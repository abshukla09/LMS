# LMS
Step 1:     dotnet new sln –n LeadManagmentApiSolution
Note :     if you do not execute step 1 command then sln file generate itself in side your solution.
Step 2:     dotnet new webapi -n LeadManagment
  
Check Files inside LMS Folder
 
Step 3 :    dotnet sln LeadManagmentApiSolution.sln add LeadManagment.csproj
Step 4 :       Navigate into the project folder:    cd LeadManagment
Step 5 :       Create a new controller:
                 dotnet new mvccontroller(For MVC Application)
                 dotnet new apicontroller -n EnquiryController -o Controllers
Note : The default Web API template in .NET Core already includes Swagger.

Program.cs, it should have
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


How to Add EFCore in webAPI solution
//In Program.CS file add this line.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
For Now will put our connection string in Appsettings.json file later will move it from here
 

Now inside solution will create following folder to structure our solution
•	DataBase
•	Models
•	Functionality
•	Services
Next will Four Package to configure EFCORE
•	dotnet add package Microsoft.EntityFrameworkCore
•	dotnet add package Microsoft.EntityFrameworkCore.SqlServer
•	dotnet add package Microsoft.EntityFrameworkCore.Tools
•	dotnet add package Microsoft.EntityFrameworkCore.Design
Once you execute above four command ,you can able to see updated packages in csproj file.
 
Next will do database connectivity .So in EFCore we have two approaches for DB connectivity
•	Data Base First Approaches
•	Code First
And we will go with Database first approache. For that we have to execute below command 

dotnet ef dbcontext scaffold "Server=DESKTOP-3NP53N0;Database= DB_ManageLead;
User Id=sa;Password=Abhi@1234;TrustServerCertificate=True;"   
 Microsoft.EntityFrameworkCore.SqlServer -o DataBase

 

With Run of Above command inside database folder below files will created itself.
 
Now will shift all class file inside Model folder.And connection string will move in Program.CS file.
Next will Create the end points to perform CURD operation with leads.

 public IActionResult GetEnquiries()
        {
            var enquiries = _context.TblEnquiries.ToList();
            return Ok(enquiries);
        }

 public IActionResult GetEnquiryById(int id)
        {
            var enquiry = _context.TblEnquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }
            return Ok(enquiry);
        }





 public IActionResult CreateEnquiry(TblEnquiry enquiry)
        {
            _context.TblEnquiries.Add(enquiry);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnquiryById), new { id = enquiry.Id }, enquiry);
        }


  public IActionResult UpdateEnquiry(int id, TblEnquiry enquiry)
        {
            if (id != enquiry.Id)
            {
                return BadRequest();
            }

            _context.Entry(enquiry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }



Lets build the solution now  : dotnet build
 


Use DTOs to avoid cycles and control your API output. Only use ReferenceHandler.IgnoreCycles if you must return entities directly, but DTOs are the preferred solution.
         Create new class for DTO object:   dotnet new class -n EnquiryDto -o DTOs
 



So above action method is not good as we pass enties directly to API and there are too many limitation to do like this. So now we create DTO class than add functionality in functionality folder then will check other things.

List Of Functionality what we have:
•	Add Enquiry      	     Edit Enquiry		Get Enquiry list		Search Enquiry By ID
•	Add User                Edit User                      Get User List                     Search UserBy ID
•	Add User To Enquiry           UserEnquiry list
•	Add Followup      EditFollowup    Change Enquiry Status
