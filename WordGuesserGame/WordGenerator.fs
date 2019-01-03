module WordGenerator
    open System
    let randomGenerator = Random()

    // Return a string based on [word] where all char's NOT in [guesses] will be replaced with Config.HIDDEN
    let HiddenWord word guesses = String.map(fun ch -> if List.contains ch guesses then ch else Config.HIDDEN) word 

    let GetRandomWord() = match Config.ALLOW_BLANKS with
                                    |true -> Config.WORDS.[randomGenerator.Next(Config.WORDS.Length)]
                                    |false -> Config.WORDS_WITHOUT_SPACES.[randomGenerator.Next(Config.WORDS_WITHOUT_SPACES.Length)]

    let GetWord() = if Config.CASE_SENSITIVE then GetRandomWord() else GetRandomWord().ToLower()