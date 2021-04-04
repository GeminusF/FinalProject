using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{   // is kodunu yazacagimiz interfaceleri sevice olaraq adlandirariq
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
