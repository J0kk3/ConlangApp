using Conlang.Core.Entities.Users;

namespace Conlang.Infrastructure.Repositories
{
    public interface IAuthorRepository
    {
        Author GetAuthorByName(string name);
        IEnumerable<Author> GetAllAuthors();
        void AddAuthor(Author author);
        void RemoveAuthor(Author author);
        void SaveChanges();
    }
}