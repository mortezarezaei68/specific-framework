#Command Handler #
___
this document is a guideline to use CommandHandler. 
## using MediatR library
`ITransactionalCommandHandlerMediatR<in TCommand, TResponse>` is a generic interface inherited from `IPipelineBehavior<in TRequest, TResponse>`.
for additional information you can use these links:
* https://github.com/jbogard/MediatR
* https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-apix


