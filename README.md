# elastic-example
Exemplo de configuração do Elastic utilizando .net core

Baixe e configure o appsettings.json de acordo com sua configuração do Elastic.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ElasticsearchSettings": {
    "uri": "http://uri:2400",
    "defaultIndex": "indexcatalog",
    "username": "user",
    "password": "pass"
  },
  "AllowedHosts": "*"
}
```

Para inserir os dados no elastic execute o endpoint http://localhost:5000/api/catalog (POST)

Para listar todos os dados execute o endpoint http://localhost:5000/api/catalog (GET)

Resposta:
```json
[
    {
        "id": "c43ce473-9ebc-47a2-bc0e-ce2d4f4c821f",
        "registrationDate": "2020-10-07T22:43:15.877409-03:00",
        "sku": "AT3850",
        "description": "Auto Atarraxante Phillips Panela 2.2 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "0c90a6be-19e7-4a77-90a4-efa35ff3d177",
        "registrationDate": "2020-10-07T22:43:15.8774242-03:00",
        "sku": "AT3851",
        "description": "Auto Atarraxante Phillips Oval 2.2 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "9768110a-41d0-4b24-8a43-349bf7a30592",
        "registrationDate": "2020-10-07T22:43:15.8774246-03:00",
        "sku": "AT3852",
        "description": "Auto Atarraxante Phillips Panela  2.5 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "407c5c2b-4893-4f57-949f-dad2cc0507e4",
        "registrationDate": "2020-10-07T22:43:15.8774249-03:00",
        "sku": "AT3853",
        "description": "Auto Atarraxante Phillips Panela 2.6 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "29539630-4169-410b-8b11-2247637111b3",
        "registrationDate": "2020-10-07T22:43:15.8774252-03:00",
        "sku": "AT3854",
        "description": "Auto Atarraxante Phillips Chata 2.2 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "7a41e8b9-3a00-4b8a-9333-443923fa225a",
        "registrationDate": "2020-10-07T22:43:15.877437-03:00",
        "sku": "AT3855",
        "description": "Auto Atarraxante Phillips Panela Passivado 2.2 X 6.5 Aço Carbono Zincado Branco"
    },
    {
        "id": "cb69b3d5-41e0-4c75-b60d-78ba2142b258",
        "registrationDate": "2020-10-07T22:43:15.8774383-03:00",
        "sku": "AT3856",
        "description": "Auto Atarraxante Phillips Panela 2.9 X 6.5 Aço Carbono Zincado Branco"
    }
]
```

Para executar busca pelo SKU execute o endpoint com a descrição do SKU desejado http://localhost:5000/api/catalog/getBySku?sku=AT3855

Resposta:
```json
[
    {
        "id": "7a41e8b9-3a00-4b8a-9333-443923fa225a",
        "registrationDate": "2020-10-07T22:43:15.877437-03:00",
        "sku": "AT3855",
        "description": "Auto Atarraxante Phillips Panela Passivado 2.2 X 6.5 Aço Carbono Zincado Branco"
    }
]
```

Para executar busca pela descrição execute o endpoint com a descrição desejada http://localhost:5000/api/catalog/getByDescription?description=Oval

Resposta
```json
[
    {
        "id": "0c90a6be-19e7-4a77-90a4-efa35ff3d177",
        "registrationDate": "2020-10-07T22:43:15.8774242-03:00",
        "sku": "AT3851",
        "description": "Auto Atarraxante Phillips Oval 2.2 X 6.5 Aço Carbono Zincado Branco"
    }
]
```

Artigos/Documentações utilizadas:

Utilizando o Elasticsearch com NEST no .NET Core 3.1 -
https://medium.com/@hgmauri/utilizando-o-elasticsearch-com-nest-no-net-core-3-1-cd83d559dc5c

Elastic Stack and Product Documentation -
https://www.elastic.co/guide/index.html

