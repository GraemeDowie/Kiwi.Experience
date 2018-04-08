Feature: MobileSideMenu
	As a user
	When I click on the mobile hamburger menu
	Then i should see a list of site navigation options

Background: User has visited the Kiwi Experience site on mobile device
	Given user has visited the Kiwi Experience site on mobile
		And clicks on the hamburger menu


Scenario Outline: User should see a list of options for to navaigate the site
	Then user should see a list of options to navigate the site <slideOutMenu>

Examples: 
	| slideOutMenu                   |
	| Specials                       |
	| Book Your Trip Now             |
	| Why Us                         |
	| Travel Info                    |
	| Discover New Zealand           |
	| Bus Timetable & Pick-up Points |
	| Contact Us                     |
	| FAQ                            |
	| Blog                           |
	| Kiwi Experience Shop           |


