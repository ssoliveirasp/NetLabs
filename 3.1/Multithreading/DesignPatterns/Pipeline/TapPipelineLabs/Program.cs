using System;
using System.Threading;
using System.Threading.Tasks;

namespace TplPipelineLabs
{
    class Program
    {
        static void Main()
        {

            Task<int> t1 = Task.Factory.StartNew(() =>
            { return CreateUser(); });

            var t2 = t1.ContinueWith((antecedent) =>
            { return InitiateWorkflow(antecedent.Result); });
            
            var t3 = t2.ContinueWith((antecedant) =>
            { return SendEmail(antecedant.Result); });

            Console.Read();
        }

        public static int CreateUser()
        {
            //Create user, passing hardcoded user ID as 1 
            Console.WriteLine("Start - Create User");
            Thread.Sleep(1000);
            Console.WriteLine("User created \n");
            return 1;
        }

        public static int InitiateWorkflow(int userId)
        {
            //Initiate Workflow 
            Console.WriteLine("Start - Initiate Workflow");
            Thread.Sleep(1000);
            Console.WriteLine("Workflow initiates \n");

            return userId;
        }

        public static int SendEmail(int userId)
        {
            //Send email 
            Console.WriteLine("Start - Email Send");
            Thread.Sleep(1000);
            Console.WriteLine("Email sent");

            return userId;
        }
    }
}
