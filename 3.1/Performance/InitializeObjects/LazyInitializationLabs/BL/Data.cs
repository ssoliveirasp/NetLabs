using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LazyInitializationLabs.BL
{
    class Data
    {
        public bool CreatedSucess { get; set; }
        public Data()
        {
            CreatedSucess = true;
            //throw new System.Exception("Some Error");
        }
    }
}
