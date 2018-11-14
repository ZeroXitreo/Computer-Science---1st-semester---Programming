SELECT
	PetBreed,
	AVG(PetWeight) AS Average,
	COUNT(PetBreed) AS AmountPets
FROM PET

GROUP BY PetBreed

HAVING COUNT(PetBreed) > 1