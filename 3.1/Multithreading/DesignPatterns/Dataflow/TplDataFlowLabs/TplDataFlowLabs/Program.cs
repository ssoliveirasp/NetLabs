using System;
using System.Threading;
using System.Threading.Tasks;

namespace TplDataFlowLabs
{
    static class Program
    {
        static void Main()
        {
            //Creating two tasks t1 and t2 and starting them at the same //time
            Task<int> t1 = Task.Factory.StartNew(() => Task1());
            Task<int> t2 = Task.Factory.StartNew(() => Task2());

            //Creating task 3 and used ContinueWhenAll that runs when both the 
            //tasks T1 and T2 will be completed
            Task<int> t3 = Task.Factory.ContinueWhenAll(
            new[] { t1, t2 }, (_) => Task3());

            //Task 4 and Task 5 will be started when Task 3 will be completed. 
            //ContinueWith actually creates a continuation of executing tasks 
            //T4 and T5 asynchronously when the task T3 is completed
            Task<int> t4 = t3.ContinueWith((_) => Task4());
            Task<int> t5 = t3.ContinueWith((_) => Task5());
            Console.Read();
        }
        //Implementation of Task1
        public static int Task1()
        {
            Console.WriteLine("Task 1 is Started");
            Thread.Sleep(1200);
            Console.WriteLine("Task 1 is executed");
            return 1;
        }

        //Implementation of Task2 
        public static int Task2()
        {
            Console.WriteLine("Task 2 is Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 is executed");
            return 1;
        }
        //Implementation of Task3 
        public static int Task3()
        {
            Console.WriteLine("Task 3 is Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task 3 is executed");
            return 1;
        }
        //Implementation of Task4
        public static int Task4()
        {
            Console.WriteLine("Task 4 is Started");
            Thread.Sleep(1200);
            Console.WriteLine("Task 4 is executed");
            return 1;
        }
        //Implementation of Task5
        public static int Task5()
        {
            Console.WriteLine("Task 5 is Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task 5 is executed");
            return 1;
        }
    }
}
