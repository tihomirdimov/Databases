CREATE FUNCTION ufn_CalculateFutureValue
(
  @Sum           MONEY,
  @InterestRate  FLOAT,
  @NumberOfYears INT)
RETURNS MONEY
AS
BEGIN
RETURN(SELECT @Sum*POWER(1+@InterestRate, @NumberOfYears));
END;