using Entities.Concrete;
using Entities.ViewModel;

namespace Business.Abstract
{
    public interface IApplicationUserService
    {
        ResultDTO<ApplicationUserDTO> GetByMail(string email);
        ResultDTO<ApplicationUserDTO> SignIn(string EmailAdress, string Password);
        ResultDTO<ApplicationUserDTO> SignUp(ApplicationUserDTO model);
        ResultDTO<ApplicationUserDTO> Update(ApplicationUserDTO model);
        ResultDTO<ApplicationUserDTO> GetById(int id);
        ResultDTO<EmailConfirmedDTO> EmailCodeSaved(EmailConfirmedDTO emailConfirmedDTO);
        ResultDTO<EmailConfirmedDTO> EmailCodeControl(EmailConfirmedDTO emailConfirmedDTO);
    }
}
