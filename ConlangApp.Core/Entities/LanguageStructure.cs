using Conlang.Core.Enums;

namespace Conlang.Core.Entities
{
    public class LanguageStructure
    {
        public required SyllableStructure SyllableStructure { get; set; }
        public SentenceOrder WordOrder { get; set; }
        public AdpositionPlacement AdpositionOrder { get; set; }
        public DemonstrativePlacement DemonstrativeOrder { get; set; }
        public NumberPlacement NumberOrder { get; set; }
        public PossessivePlacement PossessiveOrder { get; set; }
        public AdjectivePlacement AdjectiveOrder { get; set; }
        public GenitivePlacement GenitiveOrder { get; set; }
        public RelativeClausePlacement RelativeClauseOrder { get; set; }
        public AuxiliaryPlacement AuxiliaryOrder { get; set; }
        public CopulaPlacement CopulaOrder { get; set; }
        public required List<VerbPhrase> VerbElementOrder { get; set; }
        public bool IsHeadInitial { get; set; }
        public bool Topicalization { get; set; }
    }
}