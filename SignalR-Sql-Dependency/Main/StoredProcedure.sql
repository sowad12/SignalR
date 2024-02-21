EXEC(N'CREATE OR ALTER PROC HUMAN_INFO_SELECTTT
(
 
   @Name nvarchar(MAX)=NULL,
   @Age int
  
)
AS
BEGIN

SELECT Id FROM Human
  WHERE IsDeleted = 0;
END')