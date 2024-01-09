using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        public void BookingStatusApproved(int id);
        public void BookingStatusCancelled(int id);
    }
}
