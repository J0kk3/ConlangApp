namespace Conlang.Core.Entities.Syllables
{
    public class Syllable
    {
        public Onset OnsetComponent { get; set; } = new Onset();
        public Nucleus NucleusComponent { get; set; } = new Nucleus();
        public Coda CodaComponent { get; set; } = new Coda();
    }
}