using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEachLabs
{
    public class ParallelForEach
    {
        
        public static void For_Threadlocalvariable()
        {
            var numbers = Enumerable.Range(1, 60);
            long sumOfNumbers = 0;

            Action<long> taskFinishedMethod = (taskResult) =>
            {
                Console.WriteLine($"Sum at the end of all task iterations for task { Task.CurrentId} is { taskResult }");
                Interlocked.Add(ref sumOfNumbers, taskResult);
            };

            Parallel.For(1, numbers.Count(),
                () => 0,
                (i, state, subtotal) =>
                {
                    subtotal += i;
                    return subtotal;
                },
                taskFinishedMethod
            );
            Console.WriteLine($"The total of 60 numbers is {sumOfNumbers}");
        }

        /// <summary>
        ///   O exemplo a seguir executa até 100 iterações de um loop em paralelo. Cada iteração pausa para um intervalo aleatório de 1 a 1.000 milissegundos.
        ///   Um valor gerado aleatoriamente determina em qual iteração do loop o ParallelLoopState.Break método é chamado.
        ///   Como mostra a saída do exemplo, nenhuma iteração cujo índice é maior que o valor da ParallelLoopState.
        ///   LowestBreakIteration propriedade é iniciado após a chamada ao ParallelLoopState.Break método.
        ///   Chamar o Break método informa à for operação que as iterações após a atual não precisam ser executadas.
        ///   No entanto, todas as iterações antes da atual ainda precisarão ser executadas se ainda não tiverem sido executadas.
        /// </summary>
        public static void For_ParallelBreak()
        {
            var rnd = new Random();
            int breakIndex = rnd.Next(1, 11);

            Console.WriteLine($"Will call Break at iteration {breakIndex}\n");

            var result = Parallel.For(1, 101, (i, state) =>
            {
                Console.WriteLine($"Beginning iteration {i}");
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);

                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < i)
                        return;
                }

                if (i == breakIndex)
                {
                    Console.WriteLine($"Break in iteration {i}");
                    state.Break();
                }

                Console.WriteLine($"Completed iteration {i}");
            });

            if (result.LowestBreakIteration.HasValue)
                Console.WriteLine($"\nLowest Break Iteration: {result.LowestBreakIteration}");
            else
                Console.WriteLine($"\nNo lowest break iteration.");
        }
    }
}
