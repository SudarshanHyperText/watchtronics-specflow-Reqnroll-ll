Feature: Home

A short summary of the feature

@tag01
Scenario: verify user can successfully opens HomePage
	Given user is on login page

@tag02
Scenario: verify products page opens when user clicks on shop now button
	Given user is on login page
	When user clicks on shop now button
	Then product page should be visible
	
