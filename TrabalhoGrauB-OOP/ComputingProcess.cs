using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrauB_OOP
{
    class ComputingProcess : Process
    {
        public string expressao { get; }
        public float resultado { get; set; }
        public new const string tipo = "computacao";
        public ComputingProcess(int pid, string expressao) : base(pid)
        {
            this.expressao = expressao;
        }

        new public void Execute ()
        {
            string[] str = expressao.Split(" ");
            float num1 = float.Parse(str[0]);
            float num2 = float.Parse(str[2]);

            switch(str[1])
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }

            Console.WriteLine("Expressão calculada: " + expressao);
            Console.WriteLine("Resultado: " + resultado);
        }

        public string Serializar()
        {
            StringBuilder sb = new StringBuilder(tipo + ";" + expressao);
            return sb.ToString();
        }
    }
}
