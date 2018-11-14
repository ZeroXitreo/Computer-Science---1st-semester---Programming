SELECT
	PetBreed,
	AVG(PetWeight) AS Average
FROM PET

GROUP BY PetBreed