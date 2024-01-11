using Training.Service.ViewModel;

namespace Training.Service.Interfaces
{
    public interface IMemberService
    {
        List<MemberViewModel> GetMembers();

        List<MemberViewModel> GetMemberByName(string name);
        MemberViewModel Add(MemberViewModel memberViewModel);

        void Update(MemberViewModel memberViewModel);

        void Delete(int id);
    }
}