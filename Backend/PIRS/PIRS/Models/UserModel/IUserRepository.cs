namespace PIRS.Models.UserModel
{
    public interface IUserRepository
    {
        public User add();
        public User edit(User user);
        public User delete(int id);
        public List<User> GetAll();
    }
}
