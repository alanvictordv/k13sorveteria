using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual float PrecoVenda { get; set; }
        public virtual float PrecoCompra { get; set; }
    }
}
