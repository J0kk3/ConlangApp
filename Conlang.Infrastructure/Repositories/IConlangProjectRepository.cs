using Conlang.Core.Entities;

namespace Conlang.Infrastructure.Repositories
{
    public interface IConlangProjectRepository
    {
        IEnumerable<ConlangProject> GetConlangProjectsByAuthorId(int authorId);
        void AddConlangProject(ConlangProject project);
        void RemoveConlangProject(ConlangProject project);
        void SaveChanges();
    }
}