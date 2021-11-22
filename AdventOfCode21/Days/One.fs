module Days

open CommonTypes

module One =
    let solve1 (puzzle: DailyPuzzle) = puzzle.Part |> string
    let solve2 (puzzle: DailyPuzzle) = puzzle.Part |> string

module EveryDay =
    let solve day puzzle =
        match day with
        | 1 -> match puzzle.Part with
                | 1 -> One.solve1 puzzle
                | 2 -> One.solve2 puzzle
                | _ -> failwith "no part defined"
        | _ -> "day not available"
//        let solve = if puzzle.Part = 1 then solve1 else solve2
//        puzzle.Lines |> Array.map int |> solve