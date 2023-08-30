using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCarSell.DataAccess.Entities
{
    public class Model_Modifications
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public Guid ModelId { get; set; }
    }
}
