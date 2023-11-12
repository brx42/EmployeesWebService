using System.Text.Json;
using SqlKata;
using SqlKata.Execution;

namespace EmployeesWebService.Extensions;

public static class SqlKataExtension
{
    public static async Task<PaginationResult<T>> PaginateForInclude<T>(this Query query, int page, int perPage = 20,
        CancellationToken ct = default)
    {
        var newQuery = query.Clone();

        var skip = (page - 1) * perPage;
        newQuery.Skip(skip)
            .Take(perPage);

        var count = await query.CountAsync<long>(cancellationToken: ct);

        var dynamicResult = await newQuery.GetAsync(cancellationToken: ct);
        var jsonSer = JsonSerializer.Serialize(dynamicResult);
        var response = new PaginationResult<T>
        {
            Count = 0,
            List = Enumerable.Empty<T>(),
            Page = page,
            PerPage = perPage
        };
        if (string.IsNullOrEmpty(jsonSer))
        {
            return response;
        }

        var result = JsonSerializer.Deserialize<IEnumerable<T>>(jsonSer);

        if (result is null)
        {
            return response;
        }

        response.Count = count;
        response.List = result;

        return response;
    }
}