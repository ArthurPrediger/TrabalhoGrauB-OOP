using System;

namespace TrabalhoGrauB_OOP
{
    class Program
    {
        static void Menu(ref Sistema sistema)
        {
            Console.WriteLine("\tExecução de processos");
            Console.WriteLine("1 - Criar processo");
            Console.WriteLine("2 - Executar próximo processos na fila");
            Console.WriteLine("3 - Executar processo específico");
            Console.WriteLine("4 - Salvar fila de processos");
            Console.WriteLine("5 - Carregar fila de processos");
            Console.WriteLine("6 - Sair");
            Console.Write("Informe a opção desejada: ");

            int input;
            do
            {
                input = int.Parse(Console.ReadLine());
            } while (input < 1 || input > 7);

            if(input == 1)
            {
                Console.WriteLine("\tSeleção de processo");
                Console.WriteLine("1 - Processo de cálculo");
                Console.WriteLine("2 - Processo de gravação");
                Console.WriteLine("3 - Processo de leitura");
                Console.WriteLine("4 - Processo de impressão");
                Console.Write("Informe a opção desejada: ");

                int i;
                do
                {
                    i = int.Parse(Console.ReadLine());
                } while (i < 1 || i > 4);

                string expressao;
                switch (i)
                {
                    case 1:
                        Console.Write("Informe uma expressão para calcular: ");
                        expressao = Console.ReadLine();
                        sistema.CriarProcesso("computacao", expressao);
                        break;
                    case 2:
                        Console.Write("Informe uma expressão para gravação: ");
                        expressao = Console.ReadLine();
                        sistema.CriarProcesso("escrita", expressao);
                        break;
                    case 3:
                        sistema.CriarProcesso("leitura");
                        break;
                    case 4:
                        sistema.CriarProcesso("impressao");
                        break;
                    default:
                        break;
                }
            }
            else if(input == 2)
            {
                sistema.ExecutarProximo();
            }
            else if (input == 3)
            {
                Console.Write("Informe o pid do processo a ser executado: ");
                int pid = int.Parse(Console.ReadLine());
                sistema.ExecutarEspecifico(pid);
            }
            else if (input == 4)
            {
                Console.Write("Informe o nome do arquivo em que a fila de processos deseja ser ser salva: ");
                string nomeArq = Console.ReadLine();
                sistema.SalvarProcessos(nomeArq);
            }
            else if (input == 5)
            {
                Console.Write("Informe o nome do arquivo do qual a fila de processos deseja ser carregada: ");
                string nomeArq = Console.ReadLine();
                sistema.CarregarProcessos(nomeArq);
            }
            else if (input == 6)
            {
                Environment.Exit(0);
            }
        }
        static void Main()
        {
            Sistema sistema = new();

            Menu(ref sistema);
        }
    }
}
