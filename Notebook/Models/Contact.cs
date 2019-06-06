using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notebook.Models {
    public class Contact {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}