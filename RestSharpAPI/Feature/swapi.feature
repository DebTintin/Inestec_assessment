Feature: Star Wars API People Endpoint
  As a Star Wars fan
  I want to retrieve people data from the Star Wars API
  So that I can verify the API is working

  Scenario: Search for a specific record in the Star Wars API
    When I search for R2-D2 in the Star Wars API people endpoint
    Then the skin color should contain both white and blue
