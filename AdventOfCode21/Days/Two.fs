module Days.Two

open CommonTypes

let solve1 (puzzle: DailyPuzzle) =
    "solving day 2 part 1"

let solve2 (puzzle: DailyPuzzle) =
    "solving day 2 part 2"

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2