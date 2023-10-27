using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal: GenericRepository<Booking>,IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

      
        public void BookingStatusChangeApproved(int id)
        {
            Context context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = true; 
            
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            return context.Bookings.Count();
        }

        public List<Booking> Last6BookingList()
        {
           var context = new Context();
            var values = context.Bookings.OrderByDescending(x=>x.BookingId).Take(6).ToList();
            return values;
        }
    }
}
