using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
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
        public RepositorioAmigos repositorioAmigos = null;
        public TelaAmigos telaAmigos = null;

        public RepositorioRevistas repositorioRevistas = null;
        public TelaRevista telaRevista = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Emprestimo entidade = (Emprestimo)ObterRegistro();
            ArrayList erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }


            repositorio.Cadastrar(entidade);
            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);


        }
        public override void VisualizarRegistros(bool exibirTitulo)
        {

            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixa...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -20}",
                "Id", "Amigo", "Revista", "Data Emprestimo","Data Devoução"
            ); ArrayList emprestimoCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo

                in emprestimoCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} }",
                    emprestimo.Id,
                    emprestimo.amigo.nome,
                    emprestimo.revista.titulo,
                    emprestimo.dtEmpretimo, 
                    emprestimo.dtDevolucao
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigos.VisualizarRegistros(false);

            Console.Write("Informe id do Amigo que realizará o empréstimo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecinado = (Amigo)repositorioAmigos.SelecionarPorId(idAmigo);
            
            telaRevista.VisualizarRegistros(false);

            Console.Write("Informe id da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revistaSelecinado = (Revista)repositorioRevistas.SelecionarPorId(idRevista);

            Emprestimo novoEmprestimo = new Emprestimo(revistaSelecinado, amigoSelecinado);

            return novoEmprestimo;
        }
    }
}
