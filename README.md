# Introduction 
`ActivityLog` is a package that allows you to capture and save differences in data during create or update actions, effectively providing a logging mechanism for your database operations.

# Getting Started
Follow these steps to integrate ActivityLog into your project:
1. `Service Registration`: In `Program.cs`, add the following line to register the service:
```c#
   builder.Services.AddActivityLog();
```
3. `Dependency Injection`: Introduce the `ActivityEventLog` in your class, providing the appropriate parameters for your context and enum
```c#
   private readonly ActivityEventLog<TraderDbContext, YourEnumActivityType, YourEnumActorType> _activityLog;
```
5. `Entity Integration`: To save differences in a particular entity, ensure that the entity inherits from the `IActivityLog` interface

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
