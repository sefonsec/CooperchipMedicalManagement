using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Uf
    {
        public int UfId { get; set; }
        public string Sigla { get; set; }
        public string Estado { get; set; }
        public int CodigoEstado { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
