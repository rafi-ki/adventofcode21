module Tests

open System
open Xunit
open CommonTypes
open Days

module DayOne =
    [<Fact>]
    let ``solve part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = One.solve puzzle
        Assert.Equal("7", result)

    [<Fact>]
    let ``solve part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = One.solve puzzle
        Assert.Equal("5", result)