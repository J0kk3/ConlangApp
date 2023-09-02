using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Conlang.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllowedInitialCoda = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedInternalCoda = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedFinalCoda = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedConsonantClusters = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPASymbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PlaceOfArticulation = table.Column<string>(type: "text", nullable: true),
                    MannerOfArticulation = table.Column<string>(type: "text", nullable: true),
                    IsVoiceless = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPASymbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nucleus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vowels = table.Column<List<string>>(type: "text[]", nullable: true),
                    Diphthongs = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedSyllables = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nucleus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllowedInitialOnset = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedInternalOnset = table.Column<List<string>>(type: "text[]", nullable: true),
                    AllowedFinalOnset = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VowelSymbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Rounded = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VowelSymbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IPARepresentation = table.Column<string>(type: "text", nullable: true),
                    Latinization = table.Column<string>(type: "text", nullable: true),
                    EnglishTranslation = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Types = table.Column<int[]>(type: "integer[]", nullable: true),
                    Register = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syllable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnsetComponentId = table.Column<int>(type: "integer", nullable: true),
                    NucleusComponentId = table.Column<int>(type: "integer", nullable: true),
                    CodaComponentId = table.Column<int>(type: "integer", nullable: true),
                    WordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Syllable_Coda_CodaComponentId",
                        column: x => x.CodaComponentId,
                        principalTable: "Coda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Syllable_Nucleus_NucleusComponentId",
                        column: x => x.NucleusComponentId,
                        principalTable: "Nucleus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Syllable_Onset_OnsetComponentId",
                        column: x => x.OnsetComponentId,
                        principalTable: "Onset",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Syllable_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "IPASymbols",
                columns: new[] { "Id", "Description", "IsVoiceless", "MannerOfArticulation", "PlaceOfArticulation", "Symbol" },
                values: new object[,]
                {
                    { 1, "Voiceless bilabial nasal", true, "Nasal", "Bilabial", "m̥" },
                    { 2, "Voiced bilabial nasal", false, "Nasal", "Bilabial", "m" },
                    { 3, "Voiceless bilabial plosive", true, "Plosive", "Bilabial", "p" },
                    { 4, "Voiced bilabial plosive", false, "Plosive", "Bilabial", "b" },
                    { 5, "Voiceless bilabial affricate", true, "Non-sibilant Affricate", "Bilabial", "pɸ" },
                    { 6, "Voiced bilabial affricate", false, "Non-sibilant Affricate", "Bilabial", "bβ" },
                    { 7, "Voiceless bilabial fricative", true, "Non Siblant Fricative", "Bilabial", "ɸ" },
                    { 8, "Voiced bilabial fricative", false, "Non Siblant Fricative", "Bilabial", "β" },
                    { 9, "Voiceless bilabial fricative", true, "Approximant", "Bilabial", "β̞" },
                    { 10, "Voiced bilabial flap", false, "Tap/flap", "Bilabial", "ⱱ̟" },
                    { 11, "Voiceless bilabial trill", true, "Trill", "Bilabial", "ʙ̥" },
                    { 12, "Voiced bilabial trill", false, "Trill", "Bilabial", "ʙ" },
                    { 13, "Voiced Labiodental nasal", false, "Nasal", "Labiodental", "ɱ" },
                    { 14, "Voiceless labiodental plosive", true, "Plosive", "Labiodental", "p̪" },
                    { 15, "Voiced labiodental plosive", false, "Plosive", "Labiodental", "b̪" },
                    { 16, "Voiceless labiodental affricate", true, "Affricate", "Labiodental", "p̪f" },
                    { 17, "Voiced labiodental affricate", false, "Affricate", "Labiodental", "b̪v" },
                    { 18, "Voiceless labiodental fricative", true, "Non Siblant Fricative", "Labiodental", "f" },
                    { 19, "Voiced labiodental fricative", false, "Non Siblant Fricative", "Labiodental", "v" },
                    { 20, "Voiced labiodental approximant", false, "Approximant", "Labiodental", "ʋ" },
                    { 21, "Voiced labiodental flap", false, "Tap/flap", "Labiodental", "ⱱ" },
                    { 22, "Voiced linguolabial nasal", false, "Nasal", "Linguolabial", "n̼" },
                    { 23, "Voiceless linguolabial plosive", true, "Plosive", "Linguolabial", "t̼" },
                    { 24, "Voiced linguolabial plosive", false, "Plosive", "Linguolabial", "d̼" },
                    { 25, "Voiceless linguolabial fricative", true, "Non Siblant Fricative", "Linguolabial", "θ̼" },
                    { 26, "Voiced linguolabial fricative", false, "Non Siblant Fricative", "Linguolabial", "ð̼" },
                    { 27, "Voiced linguolabial plosive", true, "Plosive", "Linguolabial", "ɾ̼" },
                    { 28, "Voiceless dental plosive", true, "Plosive", "Dental", "t̪" },
                    { 29, "Voiced dental plosive", false, "Plosive", "Dental", "d̪" },
                    { 30, "Voiceless dental affricate", true, "Siblant Affricate", "Dental", "t̪s̪" },
                    { 31, "Voiced dental affricate", false, "Siblant Affricate", "Dental", "d̪z̪" },
                    { 32, "Voiceless dental non-sibilant affricate", true, "Non Siblant Affricate", "Dental", "t̪θ" },
                    { 33, "Voiced dental non-sibilant affricate", false, "Non Siblant Affricate", "Dental", "d̪ð" },
                    { 34, "Voiceless dental fricative", true, "Non Siblant Fricative", "Dental", "θ" },
                    { 35, "Voiced dental fricative", false, "Non Siblant Fricative", "Dental", "ð" },
                    { 36, "Voiced dental approximant", false, "Approximant", "Dental", "ð̞" },
                    { 37, "Voiced dental lateral approximant", false, "Lateral approximant", "Dental", "l̪" },
                    { 38, "Voiceless alveolar lateral flap", false, "Lateral tap/flap", "Dental", "ɺ̥" },
                    { 39, "Voiceless alveolar nasal", true, "Nasal", "Alveolar", "n̥" },
                    { 40, "Voiced alveolar nasal", false, "Nasal", "Alveolar", "n" },
                    { 41, "Voiceless alveolar plosive", true, "Plosive", "Alveolar", "t" },
                    { 42, "Voiced alveolar plosive", false, "Plosive", "Alveolar", "d" },
                    { 43, "Voiceless alveolar affricate", true, "Siblant Affricate", "Alveolar", "ts" },
                    { 44, "Voiced alveolar affricate", false, "Siblant Affricate", "Alveolar", "dz" },
                    { 45, "Voiceless alveolar non-sibilant affricate", true, "Non Siblant Affricate", "Alveolar", "tɹ̝̊" },
                    { 46, "Voiced alveolar non-sibilant affricate", false, "Non Siblant Affricate", "Alveolar", "dɹ̝" },
                    { 47, "Voiceless alveolar sibilant fricative", true, "Siblant Fricative", "Alveolar", "s" },
                    { 48, "Voiced alveolar sibilant fricative", false, "Siblant Fricative", "Alveolar", "z" },
                    { 49, "Voiceless alveolar non-sibilant fricative", true, "Non Siblant Fricative", "Alveolar", "θ̠" },
                    { 50, "Voiced alveolar non-sibilant fricative", false, "Non Siblant Fricative", "Alveolar", "ð̠" },
                    { 51, "Voiced alveolar approximant", false, "Approximant", "Alveolar", "ɹ" },
                    { 52, "Voiceless alveolar flap", true, "Tap/flap", "Alveolar", "ɾ̥" },
                    { 53, "Voiced alveolar flap", false, "Tap/flap", "Alveolar", "ɾ" },
                    { 54, "Voiceless alveolar trill", true, "Trill", "Alveolar", "r̥" },
                    { 55, "Voiced alveolar trill", false, "Trill", "Alveolar", "r" },
                    { 56, "Voiceless alveolar lateral affricate", true, "Lateral Affricate", "Alveolar", "tɬ" },
                    { 57, "Voiced alveolar lateral affricate", false, "Lateral Affricate", "Alveolar", "dɮ" },
                    { 58, "Voiceless alveolar lateral fricative", true, "Lateral Fricative", "Alveolar", "ɬ" },
                    { 59, "Voiced alveolar lateral fricative", false, "Lateral Fricative", "Alveolar", "ɮ" },
                    { 60, "Voiced alveolar lateral approximant", false, "Lateral Approximant", "Alveolar", "l" },
                    { 61, "Voiced alveolar lateral flap", false, "Lateral Tap/flap", "Alveolar", "ɺ" },
                    { 62, "Voiceless postalveolar affricate", true, "Siblant Affricate", "Postalveolar", "t̠ʃ" },
                    { 63, "Voiced postalveolar affricate", false, "Siblant Affricate", "Postalveolar", "d̠ʒ" },
                    { 64, "Voiceless postalveolar non-sibilant affricate", true, "Non Siblant Affricate", "Postalveolar", "t̠ɹ̠̊˔" },
                    { 65, "Voiced postalveolar non-sibilant affricate", false, "Non Siblant Affricate", "Postalveolar", "d̠ɹ̠˔" },
                    { 66, "Voiceless postalveolar sibilant fricative", true, "Siblant Fricative", "Postalveolar", "ʃ" },
                    { 67, "Voiced postalveolar sibilant fricative", false, "Siblant Fricative", "Postalveolar", "ʒ" },
                    { 68, "Voiceless postalveolar non-sibilant fricative", true, "Non Siblant Fricative", "Postalveolar", "ɹ̠̊˔" },
                    { 69, "Voiced postalveolar non-sibilant fricative", false, "Non Siblant Fricative", "Postalveolar", "ɹ̠˔" },
                    { 70, "Voiced postalveolar approximant", false, "Approximant", "Postalveolar", "ɹ̠" },
                    { 71, "Voiced postalveolar trill", false, "Trill", "Postalveolar", "r̠" },
                    { 72, "Voiced postalveolar lateral approximant", false, "Lateral Approximant", "Postalveolar", "l̠" },
                    { 73, "Voiceless retroflex nasal", true, "Nasal", "Retroflex", "ɳ̊" },
                    { 74, "Voiced retroflex nasal", false, "Nasal", "Retroflex", "ɳ" },
                    { 75, "Voiceless retroflex plosive", true, "Plosive", "Retroflex", "ʈ" },
                    { 76, "Voiced retroflex plosive", false, "Plosive", "Retroflex", "ɖ" },
                    { 77, "Voiceless retroflex affricate", true, "Siblant Affricate", "Retroflex", "tʂ" },
                    { 78, "Voiced retroflex affricate", false, "Siblant Affricate", "Retroflex", "dʐ" },
                    { 79, "Voiceless retroflex sibilant fricative", true, "Siblant Fricative", "Retroflex", "ʂ" },
                    { 80, "Voiced retroflex sibilant fricative", false, "Siblant Fricative", "Retroflex", "ʐ" },
                    { 81, "Voiceless retroflex non-sibilant fricative", true, "Non Siblant Fricative", "Retroflex", "ɻ̊˔" },
                    { 82, "Voiced retroflex non-sibilant fricative", false, "Non Siblant Fricative", "Retroflex", "ɻ˔" },
                    { 83, "Voiced retroflex approximant", false, "Approximant", "Retroflex", "ɻ" },
                    { 84, "Voiceless retroflex flap", true, "Tap/flap", "Retroflex", "ɽ̊" },
                    { 85, "Voiced retroflex flap", false, "Tap/flap", "Retroflex", "ɽ" },
                    { 86, "Voiceless retroflex trill", true, "Trill", "Retroflex", "ɽ̊r̥" },
                    { 87, "Voiced retroflex trill", false, "Trill", "Retroflex", "ɽr" },
                    { 88, "Voiceless retroflex lateral affricate", true, "Lateral Affricate", "Retroflex", "tꞎ" },
                    { 89, "Voiced retroflex lateral affricate", false, "Lateral Affricate", "Retroflex", "ɖ͡ɭ" },
                    { 90, "Voiceless retroflex lateral fricative", true, "Lateral Fricative", "Retroflex", "ꞎ" },
                    { 91, "Voiced retroflex lateral fricative", false, "Lateral Fricative", "Retroflex", "ɭ̞̝" },
                    { 92, "Voiced retroflex lateral approximant", false, "Lateral Approximant", "Retroflex", "ɭ" },
                    { 93, "Voiceless retroflex lateral flap", true, "Lateral Tap/flap", "Retroflex", "ɭ̼̊" },
                    { 94, "Voiced retroflex lateral flap", false, "Lateral Tap/flap", "Retroflex", "ɭ̺" },
                    { 95, "Voiceless palatal nasal", true, "Nasal", "Palatal", "ɲ̊" },
                    { 96, "Voiced palatal nasal", false, "Nasal", "Palatal", "ɲ" },
                    { 97, "Voiceless palatal plosive", true, "Plosive", "Palatal", "c" },
                    { 98, "Voiced palatal plosive", false, "Plosive", "Palatal", "ɟ" },
                    { 99, "Voiceless palatal affricate", true, "Siblant Affricate", "Palatal", "tɕ" },
                    { 100, "Voiced palatal affricate", false, "Siblant Affricate", "Palatal", "dʑ" },
                    { 101, "Voiceless palatal non-sibilant affricate", true, "Non Siblant Affricate", "Palatal", "cç" },
                    { 102, "Voiced palatal non-sibilant affricate", false, "Non Siblant Affricate", "Palatal", "ɟʝ" },
                    { 103, "Voiceless palatal sibilant fricative", true, "Siblant Fricative", "Palatal", "ɕ" },
                    { 104, "Voiced palatal sibilant fricative", false, "Siblant Fricative", "Palatal", "ʑ" },
                    { 105, "Voiceless palatal non-sibilant fricative", true, "Non Siblant Fricative", "Palatal", "ç" },
                    { 106, "Voiced palatal non-sibilant fricative", false, "Non Siblant Fricative", "Palatal", "ʝ" },
                    { 107, "Voiced palatal approximant", false, "Approximant", "Palatal", "j" },
                    { 108, "Voiceless palatal lateral affricate", true, "Lateral Affricate", "Palatal", "cʎ̥" },
                    { 109, "Voiced palatal lateral affricate", false, "Lateral Affricate", "Palatal", "ɟʎ̝" },
                    { 110, "Voiceless palatal lateral fricative", true, "Lateral Fricative", "Palatal", "ʎ̥̞" },
                    { 111, "Voiced palatal lateral fricative", false, "Lateral Fricative", "Palatal", "ʎ̝" },
                    { 112, "Voiced palatal lateral approximant", false, "Lateral Approximant", "Palatal", "ʎ" },
                    { 113, "Voiced palatal lateral flap", false, "Lateral Tap/flap", "Palatal", "ʎ̆" },
                    { 114, "Voiceless velar nasal", true, "Nasal", "Velar", "ŋ̊" },
                    { 115, "Voiced velar nasal", false, "Nasal", "Velar", "ŋ" },
                    { 116, "Voiceless velar plosive", true, "Plosive", "Velar", "k" },
                    { 117, "Voiced velar plosive", false, "Plosive", "Velar", "g" },
                    { 118, "Voiceless velar affricate", true, "Non Siblant Affricate", "Velar", "kx" },
                    { 119, "Voiced velar affricate", false, "Non Siblant Affricate", "Velar", "ɡɣ" },
                    { 120, "Voiceless velar fricative", true, "Non Siblant Fricative", "Velar", "x" },
                    { 121, "Voiced velar fricative", false, "Non Siblant Fricative", "Velar", "ɣ" },
                    { 122, "Voiced velar approximant", false, "Approximant", "Velar", "ɰ" },
                    { 123, "Voiceless velar lateral affricate", true, "Lateral Affricate", "Velar", "k𝼄" },
                    { 124, "Voiced velar lateral affricate", false, "Lateral Affricate", "Velar", "ɡʟ̝" },
                    { 125, "Voiceless velar lateral fricative", true, "Lateral Fricative", "Velar", "𝼄" },
                    { 126, "Voiced velar lateral fricative", false, "Lateral Fricative", "Velar", "ʟ̝" },
                    { 127, "Voiced velar lateral approximant", false, "Lateral Approximant", "Velar", "ʟ" },
                    { 128, "Voiced velar lateral flap", false, "Lateral Tap/flap", "Velar", "ʟ̆" },
                    { 129, "Voiced uvular nasal", false, "Nasal", "Uvular", "ɴ" },
                    { 130, "Voiceless uvular plosive", true, "Plosive", "Uvular", "q" },
                    { 131, "Voiced uvular plosive", false, "Plosive", "Uvular", "ɢ" },
                    { 132, "Voiceless uvular affricate", true, "Non Siblant Affricate", "Uvular", "qχ" },
                    { 133, "Voiced uvular affricate", false, "Non Siblant Affricate", "Uvular", "ɢʁ" },
                    { 134, "Voiceless uvular fricative", true, "Non Siblant Fricative", "Uvular", "χ" },
                    { 135, "Voiced uvular fricative", false, "Non Siblant Fricative", "Uvular", "ʁ" },
                    { 136, "Voiced uvular approximant", false, "Approximant", "Uvular", "ʁ̞" },
                    { 137, "Voiced uvular lateral flap", false, "Tap/flap", "Uvular", "ɢ̆" },
                    { 138, "Voiceless uvular trill", true, "Trill", "Uvular", "ʀ̥" },
                    { 139, "Voiced uvular trill", false, "Trill", "Uvular", "ʀ" },
                    { 140, "Voiced uvular lateral approximant", false, "Lateral Approximant", "Uvular", "ʟ̠" },
                    { 141, "Pharyngeal/Epiglottal", true, "Plosive", "Pharyngeal/Epiglottal", "ʡ" },
                    { 142, "Pharyngeal/Epiglottal", true, "Non Siblant Affricate", "Pharyngeal/Epiglottal", "ʡʜ" },
                    { 143, "Pharyngeal/Epiglottal", true, "Non Siblant Affricate", "Pharyngeal/Epiglottal", "ʡʢ" },
                    { 144, "Pharyngeal/Epiglottal", true, "Non Siblant Fricative", "Pharyngeal/Epiglottal", "ħ" },
                    { 145, "Pharyngeal/Epiglottal", false, "Non Siblant Fricative", "Pharyngeal/Epiglottal", "ʕ" },
                    { 146, "Pharyngeal/Epiglottal", true, "Tap/flap", "Pharyngeal/Epiglottal", "ʡ̆" },
                    { 147, "Pharyngeal/Epiglottal", true, "Trill", "Pharyngeal/Epiglottal", "ʜ" },
                    { 148, "Pharyngeal/Epiglottal", true, "Trill", "Pharyngeal/Epiglottal", "ʢ" },
                    { 149, "Glottal Stop", true, "Plosive", "Glottal", "ʔ" },
                    { 150, "Glottal Stop", true, "Non Siblant Affricate", "Glottal", "ʔh" },
                    { 151, "Glottal Stop", true, "Non Siblant Fricative", "Glottal", "h" },
                    { 152, "Glottal Stop", false, "Non Siblant Fricative", "Glottal", "ɦ" },
                    { 153, "Glottal Stop", true, "Approximant", "Glottal", "ʔ̞" }
                });

            migrationBuilder.InsertData(
                table: "VowelSymbols",
                columns: new[] { "Id", "Description", "Height", "Position", "Rounded", "Symbol" },
                values: new object[,]
                {
                    { 154, "Close front unrounded vowel", "Close", "Front", false, "i" },
                    { 155, "Close front rounded vowel", "Close", "Front", true, "y" },
                    { 156, "Close central unrounded vowel", "Close", "Central", false, "ɨ" },
                    { 157, "Close central rounded vowel", "Close", "Central", true, "ʉ" },
                    { 158, "Close back unrounded vowel", "Close", "Back", false, "ɯ" },
                    { 159, "Close back rounded vowel", "Close", "Back", true, "u" },
                    { 160, "Near-close near-front unrounded vowel", "Near-close", "Near-front", false, "ɪ" },
                    { 161, "Near-close near-front rounded vowel", "Near-close", "Near-front", true, "ʏ" },
                    { 162, "Near-close near-back rounded vowel", "Near-close", "Near-back", true, "ʊ" },
                    { 163, "Close-mid front unrounded vowel", "Close-mid", "Front", false, "e" },
                    { 164, "Close-mid front rounded vowel", "Close-mid", "Front", true, "ø" },
                    { 165, "Close-mid central unrounded vowel", "Close-mid", "Central", false, "ɘ" },
                    { 166, "Close-mid central rounded vowel", "Close-mid", "Central", true, "ɵ" },
                    { 167, "Close-mid back unrounded vowel", "Close-mid", "Back", false, "ɤ" },
                    { 168, "Close-mid back rounded vowel", "Close-mid", "Back", true, "o" },
                    { 169, "Mid front unrounded vowel", "Mid", "Front", false, "e̞" },
                    { 170, "Mid front rounded vowel", "Mid", "Front", true, "ø̞" },
                    { 171, "Mid central vowel", "Mid", "Central", false, "ə" },
                    { 172, "Mid back unrounded vowel", "Mid", "Back", false, "ɤ̞" },
                    { 173, "Mid back rounded vowel", "Mid", "Back", true, "o̞" },
                    { 174, "Open-mid front unrounded vowel", "Open-mid", "Front", false, "ɛ" },
                    { 175, "Open-mid front rounded vowel", "Open-mid", "Front", true, "œ" },
                    { 176, "Open-mid central unrounded vowel", "Open-mid", "Central", false, "ɜ" },
                    { 177, "Open-mid central rounded vowel", "Open-mid", "Central", true, "ɞ" },
                    { 178, "Open-mid back unrounded vowel", "Open-mid", "Back", false, "ʌ" },
                    { 179, "Open-mid back rounded vowel", "Open-mid", "Back", true, "ɔ" },
                    { 180, "Near-open front unrounded vowel", "Near-open", "Front", false, "æ" },
                    { 181, "Near-open central vowel", "Near-open", "Central", false, "ɐ" },
                    { 182, "Open front unrounded vowel", "Open", "Front", false, "a" },
                    { 183, "Open front rounded vowel", "Open", "Front", true, "ɶ" },
                    { 184, "Open central unrounded vowel", "Open", "Central", false, "ä" },
                    { 185, "Open back unrounded vowel", "Open", "Back", false, "ɑ" },
                    { 186, "Open back rounded vowel", "Open", "Back", true, "ɒ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Syllable_CodaComponentId",
                table: "Syllable",
                column: "CodaComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllable_NucleusComponentId",
                table: "Syllable",
                column: "NucleusComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllable_OnsetComponentId",
                table: "Syllable",
                column: "OnsetComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllable_WordId",
                table: "Syllable",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPASymbols");

            migrationBuilder.DropTable(
                name: "Syllable");

            migrationBuilder.DropTable(
                name: "VowelSymbols");

            migrationBuilder.DropTable(
                name: "Coda");

            migrationBuilder.DropTable(
                name: "Nucleus");

            migrationBuilder.DropTable(
                name: "Onset");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
