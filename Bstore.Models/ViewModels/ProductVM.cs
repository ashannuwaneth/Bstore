using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bstore.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerator<SelectListItem> CategoryList { get; set; }

        public IEnumerator<SelectListItem> CovereTypeList { get; set; }
    }
}
