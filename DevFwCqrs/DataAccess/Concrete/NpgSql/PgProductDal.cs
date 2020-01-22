using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.NpgSql.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.NpgSql
{
    public class PgProductDal:EfEntityRepositoryBase<Product,NorthwindPgContext>,IProductDal
    {
    }
}
