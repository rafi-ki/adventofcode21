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
            Lines = [|"1721";"979";"366";"299";"675";"1456"|]
        }
        let result = One.solve puzzle
        Assert.Equal("1", result)

    [<Fact>]
    let ``solve part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"1721";"979";"366";"299";"675";"1456"|]
        }
        let result = One.solve puzzle
        Assert.Equal("2", result)