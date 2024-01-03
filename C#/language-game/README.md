# Language Game

## Task description

Implement a [TranslateToPigLatin](/LanguageGame/Translator.cs#L25) method that translates from English to [Pig Latin Language](https://en.wikipedia.org/wiki/Pig_Latin), that obeys a few simple following rules:
1. If a word begins with a vowel sound (`'a'`,`'o'`,`'e'`,`'i'`,`'u'`), add an `"yay"` sound to the end of the word (e.g. `"apple" -> "appleyay"`).
1. If a word begins with a consonant sound, move it to the end of the word and then add an `"ay"` sound to the end of the word. Consonant sounds can be made up of multiple consonants, a.k.a. a consonant cluster (e.g. `"chair" -> "airchay"`).   
The task definition is given in the XML-comments for the method.    

Notes:
- If a word begins with a capital letter, then its translation also begins with a capital letter, if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
- Do not use regular expression.