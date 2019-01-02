module WordGenerator

    // Return a string based on [word] where all char's NOT in [guesses] will be replaced with
    // Config.HIDDEN
    let HiddenWord word guesses = String.map(fun ch -> if List.contains ch guesses then ch else Config.HIDDEN) word 

