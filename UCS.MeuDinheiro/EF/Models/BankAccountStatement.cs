using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS.MeuDinheiro.EF.Models
{
    internal class BankAccountStatement
    {
        [Key]
        public int Id { get; set; }

        public int BankAccountId { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }
    }
}
