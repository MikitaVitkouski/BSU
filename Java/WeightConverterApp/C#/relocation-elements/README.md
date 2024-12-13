# Relocation Elements

## Task description

Implement the [MoveToTail](RelocationElements/ArrayExtension.cs#L17) method moves all the elements of an integer array by the specified `value` to the end, while maintaining the order of other elements. Do not use additional arrays. *The task definition is given in the XML-comments for the method.*
            
`{1, 2, 0, 1, 0, 1, 0, 3, 0, 1} for value = 0 =>  {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}  `   
`{1, 2, 3, 4, 5, 3, 2, 3, 1, 3, 4, 5, 1, 5, 0, 7, 6, 5} for value = 3 => {1, 2, 4, 5, 2, 1, 4, 5, 1, 5, 0, 7, 6, 5, 3, 3, 3, 3}`