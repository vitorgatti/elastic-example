using ElasticExample.Domain.Concrete;
using ElasticExample.Domain.Indices;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElasticExample.Domain.Application
{
    public class CatalogApplication : ICatalogApplication
    {
        private readonly IElasticClient _elasticClient;

        public CatalogApplication(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public ICollection<IndexCatalog> GetAll()
        {
            var result = _elasticClient.Search<IndexCatalog>(s => s
                .Index(nameof(IndexCatalog).ToLower())
                .Size(100)
                .Sort(q => q.Descending(p => p.RegistrationDate)))?.Documents;

            return result?.ToList();
        }

        public ICollection<IndexCatalog> GetByDescription(string description)
        {
            return _elasticClient.Search<IndexCatalog>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Description)
                        .Query(description)
                    )
                ).Size(100)
            ).Documents.ToList();
        }

        public ICollection<IndexCatalog> GetBySku(string sku)
        {
            return _elasticClient.Search<IndexCatalog>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Sku)
                        .Query(sku)
                    )
                ).Size(100)
            ).Documents.ToList();
        }

        public void PostCatalogsSample()
        {
            if (!_elasticClient.Indices.Exists(nameof(IndexCatalog).ToLower()).Exists)
                _elasticClient.Indices.Create(nameof(IndexCatalog).ToLower());

            _elasticClient.IndexMany<IndexCatalog>(IndexCatalog.GetCatalog());

            var descriptor = new BulkDescriptor();

            descriptor.UpdateMany<IndexCatalog>(IndexCatalog.GetCatalog(), (b, u) => b
                .Index(nameof(IndexCatalog).ToLower())
                .Doc(u)
                .DocAsUpsert());

            var insert = _elasticClient.Bulk(descriptor);

            if (!insert.IsValid)
                throw new Exception(insert.OriginalException.ToString());
        }
    }
}
