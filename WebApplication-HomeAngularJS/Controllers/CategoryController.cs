//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace WebApplication_HomeAngularJS.Controllers
//{
//    public class CategoryController : ApiController
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication_HomeAngularJS.Models;
using System.Xml.Linq;
namespace WebApplication_HomeAngularJS.Controllers
{
    public class CategoryController : ApiController
    {
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            //XDocument doc = XDocument.Load("D:\\Mudita\\Category.xml");
            //XDocument doc = XDocument.Load("E:\\1-Parvathi\\XMLData\\Category.xml");
            if (System.IO.File.Exists(@"(E:\XMLData\Category.xml") == true)
                return categories;
            XDocument doc = XDocument.Load(@"(E:\XMLData\Category.xml");
            foreach (XElement element in doc.Descendants("DocumentElement")
                .Descendants("Category"))
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(element.Element("ID"));
                category.Name = element.Element("Name").Value;
                category.AddedDate = Convert.ToDateTime(element.Element("AddedDate").Value);
                categories.Add(category);
            }
            return categories;
        }
        public Category GetCategory(int id)
        {
            Category category = new Category();
            //XDocument doc = XDocument.Load("D:\\Mudita\\Category.xml");
            XDocument doc = XDocument.Load("E:\\1-Parvathi\\AngularJS Application DEvelopment\\Application\\Application-AngularJS\\WebApplication-HomeAngularJS\\XML Data\\Category.xml");
            XElement element = doc.Element("DocumentElement")
                                .Elements("Category").Elements("ID").
                                SingleOrDefault(x => x.Value == id.ToString());
            if (element != null)
            {
                XElement parent = element.Parent;
                category.ID =
                        //parent.Element("ID").Value;
                        Convert.ToInt32(parent.Element("ID"));
                category.Name =
                        parent.Element("Name").Value;
                category.AddedDate =
                        //parent.Element("Address").Value;
                        Convert.ToDateTime(parent.Element("AddedDate").Value);
                return category;
            }
            else
            {
                throw new HttpResponseException
                    (new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
    }
}