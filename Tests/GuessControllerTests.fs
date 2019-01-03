module GuessControllerTests

    open Xunit
    open GuessController
    open System

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