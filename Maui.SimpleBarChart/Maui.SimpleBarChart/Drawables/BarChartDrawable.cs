using Microsoft.Maui.Graphics;

namespace Maui.SimpleBarChart.Drawables;

public class BarChartDrawable : IDrawable
{
    public List<double> YAxisValues { get; set; } = new();
    public List<string> XAxisLabels { get; set; } = new();

    // ========== STYLE PROPERTIES ==========
    public Color BarColor { get; set; } = Colors.Blue;
    public float BarWidth { get; set; } = 0; // 0 = auto width
    public float BarSpacing { get; set; } = 12;
    public float XAxisRowHeight { get; set; } = 40;
    public float YAxisTopPadding { get; set; } = 10;

    public float FontSize { get; set; } = 12;
    public Color FontColor { get; set; } = Colors.Black;

    // extra spacing below X-axis for labels
    public float XAxisLabelOffset { get; set; } = 5;

    // ================= Y AXIS VALUE OPTIONS =================
    public bool ShowValuesOnTop { get; set; } = true;
    public float FixedValuesRow { get; set; } = 5; // if not on top, Y position from top

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // return if no data
        if (YAxisValues.Count == 0 || XAxisLabels.Count == 0)
            return;

        int count = Math.Min(YAxisValues.Count, XAxisLabels.Count);

        float width = dirtyRect.Width;
        float height = dirtyRect.Height;

        double maxValue = YAxisValues.Max();

        // define chart area
        float barAreaTop = YAxisTopPadding;
        float barAreaBottom = height - XAxisRowHeight;
        float barAreaHeight = barAreaBottom - barAreaTop;

        // calculate bar width
        float barWidth = BarWidth > 0
            ? BarWidth
            : (width - (count + 1) * BarSpacing) / count;

        // ========== HORIZONTAL CENTERING ==========
        float totalBarsWidth = count * barWidth + (count + 1) * BarSpacing;
        float startX = (width - totalBarsWidth) / 2;

        // ========== DRAW BARS ==========
        canvas.FillColor = BarColor;
        for (int i = 0; i < count; i++)
        {
            float barHeight = (float)(YAxisValues[i] / maxValue * barAreaHeight);
            float x = startX + BarSpacing + i * (barWidth + BarSpacing);
            float y = barAreaBottom - barHeight;

            canvas.FillRectangle(x, y, barWidth, barHeight);
        }

        // ========== DRAW X-AXIS LABELS ==========
        float labelY = height - XAxisRowHeight + XAxisLabelOffset;
        canvas.FontSize = FontSize;
        canvas.FontColor = FontColor;

        for (int i = 0; i < count; i++)
        {
            float x = startX + BarSpacing + i * (barWidth + BarSpacing) + barWidth / 2;
            canvas.DrawString(XAxisLabels[i], x, labelY, HorizontalAlignment.Center);
        }

        // ========== DRAW Y-AXIS VALUES ==========
        for (int i = 0; i < count; i++)
        {
            float barHeight = (float)(YAxisValues[i] / maxValue * barAreaHeight);
            float x = startX + BarSpacing + i * (barWidth + BarSpacing) + barWidth / 2;
            float y = ShowValuesOnTop
                ? barAreaBottom - barHeight - 5   // above each bar
                : FixedValuesRow;                 // fixed row from top

            canvas.DrawString(YAxisValues[i].ToString(), x, y, HorizontalAlignment.Center);
        }
    }

}
