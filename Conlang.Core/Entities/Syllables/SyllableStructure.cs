namespace Conlang.Core.Entities.Syllables
{
    public class SyllableStructure
    {
        public Nucleus Nucleus { get; set; } = new Nucleus();
        public Onset Onset { get; set; } = new Onset();
        public Coda Coda { get; set; } = new Coda();
    }

    public class StressRule
    {
        // the desired syllable to stress, null if not set
        public int? PrimaryStressSyllable { get; set; }
        // fallback strategy if the desired syllable isn't present
        public List<int?> StressFallbackSyllables { get; set; } = new List<int?>();
    }
}