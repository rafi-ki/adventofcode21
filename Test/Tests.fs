module Tests

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
        Assert.Equal(7, result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"199"; "200"; "208"; "210"; "200"; "207"; "240"; "269"; "260"; "263"|]
        }
        let result = EveryDay.solve 1 puzzle
        Assert.Equal(5, result)

module DayTwo =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"forward 5";"down 5";"forward 8";"up 3";"down 8";"forward 2"|]
        }
        let result = EveryDay.solve 2 puzzle
        Assert.Equal(150, result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"forward 5";"down 5";"forward 8";"up 3";"down 8";"forward 2"|]
        }
        let result = EveryDay.solve 2 puzzle
        Assert.Equal(900, result)

module DayThree =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"00100";"11110";"10110";"10111";"10101";"01111";"00111";"11100";"10000";"11001";"00010";"01010"|]
        }
        let result = EveryDay.solve 3 puzzle
        Assert.Equal(198, result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"00100";"11110";"10110";"10111";"10101";"01111";"00111";"11100";"10000";"11001";"00010";"01010"|]
        }
        let result = EveryDay.solve 3 puzzle
        Assert.Equal(230, result)

module DayFour =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1"
                ""
                "22 13 17 11  0"
                "8  2 23  4 24"
                "21  9 14 16  7"
                "6 10  3 18  5"
                "1 12 20 15 19"
                ""
                "3 15  0  2 22"
                "9 18 13 17  5"
                "19  8  7 25 23"
                "20 11 10 24  4"
                "14 21 16 12  6"
                ""
                "14 21 17 24  4"
                "10 16 15  9 19"
                "18  8 23 26 20"
                "22 11 13  6  5"
                "2  0 12  3  7"|]
        }
        let result = EveryDay.solve 4 puzzle
        Assert.Equal(4512, result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"00100";"11110";"10110";"10111";"10101";"01111";"00111";"11100";"10000";"11001";"00010";"01010"|]
        }
        let result = EveryDay.solve 4 puzzle
        Assert.Equal(2, result)

module DaySeven =
    [<Fact>]
    let ``part one``() =
        let puzzle = {
            Part = 1
            Lines = [|"16,1,2,0,4,2,7,1,2,14"|]
        }
        let result = EveryDay.solve 7 puzzle
        Assert.Equal(37, result)

    [<Fact>]
    let ``part two``() =
        let puzzle = {
            Part = 2
            Lines = [|"16,1,2,0,4,2,7,1,2,14"|]
        }
        let result = EveryDay.solve 7 puzzle
        Assert.Equal(168, result)