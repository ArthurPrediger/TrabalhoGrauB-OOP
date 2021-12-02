using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoGrauB_OOP
{
    class WritingProcess : Process
    {
        public string expressao { get; }
        public new const string tipo = "escrita";

        public WritingProcess(int pid, string expressao) : base(pid)
        {
            this.expressao = expressao;
        }

        new public void Execute()
        {
            StreamWriter sw = File.AppendText("computation.txt");
            sw.WriteLine(expressao);
            sw.Close();
            Console.WriteLine("Processo de escrita executado.");
        }
        public string Serializar()
        {
            StringBuilder sb = new StringBuilder(tipo + ";" + expressao);
            return sb.ToString();
        }
    }
}
