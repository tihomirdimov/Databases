CREATE PROCEDURE usp_WithdrawMoney
  @AccountId   INT,
  @moneyAmount MONEY
AS
BEGIN
BEGIN TRANSACTION WithdrawMoneyTransaction;
UPDATE Accounts
SET
    Balance=Balance-@moneyAmount
WHERE Id=@AccountId;
COMMIT TRANSACTION WithdrawMoneyTransaction;
END;