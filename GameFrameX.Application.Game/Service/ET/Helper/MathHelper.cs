using System;

namespace ET
{
    public static class MathHelper
    {
        public static float RadToDeg(float radians)
        {
            return (float)(radians * 180 / Math.PI);
        }
        
        public static float DegToRad(float degrees)
        {
            return (float)(degrees * Math.PI / 180);
        }
        /// <summary>
        /// 注意,该方法0.5会被舍弃，0.51会被进位
        /// </summary>
        /// <param name="fNum"></param>
        /// <returns></returns>
        public static int Round(float fNum)
        {
            return (int)(Math.Round(fNum));
        }
        
        public static float Round(float fNum,int i)
        {
            return (float)Math.Round(fNum,i);
        }
        
        //除法，入参为2个int,返回值为float,不需要四舍五入
        public static float Div(int a, int b)
        {
            return Div((float)a,(float)b);
        }
        //除法，入参为2个float,返回值为float,不需要四舍五入
        public static float Div(float a, float b)
        {
            return a / b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Divide1KAndRoundi(int value, int i)
        {
            //除于1000后，保留i位小数
            return (float)Math.Round(Decimal.Divide(value, 1000), i);
        }
        public static float DivideAndRoundi(float a, float b,int i)
        {
            //除于1000后，保留i位小数
            return (float)Math.Round(Decimal.Divide(new Decimal(a), new Decimal(b)), i);
        }
        /// <summary>
        /// 五舍六入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Divide1K(int value)
        {
            //除于1000后
            return (int)Math.Round(Decimal.Divide(value, 1000));
        }
        public static int Divide1K(long value)
        {
            //除于1000后
            return (int)Math.Round(Decimal.Divide(value, 1000));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Mutiply1K(int value)
        {
            //乘以1000，可能溢出，这里不存在，不处理
            return value * 1000;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Mutiply1K(float value)
        {
            //乘以1000，可能溢出，待处理
            return (int)(value * 1000);
        }
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="fNum"></param>
        /// <returns></returns>
        public static int Round4Down5Up(float fNum)
        {
            return (int)(Math.Round(fNum,MidpointRounding.AwayFromZero));
        }
        
        /// <summary>
        /// 近似等于
        /// </summary>
        /// <param name="fNum"></param>
        /// <param name="iNum"></param>
        /// <returns></returns>
        public static bool CloseToEqual(float fNum, float iNum)
        {
            return Math.Abs(fNum - iNum) < 0.001f;
        }

#pragma warning disable ET0015
        private static readonly int[] IDS = new int[] { 
            1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657,
            46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986,
            102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903};
#pragma warning restore ET0015

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int FibonacciSequence(int num)
        {
            if (num < IDS.Length - 1)
            {
                return IDS[num - 1];
            }
            return int.MaxValue;
            /*if (num == 0)
            {
                return 1;
            }
            if (num == -1)
            {
                return 0;
            }
            return FibonacciSequence(num - 1) + FibonacciSequence(num - 2);*/
        }

        public static int Min(int a, int b)
        {
            return a > b? b : a;
        }
        public static int Max(int a, int b)
        {
            return a > b? a : b;
        }
    }
}