using FluentResults;
using GymManager.Domain;
using MediatR;
using System.Text.Json.Serialization;


namespace GymManager.Application.Requests;

public abstract class ApplicationRequest<TResult>
    : IRequest<Result<TResult>>
{
    [JsonIgnore]
    public OperationContext Context { get; internal set; } = null!;
}

public abstract class ApplicationRequest : IRequest<Result>
{
    [JsonIgnore]
    public OperationContext Context { get; internal set; } = null!;
}