using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        public ArrayList SelecionarEmprestimosDoMes()
        {
            ArrayList emprestimosDoMes = new ArrayList();

            foreach (Emprestimo emprestimo  in registros)
            {
                if(emprestimo.dtEmpretimo.Month == DateTime.Today.Month)
                    emprestimosDoMes.Add(emprestimo);
            }

            return emprestimosDoMes;
        }

        public ArrayList SelecionarEmprestimosDoDia()
        {
            ArrayList emprestimosDoDia = new ArrayList();

            foreach (Emprestimo emprestimo in registros)
            {
                if ((emprestimo.dtEmpretimo.Month == DateTime.Today.Month) &&
                    (emprestimo.dtEmpretimo.Day == DateTime.Today.Day))

                    emprestimosDoDia.Add(emprestimo);
            }

            return emprestimosDoDia;
        }
    }

}
