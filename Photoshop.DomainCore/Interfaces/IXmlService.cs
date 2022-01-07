
using System.Collections.Generic;
using System.IO;
using Phoneshop.Domain.Objects;

namespace Phoneshop.Domain.Interfaces
{
    public interface IXmlService
    {
        List<Phone> Read(TextReader xml);
    }
}
