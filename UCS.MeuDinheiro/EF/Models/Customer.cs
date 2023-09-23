using System.ComponentModel.DataAnnotations;

namespace UCS.MeuDinheiro.EF.Models
{
    internal class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
