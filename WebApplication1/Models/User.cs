using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        public string userName { get; set; }

        public string userPw { get; set; }
    }
}
