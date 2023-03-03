using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULDeneme.Core.DataAccess.EntityFramework;
using ULDeneme.DAL.Abstract;
using ULDeneme.DAL.Concrete.Context;
using ULDeneme.Model.Entities;

namespace ULDeneme.DAL.Concrete.Repository
{
    public class UserRepository : EFRepositoryBase<User, ULDenemeDbContext>, IUserDAL
    {
        public UserRepository(ULDenemeDbContext context) : base(context)
        {

        }
    }
}
