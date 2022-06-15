using CreateThreadsLabs.UI;
using System.Threading;

namespace CreateThreadsLabs.BL
{
    internal static class ProcessOperationStatic
    {
        public static void ExecuteShortRunningOperationWithoutParameter()
        {
            ExecuteShortRunningOperation(null);
        }

        public static void ExecuteShortRunningOperation(object milliseconds)
        {
            if (milliseconds == null || (int)milliseconds <= 1000)
                milliseconds = 1000;

            Thread.Sleep((int)milliseconds);

            LogThreads.LogCompleted(nameof(ExecuteShortRunningOperation));
        }
        public static void ExecuteLongRunningOperation(object milliseconds)
        {
            if (milliseconds == null || (int)milliseconds <= 250000)
                milliseconds = 250000;

            Thread.Sleep((int)milliseconds);
            LogThreads.LogCompleted(nameof(ExecuteShortRunningOperation));
        }
    }
}
