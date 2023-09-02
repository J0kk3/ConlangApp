namespace Conlang.Core.Entities.Syllables
{
    public class Coda
    {
        public int Id { get; set; }
        public List<string> AllowedInitialCoda { get; set; }
        public List<string> AllowedInternalCoda { get; set; }
        public List<string> AllowedFinalCoda { get; set; }
        public List<string> AllowedConsonantClusters { get; set; }
    }
}