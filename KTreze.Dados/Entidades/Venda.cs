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
        public virtual float Preco { get; set; }
        public virtual float Troco { get; set; }
        public virtual DateTime DataHora { get; set; }
    }
}
