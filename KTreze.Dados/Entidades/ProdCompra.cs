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


        public override int GetHashCode()
        {
            return Produto.GetHashCode() ^ Compra.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ProdCompra other = obj as ProdCompra;
            if (other == null)
                return false;
            if (Produto == other.Produto && Compra == other.Compra)
                return true;
            return base.Equals(obj);
        }

    }
}
