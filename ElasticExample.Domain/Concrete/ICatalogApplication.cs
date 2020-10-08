using ElasticExample.Domain.Indices;
using System.Collections.Generic;

namespace ElasticExample.Domain.Concrete
{
    public interface ICatalogApplication
    {
        void PostCatalogsSample();
        ICollection<IndexCatalog> GetAll();
        ICollection<IndexCatalog> GetBySku(string sku);
        ICollection<IndexCatalog> GetByDescription(string description);
    }
}
