# oqtane.TelerikModule1

## Purpose

How to integrate [*Telerik Blazor UI Components*](https://www.telerik.com/blazor-ui) components into [*Oqtane Application Framework for Blazor*](www.oqtane.org).

![Oqtane Module with Telerik Data Grid component](https://github.com/nicpitsch/Oqtane.TelerikModule1/assets/1652835/7a55889e-2f3f-48ea-acb6-a142e62620ca)

## Information, Requirements

This is how I got it running. I'm not an Oqtane developer (but a user) and I'm not related Telerik, but I have integrated Telerik Blazor UI and Reporting into a line of business solution.

* [Oqtane development environment](https://github.com/oqtane/oqtane.framework#getting-started).
* [A Telerik Blazor UI full or trial license](https://www.telerik.com/blazor-ui).
* The integration was implemented using the *Blazor Server* hosting model (Oqtane Site Settings).
* Versions: *Oqtane 4.0.1*, *Telerik Blazor UI 4.3.0*.

## Steps

The subsequent steps are reflected by commits in this repo.

### Create a Oqtane Module

Create a Module within your Oqtane development environment. I named it *My.TelerikModule1* (referenced subsequent as *Module*). This is the *Initial commit*.

### Install Telerik.Blazor NuGet package

* Install *Telerik.UI.for.Blazor* into the Module Client VS Project *My.Module.TelerikModule1.Client* (Client Project).
* To get the Telerik dll and static resources (*.js, *.css) into the *./Debug/bin* folders of the Client VS Project, execute: `dotnet publish --configuration Debug -p:PublishSingleFile=false -p:PublishTrimmed=false --runtime win10-x64 --self-contained false` from the Client Project folder.
