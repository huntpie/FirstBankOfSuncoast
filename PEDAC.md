Create a console app that allows a user to manage a banking account.

As user should be able to make transactions against their accounts.

The transaction information should be stored in a file, using a CSV(or JSON) format to record the data.

Balances will be computed by determining the cumulative effect of all the transactions in order. For instance, if a user deposits 10 to their savings account and then withdraws 8 from their savings account, their balance is computed as 2.

Explorer Mode
The app should load past transactions from a file at start up.
As a user I should be able to see the balances in my saving and checking account when the program first starts.
Never allow withdrawing or depositing more money than allowed. That is, we cannot allow our accounts to go negative.
When prompting for an amount to deposit or withdraw always ensure the amount is positive.
As a user I should be able to deposit funds to my savings account.
As a user I should be able to deposit funds to my checking account.
As a user I should be able to withdraw funds from my savings account.
As a user I should be able to withdraw funds from my checking account.
As a user I should be able to see my account balances.
The app should, after each transaction, write all the transactions to a file using a standard format.
Adventure Mode
Add the ability to transfer funds from my checking account to my savings account.
Add the ability to transfer funds from my savings account to my checking accounts.
Add the ability to have multiple users. There are many steps to take here, so take the time to plan out the changes needed. This includes changes to the interface as well as changes to how you store the data.
Epic Mode
Add simple password protection to your user's accounts

Summary

Load past transactions from a csv or json

Give Option to show balance in savings and checking

Withdraw and deposit cannot exceed amount held in totalAccount

Do not accept negative user entries when user is prompted to deposit or withdraw

Deposit Funds to Savings
Deposit Funds to Checking
Withdraw funds from Savings
Withdraw funds from Checking
Show Account Balances

Anytime user deposit or withdraws, write said transaction to loaded past file or create new file
