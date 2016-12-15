@Sample
Feature: CardValidation

Scenario: Credit Card Validation - number too short
	Given I open application 
	When I enter credit card number "999222333888444"
	Then I can see validation failure

Scenario: Credit Card Validation - number too short 2
	Given I open application 
	When I enter credit card number "999222333888224"
	Then I can see validation failure