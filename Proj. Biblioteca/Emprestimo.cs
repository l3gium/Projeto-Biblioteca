using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime? dtDevolucao;

        public DateTime getDtEmprestimo()
        {
            return dtEmprestimo;
        }

        public void setDtEmprestimo(DateTime dtEmprestimo)
        {
            this.dtEmprestimo = dtEmprestimo;
        }

        public DateTime? getDtDevolucao()
        {
            return dtDevolucao;
        }

        public void setDtDevolucao(DateTime? dtDevolucao)
        {
            this.dtDevolucao = dtDevolucao;
        }
    }
}
