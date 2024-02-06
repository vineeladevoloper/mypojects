namespace taskmanagement2.Irepos
{
    using System.Collections.Generic;
    using taskmanagement2.Entities;

    public interface Iuser
    {
        public IEnumerable<UserDTO> GetAllUsers();
        public UserDTO GetUserById(long userId);
        public void AddUser(UserDTO userDTO);
        public void UpdateUser(UserDTO userDTO);
        public void DeleteUser(long userId);
        //public string GetUserByEmail(string email);
        //private void ValidateUser(UserDTO userDTO);

        //private UserDTO MapToUserDTO(UserEntity userEntity);

        //UserDTO GetUserByEmail(object email);
    }

}
