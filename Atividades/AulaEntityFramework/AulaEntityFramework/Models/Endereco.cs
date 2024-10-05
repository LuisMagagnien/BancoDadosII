using System.ComponentModel.DataAnnotations.Schema;

namespace AulaEntityFramework.Models
{
    public enum UF
    {
        RS, SC, PR, SP, RJ, ES, MS, MT, MG, RO, AC,
        RR, AM, PA, AP, TO, GO, MA, PI, CE, PB, PE,
        AL, SE, BA, DF
    }

    public class Endereco
    {
        public int Id { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public UF UF { get; set; }
        public string? Pais { get; set; } = "Brasil";
        public string? CEP { get; set; }

        public long PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        public Pessoa? Pessoa { get; set; }
    }
}
