# oqtane.TelerikModule1

## Purpose

How to integrate [*Telerik Blazor UI Components*](https://www.telerik.com/blazor-ui) into [*Oqtane Application Framework for Blazor*](www.oqtane.org).

![Oqtane Module with Telerik Data Grid component](https://github.com/nicpitsch/Oqtane.TelerikModule1/assets/1652835/7a55889e-2f3f-48ea-acb6-a142e62620ca)

## Information, Requirements

This is how I got it running. I'm not an Oqtane developer (but a enthusiastic user) and I'm not related Telerik. I have integrated Telerik Blazor UI and Reporting into a line of business solution using Oqtane (but not yet updated from Blazor 3.x to 4.x).

* [Oqtane development environment](https://github.com/oqtane/oqtane.framework#getting-started).
* [A Telerik Blazor UI full or trial license](https://www.telerik.com/blazor-ui).
* The integration was implemented using the *Blazor Server* hosting model (Oqtane Site Settings).
* Versions: *Oqtane 4.0.1*, *Telerik Blazor UI 4.3.0*.

## Steps

The subsequent steps are reflected this repository commits.

### Create a Oqtane Module

Create a Module within your Oqtane development environment (*oqtane.framework*). I named it *My.TelerikModule1* (referenced subsequent as *Module*). This is the *Initial commit*.

### Install Telerik.Blazor NuGet package

* Install *Telerik.UI.for.Blazor* into the Module Client VS Project *My.Module.TelerikModule1.Client* (Client Project).
* To get the Telerik dll and static resources (*.js, *.css) into the *./Debug/bin* folders of the Client VS Project, execute: `dotnet publish --configuration Debug -p:PublishSingleFile=false -p:PublishTrimmed=false --runtime win10-x64 --self-contained false` from the Client Project folder. Maybe it could be done too by using VS *Publish*.

### Integrate the Telerik css & js resources

Based on the [Oqtane CCS & JS resources blog](https://www.oqtane.org/blog/!/61/css-js-resources) I have used the *IModule* implementation by adding the *Resources* property into the existing *ModuleInfo.cs*:

```cs
...
Resources = new List<Resource>
{
    new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Telerik.UI.for.Blazor/css/kendo-theme-default/all.css" },              
    new Resource { ResourceType = ResourceType.Script, Url = "~/Telerik.UI.for.Blazor/js/telerik-blazor.js", Level = ResourceLevel.Site },
}
...
```

Within a larger environment having multiply submodules I would probably use the *ITheme* implementation.

### Deploy the Telerik dll's and static resources

You have get the dll into the *oqtane.framework\Oqtane.Server\bin\Debug\net7.0* folder and the css & js into the *oqtane.framework\Oqtane.Server\wwwroot\Modules\My.Module.TelerikModule1/Telerik.UI.for.Blazor* subfolders. This is where the *My.Module.TelerikModule1.Package* Module VS project comes into play.

* *debug.cmd* is for the deploy within the development environment.
* *My.Module.TelerikModule1.nuspec* is for generating in installable *nuspec* package into the *Package* subfolder.

```ini
:: debug.cmd additions:
REM Telerik Blazor:
XCOPY "..\Client\bin\Debug\net7.0\win10-x64\publish\Telerik*.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
REM Telerik Blazor static resources (css, js):
XCOPY "..\Client\bin\Debug\net7.0\win10-x64\publish\wwwroot\_content\Telerik.UI.for.Blazor\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\My.Module.TelerikModule1\Telerik.UI.for.Blazor\" /Y /S /I

:: My.Module.TelerikModule1.nuspec additions
<!-- Telerik libraries -->
<file src="..\Client\bin\Debug\net7.0\win10-x64\publish\Telerik*.dll" target="lib\net7.0" />
<!-- Telerik Blazor static resources (css, js) -->
<file src="..\Client\bin\Debug\net7.0\win10-x64\publish\wwwroot\_content\Telerik.UI.for.Blazor\**\*.*" target="wwwroot\Modules\My.Module.TelerikModule1\Telerik.UI.for.Blazor\" />
```

### Integrate Telerik Data Grid into the Module

Integrate Telerik Data Grid into the *index.razor* component of your Module. It's based on the [Telerik docs Typical Workflow for Using the UI for Blazor Components](https://docs.telerik.com/blazor-ui/getting-started/what-you-need).

*_Imports.razor*:

```razor
...
@using Telerik.Blazor
@using Telerik.Blazor.Components
@using Telerik.FontIcons
@using Telerik.SvgIcons
```

*index.razor*:

```razor
...
<TelerikRootComponent>
    <TelerikGrid Data="@_TelerikModule1s"
                 Pageable="true" PageSize="50" Sortable="true"
                 FilterMode="Telerik.Blazor.GridFilterMode.FilterRow"
                 Resizable="true" 
                 Reorderable="true">
        <GridColumns>
            <GridColumn Field="@(nameof(TelerikModule1.Name))" Title="Name" />
            <GridColumn Field="@(nameof(TelerikModule1.CreatedBy))" Title="CreatedBy" />
        </GridColumns>
    </TelerikGrid>
</TelerikRootComponent>
...
```
