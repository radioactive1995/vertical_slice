using FastEndpoints;

namespace todo.api.Core;

public abstract class CommandMapper<TRequest, TResponse, TCommand, TEntity> : Mapper<TCommand, TResponse, TEntity> where TCommand : ICommand<TResponse>
{
    public virtual TCommand ToCommand(TRequest request) => throw new NotImplementedException();
}
