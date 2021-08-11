using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MainAdiLink.Models
{
    public class WeblinkDescriptionViewModel
    {
        public List<Weblink> Weblinks { get; set; }
        public SelectList Descriptions { get; set; }
        public string WeblinkDescription { get; set; }
        public string SearchString { get; set; }
    }
}
