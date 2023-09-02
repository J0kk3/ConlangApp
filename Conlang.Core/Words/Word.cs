using Conlang.Core.Entities.Syllables;
using Conlang.Core.Enums;

namespace Conlang.Core.Words
{
    public class Word
    {
        public int Id { get; private set; }
        public required string IPARepresentation { get; set; }
        public required string Latinization { get; set; }
        public string EnglishTranslation { get; set; }
        public List<Syllable> Syllables { get; set; } = new List<Syllable>();

        // Description and notes fields allow users to add any context or specifics they want for a word.
        public string Description { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// Enum with Noun, Verb, Adjective, etc.
        /// </summary>
        public List<WordType> Types { get; set; } = new List<WordType>();

        // This can be useful if words have different usages based on formality or context.
        public WordRegister Register { get; set; }

        /// <summary>
        /// Returns the Latinized representation of the word if available,
        /// otherwise returns the IPA representation.
        /// </summary>
        /// <returns>The best representation of the word for display purposes.</returns>
        public string DisplayWord()
        {
            return string.IsNullOrEmpty(Latinization) ? IPARepresentation : Latinization;
        }

        public virtual string ApplyPattern(MorphologicalType type)
        {
            // Base logic for applying pattern (can be empty or provide a default behavior)
            return "";
        }

        public virtual string IrregularForm()
        {
            // Base logic for getting irregular form (can be empty or provide a default behavior)
            return "";
        }
    }
}