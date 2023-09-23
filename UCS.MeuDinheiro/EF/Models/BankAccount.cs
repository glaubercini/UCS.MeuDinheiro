using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS.MeuDinheiro.EF.Models
{
    internal class BankAccount
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal Balance { get; set; }
    }
}
