package com.kpi;

import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.Plot;
import org.jzy3d.analysis.AbstractAnalysis;
import org.jzy3d.analysis.AnalysisLauncher;
//import org.jzy3d.chart.Chart;
//import org.jzy3d.chart.Chart;
import org.jzy3d.chart.Chart;
import org.jzy3d.chart.ChartLauncher;
import org.jzy3d.chart.factories.AWTChartComponentFactory;
import org.jzy3d.chart.factories.IChartComponentFactory;
import org.jzy3d.colors.Color;
import org.jzy3d.colors.ColorMapper;
import org.jzy3d.colors.colormaps.ColorMapGrayscale;
import org.jzy3d.colors.colormaps.ColorMapRainbow;
import org.jzy3d.maths.*;
import org.jzy3d.maths.Rectangle;
import org.jzy3d.plot3d.builder.Builder;
import org.jzy3d.plot3d.builder.Mapper;
import org.jzy3d.plot3d.builder.concrete.OrthonormalGrid;
import org.jzy3d.plot3d.primitives.Shape;
import org.jzy3d.plot3d.rendering.canvas.Quality;

import javax.swing.*;
import java.awt.*;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class SurfaceDemo/* extends AbstractAnalysis*/ {
    public static void main(String[] args) throws Exception {
       // AnalysisLauncher.open(new SurfaceDemo());
        // Define a function to plot

        Mapper mapper = new Mapper() {
            @Override
            public double f(double x, double y) {
                return x*x-y*y;//x * Math.sin(x * y);
            }
        };
        Mapper mapper2 = new Mapper() {
            @Override
            public double f(double x, double y) {
                return 3;//x * Math.sin(x * y);
            }
        };

        // Define range and precision for the function to plot
        Range range = new Range(-3, 3);
        int steps = 80;

        // Create the object to represent the function over the given range.
        final Shape surface = Builder.buildOrthonormal(new OrthonormalGrid(range, steps, range, steps), mapper);
        surface.setColorMapper(new ColorMapper(new ColorMapRainbow(), surface.getBounds().getZmin(), surface.getBounds().getZmax(), new Color(1, 1, 1, .5f)));
        surface.setFaceDisplayed(true);
        surface.setWireframeDisplayed(false);

        final Shape surface2 = Builder.buildOrthonormal(new OrthonormalGrid(range, steps, range, steps), mapper2);
        surface2.setColorMapper(new ColorMapper(new ColorMapGrayscale(), surface2.getBounds().getZmin(), surface2.getBounds().getZmax(), new Color(1, 1, 1, .5f)));
        surface2.setFaceDisplayed(true);
        surface2.setWireframeDisplayed(false);

        Chart chart = AWTChartComponentFactory.chart(Quality.Advanced, "newt");

        chart.getScene().getGraph().add(surface);
        chart.getScene().getGraph().add(surface2);
        ChartLauncher.instructions();
        ChartLauncher.openChart(chart, new Rectangle(600,600), "Lab6");

    }
}