/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2016                     */
/* Date de création :  09/03/2021 12:21:47                      */
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
   where r.fkeyid = object_id('BTQPTR') and o.name = 'FK_BTQPTR_PROPOSER_BOUTIQUE')
alter table BTQPTR
   drop constraint FK_BTQPTR_PROPOSER_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BTQPTR') and o.name = 'FK_BTQPTR_PROPOSER2_LOCALISA')
alter table BTQPTR
   drop constraint FK_BTQPTR_PROPOSER2_LOCALISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CATCAT') and o.name = 'FK_CATCAT_REGROUPER_CATEGORI')
alter table CATCAT
   drop constraint FK_CATCAT_REGROUPER_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CATCAT') and o.name = 'FK_CATCAT_REGROUPER_CATEGORI')
alter table CATCAT
   drop constraint FK_CATCAT_REGROUPER_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQPROD') and o.name = 'FK_CMDBTQPR_COMPORTER_COMMANDE')
alter table CMDBTQPROD
   drop constraint FK_CMDBTQPR_COMPORTER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQPROD') and o.name = 'FK_CMDBTQPR_COMPORTER_PRODUIT')
alter table CMDBTQPROD
   drop constraint FK_CMDBTQPR_COMPORTER_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDBTQPROD') and o.name = 'FK_CMDBTQPR_COMPORTER_LIVRAISO')
alter table CMDBTQPROD
   drop constraint FK_CMDBTQPR_COMPORTER_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTPROD') and o.name = 'FK_CMDCLTPR_LISTER_COMMANDE')
alter table CMDCLTPROD
   drop constraint FK_CMDCLTPR_LISTER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTPROD') and o.name = 'FK_CMDCLTPR_LISTER2_PRODUIT')
alter table CMDCLTPROD
   drop constraint FK_CMDCLTPR_LISTER2_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CMDCLTPROD') and o.name = 'FK_CMDCLTPR_LISTER3_LIVRAISO')
alter table CMDCLTPROD
   drop constraint FK_CMDCLTPR_LISTER3_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_ASSOCIER_COMMANDE')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_ASSOCIER_COMMANDE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDEBOUTIQUE') and o.name = 'FK_COMMANDE_RECEVOIR_BOUTIQUE')
alter table COMMANDEBOUTIQUE
   drop constraint FK_COMMANDE_RECEVOIR_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMMANDECLIENT') and o.name = 'FK_COMMANDE_CHOISIR_LOCALISA')
alter table COMMANDECLIENT
   drop constraint FK_COMMANDE_CHOISIR_LOCALISA
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
   where r.fkeyid = object_id('LOCALISATION') and o.name = 'FK_LOCALISA_ASSOCIATI_BOUTIQUE')
alter table LOCALISATION
   drop constraint FK_LOCALISA_ASSOCIATI_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOCALISATION') and o.name = 'FK_LOCALISA_POSSEDER_PARTENAI')
alter table LOCALISATION
   drop constraint FK_LOCALISA_POSSEDER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDIA') and o.name = 'FK_MEDIA_BOUTMEDIA_BOUTIQUE')
alter table MEDIA
   drop constraint FK_MEDIA_BOUTMEDIA_BOUTIQUE
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
   where r.fkeyid = object_id('PANIER') and o.name = 'FK_PANIER_DISPOSER_PARTENAI')
alter table PANIER
   drop constraint FK_PANIER_DISPOSER_PARTENAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANIER') and o.name = 'FK_PANIER_LIER2_SESSION')
alter table PANIER
   drop constraint FK_PANIER_LIER2_SESSION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANPROD') and o.name = 'FK_PANPROD_CONTENIR_PANIER')
alter table PANPROD
   drop constraint FK_PANPROD_CONTENIR_PANIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PANPROD') and o.name = 'FK_PANPROD_CONTENIR2_PRODUIT')
alter table PANPROD
   drop constraint FK_PANPROD_CONTENIR2_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARTENAIRE') and o.name = 'FK_PARTENAI_DISPOSER2_PANIER')
alter table PARTENAIRE
   drop constraint FK_PARTENAI_DISPOSER2_PANIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODLIVR') and o.name = 'FK_PRODLIVR_AVOIR_PRODUIT')
alter table PRODLIVR
   drop constraint FK_PRODLIVR_AVOIR_PRODUIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODLIVR') and o.name = 'FK_PRODLIVR_AVOIR2_LIVRAISO')
alter table PRODLIVR
   drop constraint FK_PRODLIVR_AVOIR2_LIVRAISO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUIT') and o.name = 'FK_PRODUIT_APPARTENI_CATEGORI')
alter table PRODUIT
   drop constraint FK_PRODUIT_APPARTENI_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUIT') and o.name = 'FK_PRODUIT_VENDRE_BOUTIQUE')
alter table PRODUIT
   drop constraint FK_PRODUIT_VENDRE_BOUTIQUE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SESSION') and o.name = 'FK_SESSION_LIER_PANIER')
alter table SESSION
   drop constraint FK_SESSION_LIER_PANIER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"TRANSACTION"') and o.name = 'FK_TRANSACT_REGLER_MOYENDEP')
alter table "TRANSACTION"
   drop constraint FK_TRANSACT_REGLER_MOYENDEP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"TRANSACTION"') and o.name = 'FK_TRANSACT_TRACER_COMMANDE')
alter table "TRANSACTION"
   drop constraint FK_TRANSACT_TRACER_COMMANDE
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
            from  sysobjects
           where  id = object_id('BOUTIQUE')
            and   type = 'U')
   drop table BOUTIQUE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BTQPTR')
            and   name  = 'PROPOSER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index BTQPTR.PROPOSER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BTQPTR')
            and   name  = 'PROPOSER_FK'
            and   indid > 0
            and   indid < 255)
   drop index BTQPTR.PROPOSER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BTQPTR')
            and   type = 'U')
   drop table BTQPTR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CATCAT')
            and   name  = 'CAT_PARENTID'
            and   indid > 0
            and   indid < 255)
   drop index CATCAT.CAT_PARENTID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATCAT')
            and   type = 'U')
   drop table CATCAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIE')
            and   type = 'U')
   drop table CATEGORIE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CIVILITE')
            and   type = 'U')
   drop table CIVILITE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQPROD')
            and   name  = 'COMPORTER3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQPROD.COMPORTER3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQPROD')
            and   name  = 'COMPORTER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQPROD.COMPORTER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDBTQPROD')
            and   name  = 'COMPORTER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDBTQPROD.COMPORTER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CMDBTQPROD')
            and   type = 'U')
   drop table CMDBTQPROD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTPROD')
            and   name  = 'LISTER3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTPROD.LISTER3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTPROD')
            and   name  = 'LISTER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTPROD.LISTER2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CMDCLTPROD')
            and   name  = 'LISTER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CMDCLTPROD.LISTER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CMDCLTPROD')
            and   type = 'U')
   drop table CMDCLTPROD
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
            and   name  = 'CHOISIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMMANDECLIENT.CHOISIR_FK
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
            from  sysobjects
           where  id = object_id('LIVRAISON')
            and   type = 'U')
   drop table LIVRAISON
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
            and   name  = 'ASSOCIATION_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOCALISATION.ASSOCIATION_12_FK
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
           where  id    = object_id('PANIER')
            and   name  = 'LIER2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANIER.LIER2_FK
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
           where  id    = object_id('PANPROD')
            and   name  = 'CONTENIR2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANPROD.CONTENIR2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PANPROD')
            and   name  = 'CONTENIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PANPROD.CONTENIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PANPROD')
            and   type = 'U')
   drop table PANPROD
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
           where  id    = object_id('PRODLIVR')
            and   name  = 'AVOIR2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODLIVR.AVOIR2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODLIVR')
            and   name  = 'AVOIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODLIVR.AVOIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODLIVR')
            and   type = 'U')
   drop table PRODLIVR
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
           where  id    = object_id('SESSION')
            and   name  = 'LIER_FK'
            and   indid > 0
            and   indid < 255)
   drop index SESSION.LIER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SESSION')
            and   type = 'U')
   drop table SESSION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"TRANSACTION"')
            and   name  = 'ASSOCIATION_30_FK'
            and   indid > 0
            and   indid < 255)
   drop index "TRANSACTION".ASSOCIATION_30_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"TRANSACTION"')
            and   name  = 'REGLER_FK'
            and   indid > 0
            and   indid < 255)
   drop index "TRANSACTION".REGLER_FK
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
   PRODID               bigint               not null,
   PARTENAIREID         bigint               not null,
   BTQID                bigint               not null,
   AVISNOTE             smallint             null,
   AVISDATE             datetime             null,
   AVISTEXTE            varchar(255)         null,
   AVISREPONSE          varchar(255)         null,
   AVISREPDATE          datetime             null,
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
   BTQID                bigint               not null,
   RAISONSOCIALE        varchar(255)         null,
   SIRET                varchar(14)          null,
   SIREN                varchar(9)           null,
   BTQTEL               varchar(15)          null,
   CODENAF              varchar(5)           null,
   CODEBANQUE           varchar(5)           null,
   CODEGUICHET          varchar(5)           null,
   NUMCOMPTE            varchar(11)          null,
   CLERIB               varchar(2)           null,
   DOMICILIATION        varchar(24)          null,
   IBAN                 varchar(27)          null,
   BIC                  varchar(11)          null,
   TITULAIRE            varchar(140)         null,
   BTQTMAIL             varchar(255)         null,
   BTQMESSAGE           varchar(255)         null,
   CA                   int                  null,
   NBSALARIE            int                  null,
   SITEWEB              varchar(100)         null,
   STATUTJURIDIQUE      varchar(25)          null,
   BTQSEO               varchar(100)         null,
   constraint PK_BOUTIQUE primary key (BTQID)
)
go

/*==============================================================*/
/* Table : BTQPTR                                               */
/*==============================================================*/
create table BTQPTR (
   BTQID                bigint               not null,
   LOCALISATIONID       bigint               not null,
   constraint PK_BTQPTR primary key (BTQID, LOCALISATIONID)
)
go

/*==============================================================*/
/* Index : PROPOSER_FK                                          */
/*==============================================================*/




create nonclustered index PROPOSER_FK on BTQPTR (BTQID ASC)
go

/*==============================================================*/
/* Index : PROPOSER2_FK                                         */
/*==============================================================*/




create nonclustered index PROPOSER2_FK on BTQPTR (LOCALISATIONID ASC)
go

/*==============================================================*/
/* Table : CATCAT                                               */
/*==============================================================*/
create table CATCAT (
   CATEGORIEID          int                  not null,
   CAT_PARENTID         int                  not null,
   constraint PK_CATCAT primary key (CATEGORIEID, CAT_PARENTID)
)
go

/*==============================================================*/
/* Index : CAT_PARENTID                                         */
/*==============================================================*/




create nonclustered index CAT_PARENTID on CATCAT (CAT_PARENTID ASC)
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
/* Table : CIVILITE                                             */
/*==============================================================*/
create table CIVILITE (
   CIVID                smallint             not null,
   ABREGE               varchar(5)           null,
   COMPLET              varchar(15)          null,
   constraint PK_CIVILITE primary key (CIVID)
)
go

/*==============================================================*/
/* Table : CMDBTQPROD                                           */
/*==============================================================*/
create table CMDBTQPROD (
   CMDBTQID             bigint               not null,
   PRODID               bigint               not null,
   LIVRAISONID          bigint               not null,
   B_QTEPROD            smallint             null,
   constraint PK_CMDBTQPROD primary key (CMDBTQID, PRODID, LIVRAISONID)
)
go

/*==============================================================*/
/* Index : COMPORTER_FK                                         */
/*==============================================================*/




create nonclustered index COMPORTER_FK on CMDBTQPROD (CMDBTQID ASC)
go

/*==============================================================*/
/* Index : COMPORTER2_FK                                        */
/*==============================================================*/




create nonclustered index COMPORTER2_FK on CMDBTQPROD (PRODID ASC)
go

/*==============================================================*/
/* Index : COMPORTER3_FK                                        */
/*==============================================================*/




create nonclustered index COMPORTER3_FK on CMDBTQPROD (LIVRAISONID ASC)
go

/*==============================================================*/
/* Table : CMDCLTPROD                                           */
/*==============================================================*/
create table CMDCLTPROD (
   CMDCLTID             bigint               not null,
   PRODID               bigint               not null,
   LIVRAISONID          bigint               not null,
   CMDQTEPROD           smallint             null,
   constraint PK_CMDCLTPROD primary key (CMDCLTID, PRODID, LIVRAISONID)
)
go

/*==============================================================*/
/* Index : LISTER_FK                                            */
/*==============================================================*/




create nonclustered index LISTER_FK on CMDCLTPROD (CMDCLTID ASC)
go

/*==============================================================*/
/* Index : LISTER2_FK                                           */
/*==============================================================*/




create nonclustered index LISTER2_FK on CMDCLTPROD (PRODID ASC)
go

/*==============================================================*/
/* Index : LISTER3_FK                                           */
/*==============================================================*/




create nonclustered index LISTER3_FK on CMDCLTPROD (LIVRAISONID ASC)
go

/*==============================================================*/
/* Table : COMMANDEBOUTIQUE                                     */
/*==============================================================*/
create table COMMANDEBOUTIQUE (
   CMDBTQID             bigint               not null,
   CMDCLTID             bigint               null,
   BTQID                bigint               not null,
   CMDBTQETAT           varchar(15)          null,
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
/* Table : COMMANDECLIENT                                       */
/*==============================================================*/
create table COMMANDECLIENT (
   CMDCLTID             bigint               not null,
   LOCALISATIONID       bigint               not null,
   PARTENAIREID         bigint               not null,
   FACTUREID            bigint               null,
   CMDCLTDATE           datetime             null,
   CMDCLTETAT           varchar(15)          null,
   SUIVI                varchar(255)         null,
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
/* Index : CHOISIR_FK                                           */
/*==============================================================*/




create nonclustered index CHOISIR_FK on COMMANDECLIENT (LOCALISATIONID ASC)
go

/*==============================================================*/
/* Table : ECHANGE                                              */
/*==============================================================*/
create table ECHANGE (
   PARTENAIREID         bigint               not null,
   PRODID               bigint               not null,
   BTQID                bigint               not null,
   ECHGQUEST            varchar(255)         null,
   ECHREP               varchar(255)         null,
   ECHGQUESTDATE        datetime             null,
   ECHGREPDATE          datetime             null,
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
/* Table : FACTURE                                              */
/*==============================================================*/
create table FACTURE (
   FACTUREID            bigint               not null,
   CMDCLTID             bigint               not null,
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
   IDENTID              bigint               not null,
   PARTENAIREID         bigint               not null,
   CIVID                smallint             not null,
   NOM                  varchar(70)          null,
   PRENOM               varchar(70)          null,
   EMAIL                varchar(255)         null,
   TEL                  varchar(15)          null,
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
/* Table : LIVRAISON                                            */
/*==============================================================*/
create table LIVRAISON (
   LIVRAISONID          bigint               not null,
   LIBRE                bit                  null,
   POINTRETRAITBTQ      bit                  null,
   constraint PK_LIVRAISON primary key (LIVRAISONID)
)
go

/*==============================================================*/
/* Table : LOCALISATION                                         */
/*==============================================================*/
create table LOCALISATION (
   LOCALISATIONID       bigint               not null,
   BTQID                bigint               not null,
   PARTENAIREID         bigint               not null,
   ADRESSE              varchar(255)         null,
   RUE                  varchar(255)         null,
   NUM                  int                  null,
   VILLE                varchar(255)         null,
   CODEPOSTAL           smallint             null,
   PAYS                 varchar(255)         null,
   constraint PK_LOCALISATION primary key (LOCALISATIONID)
)
go

/*==============================================================*/
/* Index : ASSOCIATION_12_FK                                    */
/*==============================================================*/




create nonclustered index ASSOCIATION_12_FK on LOCALISATION (BTQID ASC)
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
   MEDIAID              bigint               not null,
   PRODID               bigint               null,
   BTQID                bigint               null,
   LIEN                 varchar(255)         null,
   DESCRIPTION          varchar(255)         null,
   IMAGE                bit                  null,
   VIDEO                bit                  null,
   HTML                 varchar(255)         null,
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
/* Table : MOYENDEPAIEMENT                                      */
/*==============================================================*/
create table MOYENDEPAIEMENT (
   MDPID                bigint               not null,
   PARTENAIREID         bigint               not null,
   CB_NUM               varchar(16)          null,
   CVC                  varchar(4)           null,
   DATEEXP              datetime             null,
   CB_TITULAIRE         varchar(140)         null,
   CB_TYPE              varchar(30)          null,
   constraint PK_MOYENDEPAIEMENT primary key (MDPID)
)
go

/*==============================================================*/
/* Index : UTILISER_FK                                          */
/*==============================================================*/




create nonclustered index UTILISER_FK on MOYENDEPAIEMENT (PARTENAIREID ASC)
go

/*==============================================================*/
/* Table : PANIER                                               */
/*==============================================================*/
create table PANIER (
   PANIERID             bigint               not null,
   SESSIONID            bigint               null,
   PARTENAIREID         bigint               null,
   constraint PK_PANIER primary key (PANIERID)
)
go

/*==============================================================*/
/* Index : DISPOSER_FK                                          */
/*==============================================================*/




create nonclustered index DISPOSER_FK on PANIER (PARTENAIREID ASC)
go

/*==============================================================*/
/* Index : LIER2_FK                                             */
/*==============================================================*/




create nonclustered index LIER2_FK on PANIER (SESSIONID ASC)
go

/*==============================================================*/
/* Table : PANPROD                                              */
/*==============================================================*/
create table PANPROD (
   PANIERID             bigint               not null,
   PRODID               bigint               not null,
   P_QTEPROD            smallint             null,
   constraint PK_PANPROD primary key (PANIERID, PRODID)
)
go

/*==============================================================*/
/* Index : CONTENIR_FK                                          */
/*==============================================================*/




create nonclustered index CONTENIR_FK on PANPROD (PANIERID ASC)
go

/*==============================================================*/
/* Index : CONTENIR2_FK                                         */
/*==============================================================*/




create nonclustered index CONTENIR2_FK on PANPROD (PRODID ASC)
go

/*==============================================================*/
/* Table : PARTENAIRE                                           */
/*==============================================================*/
create table PARTENAIRE (
   PARTENAIREID         bigint               not null,
   PANIERID             bigint               null,
   VENDEUR              bit                  null,
   DATEENR              datetime             null,
   DATECON              datetime             null,
   constraint PK_PARTENAIRE primary key (PARTENAIREID)
)
go

/*==============================================================*/
/* Index : DISPOSER2_FK                                         */
/*==============================================================*/




create nonclustered index DISPOSER2_FK on PARTENAIRE (PANIERID ASC)
go

/*==============================================================*/
/* Table : PRODLIVR                                             */
/*==============================================================*/
create table PRODLIVR (
   PRODID               bigint               not null,
   LIVRAISONID          bigint               not null,
   constraint PK_PRODLIVR primary key (PRODID, LIVRAISONID)
)
go

/*==============================================================*/
/* Index : AVOIR_FK                                             */
/*==============================================================*/




create nonclustered index AVOIR_FK on PRODLIVR (PRODID ASC)
go

/*==============================================================*/
/* Index : AVOIR2_FK                                            */
/*==============================================================*/




create nonclustered index AVOIR2_FK on PRODLIVR (LIVRAISONID ASC)
go

/*==============================================================*/
/* Table : PRODUIT                                              */
/*==============================================================*/
create table PRODUIT (
   PRODID               bigint               not null,
   BTQID                bigint               not null,
   CATEGORIEID          int                  not null,
   PRIX                 decimal(8,2)         null,
   STOCK                smallint             null,
   DISPONIBILITE        smallint             null,
   RABAIS               smallint             null,
   PREPARATION          smallint             null,
   PRODSEO              varchar(100)         null,
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
/* Table : SESSION                                              */
/*==============================================================*/
create table SESSION (
   SESSIONID            bigint               not null,
   PANIERID             bigint               not null,
   SESSION              varchar(255)         null,
   constraint PK_SESSION primary key (SESSIONID)
)
go

/*==============================================================*/
/* Index : LIER_FK                                              */
/*==============================================================*/




create nonclustered index LIER_FK on SESSION (PANIERID ASC)
go

/*==============================================================*/
/* Table : "TRANSACTION"                                        */
/*==============================================================*/
create table "TRANSACTION" (
   TRANSACTIONID        bigint               not null,
   MDPID                bigint               not null,
   CMDCLTID             bigint               not null,
   CODE                 varchar(100)         null,
   TYPE                 smallint             null,
   MODE                 smallint             null,
   TRANSACTSTATUT       smallint             null,
   TRANSACTCREA         datetime             null,
   TRANSACTMODIF        datetime             null,
   TRANSACTCONTENU      varchar(255)         null,
   constraint PK_TRANSACTION primary key (TRANSACTIONID)
)
go

/*==============================================================*/
/* Index : REGLER_FK                                            */
/*==============================================================*/




create nonclustered index REGLER_FK on "TRANSACTION" (TRANSACTIONID ASC)
go

/*==============================================================*/
/* Index : ASSOCIATION_30_FK                                    */
/*==============================================================*/




create nonclustered index ASSOCIATION_30_FK on "TRANSACTION" (CMDCLTID ASC)
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

alter table BTQPTR
   add constraint FK_BTQPTR_PROPOSER_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table BTQPTR
   add constraint FK_BTQPTR_PROPOSER2_LOCALISA foreign key (LOCALISATIONID)
      references LOCALISATION (LOCALISATIONID)
go

alter table CATCAT
   add constraint FK_CATCAT_CATEGORI_PR foreign key (CATEGORIEID)
      references CATEGORIE (CATEGORIEID)
go

alter table CATCAT
   add constraint FK_CATCAT_CATEGORI_EF foreign key (CAT_PARENTID)
      references CATEGORIE (CATEGORIEID)
go

alter table CMDBTQPROD
   add constraint FK_CMDBTQPR_COMPORTER_COMMANDE foreign key (CMDBTQID)
      references COMMANDEBOUTIQUE (CMDBTQID)
go

alter table CMDBTQPROD
   add constraint FK_CMDBTQPR_COMPORTER_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table CMDBTQPROD
   add constraint FK_CMDBTQPR_COMPORTER_LIVRAISO foreign key (LIVRAISONID)
      references LIVRAISON (LIVRAISONID)
go

alter table CMDCLTPROD
   add constraint FK_CMDCLTPR_LISTER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table CMDCLTPROD
   add constraint FK_CMDCLTPR_LISTER2_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table CMDCLTPROD
   add constraint FK_CMDCLTPR_LISTER3_LIVRAISO foreign key (LIVRAISONID)
      references LIVRAISON (LIVRAISONID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_ASSOCIER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

alter table COMMANDEBOUTIQUE
   add constraint FK_COMMANDE_RECEVOIR_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_CHOISIR_LOCALISA foreign key (LOCALISATIONID)
      references LOCALISATION (LOCALISATIONID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_GENERER2_FACTURE foreign key (FACTUREID)
      references FACTURE (FACTUREID)
go

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_PASSER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
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

alter table LOCALISATION
   add constraint FK_LOCALISA_ASSOCIATI_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table LOCALISATION
   add constraint FK_LOCALISA_POSSEDER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table MEDIA
   add constraint FK_MEDIA_BOUTMEDIA_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table MEDIA
   add constraint FK_MEDIA_PRODMEDIA_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table MOYENDEPAIEMENT
   add constraint FK_MOYENDEP_UTILISER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table PANIER
   add constraint FK_PANIER_DISPOSER_PARTENAI foreign key (PARTENAIREID)
      references PARTENAIRE (PARTENAIREID)
go

alter table PANIER
   add constraint FK_PANIER_LIER2_SESSION foreign key (SESSIONID)
      references SESSION (SESSIONID)
go

alter table PANPROD
   add constraint FK_PANPROD_CONTENIR_PANIER foreign key (PANIERID)
      references PANIER (PANIERID)
go

alter table PANPROD
   add constraint FK_PANPROD_CONTENIR2_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table PARTENAIRE
   add constraint FK_PARTENAI_DISPOSER2_PANIER foreign key (PANIERID)
      references PANIER (PANIERID)
go

alter table PRODLIVR
   add constraint FK_PRODLIVR_AVOIR_PRODUIT foreign key (PRODID)
      references PRODUIT (PRODID)
go

alter table PRODLIVR
   add constraint FK_PRODLIVR_AVOIR2_LIVRAISO foreign key (LIVRAISONID)
      references LIVRAISON (LIVRAISONID)
go

alter table PRODUIT
   add constraint FK_PRODUIT_APPARTENI_CATEGORI foreign key (CATEGORIEID)
      references CATEGORIE (CATEGORIEID)
go

alter table PRODUIT
   add constraint FK_PRODUIT_VENDRE_BOUTIQUE foreign key (BTQID)
      references BOUTIQUE (BTQID)
go

alter table SESSION
   add constraint FK_SESSION_LIER_PANIER foreign key (PANIERID)
      references PANIER (PANIERID)
go

alter table "TRANSACTION"
   add constraint FK_TRANSACT_REGLER_MOYENDEP foreign key (MDPID)
      references MOYENDEPAIEMENT (MDPID)
go

alter table "TRANSACTION"
   add constraint FK_TRANSACT_TRACER_COMMANDE foreign key (CMDCLTID)
      references COMMANDECLIENT (CMDCLTID)
go

