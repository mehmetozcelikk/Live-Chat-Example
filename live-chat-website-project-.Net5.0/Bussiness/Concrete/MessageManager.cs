using AutoMapper;
using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModel;

namespace Bussiness.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IMapper _mapper;

        public MessageManager(IMessageDal messageDal, IMapper mapper
             )
        {
            _mapper = mapper;
            _messageDal = messageDal;
        }
        public ResultDTO<MessageDTO> AddMessage(MessageDTO message)
        {
            var mapper = _mapper.Map<Message>(message);
            _messageDal.Add(mapper);

            return new ResultDTO<MessageDTO> { Data = null, Success = false };

        }
    }
}
