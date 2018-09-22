using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsWebApp.Models
{
    interface IRepository
    {
        void bookRooms(BookedItem item);
    }
}
