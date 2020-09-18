using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    interface IProductDB {
        Product GetProductByTypeInvoice(string productType, string invoice);
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
    }
}
