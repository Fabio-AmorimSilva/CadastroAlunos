using System;
using System.Collections.Generic;

/*
Refatoração do Exemplo utilizando listas encadeadas para permitir o crescimento do número de alunos
Fonte: Refatoração do Curso de Introdução ao .NET e C# da Digital Innovation One 
*/

namespace cadastroAlunos
{
    class Program
    {
        static void Main(string[] args)
        {

        //Criação do array de alunos
        List<Alunos> alunos = new List<Alunos>(); 
        float mediaGeral = 0;
        float notaTotal = 0;
        string nomeAluno;

        string opUsuario = obterOpcaoUsuario();

        do{
                
                switch(opUsuario){
                    //Adicionar alunos
                    case "1":
                        try{
                            Console.WriteLine("Informe o nome do aluno:");
                            Alunos aluno = new Alunos();
                            aluno.Nome = Console.ReadLine();
                            Console.WriteLine("Informe a nota do aluno:");
                            aluno.Nota = float.Parse(Console.ReadLine());
                            alunos.Add(aluno);

                        }catch(Exception ex){
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");

                        }
                    break;
                    //Listar alunos
                    case "2":
                        Console.WriteLine("Nome e nota de todos os alunos cadastrados");
                        alunos.Sort();
                        for(int i = 0; i < alunos.Count; i++){
                            Console.WriteLine($"Nome do aluno {i+1}: " + alunos[i].Nome);
                            Console.WriteLine($"Nota do aluno {i+1}: " + alunos[i].Nota);
                            Console.WriteLine();
                        }

                        Console.WriteLine("O número de alunos matrículados é: " + alunos.Count);
                        Console.WriteLine();
                        
                    break;
                    //Calcular média geral
                    case "3":
                        Console.WriteLine("Calculando média geral.....");
                        for(int i = 0; i < alunos.Count; i++){
                            notaTotal += alunos[i].Nota;
                        }

                        mediaGeral = notaTotal/alunos.Count;

                        Console.WriteLine("A média geral de todos os alunos é: " + mediaGeral);
                    break;
                    case "4":
                        try{
                            Console.WriteLine("Digite o nome do aluno a ser buscado: ");
                            nomeAluno = Console.ReadLine();
                            buscaAluno(alunos, nomeAluno);
                            Console.WriteLine();

                        }catch(Exception ex){
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");

                        }
                    break;
                    case "5":
                        try{
                            Console.WriteLine("Digite o nome do aluno a ser buscado: ");
                            nomeAluno = Console.ReadLine();
                            alteraAluno(alunos, nomeAluno);
                            Console.WriteLine();
                            
                        }catch(Exception ex){
                            Console.WriteLine($"{ex.GetType()}: {ex.Message}");

                        }
                    break;
                    case "S":
                    return;
                    default:
                    Console.WriteLine("Insira uma das opções listadas acima!");
                    Console.WriteLine();
                    break;

                }

                opUsuario = obterOpcaoUsuario();

            }while(opUsuario.ToUpper() != "S");
            
        }

         private static string obterOpcaoUsuario(){

            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno.");
            Console.WriteLine("2 - Listar alunos.");
            Console.WriteLine("3 - Calcular média geral.");
            Console.WriteLine("4 - Buscar aluno.");
            Console.WriteLine("5 - Alterar dados do aluno.");
            Console.WriteLine("S - Sair.");
            Console.WriteLine();

            //Lê strings inseridas por usuário e retorna o valor para uma váriavel
            string opUsuario = Console.ReadLine();

            return opUsuario;

        }

        private static void buscaAluno(List<Alunos> alunos, string nome){

            for(int i = 0; i < alunos.Count; i++){

                if(nome.Equals(alunos[i].Nome)){
                    Console.WriteLine("Aluno encontrado! Apresentando dados....");
                    Console.WriteLine();
                    Console.WriteLine("Nome: " + alunos[i].Nome);
                    Console.WriteLine("Nome: " + alunos[i].Nota);

                }else{
                    Console.WriteLine("O aluno não se encontra na base de dados!");
                    break;

                }

            }

        }

        private static void alteraAluno(List<Alunos> aluno, string nome){

            for(int i = 0; i < aluno.Count; i++){

                if(nome.Equals(aluno[i].Nome)){
                    Console.WriteLine("Aluno encontrado. Insira os novos dados.");
                    Alunos novoAluno = new Alunos();
                    Console.WriteLine("Nome: ");
                    novoAluno.Nome = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Nota: ");
                    novoAluno.Nota = float.Parse(Console.ReadLine());
                    aluno.Remove(aluno[i]);
                    aluno.Add(novoAluno);

                }else {
                    Console.WriteLine("O aluno não se encontra na base de dados!");
                    break;

                }
            }
        }
    }
}
