using System;
using System.Text;

class Program {
    static void Main()
    {
        Exercise ex = new Exercise();
        ex.Inverse();
        ex.WordCount("铁  拳,,无!敌?俞.大猷");
        ex.Num2Word(new Random().Next(200)-100);
        ex.SimpleSentenceSlice("I have a dream");
        Console.ReadLine();
    }
}