namespace LMS;

public class EnquiryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MobileNo { get; set; }
    public string EmailId { get; set; }
    public string? Purpose { get; set; }
    public bool? IsVerified { get; set; }
    public int StatusId { get; set; }
    public string? StatusName { get; set; }
    public DateTime? CreatedDate { get; set; }
}