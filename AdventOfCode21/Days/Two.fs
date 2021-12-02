module Days.Two

open CommonTypes

type Position = { X: int; Y: int}

type Action = { Command: string; Depth: int }

let parseToAction (line: string) =
    let split = line.Split(' ')
    { Command = split.[0]; Depth = int split.[1] }

let apply (action: Action) position =
    match action.Command with
    | "forward" -> { position with X = position.X + action.Depth }
    | "down" -> { position with Y = position.Y + action.Depth }
    | "up" -> { position with Y = position.Y - action.Depth }
    | _ -> failwith "unknown action"

let solve1 (puzzle: DailyPuzzle) =
    let position = { X = 0; Y = 0 }
    let finalPosition =
                        puzzle.Lines
                        |> Array.map parseToAction
                        |> Array.fold (fun position action -> apply action position) position
    finalPosition.X * finalPosition.Y |> string

let solve2 (puzzle: DailyPuzzle) =
    "solving day 2 part 2"

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2