namespace SomeRubbishAPI.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IpAddress { get; set; }

        public int SwitchId { get; set; }
        public Switch? Switch { get; set; }
    }
}
