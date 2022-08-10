using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        
        public List<OperationClaim> GetClaim(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = (from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims//.Where(u=>u.UserId == user.Id)
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                            where userOperationClaim.UserId == user.Id
                             select new OperationClaim { 
                                 Id = operationClaim.Id, 
                                 Name = operationClaim.Name 
                             });
                return result.ToList();
            }
        }
    }
}
