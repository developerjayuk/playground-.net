USE [TodoDb]
GO

/****** Object: Table [dbo].[Todos] Script Date: 19/07/2022 07:49:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Todos] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Task]       NVARCHAR (150) NOT NULL,
    [AssignedTo] INT            NOT NULL,
    [IsComplete] BIT            NOT NULL
);


USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_CompleteTodo] Script Date: 19/07/2022 07:49:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_CompleteTodo]
	@AssignedTo int,
	@TodoId int
AS

BEGIN
	update dbo.Todos
	set IsComplete = 1
	where Id = @TodoId and AssignedTo = @AssignedTo;
END

USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_Create] Script Date: 19/07/2022 07:50:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_Create]
	@Task nvarchar(150),
	@AssignedTo int
AS

BEGIN
	insert into dbo.Todos (Task, AssignedTo)
	values (@Task, @AssignedTo);

	select Id, Task, AssignedTo, IsComplete
	from dbo.Todos
	where Id = SCOPE_IDENTITY(); -- @@Identity
END

USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_Delete] Script Date: 19/07/2022 07:50:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_Delete]
	@AssignedTo int,
	@TodoId int
AS

BEGIN
	delete from dbo.Todos
	where Id = @TodoId and AssignedTo = @AssignedTo;
END

USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_GetAllAssigned] Script Date: 19/07/2022 07:51:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_GetAllAssigned]
	 @AssignedTo int
AS

BEGIN
	select Id, Task, AssignedTo, IsComplete 
	from dbo.Todos
	where AssignedTo = @AssignedTo;
END

USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_GetOneAssigned] Script Date: 19/07/2022 07:51:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_GetOneAssigned]
	 @AssignedTo int,
	 @TodoId int
AS

BEGIN
	select Id, Task, AssignedTo, IsComplete 
	from dbo.Todos
	where AssignedTo = @AssignedTo and Id = @TodoId;
END

USE [TodoDb]
GO

/****** Object: SqlProcedure [dbo].[spTodos_UpdateTask] Script Date: 19/07/2022 07:52:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTodos_UpdateTask]
	@Task nvarchar(150),
	@AssignedTo int,
	@TodoId int
AS

BEGIN
	update dbo.Todos
	set Task = @Task
	where Id = @TodoId and AssignedTo = @AssignedTo;
END
