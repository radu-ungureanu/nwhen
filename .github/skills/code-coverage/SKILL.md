---
name: code-coverage
description: "Run the test suite with code coverage and report uncovered lines. Use when: checking coverage, finding untested code, listing uncovered lines, showing which lines are not covered, running coverage report, checking test coverage percentage, coverage badge."
argument-hint: "Optional: -SrcDir and -ResultsDir overrides"
---

# Code Coverage

Runs the NWhen test suite with XPlat Code Coverage (coverlet) and prints a developer-friendly report of every uncovered line, grouped by source file, alongside a line/branch/method summary.

## When to Use

- You want to know which lines or branches have no test coverage
- You want to check the current coverage percentage before committing
- You want to compare coverage before and after adding tests
- The Codecov badge shows a drop and you need to investigate

## Procedure

1. Run the [coverage script](./scripts/coverage.ps1) from the **repository root**:

   ```powershell
   .\.github\skills\code-coverage\scripts\coverage.ps1
   ```

   Or with explicit paths:

   ```powershell
   .\.github\skills\code-coverage\scripts\coverage.ps1 -SrcDir .\src -ResultsDir .\src\TestResults
   ```

2. The script will:
   - Delete any stale `TestResults/` folder to ensure a clean run
   - Execute `dotnet test` with `--collect:"XPlat Code Coverage"`
   - Parse the generated `coverage.cobertura.xml`
   - Print uncovered **statements** and **branch** lines grouped by source file
   - Print a summary: line coverage %, branch coverage %, total uncovered lines

3. Review the output and identify which methods or branches need new tests.

## Output Example

```
==> Uncovered lines by file:

  Valid.cs
    Statements : 67, 70

  When.cs
    Statements : 47, 48, 49, 50, ...
    Branches   : 91, 100, 115, ...

==> Summary
    Line coverage   : 78.8%
    Branch coverage : 70.8%
    Uncovered lines : 176
```

## Requirements

- .NET SDK installed and on `PATH`
- `coverlet.collector` NuGet package present in the test project (already included in `NWhen.Tests`)
- PowerShell 5+ or PowerShell 7+
