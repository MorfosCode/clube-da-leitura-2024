using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Emprestimo : EntidadeBase
    {
        public Revista revista { get; set; }
        public Caixa caixa { get; set; }    
        public Amigo amigo
        { set; get; }
        public DateTime dtEmpretimo { set; get; }
        public DateTime dtDevolucao { set; get; }
        public int QuantidadeDiasEmAberto
        {
            get
            {
                DateTime dataHoje = DateTime.Now;

                TimeSpan diferenca = dataHoje.Subtract(dtEmpretimo);

                int diferencaNumero = diferenca.Days;

                return diferencaNumero;
            }
        }
        public Emprestimo(Revista revista, Amigo amigo)
        {
            revista = revista;
            amigo = amigo;
            this.dtEmpretimo = DateTime.Today;
            this.dtDevolucao = dtEmpretimo.AddDays(caixa.diasEmprestimo);
        }
        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Emprestimo emprestimo = (Emprestimo)novoregistro;

            this.revista = emprestimo.revista;
            this.amigo = emprestimo.amigo;
            this.dtEmpretimo = emprestimo.dtEmpretimo;
            this.dtDevolucao = emprestimo.dtDevolucao;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}