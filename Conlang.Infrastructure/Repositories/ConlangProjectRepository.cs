using Conlang.Core.Entities;
using Conlang.Infrastructure.Data;

namespace Conlang.Infrastructure.Repositories
{
    public class ConlangProjectRepository : IConlangProjectRepository
    {
        readonly ConlangDbContext _dbCtx;

        public ConlangProjectRepository(ConlangDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IEnumerable<ConlangProject> GetConlangProjectsByAuthorId(int authorId)
        {
            return _dbCtx.ConlangProjects.Where(p => p.AuthorId == authorId).ToList();
        }

        public void AddConlangProject(ConlangProject project)
        {
            _dbCtx.ConlangProjects.Add(project);
            SaveChanges();
        }

        public void RemoveConlangProject(ConlangProject project)
        {
            _dbCtx.ConlangProjects.Remove(project);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbCtx.SaveChanges();
        }
    }
}