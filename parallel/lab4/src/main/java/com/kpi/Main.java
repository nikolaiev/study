package com.kpi;

import org.apache.hadoop.conf.Configured;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;
import org.apache.hadoop.mapreduce.lib.output.TextOutputFormat;
import org.apache.hadoop.util.Tool;
import org.apache.hadoop.util.ToolRunner;

/**
 * Created by vlad on 18.12.16.
 * Завдання 12 варіант
 *
 * 12. Заповнити квадратну матрицю випадковими числами.
 * Відобразити симетрично відносно вертикальної вісі сектори матриці,
 * які лежать праворуч та ліворуч головної і побічної діагоналей.
 */
public class Main extends Configured implements Tool {

    public static void main(String[] args) throws Exception{
        int exitCode = ToolRunner.run(new Main(), args);
        System.exit(exitCode);
    }

    public int run(String[] args) throws Exception {
        if (args.length != 2) {
            System.err.printf("Usage: %s [generic options] <input> <output>\n",
                    getClass().getSimpleName());
            ToolRunner.printGenericCommandUsage(System.err);
            return -1;
        }

        //creating new Job
        Job job = new org.apache.hadoop.mapreduce.Job();
        job.setJarByClass(Main.class);
        job.setJobName("MatrixHandler");

        //setting input file
        FileInputFormat.addInputPath(job, new Path(args[0]));
        //setting outputfile
        FileOutputFormat.setOutputPath(job, new Path(args[1]));

        job.setOutputKeyClass(Text.class);
        job.setOutputValueClass(Text.class);
        job.setOutputFormatClass(TextOutputFormat.class);

        //setting Mapper
        job.setMapperClass(Mapper.class);
        //setting Combiner
        job.setCombinerClass(Combiner.class);
        //setting Reducer
        job.setReducerClass(Reducer.class);

        //checking if job was successful
        int returnValue = job.waitForCompletion(true) ? 0:1;
        System.out.println("job.isSuccessful " + job.isSuccessful());
        return returnValue;
    }
}
