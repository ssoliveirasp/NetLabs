using System;
using System.Threading;

namespace AutoResetEventLabs
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var autoResetLab = new AutoResetEventLab();
            
            autoResetLab.Execute();
        }
    }
}