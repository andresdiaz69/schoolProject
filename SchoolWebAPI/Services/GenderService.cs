using SchoolWebAPI.Domain.Entities.Generic;
using SchoolWebAPI.Domain.IRepository;
using SchoolWebAPI.Domain.IServices;
using SchoolWebAPI.Domain.Models;
using SchoolWebAPI.Persistence.Repositories;

namespace SchoolWebAPI.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenderService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GenderService(IGenderRepository repository)
        {
            _genderRepository = repository;
        }

        /// <summary>
        /// Gets all genders.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<Gender>>> GetAllGenders()
        {
            try
            {
                var genders = await _genderRepository.GetGenders();

                if (genders == null)
                    return Result<List<Gender>>.Failure("No Gender");

                return Result<List<Gender>>.Success(genders);
            }
            catch (Exception ex)
            {
                return Result<List<Gender>>.Failure($"Error getting Genders: {ex.Message}");
            }

        }
    }
}
