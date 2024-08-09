using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

class ProducerConsumerExample
{
  private static BlockingCollection<int> _queue = new BlockingCollection<int>(boundedCapacity: 5);
  private static Random _random = new Random();

  static async Task Main(string[] args)
  {
    Console.WriteLine("Producer-Consumer Pattern Example");
    Console.WriteLine("Press any key to stop the program...");

    using var cts = new CancellationTokenSource();

    var producerTask = Task.Run(() => ProduceItems(cts.Token));
    var consumerTask1 = Task.Run(() => ConsumeItems("Consumer 1", cts.Token));
    var consumerTask2 = Task.Run(() => ConsumeItems("Consumer 2", cts.Token));

    Console.ReadKey();
    cts.Cancel();

    await Task.WhenAll(producerTask, consumerTask1, consumerTask2);

    Console.WriteLine("Program finished.");
  }

  static void ProduceItems(CancellationToken cancellationToken)
  {
    try
    {
      while (!cancellationToken.IsCancellationRequested)
      {
        int item = _random.Next(1, 100);
        _queue.Add(item, cancellationToken);
        Console.WriteLine($"Produced: {item}");
        Thread.Sleep(_random.Next(100, 1000));
      }
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine("Producer was cancelled.");
    }
    finally
    {
      _queue.CompleteAdding();
    }
  }

  static void ConsumeItems(string consumerName, CancellationToken cancellationToken)
  {
    try
    {
      foreach (var item in _queue.GetConsumingEnumerable(cancellationToken))
      {
        Console.WriteLine($"{consumerName} consumed: {item}");
        Thread.Sleep(_random.Next(100, 1000));
      }
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine($"{consumerName} was cancelled.");
    }
  }
}