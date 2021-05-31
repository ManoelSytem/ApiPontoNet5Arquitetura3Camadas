using Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RetornoAPI
{
    public class Retorno
    {
        public Retorno()
        {
            Erros = new List<string>();
        }

        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }
    }
}
