# What is BBUnit?

> [!CAUTION]
> BBUnit is neither released nor finished yet.
> It is not ready for production use.

> [!CAUTION]
> BBUnit API is not stable yet.
> Use it at your own risk.

## Why yet another testing framework?

### Test fragility

BBUnit restricts test fragility by design.

## What's it like?

### 1. ITestSuite\<TContract>

Any ```ITestSuite<TContract>``` implementation is treated
as a test collection. ```TContract``` here is a contract under test. Use
```It``` property to test the contract implementation.

```csharp
using BBTest;
using FLuentAssertions;

public CalcTests : ITestSuite<ICalc>
{
  public required ICalc It { get; init; }

  public void TwoPlusTwo_Should_BeFour()
  {
    It.Sum(2, 2).Should().Be(4);
  }
}
```

### 2. ITestingContext\<TContract>

An ```ITestingContext<TContract>``` implementation is responsible for
1. ```TContract``` implementation setup
2. ```TestData``` setup

## Getting Started

## To-Do List

- [ ] Finish initial README.md
  - [ ] What is BBUnit?
  - [ ] What's it like?
  - [ ] Getting Started
  - [ ] Examples
  - [ ] To-Do List
- [ ] Create initial API
  - [ ] CornerCaseAttribute
  - [x] CriticalSectionAttribute
  - [ ] IDataSetup
  - [ ] ITargetSetup
  - [ ] ITestingContext
  - [ ] ITestPrecondition
  - [x] ITestSuite
  - [ ] NotForAttribute
  - [ ] SkipAttribute
  - [ ] SkipForAttribute
  - [ ] SpecialAttribute
  - [x] TestSuite
  - [ ] WhenAttribute
- [ ] Implement core functionality
  - [ ] Discovery
  - [ ] Setup
    - [ ] TestTarget setup
    - [ ] TestData setup
  - [ ] Execution
- [ ] Implement Visual Studio test adapter
- [ ] Implement Roslyn analyzers
- [ ] Implement "dotnet new" templates
- [ ] Implement advanced functionality
  - [ ] Automated TestTarget setup
  - [ ] Automated TestData setup

## TO READ

https://martinfowler.com/tags/testing.html
http://xunitpatterns.com/index.html