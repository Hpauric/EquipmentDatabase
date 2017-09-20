using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace EquipmentDatabase.DAL
{
    public class ProjectConfiguration : DbConfiguration
    {
        public ProjectConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}