using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelInterface
{
    public interface IMessageRepository
    {
        Task<RepositoryResult> Add(Message message);
        Task<IEnumerable<Message>> GetAll();
    }
}
