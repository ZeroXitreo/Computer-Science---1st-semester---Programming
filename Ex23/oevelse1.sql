DROP TABLE IF EXISTS PET
DROP TABLE IF EXISTS PET_OWNER



CREATE TABLE PET_OWNER
(
	OwnerId				int				NOT NULL IDENTITY(1,1) primary key
	,OwnerLastName		varchar(50)		NOT NULL
	,OwnerFirstName		varchar(50)		NOT NULL
	,OwnerPhone			varchar(12)
	,OwnerEmail			varchar(50)		NOT NULL
);

CREATE TABLE PET
(
	PetID				int				NOT NULL IDENTITY(1,1) primary key
	,PetName			varchar(50)		NOT NULL
	,PetType			varchar(50)		NOT NULL
	,PetBreed			varchar(50)		NOT NULL
	,PetDOB				datetime2
	,PetWeight			float			NOT NULL
	,OwnerId			int				NOT NULL

	,CONSTRAINT FK_PET_OWNER FOREIGN KEY (OwnerId)
		REFERENCES PET_OWNER (OwnerId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);