using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebCarSell.DataAccess.Entities
{
    public class Basket : ISoftDeletable
    {
        [Required]
        public Order Order { get; set; }

        [Required]
        public Model Model { get; set; }

        public bool IsDeleted { get; set; }
    }
}
