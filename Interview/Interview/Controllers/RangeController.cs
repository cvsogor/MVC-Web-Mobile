using Interview.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview.Controllers
{
    public class RangeController : Controller
    {
        [Route("Range/List")]
        [Route("Range/List/{name}")]
        public ActionResult List(string name)
        {
            Entities db = new Entities();
            List<Manufacturer> manufacturers;
            if (name == null)
            {
                manufacturers = db.Manufacturer.ToList();
            }
            else
            {
                manufacturers = new List<Manufacturer>();
                var manufacturer = db.Manufacturer.FirstOrDefault(x => x.ManufacturerName.ToLower() == name.ToLower());
                if (manufacturer != null)
                {
                    manufacturers.Add(manufacturer);
                }
            }
            return View(manufacturers);
        }
    }
}