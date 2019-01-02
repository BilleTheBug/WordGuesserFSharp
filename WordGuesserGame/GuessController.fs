module GuessController
    open System

    let randomGenerator = Random()

    // returns a correct guessed char that has not yet been guessed on
    let rec Help (hiddenWord : string) (word : string) = 
        let randomChar = word.[randomGenerator.Next(word.Length)] |> char
        match hiddenWord.Contains randomChar with
        | true -> Help hiddenWord word
        | false -> randomChar


    // Return a string based on [word] where all char's NOT in [guesses] will be replaced with
    // Config.HIDDEN
    let HiddenWord word guesses = String.map(fun ch -> if List.contains ch guesses then ch else Config.HIDDEN) word 

    let StringContains (str : string) (guess : string) = match str.IndexOf(guess) with 
                                                            | -1 -> false
                                                            | _ -> true                          

    // return the amount of chars equals to Config.HIDDEN in [word]
    let HiddenCount word = (String.filter (fun ch -> ch = Config.HIDDEN) word).Length