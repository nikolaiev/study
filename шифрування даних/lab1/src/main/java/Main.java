import edu.emory.mathcs.jtransforms.fft.DoubleFFT_1D;
import javafx.application.Application;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.xy.XYSeries;
import org.jfree.data.xy.XYSeriesCollection;
import org.jfree.ui.ApplicationFrame;
import org.jfree.ui.RefineryUtilities;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

/**
 * Created by vlad on 03.10.16.
 */
public class Main {

    final static int SIZE=44100;
    public static void main(String[] args) throws Exception {

        // создание одноканального wave-файла из массива целых чисел
        /*System.out.println("Создание моно-файла...");
        int []samples=new int[100000];
        int x=0;
        for(int i=0; i < samples.length; i++){
            samples[i++] = (int)Math.round((Integer.MAX_VALUE/2)*
                    (Math.sin(2*Math.PI*440*x/44100)));
            x++;
        }

        WaveFile wf = new WaveFile(4, 44100, 1, samples);
        wf.saveFile(new File("testwav1.wav"));
        System.out.println("Продолжительность моно-файла: "+wf.getDurationTime()+ " сек.");

        // Создание стерео-файла
        System.out.println("Создание стерео-файла...");

        wf = new WaveFile(4, 44100, 1, samples);
        wf.saveFile(new File("/home/vlad/test/testwav2.wav"));
        System.out.println("Продолжительность стерео-файла: "+wf.getDurationTime()+ " сек.");*/

       /* // Чтение данных из файла
        System.out.println("Чтение данных из моно-файла:");
        wf = new WaveFile(new File("/home/vlad/test/testwav1.wav"));
        for(int i=0; i<50000; i+=200){
            System.out.println(wf.getSampleInt(i));
        }* /

        /*========TESTING==========*/


        double[] realParts=new double[SIZE];
        double amp[]={0.9999,0.9999,0.99999}; //затухание
        double freq[]={3000,250,400}; //затухание

        for(int i=0; i < realParts.length; i++){
            realParts[i] =
                    (double)Math.round((Integer.MAX_VALUE/2)*Math.pow(amp[0],i)*
                    (Math.sin(2*Math.PI*freq[0]*i/22050)))
                            +
                    (double)Math.round((Integer.MAX_VALUE/2)*Math.pow(amp[1],i)*
                            (Math.sin(2*Math.PI*freq[1]*i/22050)))
                            +
                    (double)Math.round((Integer.MAX_VALUE/2)*Math.pow(amp[2],i)*
                            (Math.sin(2*Math.PI*freq[2]*i/22050)));

            //imageParts[i]=0;
        }

        //creating wav file
        createWav(realParts,"initial");

        /*getting frequencies*/
        DoubleFFT_1D fftDo = new DoubleFFT_1D(realParts.length);
        double[] fft = new double[realParts.length * 2];
        System.arraycopy(realParts, 0, fft, 0, realParts.length);
        fftDo.realForwardFull(fft);

        double frequen[]=new double[SIZE];

        for(int i=0;i<realParts.length;i++){
            frequen[i]=Math.sqrt(fft[2*i]*fft[2*i]+fft[2*i+1]*fft[2*i+1]);
        }

        JFrame initFrame=drawFrame(frequen,realParts,"Initial chart");
        saveJframeAsImage(initFrame,"intitial");


        /*SIMPLE FILTERING*/
        double alpha=0.999;

        double filterData[]=new double[SIZE];
        for(int i=1;i<SIZE;i++){
            filterData[i]=(1-alpha)*realParts[i]
                    +
                    alpha*filterData[i-1];
        }

        /*getting frequencies*/
        DoubleFFT_1D fftDo2 = new DoubleFFT_1D(filterData.length);
        double[] fft2 = new double[filterData.length * 2];
        System.arraycopy(filterData, 0, fft2, 0, filterData.length);
        fftDo2.realForwardFull(fft2);

        double frequenFilt[]=new double[SIZE];

        for(int i=0;i<filterData.length;i++){
            frequenFilt[i]=Math.sqrt(fft2[2*i]*fft2[2*i]+fft2[2*i+1]*fft2[2*i+1]);
        }

        /*DRAWING*/
        JFrame filtFrame=drawFrame(frequenFilt,filterData,"FIltered chart");

        //creating wav file
        createWav(filterData,"filtered");

        saveJframeAsImage(filtFrame,"filtered");

    }

    private static void saveJframeAsImage(JFrame filtFrame, String filtered) {
        Image image=filtFrame.createImage(300,200);
        BufferedImage bi =toBufferedImage(image);

        Container content = filtFrame.getContentPane();
        BufferedImage img = new BufferedImage(content.getWidth(), content.getHeight(), BufferedImage.TYPE_INT_RGB);
        Graphics2D g2d = img.createGraphics();
        content.printAll(g2d);
        g2d.dispose();

        try {
            ImageIO.write(img, "png", new File(filtered+".png"));
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    /**
     * Converts a given Image into a BufferedImage
     *
     * @param img The Image to be converted
     * @return The converted BufferedImage
     */
    public static BufferedImage toBufferedImage(Image img)
    {
        if (img instanceof BufferedImage)
        {
            return (BufferedImage) img;
        }

        // Create a buffered image with transparency
        BufferedImage bimage = new BufferedImage(img.getWidth(null), img.getHeight(null), BufferedImage.TYPE_INT_ARGB);

        // Draw the image on to the buffered image
        Graphics2D bGr = bimage.createGraphics();
        bGr.drawImage(img, 0, 0, null);
        bGr.dispose();

        // Return the buffered image
        return bimage;
    }

    public static JFrame drawFrame(double[]frequenFilt/*frequen*/,double[] filterData/*samples*/,String title/*title*/){
        XYSeriesCollection datasetFiltFreq = new XYSeriesCollection( );
        XYSeriesCollection datasetFiltSampl = new XYSeriesCollection( );

        XYSeries seriesFiltFreq = new XYSeries("Filtered Frequency");
        XYSeries seriesFiltSampl= new XYSeries("Filtered Samples");

        for(int i=0;i<SIZE;i++){
            seriesFiltFreq.add(i*22050/SIZE, frequenFilt[i]);
            seriesFiltSampl.add(i, filterData[i]);
        }

        datasetFiltFreq.addSeries(seriesFiltFreq);
        datasetFiltSampl.addSeries(seriesFiltSampl);

        JFreeChart chartFiltFreq = ChartFactory.createXYLineChart(
                "Frequncy Chart",      // chart title
                "X",                      // x axis label
                "Y",                      // y axis label
                datasetFiltFreq,                  // data
                PlotOrientation.VERTICAL,
                true,                     // include legend
                true,                     // tooltips
                false                     // urls
        );

        JFreeChart chartFiltSampl = ChartFactory.createXYLineChart(
                "Samples Chart",      // chart title
                "X",                      // x axis label
                "Y",                      // y axis label
                datasetFiltSampl,                  // data
                PlotOrientation.VERTICAL,
                true,                     // include legend
                true,                     // tooltips
                false                     // urls
        );

        ChartPanel chartPanelFiltFreq = new ChartPanel( chartFiltFreq );
        chartPanelFiltFreq.setPreferredSize( new java.awt.Dimension( 560 , 367 ) );

        ChartPanel chartPanelFiltSampl = new ChartPanel( chartFiltSampl );
        chartPanelFiltSampl.setPreferredSize( new java.awt.Dimension( 560 , 367 ) );

        JFrame filtFrame = new JFrame(title);

        filtFrame.getContentPane().add(chartPanelFiltFreq,BorderLayout.EAST);
        filtFrame.getContentPane().add(chartPanelFiltSampl,BorderLayout.WEST);
        filtFrame.pack();
        filtFrame.setVisible(true);
        return filtFrame;
    }

    static void createWav(double [] samples,String title) throws Exception {
        int[] intSamples=new int[samples.length];

        for (int i=0;i<samples.length;i++) {
               intSamples[i]=(int)samples[i];
        }

        WaveFile wf = new WaveFile(4, 44100, 1, intSamples);
        wf.saveFile(new File(title+".wav"));
        System.out.println(title);
        System.out.println("Продолжительность стерео-файла: "+wf.getDurationTime()+ " сек.");
    }
}


