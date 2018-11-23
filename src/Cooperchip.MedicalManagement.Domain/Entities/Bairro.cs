namespace Cooperchip.MedicalManagement.Domain.Entities
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
