CREATE PROCEDURE [dbo].[CreateEntrada]  
(  
 @CenarioId int,  
 @TipoValorId int,  
 @CadeiaId int
)  
AS  
BEGIN  

  INSERT INTO [dbo].[Entrada]   
  (  
   CenarioId,  
   TipoValorId,  
   SimboloId,  
   Grandeza  
  )  
  SELECT  
   @CenarioId,  
   @TipoValorId,  
   S.Id,  
   S.[Default]  
  FROM [dbo].[Simbolo] S  
  WHERE S.CadeiaId = @CadeiaId  
  AND S.[Default] IS NOT NULL

  end