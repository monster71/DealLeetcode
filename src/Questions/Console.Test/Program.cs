﻿using Command.CommonStruct;
using Command.CusStruct;
using Command.Helper;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Challenge;
using ConsoleTest.TestDemo.Challenge._2021.February.Week1;
using ConsoleTest.TestDemo.Hard;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.December.Week1;
using Questions.DailyChallenge._2020.December.Week2;
using Questions.DailyChallenge._2020.December.Week3;
using Questions.DailyChallenge._2020.December.Week4;
using Questions.DailyChallenge._2020.December.Week5;
using Questions.DailyChallenge._2020.November.Week1;
using Questions.DailyChallenge._2020.November.Week2;
using Questions.DailyChallenge._2020.November.Week3;
using Questions.DailyChallenge._2020.November.Week4;
using Questions.DailyChallenge._2020.November.Week5;
using Questions.DailyChallenge._2020.October.Week2;
using Questions.DailyChallenge._2020.October.Week4;
using Questions.DailyChallenge._2020.October.Week5;
using Questions.DailyChallenge._2021.February.Week1;
using Questions.DailyChallenge._2021.January;
using Questions.DailyChallenge._2021.January.Week2;
using Questions.DailyChallenge._2021.January.Week3;
using Questions.DailyChallenge._2021.January.Week4;
using Questions.DailyChallenge._2021.January.Week5;
using Questions.Easy.Algorithms;
using Questions.Hard.Deal;
using Questions.Hard.Deal2;
using Questions.Middle.Deal;
using Questions.Series.AlgorithmThinking;
using Questions.Series.Common_Think;
using Questions.Series.Common_Think.BinarySearch;
using Questions.Series.Dp;
using Questions.Series.Dp.Stone_Game;
using Questions.Series.Dp.动态规划之正则表达;
using Questions.Series.Dp.贪心算法之区间调度问题;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Command.Extension;
using Questions.DailyChallenge._2021.February.Week4;
using Questions.DailyChallenge._2021.March.Week1;
using Questions.DailyChallenge._2021.March.Week2;
using Questions.DailyChallenge._2021.March.Week3;
using Questions.Hard.Deal3;
using Questions.DailyChallenge._2021.March.Week4;
using Questions.DailyChallenge._2021.March.Week5;
using ConsoleTest.TestDemo.Challenge._2021.January;
using Questions.Series.CountDistinctSubSequences;
using Questions.DailyChallenge._2021.April.Week1;
using Questions.DailyChallenge._2021.April.Week2;
using Questions.DailyChallenge._2021.April.Week3;
using Questions.DailyChallenge._2021.April.Week4;
using ConsoleTest.TestDemo.Challenge._2021.April;
using Questions.DailyChallenge._2021.April.Week5;
using Questions.DailyChallenge._2021.May.Week2;
using Questions.DailyChallenge._2021.May.Week1;
using Questions.DailyChallenge._2021.May.Week3;
using Questions.DailyChallenge._2021.May.Week4;
using Questions.DailyChallenge._2021.May.Week5;
using Questions.DailyChallenge._2021.June.Week1;
using Questions.DailyChallenge._2021.June.Week2;
using Questions.DailyChallenge._2021.June.Week3;
using ConsoleTest.TestDemo.Hard.Two;
using Questions.DailyChallenge._2021.June.Week4;

namespace ConsoleTest
{

    [Obsolete]
    class Program
    {

        #region base node

        // 子序列： 不连续
        // 子串: 连续
        //例如：
        //    123456789：
        //        (137)-子序列
        //        (123)-子串
        #endregion

        static void Main(string[] args)
        {
            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            Exception bugEx = new Exception("bug");
            bool runSimple = true;
            runSimple = false;

            {
                Out_of_Boundary_Paths instance = new Out_of_Boundary_Paths();

                BaseLibrary.CommonTest(new[] {
                    (2,2,2,0,0),//6
                    (1,3,3,0,1),//12
                }
                , arg => instance.FindPaths(arg.Item1, arg.Item2, arg.Item3, arg.Item4, arg.Item5)
                , () =>
                {
                    //int m = 50, n = 50;
                    int m = random.Next(50)+1, n = random.Next(50) + 1;

                    return (m, n, 50, random.Next(m), random.Next(n));
                }
                );

            }

            { if (runSimple) { } else { } }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}