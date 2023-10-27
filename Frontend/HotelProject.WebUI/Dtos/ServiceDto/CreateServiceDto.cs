using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
       [Required(ErrorMessage ="Hizmet ikon linki giriniz.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100,ErrorMessage ="Başlık 100 karakterden uzun olmamalı.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        public string Description { get; set; }
    }
}
