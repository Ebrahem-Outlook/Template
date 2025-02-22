﻿using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<TResponse>
    where TResponse : Result
{

}
