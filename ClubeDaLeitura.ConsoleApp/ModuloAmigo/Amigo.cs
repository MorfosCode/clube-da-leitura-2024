using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        
        public string nome { get; set;  }
        public string responsavel{ get; set;  }
        public string telefone { get; set; }
        
        public string endereco { get; set; }
       
        public Amigo(string nome, string responsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (nome == null)
                erros.Add("O nome precisa ser preenchido");

            if (responsavel == null)
                erros.Add("O resonsavel precisa ser informado");

            if (responsavel == null)
                erros.Add("Por favor informe um contato");
            
            if (endereco == null)
                erros.Add("Por favor informe um endereço");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            Amigo amigo = (Amigo)novoregistro;
            this.nome = amigo.nome;
            this.responsavel=amigo.responsavel;
            this.telefone=amigo.telefone;
            this.endereco=amigo.endereco;
        }
    }
}