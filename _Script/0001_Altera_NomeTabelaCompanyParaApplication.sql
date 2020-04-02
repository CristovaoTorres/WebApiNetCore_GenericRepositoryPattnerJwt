
sp_rename 'API_COMPANY','Application';
go
sp_rename 'API_HISTORY','ApplicationHistory';
go


sp_rename 'Application.ApiKey', 'Applicationkey' , 'COLUMN';
go
sp_rename 'Application.ApiSecretKey', 'ApplicationSecretKey' , 'COLUMN';
go


sp_rename 'ApplicationHistory.CallerApiCompanyId', 'CallerApplicationId' , 'COLUMN';
go



