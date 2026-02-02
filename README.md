# Maui.SimpleBarChart

A **simple and highly customizable bar chart control** for .NET MAUI apps.  
Display bars with X-axis labels and Y-axis values, and customize every aspect of the chart including **bar color, width, spacing, font, and label positions**.

---

## Features

- Draw **bars** with customizable color, width, and spacing
- Show **X-axis labels** (categories, days, etc.)
- Display **Y-axis values** either floating above each bar or in a fixed row
- **Auto-centers** bars horizontally within the control
- Fully customizable style:
  - `BarColor` – color of the bars
  - `BarWidth` – width of each bar (0 = auto)
  - `BarSpacing` – space between bars
  - `FontSize` – font size for labels and values
  - `FontColor` – font color for labels and values
  - `XAxisRowHeight` – reserved space for X-axis labels
  - `YAxisTopPadding` – top padding of the chart
  - `XAxisLabelOffset` – vertical offset for X-axis labels
  - `ShowValuesOnTop` – Y-axis values above bars (`true`) or fixed row (`false`)
  - `FixedValuesRow` – row position of Y-axis values if `ShowValuesOnTop = false`

---

## Installation

Install via NuGet:

```bash
Install-Package Maui.SimpleBarChart -Version 1.0.0
```

## Installation

XAML Example

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:charts="clr-namespace:Maui.SimpleBarChart.Controls;assembly=Maui.SimpleBarChart"
             x:Class="YourApp.MainPage">

    <Grid>
        <charts:BarChartView
            x:Name="SalesChart"
            WidthRequest="300"
            HeightRequest="300"
            BarColor="DodgerBlue"
            BarWidth="30"
            BarSpacing="20"
            FontSize="14"
            FontColor="Green"
            XAxisRowHeight="50"
            YAxisTopPadding="40"
            XAxisLabelOffset="20"
            ShowValuesOnTop="False"
            FixedValuesRow="25"
            HorizontalOptions="Center"
            VerticalOptions="Start"/>
    </Grid>
</ContentPage>


```

C# Example

```cs
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        SalesChart.XAxisLabels = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri" };
        SalesChart.YAxisValues = new List<double> { 100, 150, 90, 130, 110 };

        SalesChart.BarColor = Colors.MediumSeaGreen;
        SalesChart.BarWidth = 25;
        SalesChart.BarSpacing = 10;
        SalesChart.FontSize = 12;
        SalesChart.FontColor = Colors.Black;
        SalesChart.XAxisRowHeight = 40;
        SalesChart.YAxisTopPadding = 15;
        SalesChart.XAxisLabelOffset = 10;

        // show values on top of each bar
        SalesChart.ShowValuesOnTop = true;

        // if ShowValuesOnTop = false, this is the Y position of values
        SalesChart.FixedValuesRow = 20;
    }
}



```

## Customization Options

| Property           | Type  | Default        | Description                                                  |
| ------------------ | ----- | -------------- | ------------------------------------------------------------ |
| `BarColor`         | Color | CornflowerBlue | Color of the bars                                            |
| `BarWidth`         | float | 0              | Width of each bar (0 = auto)                                 |
| `BarSpacing`       | float | 12             | Space between bars                                           |
| `FontSize`         | float | 12             | Font size for labels and values                              |
| `FontColor`        | Color | Black          | Font color for labels and values                             |
| `XAxisRowHeight`   | float | 40             | Height reserved for X-axis labels                            |
| `YAxisTopPadding`  | float | 10             | Padding above the chart                                      |
| `XAxisLabelOffset` | float | 5              | Vertical offset for X-axis labels                            |
| `ShowValuesOnTop`  | bool  | true           | If true, Y-axis values float above bars; else fixed row      |
| `FixedValuesRow`   | float | 5              | Row position of Y-axis values when `ShowValuesOnTop = false` |

