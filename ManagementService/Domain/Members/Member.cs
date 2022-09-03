using ManagementService.Domain.Contracts;
using ManagementService.Domain.Members.Events;

namespace ManagementService.Domain.Members;

public class Member : BaseEntity
{
    public MemberId Id { get; private set; }

    private string _login;

    private string _email;

    private string _firstName;

    private string _lastName;

    private string _name;

    private DateTime _createDate;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Member()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        // Only for EF.
    }

    private Member(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        Id = new MemberId(id);
        _login = login;
        _email = email;
        _firstName = firstName;
        _lastName = lastName;
        _name = name;
        _createDate = DateTime.UtcNow;

        this.AddDomainEvent(new MemberCreatedDomainEvent(Id));
    }

    public static Member Create(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        return new Member(id, login, email, firstName, lastName, name);
    }
}