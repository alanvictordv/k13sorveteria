using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class Venda
    {
        public virtual int Id { get; set; }
        public virtual decimal? Preco { get; set; }
        public virtual decimal? Troco { get; set; }
        public virtual DateTime DataHora { get; set; }

        public virtual ICollection<ProdVenda> ProdVenda { get; set; }
    }
}
