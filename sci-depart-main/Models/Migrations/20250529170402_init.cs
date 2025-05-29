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
                    Money = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Courant = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    { "11111111-1111-1111-1111-111111111111", 0, "5bcc81a8-6064-4011-8a30-0765fa61f829", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMgH9iyaHLC7URFWscaZlRobVNrVHj9GcN/04FQDVP0gm8Uw3hnOVrnAlkSD1g0D5w==", null, false, "5b611a33-bc2e-4751-be6a-692abf148704", false, "admin@admin.com" },
                    { "User1Id", 0, "486fdeaa-5a9b-4426-a8ca-47563ab718dc", null, false, false, null, null, null, null, null, false, "996e7f7d-ab5c-4886-b190-f3a9689739fd", false, null },
                    { "User2Id", 0, "b128daf2-8210-4a0c-8716-2efa29d3260e", null, false, false, null, null, null, null, null, false, "f4f8327a-26cd-430c-aa82-0942661ef0f6", false, null }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "IsSpell", "Name", "Rareté", "SpellId" },
                values: new object[,]
                {
                    { 1, 3, 3, 3, "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg", false, "Chat Dragon", 0, null },
                    { 2, 2, 3, 5, "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg", false, "Chat Awesome", 0, null },
                    { 3, 2, 1, 1, "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg", false, "Chatton Laser", 1, null },
                    { 4, 8, 4, 4, "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg", false, "Chat Spacial", 1, null },
                    { 5, 7, 5, 7, "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg", false, "Chat Guerrier", 2, null },
                    { 6, 4, 2, 2, "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720", false, "Chat Laser", 2, null },
                    { 7, 6, 4, 3, "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg", false, "Jedi Chat", 3, null },
                    { 8, 1, 2, 9, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/c89c9a3c-7848-4bd5-9306-417c97096ae5/dh8sghm-7bebd975-51f2-4728-87bc-fb3cef176af5.jpg/v1/fit/w_750,h_1000,q_70,strp/another_lucifur_blob_by_slugyyycat_dh8sghm-375w-2x.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTAwMCIsInBhdGgiOiJcL2ZcL2M4OWM5YTNjLTc4NDgtNGJkNS05MzA2LTQxN2M5NzA5NmFlNVwvZGg4c2dobS03YmViZDk3NS01MWYyLTQ3MjgtODdiYy1mYjNjZWYxNzZhZjUuanBnIiwid2lkdGgiOiI8PTc1MCJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.7oGugpkEX4yqfhiOXlo4TfqzatOuHaCu2aEi-Lnw_40", false, "Blob Chat", 3, null },
                    { 9, 5, 2, 1, "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75", false, "Jedi Chatton", 3, null },
                    { 10, 6, 2, 1, "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg", false, "Chat Furtif", 2, null }
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
                    { 3, 2, "https://m.media-amazon.com/images/I/61y74SPNLnL._AC_UF894,1000_QL80_.jpg", "La céramique", 5, 1, 2 }
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
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "IsSpell", "Name", "Rareté", "SpellId" },
                values: new object[,]
                {
                    { 11, 0, 2, 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR936kxkL3CDGYOfTwzxYl8nAZ_KE3GzXk6GQ&s", true, "Random Pain", 1, 2 },
                    { 12, 0, 2, 0, "https://catpedia.wiki/images/5/59/Milly.png", true, "Earthquake", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Money", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "Test player 1", "User1Id" },
                    { 2, 20, "Test player 2", "User2Id" }
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
                    { 10, 11 },
                    { 11, 12 }
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
