using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class TblEnquiryStatusMaster
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<TblEnquiry> TblEnquiries { get; set; } = new List<TblEnquiry>();
}
