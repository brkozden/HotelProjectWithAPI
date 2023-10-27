﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstrack
{
    public interface IBookingDal:IGenericDal<Booking>
    {
    
        int GetBookingCount();

        List<Booking> Last6BookingList();

        void BookingStatusChangeApproved(int id);
    }
}
