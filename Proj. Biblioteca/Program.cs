using Proj.Biblioteca;
using System;
using System.Linq;

//Desenvolvido por Beatriz Bastos Borges e Miguel Luizatto Alves

namespace BibliotecaConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Livros acervo = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("-------- Menu --------");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro(acervo);
                        break;
                    case 2:
                        PesquisarLivroSintetico(acervo);
                        break;
                    case 3:
                        PesquisarLivroAnalitico(acervo);
                        break;
                    case 4:
                        AdicionarExemplar(acervo);
                        break;
                    case 5:
                        RegistrarEmprestimo(acervo);
                        break;
                    case 6:
                        RegistrarDevolucao(acervo);
                        break;
                }
            } while (opcao != 0);
        }

        static void AdicionarLivro(Livros acervo)
        {
            try
            {
                Console.Write("ISBN: ");
                int isbn = int.Parse(Console.ReadLine());
                Console.Write("Título: ");
                string titulo = Console.ReadLine();
                Console.Write("Autor: ");
                string autor = Console.ReadLine();
                Console.Write("Editora: ");
                string editora = Console.ReadLine();

                Livro livro = new Livro();
                livro.setIsbn(isbn);
                livro.setTitulo(titulo);
                livro.setAutor(autor);
                livro.setEditora(editora);

                acervo.Adicionar(livro);
                Console.WriteLine("Livro adicionado com sucesso.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: ISBN deve ser um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o livro: {ex.Message}");
            }
        }

        static void PesquisarLivroSintetico(Livros acervo)
        {
            try
            {
                Console.Write("Informe o ISBN do livro: ");
                int isbn = int.Parse(Console.ReadLine());
                Livro livro = acervo.Pesquisar(isbn);

                if (livro != null)
                {
                    Console.WriteLine($"Título: {livro.getTitulo()}");
                    Console.WriteLine($"Total de exemplares: {livro.QtdeExemplares()}");
                    Console.WriteLine($"Exemplares disponíveis: {livro.QtdeDisponiveis()}");
                    Console.WriteLine($"Total de empréstimos: {livro.QtdeEmprestimos()}");
                    Console.WriteLine($"Percentual de disponibilidade: {livro.PercDisponibilidade()}%");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: ISBN deve ser um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o livro: {ex.Message}");
            }
        }

        static void PesquisarLivroAnalitico(Livros acervo)
        {
            try
            {
                Console.Write("Informe o ISBN do livro: ");
                int isbn = int.Parse(Console.ReadLine());
                Livro livro = acervo.Pesquisar(isbn);

                if (livro != null)
                {
                    Console.WriteLine($"Título: {livro.getTitulo()}");
                    Console.WriteLine($"Total de exemplares: {livro.QtdeExemplares()}");
                    Console.WriteLine($"Exemplares disponíveis: {livro.QtdeDisponiveis()}");
                    Console.WriteLine($"Total de empréstimos: {livro.QtdeEmprestimos()}");
                    Console.WriteLine($"Percentual de disponibilidade: {livro.PercDisponibilidade()}%");

                    foreach (Exemplar exemplar in livro.getExemplares())
                    {
                        Console.WriteLine($"Exemplar Tombo: {exemplar.getTombo()}");
                        Console.WriteLine($"Disponível: {(exemplar.Disponivel() ? "Sim" : "Não")}");
                        Console.WriteLine($"Quantidade de Empréstimos: {exemplar.QtdeEmprestimos()}");
                        foreach (Emprestimo emprestimo in exemplar.getEmprestimos())
                        {
                            Console.WriteLine($"- Empréstimo em {emprestimo.getDtEmprestimo()}, Devolução em {(emprestimo.getDtDevolucao().HasValue ? emprestimo.getDtDevolucao().ToString() : "Não devolvido")}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: ISBN deve ser um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o livro: {ex.Message}");
            }
        }

        static void AdicionarExemplar(Livros acervo)
        {
            try
            {
                Console.Write("Informe o ISBN do livro: ");
                int isbn = int.Parse(Console.ReadLine());
                Livro livro = acervo.Pesquisar(isbn);

                if (livro != null)
                {
                    Console.Write("Tombo do exemplar: ");
                    int tombo = int.Parse(Console.ReadLine());
                    Exemplar exemplar = new Exemplar();
                    exemplar.setTombo(tombo);
                    livro.AdicionarExemplar(exemplar);
                    Console.WriteLine("Exemplar adicionado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: O valor digitado deve ser um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o livro: {ex.Message}");
            }
        }

        static void RegistrarEmprestimo(Livros acervo)
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = acervo.Pesquisar(isbn);

            if (livro != null)
            {
                Exemplar exemplar = livro.getExemplares().FirstOrDefault(e => e.Disponivel());
                if (exemplar != null && exemplar.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Nenhum exemplar disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao(Livros acervo)
        {
            try
            {
                Console.Write("Informe o ISBN do livro: ");
                int isbn = int.Parse(Console.ReadLine());
                Livro livro = acervo.Pesquisar(isbn);

                if (livro != null)
                {
                    Exemplar exemplar = livro.getExemplares().FirstOrDefault(e => !e.Disponivel());
                    if (exemplar != null && exemplar.Devolver())
                    {
                        Console.WriteLine("Devolução registrada com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum exemplar a ser devolvido.");
                    }
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: ISBN deve ser um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o livro: {ex.Message}");
            }
        }
    }
}
