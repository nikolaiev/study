import java.util.*;

public class Decoder{
    private List<Character> alphabet=new LinkedList<>();
    private int SHIFT;
    private int DIVISOR;

    /**
     * Якщо ми не вказали зсув при створенні
     * @param alph алфавіт
     */

    public Decoder(Alphabet alph){
        this(alph,new Random().nextInt(100));
    }

    public Decoder(Alphabet alph,int shift) throws IllegalArgumentException{

        if(alph==Alphabet.English){
            alphabet.add(' ');
            alphabet.add('\n');
            alphabet.add('?');
            alphabet.add(',');
            alphabet.add('!');

            for (char i='A';i<='z';i++){
                alphabet.add(i);
            }
        }
        else if(alph==Alphabet.Russian){
            alphabet.add(' ');
            alphabet.add('\n');
            alphabet.add('?');
            alphabet.add(',');
            alphabet.add('!');

            for(char i='А';i<='я';i++){
                alphabet.add(i);
            }
        }
        else{
            throw new IllegalArgumentException();
        }

        this.SHIFT=shift;
        this.DIVISOR=alphabet.size();
        //System.out.println(alphabet);
        //System.out.println(shift);
    }

    /**
     *
     * @param str незакодована строка
     * @return повертає закодовану строку за відомим здвигом
     * @throws Exception якщо зустрічаємо символ не з алфавіту
     */
    public String encode(String str) throws Exception{
        StringBuilder sb= new StringBuilder();
        for(char ch : str.toCharArray()){
            if(alphabet.indexOf(ch)==-1){
                //TODO зробити програму більш гнучкою для невідомих символів, якщо буде бажання
                throw new Exception("Wrong symbol was found!");
            }
            int index=(alphabet.indexOf(ch)+SHIFT)%DIVISOR;
            char chToAppend=alphabet.get(index);
            sb.append(chToAppend);
        }
        return sb.toString();
    }


    /**
     *
     * @param str вхідна строка
     * @return результат
     *
     * Розшифроває строку за відомим здвигом
     */
    public String decode (String str){
        return decode(str,this.SHIFT);
    }

    /**
     *
     * @param str вхідна строка
     * @param shift зсув
     * @return розшифрована строка
     */
    public String decode(String str,int shift){
        StringBuilder sb=new StringBuilder();

        for(Character ch : str.toCharArray()){
            int currentIndex=alphabet.indexOf(ch);
            int elemIndex= (currentIndex-shift)<0?
                    alphabet.size()+(currentIndex-shift)
                    :(currentIndex-shift);

            sb.append(alphabet.get(elemIndex));
        }
        //System.out.println(sb);
        return sb.toString();
    }

    /**
     *
     * @param str закодована строка
     * @return можливі результати розшифровки
     *
     * Припускаємо що алфавіт нам відомий (можна зробити автоматичне визначення)
     * Перебираємо всі можливі здвиги (SHIFT)
     *
     * Використовується при розшифровці строки з невідомим здвигом (SHIFT), при її шифруванні
     */
    public Map<Integer,String> decodeWithNoShift(String str){
        Map<Integer,String> strings=new TreeMap<>();
        for(int shift=0;shift<alphabet.size();shift++){
            String temp=decode(str,shift);
            strings.put(shift,temp);
        }
        return strings;
    }

    public void showMapPretty(Map<Integer, String> map) {
        for(Map.Entry<Integer,String> entry:map.entrySet()){
            System.out.println("With SHIFT = " +entry.getKey());
            System.out.println(entry.getValue());
            System.out.println();
        }
    }
}
