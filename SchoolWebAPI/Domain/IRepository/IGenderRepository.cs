namespace SchoolWebAPI.Domain.IRepository
{
    using SchoolWebAPI.Domain.Entities.Generic;
    using SchoolWebAPI.Domain.Models;

    /// <summary>
    /// Gender Repository Interface
    /// </summary>
    public interface IGenderRepository
    {
        Task<List<Gender>> GetGenders();
    }
}
