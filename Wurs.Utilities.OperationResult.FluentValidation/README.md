# Wurs.Utilities.OperationResult.Extensions.FluentValidation

`Wurs.Utilities.OperationResult.Extensions.FluentValidation` is a .NET library that provides extension methods to use `Wurs.Utilities.OperationResult` with [Fluent Validation](https://github.com/FluentValidation/FluentValidation)

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Basic Usage](#basic-usage)
- [Acknowledgments](#acknowledgments)

## Introduction

`Wurs.Utilities.OperationResult.Extensions.FluentValidation`, enhances `Wurs.Utilities.OperationResult` usability by integrating it with [Fluent Validation](https://github.com/FluentValidation/FluentValidation), a popular library for building strongly-typed validation rules.

## Features
- **FluentValidation mapping:** Seamlessly validate objects using [Fluent Validation](https://github.com/FluentValidation/FluentValidation) and map the validation failures to OperationResult errors.

## Getting Started

### Installation

You can install the library via NuGet Package Manager:

```c#
# Wurs.Utilities.OperationResult.Extensions.FluentValidation
Install-Package Wurs.Utilities.OperationResult.Extensions.FluentValidation
```
### Basic Usage
In the following example, we use FluentValidation to validate our model and map the `List<ValidationFailures>` to `List<OperationResult<T>.Errors>` using the extension method `OperationResult<T>.AddErrors()`.

```c#
using Wurs.Utilities.OperationResult.Extensions.FluentValidation;
using FluentValidation;
// ...
private readonly IValidator<MyModel> _myModelValidator;

public MyModelService(IValidator<MyModel> myModelValidator)
{
    _myModelValidator = myModelValidator;
}

public OperationResult<MyModel> AssignPropertyOne(MyModel model)
{
    var result = new OperationResult<MyModel>();
    var validationResult = _myModelValidator.Validate(model);

    if (!validationResult.IsValid)
        return result.AddErrors(validationResult.Errors);

        model.PropertyOne = "Example Value"

    return result.AddResult(model);
}
```
## Acknowledgments

This project relies on the following open-source libraries and their talented authors:

- [Fluent Validation](https://github.com/FluentValidation/FluentValidation) by [JeremySkinner](https://github.com/JeremySkinner)
  - A validation library for .NET that uses a fluent interface and lambda expressions for building strongly-typed validation rules.