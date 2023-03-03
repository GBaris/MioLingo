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
    public class VocabularyRepository : EFRepositoryBase<Vocabulary, ULDenemeDbContext>, IVocabularyDAL
    {
        private readonly ULDenemeDbContext _context;
        public VocabularyRepository(ULDenemeDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Vocabulary> GetList(Expression<Func<Vocabulary, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<Vocabulary>().ToList()
            : _context.Set<Vocabulary>().Where(filter).ToList();
        }

        public Vocabulary Update(Vocabulary entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
