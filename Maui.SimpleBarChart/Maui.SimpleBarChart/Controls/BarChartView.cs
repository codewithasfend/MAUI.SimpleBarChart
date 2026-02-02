using Microsoft.Maui.Graphics;
using Maui.SimpleBarChart.Drawables;

namespace Maui.SimpleBarChart.Controls;

public class BarChartView : GraphicsView
{
    private readonly BarChartDrawable _drawable;

    public BarChartView()
    {
        _drawable = new BarChartDrawable();
        Drawable = _drawable;

        // default centering
        HorizontalOptions = LayoutOptions.Center;
        VerticalOptions = LayoutOptions.Center;
    }

    // ================= X AXIS =================
    public static readonly BindableProperty XAxisLabelsProperty =
        BindableProperty.Create(nameof(XAxisLabels), typeof(IList<string>), typeof(BarChartView),
            propertyChanged: OnDataChanged);
    public IList<string> XAxisLabels
    {
        get => (IList<string>)GetValue(XAxisLabelsProperty);
        set => SetValue(XAxisLabelsProperty, value);
    }

    // ================= Y AXIS =================
    public static readonly BindableProperty YAxisValuesProperty =
        BindableProperty.Create(nameof(YAxisValues), typeof(IList<double>), typeof(BarChartView),
            propertyChanged: OnDataChanged);
    public IList<double> YAxisValues
    {
        get => (IList<double>)GetValue(YAxisValuesProperty);
        set => SetValue(YAxisValuesProperty, value);
    }

    // ================= STYLE =================
    public static readonly BindableProperty BarColorProperty =
        BindableProperty.Create(nameof(BarColor), typeof(Color), typeof(BarChartView),
            Colors.CornflowerBlue, propertyChanged: OnStyleChanged);
    public Color BarColor
    {
        get => (Color)GetValue(BarColorProperty);
        set => SetValue(BarColorProperty, value);
    }

    public static readonly BindableProperty BarWidthProperty =
        BindableProperty.Create(nameof(BarWidth), typeof(float), typeof(BarChartView), 0f,
            propertyChanged: OnStyleChanged);
    public float BarWidth
    {
        get => (float)GetValue(BarWidthProperty);
        set => SetValue(BarWidthProperty, value);
    }

    public static readonly BindableProperty BarSpacingProperty =
        BindableProperty.Create(nameof(BarSpacing), typeof(float), typeof(BarChartView), 12f,
            propertyChanged: OnStyleChanged);
    public float BarSpacing
    {
        get => (float)GetValue(BarSpacingProperty);
        set => SetValue(BarSpacingProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(float), typeof(BarChartView), 12f,
            propertyChanged: OnStyleChanged);
    public float FontSize
    {
        get => (float)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static readonly BindableProperty FontColorProperty =
        BindableProperty.Create(nameof(FontColor), typeof(Color), typeof(BarChartView), Colors.Black,
            propertyChanged: OnStyleChanged);
    public Color FontColor
    {
        get => (Color)GetValue(FontColorProperty);
        set => SetValue(FontColorProperty, value);
    }

    public static readonly BindableProperty XAxisRowHeightProperty =
        BindableProperty.Create(nameof(XAxisRowHeight), typeof(float), typeof(BarChartView), 40f,
            propertyChanged: OnStyleChanged);
    public float XAxisRowHeight
    {
        get => (float)GetValue(XAxisRowHeightProperty);
        set => SetValue(XAxisRowHeightProperty, value);
    }

    public static readonly BindableProperty YAxisTopPaddingProperty =
        BindableProperty.Create(nameof(YAxisTopPadding), typeof(float), typeof(BarChartView), 10f,
            propertyChanged: OnStyleChanged);
    public float YAxisTopPadding
    {
        get => (float)GetValue(YAxisTopPaddingProperty);
        set => SetValue(YAxisTopPaddingProperty, value);
    }

    public static readonly BindableProperty XAxisLabelOffsetProperty =
        BindableProperty.Create(nameof(XAxisLabelOffset), typeof(float), typeof(BarChartView), 5f,
            propertyChanged: OnStyleChanged);
    public float XAxisLabelOffset
    {
        get => (float)GetValue(XAxisLabelOffsetProperty);
        set => SetValue(XAxisLabelOffsetProperty, value);
    }

    // ================= Y AXIS VALUE OPTIONS =================
    public static readonly BindableProperty ShowValuesOnTopProperty =
        BindableProperty.Create(nameof(ShowValuesOnTop), typeof(bool), typeof(BarChartView), true,
            propertyChanged: OnStyleChanged);
    public bool ShowValuesOnTop
    {
        get => (bool)GetValue(ShowValuesOnTopProperty);
        set => SetValue(ShowValuesOnTopProperty, value);
    }

    public static readonly BindableProperty FixedValuesRowProperty =
        BindableProperty.Create(nameof(FixedValuesRow), typeof(float), typeof(BarChartView), 5f,
            propertyChanged: OnStyleChanged);
    public float FixedValuesRow
    {
        get => (float)GetValue(FixedValuesRowProperty);
        set => SetValue(FixedValuesRowProperty, value);
    }

    // ================= CHANGE HANDLERS =================
    static void OnDataChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (BarChartView)bindable;
        view._drawable.YAxisValues = view.YAxisValues?.ToList() ?? new();
        view._drawable.XAxisLabels = view.XAxisLabels?.ToList() ?? new();
        view.Invalidate();
    }

    static void OnStyleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (BarChartView)bindable;

        view._drawable.BarColor = view.BarColor;
        view._drawable.BarWidth = view.BarWidth;
        view._drawable.BarSpacing = view.BarSpacing;
        view._drawable.FontSize = view.FontSize;
        view._drawable.FontColor = view.FontColor;
        view._drawable.XAxisRowHeight = view.XAxisRowHeight;
        view._drawable.YAxisTopPadding = view.YAxisTopPadding;
        view._drawable.XAxisLabelOffset = view.XAxisLabelOffset;

        view._drawable.ShowValuesOnTop = view.ShowValuesOnTop;
        view._drawable.FixedValuesRow = view.FixedValuesRow;

        view.Invalidate();
    }
}
