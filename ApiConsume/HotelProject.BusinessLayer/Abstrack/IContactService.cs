﻿using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstrack
{
    public interface IContactService:IGenericService<Contact>
    {
        public int TGetContactCount();
    }
}
