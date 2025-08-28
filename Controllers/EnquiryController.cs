using LMS;
using LMS.DataBase;
using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly DbManageLeadContext _context;

        public EnquiryController(DbManageLeadContext context)
        {
            _context = context;
        }
        // Action methods go here
        [HttpGet]
        public IActionResult GetEnquiries()
        {
            // var enquiries = _context.TblEnquiries.ToList();
            var enquiries = _context.TblEnquiries
      .Select(e => new EnquiryDto
      {
          Id = e.Id,
          Name = e.Name,
          MobileNo = e.MobileNo,
          EmailId = e.EmailId,
          Purpose = e.Purpose,
          IsVerified = e.IsVerified,
          StatusId = e.StatusId,
          StatusName = e.Status != null ? e.Status.StatusName : null,
          CreatedDate = e.CreatedDate
      })
      .ToList();

            return Ok(enquiries);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnquiryById(int id)
        {
            var enquiry = _context.TblEnquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }
            var EnqyDTO = new EnquiryDto
            {
                Id = enquiry.Id,
          Name = enquiry.Name,
          MobileNo = enquiry.MobileNo,
          EmailId = enquiry.EmailId,
          Purpose = enquiry.Purpose,
          IsVerified = enquiry.IsVerified,
          StatusId = enquiry.StatusId,
          StatusName = enquiry.Status != null ? enquiry.Status.StatusName : null,
          CreatedDate = enquiry.CreatedDate
            };
            return Ok(EnqyDTO);
        }
        [HttpPost]
        public IActionResult CreateEnquiry(EnquiryDto enquiry)
        {
            var enqObj = new TblEnquiry
            {
                Name = enquiry.Name,
                MobileNo = enquiry.MobileNo,
                EmailId = enquiry.EmailId,
                Purpose = enquiry.Purpose,
                StatusId = enquiry.StatusId
            };
            _context.TblEnquiries.Add(enqObj);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnquiryById), new { id = enquiry.Id }, enquiry);
        }

        [HttpPost("Status")]
        public IActionResult AddStatus(TblEnquiryStatusMaster statusMaster)
        {
            _context.TblEnquiryStatusMasters.Add(statusMaster);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnquiryById), new { id = statusMaster.Id }, statusMaster);
        }
       

        [HttpPut("{id}")]
        public IActionResult UpdateEnquiry(int id, EnquiryDto enquiry)
        {
            var enqObj = _context.TblEnquiries.Find(id);
            if (enqObj == null)
                  return NotFound();

            enqObj.Name = enquiry.Name;
           
            _context.Entry(enqObj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
