using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Livros
    {
        private List<Livro> acervo = new List<Livro>();

        public List<Livro> getAcervo()
        {
            return acervo;
        }

        public void Adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro Pesquisar(int isbn)
        {
            return acervo.FirstOrDefault(l => l.getIsbn() == isbn);
        }
    }
}
