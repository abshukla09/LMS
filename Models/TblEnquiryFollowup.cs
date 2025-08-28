using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class TblEnquiryFollowup
{
    public int FollowupId { get; set; }

    public int EnquiryId { get; set; }

    public string FollowupDetail { get; set; } = null!;

    public DateTime? FollowupDate { get; set; }

    public bool? NextFollowUp { get; set; }

    public DateTime? NextFollowupDate { get; set; }

    public virtual TblEnquiry Enquiry { get; set; } = null!;
}
