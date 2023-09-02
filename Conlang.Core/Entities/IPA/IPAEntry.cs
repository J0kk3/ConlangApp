namespace Conlang.Core.Entities.IPA
{
    public class IPAEntry
    {
        public string Symbol { get; set; }
        public string PlaceOfArticulation { get; set; }
        public string MannerOfArticulation { get; set; }
        public bool IsVoiced { get; set; }
        public string Description { get; set; }
    }
}