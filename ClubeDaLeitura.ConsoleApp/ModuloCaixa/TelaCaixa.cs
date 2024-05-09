using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Caixa entidade = (Caixa)ObterRegistro();
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
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} ",
                "Id", "Cor", "Etiqueta", "Numero"
            ); ArrayList caixaCadastradas = repositorio.SelecionarTodos();

            foreach (Caixa caixa
                in caixaCadastradas)
            {
                if (caixa == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} }",
                    caixa.Id,
                    caixa.cor,
                    caixa.etiqueta,
                    caixa.numero
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Informe a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Informe o etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Informe o numero da caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());  
            Console.Write("Informe a quantidade de dia disponiveis comessa etiqueta: ");
            int dias = Convert.ToInt32(Console.ReadLine());   


            Caixa novaCaixa = new Caixa(cor, etiqueta, numero, dias);

            return novaCaixa;
        }
    }
}
