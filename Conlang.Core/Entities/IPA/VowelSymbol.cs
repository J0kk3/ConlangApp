namespace Conlang.Core.Entities.IPA
{
    public class VowelSymbol
    {
        public int Id { get; private set; }
        public string Symbol { get; set; }
        public string Description { get; set; }  // Description or name of the sound
        public string Height { get; set; }  // e.g. "Close", "Near-close", "Open", etc.
        public string Position { get; set; }  // e.g. "Front", "Central", "Back"
        public bool? Rounded { get; set; }  // True if rounded, False if unrounded

        public VowelSymbol(int id, string symbol, string description, string height, string position, bool? rounded)
        {
            Id = id;
            Symbol = symbol;
            Description = description;
            Height = height;
            Position = position;
            Rounded = rounded;
        }
    }
}