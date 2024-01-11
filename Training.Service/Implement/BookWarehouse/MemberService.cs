using AutoMapper;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel;

namespace Training.Service.Implement.BookWarehouse
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public MemberViewModel Add(MemberViewModel memberViewModel)
        {
            var datas = _mapper.Map<MemberViewModel, Member>(memberViewModel);
            _memberRepository.Add(datas);
            _memberRepository.Commit();
            return memberViewModel;
        }

        public void Delete(int id)
        {
            _memberRepository.Delete(id);
            _memberRepository.Commit();
        }

        public List<MemberViewModel> GetMemberByName(string name)
        {
            var datas = _memberRepository.GetMemberByName(name);
            List<MemberViewModel> result = new List<MemberViewModel>();
            if(datas != null)
            {
                foreach (var data in datas)
                {
                    MemberViewModel memberViewModel = new MemberViewModel()
                    {
                        Name = data.Name,
                        CreatedBy = data.CreatedBy,
                        CreatedAt = data.CreatedAt,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedAt = data.UpdatedAt,
                    };
                    result.Add(memberViewModel);
                }
            }
            return result;
        }

        public List<MemberViewModel> GetMembers()
        {
            List<Member> datas = _memberRepository.FindAll();
            List<MemberViewModel> dataView = _mapper.Map<List<Member>, List<MemberViewModel>>(datas);
            return dataView;
        }

        public void Update(MemberViewModel memberViewModel)
        {
            Member datas = _memberRepository.FindById(memberViewModel.Id);
            if(datas == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _memberRepository.Update(datas);
                _memberRepository.Commit();
            }
        }
    }
}