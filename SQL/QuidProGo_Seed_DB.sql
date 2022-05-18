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
(1, 'Nick Paso', 'nick@go-mail.com', 2, 'Us46l8O7LwRm97HUa2KEDgR7x0X2'), 
(2, 'Jimmy McGill', 'jimmy@go-mail.com', 1, 'Tz1C8oFZj5VeKO2gBEBb9WupGnm1'),
(3, 'Clive Montgomery III', 'clive@go-mail.com', 1, 'bkt91ANmKJWMxth6PJuhERP42gH2'),
(4, 'Perry Mason', 'perry@go-mail.com', 1, 's9xUYmLyAnMLNM1jU3LBW8YPd6c2'),
(5, 'Vincent Gambini', 'vinny@go-mail.com', 1, 'HBZWnYm9UYevW1fpiOnduNtizEw1');
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
(1, 'Need a Contract Reviewed', 'I need a vendor contract reviewed before.', 1, 3, '2020-04-09 17:30:00'), 
(2, 'Criminal or Civil?', 'Someone might be tring to embezzle from a business I own.', 1, 4, '2020-04-010 17:30:00'),
(3, 'Windfall', 'I came into some money.', 1, 5, '2020-04-011 17:30:00'),
(4, 'New Mexico Property Law', 'I want to build a retirement home in NM. What do I need to know?', 1, 2, '2020-04-012 17:30:00');
set identity_insert [Consultation] off;


set identity_insert [ConsultationCategory] on;
insert into [ConsultationCategory] ([Id], [ConsultationId], [CategoryId]) 
values 
(1, 1, 1),
(2, 2, 2),
(3, 2, 3),
(4, 2, 4),
(5, 2, 5),
(6, 3, 5),
(7, 3, 6),
(8, 3, 7),
(9, 4, 1),
(10, 4, 4),
(11, 4, 5),
(12, 4, 7);
set identity_insert [ConsultationCategory] off;