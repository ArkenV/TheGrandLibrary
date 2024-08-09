using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

// Model
public class Person
{
  public string Name { get; set; }
  public int Age { get; set; }
}

// ViewModel
public class MainViewModel : INotifyPropertyChanged
{
  private ObservableCollection<Person> _people;
  public ObservableCollection<Person> People
  {
    get { return _people; }
    set
    {
      _people = value;
      OnPropertyChanged(nameof(People));
    }
  }

  private string _newPersonName;
  public string NewPersonName
  {
    get { return _newPersonName; }
    set
    {
      _newPersonName = value;
      OnPropertyChanged(nameof(NewPersonName));
    }
  }

  private int _newPersonAge;
  public int NewPersonAge
  {
    get { return _newPersonAge; }
    set
    {
      _newPersonAge = value;
      OnPropertyChanged(nameof(NewPersonAge));
    }
  }

  public ICommand AddPersonCommand { get; private set; }

  public MainViewModel()
  {
    People = new ObservableCollection<Person>();
    AddPersonCommand = new RelayCommand(AddPerson, CanAddPerson);
  }

  private void AddPerson()
  {
    People.Add(new Person { Name = NewPersonName, Age = NewPersonAge });
    NewPersonName = string.Empty;
    NewPersonAge = 0;
  }

  private bool CanAddPerson()
  {
    return !string.IsNullOrWhiteSpace(NewPersonName) && NewPersonAge > 0;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  protected virtual void OnPropertyChanged(string propertyName)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}

public class RelayCommand : ICommand
{
  private readonly Action _execute;
  private readonly Func<bool> _canExecute;

  public RelayCommand(Action execute, Func<bool> canExecute = null)
  {
    _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    _canExecute = canExecute;
  }

  public event EventHandler CanExecuteChanged
  {
    add { CommandManager.RequerySuggested += value; }
    remove { CommandManager.RequerySuggested -= value; }
  }

  public bool CanExecute(object parameter)
  {
    return _canExecute == null || _canExecute();
  }

  public void Execute(object parameter)
  {
    _execute();
  }
}

// View (XAML) - MainWindow.xaml
/*
<Window x:Class="MVVMExample.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MVVM Example" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        
        <StackPanel Grid.Row="0" Orientation="Horizontal" Margin="10">
            <TextBox Text="{Binding NewPersonName, UpdateSourceTrigger=PropertyChanged}" 
                     Width="150" Margin="0,0,10,0"/>
            <TextBox Text="{Binding NewPersonAge, UpdateSourceTrigger=PropertyChanged}" 
                     Width="50" Margin="0,0,10,0"/>
            <Button Content="Add Person" Command="{Binding AddPersonCommand}" Width="100"/>
        </StackPanel>
        
        <ListView Grid.Row="1" ItemsSource="{Binding People}" Margin="10">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}" Width="150"/>
                        <TextBlock Text="{Binding Age}" Width="50"/>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Window>
*/

// View code-behind - MainWindow.xaml.cs
/*
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
*/