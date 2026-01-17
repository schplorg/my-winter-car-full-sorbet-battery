#dotnet build FullSorbetBattery.csproj -c Release
#cp ".\bin\Release\net48\FullSorbetBattery.dll" "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\Mods\"

$env:PATH = "C:\Program Files\Mono\bin;$env:PATH"
$refs = @(
    "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\mywintercar_Data\Managed\Assembly-CSharp.dll",
    "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\mywintercar_Data\Managed\MSCLoader.dll",
    "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\mywintercar_Data\Managed\PlayMaker.dll",
    "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\mywintercar_Data\Managed\UnityEngine.dll"
)
$refArgs = $refs | ForEach-Object { "-r:`"$_`"" }
mcs -sdk:2 -target:library -out:dist/FullSorbetBattery.dll $refArgs -unsafe *.cs
cp ".\dist\FullSorbetBattery.dll" "C:\Program Files (x86)\Steam\steamapps\common\My Winter Car\Mods\"
