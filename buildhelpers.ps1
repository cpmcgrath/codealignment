function Replace($file, $before, $after)
{
    $content = Get-Content $file | Foreach-Object {$_ -replace $before, $after }
    $content | Set-Content $file -Encoding UTF8
}

function UpdateVersion($project, $version)
{
    $file = "./$project/Properties/AssemblyInfo.cs"
    Replace $file "AssemblyVersion\s*\([^\)]+\)"     "AssemblyVersion    (`"$version`")"
    Replace $file "AssemblyFileVersion\s*\([^\)]+\)" "AssemblyFileVersion(`"$version`")"
}

function UpdateVsVersion($project, $version)
{
    UpdateVersion $project $version
        
    Replace "./$project/CodeAlignmentPackage.cs" `
            "\[InstalledProductRegistration\(`"#110`", `"#112`", `"[^`"]+`", IconResourceID = 400\)\]" `
            "[InstalledProductRegistration(`"#110`", `"#112`", `"$version`", IconResourceID = 400)]"
        
    Replace "./$project/source.extension.vsixmanifest" `
            "2adcbb11-89c4-451e-97f2-14049154ccad`" Version=`"[^`"]+`"" `
            "2adcbb11-89c4-451e-97f2-14049154ccad`" Version=`"$version`""
}


function CollectNpp($is64)
{
    $origin = $pwd

    $outputMod   = if ($is64) { "\x64" }    else { "" }
    $zipSuffix   = if ($is64) { "x64.zip" } else { "x86.zip" }
    $zipFileName = "CodeAlignmentNpp_$($env:APPVEYOR_REPO_TAG_NAME)_$zipSuffix"
    cd "CodeAlignment.Npp\bin$outputMod\$env:CONFIGURATION"
    7z a -r $zipFileName *.dll
    Push-AppveyorArtifact $zipFileName -FileName $zipFileName
    cd $origin
}
