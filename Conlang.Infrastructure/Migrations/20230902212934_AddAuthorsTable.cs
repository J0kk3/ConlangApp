using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Conlang.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConlangProjectId",
                table: "Words",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConlangProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConlangName = table.Column<string>(type: "text", nullable: true),
                    ConlangParent = table.Column<string>(type: "text", nullable: true),
                    ConlangAuthor = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Structure_SyllableStructure_NucleusId = table.Column<int>(type: "integer", nullable: true),
                    Structure_SyllableStructure_OnsetId = table.Column<int>(type: "integer", nullable: true),
                    Structure_SyllableStructure_CodaId = table.Column<int>(type: "integer", nullable: true),
                    Structure_WordOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_AdpositionOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_DemonstrativeOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_NumberOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_PossessiveOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_AdjectiveOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_GenitiveOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_RelativeClauseOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_AuxiliaryOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_CopulaOrder = table.Column<int>(type: "integer", nullable: true),
                    Structure_VerbElementOrder = table.Column<int[]>(type: "integer[]", nullable: true),
                    Structure_IsHeadInitial = table.Column<bool>(type: "boolean", nullable: true),
                    Structure_Topicalization = table.Column<bool>(type: "boolean", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConlangProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConlangProject_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConlangProject_Coda_Structure_SyllableStructure_CodaId",
                        column: x => x.Structure_SyllableStructure_CodaId,
                        principalTable: "Coda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConlangProject_Nucleus_Structure_SyllableStructure_NucleusId",
                        column: x => x.Structure_SyllableStructure_NucleusId,
                        principalTable: "Nucleus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConlangProject_Onset_Structure_SyllableStructure_OnsetId",
                        column: x => x.Structure_SyllableStructure_OnsetId,
                        principalTable: "Onset",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_ConlangProjectId",
                table: "Words",
                column: "ConlangProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConlangProject_AuthorId",
                table: "ConlangProject",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConlangProject_Structure_SyllableStructure_CodaId",
                table: "ConlangProject",
                column: "Structure_SyllableStructure_CodaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConlangProject_Structure_SyllableStructure_NucleusId",
                table: "ConlangProject",
                column: "Structure_SyllableStructure_NucleusId");

            migrationBuilder.CreateIndex(
                name: "IX_ConlangProject_Structure_SyllableStructure_OnsetId",
                table: "ConlangProject",
                column: "Structure_SyllableStructure_OnsetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_ConlangProject_ConlangProjectId",
                table: "Words",
                column: "ConlangProjectId",
                principalTable: "ConlangProject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_ConlangProject_ConlangProjectId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "ConlangProject");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Words_ConlangProjectId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ConlangProjectId",
                table: "Words");
        }
    }
}
