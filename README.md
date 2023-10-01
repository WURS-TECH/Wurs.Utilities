# Wurs.Utilities
A set of code utilities for your .NET projects.

## Wurs.Utilities.OperationResult

`Wurs.Utilities.OperationResult` is a .NET library that provides the basics for using the OperationResult pattern in your applications.

### Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Basic Usage](#basic-usage)
- [FluentValidation Integration](#fluentvalidation-integration)
- [License](#license)

### Introduction

The OperationResult pattern is a way to encapsulate the result of an operation, including success or failure information, error messages, and additional data. It helps in creating cleaner and more maintainable code by separating concerns related to error handling from the core business logic.

`Wurs.Utilities.OperationResult` provides the foundation for implementing this pattern in your .NET applications. The extension library, `Wurs.Utilities.OperationResult.Extensions.FluentValidation`, enhances this pattern's usability by integrating it with FluentValidation, a popular library for validating objects.

### Features

- **Operation Result Pattern:** Easily implement the Operation Result pattern in your .NET projects.
- **Error Messages:** Include detailed error messages in your operation results.
- **Error codes:** Attach custom error codes to your operation results.
- **Fluent interface pattern:** All the implemented OperationResult<T> methods return the current operation instance, so you can chain additional calls or return directly this methods.
- **FluentValidation Integration:** Seamlessly validate objects using FluentValidation and map the validation failures to OperationResult errors.

### Getting Started

#### Installation

You can install both libraries via NuGet Package Manager:

```bash
# Wurs.Utilities.OperationResult
Install-Package Wurs.Utilities.OperationResult

# Wurs.Utilities.OperationResult.Extensions.FluentValidation
Install-Package Wurs.Utilities.OperationResult.Extensions.FluentValidation
```
#### Basic Usage
Here's a simple example of using the Wurs.Utilities.OperationResult library:
```bash
using Wurs.Utilities.OperationResult;

// ...
public OperationResult<int> Divide(int dividend, int divisor)
{
    var result = new OperationResult<int>();
    
    if (divisor == 0)
    {
        return result.AddError("Division by zero is not allowed.");
    }

    return result.AddResult(dividend / divisor);
}
```
### Fluent Validation Integration
`Wurs.Utilities.OperationResult.Extensions.FluentValidation` allows you to easily integrate FluentValidation with the OperationResult pattern. Here's an example:

```bash
using Wurs.Utilities.OperationResult.Extensions.FluentValidation;
using FluentValidation;
// ...
private readonly IValidator<MyModel> _myModelValidator;

public MyModelService(IValidator<CreateTokenRequest> myModelValidator)
{
    _myModelValidator = myModelValidator;
}

public OperationResult<MyModel> AssignPropertyOne(MyModel model)
{
    var result = new OperationResult<MyModel>();
    var validationResult = _myModelValidator.Validate(createTokenRequest);

    if (!validationResult.IsValid)
        return result.AddErrors(validationResult.Errors);

        model.PropertyOne = "Example Value"

    return result.AddResult(model);
}
```

### License
This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/). See the LICENSE file for details.
