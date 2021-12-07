module Days.Seven

open CommonTypes

type FuelConsumption = { Index: int; Position: int; Consumption: int }

let initConsumption p i = { Index = i; Position = p; Consumption = 0 }

let calcFuelConsumption (i : int) (positions : int []) =
    let v = positions.[i]
    positions |> Array.fold (fun acc el -> { acc with Consumption = acc.Consumption + abs(el - v) }) (initConsumption v i)

let solve1 (puzzle: DailyPuzzle) =
    let positions = puzzle.Lines.[0].Split(",") |> Array.map int
    let fuelConsumptions = positions |> Array.mapi (fun x _ -> calcFuelConsumption x positions)
    fuelConsumptions
    |> Array.map (fun x -> x.Consumption)
    |> Array.sort
    |> Array.head

let binomial v = (v * v + v) / 2

let calcCrabsMovement position (crabs: int[]) =
    crabs |> Array.fold (fun acc el -> acc + binomial(abs(el - position))) 0

let calcFuelConsumption2 (crabs : int []) (possiblePositions : int [])=
    possiblePositions |> Array.map (fun x -> calcCrabsMovement x crabs)

let solve2 (puzzle: DailyPuzzle) =
    let positions = puzzle.Lines.[0].Split(",") |> Array.map int
    let possiblePositions = [| Array.min positions .. Array.max positions |]
    calcFuelConsumption2 positions possiblePositions
    |> Array.sort
    |> Array.head


let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2