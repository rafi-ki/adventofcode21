module Days.Seven

open CommonTypes

type FuelConsumption = { Position: int; FuelConsumption: int }

let initConsumption position = { Position = position; FuelConsumption = 0 }

let calcFuelConsumption (i : int) (positions : int []) =
    let v = positions.[i]
    positions |> Array.fold (fun acc el -> { acc with FuelConsumption = acc.FuelConsumption + abs(el - v) }) { Position = v; FuelConsumption = 0 }

let solve1 (puzzle: DailyPuzzle) =
    let positions = puzzle.Lines.[0].Split(",") |> Array.map int
    let fuelConsumptions = positions |> Array.mapi (fun x y -> calcFuelConsumption x positions)
    fuelConsumptions
    |> Array.map (fun x -> x.FuelConsumption)
    |> Array.sort
    |> Array.head

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2