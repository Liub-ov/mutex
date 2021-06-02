using System;
using System.Threading;

namespace ConsoleApp5
{
    public class MutexClass
    {
        public static int Count;
        public static Mutex mutex = new Mutex();
    }
    public class Thread1
    {
        int num;
        public Thread Thrd;

        public Thread1(string name, int n)
        {
            Thrd = new Thread(this.Run);
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }
        void Run()
        {
            Console.WriteLine(Thrd.Name + " wait for mutex");

            MutexClass.mutex.WaitOne();

            Console.WriteLine(Thrd.Name + " bring the mutex");

            do
            {
                Thread.Sleep(500);
                MutexClass.Count++;
                Console.WriteLine("in thread {0}, Count={1}", Thrd.Name, MutexClass.Count);
                num--;
            } while (num > 0);

            Console.WriteLine(Thrd.Name + " relieve the mutex ");

            MutexClass.mutex.ReleaseMutex();
        }
    }
    public class Thread2
    {
        int num;
        public Thread Thrd;

        public Thread2(string name, int n)
        {
            Thrd = new Thread(new ThreadStart(this.Run));
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }
        void Run()
        {
            Console.WriteLine(Thrd.Name + " wait for mutex");

            MutexClass.mutex.WaitOne();

            Console.WriteLine(Thrd.Name + " bring the mutex");

            do
            {
                Thread.Sleep(500);
                MutexClass.Count--;
                Console.WriteLine("in thread {0}, Count={1}", Thrd.Name, MutexClass.Count);
                num--;
            } while (num > 0);

            Console.WriteLine(Thrd.Name + " relieve the mutex");

            MutexClass.mutex.ReleaseMutex();
        }
    }
    class Program
    {
        static void Main()
        {
            Thread1 mutex1 = new Thread1("Thread1", 1);
            Thread.Sleep(1);

            Thread2 mutex2 = new Thread2("Thread2", 0);

            mutex1.Thrd.Join();
            mutex2.Thrd.Join();

            Console.ReadLine();
        }
    }
}

