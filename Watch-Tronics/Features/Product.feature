Feature: Product

A short summary of the feature

@tag1
Scenario: verify products get filter by text which user inputs in search bar_Fastrack
	Given user is on login page
	When user clicks on shop now button
	And user types "fastrack" in the search box
	Then all visible products should contain "Fastrack"

	@tag2
Scenario: verify products get filter by text which user inputs in search bar_Sports
	Given user is on login page
	When user clicks on shop now button
	And user types "sports" in the search box
	Then all visible products should contain "Sports"

	@tag3
Scenario: verify products get filter by text which user inputs in search bar_boAt
	Given user is on login page
	When user clicks on shop now button
	And user types "boat" in the search box
	Then all visible products should contain "boAt"

	@tag4
Scenario: verify products get filter by text which user inputs in search bar_Titan
	Given user is on login page
	When user clicks on shop now button
	And user types "titan" in the search box
	Then all visible products should contain "Titan"
