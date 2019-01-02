﻿module Tests
    open Xunit
    open WordGenerator
    open System
    open Config

    [<Fact>]
    let ``HiddenWord with all letters guessed``()=
        let expected = "bille"
        let actual = HiddenWord "bille" ['b';'i';'l';'e']
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``HiddenWord with no letters guessed``()=
        let expected = "*****"
        let actual = HiddenWord "bille" []
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``HiddenWord with half letters guessed``()=
        let expected = "b*ll*"
        let actual = HiddenWord "bille" ['b';'l']
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``HiddenWord with no correct letters guessed``()=
        let expected = "*****"
        let actual = HiddenWord "bille" ['a';'c';'d';'f']
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``GetWord returns a string``()=
        let actual = GetWord()
        Assert.IsType<string> actual

    [<Fact>]
    let ``GetWord returns a random word in the selection``()=
        let words = [GetWord();GetWord();GetWord();GetWord();GetWord();GetWord();]
        Assert.True(words.[0] <> words.[1] || words.[1] <> words.[2] || words.[2] <> words.[3] || words.[3] <> words.[4] || words.[4] <> words.[5])