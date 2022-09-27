using Denetim_Takip_Sistemi.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denetim_Takip_Sistemi.ViewModels
{
    public class BelgeFormViewModel
    {
        public IEnumerable<belge_tipi> Belge_Tipi { get; set; }

        public belge Belge { get; set; }

        public denetim Denetim { get; set; }

        public dosya_bilgisi Dosya { get; set; }

        public bitis_tarihi B_Tarih { get; set; }

        public nott Nott { get; set; }
    }
}