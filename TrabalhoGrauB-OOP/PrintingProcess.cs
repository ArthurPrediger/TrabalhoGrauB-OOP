using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrauB_OOP
{
    class PrintingProcess : Process
    {
        private List<Process> processos;
        public new const string tipo = "impressao";

        public string Tipo
        {
            get { return tipo; }
        }
        public PrintingProcess(int pid, ref List<Process> processos) : base(pid)
        {
            this.processos = processos;
        }

        new public void Execute()
        {
            for(int i = 0; i < processos.Count; i++)
            {
                Console.WriteLine("\tProcessos a serem executados");
                Console.WriteLine("Processo " + (i + 1) + ":");
                Console.WriteLine("Pid: " + processos[i].pid);
                Console.WriteLine("Tipo: " + processos[i].tipo);
                if (processos[i].tipo == "computacao")
                {
                    ComputingProcess p = (ComputingProcess)processos[i];
                    Console.WriteLine("Expressao: " + p.expressao);
                }
                else if(processos[i].tipo == "computacao")
                {
                    WritingProcess p = (WritingProcess)processos[i];
                    Console.WriteLine("Expressao: " + p.expressao);
                }

            }
        }
        public string Serializar()
        {
            StringBuilder sb = new StringBuilder(tipo);
            return sb.ToString();
        }
    }
}
