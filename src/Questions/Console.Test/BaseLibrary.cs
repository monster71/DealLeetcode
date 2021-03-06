﻿using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 2:56:35 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class BaseLibrary
    {
        static CodeTimer CodeTimer { get; }
        static BaseLibrary()
        {
            CodeTimer = new CodeTimer();
            CodeTimer.Initialize();
        }

        internal static void CommonTest(object[] ps, Func<int[][], int> try3)
        {
            throw new NotImplementedException();
        }

        internal static void CommonTest((object, int, int)[] ps, Func<object, int> p, Func<(int[][], int, int)> generateArg, bool showArg)
        {
            throw new NotImplementedException();
        }

        public static Exception bugException = new Exception("bug");

        public static void CommonTest<TArg, TRes>(TArg[] argArr, Func<TArg, TRes> func, Func<TArg> generateArg = null, int codeTimeCount = 10, bool showArg = true, Func<TRes, bool> isShowInfo = null, bool showRes = true, Func<TArg, string> formatArg = null, Func<TArg, TRes> checkFunc = null, bool throwDiff = true, Func<TRes, bool> skipFunc = null, Func<TRes, TRes, bool> equalsFunc = null)
        {
            foreach (var arg in argArr)
            {
                TRes real = checkFunc == null ? default : checkFunc(arg), res = func(arg);
                if (checkFunc != null)
                {
                    if (!(equalsFunc != null ? equalsFunc(real, res) : res.Equals(real)))
                    {
                        ShowTools.ShowMulti(new Dictionary<string, object>() {
                            {nameof(arg),arg },
                            {nameof(res),res },
                            {nameof(real),real }
                        });
                        continue;
                    }
                }
                ShowTools.Show(res);
            }

            Console.WriteLine("是否运行测速?n-否");

            string input = Console.ReadLine();

            if (input.Contains("n")) return;

            if (generateArg == null)
            {
                Console.WriteLine($"{nameof(generateArg)}未定义！");
                return;
            }

            long maxTimeElapsed = 0;
            TArg maxArg = default;
            for (int i = 0; i < codeTimeCount; i++)
            {

                TArg arg = generateArg();
                TRes res = default, real = default;

                CodeTimerResult codeTimerResult = CodeTimer.Time(1, () => { res = func(arg); });

                if (skipFunc != null && skipFunc(res))
                {
                    i--;
                    continue;
                }

                Dictionary<string, object> mul = new Dictionary<string, object>() {
                            //{nameof(codeTimerResult),codeTimerResult },
                        };
                if (showArg)
                {
                    if (formatArg == null)
                        mul[nameof(arg)] = arg;
                    else
                        mul[nameof(arg)] = formatArg(arg);
                }
                if (showRes) mul[nameof(res)] = res;

                mul[nameof(codeTimerResult)] = codeTimerResult;

                if (checkFunc != null)
                {
                    CodeTimerResult checkCodeTimerResult = CodeTimer.Time(1, () => { real = checkFunc(arg); });
                    mul[nameof(checkCodeTimerResult)] = checkCodeTimerResult;
                }

                if (isShowInfo == null || isShowInfo(res))
                    ShowTools.ShowMulti(mul);

                if (checkFunc != null)
                {

                    if (!(equalsFunc != null ? equalsFunc(real, res) : res.Equals(real)))
                    {
                        mul[nameof(real)] = real;
                        ShowTools.ShowMulti(mul);
                        if (throwDiff)
                            throw bugException;
                    }
                }

                if (codeTimerResult.TimeElapsed > maxTimeElapsed)
                {
                    maxTimeElapsed = codeTimerResult.TimeElapsed;
                    maxArg = arg;
                }

                maxTimeElapsed = Math.Max(maxTimeElapsed, codeTimerResult.TimeElapsed);

            }

            Dictionary<string, object> dictionary = new Dictionary<string, object> {
                {"单次耗时最长",maxTimeElapsed },
            };
            if (showArg)
            {
                dictionary["参数"] = formatArg != null ? formatArg(maxArg) as object : maxArg;
            }
            ShowTools.ShowMulti(dictionary);


        }

        public static void CommonWithCheckTest<TArg, TRes>(TArg[] argArr, Func<TArg, TRes> func, Func<TArg, TRes> checkFunc, Func<TArg> generateArg = null, int codeTimeCount = 10, bool showArg = true, bool showRes = true)
        {
            CommonTest(argArr, func, generateArg, codeTimeCount, showArg, null, showRes, null, checkFunc);

            foreach (var arg in argArr)
            {
                TRes real = checkFunc(arg), res = func(arg);
                if (res.Equals(real))
                    Console.WriteLine(res);
                else
                {
                    ShowTools.ShowMulti(new Dictionary<string, object>() {
                            {nameof(res),res },
                            {nameof(real),real }
                    });
                }
            }

            Console.WriteLine("是否运行测速?n-否");

            string input = Console.ReadLine();

            if (input.Contains("n")) return;

            if (generateArg == null)
            {
                Console.WriteLine($"{nameof(generateArg)}未定义！");
                return;
            }

            for (int i = 0; i < codeTimeCount; i++)
            {

                TArg arg = generateArg();
                TRes res = default, real = default;

                CodeTimerResult codeTimerResult = CodeTimer.Time(1, () => { res = func(arg); });
                CodeTimerResult checkCodeTimerResult = CodeTimer.Time(1, () => { real = checkFunc(arg); });

                Dictionary<string, object> mul = new Dictionary<string, object>() {
                            {nameof(codeTimerResult),codeTimerResult },
                            {nameof(checkCodeTimerResult),checkCodeTimerResult },
                        };
                if (showRes) mul[nameof(res)] = res;
                if (showArg) mul[nameof(arg)] = arg;
                ShowTools.ShowMulti(mul);

                if (!res.Equals(real))
                {
                    mul[nameof(arg)] = arg;
                    ShowTools.ShowMulti(mul);
                    throw bugException;
                }

            }
        }

    }
}
