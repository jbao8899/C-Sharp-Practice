using System.Threading;
using System.Threading.Tasks;

namespace ThreadsIntro
{
    internal class Program
    {
        public static void ThreadFunction1()
        {
            Console.WriteLine("ThreadFunction1 called");
            Thread.Sleep(3000);
            Console.WriteLine("ThreadFunction1 completed");
        }

        public static void ThreadFunction2()
        {
            Console.WriteLine("ThreadFunction2 called");
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World 1");
            //Thread.Sleep(1000);
            //Console.WriteLine("Hello, World 2");
            //Thread.Sleep(1000);
            //Console.WriteLine("Hello, World 3");
            //Thread.Sleep(1000);
            //Console.WriteLine("Hello, World 4");

            //new Thread(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 1");
            //}).Start();
            //new Thread(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 2");
            //}).Start();
            //new Thread(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 3");
            //}).Start();
            //new Thread(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 4");
            //}).Start();

            //TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            //Thread thread = new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    taskCompletionSource.TrySetResult(true); // Try to set the task as complete
            //    Console.WriteLine($"Inside thread's id is {Thread.CurrentThread.ManagedThreadId}");
            //});
            //Console.WriteLine($"Outside thread's id is {Thread.CurrentThread.ManagedThreadId}");

            //thread.Start();

            //bool test = taskCompletionSource.Task.Result;

            //Console.WriteLine("task was done: {0}", test);

            //new Thread(() =>
            //{
            //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ending");
            //})
            //{ IsBackground = true }.Start();

            //Enumerable.Range(0, 100).ToList().ForEach(f =>
            //{
            //    // ThreadPool waits for hardware to be available to start a background thread
            //    // It reuses threads, so if they have some local data, methods which look at that data may use it
            //    ThreadPool.QueueUserWorkItem((o) =>
            //    {
            //        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
            //        Thread.Sleep(1000);
            //        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ending");
            //    });
            //});

            Console.WriteLine("Main thread started.");

            Thread thread1 = new Thread(ThreadFunction1);
            Thread thread2 = new Thread(ThreadFunction2);

            thread1.Start();
            thread2.Start();

            //thread1.Join();
            //Console.WriteLine("Thread 1 complete");
            //thread2.Join();
            //Console.WriteLine("Thread 2 complete");

            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread 1 finished within 1 second");
            }
            else
            {
                Console.WriteLine("Thread 1 did not finish within 1 second");
                // "ThreadFunction1 completed" prints after main thread ends
            }
            thread2.Join();
            Console.WriteLine("Thread 2 complete");

            Console.WriteLine("Main thread ended");

            //if (thread1.IsAlive)
            //{
            //    Console.WriteLine("Thread 1 is still doing stuff");
            //}
            //else
            //{
            //    Console.WriteLine("Thread 1 is not alive right now");
            //}

            //while (true)
            //{
            //    Thread.Sleep(300);
            //    if (thread1.IsAlive)
            //    {
            //        Console.WriteLine("Thread 1 is still doing stuff");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Thread 1 has finished");
            //        break;
            //    }

            //}


            Console.Read();
        }
    }
}