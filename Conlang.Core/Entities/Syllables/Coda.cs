namespace Conlang.Core.Entities.Syllables
{
    public class Coda
    {
        public List<string>? AllowedInitialCoda { get; set; }
        public List<string>? AllowedInternalCoda { get; set; }
        public List<string>? AllowedFinalCoda { get; set; }
        public List<string>? AllowedConsonantClusters { get; set; }
    }
}