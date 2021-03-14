﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ArtShop.Models
{
    public partial class ARTSHOPContext : DbContext
    {
        public ARTSHOPContext()
        {
        }

        public ARTSHOPContext(DbContextOptions<ARTSHOPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Boutique> Boutiques { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Catnav> Catnavs { get; set; }
        public virtual DbSet<Civilite> Civilites { get; set; }
        public virtual DbSet<Cmdbtqdetail> Cmdbtqdetails { get; set; }
        public virtual DbSet<Cmdcltdetail> Cmdcltdetails { get; set; }
        public virtual DbSet<Commandeboutique> Commandeboutiques { get; set; }
        public virtual DbSet<Commandeclient> Commandeclients { get; set; }
        public virtual DbSet<Echange> Echanges { get; set; }
        public virtual DbSet<Etatcmd> Etatcmds { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Identification> Identifications { get; set; }
        public virtual DbSet<Litige> Litiges { get; set; }
        public virtual DbSet<Livraison> Livraisons { get; set; }
        public virtual DbSet<Livraisonetat> Livraisonetats { get; set; }
        public virtual DbSet<Livraisontype> Livraisontypes { get; set; }
        public virtual DbSet<Localisation> Localisations { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Moyendepaiement> Moyendepaiements { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<Pandetail> Pandetails { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Partenaire> Partenaires { get; set; }
        public virtual DbSet<Pointrelai> Pointrelais { get; set; }
        public virtual DbSet<Politique> Politiques { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Ptransact> Ptransacts { get; set; }
        public virtual DbSet<Remboursement> Remboursements { get; set; }
        public virtual DbSet<Remplacement> Remplacements { get; set; }
        public virtual DbSet<Rtransact> Rtransacts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.\\;Database=ARTSHOP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Avi>(entity =>
            {
                entity.HasKey(e => new { e.Prodid, e.Partenaireid, e.Btqid });

                entity.ToTable("AVIS");

                entity.HasIndex(e => e.Partenaireid, "AVIS2_FK");

                entity.HasIndex(e => e.Btqid, "AVIS3_FK");

                entity.HasIndex(e => e.Prodid, "AVIS_FK");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.ADate)
                    .HasColumnType("datetime")
                    .HasColumnName("A_DATE");

                entity.Property(e => e.ANote).HasColumnName("A_NOTE");

                entity.Property(e => e.ARepdate)
                    .HasColumnType("datetime")
                    .HasColumnName("A_REPDATE");

                entity.Property(e => e.AReponse)
                    .HasMaxLength(255)
                    .HasColumnName("A_REPONSE");

                entity.Property(e => e.ATexte)
                    .HasMaxLength(255)
                    .HasColumnName("A_TEXTE");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AVIS_AVIS3_BOUTIQUE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AVIS_AVIS2_PARTENAI");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AVIS_AVIS_PRODUIT");
            });

            modelBuilder.Entity<Boutique>(entity =>
            {
                entity.HasKey(e => e.Btqid);

                entity.ToTable("BOUTIQUE");

                entity.HasIndex(e => e.Politiqueid, "APPLIQUER_FK");

                entity.HasIndex(e => e.Partenaireid, "CREER_FK");

                entity.Property(e => e.Btqid)
                    .ValueGeneratedNever()
                    .HasColumnName("BTQID");

                entity.Property(e => e.BDescriptionC)
                    .HasMaxLength(100)
                    .HasColumnName("B_DESCRIPTION_C");

                entity.Property(e => e.BDescriptionL)
                    .HasMaxLength(255)
                    .HasColumnName("B_DESCRIPTION_L");

                entity.Property(e => e.Bic)
                    .HasMaxLength(11)
                    .HasColumnName("BIC");

                entity.Property(e => e.Btqmessage)
                    .HasMaxLength(255)
                    .HasColumnName("BTQMESSAGE");

                entity.Property(e => e.Btqseo)
                    .HasMaxLength(100)
                    .HasColumnName("BTQSEO");

                entity.Property(e => e.Btqtel)
                    .HasMaxLength(15)
                    .HasColumnName("BTQTEL");

                entity.Property(e => e.Btqtmail)
                    .HasMaxLength(255)
                    .HasColumnName("BTQTMAIL");

                entity.Property(e => e.Ca).HasColumnName("CA");

                entity.Property(e => e.Clerib)
                    .HasMaxLength(2)
                    .HasColumnName("CLERIB");

                entity.Property(e => e.Codebanque)
                    .HasMaxLength(5)
                    .HasColumnName("CODEBANQUE");

                entity.Property(e => e.Codeguichet)
                    .HasMaxLength(5)
                    .HasColumnName("CODEGUICHET");

                entity.Property(e => e.Codenaf)
                    .HasMaxLength(5)
                    .HasColumnName("CODENAF");

                entity.Property(e => e.Domiciliation)
                    .HasMaxLength(24)
                    .HasColumnName("DOMICILIATION");

                entity.Property(e => e.Iban)
                    .HasMaxLength(27)
                    .HasColumnName("IBAN");

                entity.Property(e => e.Nbsalarie).HasColumnName("NBSALARIE");

                entity.Property(e => e.Numcompte)
                    .HasMaxLength(11)
                    .HasColumnName("NUMCOMPTE");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.Property(e => e.Politiqueid).HasColumnName("POLITIQUEID");

                entity.Property(e => e.Raisonsociale)
                    .HasMaxLength(255)
                    .HasColumnName("RAISONSOCIALE");

                entity.Property(e => e.Siren)
                    .HasMaxLength(9)
                    .HasColumnName("SIREN");

                entity.Property(e => e.Siret)
                    .HasMaxLength(14)
                    .HasColumnName("SIRET");

                entity.Property(e => e.Siteweb)
                    .HasMaxLength(100)
                    .HasColumnName("SITEWEB");

                entity.Property(e => e.Statutjuridique)
                    .HasMaxLength(25)
                    .HasColumnName("STATUTJURIDIQUE");

                entity.Property(e => e.Titulaire)
                    .HasMaxLength(140)
                    .HasColumnName("TITULAIRE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Boutiques)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOUTIQUE_CREER_PARTENAI");

                entity.HasOne(d => d.Politique)
                    .WithMany(p => p.Boutiques)
                    .HasForeignKey(d => d.Politiqueid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOUTIQUE_APPLIQUER_POLITIQU");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("CATEGORIE");

                entity.Property(e => e.Categorieid)
                    .ValueGeneratedNever()
                    .HasColumnName("CATEGORIEID");

                entity.Property(e => e.Categorienom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIENOM");
            });

            modelBuilder.Entity<Catnav>(entity =>
            {
                entity.HasKey(e => new { e.Categorieid, e.CatParentid });

                entity.ToTable("CATNAV");

                entity.HasIndex(e => e.Categorieid, "REGROUPER2_FK");

                entity.HasIndex(e => e.CatParentid, "REGROUPER3_FK");

                entity.Property(e => e.Categorieid).HasColumnName("CATEGORIEID");

                entity.Property(e => e.CatParentid).HasColumnName("CAT_PARENTID");

                entity.HasOne(d => d.CatParent)
                    .WithMany(p => p.CatnavCatParents)
                    .HasForeignKey(d => d.CatParentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATNAV_REGROUPER2_CATEGORI");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.CatnavCategories)
                    .HasForeignKey(d => d.Categorieid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATNAV_REGROUPER1_CATEGORI");
            });

            modelBuilder.Entity<Civilite>(entity =>
            {
                entity.HasKey(e => e.Civid);

                entity.ToTable("CIVILITE");

                entity.Property(e => e.Civid)
                    .ValueGeneratedNever()
                    .HasColumnName("CIVID");

                entity.Property(e => e.Abrege)
                    .HasMaxLength(5)
                    .HasColumnName("ABREGE");

                entity.Property(e => e.Complet)
                    .HasMaxLength(15)
                    .HasColumnName("COMPLET");
            });

            modelBuilder.Entity<Cmdbtqdetail>(entity =>
            {
                entity.HasKey(e => new { e.Cmdbtqid, e.Prodid, e.Livraisonid });

                entity.ToTable("CMDBTQDETAIL");

                entity.HasIndex(e => e.Prodid, "COMPORTER2_FK");

                entity.HasIndex(e => e.Livraisonid, "COMPORTER3_FK");

                entity.HasIndex(e => e.Cmdbtqid, "COMPORTER_FK");

                entity.Property(e => e.Cmdbtqid).HasColumnName("CMDBTQID");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.Livraisonid).HasColumnName("LIVRAISONID");

                entity.Property(e => e.BCmdQteprod).HasColumnName("B_CMD_QTEPROD");

                entity.HasOne(d => d.Cmdbtq)
                    .WithMany(p => p.Cmdbtqdetails)
                    .HasForeignKey(d => d.Cmdbtqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDBTQDE_COMPORTER_COMMANDE");

                entity.HasOne(d => d.Livraison)
                    .WithMany(p => p.Cmdbtqdetails)
                    .HasForeignKey(d => d.Livraisonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDBTQDE_COMPORTER_LIVRAISO");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Cmdbtqdetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDBTQDE_COMPORTER_PRODUIT");
            });

            modelBuilder.Entity<Cmdcltdetail>(entity =>
            {
                entity.HasKey(e => new { e.Cmdcltid, e.Prodid, e.Livraisonid });

                entity.ToTable("CMDCLTDETAIL");

                entity.HasIndex(e => e.Prodid, "LISTER2_FK");

                entity.HasIndex(e => e.Livraisonid, "LISTER3_FK");

                entity.HasIndex(e => e.Cmdcltid, "LISTER_FK");

                entity.Property(e => e.Cmdcltid).HasColumnName("CMDCLTID");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.Livraisonid).HasColumnName("LIVRAISONID");

                entity.Property(e => e.CCmdQteprod).HasColumnName("C_CMD_QTEPROD");

                entity.HasOne(d => d.Cmdclt)
                    .WithMany(p => p.Cmdcltdetails)
                    .HasForeignKey(d => d.Cmdcltid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDCLTDE_LISTER_COMMANDE");

                entity.HasOne(d => d.Livraison)
                    .WithMany(p => p.Cmdcltdetails)
                    .HasForeignKey(d => d.Livraisonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDCLTDE_LISTER3_LIVRAISO");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Cmdcltdetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMDCLTDE_LISTER2_PRODUIT");
            });

            modelBuilder.Entity<Commandeboutique>(entity =>
            {
                entity.HasKey(e => e.Cmdbtqid);

                entity.ToTable("COMMANDEBOUTIQUE");

                entity.HasIndex(e => e.Cmdcltid, "ASSOCIER_FK");

                entity.HasIndex(e => e.Etatid, "COMPRENDRE_FK");

                entity.HasIndex(e => e.Litigeid, "ENGENDRER2_FK");

                entity.HasIndex(e => e.Btqid, "RECEVOIR_FK");

                entity.Property(e => e.Cmdbtqid)
                    .ValueGeneratedNever()
                    .HasColumnName("CMDBTQID");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.Cmdcltid).HasColumnName("CMDCLTID");

                entity.Property(e => e.Datecrea)
                    .HasColumnType("datetime")
                    .HasColumnName("DATECREA");

                entity.Property(e => e.Datedebut)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEDEBUT");

                entity.Property(e => e.Datefin)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEFIN");

                entity.Property(e => e.Etatid).HasColumnName("ETATID");

                entity.Property(e => e.Litigeid).HasColumnName("LITIGEID");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Commandeboutiques)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMANDE_RECEVOIR_BOUTIQUE");

                entity.HasOne(d => d.Cmdclt)
                    .WithMany(p => p.Commandeboutiques)
                    .HasForeignKey(d => d.Cmdcltid)
                    .HasConstraintName("FK_COMMANDE_ASSOCIER_COMMANDE");

                entity.HasOne(d => d.Etat)
                    .WithMany(p => p.Commandeboutiques)
                    .HasForeignKey(d => d.Etatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMANDE_COMPRENDR_ETATCMD");

                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Commandeboutiques)
                    .HasForeignKey(d => d.Litigeid)
                    .HasConstraintName("FK_COMMANDE_ENGENDRER_LITIGE");
            });

            modelBuilder.Entity<Commandeclient>(entity =>
            {
                entity.HasKey(e => e.Cmdcltid);

                entity.ToTable("COMMANDECLIENT");

                entity.HasIndex(e => e.Etatid, "DETENIR_FK");

                entity.HasIndex(e => e.Factureid, "GENERER2_FK");

                entity.HasIndex(e => e.Partenaireid, "PASSER_FK");

                entity.HasIndex(e => e.Paiementid, "PRENDRE2_FK");

                entity.Property(e => e.Cmdcltid)
                    .ValueGeneratedNever()
                    .HasColumnName("CMDCLTID");

                entity.Property(e => e.Cmdcltdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CMDCLTDATE");

                entity.Property(e => e.Cmdcltdatedebut)
                    .HasColumnType("datetime")
                    .HasColumnName("CMDCLTDATEDEBUT");

                entity.Property(e => e.Cmdcltdatefin)
                    .HasColumnType("datetime")
                    .HasColumnName("CMDCLTDATEFIN");

                entity.Property(e => e.Etatid).HasColumnName("ETATID");

                entity.Property(e => e.Factureid).HasColumnName("FACTUREID");

                entity.Property(e => e.Paiementid).HasColumnName("PAIEMENTID");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.HasOne(d => d.Etat)
                    .WithMany(p => p.Commandeclients)
                    .HasForeignKey(d => d.Etatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMANDE_DETENIR_ETATCMD");

                entity.HasOne(d => d.Facture)
                    .WithMany(p => p.Commandeclients)
                    .HasForeignKey(d => d.Factureid)
                    .HasConstraintName("FK_COMMANDE_GENERER2_FACTURE");

                entity.HasOne(d => d.Paiement)
                    .WithMany(p => p.Commandeclients)
                    .HasForeignKey(d => d.Paiementid)
                    .HasConstraintName("FK_COMMANDE_PRENDRE2_PAIEMENT");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Commandeclients)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMANDE_PASSER_PARTENAI");
            });

            modelBuilder.Entity<Echange>(entity =>
            {
                entity.HasKey(e => new { e.Partenaireid, e.Prodid, e.Btqid });

                entity.ToTable("ECHANGE");

                entity.HasIndex(e => e.Prodid, "ECHANGE2_FK");

                entity.HasIndex(e => e.Btqid, "ECHANGE3_FK");

                entity.HasIndex(e => e.Partenaireid, "ECHANGE_FK");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.EQuest)
                    .HasMaxLength(255)
                    .HasColumnName("E_QUEST");

                entity.Property(e => e.EQuestdate)
                    .HasColumnType("datetime")
                    .HasColumnName("E_QUESTDATE");

                entity.Property(e => e.ERep)
                    .HasMaxLength(255)
                    .HasColumnName("E_REP");

                entity.Property(e => e.ERepdate)
                    .HasColumnType("datetime")
                    .HasColumnName("E_REPDATE");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Echanges)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECHANGE_ECHANGE3_BOUTIQUE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Echanges)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECHANGE_ECHANGE_PARTENAI");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Echanges)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECHANGE_ECHANGE2_PRODUIT");
            });

            modelBuilder.Entity<Etatcmd>(entity =>
            {
                entity.HasKey(e => e.Etatid);

                entity.ToTable("ETATCMD");

                entity.Property(e => e.Etatid)
                    .ValueGeneratedNever()
                    .HasColumnName("ETATID");

                entity.Property(e => e.Etatcmd1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ETATCMD");
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.ToTable("FACTURE");

                entity.HasIndex(e => e.Cmdcltid, "GENERER_FK");

                entity.Property(e => e.Factureid)
                    .ValueGeneratedNever()
                    .HasColumnName("FACTUREID");

                entity.Property(e => e.Cmdcltid).HasColumnName("CMDCLTID");

                entity.Property(e => e.Factlien)
                    .HasMaxLength(255)
                    .HasColumnName("FACTLIEN");

                entity.HasOne(d => d.Cmdclt)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.Cmdcltid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTURE_GENERER_COMMANDE");
            });

            modelBuilder.Entity<Identification>(entity =>
            {
                entity.HasKey(e => e.Identid);

                entity.ToTable("IDENTIFICATION");

                entity.HasIndex(e => e.Civid, "ETRE_FK");

                entity.HasIndex(e => e.Partenaireid, "IDENTIFIER_FK");

                entity.Property(e => e.Identid)
                    .ValueGeneratedNever()
                    .HasColumnName("IDENTID");

                entity.Property(e => e.Civid).HasColumnName("CIVID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Nom)
                    .HasMaxLength(70)
                    .HasColumnName("NOM");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(70)
                    .HasColumnName("PRENOM");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .HasColumnName("TEL");

                entity.HasOne(d => d.Civ)
                    .WithMany(p => p.Identifications)
                    .HasForeignKey(d => d.Civid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDENTIFI_ETRE_CIVILITE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Identifications)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDENTIFI_IDENTIFIE_PARTENAI");
            });

            modelBuilder.Entity<Litige>(entity =>
            {
                entity.ToTable("LITIGE");

                entity.HasIndex(e => e.Remboursementid, "DONNER2_FK");

                entity.HasIndex(e => e.Cmdbtqid, "ENGENDRER_FK");

                entity.HasIndex(e => e.Retourid, "ENVOYER2_FK");

                entity.Property(e => e.Litigeid)
                    .ValueGeneratedNever()
                    .HasColumnName("LITIGEID");

                entity.Property(e => e.Cmdbtqid).HasColumnName("CMDBTQID");

                entity.Property(e => e.Ltgmsg)
                    .HasMaxLength(255)
                    .HasColumnName("LTGMSG");

                entity.Property(e => e.Remboursementid).HasColumnName("REMBOURSEMENTID");

                entity.Property(e => e.Retourid).HasColumnName("RETOURID");

                entity.HasOne(d => d.Cmdbtq)
                    .WithMany(p => p.Litiges)
                    .HasForeignKey(d => d.Cmdbtqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LITIGE_ENGENDRER_COMMANDE");

                entity.HasOne(d => d.Remboursement)
                    .WithMany(p => p.Litiges)
                    .HasForeignKey(d => d.Remboursementid)
                    .HasConstraintName("FK_LITIGE_DONNER2_REMBOURS");

                entity.HasOne(d => d.Retour)
                    .WithMany(p => p.Litiges)
                    .HasForeignKey(d => d.Retourid)
                    .HasConstraintName("FK_LITIGE_ENVOYER2_REMPLACE");
            });

            modelBuilder.Entity<Livraison>(entity =>
            {
                entity.ToTable("LIVRAISON");

                entity.HasIndex(e => e.Lvretatid, "CARACTERISER_FK");

                entity.HasIndex(e => e.Lvrtypid, "DEFINIR_FK");

                entity.HasIndex(e => e.Localisationid, "DESTINER_FK");

                entity.Property(e => e.Livraisonid)
                    .ValueGeneratedNever()
                    .HasColumnName("LIVRAISONID");

                entity.Property(e => e.Dateenvoi)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEENVOI");

                entity.Property(e => e.Localisationid).HasColumnName("LOCALISATIONID");

                entity.Property(e => e.Lvretatid).HasColumnName("LVRETATID");

                entity.Property(e => e.Lvrtypid).HasColumnName("LVRTYPID");

                entity.Property(e => e.Suivilien)
                    .HasMaxLength(255)
                    .HasColumnName("SUIVILIEN");

                entity.Property(e => e.Suivinum)
                    .HasMaxLength(255)
                    .HasColumnName("SUIVINUM");

                entity.HasOne(d => d.Localisation)
                    .WithMany(p => p.Livraisons)
                    .HasForeignKey(d => d.Localisationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIVRAISO_DESTINER_LOCALISA");

                entity.HasOne(d => d.Lvretat)
                    .WithMany(p => p.Livraisons)
                    .HasForeignKey(d => d.Lvretatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIVRAISO_CARACTERI_LIVRAISO");

                entity.HasOne(d => d.Lvrtyp)
                    .WithMany(p => p.Livraisons)
                    .HasForeignKey(d => d.Lvrtypid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIVRAISO_DEFINIR_LIVRAISO");
            });

            modelBuilder.Entity<Livraisonetat>(entity =>
            {
                entity.HasKey(e => e.Lvretatid);

                entity.ToTable("LIVRAISONETAT");

                entity.Property(e => e.Lvretatid)
                    .ValueGeneratedNever()
                    .HasColumnName("LVRETATID");

                entity.Property(e => e.Lvretat)
                    .HasMaxLength(15)
                    .HasColumnName("LVRETAT");
            });

            modelBuilder.Entity<Livraisontype>(entity =>
            {
                entity.HasKey(e => e.Lvrtypid);

                entity.ToTable("LIVRAISONTYPE");

                entity.Property(e => e.Lvrtypid)
                    .ValueGeneratedNever()
                    .HasColumnName("LVRTYPID");

                entity.Property(e => e.Lvrcout)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("LVRCOUT");

                entity.Property(e => e.Lvrdelai).HasColumnName("LVRDELAI");

                entity.Property(e => e.Lvrdesignation)
                    .HasMaxLength(15)
                    .HasColumnName("LVRDESIGNATION");
            });

            modelBuilder.Entity<Localisation>(entity =>
            {
                entity.ToTable("LOCALISATION");

                entity.HasIndex(e => e.Partenaireid, "POSSEDER_FK");

                entity.HasIndex(e => e.Btqid, "SITUER_FK");

                entity.Property(e => e.Localisationid)
                    .ValueGeneratedNever()
                    .HasColumnName("LOCALISATIONID");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(255)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.Codepostal)
                    .HasMaxLength(255)
                    .HasColumnName("CODEPOSTAL");

                entity.Property(e => e.Num)
                    .HasMaxLength(255)
                    .HasColumnName("NUM");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.Property(e => e.Pays)
                    .HasMaxLength(255)
                    .HasColumnName("PAYS");

                entity.Property(e => e.PrNom)
                    .HasMaxLength(255)
                    .HasColumnName("PR_NOM");

                entity.Property(e => e.Rue)
                    .HasMaxLength(255)
                    .HasColumnName("RUE");

                entity.Property(e => e.Ville)
                    .HasMaxLength(255)
                    .HasColumnName("VILLE");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Localisations)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCALISA_SITUER_BOUTIQUE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Localisations)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCALISA_POSSEDER_PARTENAI");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.Mediaid);

                entity.ToTable("MEDIA");

                entity.HasIndex(e => e.Btqid, "BOUTMEDIA_FK");

                entity.HasIndex(e => e.Litigeid, "LTGMEDIA_FK");

                entity.HasIndex(e => e.Prodid, "PRODMEDIA_FK");

                entity.Property(e => e.Mediaid)
                    .ValueGeneratedNever()
                    .HasColumnName("MEDIAID");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Html)
                    .HasMaxLength(255)
                    .HasColumnName("HTML");

                entity.Property(e => e.Image).HasColumnName("IMAGE");

                entity.Property(e => e.Lien)
                    .HasMaxLength(255)
                    .HasColumnName("LIEN");

                entity.Property(e => e.Litigeid).HasColumnName("LITIGEID");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.Video).HasColumnName("VIDEO");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Btqid)
                    .HasConstraintName("FK_MEDIA_BOUTMEDIA_BOUTIQUE");

                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Litigeid)
                    .HasConstraintName("FK_MEDIA_LTGMEDIA_LITIGE");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Prodid)
                    .HasConstraintName("FK_MEDIA_PRODMEDIA_PRODUIT");
            });

            modelBuilder.Entity<Moyendepaiement>(entity =>
            {
                entity.HasKey(e => e.Mdpid);

                entity.ToTable("MOYENDEPAIEMENT");

                entity.HasIndex(e => e.Partenaireid, "UTILISER_FK");

                entity.Property(e => e.Mdpid)
                    .ValueGeneratedNever()
                    .HasColumnName("MDPID");

                entity.Property(e => e.CbNum)
                    .HasMaxLength(16)
                    .HasColumnName("CB_NUM");

                entity.Property(e => e.CbTitulaire)
                    .HasMaxLength(140)
                    .HasColumnName("CB_TITULAIRE");

                entity.Property(e => e.CbType)
                    .HasMaxLength(30)
                    .HasColumnName("CB_TYPE");

                entity.Property(e => e.Cvc)
                    .HasMaxLength(4)
                    .HasColumnName("CVC");

                entity.Property(e => e.Dateexp)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEEXP");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Moyendepaiements)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOYENDEP_UTILISER_PARTENAI");
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.ToTable("PAIEMENT");

                entity.HasIndex(e => e.Cmdcltid, "PRENDRE_FK");

                entity.HasIndex(e => e.Mdpid, "REGLER_FK");

                entity.Property(e => e.Paiementid)
                    .ValueGeneratedNever()
                    .HasColumnName("PAIEMENTID");

                entity.Property(e => e.Cmdcltid).HasColumnName("CMDCLTID");

                entity.Property(e => e.Mdpid).HasColumnName("MDPID");

                entity.Property(e => e.PMontant)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("P_MONTANT");

                entity.HasOne(d => d.Cmdclt)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.Cmdcltid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIEMENT_PRENDRE_COMMANDE");

                entity.HasOne(d => d.Mdp)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.Mdpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIEMENT_REGLER_MOYENDEP");
            });

            modelBuilder.Entity<Pandetail>(entity =>
            {
                entity.HasKey(e => new { e.Panierid, e.Prodid });

                entity.ToTable("PANDETAIL");

                entity.HasIndex(e => e.Prodid, "CONTENIR2_FK");

                entity.HasIndex(e => e.Panierid, "CONTENIR_FK");

                entity.Property(e => e.Panierid).HasColumnName("PANIERID");

                entity.Property(e => e.Prodid).HasColumnName("PRODID");

                entity.Property(e => e.PQteprod).HasColumnName("P_QTEPROD");

                entity.HasOne(d => d.Panier)
                    .WithMany(p => p.Pandetails)
                    .HasForeignKey(d => d.Panierid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PANDETAI_CONTENIR_PANIER");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Pandetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PANDETAI_CONTENIR2_PRODUIT");
            });

            modelBuilder.Entity<Panier>(entity =>
            {
                entity.ToTable("PANIER");

                entity.HasIndex(e => e.Partenaireid, "DISPOSER_FK");

                entity.Property(e => e.Panierid)
                    .ValueGeneratedNever()
                    .HasColumnName("PANIERID");

                entity.Property(e => e.Partenaireid).HasColumnName("PARTENAIREID");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Paniers)
                    .HasForeignKey(d => d.Partenaireid)
                    .HasConstraintName("FK_PANIER_DISPOSER_PARTENAI");
            });

            modelBuilder.Entity<Partenaire>(entity =>
            {
                entity.ToTable("PARTENAIRE");

                entity.HasIndex(e => e.Panierid, "DISPOSER2_FK");

                entity.Property(e => e.Partenaireid)
                    .ValueGeneratedNever()
                    .HasColumnName("PARTENAIREID");

                entity.Property(e => e.Admin).HasColumnName("ADMIN");

                entity.Property(e => e.Datecon)
                    .HasColumnType("datetime")
                    .HasColumnName("DATECON");

                entity.Property(e => e.Dateenr)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEENR");

                entity.Property(e => e.Panierid).HasColumnName("PANIERID");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Vendeur).HasColumnName("VENDEUR");

                entity.HasOne(d => d.Panier)
                    .WithMany(p => p.Partenaires)
                    .HasForeignKey(d => d.Panierid)
                    .HasConstraintName("FK_PARTENAI_DISPOSER2_PANIER");
            });

            modelBuilder.Entity<Pointrelai>(entity =>
            {
                entity.HasKey(e => new { e.Btqid, e.Localisationid });

                entity.ToTable("POINTRELAIS");

                entity.HasIndex(e => e.Localisationid, "PROPOSER2_FK");

                entity.HasIndex(e => e.Btqid, "PROPOSER_FK");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.Localisationid).HasColumnName("LOCALISATIONID");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Pointrelais)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POINTREL_PROPOSER_BOUTIQUE");

                entity.HasOne(d => d.Localisation)
                    .WithMany(p => p.Pointrelais)
                    .HasForeignKey(d => d.Localisationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POINTREL_PROPOSER2_LOCALISA");
            });

            modelBuilder.Entity<Politique>(entity =>
            {
                entity.ToTable("POLITIQUE");

                entity.Property(e => e.Politiqueid)
                    .ValueGeneratedNever()
                    .HasColumnName("POLITIQUEID");

                entity.Property(e => e.Echange).HasColumnName("ECHANGE");

                entity.Property(e => e.Pltqdescription)
                    .HasMaxLength(255)
                    .HasColumnName("PLTQDESCRIPTION");

                entity.Property(e => e.Remboursement).HasColumnName("REMBOURSEMENT");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Prodid);

                entity.ToTable("PRODUIT");

                entity.HasIndex(e => e.Categorieid, "APPARTENIR_FK");

                entity.HasIndex(e => e.Lvrtypid, "AVOIR_FK");

                entity.HasIndex(e => e.Btqid, "VENDRE_FK");

                entity.Property(e => e.Prodid)
                    .ValueGeneratedNever()
                    .HasColumnName("PRODID");

                entity.Property(e => e.Btqid).HasColumnName("BTQID");

                entity.Property(e => e.Categorieid).HasColumnName("CATEGORIEID");

                entity.Property(e => e.Disponibilite).HasColumnName("DISPONIBILITE");

                entity.Property(e => e.Lvrtypid).HasColumnName("LVRTYPID");

                entity.Property(e => e.PDescriptionC)
                    .HasMaxLength(100)
                    .HasColumnName("P_DESCRIPTION_C");

                entity.Property(e => e.PDescriptionL)
                    .HasMaxLength(255)
                    .HasColumnName("P_DESCRIPTION_L");

                entity.Property(e => e.PMetaKeywords)
                    .HasMaxLength(100)
                    .HasColumnName("P_META_KEYWORDS");

                entity.Property(e => e.PMetaTitre)
                    .HasMaxLength(100)
                    .HasColumnName("P_META_TITRE");

                entity.Property(e => e.PNom)
                    .HasMaxLength(20)
                    .HasColumnName("P_NOM");

                entity.Property(e => e.PSeo)
                    .HasMaxLength(100)
                    .HasColumnName("P_SEO");

                entity.Property(e => e.Preparation).HasColumnName("PREPARATION");

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PRIX");

                entity.Property(e => e.Publier).HasColumnName("PUBLIER");

                entity.Property(e => e.Rabais).HasColumnName("RABAIS");

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUIT_VENDRE_BOUTIQUE");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.Categorieid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUIT_APPARTENI_CATEGORI");

                entity.HasOne(d => d.Lvrtyp)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.Lvrtypid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUIT_AVOIR_LIVRAISO");
            });

            modelBuilder.Entity<Ptransact>(entity =>
            {
                entity.HasKey(e => new { e.Paiementid, e.Transactionid });

                entity.ToTable("PTRANSACT");

                entity.HasIndex(e => e.Transactionid, "TRACER2_FK");

                entity.HasIndex(e => e.Paiementid, "TRACER_FK");

                entity.Property(e => e.Paiementid).HasColumnName("PAIEMENTID");

                entity.Property(e => e.Transactionid).HasColumnName("TRANSACTIONID");

                entity.HasOne(d => d.Paiement)
                    .WithMany(p => p.Ptransacts)
                    .HasForeignKey(d => d.Paiementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PTRANSAC_TRACER_PAIEMENT");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Ptransacts)
                    .HasForeignKey(d => d.Transactionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PTRANSAC_TRACER2_TRANSACT");
            });

            modelBuilder.Entity<Remboursement>(entity =>
            {
                entity.ToTable("REMBOURSEMENT");

                entity.HasIndex(e => e.Litigeid, "DONNER_FK");

                entity.Property(e => e.Remboursementid)
                    .ValueGeneratedNever()
                    .HasColumnName("REMBOURSEMENTID");

                entity.Property(e => e.Litigeid).HasColumnName("LITIGEID");

                entity.Property(e => e.RMontant)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("R_MONTANT");

                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Remboursements)
                    .HasForeignKey(d => d.Litigeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REMBOURS_DONNER_LITIGE");
            });

            modelBuilder.Entity<Remplacement>(entity =>
            {
                entity.HasKey(e => e.Retourid);

                entity.ToTable("REMPLACEMENT");

                entity.HasIndex(e => e.Litigeid, "ENVOYER_FK");

                entity.Property(e => e.Retourid)
                    .ValueGeneratedNever()
                    .HasColumnName("RETOURID");

                entity.Property(e => e.Litigeid).HasColumnName("LITIGEID");

                entity.Property(e => e.RSuivilien)
                    .HasMaxLength(255)
                    .HasColumnName("R_SUIVILIEN");

                entity.Property(e => e.RSuivinum)
                    .HasMaxLength(255)
                    .HasColumnName("R_SUIVINUM");

                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Remplacements)
                    .HasForeignKey(d => d.Litigeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REMPLACE_ENVOYER_LITIGE");
            });

            modelBuilder.Entity<Rtransact>(entity =>
            {
                entity.HasKey(e => new { e.Remboursementid, e.Transactionid });

                entity.ToTable("RTRANSACT");

                entity.HasIndex(e => e.Transactionid, "TRAQUER2_FK");

                entity.HasIndex(e => e.Remboursementid, "TRAQUER_FK");

                entity.Property(e => e.Remboursementid).HasColumnName("REMBOURSEMENTID");

                entity.Property(e => e.Transactionid).HasColumnName("TRANSACTIONID");

                entity.HasOne(d => d.Remboursement)
                    .WithMany(p => p.Rtransacts)
                    .HasForeignKey(d => d.Remboursementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RTRANSAC_TRAQUER_REMBOURS");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Rtransacts)
                    .HasForeignKey(d => d.Transactionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RTRANSAC_TRAQUER2_TRANSACT");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("TRANSACTION");

                entity.Property(e => e.Transactionid)
                    .ValueGeneratedNever()
                    .HasColumnName("TRANSACTIONID");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("CODE");

                entity.Property(e => e.Mode).HasColumnName("MODE");

                entity.Property(e => e.Transactcontenu)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSACTCONTENU");

                entity.Property(e => e.Transactcrea)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTCREA");

                entity.Property(e => e.Transactmodif)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTMODIF");

                entity.Property(e => e.Transactstatut).HasColumnName("TRANSACTSTATUT");

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
