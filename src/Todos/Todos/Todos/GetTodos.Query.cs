using Todos.Core;

namespace Todos.Todos;

public class GetTodosQuery : ICachedQuery<GetTodosResponse[]>
{
    public string Key { get => CacheKeyConstants.GET_TODOS_QUERY_CACHED_KEY; }
}
