using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.NpgSql.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.NpgSql
{
    public class PgOperationClaimDal:EfEntityRepositoryBase<OperationClaim,NorthwindPgContext>,IOperationClaimDal
    {
    }
}
