using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;

namespace SistemaInfra.Repository
{
    public class PhoebusRepository : Repository<Phoebus>, IPhoebusRepository
    {
        public PhoebusRepository(SuporteContext context) : base (context)
        {

        }
    }
}
