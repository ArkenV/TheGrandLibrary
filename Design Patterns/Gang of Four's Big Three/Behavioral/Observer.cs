using System;
using System.Collections.Generic;

// Subject Contract
public interface ISecurityMonitor
{
  void RegisterObserver(ISecurityComponent observer);
  void RemoveObserver(ISecurityComponent observer);
  void NotifyObservers();
}

// Observer Contract
public interface ISecurityComponent
{
  void Update(int threatLevel, int activeIncidents, int vulnerabilities);
}

// Concrete Subject
public class SecurityMonitor : ISecurityMonitor
{
  private List<ISecurityComponent> observers;
  private int threatLevel;
  private int activeIncidents;
  private int vulnerabilities;

  public SecurityMonitor()
  {
    observers = new List<ISecurityComponent>();
  }

  public void RegisterObserver(ISecurityComponent observer)
  {
    observers.Add(observer);
  }

  public void RemoveObserver(ISecurityComponent observer)
  {
    observers.Remove(observer);
  }

  public void NotifyObservers()
  {
    foreach (var observer in observers)
    {
      observer.Update(threatLevel, activeIncidents, vulnerabilities);
    }
  }

  public void SetSecurityStatus(int threatLevel, int activeIncidents, int vulnerabilities)
  {
    this.threatLevel = threatLevel;
    this.activeIncidents = activeIncidents;
    this.vulnerabilities = vulnerabilities;
    NotifyObservers();
  }
}

// Concrete Observers
public class DashboardDisplay : ISecurityComponent
{
  public void Update(int threatLevel, int activeIncidents, int vulnerabilities)
  {
    Console.WriteLine($"Dashboard Alert: Threat Level {threatLevel}, Active Incidents: {activeIncidents}, Vulnerabilities: {vulnerabilities}");
  }
}

public class IncidentResponseTeam : ISecurityComponent
{
  public void Update(int threatLevel, int activeIncidents, int vulnerabilities)
  {
    if (threatLevel >= 3 || activeIncidents > 5)
    {
      Console.WriteLine("Incident Response Team: High alert! Initiating emergency protocols.");
    }
    else
    {
      Console.WriteLine("Incident Response Team: Monitoring situation. No immediate action required.");
    }
  }
}

public class VulnerabilityScanner : ISecurityComponent
{
  private List<int> vulnerabilityHistory = new List<int>();

  public void Update(int threatLevel, int activeIncidents, int vulnerabilities)
  {
    vulnerabilityHistory.Add(vulnerabilities);
    AnalyzeVulnerabilityTrend();
  }

  private void AnalyzeVulnerabilityTrend()
  {
    if (vulnerabilityHistory.Count >= 3)
    {
      int currentVulnerabilities = vulnerabilityHistory[vulnerabilityHistory.Count - 1];
      int previousVulnerabilities = vulnerabilityHistory[vulnerabilityHistory.Count - 2];

      if (currentVulnerabilities > previousVulnerabilities)
      {
        Console.WriteLine("Vulnerability Scanner: Warning! Vulnerability count is increasing. Recommend immediate action.");
      }
      else if (currentVulnerabilities < previousVulnerabilities)
      {
        Console.WriteLine("Vulnerability Scanner: Vulnerability count is decreasing. Keep up the good work!");
      }
      else
      {
        Console.WriteLine("Vulnerability Scanner: Vulnerability count remains stable.");
      }
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    SecurityMonitor securityMonitor = new SecurityMonitor();

    DashboardDisplay dashboard = new DashboardDisplay();
    IncidentResponseTeam responseTeam = new IncidentResponseTeam();
    VulnerabilityScanner vulnScanner = new VulnerabilityScanner();

    securityMonitor.RegisterObserver(dashboard);
    securityMonitor.RegisterObserver(responseTeam);
    securityMonitor.RegisterObserver(vulnScanner);

    securityMonitor.SetSecurityStatus(2, 3, 10);
    securityMonitor.SetSecurityStatus(4, 7, 12);
    securityMonitor.SetSecurityStatus(3, 5, 8);
  }
}