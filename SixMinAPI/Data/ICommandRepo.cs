using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface ICommandRepo 
    {
        Task SaveChanges();
        Task<Commandm?> GetCommandById(int id);
        Task<IEnumerable<Commandm>> GetAllCommands();
        Task CreateCommand(Commandm cmd);
        
        void DeleteCommand(Commandm cmd);
    }    
}