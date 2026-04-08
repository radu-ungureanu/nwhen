#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Runs the test suite with code coverage and reports uncovered lines.

.DESCRIPTION
    1. Runs dotnet test with XPlat Code Coverage (coverlet).
    2. Parses the generated Cobertura XML.
    3. Prints every uncovered line grouped by source file.
    4. Prints a summary (line %, branch %, method %).

.PARAMETER SrcDir
    Path to the solution root. Defaults to the 'src' folder next to this script.

.PARAMETER ResultsDir
    Where dotnet test writes coverage XML. Defaults to <SrcDir>/TestResults.

.EXAMPLE
    .github/skills/code-coverage/scripts/coverage.ps1
    .github/skills/code-coverage/scripts/coverage.ps1 -SrcDir .\src -ResultsDir .\src\TestResults
#>
param(
    [string]$SrcDir     = (Join-Path (Split-Path (Split-Path (Split-Path (Split-Path $PSScriptRoot)))) "src"),
    [string]$ResultsDir = (Join-Path (Join-Path (Split-Path (Split-Path (Split-Path (Split-Path $PSScriptRoot)))) "src") "TestResults")
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# ── 1. Run tests ────────────────────────────────────────────────────────────

Write-Host "`n==> Running tests with coverage...`n" -ForegroundColor Cyan

# Clean previous results so we always parse the freshest XML
if (Test-Path $ResultsDir) {
    Remove-Item $ResultsDir -Recurse -Force
}

Push-Location $SrcDir
try {
    dotnet test --verbosity quiet `
                "--collect:XPlat Code Coverage" `
                "--results-directory" $ResultsDir
    if ($LASTEXITCODE -ne 0) {
        Write-Error "dotnet test failed (exit code $LASTEXITCODE)."
    }
} finally {
    Pop-Location
}

# ── 2. Locate the Cobertura XML ─────────────────────────────────────────────

$xmlFile = Get-ChildItem $ResultsDir -Recurse -Filter "coverage.cobertura.xml" |
           Sort-Object LastWriteTime -Descending |
           Select-Object -First 1

if (-not $xmlFile) {
    Write-Error "No coverage.cobertura.xml found under $ResultsDir"
}

Write-Host "`n==> Coverage file: $($xmlFile.FullName)`n" -ForegroundColor DarkGray

# ── 3. Parse XML ─────────────────────────────────────────────────────────────

[xml]$cov = Get-Content $xmlFile.FullName

# Summary metrics
$summary = $cov.coverage
$lineRate   = [math]::Round([double]$summary.GetAttribute("line-rate")   * 100, 1)
$branchRate = [math]::Round([double]$summary.GetAttribute("branch-rate") * 100, 1)

# ── 4. Collect uncovered lines ───────────────────────────────────────────────

$uncovered = [System.Collections.Generic.List[PSCustomObject]]::new()

foreach ($class in $cov.SelectNodes("//class")) {
    $file = $class.GetAttribute("filename")
    foreach ($line in $class.SelectNodes("lines/line[@hits='0']")) {
        $uncovered.Add([PSCustomObject]@{
            File   = $file
            Line   = [int]$line.GetAttribute("number")
            Branch = $line.GetAttribute("branch")
        })
    }
}

$grouped = $uncovered | Sort-Object File, Line | Group-Object File

# ── 5. Report ────────────────────────────────────────────────────────────────

if ($grouped) {
    Write-Host "==> Uncovered lines by file:`n" -ForegroundColor Yellow
    foreach ($g in $grouped) {
        Write-Host "  $($g.Name)" -ForegroundColor White
        $lines      = $g.Group | Where-Object { $_.Branch -ne "True" } | ForEach-Object { $_.Line }
        $branches   = $g.Group | Where-Object { $_.Branch -eq "True" } | ForEach-Object { $_.Line }

        if ($lines) {
            Write-Host "    Statements : $($lines -join ', ')" -ForegroundColor Gray
        }
        if ($branches) {
            Write-Host "    Branches   : $($branches -join ', ')" -ForegroundColor DarkYellow
        }
        Write-Host ""
    }
} else {
    Write-Host "==> No uncovered lines found. 100% line coverage!" -ForegroundColor Green
}

# ── 6. Summary ───────────────────────────────────────────────────────────────

$totalUncovered = $uncovered.Count
Write-Host "==> Summary" -ForegroundColor Cyan
Write-Host "    Line coverage   : $lineRate%"
Write-Host "    Branch coverage : $branchRate%"
Write-Host "    Uncovered lines : $totalUncovered"
Write-Host ""
