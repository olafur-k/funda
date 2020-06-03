using System.Diagnostics;

namespace Funda.Services.Models
{
    [DebuggerDisplay("{Name,nq} with {ObjectCount} objects")]
    public class AgentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ObjectCount { get; set; }
    }
}
