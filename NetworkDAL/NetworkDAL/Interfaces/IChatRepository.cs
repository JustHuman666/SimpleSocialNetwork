using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDAL.Interfaces
{
    /// <summary>
    /// Repository interface for working with chat
    /// </summary>
    public interface IChatRepository : IRepository<Chat>, IDetailsRepository<Chat> 
    {
       
    }
}
