using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Entities;

namespace WEBCarSell.BusinessLogic.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Comments { get; set; }

        public List<Client> Client { get; set; }

        public string Phone { get; set; }
    }
}
