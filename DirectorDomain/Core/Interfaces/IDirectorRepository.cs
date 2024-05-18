using DirectorDomain.Core.Entities;

namespace DirectorDomain.Core.Interfaces
{
    public interface IDirectorRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Director>> GetAll();
        Task<bool> Insert(Director director);
        Task<bool> Update(Director director);
    }
}