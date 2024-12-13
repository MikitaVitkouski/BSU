# Search By Pattern In Text

## Task description

Implement a [SearchPatternString](SearchByPatternInText/Searcher.cs#L18) extension method that searches the pattern inside the text and  collect information about all hit positions in the order they appear. If `overlap` flag is true collect every position overlapping included, if false no overlapping is allowed (next search behind). The task definition is given in the XML-comments for the method. _Do not use regular expressions._