module Program

open System.IO
open CommonTypes
open Days

let solve day puzzle : string =
    match day with
    | 1 -> EveryDay.solve day puzzle
    | _ -> "day not defined"
//    | 2 -> Some DayTwo.solve
//    | 3 -> Some DayThree.solve
//    | 4 -> Some DayFour.solve
//    | 5 -> Some DayFive.solve
//    | 6 -> Some DaySix.solve
//    | 7 -> Some DaySeven.solve
//    | 8 -> Some DayEight.solve
//    | 9 -> Some DayNine.solve
//    | 10 -> Some DayTen.solve
//    | 11 -> Some DayEleven.solve
//    | 12 -> Some DayTwelfth.solve
//    | 13 -> Some DayThirteen.solve
//    | 14 -> Some DayFourteen.solve
//    | 15 -> Some DayFifteen.solve
//    | 16 -> Some DaySixteen.solve
//    | _ -> None

//let solvePuzzle day (puzzle: DailyPuzzle) =
//    match solveFor day with
//    | Some solve -> solve puzzle
//    | None ->  "no solve function defined"

let inputFor day = $"input/day%i{day}.txt"

let readLines (file: string) =
    match File.Exists file with
    | true -> Ok (File.ReadLines file |> Seq.toArray)
    | false -> Error $"Input file %s{file} does not exist"

let readDayPart (args: string []) =
    match args.Length with
    | 1 -> (args.[0] |> int, 1)
    | 2 -> (args.[0] |> int, args.[1] |> int)
    | _ -> (1, 1)


[<EntryPoint>]
let main argv =
    let day, part = readDayPart argv
    printfn $"-- DAY %i{day} | PART %i{part} --"
    match inputFor day |> readLines with
    | Ok lines -> solve day { Part = part; Lines = lines }
    | Error txt -> $"ERROR: %s{txt}"
    |> printfn "%s"
    0
