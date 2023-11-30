$solutionDir = "C:\Development\Projects\Utilities\BeeneticToolkit"

# Define paths to the DLLs you want to merge
$project1Dll = "$solutionDir\Core\Random\bin\Debug\netstandard2.1\Random.dll"
$project2Dll = "$solutionDir\Core\Logging\bin\Debug\netstandard2.1\Logging.dll"
# C:\Development\Projects\Utilities\BeeneticToolkit\Core\Random\bin\Debug\netstandard2.1

# Define the path to ILRepack.exe
# This path may vary based on how ILRepack is installed
$ilRepackPath = "C:\Users\bfran\.nuget\packages\ilrepack\2.0.18\tools\ILRepack.exe"

# Define the output path for the merged DLL
$outputDll = "$solutionDir\Master\bin\Debug\net6.0\BeeneticToolkit.dll"
# C:\Development\Projects\Utilities\BeeneticToolkit\Master\bin\Debug\net6.0

# Run ILRepack
& $ilRepackPath /out:$outputDll $project1Dll $project2Dll

# Check for errors
if ($LASTEXITCODE -ne 0) {
    Write-Error "ILRepack failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}