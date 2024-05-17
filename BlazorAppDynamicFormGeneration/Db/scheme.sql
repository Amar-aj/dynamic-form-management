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

