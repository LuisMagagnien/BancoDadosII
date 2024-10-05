namespace AulaEntityFramework.Models
{
    public class Time
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public List<TimePessoa>? TimesPessoas { get; set; }
    }
}
