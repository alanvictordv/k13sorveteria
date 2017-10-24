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

        public override int GetHashCode()
        {
            return Produto.GetHashCode() ^ Venda.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ProdVenda other = obj as ProdVenda;
            if (other == null)
                return false;
            if (Produto == other.Produto && Venda == other.Venda)
                return true;
            return base.Equals(obj);
        }
    }
}
