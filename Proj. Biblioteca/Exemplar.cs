using BibliotecaConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int getTombo()
        {
            return tombo;
        }

        public void setTombo(int tombo)
        {
            this.tombo = tombo;
        }

        public List<Emprestimo> getEmprestimos()
        {
            return emprestimos;
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimo AdicionarEmprestimo = new Emprestimo();
                AdicionarEmprestimo.setDtEmprestimo(DateTime.Now);

                emprestimos.Add(AdicionarEmprestimo);
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            if (!Disponivel())
            {
                emprestimos.Last().setDtDevolucao(DateTime.Now);
                return true;
            }
            return false;
        }

        public bool Disponivel()
        {
            return !emprestimos.Any() || emprestimos.Last().getDtDevolucao() != null;
        }

        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}
