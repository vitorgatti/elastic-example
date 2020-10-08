using System;
using System.Collections.Generic;

namespace ElasticExample.Domain.Indices
{
    public class IndexCatalog
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }


        public static List<IndexCatalog> GetCatalog()
        {
            return new List<IndexCatalog>
            {
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3850", Description = "Auto Atarraxante Phillips Panela 2.2 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3851", Description = "Auto Atarraxante Phillips Oval 2.2 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3852", Description = "Auto Atarraxante Phillips Panela  2.5 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3853", Description = "Auto Atarraxante Phillips Panela 2.6 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3854", Description = "Auto Atarraxante Phillips Chata 2.2 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3855", Description = "Auto Atarraxante Phillips Panela Passivado 2.2 X 6.5 Aço Carbono Zincado Branco"},
                new IndexCatalog {Id = Guid.NewGuid(), RegistrationDate = DateTime.Now, Sku = "AT3856", Description = "Auto Atarraxante Phillips Panela 2.9 X 6.5 Aço Carbono Zincado Branco"}
            };
        }
    }
}
