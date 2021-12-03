module Days.EveryDay

let solve day =
    match day with
    | 1 -> One.solve
    | 2 -> Two.solve
    | 3 -> Three.solve
    | _ -> failwith "day not yet solvable"