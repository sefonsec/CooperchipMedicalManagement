using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Bairro
    {
        public int BairroId { get; set; }
        public string Descricao { get; set; }
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
