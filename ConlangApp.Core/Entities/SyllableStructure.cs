namespace Conlang.Core.Entities
{
    public class SyllableStructure
    {
        public List<string>? Vowels { get; set; }
        public List<string>? Diphthongs { get; set; }
        public List<string>? AllowedSyllables { get; set; }
        public List<string>? AllowedInitialOnset { get; set; }
        public List<string>? AllowedInternalOnset { get; set; }
        public List<string>? AllowedFinalOnset { get; set; }
        public List<string>? AllowedInitialCoda { get; set; }
        public List<string>? AllowedInternalCoda { get; set; }
        public List<string>? AllowedFinalCoda { get; set; }
        public List<string>? AllowedConsonantClusters { get; set; }
    }

    public class StressRule
    {
        // the desired syllable to stress, null if not set
        public int? PrimaryStressSyllable { get; set; }
        // fallback strategy if the desired syllable isn't present
        public List<int?> StressFallbackSyllables { get; set; } = new List<int?>();
    }
}