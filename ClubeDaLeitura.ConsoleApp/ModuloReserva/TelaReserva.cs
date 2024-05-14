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
        public TelaAmigos telaAmigos = null;
        public RepositorioAmigos repositorioAmigos = null;

        public TelaRevista telaRevista = null;
        public RepositorioRevistas repositorioRevistas = null;

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - {tipoEntidade}r");
            Console.WriteLine($"2 - Encerrar {tipoEntidade}");
            Console.WriteLine($"3 - Visualizar {tipoEntidade}");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Opção: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

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
                "{0, -5} | {1, -25} | {2, -25} | {3, -15} | {4, -10}",
                "Id", "Amigo", "Título da Revista", "Data de Reserva", "Status"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                string status = reserva.VerificarStatusReserva(reserva.dataReserva);

                if (reserva == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -5} | {1, -25} | {2, -25} | {3, -15} | {4, -10}",
                    reserva.Id,
                    reserva.amigo.nome,
                    reserva.revista.titulo,
                    reserva.dataReserva.ToShortDateString(),
                    status
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        
        {
            Console.WriteLine("Solicitação de reserva de revista!");

            Console.WriteLine();
            Console.WriteLine("Lista de Amigos");
            telaAmigos.VisualizarRegistros(false);

            Console.Write("ID do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigos.SelecionarPorId(idAmigo);

            Console.WriteLine();
            Console.WriteLine("Lista de Revistas");
            telaRevista.VisualizarRegistros(false);

            Console.Write("ID da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevistas.SelecionarPorId(idRevista);

            DateTime hoje = DateTime.Now;

            Reserva novaReserva = new Reserva(amigoSelecionado, revistaSelecionada, hoje);

            return novaReserva;
        }
    }
}
