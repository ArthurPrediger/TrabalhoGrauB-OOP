using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoGrauB_OOP
{
    class Sistema
    {
        private List<Process> processos;

        public Sistema()
        {
            processos = new List<Process>();
        }

        public int CriarPid()
        {
            int i = 0;
            while(true)
            {
                if(!processos.Exists(x=> x.pid == i))
                {
                    return i;
                }
                i++;
            }
        }

        public void CriarProcesso(string tipoP,  string expressao)
        {
            if(tipoP == ComputingProcess.tipo)
            {
                processos.Add(new ComputingProcess(CriarPid(), expressao));
            }
            else if(tipoP == WritingProcess.tipo)
            {
                processos.Add(new WritingProcess(CriarPid(), expressao));
            }

            Console.WriteLine("O pid do processo criado é: " + processos.Last().pid.ToString());
        }
        public void CriarProcesso(string tipoP)
        {
            if(tipoP == ReadingProcess.tipo)
            {
                processos.Add(new ReadingProcess(CriarPid(), ref processos));
            }
            else if(tipoP == PrintingProcess.tipo)
            {
                processos.Add(new PrintingProcess(CriarPid(), ref processos));
            }

            Console.WriteLine("O pid do processo criado é: " + processos.Last().pid.ToString());
        }

        public void ExecutarProximo()
        {
            if (processos.Count < 1)
            {
                Console.WriteLine("Nenhum processo na fila.");
            }
            else
            {
                if (processos.First() is ComputingProcess)
                {
                    (processos.First() as ComputingProcess).Execute();
                }
                else if (processos.First() is WritingProcess)
                {
                    (processos.First() as WritingProcess).Execute();
                }
                else if (processos.First() is ReadingProcess)
                {
                    (processos.First() as ReadingProcess).Execute();
                }
                else if (processos.First() is PrintingProcess)
                {
                    (processos.First() as PrintingProcess).Execute();
                }
                processos.RemoveAt(0);
            }
        }

        public void ExecutarEspecifico(int pid)
        {
            if(processos.Exists(x => x.pid == pid))
            {
                int index = processos.FindIndex(x => x.pid == pid);
                if (processos[index] is ComputingProcess)
                {
                    (processos[index] as ComputingProcess).Execute();
                }
                else if (processos[index] is WritingProcess)
                {
                    (processos[index] as WritingProcess).Execute();
                }
                else if (processos[index] is ReadingProcess)
                {
                    (processos[index] as ReadingProcess).Execute();
                }
                else if (processos[index] is PrintingProcess)
                {
                    (processos[index] as PrintingProcess).Execute();
                }
                processos.RemoveAt(index);
            }
            else 
            {
                Console.WriteLine("Processo com o pid informado não existe.");
            }
        }

        public void SalvarProcessos(string nomeArq)
        {
            StringBuilder sb = new();
            for(int i = 0; i < processos.Count; i++)
            {
                if (processos[i] is ComputingProcess)
                {
                    sb.AppendLine((processos[i] as ComputingProcess).Serializar());
                }
                else if (processos[i] is WritingProcess)
                {
                    sb.AppendLine((processos[i] as WritingProcess).Serializar());
                }
                else if (processos[i] is ReadingProcess)
                {
                    sb.AppendLine((processos[i] as ReadingProcess).Serializar());
                }
                else if (processos[i] is PrintingProcess)
                {
                    sb.AppendLine((processos[i] as PrintingProcess).Serializar());
                }
            }

            StreamWriter sw = File.CreateText(nomeArq);
            sw.Write(sb.ToString());
            sw.Close();
            Console.WriteLine("Salvamento realizado.");
        }

        public void CarregarProcessos(string nomeArq)
        {
            if (File.Exists(nomeArq))
            {
                StreamReader sr = File.OpenText(nomeArq);

                while(!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] strAux = str.Split(";");

                    if (strAux[0] == ComputingProcess.tipo)
                    {
                        processos.Add(new ComputingProcess(CriarPid(), strAux[1]));
                    }
                    else if (strAux[0] == WritingProcess.tipo)
                    {
                        processos.Add(new WritingProcess(CriarPid(), strAux[1]));
                    }
                    else if (strAux[0] == ReadingProcess.tipo)
                    {
                        processos.Add(new ReadingProcess(CriarPid(), ref processos));
                    }
                    else if (strAux[0] == PrintingProcess.tipo)
                    {
                        processos.Add(new PrintingProcess(CriarPid(), ref processos));
                    }
                }

                sr.Close();
                Console.WriteLine("Carregamento realizado.");
            }
            else
            {
                Console.WriteLine("O arquivo informado não existe.");
            }
        }
    }
}
