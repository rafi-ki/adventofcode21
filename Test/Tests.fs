module Tests

open System
open Xunit
open CommonTypes
open Days

module DayOne =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = EveryDay.solve 1 puzzle
        Assert.Equal("7", result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = EveryDay.solve 1 puzzle
        Assert.Equal("5", result)

module DayTwo =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"forward 5";"down 5";"forward 8";"up 3";"down 8";"forward 2"|]
        }
        let result = EveryDay.solve 2 puzzle
        Assert.Equal("150", result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = EveryDay.solve 2 puzzle
        Assert.Equal("solving day 2 part 2", result)