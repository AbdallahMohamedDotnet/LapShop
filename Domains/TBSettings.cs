using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShopv2.Models
{
    public class TBSettings
    {
        public int id { get; set; }
        public string webSiteName { get; set; }
        public string Logo { get; set; }
        public string WebSiteDescription { get; set; }
        public string FaceBookLink { get; set; }
        public string instegramLink { get; set; }
        public string YoutubeLink { get; set; }
        public string WhatsAppLink { get; set; }

    }
}
