-- Creating database 
CREATE DATABASE FormBuilderDB;
GO

-- Selecting database 
USE FormBuilderDB;
GO

-- Creating table (tblSurveys) 
CREATE TABLE tblSurveys (
    Id INT IDENTITY(1,1) CONSTRAINT PK_tblSurveys_Id PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    OpenDate Date NOT NULL,
    EndDate Date NOT NULL,
    FormMethod VARCHAR(100) NULL,
    FormAction VARCHAR(100) NULL,
);

-- Creating table (tblInputs) 
CREATE TABLE tblInputs (
    Id INT IDENTITY(1,1) CONSTRAINT PK_tblInputs_Id PRIMARY KEY,
	SurveyId INT NOT NULL,
    OrderNo INT NOT NULL,
    InputType VARCHAR(100) NOT NULL,
    InternalName VARCHAR(100) NOT NULL,
    DivClassName VARCHAR(100) NULL,
    InputClassName VARCHAR(100) NULL,
    Label VARCHAR(100) NULL,
    ShouldHideLabel BIT NOT NULL,
    LabelClassName VARCHAR(100) NULL,
    Value VARCHAR(100) NULL,
    IsAutofocus BIT NOT NULL,
	Placeholder VARCHAR(100) NULL,
	IsRequired BIT NOT NULL,
	OptionData VARCHAR(MAX) NULL,
    CONSTRAINT FK_tblInputs_SurveyId FOREIGN KEY (SurveyId) REFERENCES tblSurveys(Id) ON DELETE CASCADE -- Foreign key with delete cascade
);

-- Creating table (tblControls) 
CREATE TABLE tblControls (
    Id INT IDENTITY(1,1) CONSTRAINT PK_tblControls_Id PRIMARY KEY,
    InternalName VARCHAR(100) NOT NULL,
    InputType VARCHAR(100) NOT NULL,
    DivClassName VARCHAR(100) NULL,
    InputClassName VARCHAR(100) NULL,
    Label VARCHAR(100) NULL,
    ShouldHideLabel BIT NOT NULL,
    LabelClassName VARCHAR(100) NULL,
    Value VARCHAR(100) NULL,
    IsAutofocus BIT NOT NULL,
	Placeholder VARCHAR(100) NULL,
	IsRequired BIT NOT NULL,
	OptionData VARCHAR(MAX) NULL
);