using Blog.Models;

namespace Blog.Interfaces
{
    public interface IMembership
    {
        Task<IEnumerable<Membership>> GetAllMembershipsAsync();
        Task<Membership> GetMembershipAsync(int id);
        Task<bool> ExistsMembershipByCodeAsync(string code);
        Task<bool> EnableCodeMembershipByCodeAsync(string code);
        Task DisableMembershipCodeAsync(string code);


        Task AddMembershipAsync(Membership membership);
        Task DeleteMembershipAsync(Membership membership);
    }
}
