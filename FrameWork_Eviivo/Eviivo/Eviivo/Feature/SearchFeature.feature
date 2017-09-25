Feature: SearchFeature
	In order to search available BandB 
	in a preferred location
	Type the location in search box and click search button.

@mytag
Scenario: Search without Input
	Given User has launched http://toprooms.com/ website
	And User has Not typed any location in search box
	When User click the search button
	Then Error message is shown in tooltip above the search box 
	
@mytag
Scenario: Search with Invalid Input
	Given User has launched http://toprooms.com/ website
	And User has typed the InValid location in search box
	When User click the search button
	Then Error message is shown in tooltip above the search box
	
@mytag
Scenario: Search with Valid Input
	Given User has launched http://toprooms.com/ website
	And User has typed the Valid location in search box
	When User click the search button
	Then the result is listed on the page
	And tooltip to check availablity is dispalyed near checkin date box.
