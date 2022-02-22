using System.Linq.Expressions;
using MongoDB.Driver;

namespace MongoExample.Infrastructure.DataAccess;

public static class MongoExtensions
{
    public static async Task<bool> ExistsAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> predicate)
        => await collection.GetSingleAsync(predicate) is not null;

    public static async Task<T> GetSingleAsync<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> predicate)
    {
        var filter = Builders<T>.Filter.Where(predicate);
        var result = (await collection.FindAsync(filter)).FirstOrDefault();
        return result;
    }
}
