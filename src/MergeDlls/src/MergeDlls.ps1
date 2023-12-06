$solutionDir = "C:\Development\Projects\Utilities\BeeneticToolkit"

# Define paths to the DLLs you want to merge
$project1Dll = "$solutionDir\builds\bin\Random\Debug\netstandard2.1\Random.dll"
$project2Dll = "$solutionDir\builds\bin\Logging\Debug\netstandard2.1\Logging.dll"
$project3Dll = "$solutionDir\builds\bin\Extensions\Debug\netstandard2.1\Extensions.dll"
$project4Dll = "$solutionDir\builds\bin\MathUtils\Debug\netstandard2.1\MathUtils.dll"
$project5Dll = "$solutionDir\builds\bin\CollectionUtils\Debug\netstandard2.1\CollectionUtils.dll"

# Define the path to ILRepack.exe
# This path may vary based on how ILRepack is installed
$ilRepackPath = "C:\Users\bfran\.nuget\packages\ilrepack\2.0.18\tools\ILRepack.exe"

# Define the output path for the merged DLL
$outputDll = "$solutionDir\builds\bin\BeeneticToolkit\BeeneticToolkit.dll"

# Run ILRepack
& $ilRepackPath /out:$outputDll /xmldocs $project1Dll $project2Dll $project3Dll $project4Dll $project5Dll

# Check for errors
if ($LASTEXITCODE -ne 0) {
    Write-Error "ILRepack failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}