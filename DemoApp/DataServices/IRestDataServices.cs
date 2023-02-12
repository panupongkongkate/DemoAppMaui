using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DataServices
{
    public interface IRestDataServices
    {
        Task<List<Todo>> GetAllToDoAsync();
        Task AddToDoAsync(Todo todo);
        Task UpdateToDoAsync(Todo todo);
        Task DeleteToDoAsync(string id);

    }
}
