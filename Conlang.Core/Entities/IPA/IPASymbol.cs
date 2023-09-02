namespace Conlang.Core.Entities.IPA
{
    public class IPASymbol
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }  // Description or name of the sound
        public string PlaceOfArticulation { get; set; } // e.g. "Bilabial", "Dental", etc.
        public string MannerOfArticulation { get; set; } // e.g. "Plosive", "Nasal", etc.
        public bool IsVoiceless { get; set; }  // True if voiceless, False if voiced

        public IPASymbol(int id, string symbol, string description, string placeOfArticulation, string mannerOfArticulation, bool isVoiceless)
        {
            Id = id;
            Symbol = symbol;
            Description = description;
            PlaceOfArticulation = placeOfArticulation;
            MannerOfArticulation = mannerOfArticulation;
            IsVoiceless = isVoiceless;
        }
    }
}