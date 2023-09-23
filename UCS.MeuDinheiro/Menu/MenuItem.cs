using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS.MeuDinheiro.Menu
{
    internal class MenuItem
    {
        public int Option { get; set; }

        public string? Description { get; set; }

        public IAction? Action { get; set; }
    }
}
