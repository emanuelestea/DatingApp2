using DatingApp2.DTO;
using DatingApp2.Helper;
using DatingApp2.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp2.Interfaces
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDTO>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDTO>> GetMessageThread(string currentUserName, string recipientUsername);
        Task<bool> SaveAllAsync();
    }
}
