[![License](https://img.shields.io/github/license/Lucisano/blazor-components.svg)](https://github.com/Lucisano/blazor-components/blob/master/LICENSE)

# Blazor Components Open Source Repository

I encourage anybody to contribute and use this code here.

This repository comprises simply of custom controls and components that I have created for use in my own work.

da

## Features ##

**Date Time Picker**
- Ability to manually enter date
- Ability to select date from drop down
- Ability to hook into **DateChanged** event/action
- Ability to specify **DateTimeFormat** as parameter (default set as "dd/MM/yyyy")

**Example Implementation**

```HTML
@using BlazorComponents.Components

<!-- Vanilla Implementation -->
<DateTimePicker />

<!-- Date Time format "if ya nasty" Implementation -->
<DateTimePicker DateTimeStringFormat="MM/dd/yy" />

<!-- Will stop the Tile window closing after selecting a date -->
<DateTimePicker CloseDateTileWindow="false"/>
```
**Example Event Handling**

HTML/Razor
```HTML
@page "/"
@inherits TestPageBase
@using BlazorComponents.Components

<DateTimePicker DateChanged=@HandleDateChanged/>
```

C#
```csharp
public class TestPageBase : ComponentBase
{
    public void HandleDateChanged(DateTime date)
    {
        //do stuff;
    }
}
```
