namespace Stocksly.Domain.Models
{
    using System;
    
    public class Supplier
    {
        public int Id { get; }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Territory { get; set; }
    }
}
