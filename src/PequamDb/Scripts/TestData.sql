declare @statusId int,
	@challengeId int,
	@participantId int

if not exists (select * from [Participant] where Username = 'bhogg')
	INSERT into [dbo].[Participant] ([Firstname], [Lastname], [Username]) 
		VALUES (N'Boss', N'Hogg', N'bhogg')

if not exists (select * from [Participant] where Username = 'jbob')
	INSERT into [dbo].[Participant] ([Firstname], [Lastname], [Username]) 
		VALUES (N'Jim', N'Bob', N'jbob')

if not exists (select * from [Participant] where Username = 'jdoe')
	INSERT into [dbo].[Participant] ([Firstname], [Lastname], [Username]) 
		VALUES (N'John', N'Doe', N'jdoe')

if not exists(select * from dbo.Challenge where Subject = 'Test Challenge')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @participantId = ParticipantId from [Participant] order by ParticipantId;

	insert into dbo.Challenge(Subject, StartDate, StatusId, CreatedDate, CreatedParticipantId)
		values('Test Challenge', getdate(), @statusId, getdate(), @participantId);

	set @challengeId = SCOPE_IDENTITY();
	
	INSERT [dbo].[ChallengeParticipant] ([ChallengeId], [ParticipantId]) 
		VALUES (@challengeId, @participantId)
end