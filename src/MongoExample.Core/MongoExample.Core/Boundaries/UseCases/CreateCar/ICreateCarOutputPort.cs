namespace MongoExample.Core.Boundaries.UseCases.CreateCar;

public interface ICreateCarOutputPort
{
    void Created(int vin, string brand, string model, DateTime dateManufactured);

    void BrandModelMismatch();

    void DateManufacturedIsInFuture();

    void BrandNotFound();
}
