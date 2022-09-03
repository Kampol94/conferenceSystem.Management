using ManagementService.Domain.Members;
using ManagementService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ManagementService.Infrastructure.Domain.Members;

public class MemberRepository : IMemberRepository
{
    private readonly ManagementContext _context;

    public MemberRepository(ManagementContext meetingsContext)
    {
        _context = meetingsContext;
    }

    public async Task AddAsync(Member member)
    {
        await _context.Members.AddAsync(member);
    }

    public async Task<Member> GetByIdAsync(MemberId memberId)
    {
        return await _context.Members.FirstOrDefaultAsync(x => x.Id == memberId);
    }
}