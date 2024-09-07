using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication1.UsersControl;

public partial class ScaleMark : UserControl
{
    public static readonly StyledProperty<double> LineWidthProperty = AvaloniaProperty.Register<ScaleMark, double>("LineWidth", 1.0);
    public static readonly StyledProperty<double> IntervalProperty = AvaloniaProperty.Register<ScaleMark, double>("Interval", 10.0);
    public static readonly StyledProperty<int> SplitCountProperty = AvaloniaProperty.Register<ScaleMark, int>("SplitCount", 5);
    public static readonly StyledProperty<double> MarkExpandProperty = AvaloniaProperty.Register<ScaleMark, double>("MarkExpand", 0.2);
    public static readonly StyledProperty<IBrush?> SplitForegroundProperty = AvaloniaProperty.Register<ScaleMark, IBrush?>("SplitForeground", null);

    public double LineWidth
    {
        get => GetValue(LineWidthProperty);
        set => SetValue(LineWidthProperty, value);
    }

    public double Interval
    {
        get => GetValue(IntervalProperty);
        set => SetValue(IntervalProperty, value);
    }

    public int SplitCount
    {
        get => GetValue(SplitCountProperty);
        set => SetValue(SplitCountProperty, value);
    }

    public double MarkExpand
    {
        get => GetValue(MarkExpandProperty);
        set => SetValue(MarkExpandProperty, value);
    }

    public IBrush? SplitForeground
    {
        get => GetValue(SplitForegroundProperty);
        set => SetValue(SplitForegroundProperty, value);
    }

    public ScaleMark()
    {
        InitializeComponent();
    }

    public override void Render(DrawingContext context)
    {
        var space = Interval / SplitCount;
        var splitForeground = SplitForeground ?? Foreground;
        var linePen = new Pen(splitForeground, LineWidth, null, PenLineCap.Round);
        var markPen = new Pen(Foreground, LineWidth + MarkExpand, null, PenLineCap.Round);

        for (double startX = 0, y1 = Bounds.Height * 0.3, y2 = Bounds.Height - (LineWidth / 2.0); startX < Bounds.Width; startX += Interval)
        {
            double currentX = startX;
            context.DrawLine(markPen, new Point(currentX + (LineWidth + MarkExpand) / 2.0, (LineWidth + MarkExpand) / 2.0), new Point(currentX + (LineWidth + MarkExpand) / 2.0, Bounds.Height - (LineWidth + MarkExpand) / 2.0));
            currentX += space;

            for (; currentX < startX + Interval; currentX += space)
            {
                if (startX + Interval - currentX < space) break;

                context.DrawLine(linePen, new Point(currentX, y1), new Point(currentX, y2));
            }
        }

        context.DrawLine(markPen, new Point(Bounds.Width - (LineWidth + MarkExpand) / 2.0, (LineWidth + MarkExpand) / 2.0), new Point(Bounds.Width - (LineWidth + MarkExpand) / 2.0, Bounds.Height - (LineWidth + MarkExpand) / 2.0));
        base.Render(context);
    }
}