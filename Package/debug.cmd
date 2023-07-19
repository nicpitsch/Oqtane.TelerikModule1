XCOPY "..\Client\bin\Debug\net7.0\My.Module.TelerikModule1.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Client\bin\Debug\net7.0\My.Module.TelerikModule1.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Server\bin\Debug\net7.0\My.Module.TelerikModule1.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Server\bin\Debug\net7.0\My.Module.TelerikModule1.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Shared\bin\Debug\net7.0\My.Module.TelerikModule1.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Shared\bin\Debug\net7.0\My.Module.TelerikModule1.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
REM Telerik Blazor:
XCOPY "..\Client\bin\Debug\net7.0\win10-x64\publish\Telerik*.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
REM Telerik Blazor static resources (css, js):
XCOPY "..\Client\bin\Debug\net7.0\win10-x64\publish\wwwroot\_content\Telerik.UI.for.Blazor\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\My.Module.TelerikModule1\Telerik.UI.for.Blazor\" /Y /S /I