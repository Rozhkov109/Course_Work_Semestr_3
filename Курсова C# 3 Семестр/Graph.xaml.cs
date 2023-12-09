﻿using System;
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

            foreach (var point in Fx.PointsList)
            { seriesFx.Points.Add(new DataPoint(point.X, calc.Interpolation(Fx, point.X, eps))); }

            foreach (var point in Gx.PointsList)
            { seriesGx.Points.Add(new DataPoint(point.X, calc.Interpolation(Gx, point.X, eps))); }

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
