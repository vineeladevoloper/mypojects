using System.ComponentModel.DataAnnotations.Schema;
using taskmanagement2.DTOS;

public class UserDTO
{

    public long Id { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public long RoleId { get; set; }
    public Role Role { get; set; }
    // Additional properties, if needed
}
