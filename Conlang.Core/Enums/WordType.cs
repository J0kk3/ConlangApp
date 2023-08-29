using System.ComponentModel;

namespace Conlang.Core.Enums
{
    public enum WordType
    {
        Noun,
        Verb,
        Adjective,
        Adverb,
        Pronoun,
        Particle,
        Conjunction,
        Number,
        Auxiliary,
        Copula,
        MassNoun,
        Aspect,
        Demonstrative,
        DerivativeMorpheme
    }

    /// <summary>
    /// Specifies the social or situational context in which a word is typically used, 
    /// indicating its level of formality or informality.
    /// </summary>
    public enum WordRegister
    {
        [Description("Used in formal contexts.")]
        Formal,
        [Description("Used in casual or familiar contexts.")]
        Informal,
        [Description("Neutral usage, not specifically formal or informal.")]
        Neutral,
    }
}