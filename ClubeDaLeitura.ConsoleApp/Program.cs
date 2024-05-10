using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;


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
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;

            telaEmprestimo.telaAmigos = telaAmigos;
            telaEmprestimo.telaRevista = telaRevista;

            telaEmprestimo.repositorioAmigos = repositorioAmigos;
            telaEmprestimo.repositorioRevistas = repositorioRevista;
            
            telaEmprestimo.EntidadeTeste();


            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaAmigos;
                else if(opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;
                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRevista;
                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaEmprestimo;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }
    }
}

