Feature: UserTests
	As A user of the address book application
	I want to have access to the application through secure means
	So that I can control my account data

@login
Scenario: Happy path login
	Given I am on the login page 
	When I enter the correct "username" and "password"
	Then The account should exist in the database
	And I should get a message saying "login successful"

Scenario: Unhappy path login
	Given: I am on the login page