using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

class ThreadPoolExample
{
  private static ConcurrentQueue<Task> taskQueue = new ConcurrentQueue<Task>();
  private static int maxThreads = Environment.ProcessorCount;
  private static SemaphoreSlim semaphore = new SemaphoreSlim(maxThreads);
  private static Random random = new Random();

  static async Task Main()
  {
    Console.WriteLine($"Using a thread pool with {maxThreads} threads.");

    for (int i = 0; i < 20; i++)
    {
      int taskId = i;
      taskQueue.Enqueue(new Task(() => ProcessTask(taskId)));
    }

    var processingTasks = new List<Task>();
    for (int i = 0; i < maxThreads; i++)
    {
      processingTasks.Add(ProcessQueueAsync());
    }

    await Task.WhenAll(processingTasks);

    Console.WriteLine("All tasks completed.");
  }

  static async Task ProcessQueueAsync()
  {
    while (true)
    {
      await semaphore.WaitAsync();

      try
      {
        if (taskQueue.TryDequeue(out Task task))
        {
          task.Start();
          await task;
        }
        else
        {
          break;
        }
      }
      finally
      {
        semaphore.Release();
      }
    }
  }

  static void ProcessTask(int taskId)
  {
    Console.WriteLine($"Starting task {taskId} on thread {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(random.Next(1000, 5000));
    Console.WriteLine($"Completed task {taskId} on thread {Thread.CurrentThread.ManagedThreadId}");
  }
}