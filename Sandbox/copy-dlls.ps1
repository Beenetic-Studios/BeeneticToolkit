<#
.SYNOPSIS
    Builds BeeneticToolkit.Spatial (Release) and copies its DLLs into the Unity visual-test harness.

.DESCRIPTION
    The Unity project references the toolkit as managed plugins rather than source, so it exercises the actual
    built artifact you would publish. Re-run this after changing any Spatial/Collections code, then let Unity
    reimport. The copied DLLs are gitignored.
#>
$ErrorActionPreference = 'Stop'

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$project  = Join-Path $repoRoot 'Source\Core\Spatial\Spatial.csproj'
$output   = Join-Path $repoRoot 'builds\bin\Spatial\Release\netstandard2.1'
$dest     = Join-Path $PSScriptRoot 'SpatialVisualizer\Assets\Plugins\BeeneticToolkit'

Write-Host "Building $project (Release)..."
dotnet build $project -c Release --nologo
if ($LASTEXITCODE -ne 0) { throw "Build failed (exit $LASTEXITCODE)." }

New-Item -ItemType Directory -Force -Path $dest | Out-Null

# Clear any previously-copied assemblies first, so a renamed assembly never leaves a stale duplicate behind.
Get-ChildItem -Path $dest -File | Where-Object { $_.Extension -in '.dll', '.xml', '.pdb' } | Remove-Item -Force

# Copy the project DLLs + XML docs (BeeneticToolkit.Spatial.dll and its BeeneticToolkit.Collections.dll dependency).
Get-ChildItem -Path $output -File | Where-Object { $_.Extension -in '.dll', '.xml' } | ForEach-Object {
    Copy-Item $_.FullName -Destination $dest -Force
    Write-Host "  copied $($_.Name)"
}

Write-Host "Done. DLLs are in $dest"
