namespace AulaEntityFramework.Models
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Endereco>? Enderecos { get; set; }
        public List<TimePessoa>? TimesPessoas { get; set; }
    }
}
