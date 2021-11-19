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
                processos.Add(new ComputingProcess(expressao, CriarPid()));
            }
            else if(tipoP == WritingProcess.tipo)
            {
                processos.Add(new ComputingProcess(expressao, CriarPid()));
            }
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
        }

        public void ExecutarProximo()
        {
            if (processos[0].tipo == ComputingProcess.tipo)
            {
                ComputingProcess p = (ComputingProcess)processos[0];
                p.Execute();
            }
            else if (processos[0].tipo == WritingProcess.tipo)
            {
                WritingProcess p = (WritingProcess)processos[0];
                p.Execute();
            }
            else if (processos[0].tipo == ReadingProcess.tipo)
            {
                ReadingProcess p = (ReadingProcess)processos[0];
                p.Execute();
            }
            else if (processos[0].tipo == PrintingProcess.tipo)
            {
                PrintingProcess p = (PrintingProcess)processos[0];
                p.Execute();
            }
            processos.RemoveAt(0);
        }

        public void ExecutarEspecifico(int pid)
        {
            if(processos.Exists(x => x.pid == pid))
            {
                int index = processos.FindIndex(x => x.pid == pid);
                if (processos[index].tipo == ComputingProcess.tipo)
                {
                    ComputingProcess p = (ComputingProcess)processos[index];
                    p.Execute();
                }
                else if (processos[index].tipo == WritingProcess.tipo)
                {
                    WritingProcess p = (WritingProcess)processos[index];
                    p.Execute();
                }
                else if (processos[index].tipo == ReadingProcess.tipo)
                {
                    ReadingProcess p = (ReadingProcess)processos[index];
                    p.Execute();
                }
                else if (processos[index].tipo == PrintingProcess.tipo)
                {
                    PrintingProcess p = (PrintingProcess)processos[index];
                    p.Execute();
                }
                processos.RemoveAt(index);
            }
        }

        public void SalvarProcessos()
        {
            StringBuilder sb = new();
            for(int i = 0; i < processos.Count; i++)
            {
                if (processos[i].tipo == ComputingProcess.tipo)
                {
                    ComputingProcess p = (ComputingProcess)processos[i];
                    sb.AppendLine(p.Serializar());
                }
                else if (processos[i].tipo == WritingProcess.tipo)
                {
                    WritingProcess p = (WritingProcess)processos[i];
                    sb.AppendLine(p.Serializar());
                }
                else if (processos[i].tipo == ReadingProcess.tipo)
                {
                    ReadingProcess p = (ReadingProcess)processos[i];
                    sb.AppendLine(p.Serializar());
                }
                else if (processos[i].tipo == PrintingProcess.tipo)
                {
                    PrintingProcess p = (PrintingProcess)processos[i];
                    sb.AppendLine(p.Serializar());
                }
            }

            StreamWriter sw = File.CreateText("fila_processos.txt");
            sw.Write(sb.ToString());
            sw.Close();
        }

        public void CarregarProcessos()
        {
            if (File.Exists("fila_processos.txt"))
            {
                StreamReader sr = File.OpenText("fila_processos.txt");

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
            }
        }
    }
}
