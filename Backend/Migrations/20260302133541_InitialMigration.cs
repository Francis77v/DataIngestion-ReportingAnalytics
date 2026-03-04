using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sex = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Occupation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AgeBracket = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EducationalAttainment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Religion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IfAfterCare = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IfDde = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ethnicity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LivingArrangement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SubstanceUse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Program = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staging_imports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    RawRegistryNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawCaseFileNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawCaseCategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawSex = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RawAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawMaritalStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawOccupation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawAgeBracket = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawEducationalAttainment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawReligion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawIfAfterCare = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawIfDde = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawNationality = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawEthnicity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawLivingArrangement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawSubstanceUse = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RawProgram = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ImportedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Processed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staging_imports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    RegistryNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CaseFileNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CaseCategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Clients_Id",
                        column: x => x.Id,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "staging_imports");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
