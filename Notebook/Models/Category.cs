using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notebook.Models {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }
        public Category() {
            Contacts = new List<Contact>();
        }
    }
}