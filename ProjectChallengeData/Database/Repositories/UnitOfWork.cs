using Microsoft.EntityFrameworkCore;
using ProjectChallengeData.Database.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeData.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProjectContextDb _context;
        private IClientRepository _clientRepository;
        public UnitOfWork(ProjectContextDb context)
        {
            _context = context;
        }
        public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(_context));

        public int Commit()
        {
            var n = _context.SaveChanges();
            DetachAllEntities();

            return n;
        }

        private void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
