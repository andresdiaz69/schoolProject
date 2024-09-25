using SchoolWebAPI.Domain.Entities.Generic;
using SchoolWebAPI.Domain.Models;

namespace SchoolWebAPI.Domain.IServices
{
    public interface IGenderService
    {
        Task<Result<List<Gender>>> GetAllGenders();
    }
}
