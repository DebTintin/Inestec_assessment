Feature: Star Wars API People Endpoint
  As a Star Wars fan
  I want to retrieve people data from the Star Wars API
  So that I can verify the API is working

  Scenario: Get people from the Star Wars API
    When I send a GET request to "https://swapi.dev/api/people/" with browser headers
    Then display the response content
