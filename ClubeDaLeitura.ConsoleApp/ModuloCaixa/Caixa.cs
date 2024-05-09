using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Caixa : EntidadeBase
    {
        public string cor { get; set; }
        public string etiqueta { get; set; }
        public int numero { get; set; }
        public int diasEmpretimos { get; set; }
        public Caixa(string cor, string etiqueta, int numero, int diassempretimos)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
            this.diasEmpretimos = diasEmpretimos;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (cor == null)
                erros.Add("a cor precisa ser preenchido");

            if (etiqueta == null)
                erros.Add("a etiqueta precisa ser informado");

            if (numero == null)
                erros.Add("Por favor informe o número da caixa");

            if (diasEmpretimos == null)
                erros.Add("Por favor informe quantos dias as revista estão disponiveis para empérstimo");

          

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Caixa caixa = (Caixa)novoregistro;
            this.cor = caixa.cor;
            this.etiqueta = caixa.etiqueta;
            this.numero = caixa.numero;
            this.diasEmpretimos = diasEmpretimos;
        }
    }
}