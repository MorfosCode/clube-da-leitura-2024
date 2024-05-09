using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Emprestimo: EntidadeBase
    {
        public Emprestimo(Revista revista, Amigo amigo, DateTime dtEmpretimo, DateTime dtdevolucao)
        {
            Revista = revista;
            Amigo = amigo;
            this.dtEmpretimo = dtEmpretimo;
            this.dtDevolucao = dtdevolucao;
        }

        public Revista Revista { set; get; }
        public Amigo Amigo { set; get; }        
        public DateTime dtEmpretimo { set; get; }
        public DateTime dtDevolucao { set; get; }   

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Emprestimo emprestimo = (Emprestimo)novoregistro;

            this.Revista = emprestimo.Revista;
            this.Amigo = emprestimo.Amigo;
            this.dtEmpretimo = emprestimo.dtEmpretimo;
            this.dtDevolucao = emprestimo.dtDevolucao;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}