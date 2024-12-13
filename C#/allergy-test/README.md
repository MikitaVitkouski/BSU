# Allergy Test

## Task description

Implement a [IsAllergicTo](AllergyTest/Allergies.cs#L26) method that determines on base on the allergy test score for the given person whether or not they're allergic to a given item and a [AllergensList](AllergyTest/Allergies.cs#L36) method that determines their full list of allergies. Allergy test is represented by a single numeric score which contains the information about all the allergies the person has (that they were tested for). The list of allergens for test are ([Allergens](AllergyTest/Allergens.cs#L6)):
- eggs (with value `1`)
- peanuts (with value `2`)
- shellfish (with value `4`)
- strawberries (with value `8`)
- tomatoes (with value `16`)
- chocolate (with value `32`)
- pollen (with value `64`)
- cats (with value `128`)     
**Note**: a given score may include allergens not listed above (i.e. allergens that score `256`, `512`, `1024`, etc.). Your method should ignore those components of the score. For example, if the allergy score is `257`, your program should only report the `eggs` (with value 1) allergy. The task definition is given in the XML-comments for the method.    
_Don't use LINQ._