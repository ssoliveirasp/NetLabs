using System;
using System.Threading;

namespace AutoResetEventLabs
{
    internal class Program
    {

        static void Main()
        {
            var autoResetLab = new AutoResetEventLab();
            
            autoResetLab.Execute();
        }
    }
}