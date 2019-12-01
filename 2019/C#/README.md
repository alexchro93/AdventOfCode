# 2019 Solutions in C#

## Run

To run the sample program, ensure you have the [.NET Core 3.0 SDK installed][1].  I'm using version
3.0.101.  Then, cd in to `src/AdventOfCode` and run `dotnet run -- -d (day) -p (problem)`
where day is in the range [1, 25] and problem is in the range [1, 2].  

Example:

```
cd src/AdventOfCode
dotnet run -- -d 1 -p 1

/**
*
* Expected output:
* Day One Problem One Result - 3246455.
*
**/
```

## Test

To run the test suite, ensure you have the [.NET Core 3.0 SDK installed][1].  I'm using version 
3.0.101.  Then, cd in to `src/AdventOfCodeTests` and run `dotnet test`.  You can add an optional
filter to this command in order to run tests for a specific day.

Example: 

```
cd src/AdventOfCodeTests
dotnet test --filter TestCategory=DayOne

/**
*
* Test run for /Users/alex/Projects/AdventOfCode/2019/C#/src/AdventOfCodeTests/bin/Debug/netcoreapp3.0/AdventOfCodeTests.dll(.NETCoreApp,Version=v3.0)
* Microsoft (R) Test Execution Command Line Tool Version 16.3.0
* Copyright (c) Microsoft Corporation.  All rights reserved.
* 
* Starting test execution, please wait...
* 
* A total of 1 test files matched the specified pattern.
*
* Test Run Successful.
* Total tests: 10
*     Passed: 10
* Total time: 0.8353 Seconds
*
**/
```

[1]: https://dotnet.microsoft.com/download/dotnet-core/3.0

