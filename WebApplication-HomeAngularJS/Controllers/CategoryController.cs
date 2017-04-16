using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication_HomeAngularJS.Models;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace WebApplication_HomeAngularJS.Controllers
{
    public class CategoryController : ApiController
    {
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            string fileName = "Category.xml";
            string xmlpath = "E:\\XMLData\\";
            Path.Combine(xmlpath, fileName);
            XDocument doc = XDocument.Load(Path.Combine(xmlpath, fileName));
            foreach (XElement element in doc.Descendants("DocumentElement")
                .Descendants("Category"))
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(element.Element("ID").Value);
                category.Name = element.Element("Name").Value;                
                categories.Add(category);
            }
            return categories;
        }
        public Category GetCategory(int id)
        {
            Category category = new Category();string fileName = "Category.xml";
            string xmlpath = "E:\\XMLData\\";
            Path.Combine(xmlpath, fileName);
            XDocument doc = XDocument.Load(Path.Combine(xmlpath, fileName));
            XElement element = doc.Element("DocumentElement")
                                .Elements("Category").Elements("ID").
                                SingleOrDefault(x => x.Value == id.ToString());
            if (element != null)
            {
                XElement categoryParent = element.Parent;
                category.ID = Convert.ToInt32(categoryParent.Element("ID").Value);
                category.Name =
                        categoryParent.Element("Name").Value;

                List<Forum> forums = new List<Forum>();
                foreach (XElement childElement in categoryParent.Descendants("Forum"))
                {
                    Forum childforums = new Forum();
                    childforums.ID = Convert.ToInt32(childElement.Element("ID").Value);
                    childforums.UserName = childElement.Element("UserName").Value;
                    childforums.UserComment = childElement.Element("UserComment").Value;
                    forums.Add(childforums);
                }
                category.Forums = forums;

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