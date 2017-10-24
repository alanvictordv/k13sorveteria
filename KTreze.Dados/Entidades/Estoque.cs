using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class Estoque
    {
        public virtual Produto Produto { get; set; }
        public virtual Freezer Freezer { get; set; }
        public virtual int Quantidade { get; set; }

        public override int GetHashCode()
        {
            return Produto.GetHashCode() ^ Freezer.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Estoque other = obj as Estoque;
            if (other == null)
                return false;
            if (Produto == other.Produto && Freezer == other.Freezer)
                return true;
            return base.Equals(obj);
        }
    }
}
