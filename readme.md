# <img src="/src/icon.png" height="30px"> TextCopy

[![Build status](https://ci.appveyor.com/api/projects/status/35uq76nlt9tl6m3t/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/textcopy)
[![NuGet Status](https://img.shields.io/nuget/v/TextCopy.svg)](https://www.nuget.org/packages/TextCopy/)

A cross platform package to copy text to and from the clipboard.

**See [Milestones](../../milestones?state=closed) for release notes.**


## NuGet package

https://nuget.org/packages/TextCopy/


## Usage


### SetTextAsync

<!-- snippet: SetTextAsync -->
<a id='snippet-SetTextAsync'></a>
```cs
await ClipboardService.SetTextAsync("Text to place in clipboard");
```
<sup><a href='/src/Tests/Snippets.cs#L34-L38' title='Snippet source file'>snippet source</a> | <a href='#snippet-SetTextAsync' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### SetText

<!-- snippet: SetText -->
<a id='snippet-SetText'></a>
```cs
ClipboardService.SetText("Text to place in clipboard");
```
<sup><a href='/src/Tests/Snippets.cs#L9-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-SetText' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### GetTextAsync

<!-- snippet: GetTextAsync -->
<a id='snippet-GetTextAsync'></a>
```cs
var text = await ClipboardService.GetTextAsync();
```
<sup><a href='/src/Tests/Snippets.cs#L43-L47' title='Snippet source file'>snippet source</a> | <a href='#snippet-GetTextAsync' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### GetText

<!-- snippet: GetText -->
<a id='snippet-GetText'></a>
```cs
var text = ClipboardService.GetText();
```
<sup><a href='/src/Tests/Snippets.cs#L25-L29' title='Snippet source file'>snippet source</a> | <a href='#snippet-GetText' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Clearing The Clipboard

<!-- snippet: ClearClipboard -->
<a id='snippet-ClearClipboard'></a>
```cs
ClipboardService.SetText("");
```
<sup><a href='/src/Tests/Snippets.cs#L52-L54' title='Snippet source file'>snippet source</a> | <a href='#snippet-ClearClipboard' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: ClearClipboardAsync -->
<a id='snippet-ClearClipboardAsync'></a>
```cs
await ClipboardService.SetTextAsync("");
```
<sup><a href='/src/Tests/Snippets.cs#L59-L61' title='Snippet source file'>snippet source</a> | <a href='#snippet-ClearClipboardAsync' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Instance API

In addition to the above static API, there is an instance API exposed:

<!-- snippet: SetTextInstance -->
<a id='snippet-SetTextInstance'></a>
```cs
Clipboard clipboard = new();
clipboard.SetText("Text to place in clipboard");
```
<sup><a href='/src/Tests/Snippets.cs#L15-L20' title='Snippet source file'>snippet source</a> | <a href='#snippet-SetTextInstance' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Dependency Injection

An instance of `Clipboard` can be injected into `IServiceCollection`:

<!-- snippet: InjectClipboard -->
<a id='snippet-InjectClipboard'></a>
```cs
serviceCollection.InjectClipboard();
```
<sup><a href='/src/BlazorSample/Program.cs#L9-L11' title='Snippet source file'>snippet source</a> | <a href='#snippet-InjectClipboard' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

The instance should be injected by using `IClipboard`.

There is also a `InjectMockClipboard` that injects an instance of `MockClipboard` with all methods stubbed out.


## Supported on

 * Windows with .NET Framework 4.6.1 and up
 * Windows with .NET Core 2.0 and up
 * Windows with Mono 5.0 and up
 * OSX with .NET Core 2.0 and up
 * OSX with Mono 5.20.1 and up
 * Linux with .NET Core 2.0 and up
 * Linux with Mono 5.20.1 and up
 * Xamarin.Android 9.0 and up
 * Xamarin.iOS 10.0 and up
 * Blazor WebAssembly 6.0 and up


## Blazor WebAssembly

Due to the dependency on `JSInterop` the static `ClipboardService` is not supported on Blazor.

Instead inject an `IClipboard`:

<!-- snippet: BlazorStartup -->
<a id='snippet-BlazorStartup'></a>
```cs
var builder = WebAssemblyHostBuilder.CreateDefault();
var serviceCollection = builder.Services;
serviceCollection.InjectClipboard();
builder.RootComponents.Add<App>("app");
```
<sup><a href='/src/BlazorSample/Program.cs#L6-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-BlazorStartup' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Then consume it:

<!-- snippet: Inject -->
<a id='snippet-Inject'></a>
```cs
public partial class IndexModel :
    ComponentBase
{
    [Inject]
    public IClipboard Clipboard { get; set; }

    public string Content { get; set; }

    public Task CopyTextToClipboard() =>
        Clipboard.SetTextAsync(Content);

    public async Task ReadTextFromClipboard() =>
        Content = await Clipboard.GetTextAsync();
}
```
<sup><a href='/src/BlazorSample/Pages/IndexModel.cs#L9-L24' title='Snippet source file'>snippet source</a> | <a href='#snippet-Inject' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Blazor support requires the browser APIs [clipboard.readText](https://caniuse.com/#feat=mdn-api_clipboard_readtext) and [clipboard.writeText](https://caniuse.com/#feat=mdn-api_clipboard_writetext).


## Linux

Linux uses [xsel](https://github.com/kfish/xsel) to access the clipboard. As such it needs to be installed and callable.


## Icon

[Clone](https://thenounproject.com/term/Clone/207435/) designed by [Wes Breazell](https://thenounproject.com/wes13/) from [The Noun Project](https://thenounproject.com).
