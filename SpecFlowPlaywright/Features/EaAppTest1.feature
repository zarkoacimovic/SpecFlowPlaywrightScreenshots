Feature: EAEAppTest1

    @smoke
    Scenario: Test Login operation of EA Application1
        Given I navigate to application
        And I enter following login details
          | UserName | Password |
          | standard_user    | secret_sauce |
        Then I see Employee Lists