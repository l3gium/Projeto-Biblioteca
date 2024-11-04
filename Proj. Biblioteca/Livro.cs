using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares = new List<Exemplar>();

        public int getIsbn()
        {
            return isbn;
        }

        public void setIsbn(int isbn)
        {
            this.isbn = isbn;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getAutor()
        {
            return autor;
        }

        public void setAutor(string autor)
        {
            this.autor = autor;
        }

        public string getEditora()
        {
            return editora;
        }

        public void setEditora(string editora)
        {
            this.editora = editora;
        }

        public List<Exemplar> getExemplares()
        {
            return exemplares;
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return exemplares.Count(e => e.Disponivel());
        }

        public int QtdeEmprestimos()
        {
            return exemplares.Sum(e => e.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            return QtdeExemplares() > 0 ? (double)QtdeDisponiveis() / QtdeExemplares() * 100 : 0;
        }
    }
}
