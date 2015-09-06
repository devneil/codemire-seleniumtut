Feature: MyFirstTest

Scenario: SeeMuppets
	Given I can navigate to Google
	When I search for muppets
	Then I should see an image

Scenario: SeeMuppets2
	Given I can navigate to Google
	When I search for muppets
	Then I should see an image