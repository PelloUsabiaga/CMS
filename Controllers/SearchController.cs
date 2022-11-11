using CMS02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS02.Controllers
{
    public class SearchController : Controller
    {
        private readonly MyDBContext __context;
        public SearchController(MyDBContext context)
        {
            __context = context;
        }
        public async Task<IActionResult> IndexAsync(string SearchString)
        {
            DocumentViewList ViewList = new DocumentViewList();
            if (SearchString == null) 
            {
                ViewList.Documents = null;
                return View(ViewList);
            }
            else
            {
                IQueryable<Document> Documents = from doc in __context.Document
                                                 where (doc.Name.Contains(SearchString) || doc.Description.Contains(SearchString)) && doc.Public
                                                 select doc;

                ViewList.Documents = await Documents.ToListAsync();
                
                return View(ViewList);
            }

        }
    }
}
