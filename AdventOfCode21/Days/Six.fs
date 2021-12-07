module Days.Six

open System
open CommonTypes

type Fish = { Timer: int }

let reduceTimer fish = match fish.Timer with
                        | 0 -> { fish with Timer = 6 }
                        | _ -> { fish with Timer = fish.Timer - 1 }

let passDay (fishes: Fish list) =
    let newFishCount = fishes |> List.filter (fun x -> x.Timer = 0) |> List.length
    let reducedTimerFishes = fishes |> List.map reduceTimer
    let newFishes = List.init newFishCount (fun _ -> { Timer = 8 })
    List.append reducedTimerFishes newFishes

let solve1 (puzzle: DailyPuzzle) =
    let fishes = puzzle.Lines.[0].Split(",")
                 |> Array.map (fun x -> { Timer = int x })
                 |> Array.toList
    [1 .. 80]
    |> List.fold (fun acc el -> passDay acc) fishes
    |> List.length

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

