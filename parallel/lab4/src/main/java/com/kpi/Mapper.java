package com.kpi;

import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;

import java.io.IOException;

/**
 * Created by vlad on 18.12.16.
 * Mapper class
 * Used as Map in Hadoop map-combine-reduce architecture
 */
class Mapper extends org.apache.hadoop.mapreduce.Mapper<LongWritable, Text, Text, /*IntWritable*/Text> {

    @Override
    protected void map
    (LongWritable key, Text value, Context context)
            throws IOException, InterruptedException {
        //value example is "2   11 12 13 14 15 5 9"
        //create array of tokens from input text
        String[] csv = value.toString().split("[ \\s\\t\\n\\x0B\\f\\r]+");

        //writing data to context (Combiner)
        for (int i = 1; i < csv.length; i++) {
            context.write(/*row of matrix*/new Text(csv[0]), /*concrete element with index*/new Text(csv[i]+","+(i-1)));
        }
    }
}
