using AulaEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AulaEntityFramework.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MyDbContext _dbContext;

        public PessoaRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public Pessoa? Delete(long id)
        {
            var pessoa = Get(id);

            if (pessoa is null)
                return null;

            _dbContext.Pessoas.Remove(pessoa);
            _dbContext.SaveChanges();

            return pessoa;
        }

        public Pessoa? Get(long id)
        {
            var pessoa = _dbContext
                    .Pessoas
                    .Include(e => e.Enderecos)
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return pessoa;
        }

        public List<Pessoa> GetAll()
        {
            return _dbContext
                .Pessoas
                .Include(e => e.Enderecos)
                .ToList();
        }

        public List<Pessoa> GetByBirthDate(DateTime date)
        {
            return _dbContext
                .Pessoas
                .Include(e => e.Enderecos)
                .Where(p => p.BirthDate == date)
                .ToList();
        }

        public List<Pessoa> GetByBirthMonth(int month)
        {
            return _dbContext
            .Pessoas
                .Include(e => e.Enderecos)
                .Where(p => p.BirthDate.Month == month)
                .ToList();
        }

        public List<Pessoa> GetByBirthYear(int year)
        {
            return _dbContext
                .Pessoas
                .Include(e => e.Enderecos)
                .Where(p => p.BirthDate.Year == year)
                .ToList();
        }

        public List<Pessoa> GetByName(string? name)
        {
            return _dbContext
                .Pessoas
                .Include(e => e.Enderecos)
                .Where(p => p.Name!.Equals(name))
                .ToList();
        }

        public List<Pessoa>? GetByPeriodBirthDate(DateTime startDate, DateTime endDate)
        {
            return _dbContext
            .Pessoas
                .Include(e => e.Enderecos)
                .Where(p => p.BirthDate == startDate && p.BirthDate <= endDate)
                .ToList();
        }

        public Pessoa Insert(Pessoa person)
        {
            _dbContext.Pessoas.Add(person);
            _dbContext.SaveChanges();

            return person;
        }

        public Pessoa Update(Pessoa person)
        {
            _dbContext.Pessoas.Update(person);
            _dbContext.SaveChanges();

            return person;
        }
    }
}
