import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;
import java.awt.geom.Rectangle2D;
import java.awt.image.BufferedImage;
import javax.swing.JFrame;
import javax.swing.JPanel;
//Следующий код строит кривую Коха.
public class Main
{
    private static final int WIDTH = 640;
    private static final int HEIGHT = 480;
    private static BufferedImage image;
    private static Graphics2D graph;

    private static void drawKochCurve(Point2D p, Point2D q, int n) {
        if (n == 0) {
            graph.draw(new Line2D.Double(p, q));
            return;
        }
        Point2D r = new Point2D.Double(
                (2 * p.getX() + q.getX()) / 3,
                (2 * p.getY() + q.getY()) / 3);
        Point2D s = new Point2D.Double(
                (p.getX() + q.getX()) / 2 -
                        (p.getY() - q.getY()) * Math.sqrt(3) / 6,
                ((p.getY() + q.getY()) / 2 +
                        (p.getX() - q.getX()) * Math.sqrt(3) / 6));
        Point2D t = new Point2D.Double(
                (p.getX() + 2 * q.getX()) / 3,
                (p.getY() + 2 * q.getY()) / 3);
        drawKochCurve(p, r, n - 1);
        drawKochCurve(r, s, n - 1);
        drawKochCurve(s, t, n - 1);
        drawKochCurve(t, q, n - 1);
    }

    private static void drawKochSnowflake(Point2D c, double d, int m, int n) {
        Point2D[] vs = new Point2D[m];
        for (int i = 0; i < m; ++i) {
            vs[i] = new Point2D.Double(
                    c.getX() + d * Math.cos(2 * Math.PI / m * i),
                    c.getY() - d * Math.sin(2 * Math.PI / m * i));
        }
        for (int i = 0; i < m; ++i) {
            drawKochCurve(vs[(i + 1) % m], vs[i], n);
        }
    }

    public static void main(String[] args) {
        image = new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
        graph = image.createGraphics();
        graph.setColor(Color.WHITE);
        graph.fill(new Rectangle2D.Double(0, 0, WIDTH, HEIGHT));
        graph.setColor(Color.BLACK);

        drawKochSnowflake(new Point2D.Double(WIDTH / 2, HEIGHT / 2),
                WIDTH / 3, 2, 4);

        JFrame frame = new JFrame();
        frame.addNotify();
        frame.setSize(frame.getInsets().left +
                        frame.getInsets().right + WIDTH,
                frame.getInsets().top +
                        frame.getInsets().bottom + HEIGHT);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        frame.add(new JPanel() {
            @Override
            public void paintComponent(Graphics g) {
                Graphics2D G = (Graphics2D) g;
                if (image != null) {
                    G.drawImage(image, 0, 0, null);
                }
            }
        });
        frame.setVisible(true);
    }
}