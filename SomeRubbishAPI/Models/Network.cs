namespace SomeRubbishAPI.Models
{
    public class Network
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Switch>? Switches { get; set; }
    }
}
