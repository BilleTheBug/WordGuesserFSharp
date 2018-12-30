namespace Console
open System


module Program = 

   let randomGenerator = Random()


   // Return a string based on [word] where all char's NOT in [guesses] will be replaced with
   // Config.HIDDEN
   let HiddenWord word guesses = String.map(fun ch -> if List.contains ch guesses then ch else Config.HIDDEN) word


   // return the amount of chars equals to Config.HIDDEN in [word]
   let HiddenCount word = (String.filter (fun ch -> ch = Config.HIDDEN) word).Length

   // Run the game once where the word to guess is [word]
   let OneGame word = 
       let mutable counter = 0
       let mutable guesses = []

       while HiddenCount (HiddenWord word guesses) > 0 do
          printfn "Word: %s, guesses %A" (HiddenWord word guesses) guesses
          let guess =  Console.ReadLine() |> char
          guesses <- List.distinct (guesses @ [guess])
          counter <- counter+1

       printfn "You guessed the word %s !!!!" word
       printfn "You guessed it in %d guesses..." counter
       ()

   [<EntryPoint>]
   let main argv =
       let mutable goOn = true
       printfn "Word guesser ver 0.1 "

       let word = Config.WORDS.[randomGenerator.Next(Config.WORDS.Length)]
       
       let hiddenWord = if Config.CASE_SENSITIVE then word else word.ToLower()

       while goOn do
          OneGame hiddenWord
          printf "Try again?"
          let ch = Console.ReadLine() |> char
          goOn <- ch <> 'n'
       0
