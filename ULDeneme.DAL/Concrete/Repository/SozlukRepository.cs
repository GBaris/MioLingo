using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ULDeneme.Core.DataAccess.EntityFramework;
using ULDeneme.DAL.Abstract;
using ULDeneme.DAL.Concrete.Context;
using ULDeneme.Model.Entities;

namespace ULDeneme.DAL.Concrete.Repository
{
    public class SozlukRepository : EFRepositoryBase<Sozluk, ULDenemeDbContext>, ISozlukDAL
    {
        private readonly ULDenemeDbContext _context;
        public SozlukRepository(ULDenemeDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Sozluk> GetList(Expression<Func<Sozluk, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<Sozluk>().ToList()
            : _context.Set<Sozluk>().Where(filter).ToList();
        }

        public Sozluk Update(Sozluk entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
