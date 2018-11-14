SELECT
	PetName,
	PetBreed,
	PetType
FROM PET
WHERE PetType != 'Dog'
AND PetType != 'Cat'
AND PetType != 'Fish'