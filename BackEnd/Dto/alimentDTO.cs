namespace BackEnd.Dto
{
    public class alimentDTO
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? scientificName { get; set; }
        public string? group { get; set; }
        public string? brand { get; set; }
        public IEnumerable<Dictionary<string, string>>? components { get; set; }
    }
}