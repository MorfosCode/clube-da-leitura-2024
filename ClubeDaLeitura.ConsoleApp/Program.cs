using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;


namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigos repositorioAmigos = new RepositorioAmigos();
            TelaAmigos telaAmigos = new TelaAmigos();
            telaAmigos.tipoEntidade = "Amigo";
            telaAmigos.repositorio = repositorioAmigos;

            telaAmigos.EntidadeTeste();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;

            telaCaixa.EntidadeTeste();

            RepositorioRevistas repositorioRevista = new RepositorioRevistas();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevista;

            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;

            telaRevista.EntidadeTeste();

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Emprestar";
            telaEmprestimo.repositorio = repositorioEmprestimo;

            telaEmprestimo.telaAmigos = telaAmigos;
            telaEmprestimo.telaRevista = telaRevista;

            telaEmprestimo.repositorioAmigos = repositorioAmigos;
            telaEmprestimo.repositorioRevistas = repositorioRevista;
            
            telaEmprestimo.EntidadeTeste();

            RepositorioReserva repositorioReserva = new RepositorioReserva();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;
            telaReserva.telaAmigos = telaAmigos;
            telaReserva.telaRevista = telaRevista;
            telaReserva.repositorioAmigos = repositorioAmigos;
            telaReserva.repositorioRevistas = repositorioRevista;


            while (true)
            {
                char opcaoTelaEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoTelaEscolhida == 'S' || opcaoTelaEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoTelaEscolhida == '1')
                    tela = telaAmigos;
                else if(opcaoTelaEscolhida == '2')
                    tela = telaCaixa;
                else if (opcaoTelaEscolhida == '3')
                    tela = telaRevista;
                else if (opcaoTelaEscolhida == '4')
                    tela = telaEmprestimo;
                else if (opcaoTelaEscolhida == '5')
                    tela = telaReserva;

                char opcaoSubMenu = tela.ApresentarMenu();

                if (opcaoSubMenu == 'S' || opcaoSubMenu == 's')
                    continue;

                if (opcaoTelaEscolhida == '4')
                {
                    if (opcaoSubMenu == '1')
                        telaEmprestimo.Registrar();
                    else if (opcaoSubMenu == '2')
                        telaEmprestimo.Excluir();
                    else if (opcaoSubMenu == '3')
                        telaEmprestimo.VisualizarRegistros(true);
                }

                else if (opcaoTelaEscolhida == '5')
                {
                    if (opcaoSubMenu == '1')
                        telaReserva.Registrar();
                    else if (opcaoSubMenu == '2')
                        telaReserva.Excluir();
                    else if (opcaoSubMenu == '3')
                        telaReserva.VisualizarRegistros(true);
                }

                if (opcaoSubMenu == '1')
                    tela.Registrar();

                else if (opcaoSubMenu == '2')
                    tela.Editar();

                else if (opcaoSubMenu == '3')
                    tela.Excluir();

                else if (opcaoSubMenu == '4')
                    tela.VisualizarRegistros(true);
            }
            Console.ReadLine();
        }
    }
}

