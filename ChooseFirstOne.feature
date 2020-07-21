Feature: ChooseFirstOne
	Choose the first one hotel

@mytag
Scenario: Choose first one hotel
	Given I have account created
	And I am in 'Home' page
	When I set up destination as 'Liepāja'
	And I set dates '28-08-2020' - '10-09-2020'
	And I select '10' adults and '5' children
	And I click on Search button
	And I click on 'Choose your room' for fist hotel in the list
	And 'Hotel Details' page is opened for selected hotel
	And I click on 'Reserve' button for recommended room
	And I click on 'I will Reserve' button
	Then 'Checkout' page is displayed
	And I enter valid booking information
	And I click on 'Next: Final Details' button
	And 'Final Details' page is displayed
