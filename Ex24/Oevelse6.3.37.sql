DROP TABLE IF EXISTS BREED;

CREATE TABLE BREED
(
	BreedName				varchar(50)		primary key
	,MinWeight				float			NULL
	,MaxWeight				float			NULL
	,AverageLifeExpectancy	float			NULL
);

INSERT INTO BREED (BreedName, MinWeight, MaxWeight, AverageLifeExpectancy) VALUES
('Border Collie', 15.0, 22.5, 20),
('Cashmere', 10.0, 15.0, 12),
('Collie Mix', 17.5, 25.0, 18),
('Std. Poodle', 22.5, 30.0, 18),
('Unknown', NULL, NULL, NULL);



ALTER TABLE PET
ADD CONSTRAINT FK_PET_BREED FOREIGN KEY (PetBreed)
		REFERENCES BREED (BreedName)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
