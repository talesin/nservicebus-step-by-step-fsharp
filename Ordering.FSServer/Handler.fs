namespace Ordering

open NServiceBus

type PlaceOrderHandler (bus: IBus) =
    interface IHandleMessages<PlaceOrder> with
        member this.Handle(message: PlaceOrder) =
            printfn "Order for Product:%s placed with id: %A" message.Product message.Id
            printfn "Publishing: OrderPlaced for Order Id: %A" message.Id

            bus.Publish( { OrderId = message.Id })
