using System.ComponentModel.DataAnnotations.Schema;
using taskmanagement2.DTOS;

namespace taskmanagement2.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public string RoleName { get; set; }

        [ForeignKey("RoleId")] // Add this line to specify the foreign key relationship
        public Role Role { get; set; }
        public string? UserId { get;  set; }
        public object Name { get; set; }
    }
}
