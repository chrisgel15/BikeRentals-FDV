# Rental Bikes for FDV-Intive

## Design
I have implemented a Strategy Pattern for the Rental class.
The implementations of the differents strategies are in the de derived classes of the Subscription class. They are:
  - Hourly: Contains the logic to calculate the cost of an hourly rental.
  - Daily: Contains the logic to calculate the cost of a daily rental.
  - Weekly: Contains the logic to calculate the cost of a weekly rental.
  - Family: Contains the logic to calculate the cost of a family rental. It is implemented recursively: Calculating the cost of a Family Subscription type, recursively calls all the cost of the types in its Subscription list. A family Type can hold other families types too, as it was not specified.

All of the those four Subscription types inherit from a super type called Subscription. This could have been also implemented using an Interface, but as I created a method to calculate the time span, I used the abstract class approach. I used an abstract class to ensure there in no chance to create a concrete Subscription object. You can only do that creating from its derived classes.

#### Creation of entities
I have used dependency injection to ensure all objects are properly created.

### Exceptions
I have created just one exception to show its use: it is the FamilyDiscountTypeOverflowException. It is thrown if you want to add more than 5 Subscriptions to a Family Subscription.

### Unit Testing
I have created a separate project to Unit Test the main one. There are 9 Unit Test that test the main calculation logic for the subscription types, the correct use of the Exception and the correct creation of a Family Type Subscription.

# How this could escale?
- A next step for this project could the implementation of a Repository Pattern. This could provide better separation from the logic and the data. It should be implemented with a IRepository interface, so we can switch between production and other enviroments, in case the data from production comes from a WebService or a database, and the test data is created in code.
- Another enhacement could be the use of a mock objects to improve unit testing practices.

### Instalation

1. Clone the GIT Repository into a local path.
2. Open the Visual Studio Solution file using Visual Studio 2017 (background compatibility is not guarateed).
3. Open Solution Explorer
4. Locate project BikeRentalTests-FDV.
5. Open BikeRentalTests.cs file.
6. Right click on BikeRentalTest  > Run Tests.
