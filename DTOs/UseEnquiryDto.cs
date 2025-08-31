namespace LMS;

public class UseEnquiryDto
{
    public int USEREnquiryId { get; set; }
    public int EnquiryId { get; set; }
    public int UserId { get; set; }
}

public class EnquiryWithUserDto
{
    public List<EnquiryDto> userEnquiry { get; set; }
    public UserDto User { get; set; }
    public List<EnquiryFolowupDto> userFollowUps { get; set; }
}