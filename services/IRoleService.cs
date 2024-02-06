using taskmanagement2.DTOS;

namespace taskmanagement2.services
{
    internal interface IRoleService
    {
        Role GetRoleById(long roleId);
    }
}