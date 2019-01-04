module WordGeneratorTests
    open Xunit
    open WordGenerator

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