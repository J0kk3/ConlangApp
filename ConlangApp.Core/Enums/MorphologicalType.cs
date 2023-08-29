namespace Conlang.Core.Enums
{
    /// <summary>
    /// A morphological type is a grammatical category that expresses the role of a word in a phrase, clause, or sentence.
    /// </summary>
    public enum MorphologicalType
    {
        // Tenses
        PresentTense,
        PastTense,
        FutureTense,
        PresentPerfectTense,
        PastPerfectTense,
        FuturePerfectTense,
        ConditionalTense,
        PastConditionalTense,

        // Numbers
        Singular,
        Plural,
        Dual,

        // Cases (used in some languages like Latin, Russian, Finnish, etc.)
        Nominative,
        Accusative,
        Genitive,
        Dative,
        Ablative,
        Locative,
        Instrumental,
        Vocative,

        // Moods
        Indicative,
        Subjunctive,
        Imperative,
        ConditionalMood,
        PotentialMood,
        InterrogativeMood,
        Infinitive,

        // Degrees of comparison
        Comparative,
        Superlative,
        PositiveDegree, // Base form, sometimes it's needed as a separate classification

        // Voices
        ActiveVoice,
        PassiveVoice,
        MiddleVoice, // Used in some ancient languages like Greek

        // Aspects
        PerfectiveAspect,
        ImperfectiveAspect,
        ProgressiveAspect,

        // Gender
        Masculine,
        Feminine,
        Neuter,
        CommonGender, // Some languages don't differentiate between masculine and feminine

        // Politeness/Formality
        Formal,
        Informal,

        // Other
        Negation,
        Question,
        Reflexive,
    }
}