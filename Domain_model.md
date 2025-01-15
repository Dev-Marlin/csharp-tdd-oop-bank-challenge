
# Domain model


| Class         | Methods/Properties                            | Scenario                                                                       | Output                                                                            |
|---------------|-----------------------------------------------|--------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|
|BankAccount.cs |ID                                             |When transfering money both accounts need to be identified for correct transfer |                                                                                   |
|BankAccount.cs |PhoneNumber                                    |The bank wants to contact the one holding the account                           |string showing the owner of the accounts phonenumber                               |
|BankAccount.cs |GetStatement()                                 |A customer wants to see their history on the account                            |List showing all transfers                                                         |
|BankAccount.cs |Deposit(double amount)                         |A customer wants to put money on their account                                  |                                                                                   |
|BankAccount.cs |SendSms()                                      |A customer wants to see their statements on their phone                         |string showing the sms that got sent                                               |
|BankAccount.cs |Withdraw(double amount)                        |A customer wants to use their money on their account                            |double showing the withdrawn amount and bool that shows if the withdrawal succeded |
|BankAccount.cs |RequestOverdraft(double amount, bool answer)   |A customer wants to use request an overdraft on their account                   |bool showing the answer of the request                                             |
|BankAccount.cs |OverdraftAmount                                |A customer wants to use their money on their account                            |double showing the withdrawn amount and bool that shows if the withdrawal succeded |
|Transaction.cs |Date                                           |The customer wants to know the date of a transaction                            |date                                                                               |
|Transaction.cs |Amount                                         |The customer wants to know the amount of the transaction                        |double showing the amount of a transaction                                         |
|Transaction.cs |Balance                                        |The customer wants to know the balance after a transaction                      |double showing the balance of account after transaction                            |
