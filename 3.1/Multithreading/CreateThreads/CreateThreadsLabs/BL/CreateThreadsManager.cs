using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CreateThreadsLabs.BL
{
    /// <summary>
    /// Objetivo é apresentar as diversas formas de se aplicar programação paralela usando .Net
    /// </summary>
    internal class CreateThreadsManager
    {

        ///Criar um thread sem parametro utilizando ThreadStart
        public CreateThreadsManager CreateStart_ThreadWithThreadStart()
        {
            var worker = new Thread(new ThreadStart(ProcessOperationStatic.ExecuteShortRunningOperationWithoutParameter));

            worker.Start();

            return this;
        }
    }
}
