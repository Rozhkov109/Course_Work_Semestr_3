using System;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace CourseWork
{
    public partial class Graph : Window
    {
        public Graph(FunctionWithPoints Fx, FunctionWithPoints Gx, double eps)
        {
            InitializeComponent();
            CreateGraph(Fx, Gx, eps);
        }

        void CreateGraph(FunctionWithPoints Fx, FunctionWithPoints Gx, double eps)
        {
            // PlotModel для відображення графіку
            PlotModel model = new PlotModel();
            // Серії для F(x) та G(x) та F(x) - G(x)
            LineSeries seriesFx = new LineSeries { Title = "F(x)" };
            LineSeries seriesGx = new LineSeries { Title = "G(x)" };
            LineSeries seriesDiff = new LineSeries { Title = "F(x) - G(x)" };

            FunctionWithPointsCalculator calc = new FunctionWithPointsCalculator();

            double maxPoints = Math.Max(Fx.PointsList.Count, Gx.PointsList.Count);
            double step = 1.0 / (maxPoints * 100);

            double minXFx = Fx.PointsList.Min(p => p.X);
            double maxXFx = Fx.PointsList.Max(p => p.X);


            double minXGx = Gx.PointsList.Min(p => p.X);
            double maxXGx = Gx.PointsList.Max(p => p.X);


            for (double x = minXFx; x <= maxXFx; x += step)
            {
                double interpolatedValueFx = calc.Interpolation(Fx, x, eps);
                seriesFx.Points.Add(new DataPoint(x, interpolatedValueFx));
            }

            for (double x = minXGx; x <= maxXGx; x +=  step )
            {
                double interpolatedValueGx = calc.Interpolation(Gx, x, eps);
                seriesGx.Points.Add(new DataPoint(x, interpolatedValueGx));
            }

            for (int i = 0; i < Math.Min(seriesFx.Points.Count, seriesGx.Points.Count); i++)
            { seriesDiff.Points.Add(new DataPoint(seriesFx.Points[i].X, seriesFx.Points[i].Y - seriesGx.Points[i].Y)); }

            model.Series.Add(seriesFx);
            model.Series.Add(seriesGx);
            model.Series.Add(seriesDiff);

            model.Title = "Графік F(x), G(x) та F(x) - G(x)";


            Legend legend = new Legend
            {
                LegendTitle = "Легенда",
                LegendPosition = LegendPosition.TopCenter
            };

            model.Legends.Add(legend);

            plotView.Model = model;
        }
    }


}
