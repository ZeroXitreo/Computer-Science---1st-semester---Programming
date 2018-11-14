SELECT
	PET_OWNER.OwnerLastName,
	PET_OWNER.OwnerFirstName,
	PET_OWNER.OwnerEmail,
	BREED.AverageLifeExpectancy
FROM PET_OWNER

JOIN PET
ON PET.OwnerId = PET_OWNER.OwnerId

JOIN BREED
ON BREED.BreedName = PET.PetBreed

WHERE BREED.AverageLifeExpectancy >= 15