using FluentNHibernate.Mapping;
using Pequam.Data.Entities;

namespace Pequam.Data.SqlServer.Mapping
{
    public class ChallengeMap : VersionedClassMap<Challenge>
    {
        public ChallengeMap()
        {
            Id(x => x.ChallengeId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartDate).Nullable();
            Map(x => x.DueDate).Nullable();
            Map(x => x.CompletedDate).Nullable();
            Map(x => x.CreatedDate).Not.Nullable();

            References(x => x.Status, "StatusId");
            References(x => x.CreatedBy, "CreatedParticipantId");

            HasManyToMany(x => x.Participants)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .Table("ChallengeParticipant")
                .ParentKeyColumn("ChallengeId")
                .ChildKeyColumn("ParticipantId");
        }
    }
}
