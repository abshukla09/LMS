namespace LMS;

public interface IUserService
{
void AddUser(UserDto user);

    // Read
    UserDto? GetUserById(int id);
    IEnumerable<UserDto> GetAllUsers();

    // Update
    void UpdateUser(UserDto user);

    // Delete
    void DeleteUser(int id);
}
