SELECT
	PET_OWNER.OwnerLastName,
	PET_OWNER.OwnerFirstName,
	PET_OWNER.OwnerEmail,
	BREED.AverageLifeExpectancy
FROM PET_OWNER

LEFT JOIN PET
ON PET.OwnerId = PET_OWNER.OwnerId

LEFT JOIN BREED
ON BREED.BreedName = PET.PetBreed

WHERE BREED.AverageLifeExpectancy >= 15