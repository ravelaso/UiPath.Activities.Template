# Ravelaso UiPath Template

A multi-project template for UiPath activities ported from the original VisualStudio template.

## New in v2.0.0

A set of new templates with examples have been added.
Contains an activity only project(no viewmodel, no test), an activity project with viewmodel, and the default solution template with all the projects, as it used to be in version v1.x.x

This means new project templates may be added.

## Usage

To use this template, install it from nuget.org using the following command:

```sh
dotnet new install Ravelaso.UiPath.Template
```


## Nuget Source

In order to restore the packages, you will need to add the UiPath Azure nuget registry:

```sh
dotnet nuget add source https://pkgs.dev.azure.com/uipath/Public.Feeds/_packaging/UiPath-Official/nuget/v3/index.json -n UiPath
```
