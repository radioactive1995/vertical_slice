using MediatR;
using Todos.Core;

namespace Todos.Todos;

public record AddTodoCommand(string Content, bool Completed) : IInvalidateCacheCommand<AddTodoResponse>
{
    public string[] InvalidateKeys => [CacheKeyConstants.GET_TODOS_QUERY_CACHED_KEY];
}
