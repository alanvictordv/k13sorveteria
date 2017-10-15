using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class ProdVenda
    {
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual int Quantidade { get; set; }
    }
}
