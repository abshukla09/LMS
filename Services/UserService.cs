
namespace LMS;

using LMS.DataBase;
using LMS.Models;


public class UserService : IUserService
{
    TblUser _context;
    DbManageLeadContext _dbContext;
    public UserService(DbManageLeadContext dbContext)
    {
        
        _dbContext = dbContext;
    }
    void IUserService.AddUser(UserDto user)
    {
        _dbContext.TblUsers.Add(new TblUser
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Fname = user.Fname,
            Mname = user.Mname,
            Lname = user.Lname,
            MobileNo = user.MobileNo,
            EmailId = user.EmailId,
            IsActive = user.IsActive
        });
        _dbContext.SaveChanges();
    }

    void IUserService.DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<UserDto> IUserService.GetAllUsers()
    {
        var users = _dbContext.TblUsers.Select(u => new UserDto
        {
            UserId = u.UserId,
            UserName = u.UserName,
            Fname = u.Fname,
            Mname = u.Mname,
            Lname = u.Lname,
            MobileNo = u.MobileNo,
            EmailId = u.EmailId,
            IsActive = u.IsActive
        }).ToList();

        return users;
    }

    UserDto? IUserService.GetUserById(int id)
    {
        var user = _dbContext.TblUsers
            .Where(u => u.UserId == id)
            .Select(u => new UserDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Fname = u.Fname,
                Mname = u.Mname,
                Lname = u.Lname,
                MobileNo = u.MobileNo,
                EmailId = u.EmailId,
                IsActive = u.IsActive
            })
            .FirstOrDefault();

        return user;
    }

    void IUserService.UpdateUser(UserDto user)
    {
        var existingUser = _dbContext.TblUsers.Find(user.UserId);
        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.Fname = user.Fname;
            existingUser.Mname = user.Mname;
            existingUser.Lname = user.Lname;
            existingUser.MobileNo = user.MobileNo;
            existingUser.EmailId = user.EmailId;
            existingUser.IsActive = user.IsActive;

            _dbContext.SaveChanges();
        }
    }
}
