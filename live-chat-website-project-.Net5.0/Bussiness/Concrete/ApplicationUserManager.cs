using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModel;
using System;
using System.Text;

namespace Business.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private readonly IApplicationUserDal _applicationUserDal;
        private readonly IApplicationUserRoleDal _applicationUserRoleDal;
        private readonly IImageDal _ımageDal;
        private readonly IEmailConfirmedDal _emailConfirmedDal;
        private readonly IMapper _mapper;

        public ApplicationUserManager(IApplicationUserRoleDal applicationUserRoleDal, IMapper mapper,
            IImageDal ımageDal, IApplicationUserDal applicationUserDal, IEmailConfirmedDal emailConfirmedDal)
        {
            _applicationUserRoleDal = applicationUserRoleDal;
            _mapper = mapper;
            _ımageDal = ımageDal;
            _applicationUserDal = applicationUserDal;
            _emailConfirmedDal = emailConfirmedDal;
        }

        public ResultDTO<EmailConfirmedDTO> EmailCodeControl(EmailConfirmedDTO emailConfirmedDTO)
        {
            throw new System.NotImplementedException();
        }

        public ResultDTO<EmailConfirmedDTO> EmailCodeSaved(EmailConfirmedDTO emailConfirmedDTO)
        {
            throw new System.NotImplementedException();
        }

        public ResultDTO<ApplicationUserDTO> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ResultDTO<ApplicationUserDTO> GetByMail(string email)
        {
            throw new System.NotImplementedException();
        }

        public ResultDTO<ApplicationUserDTO> SignIn(string emailAdress, string password)
        {
            string encodePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var model = _applicationUserDal.Get(u => u.Email == emailAdress && u.Password == encodePassword);
            var mapper = _mapper.Map<ApplicationUserDTO>(model);
            if (mapper != null)
            {
                return new ResultDTO<ApplicationUserDTO> { Data = mapper, Success = true };
            }
            else
            {
                return new ResultDTO<ApplicationUserDTO> { Data = null, Success = false };
            }
        }

        public ResultDTO<ApplicationUserDTO> SignUp(ApplicationUserDTO model)
        {
            var userToCheck = _applicationUserDal.Get(i=>i.Email==model.Email);
            if (userToCheck != null)
            {
                return new ResultDTO<ApplicationUserDTO> { Message = Messages.UserAlreadyExist, Success = false };
            }
            string encodePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password));
            model.Password = encodePassword;
            var mapper = _mapper.Map<ApplicationUser>(model);
            _applicationUserDal.Add(mapper);
            model.Id = mapper.Id;
            return new ResultDTO<ApplicationUserDTO> { Data = model, Success = true };


        }

        public ResultDTO<ApplicationUserDTO> Update(ApplicationUserDTO model)
        {
            throw new System.NotImplementedException();
        }
    }
}
