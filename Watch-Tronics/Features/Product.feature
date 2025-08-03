Feature: Product

A short summary of the feature

@tag1
Scenario Outline: verify products get filter by text which user inputs in search bar_Fastrack
	Given user is on login page
	When user clicks on shop now button
	And user types <searchkey> in the search box
	Then all visible products should contain <searchkey>

Examples: 
	| searchkey |
	| fastrack  |
	| sports    |
	| boat      |
	| titan     |
