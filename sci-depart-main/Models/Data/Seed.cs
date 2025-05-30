using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Models;


namespace Super_Cartes_Infinies.Data
{
    public class Seed
    {
        
        public Seed() { }

        public static GameConfig[] SeedGameConfig()
        {

            return new GameConfig[] {
            new GameConfig
            {
                Id = 1,
                nbCardsToDraw = 4,
                Mana = 3,
                nbMaxCartesDecks = 10,
                nbMaxDecks = 3,
            }
            };

        }
        public static Spell[] SeedSpells()
        {
            return new Spell[]
            {
                new Spell
                {
                    Id = Spell.EARTHQUAKE_ID,
                    Name = "Earthquake",
                    Description = "Fait X dégâts à TOUTES les cartes en jeu.",
                    Value = 2,
                    Icone = "🌎"
                },
                new Spell
                {
                    Id = Spell.RANDOM_PAIN_ID,
                    Name = "Random Pain",
                    Description = "Fait 1 à 6 de dégâts à une carte adverse (au hazard).",
                    Value = 0,
                    Icone = "🤕"
                }
            };
        }

        public static Status[] SeedStatus()
        {
            return new Status[]
            {
                new Status
                {
                    Id = Status.STUNNED_ID,
                    Name = "Stunned",
                    Description = "La carte est stunned, elle ne peut pas prendre d'action.",
                    Icone = "💫"
                },
                new Status
                {
                    Id = Status.POISONED_ID,
                    Name = "Poisoned",
                    Description = "La carte est poisoned, elle prend du dégât de poison.",
                    Icone = "🧪"
                },
                new Status
                {
                    Id = Status.PROTECTED_ID,
                    Name = "Protected",
                    Description = "Donne l'invulnérabilité à la carte durant X tours. La carte ne peut pas prendre de dégâts, même des sorts.",
                    Icone = "🛡" 
                }
            };
        }
        public static CardPower[] SeedCardPowers()
        {
            return new CardPower[]
            {
                //Ajout pour carte avec Id 1
                new CardPower
                {
                    Id = 1,
                    CardId = 1,
                    PowerId = Power.FIRST_STRIKE_ID,
                    Value = 0
                }, new CardPower
                {
                    Id = 2,
                    CardId = 1,
                    PowerId = Power.HEAL_ID,
                    Value = 1
                }, new CardPower
                {
                    Id = 3,
                    CardId = 1,
                    PowerId = Power.ATTACK_BOOST_ID,
                    Value = 4
                },
                //Ajout pour carte avec Id 2
                new CardPower
                {
                    Id = 4,
                    CardId = 2,
                    PowerId = Power.THORNS_ID,
                    Value = 2
                },
                new CardPower
                {
                    Id = 5,
                    CardId = 2,
                    PowerId = Power.HEAL_ID,
                    Value = 1
                },
                //Ajout pour carte avec Id 3 à 6
                new CardPower
                {
                    Id = 6,
                    CardId = 3,
                    PowerId = Power.CHAOS_ID,
                    Value = 0
                }, new CardPower
                {
                    Id = 7,
                    CardId = 4,
                    PowerId = Power.ATTACK_BOOST_ID,
                    Value = 5
                },
                new CardPower
                {
                    Id = 8,
                    CardId = 5,
                    PowerId = Power.POISON_ID,
                    Value = 2
                },
                new CardPower
                {
                    Id = 9,
                    CardId = 6,
                    PowerId = Power.STUNNED_ID,
                    Value = 2
                },
                new CardPower
                {
                    Id = 10,
                    CardId = 7,
                    PowerId = Power.PROTECTION_ID,
                    Value = 2
                }
            };
        }
        public static Power[] SeedPowers()
        {
            return new Power[]
            {
                new Power
                {
                    Id = Power.FIRST_STRIKE_ID,
                    Name = "First strike",
                    Description = "Permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire.",
                    IconeURL = "🥇"
                },
                new Power
                {
                    Id = Power.THORNS_ID,
                    Name = "Thorns",
                    Description = "Lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.",
                    IconeURL = "🌹"
                },
                new Power
                {
                    Id = Power.HEAL_ID,
                    Name = "Heal",
                    Description = "soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)",
                    IconeURL = "💖"
                },
                new Power
                {
                    Id = Power.ATTACK_BOOST_ID,
                    Name = "Attack boost",
                    Description ="Augmente de X les dégâts que la carte inflige quand elle attaque.",
                    IconeURL = "🐱‍🏍"
                },
                new Power
                {
                    Id = Power.CHAOS_ID,
                    Name = "Chaos",
                    Description = "Inverse l'attaque et la défense de toutes les cartes en jeu. Il se produit avant que la carte attaque.",
                    IconeURL = "💥"
                },
                new Power
                {
                    Id = Power.POISON_ID,
                    Name = "Poison",
                    Description = "Ajoute une valeur de poison à la carte attaquée. Le poison diminue ensuite la vie d’une carte de la valeur du poison à la fin de son activation.",
                    IconeURL = "🧪"
                },
                new Power
                {
                    Id = Power.STUNNED_ID,
                    Name = "Stunned",
                    Description = "Empêche une carte d’agir pendant son activation durant X tours. Mais elle reçoit quand même les dégâts de poison",
                    IconeURL = "💫"
                },
                new Power
                {
                    Id = Power.PROTECTION_ID,
                    Name = "Protection",
                    Description = "Donne l'invulnérabilité à la carte durant X tours. La carte ne peut pas prendre de dégâts, même des sorts.",
                    IconeURL = "🛡"
                }
            };
        }

        public static Card[] SeedCards()
        {
            return new Card[] {
                #region Gen1
                new Card
                {
                    Id = 1,
                    Name = "Bulbizarre",
                    Attack = 4,
                    Health = 3,
                    Cost = 4,
                    Rareté = Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/001.png"
                }, new Card
                {
                    Id = 2,
                    Name = "Herbizarre",
                    Attack = 5,
                    Health = 4,
                    Cost = 6,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/002.png"
                }, new Card
                {
                    Id = 3,
                    Name = "Florizarre",
                    Attack = 6,
                    Health = 5,
                    Cost = 8,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png"
                }, new Card
                {
                    Id = 4,
                    Name = "Salamèche",
                    Attack = 4,
                    Health = 3,
                    Cost = 4,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/004.png"
                }, new Card
                {
                    Id = 5,
                    Name = "Reptincel",
                    Attack = 5,
                    Health = 4,
                    Cost = 6,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/005.png"
                }, new Card
                {
                    Id = 6,
                    Name = "Dracaufeu",
                    Attack = 7,
                    Health = 5,
                    Cost = 8,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006.png"
                }, new Card
                {
                    Id = 7,
                    Name = "Carapuce",
                    Attack = 3,
                    Health = 3,
                    Cost = 4,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/007.png"
                }, new Card
                {
                    Id = 8,
                    Name = "Carabaffe",
                    Attack = 4,
                    Health = 4,
                    Cost = 6,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/008.png"
                }, new Card
                {
                    Id = 9,
                    Name = "Tortank",
                    Attack = 5,
                    Health = 5,
                    Cost = 8,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png"
                }, new Card
                {
                    Id = 25,
                    Name = "Pikachu",
                    Attack = 4,
                    Health = 3,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png"
                }, new Card
                {
                    Id = 26,
                    Name = "Raichu",
                    Attack = 6,
                    Health = 4,
                    Cost = 5,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/026.png"
                }, new Card
                {
                    Id = 27,
                    Name = "Sabelette d'Alola",
                    Attack = 5,
                    Health = 3,
                    Cost = 2,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/027_f2.png"
                }, new Card
                {
                    Id = 28,
                    Name = "Sablaireau d'Alola",
                    Attack = 6,
                    Health = 5,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/028_f2.png"
                }, new Card
                {
                    Id = 102,
                    Name = "Noeunoeuf",
                    Attack = 4,
                    Health = 4,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/102.png"
                }, new Card
                {
                    Id = 103,
                    Name = "Noadkoko",
                    Attack = 6,
                    Health = 6,
                    Cost = 5,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/103.png"
                },new Card
                {
                    Id = 111,
                    Name = "Rhinocorne",
                    Attack = 5,
                    Health = 5,
                    Cost = 4,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/111.png"
                },new Card
                {
                    Id = 112,
                    Name = "Rhinoféros",
                    Attack = 8,
                    Health = 7,
                    Cost = 8,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/112.png"
                },new Card
                {
                    Id = 150,
                    Name = "Mewtwo",
                    Attack = 9,
                    Health = 5,
                    Cost = 9,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/150.png"
                },new Card
                {
                    Id = 151,
                    Name = "Mew",
                    Attack = 6,
                    Health = 6,
                    Cost = 6,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png"
                },
                #endregion
                #region Gen2
                 new Card
                {
                    Id = 201,
                    Name = "Zarbi",
                    Attack = 5,
                    Health = 3,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/201.png"
                },  new Card
                {
                    Id = 203,
                    Name = "Girafarig",
                    Attack = 5,
                    Health = 5,
                    Cost = 4,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/203.png"
                },new Card
                {
                    Id = 249,
                    Name = "Lugia",
                    Attack = 8,
                    Health = 7,
                    Cost = 7,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/249.png"
                },new Card
                {
                    Id = 250,
                    Name = "Ho-Oh",
                    Attack = 8,
                    Health = 7,
                    Cost = 7,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/250.png"
                },
                #endregion
                #region Gen3
                new Card
                {
                    Id = 273,
                    Name = "Grainipiot",
                    Attack = 3,
                    Health = 3,
                    Cost = 2,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/273.png"
                },new Card
                {
                    Id = 274,
                    Name = "Pifeuil",
                    Attack = 5,
                    Health = 5,
                    Cost = 4,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/274.png"
                },new Card
                {
                    Id = 275,
                    Name = "Tengalice",
                    Attack = 6,
                    Health = 6,
                    Cost = 5,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/275.png"
                },new Card
                {
                    Id = 287,
                    Name = "Parecool",
                    Attack = 4,
                    Health = 4,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/287.png"
                },new Card
                {
                    Id = 288,
                    Name = "Vigoroth ",
                    Attack = 5,
                    Health = 5,
                    Cost = 4,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/288.png"
                },new Card
                {
                    Id = 289,
                    Name = "Monaflèmit",
                    Attack = 10,
                    Health = 9,
                    Cost = 9,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/289.png"
                },new Card
                {
                    Id = 384,
                    Name = "Rayquaza",
                    Attack = 9,
                    Health = 7,
                    Cost = 9,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png"
                },
                #endregion
                #region Gen4
                new Card
                {
                    Id = 459,
                    Name = "Blizzi",
                    Attack = 4,
                    Health = 4,
                    Cost = 3,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/459.png"
                },new Card
                {
                    Id = 460,
                    Name = "Blizzaroi",
                    Attack = 6,
                    Health = 6,
                    Cost = 5,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/460.png"
                },new Card
                {
                    Id = 493,
                    Name = "Arceus",
                    Attack = 8,
                    Health = 8,
                    Cost = 8,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/493.png"
                },
                #endregion
                #region Gen5
                new Card
                {
                    Id = 570,
                    Name = "Zorua",
                    Attack = 4,
                    Health = 3,
                    Cost = 3,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/570.png"
                },new Card
                {
                    Id = 571,
                    Name = "Zoroark",
                    Attack = 7,
                    Health = 4,
                    Cost = 5,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/571.png"
                },new Card
                {
                    Id = 643,
                    Name = "Reshiram",
                    Attack = 8,
                    Health = 6,
                    Cost = 7,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/643.png"
                },
                new Card
                {
                    Id = 644,
                    Name = "Zekrom",
                    Attack = 6,
                    Health = 8,
                    Cost = 7,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/644.png"
                },
                #endregion
                #region Gen6
                new Card
                {
                    Id = 656,
                    Name = "Grenousse",
                    Attack = 4,
                    Health = 3,
                    Cost = 3,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/656.png"
                },new Card
                {
                    Id = 657,
                    Name = "Croâporal",
                    Attack = 4,
                    Health = 4,
                    Cost = 3,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/657.png"
                },new Card
                {
                    Id = 658,
                    Name = "Amphinobi",
                    Attack = 6,
                    Health = 5,
                    Cost = 5,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/658_f2.png"
                },new Card
                {
                    Id = 661,
                    Name = "Passerouge",
                    Attack = 3,
                    Health = 3,
                    Cost = 2,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/661.png"
                },new Card
                {
                    Id = 662,
                    Name = "Braisillon",
                    Attack = 5,
                    Health = 4,
                    Cost = 3,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/662.png"
                },new Card
                {
                    Id = 663,
                    Name = "Flambusard",
                    Attack = 5,
                    Health = 5,
                    Cost = 5,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/663.png"
                },new Card
                {
                    Id = 714,
                    Name = "Sonistrelle",
                    Attack = 3,
                    Health = 3,
                    Cost = 2,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/714.png"
                },new Card
                {
                    Id = 715,
                    Name = "Bruyverne",
                    Attack = 5,
                    Health = 5,
                    Cost = 5,
                    Rareté=Card.rareté.Épique,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/715.png"
                },new Card
                {
                    Id = 716,
                    Name = "Xerneas",
                    Attack = 7,
                    Health = 7,
                    Cost = 6,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/716.png"
                }, new Card
                {
                    Id = 717,
                    Name = "Yveltal",
                    Attack = 8,
                    Health = 8,
                    Cost = 7,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/717.png"
                },new Card
                {
                    Id = 720,
                    Name = "Hoopa",
                    Attack = 7,
                    Health = 5,
                    Cost = 6,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/720.png"
                },
                #endregion
                #region Gen7
                new Card
                {
                    Id = 802,
                    Name = "Marshadow",
                    Attack = 8,
                    Health = 6,
                    Cost = 6,
                    Rareté=Card.rareté.Légendaire,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/802.png"
                },
                #endregion
                #region Gen8
                new Card
                {
                    Id = 885,
                    Name = "Fantyrm",
                    Attack = 4,
                    Health = 2,
                    Cost = 2,
                    Rareté=Card.rareté.Commune,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/885.png"
                },new Card
                {
                    Id = 886,
                    Name = "Dispareptil",
                    Attack = 5,
                    Health = 4,
                    Cost = 4,
                    Rareté=Card.rareté.Rare,
                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/886.png"
                },new Card
                {
                    Id = 887,
                    Name = "Lanssorien",
                    Attack = 8,
                    Health = 6,
                    Cost = 6,
                    Rareté=Card.rareté.Épique,

                    ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/887.png"
                },
                #endregion
            };
        }

        public static IdentityUser[] SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                // On encrypte le mot de passe
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                LockoutEnabled = true
            };
      

            return new IdentityUser[] { admin };
        }

        public static IdentityRole[] SeedRoles()
        {
            IdentityRole adminRole = new IdentityRole
            {
                Id = "11111111-1111-1111-1111-111111111112",
                Name = ApplicationDbContext.ADMIN_ROLE,
                NormalizedName = ApplicationDbContext.ADMIN_ROLE.ToUpper()
            };

            return new IdentityRole[] { adminRole };
        }

        public static IdentityUserRole<string>[] SeedUserRoles()
        {
            IdentityUserRole<string> userAdmin = new IdentityUserRole<string>
            {
                RoleId = "11111111-1111-1111-1111-111111111112",
                UserId = "11111111-1111-1111-1111-111111111111"
            };
            return new IdentityUserRole<string>[] { userAdmin };
        }

        public static object[] SeedStartingCards()
        {
            return new object[] {
                new {
                    Id = 1,
                    CardId = SeedCards()[0].Id  // Assigning the cardID value
                },
                new {
                    Id = 2,
                    CardId = SeedCards()[1].Id  // Assigning the cardID value
                },
                new {
                    Id = 3,
                    CardId = SeedCards()[2].Id  // Assigning the cardID value
                },
                new {
                    Id = 4,
                    CardId = SeedCards()[3].Id  // Assigning the cardID value
                },
                new {
                    Id = 5,
                    CardId = SeedCards()[4].Id  // Assigning the cardID value
                },
                new {
                    Id = 6,
                    CardId = SeedCards()[5].Id  // Assigning the cardID value
                },
                new {
                    Id = 7,
                    CardId = SeedCards()[6].Id  // Assigning the cardID value
                },
                new {
                    Id = 8,
                    CardId = SeedCards()[7].Id  // Assigning the cardID value
                },
                new {
                    Id = 9,
                    CardId = SeedCards()[8].Id  // Assigning the cardID value
                },
                new {
                    Id = 10,
                    CardId = SeedCards()[10].Id
                },
                new {
                    Id = 11,
                    CardId = SeedCards()[11].Id
                }

            };
        }

        public static IdentityUser[] SeedTestUsers()
        {
            return new IdentityUser[] {
                new IdentityUser()
                {
                    Id = "User1Id"
                },
                new IdentityUser
                {
                Id = "User2Id"
                }
            };
        }

        public static Player[] SeedTestPlayers()
        {
            return new Player[] {
                new Player
                {
                    Id = 1,
                    Name = "Test player 1",
                    UserId = "User1Id"

                },
                new Player
                {
                    Id = 2,
                    Name = "Test player 2",
                    UserId = "User2Id"
                }
            };
        }
        public static Pack[] SeedPacks()
        {
            return new Pack[] {
                new Pack
                {
                    Id = 1,
                    Name = "Le platre",
                    NbCard = 3,
                    Cost=1,
                    ImageUrl="https://www.realite-virtuelle.com/wp-content/uploads/2021/02/rayquaza-tout-savoir-guide.jpg"
                    ,Rareté = 0,
                    Type=0
                },
                new Pack
                {
                    Id = 2,
                    Name = "La brique",
                    NbCard=4,
                    Cost=2,
                    ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZahnOokotXrBgjZ2ywo9aQaw7oLO-JqE1rA&s",
                    Rareté = 0,
                    Type = Pack.type.Normal

                },
                  new Pack
                {
                    Id = 3,
                    Name = "La céramique",
                    NbCard=5,
                    Cost=5,
                    ImageUrl="https://m.media-amazon.com/images/I/61y74SPNLnL._AC_UF894,1000_QL80_.jpg",
                    Rareté = Pack.raretéPack.Rare,
                    Type = Pack.type.Super

                }
            };
        }
        public static Probability[] SeedProbs()
        {
            return new Probability[]
            {
                 // Probabilités pour le Basic Pack
        new Probability { Value = 0.3, Rarity = Card.rareté.Rare, BaseQty = 0, Id = 1, PackId = 1 },

        // Probabilités pour le Normal Pack
        new Probability { Value = 0.3, Rarity = Card.rareté.Rare, BaseQty = 1, Id = 2, PackId = 2 },
        new Probability { Value = 0.1, Rarity = Card.rareté.Épique, BaseQty = 0, Id = 3, PackId = 2 },
        new Probability { Value = 0.02, Rarity = Card.rareté.Légendaire, BaseQty = 0, Id = 4, PackId = 2 },

        // Probabilités pour le Super Pack
        new Probability { Value = 0.25, Rarity = Card.rareté.Épique, BaseQty = 1, Id = 5, PackId = 3 },
        new Probability { Value = 0.1, Rarity = Card.rareté.Légendaire, BaseQty = 0, Id = 6, PackId = 3 }

            };
        }
    }
}

