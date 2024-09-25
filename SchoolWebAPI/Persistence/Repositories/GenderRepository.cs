namespace SchoolWebAPI.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.IRepository;
    using SchoolWebAPI.Domain.Models;
    using SchoolWebAPI.Persistence.Context;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Student Repository class
    /// </summary>
    /// <seealso cref="SchoolWebAPI.Domain.IRepository.IGenderRepository" />
    public class GenderRepository : IGenderRepository
    {
        private readonly SchoolDbContext _context;

        public GenderRepository(SchoolDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Gets the genders.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<Gender>> GetGenders()
        {
            return await _context.Genders
                    .Where(x => x.Active).ToListAsync();
        }
    }
}
