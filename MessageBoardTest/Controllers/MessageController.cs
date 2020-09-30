using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelInterface;

namespace MessageBoardTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        // Todo: add logging
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRepository _messageRepository;

        public MessageController(
            ILogger<MessageController> logger,
            IMessageRepository messageRepository)
        {
            _logger = logger;
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MessageOutputDto>> Get()
        {
            var messages = await _messageRepository.GetAll();

            // Todo: Extract mapping to dependency.
            return messages.Select(m => new MessageOutputDto
            {
                Message = m.Content
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(PostMessageDto message)
        {
            // Todo: Extract mapping to dependency.
            await _messageRepository.Add(new Message 
            {
                Content = message.Message,
                Id = Guid.NewGuid()
            });
            return Ok();
        }
    }
}
