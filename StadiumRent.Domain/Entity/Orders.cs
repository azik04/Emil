using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.Domain.Entity
{
    public class Orders
    {
        public int Id  { get; set; }
        public int StadiumId { get; set; }
        public int UserId  { get; set; }
        public DateTime Created { get; set; }
        public string Order {  get; set; }
    }
}
