
import org.jzy3d.chart.Chart;
import org.jzy3d.chart.ChartLauncher;
import org.jzy3d.colors.Color;
import org.jzy3d.colors.ColorMapper;
import org.jzy3d.colors.colormaps.*;
import org.jzy3d.maths.Coord3d;
import org.jzy3d.plot3d.primitives.MultiColorScatter;
import org.jzy3d.plot3d.primitives.Scatter;
import org.jzy3d.plot3d.rendering.canvas.Quality;

import java.awt.*;
import java.util.ArrayList;

/**
 * Created by Denis on 18.09.2016.
 */
public class ModelLab2 {

    public static double step = 0.005;
    public static int n = 4;
    public static int m = 5;

    static int counter = 0;

    public static void main(String[] args) {


        ArrayList<TrianglePoint> triagPoints = new ArrayList<TrianglePoint>();

        triagPoints.add(new TrianglePoint(0,0,4,new Coord3d(6,6,1),1.0));

        triagPoints.add(new TrianglePoint(1,0,3,new Coord3d(5,5,1),2.3));
        triagPoints.add(new TrianglePoint(0,1,3,new Coord3d(5,6,1),2.3));

        triagPoints.add(new TrianglePoint(2,0,2,new Coord3d(4,4,-500),3.0));
        triagPoints.add(new TrianglePoint(1,1,2,new Coord3d(4,5,1),5.0));
        triagPoints.add(new TrianglePoint(0,2,2,new Coord3d(4,6,-300),1.0));

        triagPoints.add(new TrianglePoint(3,0,1,new Coord3d(3,3,1),1.0));//
        triagPoints.add(new TrianglePoint(2,1,1,new Coord3d(3,4,400),1.0));//
        triagPoints.add(new TrianglePoint(1,2,1,new Coord3d(3,5,500),1.0));
        triagPoints.add(new TrianglePoint(0,3,1,new Coord3d(3,6,1),1.0));

        triagPoints.add(new TrianglePoint(4,0,0,new Coord3d(2,2,1),1.0));
        triagPoints.add(new TrianglePoint(3,1,0,new Coord3d(2,3,1),1.0));
        triagPoints.add(new TrianglePoint(2,2,0,new Coord3d(2,4,500),1.0));//
        triagPoints.add(new TrianglePoint(1,3,0,new Coord3d(2,5,1),1.0));
        triagPoints.add(new TrianglePoint(0,4,0,new Coord3d(2,6,1),10.0));


        calcBarizentrCoords(triagPoints, squareTriangle(triagPoints));

        Chart chart = new Chart(Quality.Advanced);
        ArrayList<Coord3d> p = drawBazieTriangleSurface(triagPoints);

        Coord3d[] poi = new Coord3d[p.size()];
        for(int i =0; i<p.size(); i++){
            //	System.out.println(p.get(i).x+ "  " +p.get(i).y + " " + p.get(i).z);
            poi[i] = new Coord3d(p.get(i).x, p.get(i).y, p.get(i).z);
        }
        Coord3d[] poi2 = new Coord3d[triagPoints.size()];
        for(int i =0; i<triagPoints.size(); i++){
            poi2[i] = new Coord3d(triagPoints.get(i).coords.x, triagPoints.get(i).coords.y,triagPoints.get(i).coords.z);
        }

        MultiColorScatter scatter = new MultiColorScatter(poi, new ColorMapper( new ColorMapHotCold(), -1f, 100000f ) );
        scatter.setWidth(2f);
        MultiColorScatter scatter2 = new MultiColorScatter(poi2, new ColorMapper( new ColorMapWhiteRed(), -1f, 101100f ) );
        scatter2.setWidth(5f);


        chart.getScene().add(scatter);
        chart.getScene().add(scatter2);
        ChartLauncher.instructions();
        ChartLauncher.openChart(chart, new Rectangle(0,0,700,800), "Lab1");
    }
/*
    private static double graf(double u,double v, int[][] x) {

    }
*/
    public static TrianglePoint getTrianglePoint(int i, int j, int k, ArrayList<TrianglePoint> points){
        for(TrianglePoint point : points){
            if(point.i == i && point.j == j && point.k == k){
                return point;
            }
        }
        return null;
    }
    public static double bezierForTriangleSurface(ArrayList<TrianglePoint> points, int mode, double a, double b, double c){
        double sum = 0;
        double add_sum=0;
        for(int i = 0; i <= n; i++){
            double sum2 = 0;
            for(int j = 0; j <= n; j++){
                double sum3 = 0;
                for(int k = 0; k <= n; k++){
                    if(i + j + k == n){
                        TrianglePoint p = getTrianglePoint(i,j,k, points);
                        double m = (fact(n)/(fact(i) * fact(j) * fact(k))) * Math.pow(a, i) * Math.pow(b, j) * Math.pow(c,k);
                        m*=p.w;
                        sum3 += m;
                    }
                }
                sum2 += sum3;
            }
            add_sum += sum2;
        }
        for(int i = 0; i <= n; i++){
            double sum2 = 0;
            for(int j = 0; j <= n; j++){
                double sum3 = 0;
                for(int k = 0; k <= n; k++){
                    if(i + j + k == n){
                        TrianglePoint p = getTrianglePoint(i,j,k, points);
                        double m = (fact(n)/(fact(i) * fact(j) * fact(k))) * Math.pow(a, i) * Math.pow(b, j) * Math.pow(c,k);
                        if(mode == 0){
                            m *= p.coords.x;
                        }else if(mode == 1){
                            m *= p.coords.y;
                        }else{
                            m *= p.coords.z;
                        }
                        m*=p.w;
                        sum3 += m;
                    }
                }
                sum2 += sum3;
            }
            sum += sum2;
        }
        return sum/add_sum;
    }

    public static ArrayList<Coord3d> drawBazieTriangleSurface(ArrayList<TrianglePoint> points){
        double sX = 0;
        double sY = 0;
        double sZ = 0;
        ArrayList<Coord3d> arr = new ArrayList<Coord3d>();
        for (double a = 0;a <= 1;a = a + step){
            for(double b = 0; b <= 1; b = b + step){
                for(double c = 0; c <= 1; c = c + step){
                    if(a + b + c - 1 >= 0 && a + b + c - 1 <= 0.00001){
                        sX = bezierForTriangleSurface(points, 0, a, b, c);
                        sY = bezierForTriangleSurface(points, 1, a, b, c);
                        sZ = bezierForTriangleSurface(points, 2, a, b, c);
                        arr.add(new Coord3d(sX,sY,sZ));
                    }
                }
            }

        }
        return arr;
    }



    //get points
    public static ArrayList<TrianglePoint> getVertexPoints(ArrayList<TrianglePoint> points){
        ArrayList<TrianglePoint> vertex = new ArrayList<TrianglePoint>();
        for(TrianglePoint point : points){
            if(point.i == n || point.j == n || point.k == n){
                vertex.add(point);
            }
        }
        return vertex;
    }
    //calc area of triangle
    public static double squareTriangle(ArrayList<TrianglePoint> points){
        ArrayList<TrianglePoint> vertex = getVertexPoints(points);
        Coord3d first = vertex.get(0).coords;
        Coord3d second = vertex.get(1).coords;
        Coord3d third = vertex.get(2).coords;
        return ((first.x - third.x) * (second.y - third.y) - (second.x - third.x)*(first.y - third.y))/2;
    }

    public static double fact(int num){
        if(num == 0.0){
            return 1.0;
        }
        return num * fact(num - 1);
    }


    public static void calcBarizentrCoords(ArrayList<TrianglePoint> points, double square){
        ArrayList<TrianglePoint> vertex = getVertexPoints(points);
        Coord3d first = vertex.get(0).coords;
        Coord3d second = vertex.get(1).coords;
        Coord3d third = vertex.get(2).coords;

        for(TrianglePoint p : points){
            double a = (1/(2*square))*(p.coords.x * second.y + second.x * third.y + third.x * p.coords.y - third.x * second.y -second.x * p.coords.y - p.coords.x * third.y);
            double b = (1/(2*square))*(first.x * p.coords.y + p.coords.x * third.y + third.x * first.y - third.x * p.coords.y - p.coords.x * first.y - first.x * third.y);
            double c = (1/(2*square))*(first.x * second.y + second.x * p.coords.y + p.coords.x * first.y - p.coords.x * second.y - second.x * first.y - p.coords.y * first.x);
            p.setA(a);
            p.setB(b);
            p.setC(c);
        }
    }



}






