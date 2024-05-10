using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public string titulo { get; set; }
        public int numeroRevista { get; set; }
        public int ano { get; set; }
        public string status { get; set; }
        public Caixa Caixa { get; set; }

        public Revista(string titulo, int numeroRevista, int ano, string status, Caixa Caixa)
        {
            this.titulo = titulo;
            this.numeroRevista = numeroRevista;
            this.ano = ano;
            this.status = status;
            this.Caixa = Caixa; 
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (titulo == null)
                erros.Add("O título precisa ser preenchido!");

            if (numeroRevista == null)
                erros.Add("O número da revista precisa ser preenchido!");

            if (ano == null)
                erros.Add("O ano da revista precisa ser preenchido!");

            if (status == null)
                erros.Add("O status da revista precisa ser preenchido!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Revista revista = (Revista)novoregistro;
            this.titulo = revista.titulo;
            this.numeroRevista = revista.numeroRevista;
            this.ano = revista.ano;
            this.status = revista.status;
        }
    }
}
