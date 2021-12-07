module Days.Three

open System
open CommonTypes

let countAppearance c = Seq.filter ((=) c) >> Seq.length

let flip (v: string) = v.ToCharArray() |> Array.map (fun (c: char) -> if c = '0' then '1' else '0') |> String

let mostAppearance line =
    let zero = line |> countAppearance '0'
    let one = line |> countAppearance '1'
    if zero > one then '0' else '1'

let leastAppearance line =
    let zero = line |> countAppearance '0'
    let one = line |> countAppearance '1'
    if zero > one then '1' else '0'

let solve1 (puzzle: DailyPuzzle) =
    let mostAppearing = toColumns puzzle.Lines |> Array.map mostAppearance |> String
    let gamma = Convert.ToInt32(mostAppearing, 2)
    let epsilon = Convert.ToInt32(mostAppearing |> flip, 2)
    gamma * epsilon |> int64

let filter f (lines: string[]) (index: int) =
    if lines.Length = 1 then
        lines
    else
        let cols = toColumns lines
        let filtered = cols.[index] |> f
        lines |> Array.filter (fun x -> x.[index] = filtered)

let oxygenRating (lines: string[]) =
    let mutable linescopy = Array.copy lines
    for i = 0 to lines.[0].Length-1 do
        linescopy <- filter mostAppearance linescopy i
    Convert.ToInt64(Array.head linescopy, 2)

let scrubberRating (lines: string[]) =
    let mutable linescopy = Array.copy lines
    for i = 0 to lines.[0].Length-1 do
        linescopy <- filter leastAppearance linescopy i
    Convert.ToInt64(Array.head linescopy, 2)

let solve2 (puzzle: DailyPuzzle) =
    oxygenRating puzzle.Lines * scrubberRating puzzle.Lines

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

