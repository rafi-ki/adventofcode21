module Days.Ten

open CommonTypes

type SyntaxCheck = {
    OpenedBrackets: char list
    MistakenChar: char option
}

let initSyntaxCheck = { OpenedBrackets = []; MistakenChar = None; }

let parseBrackets c brackets =
    if brackets.MistakenChar |> Option.isSome
    then brackets
    else
    match c with
    | '[' | '(' | '{' | '<' -> { brackets with OpenedBrackets = brackets.OpenedBrackets @ [c] }
    | ']' -> if brackets.OpenedBrackets |> List.last = '['
                then { brackets with OpenedBrackets = brackets.OpenedBrackets |> (List.removeAt (brackets.OpenedBrackets.Length - 1)) }
                else  { brackets with MistakenChar = Some c }
    | ')' -> if brackets.OpenedBrackets |> List.last = '('
                then { brackets with OpenedBrackets = brackets.OpenedBrackets |> (List.removeAt (brackets.OpenedBrackets.Length - 1)) }
                else  { brackets with MistakenChar = Some c }
    | '}' -> if brackets.OpenedBrackets |> List.last = '{'
                then { brackets with OpenedBrackets = brackets.OpenedBrackets |> (List.removeAt (brackets.OpenedBrackets.Length - 1)) }
                else  { brackets with MistakenChar = Some c }
    | '>' -> if brackets.OpenedBrackets |> List.last = '<'
                then { brackets with OpenedBrackets = brackets.OpenedBrackets |> (List.removeAt (brackets.OpenedBrackets.Length - 1)) }
                else  { brackets with MistakenChar = Some c }
    | _ -> brackets

let illegalCharFor (line: string) =
    line |> Seq.toList |> Seq.fold (fun acc el -> parseBrackets el acc) initSyntaxCheck

let solve1 (puzzle: DailyPuzzle) =
    let failedChecks = puzzle.Lines |> Array.map illegalCharFor |> Array.choose (fun x -> x.MistakenChar)
    failedChecks |> Array.sumBy (fun x -> match x with | ')' -> 3 | ']' -> 57 | '}' -> 1197 | '>' -> 25137)

let solve2 (puzzle: DailyPuzzle) =
    2

let solve puzzle =
    puzzle |> if puzzle.Part = 1 then solve1 else solve2
    |> int64