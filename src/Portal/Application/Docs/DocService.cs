using AutoMapper;
using Portal.Application.Docs.Models;
using Portal.Domain.Entities;
using Portal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Docs
{
    public class DocService : IDocService
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public DocService(PortalDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Create(DocInfo docInfo)
        {
            _db.Docs.Add(_mapper.Map<DocInfo, Doc>(docInfo));
            await _db.SaveChangesAsync();
            return true;
        }

        public DocInfo GetById(Guid id)
        {
            var doc = _db.Docs.FirstOrDefault(d=>d.Id==id);
            return _mapper.Map<Doc, DocInfo>(doc);
        }

        public DocInfo GetByHash(int hashcode)
        {
            var doc = _db.Docs.Find(hashcode);
            return _mapper.Map<Doc, DocInfo>(doc);
        }
    }
}
