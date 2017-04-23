
import java.awt.*;

import javax.swing.SwingUtilities;
import javax.swing.JComponent;
import javax.swing.JFrame;

import java.awt.Graphics;
public class Main  extends JFrame {

    double step = 0.001;
    private static  int WinH = 800;
    private static int WinW = 1200;
    public static void main(String[] args) {
        // write your code here
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new Main().setVisible(true);
            }
        });
    }
    public void paint(Graphics g) {
        super.paint(g);

        double[] x ={200,300,400,500,900};
        double[] y ={100,300,400,300,100};
        double[] x1 ={x[2],500,800};

        double[] y1 ={y[2],450,400};

        for(int i=0;i<x.length;i++){
            g.setColor(Color.RED);
            g.fillOval((int)x[i],WinH-(int)y[i],4,4);
        }
        for(int j=0;j<3;j++) {
            g.setColor(Color.BLUE);
            g.drawOval((int) x1[j], WinH - (int) y1[j], 2, 2);
        }
        double sX = graf(x,0);
        double sY = graf(y,0);
        double sX1 = graf2(x,0);
        double sY1 = graf2(y,0);
        double step1 = 0.1;



        for (double j = step1;j<=1+step1/10;j=j+step1)
        {
            g.setColor(Color.BLACK);
            g.drawLine((int)x[0], WinH - (int)y[0],(int) x[2],WinH - (int) y[2]);
            g.drawLine((int)x[4], WinH - (int)y[4],(int) x[2],WinH - (int) y[2]);
            g.setColor(Color.GREEN);
            g.drawLine((int) (x[2]), WinH - (int) (y[2]), (int) (graf(x1, j)), WinH - (int) (graf(y1, j)));
            for (double i = step;i<1+step/10;i=i+step) {
                g.setColor(Color.BLACK);
                g.drawLine((int) (sX), WinH - (int) (sY), (int) (graf(x, i)), WinH - (int) (graf(y, i)));
                sX = graf(x, i);
                sY = graf(y, i);
            }



            x[2] = graf(x1, j);
            y[2] = graf(y1, j);

            g.setColor(Color.BLACK);
            g.drawLine((int)x[0], WinH - (int)y[0],(int) x[2],WinH - (int) y[2]);
            g.drawLine((int)x[4], WinH - (int)y[4],(int) x[2],WinH - (int) y[2]);
        }

        g.drawLine((int)x[0], WinH - 400,(int) x[0],WinH - (int)y[0]);
    }




    Main(){
        super("Bezie");
        setSize(WinW, WinH);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
    }
    private double graf(double[] x,double t){
        int n= x.length-1;
        double B =  0;
        for (int i=0;i<=n;i++){
            B+=x[i]*(fact(n)/(fact(i)*(fact(n-i) )))*Math.pow(t,i)*Math.pow((1-t),n-i);
        }
        return B;
    }
    private double graf2(double[] x,double t){
        return x[0]*4*Math.pow(t,3)+
                x[1]*t*t*(12-16*t)+
                x[2]*t*(24*t*t-36*t+12)+
                x[3]*Math.pow(1-t,2)*(4-16*t)-
                x[4]*Math.pow(1-t,3);
    }
    private double fact(double f){
        if(f<=1)
            return 1;
        return f*fact(f-1);
    }
}