using CreateThreadsLabs.UI;
using System;
using System.Threading;

namespace CreateThreadsLabs.BL
{
    public class ProcessOperation
    {
        public void ExecuteLongRunningOperation()
        {
            ProcessOperationStatic.ExecuteLongRunningOperation(10000);
        }
    }
}
