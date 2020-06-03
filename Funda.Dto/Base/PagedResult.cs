using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Funda.Dto.Base
{
    [Serializable]
    [JsonObject]
    public class PagedResult<T>
    {
        public List<T> Objects{ get; set; }
        public Metadata Metadata { get; set; }
        public Paging Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class Metadata
    {
        public string ObjectType { get; set; }
        public string Omschrijving { get; set; }
        public string Titel { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class Paging
    {
        public int AantalPaginas { get; set; }
        public string HuidigePagina { get; set; }
        public string VolgendeUrl { get; set; }
        public string VorigeUrl { get; set; }
    }
}
