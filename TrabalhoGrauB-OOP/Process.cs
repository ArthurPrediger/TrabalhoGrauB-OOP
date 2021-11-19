using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrauB_OOP
{
    class Process
    {
        public int pid { get; set; }
        public string tipo { get; set; }
        
        public Process(int pid)
        {
            this.pid = pid;
        }

        public void Execute()
        {

        }
    }
}
