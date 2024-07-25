using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface IQuery : IRequest
{

}

public interface IQuery<TResponse> : IRequest<TResponse>
    where TResponse : Result
{

}
