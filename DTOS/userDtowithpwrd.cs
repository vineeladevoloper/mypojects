using System.ComponentModel.DataAnnotations.Schema;

namespace taskmanagement2.DTOS
{
    public class userDtowithpwrd
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }                                 

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
