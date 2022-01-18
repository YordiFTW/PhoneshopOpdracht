using Phoneshop.Domain.Objects;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandService
    {
        Brand Create(Brand brand);
        Brand GetOrCreate(string name);
    }
}