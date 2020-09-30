using ModelInterface;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryMessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private static ConcurrentBag<Message> _messages = new ConcurrentBag<Message>();

        public Task<RepositoryResult> Add(Message message)
        {
            _messages.Add(message);

            return Task.FromResult(new RepositoryResult());
        }

        public Task<IEnumerable<Message>> GetAll()
        {
            return Task.FromResult(_messages.AsEnumerable());
        }
    }
}
