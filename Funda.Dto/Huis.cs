using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funda.Dto
{
    public class Huis
    {
        // The API result returns a lot of info.
        // We really we just need the makelaar name & id, but I've added a couple more extra properties
        // to show the mappings. More can be added as needed.
        public Guid Id { get; set; }
        public int AantalKamers { get; set; }
        public string Adres { get; set; }
        public decimal Koopprijs { get; set; }
        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }
        public decimal Woonoppervlakte { get; set; }
    }
}
