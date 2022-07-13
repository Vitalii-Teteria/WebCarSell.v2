using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCarSell.DataAccess.Entities
{
    public class Photos
    {
        public int Id { get; private set; }

        public string PhotoName { get; private set; }

        public byte[] Data { get; private set; }
    }
}
