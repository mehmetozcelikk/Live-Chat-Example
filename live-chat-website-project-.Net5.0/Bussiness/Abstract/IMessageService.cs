using Entities.ViewModel;

namespace Bussiness.Abstract
{
    public interface IMessageService
    {
        ResultDTO<MessageDTO> AddMessage(MessageDTO message);

    }
}
