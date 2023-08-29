namespace Conlang.Core.Entities
{
    public class ConlangProject
    {
        public Guid Id { get; private set; } //CTOR
        public required string ConlangName { get; set; }
        public string? ConlangParent { get; set; }
        public required string ConlangAuthor { get;  set; } //CTOR private set?
        public DateTime DateCreated { get; private set; } //CTOR
        public required LanguageStructure Structure { get; set; }
        public List<Words.Word>? Vocabulary { get; set; }
        /*If i plan on expanding this, consider breaking it up into its own class
         * like last modified, associated tags, etc.
         */
    }
}