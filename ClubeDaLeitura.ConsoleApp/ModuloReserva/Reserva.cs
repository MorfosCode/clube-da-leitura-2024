using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public Amigo amigo { get; set; }
        public Revista revista { get; set; }
        public DateTime dataReserva { get; set; }

        public Reserva (Amigo amigo, Revista revista, DateTime dataReserva)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataReserva = dataReserva;
        }

        public override void AtualizarRegistro(EntidadeBase novaReserva)
        {
            Reserva reserva = (Reserva)novaReserva;
            this.amigo = reserva.amigo;
            this.revista = reserva.revista;
            this.dataReserva = reserva.dataReserva;
        }

        public string VerificarStatusReserva(DateTime dataReserva)
        {
            DateTime hoje = DateTime.Now;
            string status = null;

            int dia = Convert.ToInt32(hoje.Day);
            int dataRes = Convert.ToInt32(dataReserva.Day);

            if ((dia - dataRes) <= 2)
                status = "Reservado";
            else
                status = "Expirado";

            return status;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (amigo == null)
                erros.Add("O 'Amigo' precisa ser informado");

            if (revista == null)
                erros.Add("A 'Revista' precisa ser informada");

            return erros;
        }
    }
}
