using Conlang.Core.Entities.Users;

namespace Conlang.Core.Entities
{
    public class ConlangProject
    {
        public Guid Id { get; private set; }
        public required string ConlangName { get; set; }
        public string ConlangParent { get; set; }
        public string ConlangAuthor { get; private set; }
        public DateTime DateCreated { get; private set; }
        public LanguageStructure Structure { get; set; }
        public List<Words.Word> Vocabulary { get; set; }
        // FK property
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        /*If i plan on expanding this, consider breaking it up into its own class
         * like last modified, associated tags, etc.
         */

        public ConlangProject() { }

        public ConlangProject(string conlangAuthor, LanguageStructure structure, string conlangName = "New Conlang")
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;

            ConlangName = conlangName;
            ConlangAuthor = conlangAuthor;
            Structure = structure;
        }
    }
}