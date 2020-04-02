CREATE procedure [dbo].[get_CodigoByTipoEntidadeId]  
(  
 @TipoEntidadeId int,  
 @TopologiaId int,  
 @Prefixo varchar(50)  
)  
AS  
BEGIN  
 DECLARE @NovoId int,  
   @LastId int,  
   @NovoCodigo varchar(63)  
  
 SELECT @NovoId = COUNT(Id) + 1 FROM [dbo].[vw_Entidade]  
 WHERE TipoEntidadeId = @TipoEntidadeId  
 AND TopologiaId = @TopologiaId  
   
 SET @NovoCodigo = [dbo].[fn_get_CodigoById](@Prefixo, @NovoId, @TopologiaId)  
   
 WHILE @NovoCodigo IS NULL  
 BEGIN  
  SET @NovoId = @NovoId  + 1  
  SET @NovoCodigo = [dbo].[fn_get_CodigoById](@Prefixo, @NovoId, @TopologiaId)  
 END  
    
 RETURN @NovoCodigo  
END