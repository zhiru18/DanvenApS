using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDanvenClient.Models {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> products { get; set; }

        public Product(int id) {
            this.Id = id;
            products = new List<string>();
        }

        public Product() {
            products = new List<string>();
        }
    }
}