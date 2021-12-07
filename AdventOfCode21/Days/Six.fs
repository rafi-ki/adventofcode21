module Days.Six

open System
open CommonTypes

type Fish = { Timer: int }

let reduceTimer fish = match fish.Timer with
                        | 0 -> { fish with Timer = 6 }
                        | _ -> { fish with Timer = fish.Timer - 1 }

let passDay (fishes: Fish[]) =
    let newFishCount = fishes |> Array.filter (fun x -> x.Timer = 0) |> Array.length
    let reducedTimerFishes = fishes |> Array.map reduceTimer
    let newFishes = Array.init newFishCount (fun _ -> { Timer = 8 })
    Array.append reducedTimerFishes newFishes

let solve1 (puzzle: DailyPuzzle) =
    let fishes = puzzle.Lines.[0].Split(",")
                 |> Array.map (fun x -> { Timer = int x })
    [|1 .. 80|]
    |> Array.fold (fun acc el -> passDay acc) fishes
    |> Array.length |> int64

let solve2 (puzzle: DailyPuzzle) =
    let fishes = puzzle.Lines.[0].Split(",")
                 |> Array.map (fun x -> { Timer = int x })
    [|1 .. 256|]
    |> Array.fold (fun acc _ -> passDay acc) fishes
    |> Array.length |> int64

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

