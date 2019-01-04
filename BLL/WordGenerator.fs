module WordGenerator
    open System
    let randomGenerator = Random()

    let GetRandomWord() = match Config.ALLOW_BLANKS with
                                    |true -> Config.WORDS.[randomGenerator.Next(Config.WORDS.Length)]
                                    |false -> Config.WORDS_WITHOUT_SPACES.[randomGenerator.Next(Config.WORDS_WITHOUT_SPACES.Length)]

    let GetWord() = if Config.CASE_SENSITIVE then GetRandomWord() else GetRandomWord().ToLower()