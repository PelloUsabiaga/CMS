using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS02.Models
{
    public class DocumentViewList
    {
        public List<Document> Documents { get; set; }
        public string SearchString { get; set; }
    }
}
