using System.ComponentModel;

namespace Conlang.Core.Enums
{
    public enum SentenceOrder
    {
        SOV,
        SVO,
        VSO,
        VOS,
        OVS,
        OSV
    }

    [Description("NAdposition,  or AdpositionN")]
    public enum AdpositionPlacement
    {
        NounBeforeAdposition,
        AdpositionBeforeNoun
    }

    [Description("NDemonstrative, or DemonstrativeN")]
    public enum DemonstrativePlacement
    {
        NounBeforeDemon,
        DemonBeforeNoun
    }

    [Description("NNumber, or NumberN")]
    public enum NumberPlacement
    {
        NounBeforeNum,
        NumBeforeNoun
    }

    [Description("NPossessive, or PossessiveN")]
    public enum PossessivePlacement
    {
        NounBeforePoss,
        PossBeforeNoun
    }

    [Description("NAdjective, or AdjectiveN")]
    public enum AdjectivePlacement
    {
        NounBeforeAdj,
        AdjBeforeNoun
    }

    [Description("NGenitive, or GenitiveN")]
    public enum GenitivePlacement
    {
        NounBeforeGen,
        GenBeforeNoun
    }

    [Description("NRelativeClause, or RelativeClauseN")]
    public enum RelativeClausePlacement
    {
        NounBeforeRel,
        RelBeforeNoun
    }

    [Description("VAux, or AuxV")]
    public enum AuxiliaryPlacement
    {
        MainVerbBeforeAux,
        AuxBeforeMainVerb,
    }

    [Description("VCopula, or CopulaV")]
    public enum CopulaPlacement
    {
        SubjectBeforeCopula,
        CopulaBeforeSubject
    }

    [Description("Order of the elements in a Verb phrase")]
    public enum VerbPhrase
    {
        Auxiliary,
        Copula,
        MainVerb,
        [Description("Describes the flow of the action (completed, ongoing, habitual)")]
        Aspect,
        Tense,
        [Description("Describes the subject's attitude toward the action (willing, forced, etc.)")]
        Mood,
        [Description("Describes the subject's volition in performing the action (intentional, accidental, etc.)")]
        Modal,
        Negation
    }
}