using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Descricao { get; set; }
        public int UfId { get; set; }

        public virtual Uf Uf { get; set; }
        public virtual ICollection<Bairro> Bairro { get; set; }
    }
}
