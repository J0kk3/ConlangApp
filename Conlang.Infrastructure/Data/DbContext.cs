﻿using Microsoft.EntityFrameworkCore;
using Conlang.Core.Words;
using Conlang.Core.Entities.IPA;
using Conlang.Core.Entities.Users;
using Conlang.Core.Entities;

namespace Conlang.Infrastructure.Data
{
    public class ConlangDbContext : DbContext
    {
        public ConlangDbContext(DbContextOptions<ConlangDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Word> Words { get; private set; }
        public DbSet<IPASymbol> IPASymbols { get; set; }
        public DbSet<VowelSymbol> VowelSymbols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConlangProject>().OwnsOne(p => p.Structure, structure =>
            {
                structure.OwnsOne(s => s.SyllableStructure);
            });

            modelBuilder.Entity<ConlangProject>()
                .HasOne(p => p.Author)
                .WithMany(a => a.ConlangProjects)
                .HasForeignKey(p => p.AuthorId);
            #region Consonants
            modelBuilder.Entity<IPASymbol>().HasData(
                new IPASymbol(1, "m̥", "Voiceless bilabial nasal", "Bilabial", "Nasal", true),
                new IPASymbol(2, "m", "Voiced bilabial nasal", "Bilabial", "Nasal", false),
                new IPASymbol(3, "p", "Voiceless bilabial plosive", "Bilabial", "Plosive", true),
                new IPASymbol(4, "b", "Voiced bilabial plosive", "Bilabial", "Plosive", false),
                new IPASymbol(5, "pɸ", "Voiceless bilabial affricate", "Bilabial", "Non-sibilant Affricate", true),
                new IPASymbol(6, "bβ", "Voiced bilabial affricate", "Bilabial", "Non-sibilant Affricate", false),
                new IPASymbol(7, "ɸ", "Voiceless bilabial fricative", "Bilabial", "Non Siblant Fricative", true),
                new IPASymbol(8, "β", "Voiced bilabial fricative", "Bilabial", "Non Siblant Fricative", false),
                new IPASymbol(9, "β̞", "Voiceless bilabial fricative", "Bilabial", "Approximant", true),
                new IPASymbol(10, "ⱱ̟", "Voiced bilabial flap", "Bilabial", "Tap/flap", false),
                new IPASymbol(11, "ʙ̥", "Voiceless bilabial trill", "Bilabial", "Trill", true),
                new IPASymbol(12, "ʙ", "Voiced bilabial trill", "Bilabial", "Trill", false),
                new IPASymbol(13, "ɱ", "Voiced Labiodental nasal", "Labiodental", "Nasal", false),
                new IPASymbol(14, "p̪", "Voiceless labiodental plosive", "Labiodental", "Plosive", true),
                new IPASymbol(15, "b̪", "Voiced labiodental plosive", "Labiodental", "Plosive", false),
                new IPASymbol(16, "p̪f", "Voiceless labiodental affricate", "Labiodental", "Affricate", true),
                new IPASymbol(17, "b̪v", "Voiced labiodental affricate", "Labiodental", "Affricate", false),
                new IPASymbol(18, "f", "Voiceless labiodental fricative", "Labiodental", "Non Siblant Fricative", true),
                new IPASymbol(19, "v", "Voiced labiodental fricative", "Labiodental", "Non Siblant Fricative", false),
                new IPASymbol(20, "ʋ", "Voiced labiodental approximant", "Labiodental", "Approximant", false),
                new IPASymbol(21, "ⱱ", "Voiced labiodental flap", "Labiodental", "Tap/flap", false),
                new IPASymbol(22, "n̼", "Voiced linguolabial nasal", "Linguolabial", "Nasal", false),
                new IPASymbol(23, "t̼", "Voiceless linguolabial plosive", "Linguolabial", "Plosive", true),
                new IPASymbol(24, "d̼", "Voiced linguolabial plosive", "Linguolabial", "Plosive", false),
                new IPASymbol(25, "θ̼", "Voiceless linguolabial fricative", "Linguolabial", "Non Siblant Fricative", true),
                new IPASymbol(26, "ð̼", "Voiced linguolabial fricative", "Linguolabial", "Non Siblant Fricative", false),
                new IPASymbol(27, "ɾ̼", "Voiced linguolabial plosive", "Linguolabial", "Plosive", true),
                new IPASymbol(28, "t̪", "Voiceless dental plosive", "Dental", "Plosive", true),
                new IPASymbol(29, "d̪", "Voiced dental plosive", "Dental", "Plosive", false),
                new IPASymbol(30, "t̪s̪", "Voiceless dental affricate", "Dental", "Siblant Affricate", true),
                new IPASymbol(31, "d̪z̪", "Voiced dental affricate", "Dental", "Siblant Affricate", false),
                new IPASymbol(32, "t̪θ", "Voiceless dental non-sibilant affricate", "Dental", "Non Siblant Affricate", true),
                new IPASymbol(33, "d̪ð", "Voiced dental non-sibilant affricate", "Dental", "Non Siblant Affricate", false),
                new IPASymbol(34, "θ", "Voiceless dental fricative", "Dental", "Non Siblant Fricative", true),
                new IPASymbol(35, "ð", "Voiced dental fricative", "Dental", "Non Siblant Fricative", false),
                new IPASymbol(36, "ð̞", "Voiced dental approximant", "Dental", "Approximant", false),
                new IPASymbol(37, "l̪", "Voiced dental lateral approximant", "Dental", "Lateral approximant", false),
                new IPASymbol(38, "ɺ̥", "Voiceless alveolar lateral flap", "Dental", "Lateral tap/flap", false),
                new IPASymbol(39, "n̥", "Voiceless alveolar nasal", "Alveolar", "Nasal", true),
                new IPASymbol(40, "n", "Voiced alveolar nasal", "Alveolar", "Nasal", false),
                new IPASymbol(41, "t", "Voiceless alveolar plosive", "Alveolar", "Plosive", true),
                new IPASymbol(42, "d", "Voiced alveolar plosive", "Alveolar", "Plosive", false),
                new IPASymbol(43, "ts", "Voiceless alveolar affricate", "Alveolar", "Siblant Affricate", true),
                new IPASymbol(44, "dz", "Voiced alveolar affricate", "Alveolar", "Siblant Affricate", false),
                new IPASymbol(45, "tɹ̝̊", "Voiceless alveolar non-sibilant affricate", "Alveolar", "Non Siblant Affricate", true),
                new IPASymbol(46, "dɹ̝", "Voiced alveolar non-sibilant affricate", "Alveolar", "Non Siblant Affricate", false),
                new IPASymbol(47, "s", "Voiceless alveolar sibilant fricative", "Alveolar", "Siblant Fricative", true),
                new IPASymbol(48, "z", "Voiced alveolar sibilant fricative", "Alveolar", "Siblant Fricative", false),
                new IPASymbol(49, "θ̠", "Voiceless alveolar non-sibilant fricative", "Alveolar", "Non Siblant Fricative", true),
                new IPASymbol(50, "ð̠", "Voiced alveolar non-sibilant fricative", "Alveolar", "Non Siblant Fricative", false),
                new IPASymbol(51, "ɹ", "Voiced alveolar approximant", "Alveolar", "Approximant", false),
                new IPASymbol(52, "ɾ̥", "Voiceless alveolar flap", "Alveolar", "Tap/flap", true),
                new IPASymbol(53, "ɾ", "Voiced alveolar flap", "Alveolar", "Tap/flap", false),
                new IPASymbol(54, "r̥", "Voiceless alveolar trill", "Alveolar", "Trill", true),
                new IPASymbol(55, "r", "Voiced alveolar trill", "Alveolar", "Trill", false),
                new IPASymbol(56, "tɬ", "Voiceless alveolar lateral affricate", "Alveolar", "Lateral Affricate", true),
                new IPASymbol(57, "dɮ", "Voiced alveolar lateral affricate", "Alveolar", "Lateral Affricate", false),
                new IPASymbol(58, "ɬ", "Voiceless alveolar lateral fricative", "Alveolar", "Lateral Fricative", true),
                new IPASymbol(59, "ɮ", "Voiced alveolar lateral fricative", "Alveolar", "Lateral Fricative", false),
                new IPASymbol(60, "l", "Voiced alveolar lateral approximant", "Alveolar", "Lateral Approximant", false),
                new IPASymbol(61, "ɺ", "Voiced alveolar lateral flap", "Alveolar", "Lateral Tap/flap", false),
                new IPASymbol(62, "t̠ʃ", "Voiceless postalveolar affricate", "Postalveolar", "Siblant Affricate", true),
                new IPASymbol(63, "d̠ʒ", "Voiced postalveolar affricate", "Postalveolar", "Siblant Affricate", false),
                new IPASymbol(64, "t̠ɹ̠̊˔", "Voiceless postalveolar non-sibilant affricate", "Postalveolar", "Non Siblant Affricate", true),
                new IPASymbol(65, "d̠ɹ̠˔", "Voiced postalveolar non-sibilant affricate", "Postalveolar", "Non Siblant Affricate", false),
                new IPASymbol(66, "ʃ", "Voiceless postalveolar sibilant fricative", "Postalveolar", "Siblant Fricative", true),
                new IPASymbol(67, "ʒ", "Voiced postalveolar sibilant fricative", "Postalveolar", "Siblant Fricative", false),
                new IPASymbol(68, "ɹ̠̊˔", "Voiceless postalveolar non-sibilant fricative", "Postalveolar", "Non Siblant Fricative", true),
                new IPASymbol(69, "ɹ̠˔", "Voiced postalveolar non-sibilant fricative", "Postalveolar", "Non Siblant Fricative", false),
                new IPASymbol(70, "ɹ̠", "Voiced postalveolar approximant", "Postalveolar", "Approximant", false),
                new IPASymbol(71, "r̠", "Voiced postalveolar trill", "Postalveolar", "Trill", false),
                new IPASymbol(72, "l̠", "Voiced postalveolar lateral approximant", "Postalveolar", "Lateral Approximant", false),
                new IPASymbol(73, "ɳ̊", "Voiceless retroflex nasal", "Retroflex", "Nasal", true),
                new IPASymbol(74, "ɳ", "Voiced retroflex nasal", "Retroflex", "Nasal", false),
                new IPASymbol(75, "ʈ", "Voiceless retroflex plosive", "Retroflex", "Plosive", true),
                new IPASymbol(76, "ɖ", "Voiced retroflex plosive", "Retroflex", "Plosive", false),
                new IPASymbol(77, "tʂ", "Voiceless retroflex affricate", "Retroflex", "Siblant Affricate", true),
                new IPASymbol(78, "dʐ", "Voiced retroflex affricate", "Retroflex", "Siblant Affricate", false),
                new IPASymbol(79, "ʂ", "Voiceless retroflex sibilant fricative", "Retroflex", "Siblant Fricative", true),
                new IPASymbol(80, "ʐ", "Voiced retroflex sibilant fricative", "Retroflex", "Siblant Fricative", false),
                new IPASymbol(81, "ɻ̊˔", "Voiceless retroflex non-sibilant fricative", "Retroflex", "Non Siblant Fricative", true),
                new IPASymbol(82, "ɻ˔", "Voiced retroflex non-sibilant fricative", "Retroflex", "Non Siblant Fricative", false),
                new IPASymbol(83, "ɻ", "Voiced retroflex approximant", "Retroflex", "Approximant", false),
                new IPASymbol(84, "ɽ̊", "Voiceless retroflex flap", "Retroflex", "Tap/flap", true),
                new IPASymbol(85, "ɽ", "Voiced retroflex flap", "Retroflex", "Tap/flap", false),
                new IPASymbol(86, "ɽ̊r̥", "Voiceless retroflex trill", "Retroflex", "Trill", true),
                new IPASymbol(87, "ɽr", "Voiced retroflex trill", "Retroflex", "Trill", false),
                new IPASymbol(88, "tꞎ", "Voiceless retroflex lateral affricate", "Retroflex", "Lateral Affricate", true),
                new IPASymbol(89, "ɖ͡ɭ", "Voiced retroflex lateral affricate", "Retroflex", "Lateral Affricate", false),
                new IPASymbol(90, "ꞎ", "Voiceless retroflex lateral fricative", "Retroflex", "Lateral Fricative", true),
                new IPASymbol(91, "ɭ̞̝", "Voiced retroflex lateral fricative", "Retroflex", "Lateral Fricative", false),
                new IPASymbol(92, "ɭ", "Voiced retroflex lateral approximant", "Retroflex", "Lateral Approximant", false),
                new IPASymbol(93, "ɭ̼̊", "Voiceless retroflex lateral flap", "Retroflex", "Lateral Tap/flap", true),
                new IPASymbol(94, "ɭ̺", "Voiced retroflex lateral flap", "Retroflex", "Lateral Tap/flap", false),
                new IPASymbol(95, "ɲ̊", "Voiceless palatal nasal", "Palatal", "Nasal", true),
                new IPASymbol(96, "ɲ", "Voiced palatal nasal", "Palatal", "Nasal", false),
                new IPASymbol(97, "c", "Voiceless palatal plosive", "Palatal", "Plosive", true),
                new IPASymbol(98, "ɟ", "Voiced palatal plosive", "Palatal", "Plosive", false),
                new IPASymbol(99, "tɕ", "Voiceless palatal affricate", "Palatal", "Siblant Affricate", true),
                new IPASymbol(100, "dʑ", "Voiced palatal affricate", "Palatal", "Siblant Affricate", false),
                new IPASymbol(101, "cç", "Voiceless palatal non-sibilant affricate", "Palatal", "Non Siblant Affricate", true),
                new IPASymbol(102, "ɟʝ", "Voiced palatal non-sibilant affricate", "Palatal", "Non Siblant Affricate", false),
                new IPASymbol(103, "ɕ", "Voiceless palatal sibilant fricative", "Palatal", "Siblant Fricative", true),
                new IPASymbol(104, "ʑ", "Voiced palatal sibilant fricative", "Palatal", "Siblant Fricative", false),
                new IPASymbol(105, "ç", "Voiceless palatal non-sibilant fricative", "Palatal", "Non Siblant Fricative", true),
                new IPASymbol(106, "ʝ", "Voiced palatal non-sibilant fricative", "Palatal", "Non Siblant Fricative", false),
                new IPASymbol(107, "j", "Voiced palatal approximant", "Palatal", "Approximant", false),
                new IPASymbol(108, "cʎ̥", "Voiceless palatal lateral affricate", "Palatal", "Lateral Affricate", true),
                new IPASymbol(109, "ɟʎ̝", "Voiced palatal lateral affricate", "Palatal", "Lateral Affricate", false),
                new IPASymbol(110, "ʎ̥̞", "Voiceless palatal lateral fricative", "Palatal", "Lateral Fricative", true),
                new IPASymbol(111, "ʎ̝", "Voiced palatal lateral fricative", "Palatal", "Lateral Fricative", false),
                new IPASymbol(112, "ʎ", "Voiced palatal lateral approximant", "Palatal", "Lateral Approximant", false),
                new IPASymbol(113, "ʎ̆", "Voiced palatal lateral flap", "Palatal", "Lateral Tap/flap", false),
                new IPASymbol(114, "ŋ̊", "Voiceless velar nasal", "Velar", "Nasal", true),
                new IPASymbol(115, "ŋ", "Voiced velar nasal", "Velar", "Nasal", false),
                new IPASymbol(116, "k", "Voiceless velar plosive", "Velar", "Plosive", true),
                new IPASymbol(117, "g", "Voiced velar plosive", "Velar", "Plosive", false),
                new IPASymbol(118, "kx", "Voiceless velar affricate", "Velar", "Non Siblant Affricate", true),
                new IPASymbol(119, "ɡɣ", "Voiced velar affricate", "Velar", "Non Siblant Affricate", false),
                new IPASymbol(120, "x", "Voiceless velar fricative", "Velar", "Non Siblant Fricative", true),
                new IPASymbol(121, "ɣ", "Voiced velar fricative", "Velar", "Non Siblant Fricative", false),
                new IPASymbol(122, "ɰ", "Voiced velar approximant", "Velar", "Approximant", false),
                new IPASymbol(123, "k𝼄", "Voiceless velar lateral affricate", "Velar", "Lateral Affricate", true),
                new IPASymbol(124, "ɡʟ̝", "Voiced velar lateral affricate", "Velar", "Lateral Affricate", false),
                new IPASymbol(125, "𝼄", "Voiceless velar lateral fricative", "Velar", "Lateral Fricative", true),
                new IPASymbol(126, "ʟ̝", "Voiced velar lateral fricative", "Velar", "Lateral Fricative", false),
                new IPASymbol(127, "ʟ", "Voiced velar lateral approximant", "Velar", "Lateral Approximant", false),
                new IPASymbol(128, "ʟ̆", "Voiced velar lateral flap", "Velar", "Lateral Tap/flap", false),
                new IPASymbol(129, "ɴ", "Voiced uvular nasal", "Uvular", "Nasal", false),
                new IPASymbol(130, "q", "Voiceless uvular plosive", "Uvular", "Plosive", true),
                new IPASymbol(131, "ɢ", "Voiced uvular plosive", "Uvular", "Plosive", false),
                new IPASymbol(132, "qχ", "Voiceless uvular affricate", "Uvular", "Non Siblant Affricate", true),
                new IPASymbol(133, "ɢʁ", "Voiced uvular affricate", "Uvular", "Non Siblant Affricate", false),
                new IPASymbol(134, "χ", "Voiceless uvular fricative", "Uvular", "Non Siblant Fricative", true),
                new IPASymbol(135, "ʁ", "Voiced uvular fricative", "Uvular", "Non Siblant Fricative", false),
                new IPASymbol(136, "ʁ̞", "Voiced uvular approximant", "Uvular", "Approximant", false),
                new IPASymbol(137, "ɢ̆", "Voiced uvular lateral flap", "Uvular", "Tap/flap", false),
                new IPASymbol(138, "ʀ̥", "Voiceless uvular trill", "Uvular", "Trill", true),
                new IPASymbol(139, "ʀ", "Voiced uvular trill", "Uvular", "Trill", false),
                new IPASymbol(140, "ʟ̠", "Voiced uvular lateral approximant", "Uvular", "Lateral Approximant", false),
                new IPASymbol(141, "ʡ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Plosive", true),
                new IPASymbol(142, "ʡʜ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Non Siblant Affricate", true),
                new IPASymbol(143, "ʡʢ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Non Siblant Affricate", true),
                new IPASymbol(144, "ħ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Non Siblant Fricative", true),
                new IPASymbol(145, "ʕ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Non Siblant Fricative", false),
                new IPASymbol(146, "ʡ̆", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Tap/flap", true),
                new IPASymbol(147, "ʜ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Trill", true),
                new IPASymbol(148, "ʢ", "Pharyngeal/Epiglottal", "Pharyngeal/Epiglottal", "Trill", true),
                new IPASymbol(149, "ʔ", "Glottal Stop", "Glottal", "Plosive", true),
                new IPASymbol(150, "ʔh", "Glottal Stop", "Glottal", "Non Siblant Affricate", true),
                new IPASymbol(151, "h", "Glottal Stop", "Glottal", "Non Siblant Fricative", true),
                new IPASymbol(152, "ɦ", "Glottal Stop", "Glottal", "Non Siblant Fricative", false),
                new IPASymbol(153, "ʔ̞", "Glottal Stop", "Glottal", "Approximant", true)
            );
            #endregion Consonants
            #region Vowels
            modelBuilder.Entity<VowelSymbol>().HasData(
                // Close Vowels
                new VowelSymbol(id: 154, symbol: "i", description: "Close front unrounded vowel", height: "Close", position: "Front", rounded: false),
                new VowelSymbol(id: 155, symbol: "y", description: "Close front rounded vowel", height: "Close", position: "Front", rounded: true),
                new VowelSymbol(id: 156, symbol: "ɨ", description: "Close central unrounded vowel", height: "Close", position: "Central", rounded: false),
                new VowelSymbol(id: 157, symbol: "ʉ", description: "Close central rounded vowel", height: "Close", position: "Central", rounded: true),
                new VowelSymbol(id: 158, symbol: "ɯ", description: "Close back unrounded vowel", height: "Close", position: "Back", rounded: false),
                new VowelSymbol(id: 159, symbol: "u", description: "Close back rounded vowel", height: "Close", position: "Back", rounded: true),
                // Near-close Vowels
                new VowelSymbol(id: 160, symbol: "ɪ", description: "Near-close near-front unrounded vowel", height: "Near-close", position: "Near-front", rounded: false),
                new VowelSymbol(id: 161, symbol: "ʏ", description: "Near-close near-front rounded vowel", height: "Near-close", position: "Near-front", rounded: true),
                new VowelSymbol(id: 162, symbol: "ʊ", description: "Near-close near-back rounded vowel", height: "Near-close", position: "Near-back", rounded: true),
                // Close-mid Vowels
                new VowelSymbol(id: 163, symbol: "e", description: "Close-mid front unrounded vowel", height: "Close-mid", position: "Front", rounded: false),
                new VowelSymbol(id: 164, symbol: "ø", description: "Close-mid front rounded vowel", height: "Close-mid", position: "Front", rounded: true),
                new VowelSymbol(id: 165, symbol: "ɘ", description: "Close-mid central unrounded vowel", height: "Close-mid", position: "Central", rounded: false),
                new VowelSymbol(id: 166, symbol: "ɵ", description: "Close-mid central rounded vowel", height: "Close-mid", position: "Central", rounded: true),
                new VowelSymbol(id: 167, symbol: "ɤ", description: "Close-mid back unrounded vowel", height: "Close-mid", position: "Back", rounded: false),
                new VowelSymbol(id: 168, symbol: "o", description: "Close-mid back rounded vowel", height: "Close-mid", position: "Back", rounded: true),
                // Mid Vowels
                new VowelSymbol(id: 169, symbol: "e̞", description: "Mid front unrounded vowel", height: "Mid", position: "Front", rounded: false),
                new VowelSymbol(id: 170, symbol: "ø̞", description: "Mid front rounded vowel", height: "Mid", position: "Front", rounded: true),
                new VowelSymbol(id: 171, symbol: "ə", description: "Mid central vowel", height: "Mid", position: "Central", rounded: false),
                new VowelSymbol(id: 172, symbol: "ɤ̞", description: "Mid back unrounded vowel", height: "Mid", position: "Back", rounded: false),
                new VowelSymbol(id: 173, symbol: "o̞", description: "Mid back rounded vowel", height: "Mid", position: "Back", rounded: true),
                // Open-mid Vowels
                new VowelSymbol(id: 174, symbol: "ɛ", description: "Open-mid front unrounded vowel", height: "Open-mid", position: "Front", rounded: false),
                new VowelSymbol(id: 175, symbol: "œ", description: "Open-mid front rounded vowel", height: "Open-mid", position: "Front", rounded: true),
                new VowelSymbol(id: 176, symbol: "ɜ", description: "Open-mid central unrounded vowel", height: "Open-mid", position: "Central", rounded: false),
                new VowelSymbol(id: 177, symbol: "ɞ", description: "Open-mid central rounded vowel", height: "Open-mid", position: "Central", rounded: true),
                new VowelSymbol(id: 178, symbol: "ʌ", description: "Open-mid back unrounded vowel", height: "Open-mid", position: "Back", rounded: false),
                new VowelSymbol(id: 179, symbol: "ɔ", description: "Open-mid back rounded vowel", height: "Open-mid", position: "Back", rounded: true),
                // Near-open Vowels
                new VowelSymbol(id: 180, symbol: "æ", description: "Near-open front unrounded vowel", height: "Near-open", position: "Front", rounded: false),
                new VowelSymbol(id: 181, symbol: "ɐ", description: "Near-open central vowel", height: "Near-open", position: "Central", rounded: false),
                // Open Vowels
                new VowelSymbol(id: 182, symbol: "a", description: "Open front unrounded vowel", height: "Open", position: "Front", rounded: false),
                new VowelSymbol(id: 183, symbol: "ɶ", description: "Open front rounded vowel", height: "Open", position: "Front", rounded: true),
                new VowelSymbol(id: 184, symbol: "ä", description: "Open central unrounded vowel", height: "Open", position: "Central", rounded: false),
                new VowelSymbol(id: 185, symbol: "ɑ", description: "Open back unrounded vowel", height: "Open", position: "Back", rounded: false),
                new VowelSymbol(id: 186, symbol: "ɒ", description: "Open back rounded vowel", height: "Open", position: "Back", rounded: true)
            );
            #endregion Vowels

            base.OnModelCreating(modelBuilder);
        }
    }
}