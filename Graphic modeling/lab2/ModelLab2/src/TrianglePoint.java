
import org.jzy3d.maths.Coord3d;

/**
 * Created by Denis on 27.02.2017.
 */

class TrianglePoint{
    double a;
    double b;
    double c;
    int i;
    int j;
    int k;
    double w;
    Coord3d coords;

    public TrianglePoint(int i, int j, int k, Coord3d coords,Double w){
        this.i = i;
        this.j = j;
        this.k = k;
        this.w = w;
        this.coords = coords;
    }

    public void setA(double a){
        this.a = a;
    }

    public void setB(double b){
        this.b = b;
    }

    public void setC(double c){
        this.c = c;
    }
}
