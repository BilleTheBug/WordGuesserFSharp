module GameManager

    open System
    open GuessController
    open WordGenerator

    // returns user input from console. 
    let GetInput caseSens : string = 
        let input = Console.ReadLine()  
        if caseSens then input else input.ToLower()

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

    let StartGame =
        let mutable goOn = true
        printfn "Word guesser ver 0.1 "

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