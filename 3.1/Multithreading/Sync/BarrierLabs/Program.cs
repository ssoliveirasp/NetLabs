using System;

namespace BarrierLabs
{
    /// <summary>
    /// Uma Barrier é um objeto que impede que as tarefas individuais em uma operação paralela continuem até que todas as tarefas atinjam a barreira.
    /// É útil quando uma operação paralela ocorre em fases e cada fase requer a sincronização entre as tarefas.
    /// 
    /// https://docs.microsoft.com/pt-br/dotnet/standard/threading/how-to-synchronize-concurrent-operations-with-a-barrier
    /// </summary>
    internal class Program
    {
        static void Main()
        {
            BarrierTeaMaker.MakeTea();
        }
    }
}
