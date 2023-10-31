# Introduction 
This packaje add posibility to save data difference at action (add/update) to database as log 

# Getting Started
1. Program.cs add -> builder.Services.AddActivityLog();
2. DI -> private readonly ActivityEventLog<TraderDbContext, YourEnumActivityType, YourEnumActorType> _activityLog;

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
