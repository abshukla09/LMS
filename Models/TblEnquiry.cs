using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class TblEnquiry
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? Purpose { get; set; }

    public bool? IsVerified { get; set; }

    public int StatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual TblEnquiryStatusMaster? Status { get; set; } = null!;

    public virtual ICollection<TblEnquiryFollowup> TblEnquiryFollowups { get; set; } = new List<TblEnquiryFollowup>();

    public virtual ICollection<TblUserEnquiry> TblUserEnquiries { get; set; } = new List<TblUserEnquiry>();
}
