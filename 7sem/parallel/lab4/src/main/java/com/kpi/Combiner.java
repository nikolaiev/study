package com.kpi;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;

import java.io.IOException;
import java.util.*;

/**
 * Created by vlad on 18.12.16.
 * Combiner class
 * Used as Combiner in Hadoop map-combine-reduce architecture
 */
class Combiner extends org.apache.hadoop.mapreduce.Reducer<Text, Text, Text, Text> {

    @Override
    protected void reduce
            (Text rowNumberText, Iterable<Text> values, Context context)
            throws IOException, InterruptedException {
        //collection to store [columnNumber,matrixElement] pairs
        //TreeMap - to sort elements by key (position in row)
        TreeMap<Integer, String> map=new TreeMap<Integer, String>();
        Iterator<Text> iterator=values.iterator();
        Integer rowNumber=Integer.parseInt(rowNumberText.toString());//row number in matrix

        while(iterator.hasNext()){
            //elements example 4,5
            //4 - matrix element
            //5 - column number

            String rowVals=iterator.next().toString();
            String[] vals=rowVals.split(",");
            //matrix element
            String val=vals[0];
            //column number
            Integer col=Integer.parseInt(vals[1]);
            //adding to collection
            map.put(col,val);
        }

        // matrix is square (height=width)
        //getting matrix size
        int matrSize=map.size();

        //collection to handle elements order
        ArrayList<String> arrayList=new ArrayList<String>(map.values());

        /*Виконується завдання з перестановки елементів
        * Суть завдання описана в коментарях до класу Main*/

        //replacing elements if necessary
        if(rowNumber<=matrSize/2){
            for(int i=rowNumber;i<matrSize/2;i++){
                Collections.swap(arrayList,i,arrayList.size()-i-1);
            }
        }

        StringBuilder res=new StringBuilder("");//to build result string

        //building result matrix row
        for(String val : arrayList){
            res.append(val);
            res.append(" ");
        }
        //writing matrix row to context (Reducer)
        context.write(rowNumberText, new Text(res.toString()));
    }


}
