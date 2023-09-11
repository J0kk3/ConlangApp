using Conlang.Core.Entities.Users;
using Conlang.Infrastructure.Data;

namespace Conlang.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ConlangDbContext _dbContext;

        public AuthorRepository(ConlangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Author GetAuthorByName(string name)
        {
            return _dbContext.Authors.FirstOrDefault(a => a.Name == name);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _dbContext.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            SaveChanges();
        }

        public void RemoveAuthor(Author author)
        {
            _dbContext.Authors.Remove(author);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}