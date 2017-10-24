using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLibrary.Manager;
using Microsoft.AspNetCore.Mvc;

namespace DncRestDemo.Controllers
{
    [Route("[controller]")]
    public class DemoController : Controller, IManager
    {
        private readonly IManager _manager;

        public DemoController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ManagerData GetDataById(int id) => _manager.GetDataById(id);

        [HttpPatch]
        public bool UpdateData(ManagerData data) => _manager.UpdateData(data);

        [HttpGet("whatever")]
        public string Whatever()
        {
            //using (var db = new BloggingContext())
            //{
            //    var b = new Blog {Rating = 3};
            //    db.Blogs.Add(b);
            //    db.SaveChanges();
            //    return b.BlogId.ToString();
            //}
            return "";
        }
    }
}
