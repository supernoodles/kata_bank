# kata_bank
A simple implementation of the Bank kata in C#.

##Outside-In TDD with Acceptance Tests
  
###Objective:
Learn and practice the double loop of TDD
Test application from outside, according to side effect
  
##Problem description: Bank kata
  
Create a simple bank application with the following features:
  
- Deposit into Account
- Withdraw from an Account
- Print a bank statement to the console.
  
Acceptance criteria
Statement should have the following the format:
```
  DATE       | AMOUNT  | BALANCE
  10/04/2014 | 500.00  | 1400.00
  02/04/2014 | -100.00 | 900.00
  01/04/2014 | 1000.00 | 1000.00
```
*Note:* Start with an acceptance test

```C#
public class AccountService {
 
  public void deposit(int amount);
 
  public void withdraw(int amount);
 
  public void printStatement();
 
}
```
