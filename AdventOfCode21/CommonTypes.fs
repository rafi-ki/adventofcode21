module CommonTypes

open System

type DailyPuzzle = {
    Part: int
    Lines: string []
}

type SolvePuzzle = DailyPuzzle -> string

let (./.) x y = (x |> double) / (y |> double)

let toColumns (lines: string[]) =
    [| 0 .. (lines.[0].Length-1) |]
    |> Array.map (fun i -> lines |> Array.map (fun line -> line.[i]))
    |> Array.map String

