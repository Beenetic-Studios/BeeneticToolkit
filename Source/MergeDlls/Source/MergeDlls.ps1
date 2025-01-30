$solutionDir = "C:\Development\Projects\Utilities\BeeneticToolkit"

# Define paths to the DLLs you want to merge
$project1Dll = "$solutionDir\Builds\bin\Collections\Debug\netstandard2.1\Collections.dll"
$project2Dll = "$solutionDir\Builds\bin\Diagnostics\Debug\netstandard2.1\Diagnostics.dll"
$project3Dll = "$solutionDir\Builds\bin\Extensions\Debug\netstandard2.1\Extensions.dll"
$project4Dll = "$solutionDir\Builds\bin\Logging\Debug\netstandard2.1\Logging.dll"
$project5Dll = "$solutionDir\Builds\bin\Numerics\Debug\netstandard2.1\Numerics.dll"
$project6Dll = "$solutionDir\Builds\bin\Random\Debug\netstandard2.1\Random.dll"

# Define the path to ILRepack.exe
# This path may vary based on how ILRepack is installed
$ilRepackPath = "C:\Users\bfran\.nuget\packages\ilrepack\2.0.18\tools\ILRepack.exe"

# Define the output path for the merged DLL
$outputDll = "$solutionDir\builds\bin\BeeneticToolkit\BeeneticToolkit.dll"

# Run ILRepack
& $ilRepackPath /out:$outputDll /xmldocs $project1Dll $project2Dll $project3Dll $project4Dll $project5Dll $project6Dll

# Check for errors
if ($LASTEXITCODE -ne 0) {
    Write-Error "ILRepack failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}