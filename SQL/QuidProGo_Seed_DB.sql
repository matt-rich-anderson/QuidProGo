USE [QuidProGo];
GO

set identity_insert [UserType] on;
insert into [UserType] ([Id], [UserTypeName]) VALUES
(1, 'Attorney'),
(2, 'Client');
set identity_insert [UserType] off;

set identity_insert [UserProfile] on;
insert into [UserProfile] ([Id], [Name], [Email], [UserTypeId], [FirebaseUserId]) 
values 
(1, 'Dave McInnes', 'dave@go-mail.com', 2, 'QMlqPBMfoyNlrs8RcFjWFseuuAC3'), 
(2, 'Jimmy McGill', 'jimmy@go-mail.com', 1, 'Tz1C8oFZj5VeKO2gBEBb9WupGnm1'),
(3, 'Nick Paso', 'nick@go-mail.com', 2, 'Us46l8O7LwRm97HUa2KEDgR7x0X2'),
(4, 'Clive Montgomery', 'clive@go-mail.com', 1, 'bkt91ANmKJWMxth6PJuhERP42gH2'); 
set identity_insert [UserProfile] off;

set identity_insert [Category] on;
insert into [Category] ([Id], [Category]) 
values 
(1, 'Contract'),
(2, 'Employment'),
(3, 'Real Estate'),
(4, 'Business'),
(5, 'Regulatory'),
(6, 'Financial'),
(7, 'Estate Planning');
set identity_insert [Category] off;

set identity_insert [Consultation] on;
insert into [Consultation] ([Id], [Title], [Description], [ClientUserId], [AttorneyUserId], [CreateDateTime]) 
values 
(1, 'Need a Contract Reviewed', 'I need a vendor contract reviewed before.', 4, 2, '2020-04-09 17:30:00'), 
(2, 'Purchasing a Commerical Property', 'I have a few questions about purchasing in Tennessee.', 3, 1, '2020-04-010 17:30:00');
set identity_insert [Consultation] off;


set identity_insert [ConsultationCategory] on;
insert into [ConsultationCategory] ([Id], [ConsultationId], [CategoryId]) 
values 
(1, 1, 4),
(2, 1, 5),
(3, 2, 3);
set identity_insert [ConsultationCategory] off;