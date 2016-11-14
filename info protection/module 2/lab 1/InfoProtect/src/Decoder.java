import java.util.*;

public class Decoder{
    private List<Character> alphabet=new LinkedList<>();
    private int SHIFT;
    private int DIVISOR;

    private Decoder(){}

    public Decoder(Alphabet alph,int...arr) throws IllegalArgumentException{

        if(alph==Alphabet.English){

            for (char i='A';i<='z';i++){
                alphabet.add(i);
            }
        }
        else if(alph==Alphabet.Russian){


            for(char i='А';i<='я';i++){
                alphabet.add(i);
            }
        }
        else{
            throw new IllegalArgumentException();
        }

        alphabet.add(' ');
        alphabet.add('\n');
        alphabet.add('?');
        alphabet.add(',');
        alphabet.add('!');
        for (char i='0';i<='9';i++){
            alphabet.add(i);
        }
        System.out.println(alphabet);

        if(arr.length==2){
            Random rand=new Random();
            int max=alphabet.size()-1;
            int min=1;
            this.SHIFT=Math.abs(arr[0])<alphabet.size()&&arr[0]!=0?Math.abs(arr[0]):rand.nextInt((max - min) + 1) + min;;
            this.DIVISOR=alphabet.size()+1;//(Math.abs(arr[1])<=alphabet.size()+1)&&arr[1]!=0?Math.abs(arr[1]):alphabet.size()+1;
        }
        else{
            Random rand=new Random();
            int max=alphabet.size()-1;
            int min=1;
            this.SHIFT=rand.nextInt((max - min) + 1) + min;
            this.DIVISOR=alphabet.size()+1;
        }
        System.out.println("SHIFT equals "+this.SHIFT);
        System.out.println("DIVISOR equals "+this.DIVISOR);
    }

    public String encode(String str) throws Exception{
        StringBuilder sb= new StringBuilder();
        for(char ch : str.toCharArray()){
            if(alphabet.indexOf(ch)==-1){
                throw new Exception("Incorrect encoding was set!");
            }
            int index=(alphabet.indexOf(ch)+SHIFT)%DIVISOR;
            char chToAppend=alphabet.get(index);
            sb.append(chToAppend);
        }
        return sb.toString();
    }

    public List<List <String>> decode(String str){
        List<List<String>> result=new ArrayList<>();
        for(Character ch :str.toCharArray()){
            List <String> charAtPosition=new ArrayList<>();
            int currentIndex=alphabet.indexOf(ch);

            do{
                int elemIndex= currentIndex-SHIFT;
                while (elemIndex<0){
                    currentIndex+=DIVISOR;
                    elemIndex+=DIVISOR;
                }
                charAtPosition.add(alphabet.get(elemIndex).toString());
                currentIndex+=DIVISOR;

            }while(currentIndex-SHIFT<alphabet.size());

            result.add(charAtPosition);
        }
        return result;
    }

    //helper function
    private void recurFunc(List<List<String>> lst,int offset,String res,List<String> result){
        if(lst.size()==offset){
            result.add(res);
            System.out.println(res);
        }
        else{
            for(int i=0;i<lst.get(offset).size();i++){
                String resCopy=new String(res+lst.get(offset).get(i));
                recurFunc(lst,offset+1,resCopy,result);
            }
        }

    }

    public List<String>  showAllPossibleStrings(List<List<String>> lst){
        List<String> result=new ArrayList<>();
        recurFunc(lst,0,"",result);
        return result;
    }
}
