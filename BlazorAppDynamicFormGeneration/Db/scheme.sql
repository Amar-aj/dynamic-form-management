CREATE TABLE MasterScheme (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    IsActive BOOLEAN NOT NULL
);

DELIMITER $$

CREATE PROCEDURE sp_CrudMasterScheme (
    IN p_ActionType VARCHAR(10),
    IN p_Id INT,
    IN p_Name VARCHAR(255),
    IN p_IsActive BOOLEAN
)
BEGIN
    IF p_ActionType = 'INSERT' THEN
        INSERT INTO MasterScheme (Name, IsActive) VALUES (p_Name, p_IsActive);

    ELSEIF p_ActionType = 'UPDATE' THEN
        UPDATE MasterScheme
        SET Name = p_Name, IsActive = p_IsActive
        WHERE Id = p_Id;

    ELSEIF p_ActionType = 'DELETE' THEN
        DELETE FROM MasterScheme WHERE Id = p_Id;

    ELSEIF p_ActionType = 'GETBYID' THEN
        SELECT * FROM MasterScheme WHERE Id = p_Id;

    ELSEIF p_ActionType = 'GETALL' THEN
        SELECT * FROM MasterScheme;

    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid ActionType';

    END IF;
END $$

DELIMITER ;


CREATE TABLE DynamicSchemeForm (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    SchemeId INT NOT NULL,
    FieldName VARCHAR(255) NOT NULL,
    DataType VARCHAR(50) NOT NULL,
    TabName VARCHAR(255),
    GroupName VARCHAR(255),
    PositionOnTab INT NOT NULL,
    Options TEXT,
    PlaceHolder VARCHAR(255),
    DefaultValue VARCHAR(255),
    MaxLength INT NOT NULL,
    IsRequired BOOLEAN NOT NULL,
    IsActive BOOLEAN NOT NULL
);


DELIMITER $$

CREATE PROCEDURE sp_CrudDynamicSchemeForm(
    IN p_ActionType VARCHAR(10),
    IN p_Id INT,
    IN p_SchemeId INT,
    IN p_FieldName VARCHAR(255),
    IN p_DataType VARCHAR(50),
    IN p_TabName VARCHAR(255),
    IN p_GroupName VARCHAR(255),
    IN p_PositionOnTab INT,
    IN p_Options TEXT,
    IN p_PlaceHolder VARCHAR(255),
    IN p_DefaultValue VARCHAR(255),
    IN p_MaxLength INT,
    IN p_IsRequired BOOLEAN,
    IN p_IsActive BOOLEAN
)
BEGIN
    IF p_ActionType = 'INSERT' THEN
        INSERT INTO DynamicSchemeForm (SchemeId, FieldName, DataType, TabName, GroupName, PositionOnTab, Options, PlaceHolder, DefaultValue, MaxLength, IsRequired, IsActive)
        VALUES (p_SchemeId, p_FieldName, p_DataType, p_TabName, p_GroupName, p_PositionOnTab, p_Options, p_PlaceHolder, p_DefaultValue, p_MaxLength, p_IsRequired, p_IsActive);

    ELSEIF p_ActionType = 'UPDATE' THEN
        UPDATE DynamicSchemeForm
        SET SchemeId = p_SchemeId,
            FieldName = p_FieldName,
            DataType = p_DataType,
            TabName = p_TabName,
            GroupName = p_GroupName,
            PositionOnTab = p_PositionOnTab,
            Options = p_Options,
            PlaceHolder = p_PlaceHolder,
            DefaultValue = p_DefaultValue,
            MaxLength = p_MaxLength,
            IsRequired = p_IsRequired,
            IsActive = p_IsActive
        WHERE Id = p_Id;

    ELSEIF p_ActionType = 'DELETE' THEN
        DELETE FROM DynamicSchemeForm
        WHERE Id = p_Id;

    ELSEIF p_ActionType = 'GETBYID' THEN
        SELECT * FROM DynamicSchemeForm
        WHERE Id = p_Id;

    ELSEIF p_ActionType = 'GETALL' THEN
        SELECT * FROM DynamicSchemeForm;

    END IF;
END$$

DELIMITER ;
