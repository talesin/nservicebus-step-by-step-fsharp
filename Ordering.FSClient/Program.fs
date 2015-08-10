open NServiceBus
open System
open Ordering

let readKeys = seq { while true do yield Console.ReadKey() }

let sendOrder (bus:IBus) =
    printfn "Press enter to send a message"
    printfn "Press any key to exit"

    readKeys
    |> Seq.takeWhile (fun key -> key.Key = ConsoleKey.Enter)
    |> Seq.iter (fun key ->
        let id = Guid.NewGuid()

        let placeOrder = { Id = id; Product = "New shoes" }
        bus.Send("StepByStep.Ordering.Server", placeOrder) |> ignore

        printfn "Sent a new PlaceOrder message with id: %A" id
        ())
    ()

[<EntryPoint>]
let main argv = 
    let busConfiguration = new BusConfiguration()
    busConfiguration.EndpointName("StepByStep.Ordering.Client")
    busConfiguration.UseSerialization<JsonSerializer>() |> ignore
    busConfiguration.EnableInstallers()
    busConfiguration.UsePersistence<InMemoryPersistence>() |> ignore

    let startableBus = Bus.Create(busConfiguration)
    use bus = startableBus.Start()
    sendOrder bus
    0 // return an integer exit code
