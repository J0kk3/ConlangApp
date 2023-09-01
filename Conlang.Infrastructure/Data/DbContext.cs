using Microsoft.EntityFrameworkCore;
using Conlang.Core.Words;

namespace Conlang.Infrastructure.Data
{
    public class ConlangDbContext : DbContext
    {
        public ConlangDbContext(DbContextOptions<ConlangDbContext> options) : base(options) { }

        public DbSet<Word> Words { get; private set; }
        // Add other DbSets for your entities...
    }
}