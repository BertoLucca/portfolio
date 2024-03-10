CREATE TABLE [task] (
    [id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT [pk__task__id] PRIMARY KEY CLUSTERED,
    [is_completed] BIT NOT NULL,
    [name] VARCHAR(80) NOT NULL,
    [description] VARCHAR(250),
    [created_at] DATETIME NOT NULL
        CONSTRAINT [df__task__created_at] DEFAULT GETDATE(),
);
GO
