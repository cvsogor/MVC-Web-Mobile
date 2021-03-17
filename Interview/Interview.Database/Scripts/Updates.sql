--Create a suitable relationship that links manufacturers with ranges.
alter table Range
add constraint Range_ManufacturerId_FK FOREIGN KEY ( ManufacturerId ) references Manufacturer(ManufacturerId)
go

--Create a view that displays the following data for each range
CREATE VIEW Range_Manufacturer 
AS
SELECT RangeId, RangeName, R.ManufacturerId, ManufacturerName FROM Range as R join Manufacturer as M on R.ManufacturerId = M.ManufacturerId
go

--Create a stored procedure that will return data about all ranges for a given manufacturer id.
CREATE PROCEDURE GetAllRangesByManufacturerId 
@ManufacturerId int
AS
BEGIN
	SET NOCOUNT ON;
	select * from Range_Manufacturer where ManufacturerId = @ManufacturerId
END
GO

--Given the following query, add an appropriate index to the manufacturer table
CREATE INDEX IX_Manufacturer_ManufacturerName 
    ON Manufacturer (ManufacturerName);
 go  
