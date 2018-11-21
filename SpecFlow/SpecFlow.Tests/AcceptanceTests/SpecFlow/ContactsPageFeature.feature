Feature: Contacts Page
    In order to know who to contact in the event of
    an application error, I want to see contact information.

Scenario: Display Contact Information
    Given I have navigated to the home page
    When I select Contacts
    Then contact information should be displayed on the page

Scenario: Fail this test
    Given I have navigated to the home page
    When I select Contacts
    Then this step should fail

Scenario: Skip the last step in this test
    Given I have navigated to the home page
    When I select Contacts
    Then this step should skip