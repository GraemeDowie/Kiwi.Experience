Feature: KiwiExperienceHomeDesktop


Background: User has visited the Kiwi Experience homepage on desktop
	Given user has visited the homepage on desktop

Scenario: Then User should see the special message bar text in purple
	Then user should see the special message bar text in purple
	| specialMessage                              | specialMessageColor    |
	| iBuses are filling up fast, don’t miss out! | rgba(219, 24, 131, 1)  |

Scenario: Then the language of the site should be ENG
	Then the language of the page should be in English

Scenario: When User clicks on the Golden Backcker award image it should open a blog article about the award
	When user clicks on the Golden Packpacker award image 
	Then it should take the user to a blog article about the award