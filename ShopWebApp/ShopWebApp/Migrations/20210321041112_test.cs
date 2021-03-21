using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIE",
                columns: table => new
                {
                    CATEGORIEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORIENOM = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIE", x => x.CATEGORIEID);
                });

            migrationBuilder.CreateTable(
                name: "CIVILITE",
                columns: table => new
                {
                    CIVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ABREGE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    COMPLET = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIVILITE", x => x.CIVID);
                });

            migrationBuilder.CreateTable(
                name: "CMDETAT",
                columns: table => new
                {
                    CMDETATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMDETAT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMDETAT", x => x.CMDETATID);
                });

            migrationBuilder.CreateTable(
                name: "LIVRAISONETAT",
                columns: table => new
                {
                    LVRETATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LVRETAT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVRAISONETAT", x => x.LVRETATID);
                });

            migrationBuilder.CreateTable(
                name: "LIVRAISONTYPE",
                columns: table => new
                {
                    LVRTYPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LVRDESIGNATION = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LVRDELAI = table.Column<short>(type: "smallint", nullable: true),
                    LVRCOUT = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVRAISONTYPE", x => x.LVRTYPID);
                });

            migrationBuilder.CreateTable(
                name: "POLITIQUE",
                columns: table => new
                {
                    POLITIQUEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ECHANGE = table.Column<bool>(type: "bit", nullable: true),
                    REMBOURSEMENT = table.Column<bool>(type: "bit", nullable: true),
                    PLTQDESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POLITIQUE", x => x.POLITIQUEID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION",
                columns: table => new
                {
                    TRANSACTIONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TYPE = table.Column<short>(type: "smallint", nullable: true),
                    MODE = table.Column<short>(type: "smallint", nullable: true),
                    TRANSACTSTATUT = table.Column<short>(type: "smallint", nullable: true),
                    TRANSACTCREA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TRANSACTMODIF = table.Column<DateTime>(type: "datetime", nullable: true),
                    TRANSACTCONTENU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION", x => x.TRANSACTIONID);
                });

            migrationBuilder.CreateTable(
                name: "CATNAV",
                columns: table => new
                {
                    CATEGORIEID = table.Column<int>(type: "int", nullable: false),
                    CAT_PARENTID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATNAV", x => new { x.CATEGORIEID, x.CAT_PARENTID });
                    table.ForeignKey(
                        name: "FK_CATNAV_REGROUPER_CATEGORI1",
                        column: x => x.CATEGORIEID,
                        principalTable: "CATEGORIE",
                        principalColumn: "CATEGORIEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CATNAV_REGROUPER_CATEGORI2",
                        column: x => x.CAT_PARENTID,
                        principalTable: "CATEGORIE",
                        principalColumn: "CATEGORIEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOUTIQUECOMMANDE",
                columns: table => new
                {
                    BTQCMDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMDETATID = table.Column<int>(type: "int", nullable: false),
                    LITIGEID = table.Column<int>(type: "int", nullable: true),
                    CLTCMDID = table.Column<int>(type: "int", nullable: true),
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    BTQCMDDATECREA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BTQCMDDATEDEBUT = table.Column<DateTime>(type: "datetime", nullable: true),
                    BTQCMDDATEFIN = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOUTIQUECOMMANDE", x => x.BTQCMDID);
                    table.ForeignKey(
                        name: "FK_BOUTIQUE_COMPRENDR_CMDETAT",
                        column: x => x.CMDETATID,
                        principalTable: "CMDETAT",
                        principalColumn: "CMDETATID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BTQPOSTE",
                columns: table => new
                {
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    LOCALISATIONID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTQPOSTE", x => new { x.BTQID, x.LOCALISATIONID });
                });

            migrationBuilder.CreateTable(
                name: "ECHANGE",
                columns: table => new
                {
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    E_QUEST = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    E_REP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    E_QUESTDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    E_REPDATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECHANGE", x => new { x.PARTENAIREID, x.PRODID, x.BTQID });
                });

            migrationBuilder.CreateTable(
                name: "LOCALISATION",
                columns: table => new
                {
                    LOCALISATIONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    ADRESSE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RUE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NUM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VILLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CODEPOSTAL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PAYS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PR_NOM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCALISATION", x => x.LOCALISATIONID);
                });

            migrationBuilder.CreateTable(
                name: "LIVRAISON",
                columns: table => new
                {
                    LIVRAISONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LVRTYPID = table.Column<int>(type: "int", nullable: false),
                    LVRETATID = table.Column<int>(type: "int", nullable: false),
                    LOCALISATIONID = table.Column<int>(type: "int", nullable: false),
                    SUIVINUM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SUIVILIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DATEENVOI = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVRAISON", x => x.LIVRAISONID);
                    table.ForeignKey(
                        name: "FK_LIVRAISO_CARACTERI_LIVRAISO",
                        column: x => x.LVRETATID,
                        principalTable: "LIVRAISONETAT",
                        principalColumn: "LVRETATID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LIVRAISO_DEFINIR_LIVRAISO",
                        column: x => x.LVRTYPID,
                        principalTable: "LIVRAISONTYPE",
                        principalColumn: "LVRTYPID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LIVRAISO_DESTINER_LOCALISA",
                        column: x => x.LOCALISATIONID,
                        principalTable: "LOCALISATION",
                        principalColumn: "LOCALISATIONID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MEDIA",
                columns: table => new
                {
                    MEDIAID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODID = table.Column<int>(type: "int", nullable: true),
                    LITIGEID = table.Column<int>(type: "int", nullable: true),
                    BTQID = table.Column<int>(type: "int", nullable: true),
                    LIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IMAGE = table.Column<bool>(type: "bit", nullable: true),
                    VIDEO = table.Column<bool>(type: "bit", nullable: true),
                    HTML = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA", x => x.MEDIAID);
                });

            migrationBuilder.CreateTable(
                name: "OPINION",
                columns: table => new
                {
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    A_NOTE = table.Column<short>(type: "smallint", nullable: true),
                    A_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    A_TEXTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    A_REPONSE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    A_REPDATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPINION", x => new { x.PRODID, x.PARTENAIREID, x.BTQID });
                });

            migrationBuilder.CreateTable(
                name: "PRODUIT",
                columns: table => new
                {
                    PRODID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTQID = table.Column<int>(type: "int", nullable: false),
                    CATEGORIEID = table.Column<int>(type: "int", nullable: false),
                    LVRTYPID = table.Column<int>(type: "int", nullable: false),
                    PRIX = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    P_NOM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    P_DESCRIPTION_C = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    P_DESCRIPTION_L = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STOCK = table.Column<short>(type: "smallint", nullable: true),
                    DISPONIBILITE = table.Column<short>(type: "smallint", nullable: true),
                    RABAIS = table.Column<short>(type: "smallint", nullable: true),
                    PREPARATION = table.Column<short>(type: "smallint", nullable: true),
                    P_SEO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    P_META_KEYWORDS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    P_META_TITRE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PUBLIER = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUIT", x => x.PRODID);
                    table.ForeignKey(
                        name: "FK_PRODUIT_APPARTENI_CATEGORI",
                        column: x => x.CATEGORIEID,
                        principalTable: "CATEGORIE",
                        principalColumn: "CATEGORIEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUIT_AVOIR_LIVRAISO",
                        column: x => x.LVRTYPID,
                        principalTable: "LIVRAISONTYPE",
                        principalColumn: "LVRTYPID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BTQCMDDETAIL",
                columns: table => new
                {
                    BTQCMDID = table.Column<int>(type: "int", nullable: false),
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    LIVRAISONID = table.Column<int>(type: "int", nullable: false),
                    B_CMD_QTEPROD = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTQCMDDETAIL", x => new { x.BTQCMDID, x.PRODID, x.LIVRAISONID });
                    table.ForeignKey(
                        name: "FK_BTQCMDDE_COMPORTER_BOUTIQUE",
                        column: x => x.BTQCMDID,
                        principalTable: "BOUTIQUECOMMANDE",
                        principalColumn: "BTQCMDID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BTQCMDDE_COMPORTER_LIVRAISO",
                        column: x => x.LIVRAISONID,
                        principalTable: "LIVRAISON",
                        principalColumn: "LIVRAISONID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BTQCMDDE_COMPORTER_PRODUIT",
                        column: x => x.PRODID,
                        principalTable: "PRODUIT",
                        principalColumn: "PRODID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LITIGE",
                columns: table => new
                {
                    LITIGEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REMBOURSEMENTID = table.Column<int>(type: "int", nullable: true),
                    RETOURID = table.Column<int>(type: "int", nullable: true),
                    BTQCMDID = table.Column<int>(type: "int", nullable: false),
                    LTGMSG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LITIGE", x => x.LITIGEID);
                    table.ForeignKey(
                        name: "FK_LITIGE_ENGENDRER_BOUTIQUE",
                        column: x => x.BTQCMDID,
                        principalTable: "BOUTIQUECOMMANDE",
                        principalColumn: "BTQCMDID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REMBOURSEMENT",
                columns: table => new
                {
                    REMBOURSEMENTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LITIGEID = table.Column<int>(type: "int", nullable: false),
                    R_MONTANT = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REMBOURSEMENT", x => x.REMBOURSEMENTID);
                    table.ForeignKey(
                        name: "FK_REMBOURS_DONNER_LITIGE",
                        column: x => x.LITIGEID,
                        principalTable: "LITIGE",
                        principalColumn: "LITIGEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REMPLACEMENT",
                columns: table => new
                {
                    REMPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LITIGEID = table.Column<int>(type: "int", nullable: false),
                    R_SUIVINUM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    R_SUIVILIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REMPLACEMENT", x => x.REMPID);
                    table.ForeignKey(
                        name: "FK_REMPLACE_ENVOYER_LITIGE",
                        column: x => x.LITIGEID,
                        principalTable: "LITIGE",
                        principalColumn: "LITIGEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RTRANSACT",
                columns: table => new
                {
                    REMBOURSEMENTID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTIONID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RTRANSACT", x => new { x.REMBOURSEMENTID, x.TRANSACTIONID });
                    table.ForeignKey(
                        name: "FK_RTRANSAC_TRAQUER_REMBOURS",
                        column: x => x.REMBOURSEMENTID,
                        principalTable: "REMBOURSEMENT",
                        principalColumn: "REMBOURSEMENTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RTRANSAC_TRAQUER2_TRANSACT",
                        column: x => x.TRANSACTIONID,
                        principalTable: "TRANSACTION",
                        principalColumn: "TRANSACTIONID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IDENTIFICATION",
                columns: table => new
                {
                    IDENTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    CIVID = table.Column<int>(type: "int", nullable: false),
                    NOM = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    PRENOM = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TEL = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTIFICATION", x => x.IDENTID);
                    table.ForeignKey(
                        name: "FK_IDENTIFI_ETRE_CIVILITE",
                        column: x => x.CIVID,
                        principalTable: "CIVILITE",
                        principalColumn: "CIVID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLTCMDDETAIL",
                columns: table => new
                {
                    CLTCMDID = table.Column<int>(type: "int", nullable: false),
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    LIVRAISONID = table.Column<int>(type: "int", nullable: false),
                    C_CMD_QTEPROD = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLTCMDDETAIL", x => new { x.CLTCMDID, x.PRODID, x.LIVRAISONID });
                    table.ForeignKey(
                        name: "FK_CLTCMDDE_LISTER2_PRODUIT",
                        column: x => x.PRODID,
                        principalTable: "PRODUIT",
                        principalColumn: "PRODID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLTCMDDE_LISTER3_LIVRAISO",
                        column: x => x.LIVRAISONID,
                        principalTable: "LIVRAISON",
                        principalColumn: "LIVRAISONID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACTURE",
                columns: table => new
                {
                    FACTUREID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLTCMDID = table.Column<int>(type: "int", nullable: false),
                    FACTLIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURE", x => x.FACTUREID);
                });

            migrationBuilder.CreateTable(
                name: "PAIEMENT",
                columns: table => new
                {
                    PAIEMENTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MDPID = table.Column<int>(type: "int", nullable: false),
                    CLTCMDID = table.Column<int>(type: "int", nullable: false),
                    P_MONTANT = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAIEMENT", x => x.PAIEMENTID);
                });

            migrationBuilder.CreateTable(
                name: "PTRANSACT",
                columns: table => new
                {
                    PAIEMENTID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTIONID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTRANSACT", x => new { x.PAIEMENTID, x.TRANSACTIONID });
                    table.ForeignKey(
                        name: "FK_PTRANSAC_TRACER_PAIEMENT",
                        column: x => x.PAIEMENTID,
                        principalTable: "PAIEMENT",
                        principalColumn: "PAIEMENTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PTRANSAC_TRACER2_TRANSACT",
                        column: x => x.TRANSACTIONID,
                        principalTable: "TRANSACTION",
                        principalColumn: "TRANSACTIONID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTCOMMANDE",
                columns: table => new
                {
                    CLTCMDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    CMDETATID = table.Column<int>(type: "int", nullable: false),
                    PAIEMENTID = table.Column<int>(type: "int", nullable: true),
                    FACTUREID = table.Column<int>(type: "int", nullable: true),
                    CLTCMDDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLTCMDDATEDEBUT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLTCMDDATEFIN = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTCOMMANDE", x => x.CLTCMDID);
                    table.ForeignKey(
                        name: "FK_CLIENTCO_DETENIR_CMDETAT",
                        column: x => x.CMDETATID,
                        principalTable: "CMDETAT",
                        principalColumn: "CMDETATID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLIENTCO_GENERER2_FACTURE",
                        column: x => x.FACTUREID,
                        principalTable: "FACTURE",
                        principalColumn: "FACTUREID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLIENTCO_PRENDRE2_PAIEMENT",
                        column: x => x.PAIEMENTID,
                        principalTable: "PAIEMENT",
                        principalColumn: "PAIEMENTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PANIERDETAIL",
                columns: table => new
                {
                    PANIERID = table.Column<int>(type: "int", nullable: false),
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    P_QTEPROD = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANIERDETAIL", x => new { x.PANIERID, x.PRODID });
                    table.ForeignKey(
                        name: "FK_PANIERDE_CONTENIR2_PRODUIT",
                        column: x => x.PRODID,
                        principalTable: "PRODUIT",
                        principalColumn: "PRODID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARTENAIRE",
                columns: table => new
                {
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PANIERID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTENAIRE", x => x.PARTENAIREID);
                });

            migrationBuilder.CreateTable(
                name: "BOUTIQUE",
                columns: table => new
                {
                    BTQID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    POLITIQUEID = table.Column<int>(type: "int", nullable: false),
                    B_DESCRIPTION_C = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    B_DESCRIPTION_L = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RAISONSOCIALE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SIRET = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    SIREN = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    BTQTEL = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CODENAF = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CODEBANQUE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CODEGUICHET = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NUMCOMPTE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CLERIB = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DOMICILIATION = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: true),
                    BIC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TITULAIRE = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    BTQTMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BTQMESSAGE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CA = table.Column<int>(type: "int", nullable: true),
                    NBSALARIE = table.Column<int>(type: "int", nullable: true),
                    SITEWEB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    STATUTJURIDIQUE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BTQSEO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOUTIQUE", x => x.BTQID);
                    table.ForeignKey(
                        name: "FK_BOUTIQUE_APPLIQUER_POLITIQU",
                        column: x => x.POLITIQUEID,
                        principalTable: "POLITIQUE",
                        principalColumn: "POLITIQUEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOUTIQUE_CREER_PARTENAI",
                        column: x => x.PARTENAIREID,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOYENDEPAIEMENT",
                columns: table => new
                {
                    MDPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: false),
                    CB_NUM = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CVC = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DATEEXP = table.Column<DateTime>(type: "datetime", nullable: true),
                    CB_TITULAIRE = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    CB_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOYENDEPAIEMENT", x => x.MDPID);
                    table.ForeignKey(
                        name: "FK_MOYENDEP_UTILISER_PARTENAI",
                        column: x => x.PARTENAIREID,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PANIER",
                columns: table => new
                {
                    PANIERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTENAIREID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANIER", x => x.PANIERID);
                    table.ForeignKey(
                        name: "FK_PANIER_DISPOSER_PARTENAI",
                        column: x => x.PARTENAIREID,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    UserClaimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partenaireid = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.UserClaimID);
                    table.ForeignKey(
                        name: "FK_UserClaims_PARTENAIRE_Partenaireid",
                        column: x => x.Partenaireid,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserLoginID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partenaireid = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserLoginID);
                    table.ForeignKey(
                        name: "FK_UserLogins_PARTENAIRE_Partenaireid",
                        column: x => x.Partenaireid,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partenaireid = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_PARTENAIRE_Partenaireid",
                        column: x => x.Partenaireid,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserTokenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partenaireid = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserTokenID);
                    table.ForeignKey(
                        name: "FK_UserTokens_PARTENAIRE_Partenaireid",
                        column: x => x.Partenaireid,
                        principalTable: "PARTENAIRE",
                        principalColumn: "PARTENAIREID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "APPLIQUER_FK",
                table: "BOUTIQUE",
                column: "POLITIQUEID");

            migrationBuilder.CreateIndex(
                name: "CREER_FK",
                table: "BOUTIQUE",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "ASSOCIER_FK",
                table: "BOUTIQUECOMMANDE",
                column: "CLTCMDID");

            migrationBuilder.CreateIndex(
                name: "COMPRENDRE_FK",
                table: "BOUTIQUECOMMANDE",
                column: "CMDETATID");

            migrationBuilder.CreateIndex(
                name: "ENGENDRER2_FK",
                table: "BOUTIQUECOMMANDE",
                column: "LITIGEID");

            migrationBuilder.CreateIndex(
                name: "RECEVOIR_FK",
                table: "BOUTIQUECOMMANDE",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "COMPORTER_FK",
                table: "BTQCMDDETAIL",
                column: "BTQCMDID");

            migrationBuilder.CreateIndex(
                name: "COMPORTER2_FK",
                table: "BTQCMDDETAIL",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "COMPORTER3_FK",
                table: "BTQCMDDETAIL",
                column: "LIVRAISONID");

            migrationBuilder.CreateIndex(
                name: "PROPOSER_FK",
                table: "BTQPOSTE",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "PROPOSER2_FK",
                table: "BTQPOSTE",
                column: "LOCALISATIONID");

            migrationBuilder.CreateIndex(
                name: "REGROUPER2_FK",
                table: "CATNAV",
                column: "CATEGORIEID");

            migrationBuilder.CreateIndex(
                name: "REGROUPER3_FK",
                table: "CATNAV",
                column: "CAT_PARENTID");

            migrationBuilder.CreateIndex(
                name: "DETENIR_FK",
                table: "CLIENTCOMMANDE",
                column: "CMDETATID");

            migrationBuilder.CreateIndex(
                name: "GENERER2_FK",
                table: "CLIENTCOMMANDE",
                column: "FACTUREID");

            migrationBuilder.CreateIndex(
                name: "PASSER_FK",
                table: "CLIENTCOMMANDE",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "PRENDRE2_FK",
                table: "CLIENTCOMMANDE",
                column: "PAIEMENTID");

            migrationBuilder.CreateIndex(
                name: "LISTER_FK",
                table: "CLTCMDDETAIL",
                column: "CLTCMDID");

            migrationBuilder.CreateIndex(
                name: "LISTER2_FK",
                table: "CLTCMDDETAIL",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "LISTER3_FK",
                table: "CLTCMDDETAIL",
                column: "LIVRAISONID");

            migrationBuilder.CreateIndex(
                name: "ECHANGE_FK",
                table: "ECHANGE",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "ECHANGE2_FK",
                table: "ECHANGE",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "ECHANGE3_FK",
                table: "ECHANGE",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "GENERER_FK",
                table: "FACTURE",
                column: "CLTCMDID");

            migrationBuilder.CreateIndex(
                name: "ETRE_FK",
                table: "IDENTIFICATION",
                column: "CIVID");

            migrationBuilder.CreateIndex(
                name: "IDENTIFIER_FK",
                table: "IDENTIFICATION",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "DONNER2_FK",
                table: "LITIGE",
                column: "REMBOURSEMENTID");

            migrationBuilder.CreateIndex(
                name: "ENGENDRER_FK",
                table: "LITIGE",
                column: "BTQCMDID");

            migrationBuilder.CreateIndex(
                name: "ENVOYER2_FK",
                table: "LITIGE",
                column: "RETOURID");

            migrationBuilder.CreateIndex(
                name: "CARACTERISER_FK",
                table: "LIVRAISON",
                column: "LVRETATID");

            migrationBuilder.CreateIndex(
                name: "DEFINIR_FK",
                table: "LIVRAISON",
                column: "LVRTYPID");

            migrationBuilder.CreateIndex(
                name: "DESTINER_FK",
                table: "LIVRAISON",
                column: "LOCALISATIONID");

            migrationBuilder.CreateIndex(
                name: "POSSEDER_FK",
                table: "LOCALISATION",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "SITUER_FK",
                table: "LOCALISATION",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "BOUTMEDIA_FK",
                table: "MEDIA",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "LTGMEDIA_FK",
                table: "MEDIA",
                column: "LITIGEID");

            migrationBuilder.CreateIndex(
                name: "PRODMEDIA_FK",
                table: "MEDIA",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "UTILISER_FK",
                table: "MOYENDEPAIEMENT",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "AVIS_FK",
                table: "OPINION",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "AVIS2_FK",
                table: "OPINION",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "AVIS3_FK",
                table: "OPINION",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "PRENDRE_FK",
                table: "PAIEMENT",
                column: "CLTCMDID");

            migrationBuilder.CreateIndex(
                name: "REGLER_FK",
                table: "PAIEMENT",
                column: "MDPID");

            migrationBuilder.CreateIndex(
                name: "DISPOSER_FK",
                table: "PANIER",
                column: "PARTENAIREID");

            migrationBuilder.CreateIndex(
                name: "CONTENIR_FK",
                table: "PANIERDETAIL",
                column: "PANIERID");

            migrationBuilder.CreateIndex(
                name: "CONTENIR2_FK",
                table: "PANIERDETAIL",
                column: "PRODID");

            migrationBuilder.CreateIndex(
                name: "DISPOSER2_FK",
                table: "PARTENAIRE",
                column: "PANIERID");

            migrationBuilder.CreateIndex(
                name: "APPARTENIR_FK",
                table: "PRODUIT",
                column: "CATEGORIEID");

            migrationBuilder.CreateIndex(
                name: "AVOIR_FK",
                table: "PRODUIT",
                column: "LVRTYPID");

            migrationBuilder.CreateIndex(
                name: "VENDRE_FK",
                table: "PRODUIT",
                column: "BTQID");

            migrationBuilder.CreateIndex(
                name: "TRACER_FK",
                table: "PTRANSACT",
                column: "PAIEMENTID");

            migrationBuilder.CreateIndex(
                name: "TRACER2_FK",
                table: "PTRANSACT",
                column: "TRANSACTIONID");

            migrationBuilder.CreateIndex(
                name: "DONNER_FK",
                table: "REMBOURSEMENT",
                column: "LITIGEID");

            migrationBuilder.CreateIndex(
                name: "ENVOYER_FK",
                table: "REMPLACEMENT",
                column: "LITIGEID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "TRAQUER_FK",
                table: "RTRANSACT",
                column: "REMBOURSEMENTID");

            migrationBuilder.CreateIndex(
                name: "TRAQUER2_FK",
                table: "RTRANSACT",
                column: "TRANSACTIONID");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_Partenaireid",
                table: "UserClaims",
                column: "Partenaireid");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_Partenaireid",
                table: "UserLogins",
                column: "Partenaireid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Partenaireid",
                table: "UserRoles",
                column: "Partenaireid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_Partenaireid",
                table: "UserTokens",
                column: "Partenaireid");

            migrationBuilder.AddForeignKey(
                name: "FK_BOUTIQUE_ASSOCIER_CLIENTCO",
                table: "BOUTIQUECOMMANDE",
                column: "CLTCMDID",
                principalTable: "CLIENTCOMMANDE",
                principalColumn: "CLTCMDID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOUTIQUE_ENGENDRER_LITIGE",
                table: "BOUTIQUECOMMANDE",
                column: "LITIGEID",
                principalTable: "LITIGE",
                principalColumn: "LITIGEID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOUTIQUE_RECEVOIR_BOUTIQUE",
                table: "BOUTIQUECOMMANDE",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BTQPOSTE_PROPOSER_BOUTIQUE",
                table: "BTQPOSTE",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BTQPOSTE_PROPOSER2_LOCALISA",
                table: "BTQPOSTE",
                column: "LOCALISATIONID",
                principalTable: "LOCALISATION",
                principalColumn: "LOCALISATIONID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECHANGE_ECHANGE_PARTENAI",
                table: "ECHANGE",
                column: "PARTENAIREID",
                principalTable: "PARTENAIRE",
                principalColumn: "PARTENAIREID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECHANGE_ECHANGE2_PRODUIT",
                table: "ECHANGE",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECHANGE_ECHANGE3_BOUTIQUE",
                table: "ECHANGE",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOCALISA_POSSEDER_PARTENAI",
                table: "LOCALISATION",
                column: "PARTENAIREID",
                principalTable: "PARTENAIRE",
                principalColumn: "PARTENAIREID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOCALISA_SITUER_BOUTIQUE",
                table: "LOCALISATION",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MEDIA_BOUTMEDIA_BOUTIQUE",
                table: "MEDIA",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MEDIA_LTGMEDIA_LITIGE",
                table: "MEDIA",
                column: "LITIGEID",
                principalTable: "LITIGE",
                principalColumn: "LITIGEID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MEDIA_PRODMEDIA_PRODUIT",
                table: "MEDIA",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OPINION_AVIS_PRODUIT",
                table: "OPINION",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OPINION_AVIS2_PARTENAI",
                table: "OPINION",
                column: "PARTENAIREID",
                principalTable: "PARTENAIRE",
                principalColumn: "PARTENAIREID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OPINION_AVIS3_BOUTIQUE",
                table: "OPINION",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_VENDRE_BOUTIQUE",
                table: "PRODUIT",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LITIGE_DONNER2_REMBOURS",
                table: "LITIGE",
                column: "REMBOURSEMENTID",
                principalTable: "REMBOURSEMENT",
                principalColumn: "REMBOURSEMENTID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LITIGE_ENVOYER2_REMPLACE",
                table: "LITIGE",
                column: "RETOURID",
                principalTable: "REMPLACEMENT",
                principalColumn: "REMPID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IDENTIFI_IDENTIFIE_PARTENAI",
                table: "IDENTIFICATION",
                column: "PARTENAIREID",
                principalTable: "PARTENAIRE",
                principalColumn: "PARTENAIREID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CLTCMDDE_LISTER_CLIENTCO",
                table: "CLTCMDDETAIL",
                column: "CLTCMDID",
                principalTable: "CLIENTCOMMANDE",
                principalColumn: "CLTCMDID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FACTURE_GENERER_CLIENTCO",
                table: "FACTURE",
                column: "CLTCMDID",
                principalTable: "CLIENTCOMMANDE",
                principalColumn: "CLTCMDID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PAIEMENT_PRENDRE_CLIENTCO",
                table: "PAIEMENT",
                column: "CLTCMDID",
                principalTable: "CLIENTCOMMANDE",
                principalColumn: "CLTCMDID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PAIEMENT_REGLER_MOYENDEP",
                table: "PAIEMENT",
                column: "MDPID",
                principalTable: "MOYENDEPAIEMENT",
                principalColumn: "MDPID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTCO_PASSER_PARTENAI",
                table: "CLIENTCOMMANDE",
                column: "PARTENAIREID",
                principalTable: "PARTENAIRE",
                principalColumn: "PARTENAIREID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PANIERDE_CONTENIR_PANIER",
                table: "PANIERDETAIL",
                column: "PANIERID",
                principalTable: "PANIER",
                principalColumn: "PANIERID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PARTENAI_DISPOSER2_PANIER",
                table: "PARTENAIRE",
                column: "PANIERID",
                principalTable: "PANIER",
                principalColumn: "PANIERID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOUTIQUE_APPLIQUER_POLITIQU",
                table: "BOUTIQUE");

            migrationBuilder.DropForeignKey(
                name: "FK_BOUTIQUE_CREER_PARTENAI",
                table: "BOUTIQUE");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTCO_PASSER_PARTENAI",
                table: "CLIENTCOMMANDE");

            migrationBuilder.DropForeignKey(
                name: "FK_MOYENDEP_UTILISER_PARTENAI",
                table: "MOYENDEPAIEMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_PANIER_DISPOSER_PARTENAI",
                table: "PANIER");

            migrationBuilder.DropForeignKey(
                name: "FK_BOUTIQUE_ASSOCIER_CLIENTCO",
                table: "BOUTIQUECOMMANDE");

            migrationBuilder.DropForeignKey(
                name: "FK_FACTURE_GENERER_CLIENTCO",
                table: "FACTURE");

            migrationBuilder.DropForeignKey(
                name: "FK_PAIEMENT_PRENDRE_CLIENTCO",
                table: "PAIEMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_BOUTIQUE_COMPRENDR_CMDETAT",
                table: "BOUTIQUECOMMANDE");

            migrationBuilder.DropForeignKey(
                name: "FK_BOUTIQUE_ENGENDRER_LITIGE",
                table: "BOUTIQUECOMMANDE");

            migrationBuilder.DropForeignKey(
                name: "FK_REMBOURS_DONNER_LITIGE",
                table: "REMBOURSEMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_REMPLACE_ENVOYER_LITIGE",
                table: "REMPLACEMENT");

            migrationBuilder.DropTable(
                name: "BTQCMDDETAIL");

            migrationBuilder.DropTable(
                name: "BTQPOSTE");

            migrationBuilder.DropTable(
                name: "CATNAV");

            migrationBuilder.DropTable(
                name: "CLTCMDDETAIL");

            migrationBuilder.DropTable(
                name: "ECHANGE");

            migrationBuilder.DropTable(
                name: "IDENTIFICATION");

            migrationBuilder.DropTable(
                name: "MEDIA");

            migrationBuilder.DropTable(
                name: "OPINION");

            migrationBuilder.DropTable(
                name: "PANIERDETAIL");

            migrationBuilder.DropTable(
                name: "PTRANSACT");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RTRANSACT");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "LIVRAISON");

            migrationBuilder.DropTable(
                name: "CIVILITE");

            migrationBuilder.DropTable(
                name: "PRODUIT");

            migrationBuilder.DropTable(
                name: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "LIVRAISONETAT");

            migrationBuilder.DropTable(
                name: "LOCALISATION");

            migrationBuilder.DropTable(
                name: "CATEGORIE");

            migrationBuilder.DropTable(
                name: "LIVRAISONTYPE");

            migrationBuilder.DropTable(
                name: "POLITIQUE");

            migrationBuilder.DropTable(
                name: "PARTENAIRE");

            migrationBuilder.DropTable(
                name: "PANIER");

            migrationBuilder.DropTable(
                name: "CLIENTCOMMANDE");

            migrationBuilder.DropTable(
                name: "FACTURE");

            migrationBuilder.DropTable(
                name: "PAIEMENT");

            migrationBuilder.DropTable(
                name: "MOYENDEPAIEMENT");

            migrationBuilder.DropTable(
                name: "CMDETAT");

            migrationBuilder.DropTable(
                name: "LITIGE");

            migrationBuilder.DropTable(
                name: "REMBOURSEMENT");

            migrationBuilder.DropTable(
                name: "BOUTIQUECOMMANDE");

            migrationBuilder.DropTable(
                name: "REMPLACEMENT");

            migrationBuilder.DropTable(
                name: "BOUTIQUE");
        }
    }
}
