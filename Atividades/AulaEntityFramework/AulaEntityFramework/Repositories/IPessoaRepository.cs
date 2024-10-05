using AulaEntityFramework.Models;

namespace AulaEntityFramework.Repositories
{
    public interface IPessoaRepository
    {
        public List<Pessoa>? GetAll();
        public Pessoa? Get(long id);
        public List<Pessoa>? GetByName(string? name);
        public List<Pessoa>? GetByBirthDate(DateTime date);
        public List<Pessoa>? GetByPeriodBirthDate(DateTime startDate, DateTime endDate);
        public List<Pessoa>? GetByBirthYear(int year);
        public List<Pessoa>? GetByBirthMonth(int month);
        public Pessoa? Insert(Pessoa person);
        public Pessoa? Update(Pessoa person);
        public Pessoa? Delete(long id);

    }
}
