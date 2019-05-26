# DoggolangInterpreter [![Build Status](https://travis-ci.com/verkel/DoggolangInterpreter.svg?branch=master)](https://travis-ci.com/verkel/DoggolangInterpreter)
C#/[Antlr](https://www.antlr.org/) solution to https://github.com/wunderdogsw/wunderpahkina-vol10 

## Installation

Install .NET Core SDK 2.2 from https://dotnet.microsoft.com/download

```shell
$ git clone https://github.com/verkel/DoggolangInterpreter.git
```

## Running tests

Inside the repository root dir:

```shell
$ dotnet test

Total tests: 5. Passed: 5. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 0,9439 Seconds
```

Tests execute the given example programs and the very important program. They verify that the return values are as expected. The very important program's supposed return value is embedded into the tests source as well.

## Executing a source file

Inside the repository root dir:

```shell
$ dotnet run --project DoggolangInterpreter path\to\doggolang-source-file
```
