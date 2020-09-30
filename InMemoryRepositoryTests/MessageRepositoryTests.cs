using InMemoryMessageRepository;
using ModelInterface;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace InMemoryRepositoryTests
{
    public class MessageRepositoryTests
    {
        [Test]
        public async Task AddAndRetrieveAMessageTest()
        {
            // Arrange
            var sut = new MessageRepository();
            var message = new Message { Content = "test content", Id = Guid.NewGuid() };

            // Act
            await sut.Add(message);
            var result = await sut.GetAll();

            // Assert
            Assert.That(result, Has.Some.Matches<Message>(n => n.Content == message.Content && n.Id == message.Id));
        }
    }
}