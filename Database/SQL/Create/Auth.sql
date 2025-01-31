
if exists ( select * from sys.tables where name = N'Clients')
 DROP TABLE [Clients];
 Create Table Clients
(
[Id] int identity(1,1) primary key clustered not null,
 Secret nvarchar(128),
 Name nvarchar(64),
 ApplicationType int,
 Active bit,
 RefreshTokenLifetime int,
 AllowedOrigin nvarchar(128),
);

if exists ( select * from sys.tables where name = N'AspNetRoles')
 DROP TABLE [AspNetRoles];
Create Table AspNetRoles
(
[Id] int identity(1,1) primary key clustered not null,
Name nvarchar(128),
);

if exists ( select * from sys.tables where name = N'AspNetUserRoles')
 DROP TABLE [AspNetUserRoles];
Create Table AspNetUserRoles
(
[UserId] int identity(1,1) primary key clustered not null,
RoleId int not null,
);

if exists ( select * from sys.tables where name = N'AspNetUsers')
 DROP TABLE [AspNetUsers];
Create Table AspNetUsers
(
 [Id] int identity(1,1) primary key clustered not null,
Email nvarchar(256),
EmailConfirmed bit,
PasswordHash nvarchar(128),
SecurityStamp nvarchar(256),
PhoneNumber nvarchar(64),
PhoneNumberConfirmed bit,
TwoFactorEnabled bit,
LockoutEndDateUtc datetime,
LockoutEnabled bit,
AccessFailedCount int,
UserName nvarchar(256),
);

if exists ( select * from sys.tables where name = N'AspNetUserClaims')
 DROP TABLE [AspNetUserClaims];
Create Table AspNetUserClaims
([Id] int identity(1,1) primary key clustered not null,
  UserId int not null,
  ClaimId int not null,
);

if exists ( select * from sys.tables where name = N'MenuAuthorizations')
 DROP TABLE [MenuAuthorizations];
Create Table MenuAuthorizations
(
[Id] int identity(1,1) primary key clustered not null,
MenuId int not null,
RoleId int not null
);

if exists ( select * from sys.tables where name = N'MenuItems')
 DROP TABLE [MenuItems];
Create Table MenuItems
(
[Id] int identity(1,1) primary key clustered not null,
MenuItem nvarchar(128)
);

if exists ( select * from sys.tables where name = N'RoleClaims')
 DROP TABLE [RoleClaims];
Create Table RoleClaims
(
[Id] int identity(1,1) primary key clustered not null,
RoleId int not null,
ClaimId int not null,

);

if exists ( select * from sys.tables where name = N'Claims')
 DROP TABLE [Claims];
Create Table Claims
(
[Id] int identity(1,1) primary key clustered not null,
Claim nvarchar(128),
);