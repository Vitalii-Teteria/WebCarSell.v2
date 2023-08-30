using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;

namespace WebCarSell.DataAccess.Entities
{
    public class Modifications : ISoftDeletable
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Price { get; set; }
        public Guid SportCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
