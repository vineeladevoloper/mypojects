using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using taskmanagement2.Entities;
using taskmanagement2.Irepos;

namespace taskmanagement2.services
{
    public class UserService : Iuser
    {
        private readonly MyDbContext _dbContext;

        public string email { get;  set; }

        public UserService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _dbContext.Users
                .Include(u => u.Role)
                .Select(userEntity => MapToUserDTO(userEntity))
                .ToList();

            return users;
        }

        public UserDTO GetUserById(long userId)
        {
            var userEntity = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == userId);

            return userEntity != null ? MapToUserDTO(userEntity) : null;
        }
         
        public void AddUser(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            var userEntity = MapToUserEntity(userDTO);
            _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();
        }
         
        public void UpdateUser(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            var existingUserEntity = _dbContext.Users.Find(userDTO.Id);

            if (existingUserEntity != null)
            {
                // Update user properties
                existingUserEntity.Username = userDTO.Username;
                existingUserEntity.Email = userDTO.Email;
                existingUserEntity.RoleId = userDTO.RoleId;

                _dbContext.SaveChanges();
            }
            // Handle the case where the user with the given ID is not found
        }

        public void DeleteUser(long userId)
        {
            var userEntity = _dbContext.Users.Find(userId);

            if (userEntity != null)
            {
                _dbContext.Users.Remove(userEntity);
                _dbContext.SaveChanges();
            }
            // Handle the case where the user with the given ID is not found
        }

        private UserDTO MapToUserDTO(UserEntity userEntity)
        {
            return new UserDTO
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = null, // Assuming you don't want to expose the password in DTO
                RoleId = userEntity.RoleId,
                Role = userEntity.Role // Assuming Role is a navigation property
            };
        }

        private UserEntity MapToUserEntity(UserDTO userDTO)
        {
            return new UserEntity
            {
                 Username = userDTO.Username,
                Email = userDTO.Email,
                RoleId = userDTO.RoleId
            };
        }

        private void ValidateUser(UserDTO userDTO)
        {
            var validationContext = new ValidationContext(userDTO, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            // Validate using data annotations
            if (!Validator.TryValidateObject(userDTO, validationContext, validationResults, true))
            {
                var validationErrors = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
                throw new ValidationException($"UserDTO validation failed: {validationErrors}");
            }  

            // Additional custom validation
            if (userDTO.Password != null && userDTO.Password.Length < 8)
            {
                throw new ValidationException("Password must be at least 8 characters long.");
            }
        }

        
    }
}
   