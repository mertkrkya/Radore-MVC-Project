namespace Radore_MVC_Project.Models
{
    public class HostingDetailDto : HostingDto
    {
        public string Message { get; set; }
        public int IncomingConnections { get; set; }
        public int CpuLoad { get; set; }
        public int RamMax { get; set; }
        public int RamUsage { get; set; }
    }
}
