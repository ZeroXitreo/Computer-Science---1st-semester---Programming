INSERT INTO PET_OWNER(OwnerLastName, OwnerFirstName, OwnerPhone, OwnerEmail)
VALUES
	('Downs', 'Marsha', '555 537 8765', 'Marsha.Downs@somewhere.com')
	,('James', 'Richard', '555 537 7654', 'Richard.James@somewhere.som')
	,('Frier', 'Liz', '555 537 6543', 'Liz.Frier@somewhere.com')
	,('Trent', 'Miles', NULL, 'Miles.Trent@somewhere.com')
;

INSERT INTO PET(PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerId)
VALUES
	('King', 'Dog', 'Std. Poodle', '21.02.2011', 25.5, 1)
	,('Teddy', 'Cat', 'Cashmere', '01.02.2012', 10.5, 2)
	,('Fido', 'Dog', 'Std. Poodle', '17.07.2010', 28.5, 1)
	,('AJ', 'Dog', 'Collie Mix', '05.05.2011', 20.0, 3)
	,('Cedro', 'Cat', 'Unknown', '06.06.2009', 9.5, 2)
	,('Wooley', 'Cat', 'Unknown', NULL, 9.5, 2)
	,('Buster', 'Dog', 'Border Collie', '11.12.2008', 25.0, 4)
;