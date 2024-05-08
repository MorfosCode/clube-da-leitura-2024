using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigos : TelaBase
    {

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Amigo entidade = (Amigo)ObterRegistro();
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

                Console.WriteLine("Visualizando amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                "Id", "Nome", "Responsavel", "Telefone", "Endereço"
            ); ArrayList amigosCadastradas = repositorio.SelecionarTodos();

            foreach (Amigo amigo in amigosCadastradas)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    amigo.Id,
                    amigo.nome,
                    amigo.responsavel,
                    amigo.telefone,
                    amigo.endereco
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o  responsavel: ");
            string responsavel = Console.ReadLine();

            Console.Write("Informe o telefone: "); 
            string telefone = Console.ReadLine();

            Console.Write("Informe o endereçço: ");
            string endereco = Console.ReadLine();

            Amigo novoAmigo = new Amigo(nome, responsavel,telefone,endereco);

            return novoAmigo;
        }
    }
}
