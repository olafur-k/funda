using System.Collections.Generic;
using System.Diagnostics;

namespace Funda.Services.Models
{
    [DebuggerDisplay("{Title,nq}")]
    public class AgentInfoList
    {
        public string Title { get; set; }

        public List<AgentInfo> Items { get; set; } = new List<AgentInfo>();
    }

    [DebuggerDisplay("{Name,nq} with {ObjectCount} objects")]
    public class AgentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ObjectCount { get; set; }
    }
}
