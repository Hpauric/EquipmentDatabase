using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace EquipmentDatabase.DAL
{
    public class ProjectConfiguration : DbConfiguration
    {
        public SchoolConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}