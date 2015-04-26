CREATE TABLE [dbo].[ChallengeParticipant]
(
	[ChallengeId] bigint NOT NULL,
	[ParticipantId] bigint not null,
	[ts] rowversion not null,
	primary key (ChallengeId, ParticipantId),
	foreign key (ParticipantId) references dbo.[Participant] (ParticipantId),
	foreign key (ChallengeId) references dbo.Challenge (ChallengeId) 
)
go

create index ix_ChallengeParticipant_ParticipantId on ChallengeParticipant(ParticipantId)
go