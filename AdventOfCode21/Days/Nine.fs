module Days.Nine

open CommonTypes

let inline charToInt c = int c - int '0'

let itemFor x y (tubes: int[][]) =
    match Array.tryItem y tubes with
    | Some row -> match row |> Array.tryItem x with
                    | Some item -> Some item
                    | None -> None
    | None -> None

let isLowPoint x y (tubes: int[][]) =
    let up = itemFor (x-1) y tubes
    let down = itemFor (x+1) y tubes
    let left = itemFor x (y-1) tubes
    let right = itemFor x (y+1) tubes
    let surroundings = [up; down; left; right] |> List.choose (fun x -> x)
    surroundings |> List.forall (fun item -> tubes.[y].[x] < item)

let solve1 (puzzle: DailyPuzzle) =
    let tubes = puzzle.Lines |> Array.map (fun x -> x |> Seq.toList |> Seq.map charToInt |> Seq.toArray)
    let mutable lowPoints: int list = []
    for y = 0 to tubes.Length-1 do
        for x = 0 to tubes.[y].Length-1 do
            let appendix = if isLowPoint x y tubes
                            then tubes.[y].[x]
                            else - 1
            lowPoints <- lowPoints @ [appendix]
    lowPoints
    |> List.filter (fun x -> x <> - 1)
    |> List.map (fun x -> x + 1)
    |> List.sum

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle =
    puzzle |> if puzzle.Part = 1 then solve1 else solve2
    |> int64