// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more helpbvc d
open System


let count =3
let max = 10
let Sort list = 
       let rec Arrange lst temp =        
                      match lst with 
                      |[] -> temp
                      |head::tail -> Arrange tail (head:: temp)
       Arrange list []

let Listgen num =
    let rec DoIt listed count =
        match (count > 0 ) with
        |true -> DoIt (count:: listed) (count-1)
        |_-> ( listed)
    DoIt [] num


let rec Checking bs tries inp low high=
    printfn  ("Enter a number between 1 and %d to play") max
    let  size = Convert.ToInt32( Console.ReadLine())
    Console.Clear()
    let rec Check (lst: int list) count sizes lw hg =
        let inrement = lst.Length
        
        match (count > 0) with
        |true ->
                 let mid = (lw + hg ) / 2
               
                 match ( sizes < lst.[mid]  ,  sizes> lst.[mid] , lst.[mid] = sizes)  with
                 | true, false, false ->  Console.Write("Please try higher number ")
                                          let size =Convert.ToInt32( Console.ReadLine())
                                          Console.Clear()
                                          let lw = lw + mid
                                          let mid = (lw + hg ) / 2
                                          Check lst (count - 1) size lw hg
                 | false, true, false ->     Console.Write("Please try lower number ")                 
                                             let size =Convert.ToInt32( Console.ReadLine())
                                             Console.Clear()
                                             let high = mid
                                             let mid = (lw + hg ) / 2
                                             Check lst (count - 1) size 0 hg
                 | false, false, true ->  printfn ("Congradulations  \n")  
                                          printfn (" You got it")   
                                          Console.WriteLine()
                                          Console.Write("Do you want to continue ?")
                                          let read = Console.ReadLine()
                                          Console.Clear()
                                          match read with 
                                                      |"yes" ->  
                                                                  let bs = count + 3
                                                                  let inrements = inrement + 10
                                                                  printfn "list size is : %d" inrements
                                                                  Console.Clear()
                                                                  printfn  ("Enter a number between 1 and %d to play") inrements
                                                                  let  size = Convert.ToInt32( Console.ReadLine())
                                                                  Console.Clear()
                                                                  Check (Sort (Listgen (inrements))) (bs) size 0 (Sort (Listgen (inrements))).Length
                                                      |_ -> System.Environment.Exit(1)
                 |_ -> System.Environment.Exit(1)
            
        |_->  
              Console.WriteLine("You lost")
            

    Check bs tries size low high


let display u =
    Console.WriteLine()
    Console.WriteLine()
    Console.WriteLine()
    Console.WriteLine()
    Console.WriteLine()
    Console.Write("                                         Welcome to Functional Programming ")
    Console.WriteLine()
    Console.WriteLine()
    Console.WriteLine()
let Home name =
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine()
       Console.Write("         Welcome  "+  name)
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine()
       Console.WriteLine("                                         You are about to play a number Guessing Game")
       Console.WriteLine()
       Console.WriteLine()
       Checking (Sort (Listgen max))  count  () 0 ((Listgen max).Length)
       
let LogIn =
        
          let rec login a =
             display ()
             Console.Write("                                       Please Enter Username  :")
             let user = Console.ReadLine()
             Console.Write("                                       Please Enter password  :")
             let pass = Console.ReadLine()
             match (user = "" , pass = "") with
                                    |true,true ->   Console.WriteLine("Please provide username or password")
                                                    Console.Clear()
                                                   
                                                    login ()

                                    |true,false ->   Console.WriteLine("Please provide username or password")
                                                     Console.Clear()
                                                  
                                                     login ()
                                    | false, true ->  Console.WriteLine("Please provide username or password")
                                                      Console.Clear()
                                                      
                                                      login ()
                                    |_,_->  Console.Clear()
                                            Home user
                                           
          login ()
// ============================================================================================================================================


Console.ReadKey()|> ignore

