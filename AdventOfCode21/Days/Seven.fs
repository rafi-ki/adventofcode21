module Days.Seven

open CommonTypes

let binomial v = (v * v + v) / 2

let calcCrabsMovement position (crabs: int[]) (f: int -> int) =
    crabs |> Array.fold (fun acc el -> acc + f(abs(el - position))) 0

let calcFuelConsumption (crabs : int []) (possiblePositions : int []) (f: int -> int) =
    possiblePositions |> Array.map (fun x -> calcCrabsMovement x crabs f)

let solve1 (puzzle: DailyPuzzle) =
    let crabs = puzzle.Lines.[0].Split(",") |> Array.map int
    calcFuelConsumption crabs crabs (fun x -> x)
    |> Array.sort
    |> Array.head

let solve2 (puzzle: DailyPuzzle) =
    let crabs = puzzle.Lines.[0].Split(",") |> Array.map int
    let possiblePositions = [| Array.min crabs .. Array.max crabs |]
    calcFuelConsumption crabs possiblePositions binomial
    |> Array.sort
    |> Array.head

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2