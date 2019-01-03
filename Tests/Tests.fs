module Tests
    open Xunit
    open WordGenerator
    open System
    open Config
    open GuessController

    //          --WordGenerator Tests
    //          --HiddenWord--
    [<Fact>]
    //Tests if a word with all containing letters guessed comes back completely revealed
    let ``HiddenWord with all letters guessed``()=
        let expected = "bille"
        let actual = HiddenWord "bille" ['b';'i';'l';'e']
        Assert.Equal(expected, actual)

    //Tests if a word with no letters guessed comes back completely hidden
    [<Fact>]
    let ``HiddenWord with no letters guessed``()=
        let expected = "*****"
        let actual = HiddenWord "bille" []
        Assert.Equal(expected, actual)

    //Tests if a word with some letters guessed comes back partially hidden
    [<Fact>]
    let ``HiddenWord with half letters guessed``()=
        let expected = "b*ll*"
        let actual = HiddenWord "bille" ['b';'l']
        Assert.Equal(expected, actual)

    //Tests if a word with no correct letters guessed comes back completely hidden
    [<Fact>]
    let ``HiddenWord with no correct letters guessed``()=
        let expected = "*****"
        let actual = HiddenWord "bille" ['a';'c';'d';'f']
        Assert.Equal(expected, actual)

    //          --GetWord--
    //Tests if GetWord returns a string
    [<Fact>]
    let ``GetWord returns a string``()=
        let actual = GetWord()
        Assert.IsType<string> actual

    //Tests that the strings GetWord returns are not the same
    [<Fact>]
    let ``GetWord returns a random word in the selection``()=
        let words = [GetWord();GetWord();GetWord();GetWord();GetWord();GetWord();]
        Assert.True(words.[0] <> words.[1] || words.[1] <> words.[2] || words.[2] <> words.[3] || words.[3] <> words.[4] || words.[4] <> words.[5])


    //          --GuessController Tests
    //          --HiddenCount--

    [<Fact>]
    let ``HiddenCount returns 0, when no characters are equal Config.HIDDEN``()=
        let expected = 0
        let actual = HiddenCount "bille"
        Assert.Equal( expected, actual)

    [<Fact>]
    let ``HiddenCount returns 3, when 3 characters are equal Config.HIDDEN``()=
        let expected = 3
        let str = String.Join('l', [Config.HIDDEN; Config.HIDDEN; Config.HIDDEN])
        let actual = HiddenCount str
        Assert.Equal( expected, actual)

    //           --Help
    [<Fact>]
    let ``Help returns the missing character`` ()=
        let hiddenWord = "b*lle"
        let word = "bille"
        let expected = 'i'
        let actual = Help hiddenWord word
        Assert.Equal(expected, actual)