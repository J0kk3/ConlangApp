namespace Conlang.Core.Entities.Syllables
{
    public class Onset
    {
        public int Id { get; set; }
        public List<string> AllowedInitialOnset { get; set; }
        public List<string> AllowedInternalOnset { get; set; }
        public List<string> AllowedFinalOnset { get; set; }
    }
}