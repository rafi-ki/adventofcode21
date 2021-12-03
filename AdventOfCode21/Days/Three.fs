module Days.Three

open System
open CommonTypes

let countAppearance c = Seq.filter ((=) c) >> Seq.length

let flip (v: string) = v.ToCharArray() |> Array.map (fun (c: char) -> if c = '0' then '1' else '0') |> String

let mostAppearance line =
    let zero = line |> countAppearance '0'
    let one = line |> countAppearance '1'
    if zero > one then '0' else '1'

let solve1 (puzzle: DailyPuzzle) =
    let mostAppearing = toColumns puzzle.Lines |> Array.map mostAppearance |> String
    let gamma = Convert.ToInt32(mostAppearing, 2)
    let epsilon = Convert.ToInt32(mostAppearing |> flip, 2)
    gamma * epsilon

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

