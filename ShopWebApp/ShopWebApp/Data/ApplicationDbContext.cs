using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<Partenaire, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                opsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<ApplicationDbContext> opsBuilder { get; set; }
            public DbContextOptions<ApplicationDbContext> dbOptions { get; set; }
            public AppConfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Boutique> Boutiques { get; set; }
        public virtual DbSet<Boutiquecommande> Boutiquecommandes { get; set; }
        public virtual DbSet<Btqcmddetail> Btqcmddetails { get; set; }
        public virtual DbSet<Btqposte> Btqpostes { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Catnav> Catnavs { get; set; }
        public virtual DbSet<Civilite> Civilites { get; set; }
        public virtual DbSet<Clientcommande> Clientcommandes { get; set; }
        public virtual DbSet<Cltcmddetail> Cltcmddetails { get; set; }
        public virtual DbSet<Cmdetat> Cmdetats { get; set; }
        public virtual DbSet<Echange> Echanges { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Identification> Identifications { get; set; }
        public virtual DbSet<Litige> Litiges { get; set; }
        public virtual DbSet<Livraison> Livraisons { get; set; }
        public virtual DbSet<Livraisonetat> Livraisonetats { get; set; }
        public virtual DbSet<Livraisontype> Livraisontypes { get; set; }
        public virtual DbSet<Localisation> Localisations { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Moyendepaiement> Moyendepaiements { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Panierdetail> Panierdetails { get; set; }
        public virtual DbSet<Partenaire> Partenaires { get; set; }
        public virtual DbSet<Politique> Politiques { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Ptransact> Ptransacts { get; set; }
        public virtual DbSet<Remboursement> Remboursements { get; set; }
        public virtual DbSet<Remplacement> Remplacements { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<Rtransact> Rtransacts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        //public virtual DbSet<UserClaim> UserClaims { get; set; }
        //public virtual DbSet<UserLogin> UserLogins { get; set; }
        //public virtual DbSet<UserRole> UserRoles { get; set; }
        //public virtual DbSet<UserToken> UserTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\;Database=ARTSHOP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

                
            modelBuilder.Entity<Partenaire>(b =>
            {
                
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.Partenaire)
                    .HasForeignKey(uc => uc.Partenaireid)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.Partenaire)
                    .HasForeignKey(ul => ul.Partenaireid)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.Partenaire)
                    .HasForeignKey(ut => ut.Partenaireid)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Partenaire)
                    .HasForeignKey(ur => ur.Partenaireid)
                    .IsRequired();

            });

            modelBuilder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
            ///////////////////////////////////////////
            modelBuilder.Entity<Boutique>(entity =>
            {
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

            modelBuilder.Entity<Boutiquecommande>(entity =>
            {
                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Boutiquecommandes)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOUTIQUE_RECEVOIR_BOUTIQUE");

                entity.HasOne(d => d.Cltcmd)
                    .WithMany(p => p.Boutiquecommandes)
                    .HasForeignKey(d => d.Cltcmdid)
                    .HasConstraintName("FK_BOUTIQUE_ASSOCIER_CLIENTCO");

                entity.HasOne(d => d.Cmdetat)
                    .WithMany(p => p.Boutiquecommandes)
                    .HasForeignKey(d => d.Cmdetatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOUTIQUE_COMPRENDR_CMDETAT");

                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Boutiquecommandes)
                    .HasForeignKey(d => d.Litigeid)
                    .HasConstraintName("FK_BOUTIQUE_ENGENDRER_LITIGE");
            });

            modelBuilder.Entity<Btqcmddetail>(entity =>
            {
                entity.HasKey(e => new { e.Btqcmdid, e.Prodid, e.Livraisonid });

                entity.HasOne(d => d.Btqcmd)
                    .WithMany(p => p.Btqcmddetails)
                    .HasForeignKey(d => d.Btqcmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BTQCMDDE_COMPORTER_BOUTIQUE");

                entity.HasOne(d => d.Livraison)
                    .WithMany(p => p.Btqcmddetails)
                    .HasForeignKey(d => d.Livraisonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BTQCMDDE_COMPORTER_LIVRAISO");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Btqcmddetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BTQCMDDE_COMPORTER_PRODUIT");
            });

            modelBuilder.Entity<Btqposte>(entity =>
            {
                entity.HasKey(e => new { e.Btqid, e.Localisationid });

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Btqpostes)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BTQPOSTE_PROPOSER_BOUTIQUE");

                entity.HasOne(d => d.Localisation)
                    .WithMany(p => p.Btqpostes)
                    .HasForeignKey(d => d.Localisationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BTQPOSTE_PROPOSER2_LOCALISA");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.Property(e => e.Categorienom).IsUnicode(false);
            });

            modelBuilder.Entity<Catnav>(entity =>
            {
                entity.HasKey(e => new { e.Categorieid, e.CatParentid });

                entity.HasOne(d => d.CatParent)
                    .WithMany(p => p.CatnavCatParents)
                    .HasForeignKey(d => d.CatParentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATNAV_REGROUPER_CATEGORI2");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.CatnavCategories)
                    .HasForeignKey(d => d.Categorieid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATNAV_REGROUPER_CATEGORI1");
            });

            modelBuilder.Entity<Clientcommande>(entity =>
            {
                entity.HasOne(d => d.Cmdetat)
                    .WithMany(p => p.Clientcommandes)
                    .HasForeignKey(d => d.Cmdetatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTCO_DETENIR_CMDETAT");

                entity.HasOne(d => d.Facture)
                    .WithMany(p => p.Clientcommandes)
                    .HasForeignKey(d => d.Factureid)
                    .HasConstraintName("FK_CLIENTCO_GENERER2_FACTURE");

                entity.HasOne(d => d.Paiement)
                    .WithMany(p => p.Clientcommandes)
                    .HasForeignKey(d => d.Paiementid)
                    .HasConstraintName("FK_CLIENTCO_PRENDRE2_PAIEMENT");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Clientcommandes)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTCO_PASSER_PARTENAI");
            });

            modelBuilder.Entity<Cltcmddetail>(entity =>
            {
                entity.HasKey(e => new { e.Cltcmdid, e.Prodid, e.Livraisonid });

                entity.HasOne(d => d.Cltcmd)
                    .WithMany(p => p.Cltcmddetails)
                    .HasForeignKey(d => d.Cltcmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLTCMDDE_LISTER_CLIENTCO");

                entity.HasOne(d => d.Livraison)
                    .WithMany(p => p.Cltcmddetails)
                    .HasForeignKey(d => d.Livraisonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLTCMDDE_LISTER3_LIVRAISO");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Cltcmddetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLTCMDDE_LISTER2_PRODUIT");
            });

            modelBuilder.Entity<Cmdetat>(entity =>
            {
                entity.Property(e => e.Cmdetat1).IsUnicode(false);
            });

            modelBuilder.Entity<Echange>(entity =>
            {
                entity.HasKey(e => new { e.Partenaireid, e.Prodid, e.Btqid });

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

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasOne(d => d.Cltcmd)
                    .WithMany(p => p.Factures)
                    .HasForeignKey(d => d.Cltcmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTURE_GENERER_CLIENTCO");
            });

            modelBuilder.Entity<Identification>(entity =>
            {
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
                entity.HasOne(d => d.Btqcmd)
                    .WithMany(p => p.Litiges)
                    .HasForeignKey(d => d.Btqcmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LITIGE_ENGENDRER_BOUTIQUE");

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

            modelBuilder.Entity<Localisation>(entity =>
            {
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
                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Moyendepaiements)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOYENDEP_UTILISER_PARTENAI");
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.HasKey(e => new { e.Prodid, e.Partenaireid, e.Btqid });

                entity.HasOne(d => d.Btq)
                    .WithMany(p => p.Opinions)
                    .HasForeignKey(d => d.Btqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPINION_AVIS3_BOUTIQUE");

                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Opinions)
                    .HasForeignKey(d => d.Partenaireid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPINION_AVIS2_PARTENAI");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Opinions)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPINION_AVIS_PRODUIT");
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.HasOne(d => d.Cltcmd)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.Cltcmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIEMENT_PRENDRE_CLIENTCO");

                entity.HasOne(d => d.Mdp)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.Mdpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAIEMENT_REGLER_MOYENDEP");
            });

            modelBuilder.Entity<Panier>(entity =>
            {
                entity.HasOne(d => d.Partenaire)
                    .WithMany(p => p.Paniers)
                    .HasForeignKey(d => d.Partenaireid)
                    .HasConstraintName("FK_PANIER_DISPOSER_PARTENAI");
            });

            modelBuilder.Entity<Panierdetail>(entity =>
            {
                entity.HasKey(e => new { e.Panierid, e.Prodid });

                entity.HasOne(d => d.Panier)
                    .WithMany(p => p.Panierdetails)
                    .HasForeignKey(d => d.Panierid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PANIERDE_CONTENIR_PANIER");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Panierdetails)
                    .HasForeignKey(d => d.Prodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PANIERDE_CONTENIR2_PRODUIT");
            });

            modelBuilder.Entity<Partenaire>(entity =>
            {
                entity.HasOne(d => d.Panier)
                    .WithMany(p => p.Partenaires)
                    .HasForeignKey(d => d.Panierid)
                    .HasConstraintName("FK_PARTENAI_DISPOSER2_PANIER");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
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
                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Remboursements)
                    .HasForeignKey(d => d.Litigeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REMBOURS_DONNER_LITIGE");
            });

            modelBuilder.Entity<Remplacement>(entity =>
            {
                entity.HasOne(d => d.Litige)
                    .WithMany(p => p.Remplacements)
                    .HasForeignKey(d => d.Litigeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REMPLACE_ENVOYER_LITIGE");
            });

            modelBuilder.Entity<Rtransact>(entity =>
            {
                entity.HasKey(e => new { e.Remboursementid, e.Transactionid });

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
