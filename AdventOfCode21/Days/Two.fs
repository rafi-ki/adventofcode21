module Days.Two

open CommonTypes

type Position = { X: int; Depth: int }

type AimedPosition = { X: int; Depth: int; Aim: int }

type Action = { Command: string; Depth: int }

let parseToAction (line: string) =
    let split = line.Split(' ')
    { Command = split.[0]; Depth = int split.[1] }

let apply (action: Action) (position: Position) =
    match action.Command with
    | "forward" -> { position with X = position.X + action.Depth }
    | "down" -> { position with Depth = position.Depth + action.Depth }
    | "up" -> { position with Depth = position.Depth - action.Depth }
    | _ -> failwith "unknown action"

let applyAimed (action: Action) (aimedPosition: AimedPosition) =
    match action.Command with
    | "forward" ->
        { aimedPosition with X = aimedPosition.X + action.Depth; Depth = aimedPosition.Depth + aimedPosition.Aim * action.Depth }
    | "down" -> { aimedPosition with Aim = aimedPosition.Aim + action.Depth }
    | "up" -> { aimedPosition with Aim = aimedPosition.Aim - action.Depth }
    | _ -> failwith "unknown action"

let solve1 (puzzle: DailyPuzzle) =
    let init = { X = 0; Depth = 0 }
    let finalPosition =
                        puzzle.Lines
                        |> Array.map parseToAction
                        |> Array.fold (fun position action -> apply action position) init
    finalPosition.X * finalPosition.Depth

let solve2 (puzzle: DailyPuzzle) =
    let init = { X = 0; Depth = 0; Aim = 0 }
    let final = puzzle.Lines
                |> Array.map parseToAction
                |> Array.fold (fun position action -> applyAimed action position) init
    final.X * final.Depth

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2