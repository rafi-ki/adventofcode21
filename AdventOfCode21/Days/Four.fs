module Days.Four

open System
open CommonTypes

type Board = (int*bool) [,]

type Draw = int[]

let parseDraw (v: string) : Draw = v.Split(",") |> Array.map int

let parseBoard (v: string[]) : Board =
    Array2D.init 5 5 (fun x y -> v.[x].Split(" ", StringSplitOptions.RemoveEmptyEntries).[y] |> int, false)

let drawOne (v: int) (board: Board) =
    for i = 0 to 4 do
        for j = 0 to 4 do
            let el = board.[i,j]
            if fst(el) = v then board.[i,j] <- v, true

let boardWin (board: Board) =
    false

let solve1 (puzzle: DailyPuzzle) =
    let draw = parseDraw puzzle.Lines.[0]
    let boardLines = puzzle.Lines |> Array.skip 2 |> Array.chunkBySize 6
    let boards = boardLines |> Array.map parseBoard
    1

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

