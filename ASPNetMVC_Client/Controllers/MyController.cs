using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVC_Client.ReadListNS;

namespace ASPNetMVC_Client.Controllers
{
    public class MyController : Controller
    {
        private ReadListContractClient _client;
        public ReadListContractClient Client {
            get
            {
                if (_client == null)
                {
                    _client = new ReadListContractClient();
                }

                return _client;
            }
        }
        public ActionResult Index()
        {
            try
            {
                var list = Client.GetAllReadLists();
                return View(list);
            }
            catch
            {
                return View("Index", null);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var temp = Client.GetById(id);
                return View(temp);
            }
            catch
            {
                return Redirect("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(ReadList rl)
        {
            try
            {
                string str = Client.DeleteById(rl.Id);
                return View("Message",(object)str);
            }
            catch
            {
                return View("Message",(object)"Видалення не вдалося!");
            }
        }

        public ActionResult Message(string str)
        {
            return View(str);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var temp = Client.GetById(id);
                return View(temp);
            }
            catch
            {
                return View("Message",(object)"Оновлення не вдалося!");
            }
        }

        [HttpPost]
        public ActionResult Edit(ReadList rl)
        {
            try
            {
                string str = Client.UpdateReadList(rl);
                return View("Message", (object)str);
            }
            catch
            {
                return View("Message",(object)"Оновлення не вдалося!");
            }
        }

        public ActionResult Insert()
        {
            return View(new ReadList(){AuthorName = "Автор", BookTitle = "Назва", ReadingDate = DateTime.Now, Page = 200, Rating = 1});
        }

        [HttpPost]
        public ActionResult Insert(ReadList rl)
        {
            try
            {
                string str = Client.InsertReadList(rl.AuthorName, rl.BookTitle, rl.ReadingDate, rl.Page, rl.Rating);
                return View("Message", (object)str);
            }
            catch
            {
                return View("Message",(object)"Додання не вдалося!");
            }
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return Redirect("/My/Index");
            }
            var list = Client.FindByAuthorOrTitle(searchString);
            return View("Index", list);
        }
    }
}