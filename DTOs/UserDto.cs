namespace LMS;

public class UserDto
{
 public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public string MobileNo { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public bool? IsActive { get; set; }
}
