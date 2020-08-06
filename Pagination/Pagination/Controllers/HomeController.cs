using Pagination.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        List<Phone> phones;
        public HomeController()
        {
            phones = new List<Phone>();
            phones.Add(new Phone { Id = 0, Fam = "Иванов", Tel = "8923215634" });
            phones.Add(new Phone { Id = 1, Fam = "Петров", Tel = "8923215734" });
            phones.Add(new Phone { Id = 2, Fam = "Сидоров", Tel = "8929615634" });
            phones.Add(new Phone { Id = 3, Fam = "Смирнов", Tel = "8923215364" });
            phones.Add(new Phone { Id = 4, Fam = "Быков", Tel = "8923215619" });
            phones.Add(new Phone { Id = 5, Fam = "Жданов", Tel = "8923217434" });
            phones.Add(new Phone { Id = 6, Fam = "Кузнецов", Tel = "8923215619" });
            phones.Add(new Phone { Id = 7, Fam = "Новоселов", Tel = "8923213126" });
            phones.Add(new Phone { Id = 8, Fam = "Грушин", Tel = "8923273455" });
            phones.Add(new Phone { Id = 9, Fam = "Семечев", Tel = "8923624977" });
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Phone> phonesPerPages = phones.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phones.Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phonesPerPages };
            return View(ivm);
        }

    }
}
