using ProsegurChallengeApp_DAL.Entities;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IItemDA
    {
        Task<List<Item>> GetItemsByIds( int[] idsItem );
    }
}
