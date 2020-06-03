using System.Collections.Generic;

namespace Funda.Dto.Base
{
    public class PagedResult<T>
    {
        public List<T> Objects{ get; set; }
        public Metadata Metadata { get; set; }
        public Paging Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }

    public class Metadata
    {
        public string ObjectType { get; set; }
        public string Omschrijving { get; set; }
        public string Titel { get; set; }
    }

    public class Paging
    {
        public int AantalPaginas { get; set; }
        public string HuidigePagina { get; set; }
        public string VolgendeUrl { get; set; }
        public string VorigeUrl { get; set; }
    }
}
