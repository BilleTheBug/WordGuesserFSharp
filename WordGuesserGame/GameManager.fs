module GameManager

    open System
    open GuessController
    open WordGenerator
    open Config

    // returns user input from console. 
    //If [caseSens] is false, the input is returned in all lower case
    let GetInput caseSens : string = 
        let input = Console.ReadLine()  
        if caseSens then input else input.ToLower()

    // Prints out help and configurations
    let PrintHelp =
        printfn "Word guesser v2.0"
        printfn "Enter any character and hit <enter> to guess."
        printfn "Enter 'crtl-h' and hit <enter> to get helped with a correct guess."
        printfn "To enable/disable settings, edit the Config file."
        printfn "Current Configs:\nCASE SENSITIVITY -> %b\nHELP -> %b\nALLOW BLANKS -> %b\nMULTIPLE -> %b\nHIDDEN SYMBOL -> %c" 
                                    CASE_SENSITIVE HELP ALLOW_BLANKS MULTIPLE HIDDEN


    // Run the game once where the word to guess is [word]
    let OneGame word = 
        let mutable counter = 0
        let mutable guesses = [] 

        while HiddenCount (HiddenWord word guesses) > 0 do
            printfn "Word: %s, guesses %A, attemps %i" (HiddenWord word guesses) guesses counter
            let guess = GetInput Config.CASE_SENSITIVE |> string
            if guess.Length = 1 
            then guesses <- List.distinct (guesses @ [guess |> char]);counter <- counter+1
            else match guess with
                 | "crtl-h" -> if Config.HELP 
                               then guesses <- List.distinct (guesses @ [Help (HiddenWord word guesses) word] );counter <- counter+1 
                               else printfn "You are on your own."
                 | _ -> printfn "Your input was invalid."
  
        printfn "You guessed the word %s !!!!" word
        printfn "You guessed it in %d guesses..." counter

    // Starts the word guesser game, continuously invoking OneGame with a new random word
    // while mutable 'goOn' is true.
    let StartGame =
        let mutable goOn = true
        PrintHelp |> ignore
        while goOn do
            OneGame (GetWord())
            let mutable invalidInput = true
            while invalidInput do 
                printf "Try again?"
                let ch = Console.ReadLine() |> string
                match ch with
                | "n" -> goOn <- false; invalidInput <- false
                | "y" -> goOn <- true; invalidInput <- false
                | _ -> printfn("Your input was invalid.")