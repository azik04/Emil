using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.Domain.Entity
{
    public class Stadium
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Adress { get; set; }
        public DateTime DateCreat { get; set; }
    }

}
