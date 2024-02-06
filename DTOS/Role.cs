using taskmanagement2.Entities;

namespace taskmanagement2.DTOS
{
    public class Role
    {
        public long Id { get; set; }

        public string RoleName { get; set; }

        private List<UserEntity> users;

        public List<UserEntity> GetUsers()
        {
            return users;
        }
    }
}
