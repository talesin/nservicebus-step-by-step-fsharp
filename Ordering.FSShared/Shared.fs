namespace Ordering

open System
open NServiceBus
open NServiceBus.Config
open NServiceBus.Config.ConfigurationSource

[<CLIMutable>]
type PlaceOrder =
    { Id: Guid; Product: string }
    interface ICommand

[<CLIMutable>]
type OrderPlaced =
    { OrderId: Guid }
    interface IEvent

type ConfigErrorQueue =
    interface IProvideConfiguration<MessageForwardingInCaseOfFaultConfig> with
        member this.GetConfiguration () =
            new MessageForwardingInCaseOfFaultConfig(ErrorQueue = "error")
