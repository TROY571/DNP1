namespace Tier1.Services
{
    public interface ISockets
    {
        void Connect();

        string Register(int id, string name, string mail, string password);
    }
}