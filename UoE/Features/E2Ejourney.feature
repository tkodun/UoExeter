Feature: E2Ejourney
    In order to verify the complete booking journey
    As a customer
    I want to verify all features are working as expected

@tag1
Scenario: I want to complete a hotel booking journey
	Given I am on the landing page
	And I accept the cookies
	And I enter destination as Manchester
    And I select the check in and out date
    When I click search button
    Then I select first hotel in list
    Then I click on reserve button in new window
    And I select room type
    And I click I will reserve button
    Then I enter my details
    And I assert the payment page is displayed


	
