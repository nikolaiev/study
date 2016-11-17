import com.sun.org.apache.xpath.internal.SourceTree;

import java.awt.image.BufferedImage;
import java.io.*;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        Alphabet alphabet;
        File file;
        String test="";
        Decoder decoder;
        InputStreamReader inputStreamReader=new InputStreamReader(System.in);
        BufferedReader bufferedReader=new BufferedReader(inputStreamReader);

        try {
            //get encoding
            while(true) {
                System.out.println("Type 1 to use english");
                System.out.println("Type 2 to use russian");

                String res = bufferedReader.readLine();

                if(res.equals("1")){
                    alphabet=Alphabet.English;
                    break;
                }
                else if(res.equals("2")){
                    alphabet=Alphabet.Russian;
                    break;
                }
                System.out.println("Try again");
            }

            System.out.println("Specify SHIFT? (y/n)");

            if(bufferedReader.readLine().equals("y")) {
                System.out.println("Type SHIFT value");

                int shift = Integer.parseInt(bufferedReader.readLine());
                decoder = new Decoder(alphabet, shift);
            }
            else{
                decoder=new Decoder(alphabet);
            }

            while(true) {
                System.out.println("Type file destination");
                String filePath = bufferedReader.readLine();
                file=new File(filePath);
                if(file.exists()){
                    break;
                }
                System.out.println("File does not exist! Try again");
            }
            //bufferedReader.close();
            BufferedReader fileReader=new BufferedReader(new FileReader(file));
            String s;
            while ((s=fileReader.readLine())!=null){
                test+=s;
            }
            fileReader.close();
        }
        catch (IOException e){
            return;
        }
        System.out.println("\nINPUT STRING\n");
        System.out.println(test);

        String encodedStr;
        try {
            encodedStr = decoder.encode(test);
        }
        catch (Exception e){
            System.out.println(e.toString());
            return;
        }
        System.out.println(encodedStr);

        String result=decoder.decode(encodedStr);//розшифрована строка

        System.out.println("\nENCODED STRING WITH KNOWN SHIFT\n");
        System.out.println(result);

        System.out.println("\nENCODED STRING WITH NO SHIFT\n");
        Map<Integer,String> map=decoder.decodeWithNoShift(encodedStr);
        decoder.showMapPretty(map);

        /*System.out.println("Save encoded string to file? (y/n)");
        BufferedReader br=new BufferedReader(new InputStreamReader(System.in));

        try {
            if(br.readLine().equals("y")){
                System.out.println("Type file destination");
                File fileToOutput=new File(br.readLine());

                PrintWriter pw =new PrintWriter(fileToOutput);
                pw.write(encodedStr);
                pw.close();
            }
            br.close();
        }
        catch (IOException e){
            System.out.println(e.toString());
        }*/
    }
}

