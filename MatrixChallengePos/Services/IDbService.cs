using System.Data.Common;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Impelementors will connect to their specific data store and provide an open SqlConnection for client use.
    /// </summary>
    public interface IDbService
    {
        /// <summary>
        /// An opened DbConnection
        /// </summary>
        DbConnection SqlConnection { get; }
    }
}