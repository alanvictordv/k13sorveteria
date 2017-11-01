using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Entidades
{
    public class Freezer
    {
        public virtual int Id { get; set; }
        public virtual string Numeracao { get; set; }
        public virtual string Descricao { get; set; }

        public virtual ICollection<Estoque> Estoque { get; set; }
    }
}
