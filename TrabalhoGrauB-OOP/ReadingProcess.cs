using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoGrauB_OOP
{
    class ReadingProcess : Process
    {
        private List<Process> processos;
        public new const string tipo = "leitura";
        public ReadingProcess(int pid, ref List<Process> processos) : base(pid)
        {
            this.processos = processos;
        }

        public int CriarPid()
        {
            int i = 0;
            while (true)
            {
                if (!processos.Exists(x => x.pid == i))
                {
                    return i;
                }
                i++;
            }
        }

        new public void Execute()
        {
            if (File.Exists("computation.txt"))
            {
                StreamReader sr = File.OpenText("computation.txt");
                while(!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    processos.Add(new ComputingProcess(CriarPid(), linha));
                }
                File.Create("computation.txt");
                sr.Close();
                Console.WriteLine("Processo de leitura executado.");
            }
        }
        public string Serializar()
        {
            StringBuilder sb = new StringBuilder(tipo);
            return sb.ToString();
        }
    }
}
