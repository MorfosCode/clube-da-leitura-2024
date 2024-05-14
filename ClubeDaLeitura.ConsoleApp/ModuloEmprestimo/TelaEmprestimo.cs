using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {

        public TelaRevista telaRevista = null;
        public TelaAmigos telaAmigos = null;

        public RepositorioRevistas repositorioRevistas = null;
        public RepositorioAmigos repositorioAmigos = null;

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - {tipoEntidade}r");
            Console.WriteLine($"2 - Devolver");
            Console.WriteLine($"3 - Visualizar {tipoEntidade}");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Opção: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Emprestimo emprestimo = (Emprestimo)ObterRegistro();
            ArrayList erros = emprestimo.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            //Altera o status de 'Disponível' para 'emprestada'
            emprestimo.Emprestar();
            base.InserirRegisdtro(emprestimo);
        }
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Empréstimo...");

            Console.WriteLine();
            Console.WriteLine("1 - Emprestimos do mês");
            Console.WriteLine("2 - Emprestimos em aberto");
            Console.WriteLine("3 - Todos emprestimos");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine();
            Console.Write("Opção: ");
            char opcao = Console.ReadLine()[0];

            ArrayList emprestimos;

            if (opcao == '1')
                emprestimos = ((RepositorioEmprestimo)repositorio).SelecionarEmprestimosDoMes();

            else if (opcao == '2')
                emprestimos = ((RepositorioEmprestimo)repositorio).SelecionarEmprestimosDoDia();

            else if (opcao == '3')
                emprestimos = repositorio.SelecionarTodos();
            else
                emprestimos = repositorio.SelecionarTodos();

            VisualizarEmprestimos(emprestimos);
        }

        public void VisualizarEmprestimos(ArrayList emprestimos)
        {
            Console.WriteLine(
                "{0, -5} | {1, -25} | {2, -25} | {3, -15} | {4, -12} | {5, -12}",
                "Id", "Amigo", "Revista", "Data Emprestimo", "Prazo", "Status"
            );
            
            ArrayList emprestimoCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimoCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -5} | {1, -25} | {2, -25} | {3, -15} | {4, -12} | {5, -12}",
                    emprestimo.Id,
                    emprestimo.amigo.nome,
                    emprestimo.revista.titulo,
                    emprestimo.dtEmpretimo.ToShortDateString(),
                    emprestimo.dtDevolucao.ToShortDateString(),
                    emprestimo.statusEmprestimo
                );
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigos.VisualizarRegistros(false);

            Console.Write("Informe o id do Amigo que realizará o empréstimo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecinado = (Amigo)repositorioAmigos.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);

            Console.Write("Informe id da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecinado = (Revista)repositorioRevistas.SelecionarPorId(idRevista);

            return new Emprestimo(revistaSelecinado, amigoSelecinado);
        }

        public void EntidadeTeste()
        {
            Revista revista= (Revista)repositorioRevistas.SelecionarTodos()[0];
            Amigo amigo = (Amigo)repositorioAmigos.SelecionarTodos()[0];
            
            Emprestimo emprestimo = new Emprestimo(revista, amigo);
           
            repositorio.Cadastrar(emprestimo);
        }
    }
}
