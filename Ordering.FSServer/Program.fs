open NServiceBus
open Autofac

[<EntryPoint>]
let main argv = 
    let busConfiguration = new BusConfiguration ()
    busConfiguration.EndpointName("StepByStep.Ordering.Server")
    busConfiguration.UseSerialization<JsonSerializer>() |> ignore
    busConfiguration.EnableInstallers()
    busConfiguration.UsePersistence<InMemoryPersistence>() |> ignore

    let startableBus = Bus.Create(busConfiguration)
    use bus = startableBus.Start()
    printfn "Press any key to exit"
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
