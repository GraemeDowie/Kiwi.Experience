Feature: wholeKitCaboodleHover
	

Background: User has visited the whole kit and caboodle bus pass page
	Given user has visited the whole kit ad caboodle bus pass page

Scenario: When user hovers over the unlimited travel icon they should see the tool tip information
	When user hovers on the unlimited travel icon in the summary container
	Then user should see information displayed via a tool tip

Scenario: When user hovers over the minimum 30 days question mark they should see the tool tip information
	When user hovers on the minimum 30days question mark
	Then user should see the tooltip text diplayed