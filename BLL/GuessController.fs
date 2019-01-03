module GuessController
    open System

    let randomGenerator = Random()

    // returns a correct guessed char that has not yet been guessed on
    let rec Help (hiddenWord : string) (word : string) = 
        let randomChar = word.[randomGenerator.Next(word.Length)] |> char
        match hiddenWord.Contains randomChar with
        | true -> Help hiddenWord word
        | false -> randomChar

    //let StringContains (word : string) (hiddenWord: string) (guess : string) = match word.IndexOf(guess) with 
    //                                                        | -1 -> ""
    //                                                        | _ ->  let startIndex = word.IndexOf(guess) 
    //                                                                for i in 0..guess.Length do
    //                                                                   hiddenWord.[startIndex + i] <- guess.[i]
    //                                                                hiddenWord

    // return the amount of chars equals to Config.HIDDEN in [word]
    let HiddenCount word = (String.filter (fun ch -> ch = Config.HIDDEN) word).Length
