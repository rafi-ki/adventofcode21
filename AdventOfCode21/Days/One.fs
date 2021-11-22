module Days.One

open CommonTypes

let solve1 (puzzle: DailyPuzzle) = puzzle.Part |> string
let solve2 (puzzle: DailyPuzzle) = puzzle.Part |> string

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

