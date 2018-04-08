Feature: NationalBusPass
	A series of tests to confirm the national bus pass option is working

Background: User has visited the Kiwi Experience home page on desktop and selects the whole kit and caboodle bus pass option
	Given user has visited the kiwi experience home page on dektop
		And user clicks on the whole kit and caboodle bus pass option

Scenario: User should be on the whole kit and caboodle page with three bus pass options 
	Then user should be on the whole kit and caboodle page with three bus pass options 
	| busPassOne               | busPassTwo    | busPassThree      |
	| THE WHOLE KIT & CABOODLE | FUNKY CHICKEN | NORTHERN ROUND UP |


Scenario: User clicks on the view pass button the user should see pass summary content
	When user clicks on the view pass button
	Then user should see the whole kit and caboodle summary content
	| priceNZ | priceAud | start    | finish            | travelTime        | cardholderDiscount							|
	| NZ$1649 | AU$1499  | Anywhere | Where you started | Minimum 30 Days ? | nz$1599\r\n(not available with special deals) |
	
	
