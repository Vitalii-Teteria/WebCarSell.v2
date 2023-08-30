using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCarSell.BusinessLogic.DTO
{
    public class ModificationsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid SportsCategory { get; set; }
    }
}
