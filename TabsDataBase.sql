Create database Tabs;
go
use Tabs;

--Client Table
Create Table Client(
	code int primary key identity,
	civilite nvarchar(50) not null,
	raisonSocial nvarchar(50) not null,
	prenom nvarchar(50) not null,
	nom nvarchar(50) not null,
	adresse nvarchar(50) not null,
	adresse2 nvarchar(50) not null,
	pays nvarchar(50) not null,
	ville nvarchar(50) not null,
	codePostal nvarchar(50) not null,
	DN Date not null,
	genre nvarchar(50) not null,
	status nvarchar(50) not null,
	tel nvarchar(50) not null,
	mobile nvarchar(50) not null,
	fax nvarchar(50) not null,
	email nvarchar(50) not null,
	url nvarchar(50) not null,
	activite nvarchar(50) not null,
	siret nvarchar(50) not null,
	codeAPE nvarchar(50) not null,
	TVAIntra nvarchar(50) not null,
);

/*
Create Table Factue(
	code int primary key identity,
	raisonSocial nvarchar(50) not null,
	prenom nvarchar(50) not null,
	nom nvarchar(50) not null,
	adresse nvarchar(50) not null,
	adresse2 nvarchar(50) not null,
	codePostal nvarchar(50) not null,
	ville nvarchar(50) not null,
	pays nvarchar(50) not null,
	activite nvarchar(50) not null,
	DN Date not null,
	tel nvarchar(50) not null,
	mobile nvarchar(50) not null,
	fax nvarchar(50) not null,
	email nvarchar(50) not null,
	url nvarchar(50) not null,
);
*/
------------------------------------------------

Create Table Facture( /*--Facture Table*/
	exercice int primary key identity,
	etat nvarchar(50) not null,
	numero nvarchar(50) not null,
	dateCreation Date not null,
	dateFermeteur Date not null,
	dateValidite Date not null,

	dateImprime DateTime not null,
	dateenvoi DateTime not null,
	dateAccept DateTime not null,

	Imprime nvarchar(50) not null,
	Envoi nvarchar(50) not null,
	Accept nvarchar(50) not null,
	paimentDefault nvarchar(50) not null,
	--Contact
	tarif nvarchar(50) not null,
	totalHT nvarchar(50) not null,
	remiseGlobal nvarchar(50) not null,
	remiseGlobal1 nvarchar(50) not null,
	autoLiquidation bit not null,
	totalHT1 nvarchar(50) not null,
	Acomplet nvarchar(50) not null,
	netPayer nvarchar(50) not null,
	--plus
	aderessage nvarchar(50) not null,
	observations nvarchar(50) not null,
	conditionPaiement nvarchar(50) not null,
	annotation nvarchar(50) not null,
);

-- Devis Table
Create Table Devis(
	exercice int primary key identity,
	etat nvarchar(50) not null,
	numero nvarchar(50) not null,
	dateCreation Date not null,
	dateFermeteur Date not null,
	dateValidite Date not null,

	dateImprime DateTime not null,
	dateenvoi DateTime not null,
	dateAccept DateTime not null,

	Imprime nvarchar(50) not null,
	Envoi nvarchar(50) not null,
	Accept nvarchar(50) not null,
	paimentDefault nvarchar(50) not null,
	--Contact
	tarif nvarchar(50) not null,
	totalHT nvarchar(50) not null,
	remiseGlobal nvarchar(50) not null,
	remiseGlobal1 nvarchar(50) not null,
	autoLiquidation bit not null,
	totalHT1 nvarchar(50) not null,
	Acomplet nvarchar(50) not null,
	netPayer nvarchar(50) not null,
	--plus
	aderessage nvarchar(50) not null,
	observations nvarchar(50) not null,
	conditionPaiement nvarchar(50) not null,
	annotation nvarchar(50) not null,
);

--Produit Table

Create Table Produit(
	--Info
	ref int primary key identity,
	unite nvarchar(50) not null,
	designation nvarchar(50) not null,
	famile nvarchar(50)  not null,
	fournisseur nvarchar(50)  not null,
	pAchat Int not null,
	--Tarif 
	pVente nvarchar(50) not null,
	mergeEnTax int not null,
	tax nvarchar(50)  not null,
	totalTTC INT not null,
	--produit Image
	img nvarchar(4000) ,
);

use Tabs
SELECT ref, unite, designation, pVente, totalTTC, pAchat, famile, fournisseur FROM Produit;
select * From Produit

insert into Produit (unite, designation, famile, fournisseur, pAchat, pVente, mergeEnTax, tax, totalTTC, img) values(2, 'computer', 'info', 'Amin', 100, 200, 300, 400, 500, 'C:\Users\DELL\ElgountariAyoub\NestedFolders\DestopWallpaper\Thinking\code-hacker-1366x768.jpg')

Delete From Produit Where unite=2