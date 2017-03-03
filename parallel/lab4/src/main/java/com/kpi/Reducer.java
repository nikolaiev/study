package com.kpi;

import org.apache.hadoop.io.Text;

import java.io.IOException;
import java.util.Iterator;

/**
 * Created by vlad on 18.12.16.
 * Reducer class
 * Used as Reducer in Hadoop map-combine-reduce architecture
 */
class Reducer extends org.apache.hadoop.mapreduce.Reducer<Text, Text, Text, Text> {


    @Override
    protected void reduce
            (Text rowNumber, Iterable<Text> values, Context context)
            throws IOException, InterruptedException {

        for(Text val :values){
            //writing matrix row to output file
            context.write(rowNumber, val/*rows element*/);
        }
    }
}
