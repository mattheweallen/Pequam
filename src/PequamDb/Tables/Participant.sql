CREATE TABLE [dbo].[Participant](
	[ParticipantId] BIGINT  IDENTITY (1, 1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
    [Username] NVARCHAR(50) NOT NULL, 
	[ts] [rowversion] NOT NULL, 
    CONSTRAINT [PK_Participant] PRIMARY KEY ([ParticipantId])
);