using Conlang.Core.Entities.Conjugation;
using Conlang.Core.Enums;

namespace Conlang.Core.Words
{
    internal class Verb : Word
    {
        //Specifies if the verb requires a direct object
        public bool IsTransitive { get; set; }
        public bool IsRegular { get; set; } = true;
        public ConjugationTable? ConjugationTable { get; set; }
        public MorphologicalType DefaultMood { get; set; }
        public MorphologicalType DefaultAspect { get; set; }
        public MorphologicalType DefaultVoice { get; set; }
        public MorphologicalType DefaultTense { get; set; }

        /// <summary>
        /// The root or stem of a word is its core part to which various affixes (prefixes, suffixes, infixes, etc.) can be added to form different tenses, moods, voices, etc.
        /// </summary>
        public string? RootOrStem { get; set; }

        /// <summary>
        /// A reflexive verb is a verb where the subject and object are the same. Like myself, herself, etc.
        /// </summary>
        public bool IsReflexive { get; set; }

        /// <summary>
        ///  Phrasal verbs are combinations of a verb and a particle (which can be a preposition or an adverb) 
        ///  that together have a meaning different from the individual meanings of the words. For example, "give up", "run out of", "take off", etc.
        /// </summary>
        public string? PhrasalVerbParticle { get; set; }

        public List<ConjugationRule> ConjugationRules { get; set; } = new List<ConjugationRule>();

        public Verb()
        {
            this.Types.Add(WordType.Verb);
        }

        public override string ApplyPattern(MorphologicalType type)
        {
            //Verb-specific logic for applying pattern
            switch (type)
            {
                case MorphologicalType.PastTense:
                    return "";
                case MorphologicalType.PresentTense:
                    return "";
                case MorphologicalType.FutureTense:
                    return "";
                case MorphologicalType.Imperative:
                    return "";
                case MorphologicalType.PresentPerfectTense:
                    return "";
                case MorphologicalType.PastPerfectTense:
                    return "";
                case MorphologicalType.FuturePerfectTense:
                    return "";
                case MorphologicalType.ConditionalTense:
                    return "";
                case MorphologicalType.PastConditionalTense:
                    return "";
            }
            return base.ApplyPattern(type);
        }

        public override string IrregularForm()
        {
            //Verb-specific logic for getting irregular form
            return base.IrregularForm();
        }
    }
}