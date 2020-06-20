using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace LocalDatabaseTutorial.Models
{
    public interface IDatabase
    {
        Task<List<Account>> GetAccountsAsync();
        Task<int> SaveAccountAsync(Account account);
    }
}
