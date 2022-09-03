namespace ManagementService.Domain.Contracts;

public interface IBaseBusinessRule
{
    bool IsBroken();

    string Message { get; }
}