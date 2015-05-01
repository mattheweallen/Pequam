using Pequam.Data.Entities;

namespace Pequam.Data.SqlServer.Mapping
{
    public class ParticipantMap : VersionedClassMap<Participant>
    {
        public ParticipantMap()
        {
            Id(x => x.ParticipantId);
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.UserName).Not.Nullable();
        }

    }
}
