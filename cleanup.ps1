Get-ChildItem **\ -include bin,obj -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }
Get-ChildItem **\packages -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }
Get-ChildItem **\ -include *.csproj.user -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }