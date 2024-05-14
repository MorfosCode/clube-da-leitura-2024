using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
    {
        public Revista revista { get; set; }
        public Amigo amigo { set; get; }
        public DateTime dtEmpretimo { set; get; }
        public DateTime dtDevolucao { set; get; }

        public bool statusEmprestimo { set; get; }

        public Emprestimo(Revista revista, Amigo amigo)
        {
            this.revista = revista;
            this.amigo = amigo;
            this.dtEmpretimo = DateTime.Now;
            this.dtDevolucao = dtEmpretimo.AddDays(revista.Caixa.diasEmprestimo);
            this.statusEmprestimo = false;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Emprestimo emprestimo = (Emprestimo)novoregistro;

            this.revista.titulo = emprestimo.revista.titulo;
            this.amigo.nome = emprestimo.amigo.nome;
            this.dtEmpretimo = emprestimo.dtEmpretimo;
            this.dtDevolucao = emprestimo.dtDevolucao;
        }

        public override ArrayList Validar()
        {

            ArrayList erros = new ArrayList();

            if (amigo == null)
                erros.Add("a data do empréstimo precisa ser Informado!");

            return erros;
        }

       public void AbrirEmprestimo()
        {
            revista.Emprestar();
        }
        
        public void FecharEmprestimo()
        {
            revista.Devolver();
            statusEmprestimo = true;
        }
    }
}