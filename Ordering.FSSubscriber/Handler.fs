namespace Ordering

open NServiceBus

type OrderCreatedHandler (bus: IBus) =
    interface IHandleMessages<OrderPlaced> with
        member this.Handle(message: OrderPlaced) =
            printfn "Handling: OrderPlaced for Order Id: %A" message.OrderId