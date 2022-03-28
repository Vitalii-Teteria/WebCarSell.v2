using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;

namespace WEBCarSell.BusinessLogic.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public Employee Employee { get; set; }

        public Client Client { get; set; }
    }
}
