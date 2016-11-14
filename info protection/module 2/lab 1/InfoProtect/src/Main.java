import java.awt.image.BufferedImage;
import java.io.*;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

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

            //System.out.println("Specify SHIFT and DEVISIOR? (y/n)");
            System.out.println("Specify KEY(SHIFT)? (y/n)");

            if(bufferedReader.readLine().equals("y")){
                int shift;
                //int divisor;
                while(true) {
                    try {
                        System.out.println("Type SHIFT value");
                        shift = Integer.parseInt(bufferedReader.readLine());
                        break;
                    }
                    catch (Exception e){
                        System.out.println(e.toString());
                        System.out.println("Try again!");
                    }
                }
                /*while(true) {
                    try {
                        System.out.println("Type DIVISIOR value");
                        divisor = Integer.parseInt(bufferedReader.readLine());
                        break;
                    }
                    catch (Exception e){
                        System.out.println(e.toString());
                        System.out.println("Try again!");
                    }
                }*/
                decoder = new Decoder(alphabet,shift,0);
            }
            else {
                decoder = new Decoder(alphabet);
            }
            //get file path
            //file=new File("test.txt");
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
        List<List<String>> decodedStrs=decoder.decode(encodedStr);
        System.out.println("\nENCODED STRING\n");
        System.out.println(decodedStrs);

        System.out.println("Save encoded string to file? (y/n)");
        BufferedReader br=new BufferedReader(new InputStreamReader(System.in));
        try {
            if(br.readLine().equals("y")){
                System.out.println("Type file destination");
                File fileToOutput=new File(br.readLine());

                PrintWriter pw =new PrintWriter(fileToOutput);
                pw.write(encodedStr);
                pw.close();
            }
            //br.close();
        }
        catch (IOException e){
            System.out.println(e.toString());
        }

        System.out.println("\nALL POSSIBLE COMBINATIONS\n");
        List<String>  result=decoder.showAllPossibleStrings(decodedStrs);
        System.out.println("Save all possible combinations string to file? (y/n)");
        try {
            if(br.readLine().equals("y")){
                System.out.println("Type file destination");
                File fileToOutput=new File(br.readLine());

                PrintWriter pw =new PrintWriter(fileToOutput);
                pw.write(result.toString());
                pw.close();
            }
            br.close();
        }
        catch (IOException e){
            System.out.println(e.toString());
        }
    }
}

