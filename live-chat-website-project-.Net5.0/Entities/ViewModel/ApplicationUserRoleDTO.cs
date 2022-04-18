using Entities.Abstract;

namespace Entities.ViewModel
{
    public class ApplicationUserRoleDTO : BaseDTO, IDTO
    {
        public string RoleName { get; set; }
    }
}
