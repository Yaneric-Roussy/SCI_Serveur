using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nbCardsToDraw = table.Column<int>(type: "INTEGER", nullable: false),
                    Mana = table.Column<int>(type: "INTEGER", nullable: false),
                    nbMaxDecks = table.Column<int>(type: "INTEGER", nullable: false),
                    nbMaxCartesDecks = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NbCard = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Rareté = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IconeURL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Icone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Icone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    Victoire = table.Column<int>(type: "INTEGER", nullable: false),
                    Defaite = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Probabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseQty = table.Column<int>(type: "INTEGER", nullable: false),
                    PackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Probabilities_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Rareté = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSpell = table.Column<bool>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Courant = table.Column<bool>(type: "INTEGER", nullable: false),
                    Victoire = table.Column<int>(type: "INTEGER", nullable: false),
                    Defaite = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Mana = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayersData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayersData_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Elo = table.Column<int>(type: "INTEGER", nullable: false),
                    Attente = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerInfos_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPower_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPower_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartingCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeckId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnedCard_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnedCard_Decks_DeckId1",
                        column: x => x.DeckId1,
                        principalTable: "Decks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnedCard_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPlayerATurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMatchCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    WinnerUserId = table.Column<string>(type: "TEXT", nullable: true),
                    UserAId = table.Column<string>(type: "TEXT", nullable: false),
                    UserBId = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerDataAId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerDataBId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataAId",
                        column: x => x.PlayerDataAId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataBId",
                        column: x => x.PlayerDataBId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchPlayerDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId2 = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId3 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId",
                        column: x => x.MatchPlayerDataId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId1",
                        column: x => x.MatchPlayerDataId1,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId2",
                        column: x => x.MatchPlayerDataId2,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId3",
                        column: x => x.MatchPlayerDataId3,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCardStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayableCardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCardStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_PlayableCard_PlayableCardId",
                        column: x => x.PlayableCardId,
                        principalTable: "PlayableCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "b68d9422-8020-4a46-9c77-65ead53f3248", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBh3C6vqLFf6PylEyENkKP9HzHrFvEtyr5gIUEkkB5g8W/9KWboWx9fn/ctnK2ohfw==", null, false, "ae5ec06d-93f5-444a-9949-915ef2e60c7b", false, "admin@admin.com" },
                    { "User1Id", 0, "133d7864-7659-44da-b57d-91076a43d2d3", null, false, false, null, null, null, null, null, false, "f0fb415a-7732-493c-bb6e-e56010a2afda", false, null },
                    { "User2Id", 0, "4be2c72d-04f9-4645-a2cc-54f4a9cb2f4e", null, false, false, null, null, null, null, null, false, "9a7dc564-f255-4fc0-9faf-e2058628fbbe", false, null }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "IsSpell", "Name", "Rareté", "SpellId" },
                values: new object[,]
                {
                    { 1, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/001.png", false, "Bulbizarre", 1, null },
                    { 2, 5, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/002.png", false, "Herbizarre", 1, null },
                    { 3, 6, 8, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png", false, "Florizarre", 2, null },
                    { 4, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/004.png", false, "Salamèche", 1, null },
                    { 5, 5, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/005.png", false, "Reptincel", 1, null },
                    { 6, 7, 8, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006.png", false, "Dracaufeu", 2, null },
                    { 7, 3, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/007.png", false, "Carapuce", 1, null },
                    { 8, 4, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/008.png", false, "Carabaffe", 1, null },
                    { 9, 5, 8, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png", false, "Tortank", 2, null },
                    { 25, 4, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png", false, "Pikachu", 0, null },
                    { 26, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/026.png", false, "Raichu", 1, null },
                    { 27, 5, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/027_f2.png", false, "Sabelette d'Alola", 0, null },
                    { 28, 6, 3, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/028_f2.png", false, "Sablaireau d'Alola", 0, null },
                    { 102, 4, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/102.png", false, "Noeunoeuf", 0, null },
                    { 103, 6, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/103.png", false, "Noadkoko", 1, null },
                    { 111, 5, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/111.png", false, "Rhinocorne", 0, null },
                    { 112, 8, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/112.png", false, "Rhinoféros", 1, null },
                    { 150, 9, 9, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/150.png", false, "Mewtwo", 3, null },
                    { 151, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png", false, "Mew", 3, null },
                    { 201, 5, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/201.png", false, "Zarbi", 0, null },
                    { 203, 5, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/203.png", false, "Girafarig", 0, null },
                    { 249, 8, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/249.png", false, "Lugia", 3, null },
                    { 250, 8, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/250.png", false, "Ho-Oh", 3, null },
                    { 273, 3, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/273.png", false, "Grainipiot", 0, null },
                    { 274, 5, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/274.png", false, "Pifeuil", 0, null },
                    { 275, 6, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/275.png", false, "Tengalice", 1, null },
                    { 287, 4, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/287.png", false, "Parecool", 0, null },
                    { 288, 5, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/288.png", false, "Vigoroth ", 0, null },
                    { 289, 10, 9, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/289.png", false, "Monaflèmit", 1, null },
                    { 384, 9, 9, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png", false, "Rayquaza", 3, null },
                    { 459, 4, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/459.png", false, "Blizzi", 0, null },
                    { 460, 6, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/460.png", false, "Blizzaroi", 1, null },
                    { 493, 8, 8, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/493.png", false, "Arceus", 3, null },
                    { 570, 4, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/570.png", false, "Zorua", 1, null },
                    { 571, 7, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/571.png", false, "Zoroark", 2, null },
                    { 643, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/643.png", false, "Reshiram", 3, null },
                    { 644, 6, 7, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/644.png", false, "Zekrom", 3, null },
                    { 656, 4, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/656.png", false, "Grenousse", 1, null },
                    { 657, 4, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/657.png", false, "Croâporal", 1, null },
                    { 658, 6, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/658_f2.png", false, "Amphinobi", 2, null },
                    { 661, 3, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/661.png", false, "Passerouge", 0, null },
                    { 662, 5, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/662.png", false, "Braisillon", 1, null },
                    { 663, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/663.png", false, "Flambusard", 1, null },
                    { 714, 3, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/714.png", false, "Sonistrelle", 0, null },
                    { 715, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/715.png", false, "Bruyverne", 2, null },
                    { 716, 7, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/716.png", false, "Xerneas", 3, null },
                    { 717, 8, 7, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/717.png", false, "Yveltal", 3, null },
                    { 720, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/720.png", false, "Hoopa", 3, null },
                    { 802, 8, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/802.png", false, "Marshadow", 3, null },
                    { 885, 4, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/885.png", false, "Fantyrm", 0, null },
                    { 886, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/886.png", false, "Dispareptil", 1, null },
                    { 887, 8, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/887.png", false, "Lanssorien", 2, null }
                });

            migrationBuilder.InsertData(
                table: "GameConfig",
                columns: new[] { "Id", "Mana", "nbCardsToDraw", "nbMaxCartesDecks", "nbMaxDecks" },
                values: new object[] { 1, 3, 4, 10, 3 });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "Cost", "ImageUrl", "Name", "NbCard", "Rareté", "Type" },
                values: new object[,]
                {
                    { 1, 1, "https://www.realite-virtuelle.com/wp-content/uploads/2021/02/rayquaza-tout-savoir-guide.jpg", "Le platre", 3, 0, 0 },
                    { 2, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZahnOokotXrBgjZ2ywo9aQaw7oLO-JqE1rA&s", "La brique", 4, 0, 1 },
                    { 3, 5, "https://m.media-amazon.com/images/I/61y74SPNLnL._AC_UF894,1000_QL80_.jpg", "La céramique", 5, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Power",
                columns: new[] { "Id", "Description", "IconeURL", "Name" },
                values: new object[,]
                {
                    { 1, "Permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire.", "🥇", "First strike" },
                    { 2, "Lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.", "🌹", "Thorns" },
                    { 3, "soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", "💖", "Heal" },
                    { 4, "Augmente de X les dégâts que la carte inflige quand elle attaque.", "🐱‍🏍", "Attack boost" },
                    { 5, "Inverse l'attaque et la défense de toutes les cartes en jeu. Il se produit avant que la carte attaque.", "💥", "Chaos" },
                    { 6, "Ajoute une valeur de poison à la carte attaquée. Le poison diminue ensuite la vie d’une carte de la valeur du poison à la fin de son activation.", "🧪", "Poison" },
                    { 7, "Empêche une carte d’agir pendant son activation durant X tours. Mais elle reçoit quand même les dégâts de poison", "💫", "Stunned" },
                    { 8, "Donne l'invulnérabilité à la carte durant X tours. La carte ne peut pas prendre de dégâts, même des sorts.", "🛡", "Protection" }
                });

            migrationBuilder.InsertData(
                table: "Spell",
                columns: new[] { "Id", "Description", "Icone", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Fait X dégâts à TOUTES les cartes en jeu.", "🌎", "Earthquake", 2 },
                    { 2, "Fait 1 à 6 de dégâts à une carte adverse (au hazard).", "🤕", "Random Pain", 0 }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "Icone", "Name" },
                values: new object[,]
                {
                    { 1, "La carte est poisoned, elle prend du dégât de poison.", "🧪", "Poisoned" },
                    { 2, "La carte est stunned, elle ne peut pas prendre d'action.", "💫", "Stunned" },
                    { 3, "Donne l'invulnérabilité à la carte durant X tours. La carte ne peut pas prendre de dégâts, même des sorts.", "🛡", "Protected" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "CardPower",
                columns: new[] { "Id", "CardId", "PowerId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 1, 3, 1 },
                    { 3, 1, 4, 4 },
                    { 4, 2, 2, 2 },
                    { 5, 2, 3, 1 },
                    { 6, 3, 5, 0 },
                    { 7, 4, 4, 5 },
                    { 8, 5, 6, 2 },
                    { 9, 6, 7, 2 },
                    { 10, 7, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Defaite", "Money", "Name", "UserId", "Victoire" },
                values: new object[,]
                {
                    { 1, 0, 20, "Test player 1", "User1Id", 0 },
                    { 2, 0, 20, "Test player 2", "User2Id", 0 }
                });

            migrationBuilder.InsertData(
                table: "Probabilities",
                columns: new[] { "Id", "BaseQty", "PackId", "Rarity", "Value" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, 0.29999999999999999 },
                    { 2, 1, 2, 1, 0.29999999999999999 },
                    { 3, 0, 2, 2, 0.10000000000000001 },
                    { 4, 0, 2, 3, 0.02 },
                    { 5, 1, 3, 2, 0.25 },
                    { 6, 0, 3, 3, 0.10000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 26 },
                    { 11, 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardPower_CardId",
                table: "CardPower",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPower_PowerId",
                table: "CardPower",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SpellId",
                table: "Cards",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_PlayerId",
                table: "Decks",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataAId",
                table: "Matches",
                column: "PlayerDataAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataBId",
                table: "Matches",
                column: "PlayerDataBId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayersData_PlayerId",
                table: "MatchPlayersData",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_CardId",
                table: "OwnedCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_DeckId",
                table: "OwnedCard",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_DeckId1",
                table: "OwnedCard",
                column: "DeckId1");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_PlayerId",
                table: "OwnedCard",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_CardId",
                table: "PlayableCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId",
                table: "PlayableCard",
                column: "MatchPlayerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId1",
                table: "PlayableCard",
                column: "MatchPlayerDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId2",
                table: "PlayableCard",
                column: "MatchPlayerDataId2");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId3",
                table: "PlayableCard",
                column: "MatchPlayerDataId3");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_PlayableCardId",
                table: "PlayableCardStatus",
                column: "PlayableCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_StatusId",
                table: "PlayableCardStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInfos_PlayerId",
                table: "PlayerInfos",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Probabilities_PackId",
                table: "Probabilities",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardPower");

            migrationBuilder.DropTable(
                name: "GameConfig");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "OwnedCard");

            migrationBuilder.DropTable(
                name: "PlayableCardStatus");

            migrationBuilder.DropTable(
                name: "PlayerInfos");

            migrationBuilder.DropTable(
                name: "Probabilities");

            migrationBuilder.DropTable(
                name: "StartingCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "PlayableCard");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "MatchPlayersData");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
