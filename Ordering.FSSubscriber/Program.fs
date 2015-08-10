open NServiceBus

[<EntryPoint>]
let main argv =
    let  busConfiguration = new BusConfiguration()
    busConfiguration.EndpointName("StepByStep.Ordering.Subscriber")
    busConfiguration.UseSerialization<JsonSerializer>() |> ignore
    busConfiguration.EnableInstallers()
    busConfiguration.UsePersistence<InMemoryPersistence>() |> ignore

    use bus = Bus.Create(busConfiguration).Start()
    printfn "Press any key to exit"
    System.Console.ReadKey() |> ignore
    
    0 // return an integer exit code
