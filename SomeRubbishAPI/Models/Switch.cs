namespace SomeRubbishAPI.Models
{
    public class Switch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Computer>? Computers { get; set; }

        public int NetworkId { get; set; }
        public Network? Network { get; set; }
    }
}
