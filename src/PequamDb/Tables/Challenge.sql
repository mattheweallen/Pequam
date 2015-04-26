CREATE TABLE [dbo].[Challenge] (
    [ChallengeId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Subject]       NVARCHAR (100) NOT NULL,
    [StartDate]     DATETIME2 (7)  NULL,
    [DueDate]       DATETIME2 (7)  NULL,
    [CompletedDate] DATETIME2 (7)  NULL,
    [StatusId]      BIGINT         NOT NULL,
    [CreatedDate]   DATETIME2 (7)  NOT NULL,
    [CreatedParticipantId]   bigint  NOT NULL,
    [ts]            rowversion     NOT NULL,
    PRIMARY KEY CLUSTERED ([ChallengeId] ASC),
    FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId]),
    FOREIGN KEY ([CreatedParticipantId]) REFERENCES [dbo].[Participant] ([ParticipantId])
);