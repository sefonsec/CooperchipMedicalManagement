using System.Collections.Generic;

namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Uf
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Estado { get; set; }
        public int CodigoEstado { get; set; }

        public virtual IEnumerable<Cidade> Cidade { get; set; }
    }
}
