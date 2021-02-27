let seq1 = Seq.empty
let seq2 = Seq.singleton 10
let seq3 = seq { 1;2;3;4;5 }
let seq4 = seq { for x in 1..10 do yield x * x }
let seq5 = seq { for x in 1..10 do yield! [x..x*x] }

printfn "1:%A" seq1
printfn "2:%A" seq2
printfn "3:%A" seq3
printfn "4:%A" seq4
printfn "5:%A" seq5
printfn "\n\n"

//int list to seq
printfn ":%A to Sequence" [1..5]
let list1 = [ 1;2;3;4;5 ]
let seq_ = list1 :> seq<int>
Seq.iter (fun x -> printfn "%d" x) seq_

//string list to seq
let list2 = [ "hi";"f";"sharp" ]
printfn ":%A to sequence" list2
let seq__ = list2 :> seq<string>
Seq.iter (fun x -> printfn "%s" x ) seq__

//unfold
printfn ":Seq.unfold"
let seq_unfold = Seq.unfold (fun x -> if (x < 5) then Some(x,x+1) else None) 0
for i in seq_unfold do printfn "%d" i

//truncate
printfn ":Seq.truncate 3 seq3"
let seq3_ = Seq.truncate 3 seq3
printfn "%A" seq3
printfn "%A" seq3_
Seq.iter (fun x -> printfn "%d" x) seq3_ 

//take
printfn ":Seq.take 3 seq3"
let seq3__ = Seq.take 3 seq3
printfn "%A" seq3
printfn "%A" seq3__
Seq.iter (fun x -> printfn "%d" x) seq3__

//nested for sequence
printfn ":nested for sequence"
let mutable count:int = 0
let seq_nest = seq {
    for i in 1..5 do
        for j in 1..10 do
            count <- count + j
        yield count
}
printfn "%A" seq_nest
Seq.iter (fun x -> printfn "%d" x) seq_nest
