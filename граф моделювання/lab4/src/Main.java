import com.orsoncharts.Chart3D;
import com.orsoncharts.Chart3DFactory;
import com.orsoncharts.Chart3DPanel;
import com.orsoncharts.data.xyz.XYZDataItem;
import com.orsoncharts.data.xyz.XYZSeries;
import com.orsoncharts.data.xyz.XYZSeriesCollection;

import javax.swing.*;

/**
 * Created by arkadius on 10/1/16.
 */
public class Main /*extends JPanel */{
    //final int PAD = 20;

//    protected void paintComponent(Graphics g) {
//        super.paintComponent(g);
//        Graphics2D g2 = (Graphics2D) g;
//        draw(g2);
//    }
    private static void drawArea(){
        XYZSeries butterfly = new XYZSeries("butterfly");
        XYZSeries butterfly2 = new XYZSeries("1");

        double step =0.5;
        for(double y=-10;y<10;y+=step){
            for (double x=-10;x<10;x+=step){
                butterfly.add(x,y,z(x,y));
            }
        }



        graphic(butterfly);
    }
    private static void draw() {
        XYZSeries butterfly = new XYZSeries("butterfly");
//        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING,
//                RenderingHints.VALUE_ANTIALIAS_ON);
//        int w = getWidth();
//        int h = getHeight();
        // Draw ordinate.

//        g2.setPaint(Color.red);
        double x = -9;
        double step = 0.1;
//        int scale = 10;
        while (x < 9) {
//            double y = 0;
            if (x <= -1) {
                double y = f1(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f1(x), 4, 4));
            }
            if (x >= 1 && x <= 9) {
                double y = f2(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f2(x), 4, 4));
            }
            if (x <= -8) {
                double y = f3(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f3(x), 4, 4));
            }
            if (x >= 8 && x <= 9) {
                double y = f4(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f4(x), 4, 4));
            }
            if (x >= -8 && x <= -1) {
                double y = f5(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f5(x), 4, 4));
            }
            if (x >= 1 && x <= 8) {
                double y = f6(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f6(x), 4, 4));
            }
            if (x >= -8 && x <= -1) {
                double y = f7(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f7(x), 4, 4));
            }
            if (x >= 1 && x <= 8) {
                double y = f8(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f8(x), 4, 4));
            }
            if (x >= -8 && x <= -2) {
                double y = f9(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f9(x), 4, 4));
            }
            if (x >= 2 && x <= 8) {
                double y = f10(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f10(x), 4, 4));
            }
            if (x >= -2 && x <= -1) {
                double y = f11(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f11(x), 4, 4));
            }
            if (x >= 1 && x <= 2) {
                double y = f12(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f12(x), 4, 4));
            }
            if (x >= -1 && x <= 1) {
                double y = f13(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f13(x), 4, 4));
            }
            if (x >= -1 && x <= 1) {
                double y = f14(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f14(x), 4, 4));
            }
            if (x >= -2 && x <= 0) {
                double y = f15(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f15(x), 4, 4));
            }
            if (x >= 0 && x <= 2) {
                double y = f16(x);
                butterfly.add(x, y, z(x, y));
//                g2.fill(new Ellipse2D.Double(w / 2 + scale * x, h / 2 - scale * f16(x), 4, 4));
            }

            x += step;
        }
        graphic(butterfly);
    }

    private static double z(double x, double y) {
        return x * x  - y * y;
    }

    private static double f1(double x) {
        return -1. / 8 * (x + 9) * (x + 9) + 8;
    }

    private static double f2(double x) {
        return -1. / 8 * (x - 9) * (x - 9) + 8;
    }

    private static double f3(double x) {
        return 7 * (x + 8) * (x + 8) + 1;
    }

    private static double f4(double x) {
        return 7 * (x - 8) * (x - 8) + 1;
    }

    private static double f5(double x) {
        return 1. / 49 * (x + 1) * (x + 1);
    }

    private static double f6(double x) {
        return 1. / 49 * (x - 1) * (x - 1);
    }

    private static double f7(double x) {
        return -4. / 49 * (x + 1) * (x + 1);
    }

    private static double f8(double x) {
        return -4. / 49 * (x - 1) * (x - 1);
    }

    private static double f9(double x) {
        return 1. / 3 * (x + 5) * (x + 5) - 7;
    }

    private static double f10(double x) {
        return 1. / 3 * (x - 5) * (x - 5) - 7;
    }

    private static double f11(double x) {
        return -2 * (x + 1) * (x + 1) - 2;
    }

    private static double f12(double x) {
        return -2 * (x - 1) * (x - 1) - 2;
    }

    private static double f13(double x) {
        return -4 * x * x + 2;
    }

    private static double f14(double x) {
        return 4 * x * x - 6;
    }

    private static double f15(double x) {
        return -1.5 * x + 2;
    }

    private static double f16(double x) {
        return 1.5 * x + 2;
    }



    public static void main(String[] args) {
//        JFrame f = new JFrame();
//        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//        f.add(new Main());
//        f.setSize(400, 400);
//        f.setLocation(200, 200);
//        f.setVisible(true);
        draw();
        drawArea();
    }


    static void graphic(XYZSeries series) {
        JFrame frame = new JFrame(); //створюємо каркас вікна
        frame.setTitle("График функции"); //заголовок вікна
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        XYZSeriesCollection data = new XYZSeriesCollection();


        data.add(series);
        final Chart3D chart = Chart3DFactory.createScatterChart(
                "",
                "",
                data,
                "X",
                "Y",
                "Z"
        );
//        XYZPlot plot = (XYZPlot) chart.getPlot();
        final Chart3DPanel chartPanel = new Chart3DPanel(chart);

        frame.setContentPane(chartPanel);
        frame.setSize(1000, 500);
        frame.setVisible(true);
    }
}
