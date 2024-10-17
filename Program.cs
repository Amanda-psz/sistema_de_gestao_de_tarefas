using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador_nv5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Listas de tarefas do sistema
            List<string> a_fazer = new List<string> { "Testar se a página principal do projeto está rodando;", "Criar a página secundária 'Sobre' em HTML do projeto;", "Criar o CSS da págna Principal;" };
            List<string> em_progresso = new List<string> { "Estruturar os arquivos da projeto;", "Criar a página principal em HTML do projeto;" };
            List<string> concluido = new List<string> { "Criar o diretório principal do projeto;", "Compreender as regras de négocio do projeto;" };

            int opcao = 0;

            //Menu principal de opções
            while (opcao != 4)
            {
                Console.Clear();
                Console.WriteLine("------------  Sistema de gestão de tarefas ------------");
                Console.WriteLine("1 -> Adicionar nova tarefa");
                Console.WriteLine("2 -> Exibir tarefas");
                Console.WriteLine("3 -> Mover tarefa");
                Console.WriteLine("4 -> Sair");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Escolha a opção desejada: ");

                //Variável que guarda a opção escolhida no menu
                string escolha = Console.ReadLine();

                if (int.TryParse(escolha, out opcao))
                {
                    switch(opcao)
                    {
                        case 1:
                            Console.WriteLine("Digite a tarefa que deseja adicionar na lista 'A Fazer': ");
                            //Variável que guarda a tarefa a ser adicionada
                            string nova_tarefa = Console.ReadLine();

                            //Adiciona uma tarefa se a condição for atendida, se valor na variável 'nova_tarefa' não for nulo/vazio
                            if(!string.IsNullOrWhiteSpace(nova_tarefa))
                            {
                                a_fazer.Add(nova_tarefa);
                                Console.WriteLine("Tarefa adicionada!");
                            }
                            else
                            {
                                Console.WriteLine("Erro, tarafa inválida. Tente novamente.");
                            }
                            break;

                        case 2:
                            //Exibe todas as listas de tarefas
                            Console.WriteLine("Tarefas à fazer:");
                            foreach (var tarefa  in a_fazer)
                            {
                                Console.WriteLine(tarefa);
                            }
                            Console.WriteLine("\nTarefas em progresso:");
                            foreach (var tarefa in em_progresso)
                            {
                                Console.WriteLine(tarefa);
                            }
                            Console.WriteLine("\nTarefas concluídas:");
                            foreach(var tarefa in concluido)
                            {
                                Console.WriteLine(tarefa);
                            }
                            break;

                        case 3:
                            //Mostra as opções das listas
                            Console.WriteLine("Mover tarefa: ");
                            Console.WriteLine("1 -> Da lista 'A fazer' para lista 'Em progresso'");
                            Console.WriteLine("2 -> Da lista 'Em progresso' para lista 'Concluído'");
                            string opcao_mover = Console.ReadLine();

                            //Move a tarefa nas listas de acordo com opção das listas escolhida
                            switch(opcao_mover)
                            {
                                case "1":
                                    MoverTarefa(a_fazer, em_progresso, "A fazer", "Em progresso");
                                    break;
                                case "2":
                                    MoverTarefa(em_progresso, concluido, "Em progresso", "Concluído");
                                    break;
                                default:
                                    Console.WriteLine("A opção escolhida é inválida!");
                                    break;
                            }
;                            break;

                        //Sai do sistema
                        case 4:
                            Console.WriteLine("Saindo do sistema...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Por favor digite um número de opção válido");
                }

                
                //Mostra o número da opção desejada na tela
                if(opcao != 4)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Função que move uma determinada tarefa entre listas escolhidas
        private static void MoverTarefa(List<string> lista_de_origem, List<string> lista_de_destino, string nome_de_origem, string nome_de_destino)
        {
            //Condição para caso a lista esteja vazia
            if (lista_de_origem.Count == 0)
            {
                Console.WriteLine($"Não existe tarefas na lista '{nome_de_origem}' para mover.");
                return;
            }

            //Condição que mostra as tarefas da lista de origem para a escolha de determinada tarefa para lista de destino
            Console.WriteLine($"Escolha qual a tarefa deseja mover da lista '{nome_de_origem}': ");
            for (int i = 0; i < lista_de_origem.Count; i++)
            {
                Console.WriteLine($"{i + 1} -> {lista_de_origem[i]}");
            }

            //Variável que guarda a tarefa escolhida
            string tarefa_escolhida = Console.ReadLine();
            if (int.TryParse(tarefa_escolhida, out int index_tarefa) && index_tarefa > 0 && index_tarefa <= lista_de_origem.Count)
            {
                string tarefa_movida = lista_de_origem[index_tarefa - 1];
                lista_de_origem.RemoveAt(index_tarefa - 1);
                lista_de_destino.Add(tarefa_movida);
                Console.WriteLine($"A tarefa '{tarefa_movida}' foi movida da lista '{nome_de_origem}' para lista '{nome_de_destino}'!");
            }
            else
            {
                Console.WriteLine("A tarefa escolhida não é válida! Tente novamente.");
            }
        }
    }
}
