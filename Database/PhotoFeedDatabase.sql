
------------------Tabels that help define the main table USER-----------------------

-- user's verified Stat (te be inserted manualy)
CREATE TABLE VerificationStat(
	IdVerification int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Verified nvarchar(255) NOT NULL DEFAULT 'no' --yes/no
);

insert into VerificationStat (Verified) values ('Not verified');
insert into VerificationStat (Verified) values ('Verified');

-- user's privileges (te be inserted manualy)
CREATE TABLE ModeratorStat(
	IdModerator int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ModeratorRole nvarchar(255) NOT NULL DEFAULT 'none' -- none/user
);

insert into ModeratorStat (ModeratorRole) values ('Not moderator');
insert into ModeratorStat (ModeratorRole) values ('Moderator');

-- MAIN TABLE : USER ACCOUNT
CREATE TABLE [User](
	IdUser int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserName nvarchar(255) NOT NULL,
	Email nvarchar(255) NOT NULL,
	[Password] nvarchar(255) NOT NULL,
	[Description] nvarchar(max),
	ProfilePicture nvarchar(MAX) NOT NULL,
	Verified int FOREIGN KEY REFERENCES dbo.VerificationStat(IdVerification) NOT NULL DEFAULT 1, -- default 1 pt id-ul coresp unverified
	Moderator int FOREIGN KEY REFERENCES dbo.ModeratorStat(IdModerator) NOT NULL  DEFAULT 1, -- default 1 pt id-ul coresp user basic
	Points int DEFAULT 0 NOT NULL,
	-- MemberOfCompany int FOREIGN KEY REFERENCES dbo.CompanyMember(IdCompanyMember),  might not be neccesarry
);

-- user's social media links
CREATE TABLE UserContact(
	IdContact int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdContactUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	WebsiteName nvarchar(255) NOT NULL,
	WebsiteUrl  nvarchar(255) NOT NULL
);

-- all specializations (te be inserted manualy)
CREATE TABLE Specialization(
	IdSpecialization int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SpecializationName nvarchar(255) NOT NULL
);

insert into Specialization (SpecializationName) values ('Nature');
insert into Specialization (SpecializationName) values ('Landscape');
insert into Specialization (SpecializationName) values ('Astrophotography');
insert into Specialization (SpecializationName) values ('Portrait');
insert into Specialization (SpecializationName) values ('Architecture');
insert into Specialization (SpecializationName) values ('Headshot');
insert into Specialization (SpecializationName) values ('Automotive');
insert into Specialization (SpecializationName) values ('Pets');
insert into Specialization (SpecializationName) values ('Enviromental');
insert into Specialization (SpecializationName) values ('Food');
insert into Specialization (SpecializationName) values ('Street Photography');
insert into Specialization (SpecializationName) values ('Abstract');
insert into Specialization (SpecializationName) values ('Fashon');
insert into Specialization (SpecializationName) values ('Black and White');
insert into Specialization (SpecializationName) values ('Long Exposure');
insert into Specialization (SpecializationName) values ('Cityscape');
insert into Specialization (SpecializationName) values ('Wedding');
insert into Specialization (SpecializationName) values ('Concert');
insert into Specialization (SpecializationName) values ('Wildlife');
insert into Specialization (SpecializationName) values ('Stock Photography');
insert into Specialization (SpecializationName) values ('Action Sports');
insert into Specialization (SpecializationName) values ('Documentary');
insert into Specialization (SpecializationName) values ('Product Photography');
insert into Specialization (SpecializationName) values ('Film Photography');
insert into Specialization (SpecializationName) values ('Minimalism');
insert into Specialization (SpecializationName) values ('Symmetry');
insert into Specialization (SpecializationName) values ('Children');
insert into Specialization (SpecializationName) values ('Senior Portraits');
insert into Specialization (SpecializationName) values ('Surreal');
insert into Specialization (SpecializationName) values ('Aerial');
insert into Specialization (SpecializationName) values ('Commercial Photography');
insert into Specialization (SpecializationName) values ('Product Photography');
insert into Specialization (SpecializationName) values ('Experimental');
insert into Specialization (SpecializationName) values ('Fine Art Photography');
insert into Specialization (SpecializationName) values ('Adventure Photography');
insert into Specialization (SpecializationName) values ('Photoshop');
insert into Specialization (SpecializationName) values ('Amatour');
insert into Specialization (SpecializationName) values ('Family Portraits');
insert into Specialization (SpecializationName) values ('Macro Photography');
insert into Specialization (SpecializationName) values ('Film Photography');

-- link between specializations and users
CREATE TABLE UserSpecialization(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUserSpec int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdSpecialization int FOREIGN KEY REFERENCES dbo.Specialization(IdSpecialization) NOT NULL, --
);


-----------------------CATEGORY TABLE-------------------------

-- MAIN TABLE : CATEGORY (te be inserted manualy)
CREATE TABLE Category(
	IdCategory int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CategoryName nvarchar(255) NOT NULL,
	[Description] nvarchar(max)
	--poza coresp categoriei o sa fie aleasa cu un select
);

insert into Category (CategoryName) values ('Nature');
insert into Category (CategoryName, [Description]) values ('Landscape', 'Landscape Photography');
insert into Category (CategoryName, [Description]) values ('Astrophotography', 'Photos of astronomical objects, celestial events, and areas of the night sky.');
insert into Category (CategoryName, [Description]) values ('Portrait', 'Portrait Photography');
insert into Category (CategoryName, [Description]) values ('Architecture', 'Architectural Photography');
insert into Category (CategoryName, [Description]) values ('Headshot', 'Like Portrait Photography, but only with heads.');
insert into Category (CategoryName, [Description]) values ('Automotive', 'Photos of vehicles');
insert into Category (CategoryName, [Description]) values ('Pets', 'Photos of domestic or tamed animals');
insert into Category (CategoryName, [Description]) values ('Enviromental', 'Photos that have the enviroment as the point of interest');
insert into Category (CategoryName, [Description]) values ('Food', 'Commercial Food Photography');
insert into Category (CategoryName) values ('Street Photography');
insert into Category (CategoryName, [Description]) values ('Abstract', 'Images that do not have an immediate association with the object world');
insert into Category (CategoryName) values ('Fashon');
insert into Category (CategoryName) values ('Black and White');
insert into Category (CategoryName, [Description]) values ('Long Exposure', 'Photos taken with long exposure times');
insert into Category (CategoryName, [Description]) values ('Cityscape', 'Urban Landscapes');
insert into Category (CategoryName, [Description]) values ('Wedding', 'Wedding Photography');
insert into Category (CategoryName, [Description]) values ('Concert', 'Photos taken at concerts');
insert into Category (CategoryName, [Description]) values ('Wildlife', 'Photos of animals in wild habitats');
insert into Category (CategoryName) values ('Stock Photography');
insert into Category (CategoryName, [Description]) values ('Action Sports', 'Photos of sporting events');
insert into Category (CategoryName) values ('Documentary');
insert into Category (CategoryName) values ('Product Photography');
insert into Category (CategoryName, [Description]) values ('Film Photography', 'Photos taken on film');
insert into Category (CategoryName, [Description]) values ('Minimalism', 'Minimalistic Photos');
insert into Category (CategoryName, [Description]) values ('Symmetry', 'Symmetric Photos');
insert into Category (CategoryName, [Description]) values ('Children', 'Children Portraits');
insert into Category (CategoryName) values ('Family Portraits');
insert into Category (CategoryName) values ('Senior Portraits');
insert into Category (CategoryName, [Description]) values ('Surreal', 'Creative imagery that captures illogical scenes');
insert into Category (CategoryName, [Description]) values ('Aerial', 'Photos taken from above, usually using drones');
insert into Category (CategoryName) values ('Commercial Photography');
insert into Category (CategoryName) values ('Product Photography');
insert into Category (CategoryName, [Description]) values ('Experimental', 'Photos based on untested ideas or techniques and not yet established or finalized');
insert into Category (CategoryName, [Description]) values ('Fine Art Photography', 'Pictures that are not meant to capture a moment or express an idea, but are to be regarded as art pieces');
insert into Category (CategoryName, [Description]) values ('Macro Photography', 'Photographs taken extremely close-up');
insert into Category (CategoryName, [Description]) values ('Adventure Photography', 'Photos of people, taken in extreme conditions');
insert into Category (CategoryName, [Description]) values ('Photoshop', 'Pictures edited in Photoshop');
insert into Category (CategoryName, [Description]) values ('Film', 'Images taken on rolls of film');


--------------Tables related to category and user--------------

-- accounts followed by users
CREATE TABLE FollowUserUser(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdUserFollowed int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL --
);

-- categories followed by the user
CREATE TABLE FollowUserCategory(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdCategoryFollowed int FOREIGN KEY REFERENCES dbo.Category(IdCategory) NOT NULL
);


---------------COMPANY TABLE-----------------

-- MAIN TABLE : COMPANY ACCOUNT
CREATE TABLE Company(
	IdCompany int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CompanyName nvarchar(255) NOT NULL,
	CompanyCode nvarchar(255) NOT NULL,
	Email nvarchar(255) NOT NULL,
	[Password] nvarchar(255) NOT NULL,
	[Description] nvarchar(max),
	ProfilePicture nvarchar(MAX) NOT NULL,
	-- Moderator int FOREIGN KEY REFERENCES dbo.ModeratorStat(IdModerator) -- posibil inutil. toate ompaniile au privilegii
);

---------------Tables related to company--------------

CREATE TABLE FollowUserCompany(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdCompanyFollowed int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
);

-- accounts followed by companies
CREATE TABLE FollowCompanyUser(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	IdUserFollowed int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL --
);

-- categories followed by a company
CREATE TABLE FollowCompanyCategory(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	IdCategoryFollowed int FOREIGN KEY REFERENCES dbo.Category(IdCategory) NOT NULL
);

CREATE TABLE FollowCompanyCompany(
	IdFollow int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	IdCompanyFollowed int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL
);

-- company's social media links
CREATE TABLE CompanyContact(
	IdContact int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdContactCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	WebsiteName nvarchar(255) NOT NULL,
	WebsiteUrl  nvarchar(255) NOT NULL
);

-- user's afiliations to companies
CREATE TABLE CompanyMember(
	IdCompanyMember int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL --
);


---------CONTEST Tables-------

-- MAIN TABLE : PROCONTEST
CREATE TABLE ContestPro(
	IdContestPro int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCreator int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	ContestName nvarchar(255) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	MaximumPictureNumber int NOT NULL DEFAULT 1,
	StartDate date NOT NULL,
	EndDate date NOT NULL
);

-- MAIN TABLE : BASIC CONTEST
CREATE TABLE ContestBasic(
	IdContestBasic int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCreator int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	ContestName nvarchar(255) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	MaximumPictureNumber int NOT NULL DEFAULT 1,
	StartDate date NOT NULL,
	EndDate date NOT NULL
);

----------------Related to all contests--------

-- the titles of all possible awards (to be inserted manualy)
CREATE TABLE PositionStat(
	IdPosition int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PositionName nvarchar(255) NOT NULL
);

insert into PositionStat (PositionName) values ('First Place');
insert into PositionStat (PositionName) values ('Second Place');
insert into PositionStat (PositionName) values ('Third Place');
insert into PositionStat (PositionName) values ('Honorable mention')

-- the winners of the pro competitions
CREATE TABLE WinnerPro(
	IdAward int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdProContest int FOREIGN KEY REFERENCES dbo.ContestPro(IdContestPro) NOT NULL, --
	IdWinnerUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	PositionPlaced int FOREIGN KEY REFERENCES dbo.PositionStat(IdPosition) NOT NULL, --
);

-- the winners of the basic competitions
CREATE TABLE WinnerBasic(
	IdAward int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdBasicContest int FOREIGN KEY REFERENCES dbo.ContestBasic(IdContestBasic) NOT NULL,
	IdWinnerUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	PositionPlaced int FOREIGN KEY REFERENCES dbo.PositionStat(IdPosition) NOT NULL, --
);

------------------Related to pro constests----------

-- pro contest prizes
CREATE TABLE PrizeProContest(
	IdPrize int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdProContest int FOREIGN KEY REFERENCES dbo.ContestPro(IdContestPro) NOT NULL, --
	Position int NOT NULL,
	PositionPrize nvarchar(255) NOT NULL
);


------------------Related to Judgeing Contests----------------

-- all contest's jury's
CREATE TABLE Jury(
	IdJury int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdProContest int FOREIGN KEY REFERENCES dbo.ContestPro(IdContestPro) NOT NULL, --
	IdJuryUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	-- judging company will be determined by selecting the company that created the contest (fron another table)
);

-- weather or not an user accepted the judge position at a contest (te be inserted manualy)
CREATE TABLE InvitationAcceptStat(
	IdInvitationAccept int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AcceptStat nvarchar(255) NOT NULL
);

insert into InvitationAcceptStat (AcceptStat) values ('Awaiting Approval');
insert into InvitationAcceptStat (AcceptStat) values ('Approved');
insert into InvitationAcceptStat (AcceptStat) values ('Rejected');

-- invitations sent by companies for judging contests
CREATE TABLE JudgeInvitation(
	IdInvitation int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCompany int FOREIGN KEY REFERENCES dbo.Company(IdCompany) NOT NULL, --
	IdUserInvited int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdContest int FOREIGN KEY REFERENCES dbo.ContestPro(IdContestPro) NOT NULL,
	Accepted int FOREIGN KEY REFERENCES dbo.InvitationAcceptStat(IdInvitationAccept) NOT NULL DEFAULT 1 --awaiting approval
	-- instead of an "expired" column, we can just check the competition's end date
);


----------------- PHOTOS Tables -------------------

-- copyright posibilities (inserted manualy)
CREATE TABLE CopyrightStat(
	IdCopyright int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Copyright int NOT NULL
);

insert into CopyrightStat (Copyright) values (0);
insert into CopyrightStat (Copyright) values (1);


--------------related to profile photos----------

-- MAIN TABLE : PHOTOS
CREATE TABLE PhotoUser(
	IdPhotoUser int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	Copyrighted int FOREIGN KEY REFERENCES dbo.CopyrightStat(IdCopyright) NOT NULL DEFAULT 1, --no copyright
	Photo nvarchar(MAX) NOT NULL,
	[Description] nvarchar(max),
	DatePosted date NOT NULL,
	Rating int NOT NULL
);

-- all photo tags
CREATE TABLE Tag(
	IdTag int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TagName nvarchar(255) NOT NULL
);

--photo's tags
CREATE TABLE PhotoTag(
	IdPhotoTag int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdTag int FOREIGN KEY REFERENCES dbo.Tag(IdTag) NOT NULL, --
	IdPhoto int FOREIGN KEY REFERENCES dbo.PhotoUser(IdPhotoUser) NOT NULL, --
);

--categories for ptofile photos
CREATE TABLE PhotoUserCategory(
	IdPhotoUserCategory int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCategory int FOREIGN KEY REFERENCES dbo.Category(IdCategory) NOT NULL, --
	IdPhoto int FOREIGN KEY REFERENCES dbo.PhotoUser(IdPhotoUser) NOT NULL, --
);


-----------related to feedback photos----------

-- MAIN TABLE : FEEDBACK PICTURE
CREATE TABLE PhotoFeedback(
	IdPhotoFeedback int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	Copyrighted int FOREIGN KEY REFERENCES dbo.CopyrightStat(IdCopyright) NOT NULL, --
	Photo nvarchar(MAX) NOT NULL,
	[Description] nvarchar(max),
	DatePosted date NOT NULL
);

--categories for ptofile photos
CREATE TABLE PhotoFeedbackCategory(
	IdPhotoFeedbackCategory int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCategory int FOREIGN KEY REFERENCES dbo.Category(IdCategory) NOT NULL, --
	IdPhoto int FOREIGN KEY REFERENCES dbo.PhotoFeedback(IdPhotoFeedback) NOT NULL, --
);

-- feedback left by users
CREATE TABLE Feedback(
	IdFeedback int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCommenter int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	IdPhotoFeedback int FOREIGN KEY REFERENCES dbo.PhotoFeedbackCategory(IdPhotoFeedbackCategory) NOT NULL, --
	GoodParts nvarchar(max) NOT NULL,
	BadParts nvarchar(max) NOT NULL,
	Miscellaneous nvarchar(max),
	DatePosted date NOT NULL
	--FeedbackRating_IdFeedbackRating int NOT NULL DEFAULT 1
);

--CREATE TABLE FeedbackRating(
--	IdFeedbackRating int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	Usefulness nvarchar(255) NOT NULL 
--);

insert into FeedbackRating (Usefulness) values ('No rating');
insert into FeedbackRating (Usefulness) values ('Useful');
insert into FeedbackRating (Usefulness) values ('Very Useful');


-----------related to contest photos----------

-- MAIN TABLE : PRO CONTEST PICTURES
CREATE TABLE PhotoProContest(
	IdPhotoProContest int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdProContest int FOREIGN KEY REFERENCES dbo.ContestPro(IdContestPro) NOT NULL, --
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	Copyrighted int FOREIGN KEY REFERENCES dbo.CopyrightStat(IdCopyright) NOT NULL, --
	Photo nvarchar(MAX) NOT NULL,
	[Description] nvarchar(max),
	DatePosted date NOT NULL,
	Rating int NOT NULL
);

-- MAIN TABLE : BASIC CONTEST PICTURES
CREATE TABLE PhotoBasicContest(
	IdPhotoBasicContest int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdBasicContest int FOREIGN KEY REFERENCES dbo.ContestBasic(IdContestBasic) NOT NULL, --
	IdUser int FOREIGN KEY REFERENCES dbo.[User](IdUser) NOT NULL, --
	Copyrighted int FOREIGN KEY REFERENCES dbo.CopyrightStat(IdCopyright) NOT NULL, --
	Photo nvarchar(MAX) NOT NULL,
	[Description] nvarchar(max),
	DatePosted date NOT NULL,
	Rating int NOT NULL
);
