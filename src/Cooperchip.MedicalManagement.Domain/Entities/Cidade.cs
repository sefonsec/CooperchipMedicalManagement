using System.Collections.Generic;

namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UfId { get; set; }

        public virtual Uf Uf { get; set; }
        public virtual IEnumerable<Bairro> Bairro { get; set; }
    }
}
