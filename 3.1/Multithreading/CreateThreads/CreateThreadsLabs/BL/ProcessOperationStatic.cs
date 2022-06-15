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

        public static void ExecuteShortRunningOperation(object id)
        {
            Thread.Sleep(1000);

            LogThreads.LogCompleted(nameof(ExecuteShortRunningOperation));
        }
        public static void ExecuteLongRunningOperation(object id)
        {
            Thread.Sleep(250000);
            LogThreads.LogCompleted(nameof(ExecuteShortRunningOperation));
        }
    }
}
