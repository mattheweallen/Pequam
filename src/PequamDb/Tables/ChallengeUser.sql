CREATE TABLE [dbo].[ChallengeUser]
(
	[ChallengeId] bigint NOT NULL,
	[UserId] bigint not null,
	[ts] rowversion not null,
	primary key (ChallengeId, UserId),
	foreign key (UserId) references dbo.[User] (UserId),
	foreign key (ChallengeId) references dbo.Challenge (ChallengeId) 
)
go

create index ix_ChallengeUser_UserId on ChallengeUser(UserId)
go