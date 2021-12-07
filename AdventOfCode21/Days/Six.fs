module Days.Six

open CommonTypes

type Fish = { Timer: int64 }

type FishBucket = { Timer: int; Count: int64 }

let reduceTimer (fish: Fish) = if fish.Timer = 0L then { fish with Timer = 6L } else { fish with Timer = fish.Timer - 1L }

let passDay (fishes: Fish[]) =
    let newFishCount = fishes |> Array.filter (fun x -> x.Timer = 0L) |> Array.length
    let reducedTimerFishes = fishes |> Array.map reduceTimer
    let newFishes = Array.init newFishCount (fun _ -> { Timer = 8L })
    Array.append reducedTimerFishes newFishes

let passDay2 (fishBuckets: FishBucket[]) =
    let fishBucket0 = fishBuckets |> Array.filter (fun x -> x.Timer = 0)
    let fishBucket1 = fishBuckets |> Array.filter (fun x -> x.Timer = 1)
    let fishBucket2 = fishBuckets |> Array.filter (fun x -> x.Timer = 2)
    let fishBucket3 = fishBuckets |> Array.filter (fun x -> x.Timer = 3)
    let fishBucket4 = fishBuckets |> Array.filter (fun x -> x.Timer = 4)
    let fishBucket5 = fishBuckets |> Array.filter (fun x -> x.Timer = 5)
    let fishBucket6 = fishBuckets |> Array.filter (fun x -> x.Timer = 6)
    let fishBucket7 = fishBuckets |> Array.filter (fun x -> x.Timer = 7)
    let fishBucket8 = fishBuckets |> Array.filter (fun x -> x.Timer = 8)
    let fishBuckets = [|
        { Timer = 0; Count = if fishBucket1.Length > 0 then fishBucket1.[0].Count else 0L }
        { Timer = 1; Count = if fishBucket2.Length > 0 then fishBucket2.[0].Count else 0L }
        { Timer = 2; Count = if fishBucket3.Length > 0 then fishBucket3.[0].Count else 0L }
        { Timer = 3; Count = if fishBucket4.Length > 0 then fishBucket4.[0].Count else 0L }
        { Timer = 4; Count = if fishBucket5.Length > 0 then fishBucket5.[0].Count else 0L }
        { Timer = 5; Count = if fishBucket6.Length > 0 then fishBucket6.[0].Count else 0L }
        { Timer = 6; Count = (if fishBucket7.Length > 0 then fishBucket7.[0].Count else 0L ) + (if fishBucket0.Length > 0 then fishBucket0.[0].Count else 0L) }
        { Timer = 7; Count = if fishBucket8.Length > 0 then fishBucket8.[0].Count else 0L }
        { Timer = 8; Count = if fishBucket0.Length > 0 then fishBucket0.[0].Count else 0L }
    |]
    fishBuckets

let solve1 (puzzle: DailyPuzzle) =
    let fishes = puzzle.Lines.[0].Split(",")
                 |> Array.map (fun x -> { Timer = int64 x })
    [|1 .. 80|]
    |> Array.fold (fun acc el -> passDay acc) fishes
    |> Array.length |> int64

let fishFilter timer = Array.filter (fun (x: Fish) -> x.Timer = timer)

let solve2 (puzzle: DailyPuzzle) =
    let fishes = puzzle.Lines.[0].Split(",")
                 |> Array.map (fun x -> { Timer = int64 x })
    let fishCount1 = fishes |> fishFilter 1L |> Array.length
    let fishCount2 = fishes |> fishFilter 2L |> Array.length
    let fishCount3 = fishes |> fishFilter 3L |> Array.length
    let fishCount4 = fishes |> fishFilter 4L |> Array.length
    let fishCount5 = fishes |> fishFilter 5L |> Array.length
    let fishBuckets = [|
        { Timer = 1; Count = fishCount1 |> int64 }
        { Timer = 2; Count = fishCount2 |> int64 }
        { Timer = 3; Count = fishCount3 |> int64 }
        { Timer = 4; Count = fishCount4 |> int64 }
        { Timer = 5; Count = fishCount5 |> int64 }
    |]
    [|1 .. 256|]
    |> Array.fold (fun acc _ -> passDay2 acc) fishBuckets
    |> Array.sumBy (fun x -> x.Count) |> int64

let solve puzzle = puzzle |> if puzzle.Part = 1 then solve1 else solve2

