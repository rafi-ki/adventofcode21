﻿module Days.One

open CommonTypes

let solve1 (puzzle: DailyPuzzle) =
    let paired = puzzle.Lines |> Array.map int |> Array.pairwise
    let increased = paired |> Array.filter (fun x -> snd(x) > fst(x)) |> Array.length
    increased |> string

let solve2 (puzzle: DailyPuzzle) =
    let windowed = puzzle.Lines |> Array.map int |> Array.windowed 3
    let summed = windowed |> Array.map Array.sum
    let paired = summed |> Array.pairwise
    let increased = paired |> Array.filter (fun x -> snd(x) > fst(x)) |> Array.length
    increased |> string

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

