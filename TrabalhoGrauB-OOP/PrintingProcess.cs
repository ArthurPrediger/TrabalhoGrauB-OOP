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

        public PrintingProcess(int pid, ref List<Process> processos) : base(pid)
        {
            this.processos = processos;
        }

        new public void Execute()
        {
            Console.WriteLine("\tProcessos a serem executados");
            for (int i = 0; i < processos.Count; i++)
            {
                Console.WriteLine("Processo " + (i + 1) + ":");
                Console.WriteLine("Pid: " + processos[i].pid);
                Console.WriteLine("Tipo: " + processos[i].Tipo);
                if (processos[i] is ComputingProcess)
                {
                    Console.WriteLine("Expressao: " + (processos[i] as ComputingProcess).expressao);
                }
                else if(processos[i] is WritingProcess)
                {
                    Console.WriteLine("Expressao: " + (processos[i] as WritingProcess).expressao);
                }
                Console.WriteLine();
            }
        }
        public string Serializar()
        {
            StringBuilder sb = new StringBuilder(tipo);
            return sb.ToString();
        }
    }
}
