Feature: As a user interested in cash investment rates
I want to search for and sign up for focus insights on the Investec website
So that I can receive relevant information in my inbox

    Scenario Outline: Search and sign up for cash investment rates insights
         Given I navigate to <url>
         And I accept the cookies
         When I use the search functionality to look for cash investment rates
         And I navigate to "Understanding cash investment interest rates"
         And I sign up to receive focus insights with <name> <surname> <email> <year>
         Then Assert the sign-up process is successful
    
Examples:
    | url                       | name | surname | email               | year |
    | https://www.investec.com/ | John | Doe     | test@investec.co.za | 1980 |
    
    