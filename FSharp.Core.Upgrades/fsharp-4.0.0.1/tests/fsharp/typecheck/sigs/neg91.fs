module Test

module T1 = 
    type Enum1 = 
        | E = 1
        with
        member this.Foo() = 1 // not ok

module T2 =    
    type Enum2 = 
        | E2 = 1
    type Enum2
        with
        member this.Foo() = 1 // not ok

module TestPrivateSet = 
    // See https://github.com/Microsoft/visualfsharp/issues/27
    module A =
        let mutable private x = 0

    module B = 
        let test () =
            // let _ = A.x  // accessibility error on read, as expected
            A.x <- 1     // but write works!

module TestObsoleteSet = 
    // See https://github.com/Microsoft/visualfsharp/issues/27
    module A =
        [<System.ObsoleteAttribute("Don't touch me")>]
        let mutable x = 0

    module B = 
        let test () =
            A.x <- 1     

module TestCompilerMessgeSet = 
    // See https://github.com/Microsoft/visualfsharp/issues/27
    module A =
        [<CompilerMessageAttribute("Don't touch me", 3003)>]
        let mutable x = 0

    module B = 
        let test () =
            A.x <- 1     

module TestExperimentalSet = 
    // See https://github.com/Microsoft/visualfsharp/issues/27
    module A =
        [<ExperimentalAttribute("It was just an experiment!")>]
        let mutable x = 0

    module B = 
        let test () =
            A.x <- 1     

