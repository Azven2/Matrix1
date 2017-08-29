Feature: Prime
	In order to avoid silly mistakes
	I want to be told useful facts about prime numbers

@PrimeTest
Scenario Outline: Is n a prime number?
Given A possible prime number <P>
When I check for Primeality
Then the answer will be <Result>
	Examples: 
	| P          | Result |
	| -1         | False  |
	| 1          | False  |
	| 2          | True   |
	| 3          | True   |
	| 5          | True   |
	| 7          | True   |
	| 9          | False  |
	| 11         | True   |
	| 15         | False  |
	| 17         | True   |
	| 23         | True   |
	| 25         | False  |
	| 29         | True   |
	| 32         | False  |
	| 49         | False  |
	| 77         | False  |
	| 14641      | False  |
	| 100010001  | False  |
	| 2147483647 | True   |
