using System.Runtime.InteropServices.ComTypes;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Implementors will provide ICrudService functionality for their specific data stores.
    /// </summary>
    public interface IEmployeeService : ICrudService<Employee, int>
    {
    }
}