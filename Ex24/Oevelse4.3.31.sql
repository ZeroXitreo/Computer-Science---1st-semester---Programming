SELECT
	MIN(PetWeight) AS Minimum,
	MAX(PetWeight) AS Maximum,
	AVG(PetWeight) AS Average
FROM PET
WHERE PetType = 'Dog'