declare @statusId int,
	@challengeId int,
	@userId int

if not exists (select * from [User] where Username = 'bhogg')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username]) 
		VALUES (N'Boss', N'Hogg', N'bhogg')

if not exists (select * from [User] where Username = 'jbob')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username]) 
		VALUES (N'Jim', N'Bob', N'jbob')

if not exists (select * from [User] where Username = 'jdoe')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username]) 
		VALUES (N'John', N'Doe', N'jdoe')

if not exists(select * from dbo.Challenge where Subject = 'Test Challenge')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @userId = UserId from [User] order by UserId;

	insert into dbo.Challenge(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
		values('Test Challenge', getdate(), @statusId, getdate(), @userId);

	set @challengeId = SCOPE_IDENTITY();
	
	INSERT [dbo].[ChallengeUser] ([ChallengeId], [UserId]) 
		VALUES (@challengeId, @userId)
end