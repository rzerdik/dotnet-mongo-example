using MongoExample.Core.Boundaries.DataAccess;

namespace MongoExample.Infrastructure.DataAccess;

public class BrandService : IBrandService
{
    private readonly MongoDbContext _context;

    public BrandService(MongoDbContext context)
    {
        _context = context;
    }

    public Task<bool> BrandExistsAsync(string brandName) => _context.Brands.ExistsAsync(b => b.Name == brandName);

    public async Task<bool> ModelExistsForBrandAsync(string brandName, string model)
    {
        var brand = await _context.Brands.GetSingleAsync(b => b.Name == brandName);
        return brand.AvailableModels.Contains(model);
    }
}
