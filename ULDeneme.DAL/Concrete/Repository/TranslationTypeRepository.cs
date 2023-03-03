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
    public class TranslationTypeRepository : EFRepositoryBase<TranslationType, ULDenemeDbContext>, ITranslationTypeDAL
    {
        private readonly ULDenemeDbContext _context;
        public TranslationTypeRepository(ULDenemeDbContext context) : base(context)
        {
            _context = context;
        }
        public List<TranslationType> GetList(Expression<Func<TranslationType, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<TranslationType>().ToList()
            : _context.Set<TranslationType>().Where(filter).ToList();
        }
        public TranslationType Update(TranslationType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
