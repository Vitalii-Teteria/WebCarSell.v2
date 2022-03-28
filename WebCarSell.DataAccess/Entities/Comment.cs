using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebCarSell.DataAccess.Entities
{
    public class Comment : ISoftDeletable
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Comments { get; set; }

        [Required]
        public List<Client> Client { get; set; }

        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        public bool IsDeleted { get; set; }
    }
}
