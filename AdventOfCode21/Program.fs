module Program

open System.IO
open CommonTypes
open Days

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

let solve day part =
    match inputFor day |> readLines with
    | Ok lines -> EveryDay.solve day { Part = part; Lines = lines }
    | Error txt -> $"ERROR: %s{txt}"

[<EntryPoint>]
let main argv =
    let day, part = readDayPart argv
    printfn $"-- DAY %i{day} | PART %i{part} --"
    solve day part |> printfn "%s"
    0
