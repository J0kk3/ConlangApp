using Conlang.Core.Enums;

namespace Conlang.Core.Entities.Conjugation
{
    public class ConjugationRule
    {
        public MorphologicalType Type { get; set; }
        public string Prefix { get; set; } = "";
        public string Suffix { get; set; } = "";
        public string StemChange { get; set; } = "";
        public string IrregularForm { get; set; } = "";
        public string Infix { get; set; } = "";

        // List of transformation steps in the order they should be applied.
        public List<Func<string, string>> TransformationSteps { get; private set; } = new List<Func<string, string>>();

        public ConjugationRule()
        {
            // Default order: Prefix -> Infix -> StemChange -> Suffix
            TransformationSteps.Add(ApplyPrefix);
            //TransformationSteps.Add(ApplyInfix);
            TransformationSteps.Add(ApplyStemChange);
            TransformationSteps.Add(ApplySuffix);
        }

        public string Apply(string baseForm)
        {
            if (!string.IsNullOrEmpty(IrregularForm))
            {
                return IrregularForm;  // If there's an irregular form, it takes precedence
            }

            foreach (var step in TransformationSteps)
            {
                baseForm = step(baseForm);
            }

            return baseForm;
        }

        string ApplyPrefix(string word) => Prefix + word;

        string ApplySuffix(string word) => word + Suffix;

        string ApplyStemChange(string word) => string.IsNullOrEmpty(StemChange) ? word : StemChange;

        //string ApplyInfix(string word)
        //{
        //    if (!string.IsNullOrEmpty(Infix))
        //    {
        //        int positionToInsert = FindInfixPosition(word);
        //        if (positionToInsert != -1)
        //        {
        //            word = word.Insert(positionToInsert, Infix);
        //        }
        //    }
        //    return word;
        //}

        //int FindInfixPosition(string word)
        //{
        //    // This is a sample method to find infix position after the first vowel. 
        //    // Adjust this method based on specific conlang rules or infix type.
        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        if (IsVowel(word[i]))
        //        {
        //            return i + 1;  // +1 to insert the infix after the vowel.
        //        }
        //    }
        //    return -1;  // Return -1 if no appropriate position found.
        //}

        //TODO: get the users' vowels from the database

        //bool IsVowel(char c)
        //{
        //    char[] vowels = null;  // Basic set, can be expanded for your needs.
        //    return vowels.Contains(char.ToLower(c));
        //}
    }
}