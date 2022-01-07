﻿using Phoneshop.Domain.Objects;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandService
    {
        void Create(Brand brand);
        Brand GetOrCreate(string name);
    }
}