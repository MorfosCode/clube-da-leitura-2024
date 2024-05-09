using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public Caixa caixa = null;
        public TelaCaixa telaCaixa = null;
        public RepositorioCaixa repositorioCaixa = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando revistas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -10} | {3, -15} | {4, -5} | {5, -10}",
                "ID", "TÍTULO", "Nº EDIÇÃO", "ANO PUBLICAÇÃO", "STATUS", "CAIXA"
            );
            
            ArrayList revistasCadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in revistasCadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -5} | {1, -20} | {2, -10} | {3, -15} | {4, -5} | {5, -10}",
                    revista.Id,
                    revista.titulo,
                    revista.numeroRevista,
                    revista.ano,
                    revista.status,
                    revista.idCaixa
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Nº da edição: ");
            int numeroEdicao = int.Parse(Console.ReadLine());

            Console.Write("Ano da edição: ");
            int anoEdicao = int.Parse(Console.ReadLine());

            Console.Write("Status da revista: ");
            string status = Console.ReadLine();

            telaCaixa.VisualizarRegistros(false);

            Console.Write("Id da caixa: ");
            int idCaixa = int.Parse(Console.ReadLine());


            Revista novaRevista = new Revista(titulo, numeroEdicao, anoEdicao, status, idCaixa);

            return novaRevista;
        }
    }
}
