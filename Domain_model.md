
# Domain model


| Class         | Methods/Properties       | Scenario                                                                       | Output                                                                            |
|---------------|--------------------------|--------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|
|BankAccount.cs |ID                        |When transfering money both accounts need to be identified for correct transfer |                                                                                   |
|BankAccount.cs |GetStatement()            |A customer wants to see their history on the account                            |List showing all transfers                                                         |
|BankAccount.cs |Deposit(double amount)    |A customer wants to put money on their account                                  |                                                                                   |
|BankAccount.cs |Withdraw(double amount)   |A customer wants to use their money on their account                            |double showing the withdrawn amount and bool that shows if the withdrawal succeded |
|Transaction.cs |Date                      |The customer wants to know the date of a transaction                            |date                                                                               |
|Transaction.cs |Amount                    |The customer wants to know the amount of the transaction                        |double showing the amount of a transaction                                         |
|Transaction.cs |Balance                   |The customer wants to know the balance after a transaction                      |double showing the balance of account after transaction                            |
