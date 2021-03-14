/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2016                     */
/* Date de création :  14/03/2021 16:40:38                      */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AVIS') and o.name = 'FK_AVIS_AVIS_PRODUIT')
alter table AVIS
   drop constraint FK_AVIS_AVIS_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AVIS') and o.name = 'FK_AVIS_AVIS2_PARTENAI')
alter table AVIS
   drop constraint FK_AVIS_AVIS2_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AVIS') and o.name = 'FK_AVIS_AVIS3_BOUTIQUE')
alter table AVIS
   drop constraint FK_AVIS_AVIS3_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOUTIQUE') and o.name = 'FK_BOUTIQUE_APPLIQUER_POLITIQU')
alter table BOUTIQUE
   drop constraint FK_BOUTIQUE_APPLIQUER_POLITIQU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOUTIQUE') and o.name = 'FK_BOUTIQUE_CREER_PARTENAI')
alter table BOUTIQUE
   drop constraint FK_BOUTIQUE_CREER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CATNAV') and o.name = 'FK_CATNAV_REGROUPER_CATEGORI')
alter table CATNAV
   drop constraint FK_CATNAV_REGROUPER_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CATNAV') and o.name = 'FK_CATNAV_REGROUPER_CATEGORI')
alter table CATNAV
   drop constraint FK_CATNAV_REGROUPER_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQDETAIL') and o.name = 'FK_CMDBTQDE_COMPORTER_COMMANDE')
alter table CMDBTQDETAIL
   drop constraint FK_CMDBTQDE_COMPORTER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQDETAIL') and o.name = 'FK_CMDBTQDE_COMPORTER_PRODUIT')
alter table CMDBTQDETAIL
   drop constraint FK_CMDBTQDE_COMPORTER_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQDETAIL') and o.name = 'FK_CMDBTQDE_COMPORTER_LIVRAISO')
alter table CMDBTQDETAIL
   drop constraint FK_CMDBTQDE_COMPORTER_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTDETAIL') and o.name = 'FK_CMDCLTDE_LISTER_COMMANDE')
alter table CMDCLTDETAIL
   drop constraint FK_CMDCLTDE_LISTER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTDETAIL') and o.name = 'FK_CMDCLTDE_LISTER2_PRODUIT')
alter table CMDCLTDETAIL
   drop constraint FK_CMDCLTDE_LISTER2_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTDETAIL') and o.name = 'FK_CMDCLTDE_LISTER3_LIVRAISO')
alter table CMDCLTDETAIL
   drop constraint FK_CMDCLTDE_LISTER3_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_ASSOCIER_COMMANDE')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_ASSOCIER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_COMPRENDR_ETATCMD')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_COMPRENDR_ETATCMD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_ENGENDRER_LITIGE')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_ENGENDRER_LITIGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_RECEVOIR_BOUTIQUE')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_RECEVOIR_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDECLIENT') and o.name = 'FK_COMMANDE_DETENIR_ETATCMD')
alter table COMMANDECLIENT
   drop constraint FK_COMMANDE_DETENIR_ETATCMD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDECLIENT') and o.name = 'FK_COMMANDE_GENERER2_FACTURE')
alter table COMMANDECLIENT
   drop constraint FK_COMMANDE_GENERER2_FACTURE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDECLIENT') and o.name = 'FK_COMMANDE_PASSER_PARTENAI')
alter table COMMANDECLIENT
   drop constraint FK_COMMANDE_PASSER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDECLIENT') and o.name = 'FK_COMMANDE_PRENDRE2_PAIEMENT')
alter table COMMANDECLIENT
   drop constraint FK_COMMANDE_PRENDRE2_PAIEMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ECHANGE') and o.name = 'FK_ECHANGE_ECHANGE_PARTENAI')
alter table ECHANGE
   drop constraint FK_ECHANGE_ECHANGE_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ECHANGE') and o.name = 'FK_ECHANGE_ECHANGE2_PRODUIT')
alter table ECHANGE
   drop constraint FK_ECHANGE_ECHANGE2_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ECHANGE') and o.name = 'FK_ECHANGE_ECHANGE3_BOUTIQUE')
alter table ECHANGE
   drop constraint FK_ECHANGE_ECHANGE3_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURE') and o.name = 'FK_FACTURE_GENERER_COMMANDE')
alter table FACTURE
   drop constraint FK_FACTURE_GENERER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('IDENTIFICATION') and o.name = 'FK_IDENTIFI_ETRE_CIVILITE')
alter table IDENTIFICATION
   drop constraint FK_IDENTIFI_ETRE_CIVILITE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('IDENTIFICATION') and o.name = 'FK_IDENTIFI_IDENTIFIE_PARTENAI')
alter table IDENTIFICATION
   drop constraint FK_IDENTIFI_IDENTIFIE_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LITIGE') and o.name = 'FK_LITIGE_DONNER2_REMBOURS')
alter table LITIGE
   drop constraint FK_LITIGE_DONNER2_REMBOURS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LITIGE') and o.name = 'FK_LITIGE_ENGENDRER_COMMANDE')
alter table LITIGE
   drop constraint FK_LITIGE_ENGENDRER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LITIGE') and o.name = 'FK_LITIGE_ENVOYER2_REMPLACE')
alter table LITIGE
   drop constraint FK_LITIGE_ENVOYER2_REMPLACE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LIVRAISON') and o.name = 'FK_LIVRAISO_CARACTERI_LIVRAISO')
alter table LIVRAISON
   drop constraint FK_LIVRAISO_CARACTERI_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LIVRAISON') and o.name = 'FK_LIVRAISO_DEFINIR_LIVRAISO')
alter table LIVRAISON
   drop constraint FK_LIVRAISO_DEFINIR_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LIVRAISON') and o.name = 'FK_LIVRAISO_DESTINER_LOCALISA')
alter table LIVRAISON
   drop constraint FK_LIVRAISO_DESTINER_LOCALISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOCALISATION') and o.name = 'FK_LOCALISA_POSSEDER_PARTENAI')
alter table LOCALISATION
   drop constraint FK_LOCALISA_POSSEDER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOCALISATION') and o.name = 'FK_LOCALISA_SITUER_BOUTIQUE')
alter table LOCALISATION
   drop constraint FK_LOCALISA_SITUER_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDIA') and o.name = 'FK_MEDIA_BOUTMEDIA_BOUTIQUE')
alter table MEDIA
   drop constraint FK_MEDIA_BOUTMEDIA_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDIA') and o.name = 'FK_MEDIA_LTGMEDIA_LITIGE')
alter table MEDIA
   drop constraint FK_MEDIA_LTGMEDIA_LITIGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDIA') and o.name = 'FK_MEDIA_PRODMEDIA_PRODUIT')
alter table MEDIA
   drop constraint FK_MEDIA_PRODMEDIA_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MOYENDEPAIEMENT') and o.name = 'FK_MOYENDEP_UTILISER_PARTENAI')
alter table MOYENDEPAIEMENT
   drop constraint FK_MOYENDEP_UTILISER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PAIEMENT') and o.name = 'FK_PAIEMENT_PRENDRE_COMMANDE')
alter table PAIEMENT
   drop constraint FK_PAIEMENT_PRENDRE_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PAIEMENT') and o.name = 'FK_PAIEMENT_REGLER_MOYENDEP')
alter table PAIEMENT
   drop constraint FK_PAIEMENT_REGLER_MOYENDEP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANDETAIL') and o.name = 'FK_PANDETAI_CONTENIR_PANIER')
alter table PANDETAIL
   drop constraint FK_PANDETAI_CONTENIR_PANIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANDETAIL') and o.name = 'FK_PANDETAI_CONTENIR2_PRODUIT')
alter table PANDETAIL
   drop constraint FK_PANDETAI_CONTENIR2_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANIER') and o.name = 'FK_PANIER_DISPOSER_PARTENAI')
alter table PANIER
   drop constraint FK_PANIER_DISPOSER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARTENAIRE') and o.name = 'FK_PARTENAI_DISPOSER2_PANIER')
alter table PARTENAIRE
   drop constraint FK_PARTENAI_DISPOSER2_PANIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('POINTRELAIS') and o.name = 'FK_POINTREL_PROPOSER_BOUTIQUE')
alter table POINTRELAIS
   drop constraint FK_POINTREL_PROPOSER_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('POINTRELAIS') and o.name = 'FK_POINTREL_PROPOSER2_LOCALISA')
alter table POINTRELAIS
   drop constraint FK_POINTREL_PROPOSER2_LOCALISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUIT') and o.name = 'FK_PRODUIT_APPARTENI_CATEGORI')
alter table PRODUIT
   drop constraint FK_PRODUIT_APPARTENI_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUIT') and o.name = 'FK_PRODUIT_AVOIR_LIVRAISO')
alter table PRODUIT
   drop constraint FK_PRODUIT_AVOIR_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUIT') and o.name = 'FK_PRODUIT_VENDRE_BOUTIQUE')
alter table PRODUIT
   drop constraint FK_PRODUIT_VENDRE_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PTRANSACT') and o.name = 'FK_PTRANSAC_TRACER_PAIEMENT')
alter table PTRANSACT
   drop constraint FK_PTRANSAC_TRACER_PAIEMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PTRANSACT') and o.name = 'FK_PTRANSAC_TRACER2_TRANSACT')
alter table PTRANSACT
   drop constraint FK_PTRANSAC_TRACER2_TRANSACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REMBOURSEMENT') and o.name = 'FK_REMBOURS_DONNER_LITIGE')
alter table REMBOURSEMENT
   drop constraint FK_REMBOURS_DONNER_LITIGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REMPLACEMENT') and o.name = 'FK_REMPLACE_ENVOYER_LITIGE')
alter table REMPLACEMENT
   drop constraint FK_REMPLACE_ENVOYER_LITIGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RTRANSACT') and o.name = 'FK_RTRANSAC_TRAQUER_REMBOURS')
alter table RTRANSACT
   drop constraint FK_RTRANSAC_TRAQUER_REMBOURS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RTRANSACT') and o.name = 'FK_RTRANSAC_TRAQUER2_TRANSACT')
alter table RTRANSACT
   drop constraint FK_RTRANSAC_TRAQUER2_TRANSACT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AVIS')
            and   name  = 'AVIS3_FK'
            and   indid > 0
            and   indid < 255)
   drop index AVIS.AVIS3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AVIS')
            and   name  = 'AVIS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index AVIS.AVIS2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AVIS')
            and   name  = 'AVIS_FK'
            and   indid > 0
            and   indid < 255)
   drop index AVIS.AVIS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AVIS')
            and   type = 'U')
   drop table AVIS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOUTIQUE')
            and   name  = 'CREER_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOUTIQUE.CREER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOUTIQUE')
            and   name  = 'APPLIQUER_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOUTIQUE.APPLIQUER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BOUTIQUE')
            and   type = 'U')
   drop table BOUTIQUE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIE')
            and   type = 'U')
   drop table CATEGORIE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CATNAV')
            and   name  = 'REGROUPER3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CATNAV.REGROUPER3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CATNAV')
            and   name  = 'REGROUPER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CATNAV.REGROUPER2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATNAV')
            and   type = 'U')
   drop table CATNAV
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CIVILITE')
            and   type = 'U')
   drop table CIVILITE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQDETAIL')
            and   name  = 'COMPORTER3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQDETAIL.COMPORTER3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQDETAIL')
            and   name  = 'COMPORTER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQDETAIL.COMPORTER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQDETAIL')
            and   name  = 'COMPORTER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQDETAIL.COMPORTER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CMDBTQDETAIL')
            and   type = 'U')
   drop table CMDBTQDETAIL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTDETAIL')
            and   name  = 'LISTER3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTDETAIL.LISTER3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTDETAIL')
            and   name  = 'LISTER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTDETAIL.LISTER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTDETAIL')
            and   name  = 'LISTER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTDETAIL.LISTER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CMDCLTDETAIL')
            and   type = 'U')
   drop table CMDCLTDETAIL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDEBOUTIQUE')
            and   name  = 'ENGENDRER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDEBOUTIQUE.ENGENDRER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDEBOUTIQUE')
            and   name  = 'COMPRENDRE_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDEBOUTIQUE.COMPRENDRE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDEBOUTIQUE')
            and   name  = 'ASSOCIER_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDEBOUTIQUE.ASSOCIER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDEBOUTIQUE')
            and   name  = 'RECEVOIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDEBOUTIQUE.RECEVOIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMMANDEBOUTIQUE')
            and   type = 'U')
   drop table COMMANDEBOUTIQUE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDECLIENT')
            and   name  = 'PRENDRE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDECLIENT.PRENDRE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDECLIENT')
            and   name  = 'DETENIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDECLIENT.DETENIR_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDECLIENT')
            and   name  = 'PASSER_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDECLIENT.PASSER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMMANDECLIENT')
            and   name  = 'GENERER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDECLIENT.GENERER2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMMANDECLIENT')
            and   type = 'U')
   drop table COMMANDECLIENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ECHANGE')
            and   name  = 'ECHANGE3_FK'
            and   indid > 0
            and   indid < 255)
   drop index ECHANGE.ECHANGE3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ECHANGE')
            and   name  = 'ECHANGE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ECHANGE.ECHANGE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ECHANGE')
            and   name  = 'ECHANGE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ECHANGE.ECHANGE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ECHANGE')
            and   type = 'U')
   drop table ECHANGE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ETATCMD')
            and   type = 'U')
   drop table ETATCMD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURE')
            and   name  = 'GENERER_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURE.GENERER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURE')
            and   type = 'U')
   drop table FACTURE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('IDENTIFICATION')
            and   name  = 'ETRE_FK'
            and   indid > 0
            and   indid < 255)
   drop index IDENTIFICATION.ETRE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('IDENTIFICATION')
            and   name  = 'IDENTIFIER_FK'
            and   indid > 0
            and   indid < 255)
   drop index IDENTIFICATION.IDENTIFIER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('IDENTIFICATION')
            and   type = 'U')
   drop table IDENTIFICATION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LITIGE')
            and   name  = 'ENVOYER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index LITIGE.ENVOYER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LITIGE')
            and   name  = 'DONNER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index LITIGE.DONNER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LITIGE')
            and   name  = 'ENGENDRER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LITIGE.ENGENDRER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LITIGE')
            and   type = 'U')
   drop table LITIGE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LIVRAISON')
            and   name  = 'CARACTERISER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LIVRAISON.CARACTERISER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LIVRAISON')
            and   name  = 'DESTINER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LIVRAISON.DESTINER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LIVRAISON')
            and   name  = 'DEFINIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index LIVRAISON.DEFINIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LIVRAISON')
            and   type = 'U')
   drop table LIVRAISON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LIVRAISONETAT')
            and   type = 'U')
   drop table LIVRAISONETAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LIVRAISONTYPE')
            and   type = 'U')
   drop table LIVRAISONTYPE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOCALISATION')
            and   name  = 'POSSEDER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOCALISATION.POSSEDER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOCALISATION')
            and   name  = 'SITUER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOCALISATION.SITUER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOCALISATION')
            and   type = 'U')
   drop table LOCALISATION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEDIA')
            and   name  = 'LTGMEDIA_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEDIA.LTGMEDIA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEDIA')
            and   name  = 'BOUTMEDIA_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEDIA.BOUTMEDIA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEDIA')
            and   name  = 'PRODMEDIA_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEDIA.PRODMEDIA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEDIA')
            and   type = 'U')
   drop table MEDIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MOYENDEPAIEMENT')
            and   name  = 'UTILISER_FK'
            and   indid > 0
            and   indid < 255)
   drop index MOYENDEPAIEMENT.UTILISER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MOYENDEPAIEMENT')
            and   type = 'U')
   drop table MOYENDEPAIEMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PAIEMENT')
            and   name  = 'PRENDRE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PAIEMENT.PRENDRE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PAIEMENT')
            and   name  = 'REGLER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PAIEMENT.REGLER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAIEMENT')
            and   type = 'U')
   drop table PAIEMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PANDETAIL')
            and   name  = 'CONTENIR2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANDETAIL.CONTENIR2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PANDETAIL')
            and   name  = 'CONTENIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANDETAIL.CONTENIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PANDETAIL')
            and   type = 'U')
   drop table PANDETAIL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PANIER')
            and   name  = 'DISPOSER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANIER.DISPOSER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PANIER')
            and   type = 'U')
   drop table PANIER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PARTENAIRE')
            and   name  = 'DISPOSER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PARTENAIRE.DISPOSER2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PARTENAIRE')
            and   type = 'U')
   drop table PARTENAIRE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('POINTRELAIS')
            and   name  = 'PROPOSER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index POINTRELAIS.PROPOSER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('POINTRELAIS')
            and   name  = 'PROPOSER_FK'
            and   indid > 0
            and   indid < 255)
   drop index POINTRELAIS.PROPOSER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('POINTRELAIS')
            and   type = 'U')
   drop table POINTRELAIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('POLITIQUE')
            and   type = 'U')
   drop table POLITIQUE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUIT')
            and   name  = 'AVOIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUIT.AVOIR_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUIT')
            and   name  = 'VENDRE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUIT.VENDRE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUIT')
            and   name  = 'APPARTENIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUIT.APPARTENIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUIT')
            and   type = 'U')
   drop table PRODUIT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PTRANSACT')
            and   name  = 'TRACER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PTRANSACT.TRACER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PTRANSACT')
            and   name  = 'TRACER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PTRANSACT.TRACER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PTRANSACT')
            and   type = 'U')
   drop table PTRANSACT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('REMBOURSEMENT')
            and   name  = 'DONNER_FK'
            and   indid > 0
            and   indid < 255)
   drop index REMBOURSEMENT.DONNER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REMBOURSEMENT')
            and   type = 'U')
   drop table REMBOURSEMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('REMPLACEMENT')
            and   name  = 'ENVOYER_FK'
            and   indid > 0
            and   indid < 255)
   drop index REMPLACEMENT.ENVOYER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REMPLACEMENT')
            and   type = 'U')
   drop table REMPLACEMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RTRANSACT')
            and   name  = 'TRAQUER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index RTRANSACT.TRAQUER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RTRANSACT')
            and   name  = 'TRAQUER_FK'
            and   indid > 0
            and   indid < 255)
   drop index RTRANSACT.TRAQUER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RTRANSACT')
            and   type = 'U')
   drop table RTRANSACT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"TRANSACTION"')
            and   type = 'U')
   drop table "TRANSACTION"
go

/*==============================================================*/
/* Table : AVIS                                                 */
/*==============================================================*/
create table AVIS (
   PRODID               int                  not null,
   PARTENAIREID         int                  not null,
   BTQID                int                  not null,
   A_NOTE               smallint             null,
   A_DATE               datetime             null,
   A_TEXTE              nvarchar(255)        null,
   A_REPONSE            nvarchar(255)        null,
   A_REPDATE            datetime             null,
   constraint PK_AVIS primary key (PRODID, PARTENAIREID, BTQID)
)
go

/*==============================================================*/
/* Index : AVIS_FK                                              */
/*==============================================================*/




create nonclustered index AVIS_FK on AVIS (PRODID ASC)
go

/*==============================================================*/
/* Index : AVIS2_FK                                             */
/*==============================================================*/




create nonclustered index AVIS2_FK on AVIS (PARTENAIREID ASC)
go

/*==============================================================*/
/* Index : AVIS3_FK                                             */
/*==============================================================*/




create nonclustered index AVIS3_FK on AVIS (BTQID ASC)
go

/*==============================================================*/
/* Table : BOUTIQUE                                             */
/*==============================================================*/
create table BOUTIQUE (
   BTQID                int                  not null,
   PARTENAIREID         int                  not null,
   POLITIQUEID          int                  not null,
   B_DESCRIPTION_C      nvarchar(100)        null,
   B_DESCRIPTION_L      nvarchar(255)        null,
   RAISONSOCIALE        nvarchar(255)        null,
   SIRET                nvarchar(14)         null,
   SIREN                nvarchar(9)          null,
   BTQTEL               nvarchar(15)         null,
   CODENAF              nvarchar(5)          null,
   CODEBANQUE           nvarchar(5)          null,
   CODEGUICHET          nvarchar(5)          null,
   NUMCOMPTE            nvarchar(11)         null,
   CLERIB               nvarchar(2)          null,
   DOMICILIATION        nvarchar(24)         null,
   IBAN                 nvarchar(27)         null,
   BIC                  nvarchar(11)         null,
   TITULAIRE            nvarchar(140)        null,
   BTQTMAIL             nvarchar(255)        null,
   BTQMESSAGE           nvarchar(255)        null,
   CA                   int                  null,
   NBSALARIE            int                  null,
   SITEWEB              nvarchar(100)        null,
   STATUTJURIDIQUE      nvarchar(25)         null,
   BTQSEO               nvarchar(100)        null,
   constraint PK_BOUTIQUE primary key (BTQID)
)
go

/*==============================================================*/
/* Index : APPLIQUER_FK                                         */
/*==============================================================*/




create nonclustered index APPLIQUER_FK on BOUTIQUE (POLITIQUEID ASC)
go

/*==============================================================*/
/* Index : CREER_FK                                             */
/*==============================================================*/




create nonclustered index CREER_FK on BOUTIQUE (PARTENAIREID ASC)
go

/*==============================================================*/
/* Table : CATEGORIE                                            */
/*==============================================================*/
create table CATEGORIE (
   CATEGORIEID          int                  not null,
   CATEGORIENOM         varchar(255)         null,
   constraint PK_CATEGORIE primary key (CATEGORIEID)
)
go

/*==============================================================*/
/* Table : CATNAV                                               */
/*==============================================================*/
create table CATNAV (
   CATEGORIEID          int                  not null,
   CAT_PARENTID         int                  not null,
   constraint PK_CATNAV primary key (CATEGORIEID, CAT_PARENTID)
)
go

/*==============================================================*/
/* Index : REGROUPER2_FK                                        */
/*==============================================================*/




create nonclustered index REGROUPER2_FK on CATNAV (CATEGORIEID ASC)
go

/*==============================================================*/
/* Index : REGROUPER3_FK                                        */
/*==============================================================*/




create nonclustered index REGROUPER3_FK on CATNAV (CAT_PARENTID ASC)
go

/*==============================================================*/
/* Table : CIVILITE                                             */
/*==============================================================*/
create table CIVILITE (
   CIVID                int                  not null,
   ABREGE               nvarchar(5)          null,
   COMPLET              nvarchar(15)         null,
   constraint PK_CIVILITE primary key (CIVID)
)
go

/*==============================================================*/
/* Table : CMDBTQDETAIL                                         */
/*==============================================================*/
create table CMDBTQDETAIL (
   CMDBTQID             int                  not null,
   PRODID               int                  not null,
   LIVRAISONID          int                  not null,
   B_CMD_QTEPROD        smallint             null,
   constraint PK_CMDBTQDETAIL primary key (CMDBTQID, PRODID, LIVRAISONID)
)
go

/*==============================================================*/
/* Index : COMPORTER_FK                                         */
/*==============================================================*/




create nonclustered index COMPORTER_FK on CMDBTQDETAIL (CMDBTQID ASC)
go

/*==============================================================*/
/* Index : COMPORTER2_FK                                        */
/*==============================================================*/




create nonclustered index COMPORTER2_FK on CMDBTQDETAIL (PRODID ASC)
go

/*==============================================================*/
/* Index : COMPORTER3_FK                                        */
/*==============================================================*/




create nonclustered index COMPORTER3_FK on CMDBTQDETAIL (LIVRAISONID ASC)
go

/*==============================================================*/
/* Table : CMDCLTDETAIL                                         */
/*==============================================================*/
create table CMDCLTDETAIL (
   CMDCLTID             int                  not null,
   PRODID               int                  not null,
   LIVRAISONID          int                  not null,
   C_CMD_QTEPROD        smallint             null,
   constraint PK_CMDCLTDETAIL primary key (CMDCLTID, PRODID, LIVRAISONID)
)
go

/*==============================================================*/
/* Index : LISTER_FK                                            */
/*==============================================================*/




create nonclustered index LISTER_FK on CMDCLTDETAIL (CMDCLTID ASC)
go

/*==============================================================*/
/* Index : LISTER2_FK                                           */
/*==============================================================*/




create nonclustered index LISTER2_FK on CMDCLTDETAIL (PRODID ASC)
go

/*==============================================================*/
/* Index : LISTER3_FK                                           */
/*==============================================================*/




create nonclustered index LISTER3_FK on CMDCLTDETAIL (LIVRAISONID ASC)
go

/*==============================================================*/
/* Table : COMMANDEBOUTIQUE                                     */
/*==============================================================*/
create table COMMANDEBOUTIQUE (
   CMDBTQID             int                  not null,
   ETATID               int                  not null,
   LITIGEID             int                  null,
   CMDCLTID             int                  null,
   BTQID                int                  not null,
   DATECREA             datetime             null,
   DATEDEBUT            datetime             null,
   DATEFIN              datetime             null,
   constraint PK_COMMANDEBOUTIQUE primary key (CMDBTQID)
)
go

/*==============================================================*/
/* Index : RECEVOIR_FK                                          */
/*==============================================================*/




create nonclustered index RECEVOIR_FK on COMMANDEBOUTIQUE (BTQID ASC)
go

/*==============================================================*/
/* Index : ASSOCIER_FK                                          */
/*==============================================================*/




create nonclustered index ASSOCIER_FK on COMMANDEBOUTIQUE (CMDCLTID ASC)
go

/*==============================================================*/
/* Index : COMPRENDRE_FK                                        */
/*==============================================================*/




create nonclustered index COMPRENDRE_FK on COMMANDEBOUTIQUE (ETATID ASC)
go

/*==============================================================*/
/* Index : ENGENDRER2_FK                                        */
/*==============================================================*/




create nonclustered index ENGENDRER2_FK on COMMANDEBOUTIQUE (LITIGEID ASC)
go

/*==============================================================*/
/* Table : COMMANDECLIENT                                       */
/*==============================================================*/
create table COMMANDECLIENT (
   CMDCLTID             int                  not null,
   PARTENAIREID         int                  not null,
   ETATID               int                  not null,
   PAIEMENTID           int                  null,
   FACTUREID            int                  null,
   CMDCLTDATE           datetime             null,
   CMDCLTDATEDEBUT      datetime             null,
   CMDCLTDATEFIN        datetime             null,
   constraint PK_COMMANDECLIENT primary key (CMDCLTID)
)
go

/*==============================================================*/
/* Index : GENERER2_FK                                          */
/*==============================================================*/




create nonclustered index GENERER2_FK on COMMANDECLIENT (FACTUREID ASC)
go

/*==============================================================*/
/* Index : PASSER_FK                                            */
/*==============================================================*/




create nonclustered index PASSER_FK on COMMANDECLIENT (PARTENAIREID ASC)
go

/*==============================================================*/
/* Index : DETENIR_FK                                           */
/*==============================================================*/




create nonclustered index DETENIR_FK on COMMANDECLIENT (ETATID ASC)
go

/*==============================================================*/
/* Index : PRENDRE2_FK                                          */
/*==============================================================*/




create nonclustered index PRENDRE2_FK on COMMANDECLIENT (PAIEMENTID ASC)
go

/*==============================================================*/
/* Table : ECHANGE                                              */
/*==============================================================*/
create table ECHANGE (
   PARTENAIREID         int                  not null,
   PRODID               int                  not null,
   BTQID                int                  not null,
   E_QUEST              nvarchar(255)        null,
   E_REP                nvarchar(255)        null,
   E_QUESTDATE          datetime             null,
   E_REPDATE            datetime             null,
   constraint PK_ECHANGE primary key (PARTENAIREID, PRODID, BTQID)
)
go

/*==============================================================*/
/* Index : ECHANGE_FK                                           */
/*==============================================================*/




create nonclustered index ECHANGE_FK on ECHANGE (PARTENAIREID ASC)
go

/*==============================================================*/
/* Index : ECHANGE2_FK                                          */
/*==============================================================*/




create nonclustered index ECHANGE2_FK on ECHANGE (PRODID ASC)
go

/*==============================================================*/
/* Index : ECHANGE3_FK                                          */
/*==============================================================*/




create nonclustered index ECHANGE3_FK on ECHANGE (BTQID ASC)
go

/*==============================================================*/
/* Table : ETATCMD                                              */
/*==============================================================*/
create table ETATCMD (
   ETATID               int                  not null,
   ETATCMD              varchar(15)          null,
   constraint PK_ETATCMD primary key (ETATID)
)
go

/*==============================================================*/
/* Table : FACTURE                                              */
/*==============================================================*/
create table FACTURE (
   FACTUREID            int                  not null,
   CMDCLTID             int                  not null,
   FACTLIEN             nvarchar(255)        null,
   constraint PK_FACTURE primary key (FACTUREID)
)
go

/*==============================================================*/
/* Index : GENERER_FK                                           */
/*==============================================================*/




create nonclustered index GENERER_FK on FACTURE (CMDCLTID ASC)
go

/*==============================================================*/
/* Table : IDENTIFICATION                                       */
/*==============================================================*/
create table IDENTIFICATION (
   IDENTID              int                  not null,
   PARTENAIREID         int                  not null,
   CIVID                int                  not null,
   NOM                  nvarchar(70)         null,
   PRENOM               nvarchar(70)         null,
   EMAIL                nvarchar(255)        null,
   TEL                  nvarchar(15)         null,
   constraint PK_IDENTIFICATION primary key (IDENTID)
)
go

/*==============================================================*/
/* Index : IDENTIFIER_FK                                        */
/*==============================================================*/




create nonclustered index IDENTIFIER_FK on IDENTIFICATION (PARTENAIREID ASC)
go

/*==============================================================*/
/* Index : ETRE_FK                                              */
/*==============================================================*/




create nonclustered index ETRE_FK on IDENTIFICATION (CIVID ASC)
go

/*==============================================================*/
/* Table : LITIGE                                               */
/*==============================================================*/
create table LITIGE (
   LITIGEID             int                  not null,
   REMBOURSEMENTID      int                  null,
   RETOURID             int                  null,
   CMDBTQID             int                  not null,
   LTGMSG               nvarchar(255)        null,
   constraint PK_LITIGE primary key (LITIGEID)
)
go

/*==============================================================*/
/* Index : ENGENDRER_FK                                         */
/*==============================================================*/




create nonclustered index ENGENDRER_FK on LITIGE (CMDBTQID ASC)
go

/*==============================================================*/
/* Index : DONNER2_FK                                           */
/*==============================================================*/




create nonclustered index DONNER2_FK on LITIGE (REMBOURSEMENTID ASC)
go

/*==============================================================*/
/* Index : ENVOYER2_FK                                          */
/*==============================================================*/




create nonclustered index ENVOYER2_FK on LITIGE (RETOURID ASC)
go

/*==============================================================*/
/* Table : LIVRAISON                                            */
/*==============================================================*/
create table LIVRAISON (
   LIVRAISONID          int                  not null,
   LVRTYPID             int                  not null,
   LVRETATID            int                  not null,
   LOCALISATIONID       int                  not null,
   SUIVINUM             nvarchar(255)        null,
   SUIVILIEN            nvarchar(255)        null,
   DATEENVOI            datetime             null,
   constraint PK_LIVRAISON primary key (LIVRAISONID)
)
go

/*==============================================================*/
/* Index : DEFINIR_FK                                           */
/*==============================================================*/




create nonclustered index DEFINIR_FK on LIVRAISON (LVRTYPID ASC)
go

/*==============================================================*/
/* Index : DESTINER_FK                                          */
/*==============================================================*/




create nonclustered index DESTINER_FK on LIVRAISON (LOCALISATIONID ASC)
go

/*==============================================================*/
/* Index : CARACTERISER_FK                                      */
/*==============================================================*/




create nonclustered index CARACTERISER_FK on LIVRAISON (LVRETATID ASC)
go

/*==============================================================*/
/* Table : LIVRAISONETAT                                        */
/*==============================================================*/
create table LIVRAISONETAT (
   LVRETATID            int                  not null,
   LVRETAT              nvarchar(15)         null,
   constraint PK_LIVRAISONETAT primary key (LVRETATID)
)
go

/*==============================================================*/
/* Table : LIVRAISONTYPE                                        */
/*==============================================================*/
create table LIVRAISONTYPE (
   LVRTYPID             int                  not null,
   LVRDESIGNATION       nvarchar(15)         null,
   LVRDELAI             smallint             null,
   LVRCOUT              decimal(9,2)         null,
   constraint PK_LIVRAISONTYPE primary key (LVRTYPID)
)
go

/*==============================================================*/
/* Table : LOCALISATION                                         */
/*==============================================================*/
create table LOCALISATION (
   LOCALISATIONID       int                  not null,
   BTQID                int                  not null,
   PARTENAIREID         int                  not null,
   ADRESSE              nvarchar(255)        null,
   RUE                  nvarchar(255)        null,
   NUM                  nvarchar(255)        null,
   VILLE                nvarchar(255)        null,
   CODEPOSTAL           nvarchar(255)        null,
   PAYS                 nvarchar(255)        null,
   PR_NOM               nvarchar(255)        null,
   constraint PK_LOCALISATION primary key (LOCALISATIONID)
)
go

/*==============================================================*/
/* Index : SITUER_FK                                            */
/*==============================================================*/




create nonclustered index SITUER_FK on LOCALISATION (BTQID ASC)
go

/*==============================================================*/
/* Index : POSSEDER_FK                                          */
/*==============================================================*/




create nonclustered index POSSEDER_FK on LOCALISATION (PARTENAIREID ASC)
go

/*==============================================================*/
/* Table : MEDIA                                                */
/*==============================================================*/
create table MEDIA (
   MEDIAID              int                  not null,
   PRODID               int                  null,
   LITIGEID             int                  null,
   BTQID                int                  null,
   LIEN                 nvarchar(255)        null,
   DESCRIPTION          nvarchar(255)        null,
   IMAGE                bit                  null,
   VIDEO                bit                  null,
   HTML                 nvarchar(255)        null,
   constraint PK_MEDIA primary key (MEDIAID)
)
go

/*==============================================================*/
/* Index : PRODMEDIA_FK                                         */
/*==============================================================*/




create nonclustered index PRODMEDIA_FK on MEDIA (PRODID ASC)
go

/*==============================================================*/
/* Index : BOUTMEDIA_FK                                         */
/*==============================================================*/




create nonclustered index BOUTMEDIA_FK on MEDIA (BTQID ASC)
go

/*==============================================================*/
/* Index : LTGMEDIA_FK                                          */
/*==============================================================*/




create nonclustered index LTGMEDIA_FK on MEDIA (LITIGEID ASC)
go

/*==============================================================*/
/* Table : MOYENDEPAIEMENT                                      */
/*==============================================================*/
create table MOYENDEPAIEMENT (
   MDPID                int                  not null,
   PARTENAIREID         int                  not null,
   CB_NUM               nvarchar(16)         null,
   CVC                  nvarchar(4)          null,
   DATEEXP              datetime             null,
   CB_TITULAIRE         nvarchar(140)        null,
   CB_TYPE              nvarchar(30)         null,
   constraint PK_MOYENDEPAIEMENT primary key (MDPID)
)
go

/*==============================================================*/
/* Index : UTILISER_FK                                          */
/*==============================================================*/




create nonclustered index UTILISER_FK on MOYENDEPAIEMENT (PARTENAIREID ASC)
go

/*==============================================================*/
/* Table : PAIEMENT                                             */
/*==============================================================*/
create table PAIEMENT (
   PAIEMENTID           int                  not null,
   MDPID                int                  not null,
   CMDCLTID             int                  not null,
   P_MONTANT            decimal(9,2)         null,
   constraint PK_PAIEMENT primary key (PAIEMENTID)
)
go

/*==============================================================*/
/* Index : REGLER_FK                                            */
/*==============================================================*/




create nonclustered index REGLER_FK on PAIEMENT (MDPID ASC)
go

/*==============================================================*/
/* Index : PRENDRE_FK                                           */
/*==============================================================*/




create nonclustered index PRENDRE_FK on PAIEMENT (CMDCLTID ASC)
go

/*==============================================================*/
/* Table : PANDETAIL                                            */
/*==============================================================*/
create table PANDETAIL (
   PANIERID             int                  not null,
   PRODID               int                  not null,
   P_QTEPROD            smallint             null,
   constraint PK_PANDETAIL primary key (PANIERID, PRODID)
)
go

/*==============================================================*/
/* Index : CONTENIR_FK                                          */
/*==============================================================*/




create nonclustered index CONTENIR_FK on PANDETAIL (PANIERID ASC)
go

/*==============================================================*/
/* Index : CONTENIR2_FK                                         */
/*==============================================================*/




create nonclustered index CONTENIR2_FK on PANDETAIL (PRODID ASC)
go

/*==============================================================*/
/* Table : PANIER                                               */
/*==============================================================*/
create table PANIER (
   PANIERID             int                  not null,
   PARTENAIREID         int                  null,
   constraint PK_PANIER primary key (PANIERID)
)
go

/*==============================================================*/
/* Index : DISPOSER_FK                                          */
/*==============================================================*/




create nonclustered index DISPOSER_FK on PANIER (PARTENAIREID ASC)
go

/*==============================================================*/
/* Table : PARTENAIRE                                           */
/*==============================================================*/
create table PARTENAIRE (
   PARTENAIREID         int                  not null,
   PANIERID             int                  null,
   ADMIN                bit                  null,
   VENDEUR              bit                  null,
   DATEENR              datetime             null,
   DATECON              datetime             null,
   USERID               int                  not null,
   constraint PK_PARTENAIRE primary key (PARTENAIREID)
)
go

/*==============================================================*/
/* Index : DISPOSER2_FK                                         */
/*==============================================================*/




create nonclustered index DISPOSER2_FK on PARTENAIRE (PANIERID ASC)
go

/*==============================================================*/
/* Table : POINTRELAIS                                          */
/*==============================================================*/
create table POINTRELAIS (
   BTQID                int                  not null,
   LOCALISATIONID       int                  not null,
   constraint PK_POINTRELAIS primary key (BTQID, LOCALISATIONID)
)
go

/*==============================================================*/
/* Index : PROPOSER_FK                                          */
/*==============================================================*/




create nonclustered index PROPOSER_FK on POINTRELAIS (BTQID ASC)
go

/*==============================================================*/
/* Index : PROPOSER2_FK                                         */
/*==============================================================*/




create nonclustered index PROPOSER2_FK on POINTRELAIS (LOCALISATIONID ASC)
go

/*==============================================================*/
/* Table : POLITIQUE                                            */
/*==============================================================*/
create table POLITIQUE (
   POLITIQUEID          int                  not null,
   ECHANGE              bit                  null,
   REMBOURSEMENT        bit                  null,
   PLTQDESCRIPTION      nvarchar(255)        null,
   constraint PK_POLITIQUE primary key (POLITIQUEID)
)
go

/*==============================================================*/
/* Table : PRODUIT                                              */
/*==============================================================*/
create table PRODUIT (
   PRODID               int                  not null,
   BTQID                int                  not null,
   CATEGORIEID          int                  not null,
   LVRTYPID             int                  not null,
   PRIX                 decimal(9,2)         null,
   P_NOM                nvarchar(20)         null,
   P_DESCRIPTION_C      nvarchar(100)        null,
   P_DESCRIPTION_L      nvarchar(255)        null,
   STOCK                smallint             null,
   DISPONIBILITE        smallint             null,
   RABAIS               smallint             null,
   PREPARATION          smallint             null,
   P_SEO                nvarchar(100)        null,
   P_META_KEYWORDS      nvarchar(100)        null,
   P_META_TITRE         nvarchar(100)        null,
   PUBLIER              bit                  null,
   constraint PK_PRODUIT primary key (PRODID)
)
go

/*==============================================================*/
/* Index : APPARTENIR_FK                                        */
/*==============================================================*/




create nonclustered index APPARTENIR_FK on PRODUIT (CATEGORIEID ASC)
go

/*==============================================================*/
/* Index : VENDRE_FK                                            */
/*==============================================================*/




create nonclustered index VENDRE_FK on PRODUIT (BTQID ASC)
go

/*==============================================================*/
/* Index : AVOIR_FK                                             */
/*==============================================================*/




create nonclustered index AVOIR_FK on PRODUIT (LVRTYPID ASC)
go

/*==============================================================*/
/* Table : PTRANSACT                                            */
/*==============================================================*/
create table PTRANSACT (
   PAIEMENTID           int                  not null,
   TRANSACTIONID        int                  not null,
   constraint PK_PTRANSACT primary key (PAIEMENTID, TRANSACTIONID)
)
go

/*==============================================================*/
/* Index : TRACER_FK                                            */
/*==============================================================*/




create nonclustered index TRACER_FK on PTRANSACT (PAIEMENTID ASC)
go

/*==============================================================*/
/* Index : TRACER2_FK                                           */
/*==============================================================*/




create nonclustered index TRACER2_FK on PTRANSACT (TRANSACTIONID ASC)
go

/*==============================================================*/
/* Table : REMBOURSEMENT                                        */
/*==============================================================*/
create table REMBOURSEMENT (
   REMBOURSEMENTID      int                  not null,
   LITIGEID             int                  not null,
   R_MONTANT            decimal(9,2)         null,
   constraint PK_REMBOURSEMENT primary key (REMBOURSEMENTID)
)
go

/*==============================================================*/
/* Index : DONNER_FK                                            */
/*==============================================================*/




create nonclustered index DONNER_FK on REMBOURSEMENT (LITIGEID ASC)
go

/*==============================================================*/
/* Table : REMPLACEMENT                                         */
/*==============================================================*/
create table REMPLACEMENT (
   RETOURID             int                  not null,
   LITIGEID             int                  not null,
   R_SUIVINUM           nvarchar(255)        null,
   R_SUIVILIEN          nvarchar(255)        null,
   constraint PK_REMPLACEMENT primary key (RETOURID)
)
go

/*==============================================================*/
/* Index : ENVOYER_FK                                           */
/*==============================================================*/




create nonclustered index ENVOYER_FK on REMPLACEMENT (LITIGEID ASC)
go

/*==============================================================*/
/* Table : RTRANSACT                                            */
/*==============================================================*/
create table RTRANSACT (
   REMBOURSEMENTID      int                  not null,
   TRANSACTIONID        int                  not null,
   constraint PK_RTRANSACT primary key (REMBOURSEMENTID, TRANSACTIONID)
)
go

/*==============================================================*/
/* Index : TRAQUER_FK                                           */
/*==============================================================*/




create nonclustered index TRAQUER_FK on RTRANSACT (REMBOURSEMENTID ASC)
go

/*==============================================================*/
/* Index : TRAQUER2_FK                                          */
/*==============================================================*/




create nonclustered index TRAQUER2_FK on RTRANSACT (TRANSACTIONID ASC)
go

/*==============================================================*/
/* Table : "TRANSACTION"                                        */
/*==============================================================*/
create table "TRANSACTION" (
   TRANSACTIONID        int                  not null,
   CODE                 nvarchar(100)        null,
   TYPE                 smallint             null,
   MODE                 smallint             null,
   TRANSACTSTATUT       smallint             null,
   TRANSACTCREA         datetime             null,
   TRANSACTMODIF        datetime             null,
   TRANSACTCONTENU      nvarchar(255)        null,
   constraint PK_TRANSACTION primary key (TRANSACTIONID)
)
go

alter table AVIS
   add constraint FK_AVIS_AVIS_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table AVIS
   add constraint FK_AVIS_AVIS2_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table AVIS
   add constraint FK_AVIS_AVIS3_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table BOUTIQUE
   add constraint FK_BOUTIQUE_APPLIQUER_POLITIQU foreign key (POLITIQUEID)
      references POLITIQUE (POLITIQUEID)
go

alter table BOUTIQUE
   add constraint FK_BOUTIQUE_CREER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table CATNAV
   add constraint FK_CATNAV_REGROUPER1_CATEGORI foreign key (CATEGORIEID)
      references CATEGORIE (CATEGORIEID)
go

alter table CATNAV
   add constraint FK_CATNAV_REGROUPER2_CATEGORI foreign key (CAT_PARENTID)
      references CATEGORIE (CATEGORIEID)
go

alter table CMDBTQDETAIL
   add constraint FK_CMDBTQDE_COMPORTER_COMMANDE foreign key (CMDBTQID)
      references COMMANDEBOUTIQUE (CMDBTQID)
go

alter table CMDBTQDETAIL
   add constraint FK_CMDBTQDE_COMPORTER_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table CMDBTQDETAIL
   add constraint FK_CMDBTQDE_COMPORTER_LIVRAISO foreign key (LIVRAISONID)
      references LIVRAISON (LIVRAISONID)
go

alter table CMDCLTDETAIL
   add constraint FK_CMDCLTDE_LISTER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table CMDCLTDETAIL
   add constraint FK_CMDCLTDE_LISTER2_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table CMDCLTDETAIL
   add constraint FK_CMDCLTDE_LISTER3_LIVRAISO foreign key (LIVRAISONID)
      references LIVRAISON (LIVRAISONID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_ASSOCIER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_COMPRENDR_ETATCMD foreign key (ETATID)
      references ETATCMD (ETATID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_ENGENDRER_LITIGE foreign key (LITIGEID)
      references LITIGE (LITIGEID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_RECEVOIR_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_DETENIR_ETATCMD foreign key (ETATID)
      references ETATCMD (ETATID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_GENERER2_FACTURE foreign key (FACTUREID)
      references FACTURE (FACTUREID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_PASSER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_PRENDRE2_PAIEMENT foreign key (PAIEMENTID)
      references PAIEMENT (PAIEMENTID)
go

alter table ECHANGE
   add constraint FK_ECHANGE_ECHANGE_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table ECHANGE
   add constraint FK_ECHANGE_ECHANGE2_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table ECHANGE
   add constraint FK_ECHANGE_ECHANGE3_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table FACTURE
   add constraint FK_FACTURE_GENERER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table IDENTIFICATION
   add constraint FK_IDENTIFI_ETRE_CIVILITE foreign key (CIVID)
      references CIVILITE (CIVID)
go

alter table IDENTIFICATION
   add constraint FK_IDENTIFI_IDENTIFIE_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table LITIGE
   add constraint FK_LITIGE_DONNER2_REMBOURS foreign key (REMBOURSEMENTID)
      references REMBOURSEMENT (REMBOURSEMENTID)
go

alter table LITIGE
   add constraint FK_LITIGE_ENGENDRER_COMMANDE foreign key (CMDBTQID)
      references COMMANDEBOUTIQUE (CMDBTQID)
go

alter table LITIGE
   add constraint FK_LITIGE_ENVOYER2_REMPLACE foreign key (RETOURID)
      references REMPLACEMENT (RETOURID)
go

alter table LIVRAISON
   add constraint FK_LIVRAISO_CARACTERI_LIVRAISO foreign key (LVRETATID)
      references LIVRAISONETAT (LVRETATID)
go

alter table LIVRAISON
   add constraint FK_LIVRAISO_DEFINIR_LIVRAISO foreign key (LVRTYPID)
      references LIVRAISONTYPE (LVRTYPID)
go

alter table LIVRAISON
   add constraint FK_LIVRAISO_DESTINER_LOCALISA foreign key (LOCALISATIONID)
      references LOCALISATION (LOCALISATIONID)
go

alter table LOCALISATION
   add constraint FK_LOCALISA_POSSEDER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table LOCALISATION
   add constraint FK_LOCALISA_SITUER_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table MEDIA
   add constraint FK_MEDIA_BOUTMEDIA_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table MEDIA
   add constraint FK_MEDIA_LTGMEDIA_LITIGE foreign key (LITIGEID)
      references LITIGE (LITIGEID)
go

alter table MEDIA
   add constraint FK_MEDIA_PRODMEDIA_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table MOYENDEPAIEMENT
   add constraint FK_MOYENDEP_UTILISER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table PAIEMENT
   add constraint FK_PAIEMENT_PRENDRE_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table PAIEMENT
   add constraint FK_PAIEMENT_REGLER_MOYENDEP foreign key (MDPID)
      references MOYENDEPAIEMENT (MDPID)
go

alter table PANDETAIL
   add constraint FK_PANDETAI_CONTENIR_PANIER foreign key (PANIERID)
      references PANIER (PANIERID)
go

alter table PANDETAIL
   add constraint FK_PANDETAI_CONTENIR2_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table PANIER
   add constraint FK_PANIER_DISPOSER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table PARTENAIRE
   add constraint FK_PARTENAI_DISPOSER2_PANIER foreign key (PANIERID)
      references PANIER (PANIERID)
go

alter table POINTRELAIS
   add constraint FK_POINTREL_PROPOSER_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table POINTRELAIS
   add constraint FK_POINTREL_PROPOSER2_LOCALISA foreign key (LOCALISATIONID)
      references LOCALISATION (LOCALISATIONID)
go

alter table PRODUIT
   add constraint FK_PRODUIT_APPARTENI_CATEGORI foreign key (CATEGORIEID)
      references CATEGORIE (CATEGORIEID)
go

alter table PRODUIT
   add constraint FK_PRODUIT_AVOIR_LIVRAISO foreign key (LVRTYPID)
      references LIVRAISONTYPE (LVRTYPID)
go

alter table PRODUIT
   add constraint FK_PRODUIT_VENDRE_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table PTRANSACT
   add constraint FK_PTRANSAC_TRACER_PAIEMENT foreign key (PAIEMENTID)
      references PAIEMENT (PAIEMENTID)
go

alter table PTRANSACT
   add constraint FK_PTRANSAC_TRACER2_TRANSACT foreign key (TRANSACTIONID)
      references "TRANSACTION" (TRANSACTIONID)
go

alter table REMBOURSEMENT
   add constraint FK_REMBOURS_DONNER_LITIGE foreign key (LITIGEID)
      references LITIGE (LITIGEID)
go

alter table REMPLACEMENT
   add constraint FK_REMPLACE_ENVOYER_LITIGE foreign key (LITIGEID)
      references LITIGE (LITIGEID)
go

alter table RTRANSACT
   add constraint FK_RTRANSAC_TRAQUER_REMBOURS foreign key (REMBOURSEMENTID)
      references REMBOURSEMENT (REMBOURSEMENTID)
go

alter table RTRANSACT
   add constraint FK_RTRANSAC_TRAQUER2_TRANSACT foreign key (TRANSACTIONID)
      references "TRANSACTION" (TRANSACTIONID)
go

