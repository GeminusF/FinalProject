﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{   //Dal - data access layer
    //Da0 - data access object
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
