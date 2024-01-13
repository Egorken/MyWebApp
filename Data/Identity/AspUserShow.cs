using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Data.Identity
{
    public class AspUserShow
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
    }
}
