# s!box
s!box (aka snotbox) is an open source implementation of the [s&box](https://sbox.facepunch.com/) C# API.

The goal of s!box is to provide a development environment where s&box addon developers can start to create addons without needing access to the s&box beta. This project is only concerned with the s&box API and not the s&box client, so there's no graphics or networking or anything like that. 

**NOTE:** This is only for developers, this is not a game.

## Building

### Requirements

* [.NET Core 5.0](https://dotnet.microsoft.com/download)

### Build steps

1. Clone this project
2. Run `dotnet build`
3. After building run `dotnet run --project SnotboxRunner`

This will start the s!box runner which will compile and run the example addon.

## Overview

s!box contains 2 .NET Core C# projects and an example s&box addon.

The first being `Snotbox`. This is my own version of the Sandbox library, based on the content available in the s&box wiki and how open source addons on GitHub are using the APIs. The goal of the library is to mock the official API so it's possible to begin development of an addon before properly testing it in s&box. Since this is only designed to mock the official API, it doesn't contain any code to handle maps, models, sounds, networking, etc.

This repo also includes a project called `SnotboxRunner`. This is a .NET Core console app that takes advantage of Roslyn to compile addon code at runtime, similar to how s&box handles it (but not nearly as well).

## Contributing

Reimplementing the s&box API is no small task and I welcome all contributions to this project. Please feel free to submit issues and pull requests.