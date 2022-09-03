using System.Data;

namespace ManagementService.Application.Contracts;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}