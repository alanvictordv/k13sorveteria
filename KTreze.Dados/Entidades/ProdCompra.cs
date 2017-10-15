using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class ProdCompra
    {
        public virtual Produto Produto { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual int Quantidade { get; set; }
    }
}
