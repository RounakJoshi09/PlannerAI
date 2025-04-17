using Contracts;
using LoggerService;

namespace PlannerAI.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureCORS(this IServiceCollection services) => services.AddCors(option => option.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .WithOrigins("http://localhost:3000")
                .AllowCredentials();

            /*
            The chaining of methods in the provided code is allowed under the Fluent Interface design pattern, which is a common concept in .NET and object-oriented programming in general. Here's how it works and why it is possible:

1. Fluent Interface Design Pattern
The Fluent Interface pattern is a way of designing APIs to make them more readable and expressive by chaining method calls together. This is achieved by having each method return the same object (or a related object) so that subsequent methods can be called on it.

In your example, methods like AllowAnyMethod(), AllowAnyHeader(), AllowAnyOrigin(), WithOrigins(), and AllowCredentials() all return the same object (CorsPolicyBuilder). This allows you to chain them together in a single statement.

2. How It Works in .NET
The chaining is made possible because each method in the CorsPolicyBuilder class returns the current instance of the builder (this). For example:

Here:

The method modifies the internal state of the _policy object (e.g., clearing and adding methods).
It then returns this, which refers to the current instance of CorsPolicyBuilder.
This allows the next method in the chain to operate on the same instance.

3. Benefits of Fluent Interfaces
Readability: The code becomes more expressive and easier to read, resembling natural language.
Compactness: Multiple operations can be performed in a single statement.
Immutability (Optional): Fluent interfaces often work well with immutable objects, though in this case, the builder modifies its internal state.
4. Example in Your Code
The chaining in your code works as follows:

AllowAnyMethod() modifies the _policy.Methods and returns the CorsPolicyBuilder instance.
AllowAnyHeader() modifies _policy.Headers and returns the same instance.
This pattern continues, allowing all methods to operate on the same CorsPolicyBuilder instance.
5. Key .NET Concepts Involved
Object-Oriented Programming (OOP): The use of this to refer to the current instance.
Method Chaining: A technique enabled by returning the same object from methods.
Builder Pattern: The CorsPolicyBuilder class is an example of the Builder pattern, which is used to construct complex objects step by step.
6. Practical Analogy
Think of the CorsPolicyBuilder as a pizza builder:

Each method (e.g., AddCheese(), AddToppings()) modifies the pizza being built.
After each modification, the builder returns itself so you can continue adding ingredients.
At the end, you have a fully customized pizza (or in this case, a CorsPolicy).
This makes the API intuitive and easy to use.

GitHub Copilot
The methods builder.Services.ConfigureCORS() and app.UseCors
            */
        }));

        public static void ConfigureIISServerOptions(this IServiceCollection services) => services.Configure<IISServerOptions>(option =>
        {
        });

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}