namespace LinqSnippets
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}