using Todos.Core;

namespace Todos.Todos;

public record CompleteTodoCommand(Guid Id) : IInvalidateCacheCommand<CompleteTodoResponse>
{
    public string[] InvalidateKeys => [
        CacheKeyConstants.GET_TODOS_QUERY_CACHED_KEY,
        $"{CacheKeyConstants.GET_TODO_QUERY_CACHED_KEY}:{Id}"];
}
