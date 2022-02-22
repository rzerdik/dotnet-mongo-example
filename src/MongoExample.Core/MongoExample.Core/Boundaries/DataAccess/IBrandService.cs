namespace MongoExample.Core.Boundaries.DataAccess;

public interface IBrandService
{
    Task<bool> BrandExistsAsync(string brand);

    Task<bool> ModelExistsForBrandAsync(string brand, string model);
}
