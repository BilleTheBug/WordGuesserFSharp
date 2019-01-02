namespace Console
open System

module Program = 

    let randomGenerator = Random()


    // Return a string based on [word] where all char's NOT in [guesses] will be replaced with
    // Config.HIDDEN
    let HiddenWord word guesses = String.map(fun ch -> if List.contains ch guesses then ch else Config.HIDDEN) word 

    let StringContains (str : string) (guess : string) = match str.IndexOf(guess) with 
                                                            | -1 -> false
                                                            | _ -> true                          

    // return the amount of chars equals to Config.HIDDEN in [word]
    let HiddenCount word = (String.filter (fun ch -> ch = Config.HIDDEN) word).Length

    // returns user input from console. 
    let GetInput caseSens : string = 
        let input = Console.ReadLine()  
        if caseSens then input else input.ToLower()

    // returns a correct guessed char that has not yet been guessed on
    let rec Help (hiddenWord : string) (word : string) = 
        let randomChar = word.[randomGenerator.Next(word.Length)] |> char
        match hiddenWord.Contains randomChar with
        | true -> Help hiddenWord word
        | false -> randomChar

    

    // Run the game once where the word to guess is [word]
    let OneGame word = 
        let mutable counter = 0
        let mutable guesses = [] 

        while HiddenCount (HiddenWord word guesses) > 0 do
            printfn "Word: %s, guesses %A" (HiddenWord word guesses) guesses
            let guess = GetInput Config.CASE_SENSITIVE |> string
            match guess.Length with
            | 1 -> guesses <- List.distinct (guesses @ [guess |> char]);counter <- counter+1
            | _ -> 
            match guess with
            | "crtl-h" -> guesses <- List.distinct (guesses @ [Help (HiddenWord word guesses) word] );counter <- counter+1
            | _ -> printfn "Your input was invalid."
        
                
            

        printfn "You guessed the word %s !!!!" word
        printfn "You guessed it in %d guesses..." counter

    [<EntryPoint>]
    let main argv =
        let mutable goOn = true
        printfn "Word guesser ver 0.1 "
        while goOn do
            let mutable word = Config.WORDS.[randomGenerator.Next(Config.WORDS.Length)] |> string
            word <- if Config.CASE_SENSITIVE then word else word.ToLower()
            OneGame word
            let mutable invalidInput = true
            while invalidInput do 
                printf "Try again?"
                let ch = Console.ReadLine() |> string
                match ch with
                | "n" -> goOn <- false; invalidInput <- false
                | "y" -> goOn <- true; invalidInput <- false
                | _ -> printfn("Your input was invalid.")
        0

