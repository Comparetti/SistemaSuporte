using SuporteCore.Entity;
using System.Collections;
using System.Linq;

namespace SuporteCore.Interfaces.Repository
{
    public interface IPhoebusRepository : IRepository<Phoebus>
    {
        IQueryable<Phoebus> GetQueryable();

        void UpdatePhoebus(Phoebus phoebus);

    }
}
