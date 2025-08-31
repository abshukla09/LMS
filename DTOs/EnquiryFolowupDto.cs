namespace LMS;

public class EnquiryFolowupDto
{
  public int Id { get; set; }
    public int EnquiryId { get; set; }
    public DateTime? FollowupDate { get; set; }
    public string? Remarks { get; set; }
    public bool? NextFollowUp { get; set; }
    public DateTime? NextFollowupDate { get; set; }
}
