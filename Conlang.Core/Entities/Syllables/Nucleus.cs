namespace Conlang.Core.Entities.Syllables
{
    public class Nucleus
    {
        public int Id { get; set; }
        public List<string> Vowels { get; set; }
        public List<string> Diphthongs { get; set; }
        public List<string> AllowedSyllables { get; set; }
    }
}