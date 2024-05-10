using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase
    {
        public TelaAmigos telaAmigo = null;
        public RepositorioAmigos repositorioAmigos = new RepositorioAmigos();

        public TelaRevista telaRevista = null;
        public RepositorioRevistas repositorioRevistas = new RepositorioRevistas();

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Reservas de Revistas...");
            }

            Console.WriteLine();

            Console.WriteLine
            (
                "{0, -5} | {1, -25} | {2, -25} | {3, -15}",
                "Id", "Amigo", "Título da Revista", "Data de Reserva"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -5} | {1, -25} | {2, -25} | {3, -15}",
                    reserva.Id,
                    reserva.amigo.nome,
                    reserva.revista.titulo,
                    reserva.dataReserva
                );
            }
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        
        {
            Console.WriteLine("Solicitação de reserva de revista!");
            
            telaAmigo.VisualizarRegistros(false);

            Console.Write("ID do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigos.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);

            Console.Write("ID da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevistas.SelecionarPorId(idAmigo);

            DateTime hoje = DateTime.Now;

            Reserva novaReserva = new Reserva(amigoSelecionado, revistaSelecionada, hoje);

            return novaReserva;
        }
    }
}
