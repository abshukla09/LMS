using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class TblUserEnquiry
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EnquiryId { get; set; }

    public virtual TblEnquiry Enquiry { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
