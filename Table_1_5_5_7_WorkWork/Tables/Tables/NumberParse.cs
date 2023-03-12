using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class NumberStruct
    {
        public int IntPartMath, IntPartWritten, Order;
        public double IntPartD, FracPart;
        public double Mantissa;
        public bool NumberIsPositive, OrderIsPositive;
        public double value;
        public int CountErr, ErstErrN;
        public NumberStruct()
        {
            IntPartMath = 0; IntPartWritten = 0; Order = 0;
            IntPartD = 0; FracPart = 0;
            Mantissa = 0; 
            NumberIsPositive = true; OrderIsPositive = true;
            value = 0;
            CountErr=0; ErstErrN=0;
        }
    }
    public static class NumberParse
    {
        public static void IntToDigits(int num, int BaseDec, ref int[] digit, ref int order)
        {
            int absx, y, n;
            absx = Math.Abs(num);
            order = 0;
            y = absx;
            digit = null;
            while (y >= BaseDec)
            {
                //
                //order++;
                //
                n = y / BaseDec;//nur int part of such div!
                //
                //digit[order - 1] = y - n * BaseDec;
                //
                MyLib.AddToVector(ref digit,  ref order, y - n * BaseDec);
                y /= BaseDec;
            }
            //
            //order++;
            //digit[order - 1] = y;
            //
            MyLib.AddToVector(ref digit, ref order, y);
            order--; //order is 1 Less than Quantity of digits!
        }//fn
        //
        //
        public static int DigitOf(string s, int BaseDec)
        {
            int n = -1;
            if (s == "0") n = 0;
            if (s == "1") n = 1;
            if (s == "2" && BaseDec > 2) n = 2;
            if (s == "3" && BaseDec > 3) n = 3;
            if (s == "4" && BaseDec > 4) n = 4;
            if (s == "5" && BaseDec > 5) n = 5;
            if (s == "6" && BaseDec > 6) n = 6;
            if (s == "7" && BaseDec > 7) n = 7;
            if (s == "8" && BaseDec > 8) n = 8;
            if (s == "9" && BaseDec > 9) n = 9;
            if ((s == "A" || s == "a") && BaseDec > 10) n = 10;
            if ((s == "B" || s == "b") && BaseDec > 11) n = 11;
            if ((s == "C" || s == "c") && BaseDec > 12) n = 12;
            if ((s == "D" || s == "d") && BaseDec > 13) n = 13;
            if ((s == "E" || s == "e") && BaseDec > 14) n = 14;
            if ((s == "F" || s == "f") && BaseDec > 15) n = 15;
            //if( (s=="G"|| s=="g") && BaseDec>16) n=16;
            //if( (s=="H"|| s=="h") && BaseDec>17) n=17;
            //
            return n;
        }
        public static bool IsComma(string s)
        {
            return (s.Equals(".") || s.Equals(","));
        }
        public static bool IsSign(string s)
        {
            return (s.Equals("+") || s.Equals("-"));
        }
        public static bool IsOrder(string s, int BaseDec)
        {
            bool verdict;
            verdict=false;
            if (BaseDec < 14)
            {
                if(s.Equals("E")||s.Equals("e")) verdict=true;
            }
            else
            {
                if(s.Equals("@")) verdict=true;
            }
            return verdict;
        }
        //
        public static double IntPower(double x, int y){
            double z;//, c;
            z = 0;
            if (x == 0 && y == 0) z = -666;
            else if (x == 0) z = 0;
            else if (y == 0) z = 1;
            else if (y > 0)
            {
                z = 1;
                for (int i = 1; i <= y; i++)
                {
                    z *= x;
                }
            }
            else if (y < 0)
            {
                z = 1;
                //for (int i = 1; i <= y; i++)
                for (int i = 1; i <= -y; i++)
                {
                    z /= x;
                }
            }
            return z;
        }
        public static int /*double*/ IntPower(int x, int y)
        {
            //int z, c;
            //double z;
            int z;
            z = 0;
            if (x == 0 && y == 0) z = -666;
            else if (x == 0) z = 0;
            else if (y == 0) z = 1;
            else if (y > 0)
            {
                z = 1;
                for (int i = 1; i <= y; i++)
                {
                    z *= x;
                }
            }
            else if (y < 0)
            {
                z = 1;
                // for (int i = 1; i <= y; i++)
                for (int i = 1; i <= -y; i++)
                {
                    z /= x;
                }
            }
            return z;
        }
        //
        public static NumberStruct ParseNumber(string str, int BaseDec=10)
        {
            string sc = "", sprev="";
            int Int1Frac2Ord3 = 1, digit=-2, IntPartOrder=0, FracPartOrder=0, /*OrderPartLength=0,*/ Order=0;
            NumberStruct ReS = new NumberStruct();
            int Length = str.Length;
            int OrdMultiplier;
            for (int i = 1; i <= Length; i++)
            {
                sc = str.Substring(i - 1, 1);
                digit=DigitOf(sc,BaseDec);
                if(IsSign(sc)){
                    if (i == 1)
                    {
                        if (sc.Equals("-")) ReS.NumberIsPositive = false;
                        else ReS.NumberIsPositive = true;
                    }else{
                        if (IsOrder(sprev, BaseDec))
                        {
                            if (sc.Equals("-")) ReS.OrderIsPositive = false;
                            else ReS.OrderIsPositive = true;
                        }
                        else
                        {
                            if (ReS.CountErr == 0) ReS.ErstErrN = i;
                            ReS.CountErr++;
                        }
                    }
                }
                if (IsComma(sc))
                {
                    if (Int1Frac2Ord3 == 1) Int1Frac2Ord3 = 2;
                    else
                    {
                        if (ReS.CountErr == 0) ReS.ErstErrN = i;
                        ReS.CountErr++;
                    }
                }
                if(IsOrder(sc,BaseDec)){
                    if (Int1Frac2Ord3 <3) Int1Frac2Ord3 = 3;
                    else
                    {
                        if (ReS.CountErr == 0) ReS.ErstErrN = i;
                        ReS.CountErr++;
                    }
                }
                if (DigitOf(sc, BaseDec) == -1 && IsComma(sc) == false && IsOrder(sc, BaseDec) == false && IsSign(sc)==false)
                {
                    if (ReS.CountErr == 0) ReS.ErstErrN = i;
                    ReS.CountErr++;
                }
                if (digit >= 0)
                {
                    switch (Int1Frac2Ord3)
                    {
                        case 1:
                            ReS.IntPartMath = ReS.IntPartMath * BaseDec + digit;
                            IntPartOrder++;
                            if (ReS.IntPartMath == 0 && digit > 0){
                                ReS.IntPartWritten = digit;
                            }
                            break;
                        case 2:
                            FracPartOrder++;
                            //ReS.FracPart = ReS.FracPart +IntPower((double)digit,-FracPartOrder);
                            //ReS.FracPart = ReS.FracPart + digit * IntPower((double)BaseDec, -FracPartOrder);
                            OrdMultiplier = 1;
                            for (int j = 1; j <= FracPartOrder; j++) OrdMultiplier *= BaseDec;
                            ReS.FracPart = ReS.FracPart + 1.0*digit / OrdMultiplier;
                            break;
                        case 3:
                            Order = Order * BaseDec + digit;
                            break;
                    }
                }
                sprev = sc;
                digit=-2;
                //
                if(ReS.OrderIsPositive){
                    if (ReS.Order == 0) ReS.value=ReS.IntPartMath + ReS.FracPart;
                    else ReS.value=IntPower((ReS.IntPartMath+ReS.FracPart),ReS.Order);
                }else{
                    ReS.value = IntPower((ReS.IntPartMath + ReS.FracPart), -ReS.Order);
                }
                ReS.Mantissa=ReS.value;
                if (ReS.NumberIsPositive == false) ReS.value = -1 * ReS.value;
                //
                ReS.Order = 0;
                while (ReS.Mantissa > BaseDec)
                {
                    ReS.Mantissa /= BaseDec;
                    ReS.Order++;
                }
                while (ReS.Mantissa < 1/BaseDec)
                {
                    ReS.Mantissa *= BaseDec;
                    ReS.Order++;
                }
            }//for
            return ReS;
        }//fn
        public static double ConvertToNumber(string s, int BaseDec=10)
        {
            double R =0;
            NumberStruct str = new NumberStruct();
            str = ParseNumber(s, BaseDec);
            if (str.CountErr == 0) R = str.value;
            return R;
        }
        public static double StrToFloat(string s)
        {
            double R = 0;
            NumberStruct str = new NumberStruct();
            int BaseDec = 10;
            str = ParseNumber(s, BaseDec);
            if (str.CountErr == 0) R = str.value;
            return R;
        }
        public static bool IsNumber(string s, int BaseDec=10)
        {
            NumberStruct str = new NumberStruct();
            str = ParseNumber(s, BaseDec);
            return (str.CountErr == 0);
        }
        public static bool IsDecimalNumber(string s)
        {
            NumberStruct str = new NumberStruct();
            str = ParseNumber(s, 10);
            return (str.CountErr == 0);
        }
        /*public static bool IsCorrectZero(string s, int CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 = 1, string OrderSignForSomeSystems = "", bool CommaFirstAllowed = true, bool CommaLastAllowed = true)
        {
            int QZeros=0, QCommas=0, QSigns=0, QOrders=0, QOther=0;
            int OrderN = 0, SignN = 0, CommaN=0;
            int L = s.Length;
            bool verdict = true;
            string cs;
            for (int i = 1; i <= L; i++)
            {
                cs = s.Substring(i - 1, 1);
                if (cs.Equals("0")) QZeros++;
                else if ((cs.Equals(".") || cs.Equals(",") || cs.Equals("б") || cs.Equals("ю")) && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 0)
                {
                    QCommas++; CommaN = i;
                }
                else if ((cs.Equals(".") || cs.Equals(",")) && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 1)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals(".") && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 2)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals(",") && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 3)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals("E") || cs.Equals("e"))
                {
                    QOrders++; CommaN = i;
                }
                else if (cs.Equals(OrderSignForSomeSystems) && OrderSignForSomeSystems.Equals("") == false)
                {
                    QOrders++; OrderN = i;
                }
                else if (cs.Equals("+") || cs.Equals("-"))
                {
                    QSigns++; SignN = i;
                }
                else QOther++;
            }
            verdict = (QDigits > 0 && QCommas <= 1 && ((QSigns <= 1 && QOrders==0) || (QSigns <= 2 && QOrders == 1))  && QOther == 0 && (SignN == 1 || SignN == OrderN + 1) && CommaN <= OrderN && (CommaFirstAllowed == true || CommaN > 1) && (CommaLastAllowed == true || CommaN < L));
            return verdict;
        }*/
         
        public static int IsCorrectNumber_No0Real1Int2(string s, int CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 = 1, int SysBase = 10, string OrderSignForSomeSystems = "", bool CommaFirstAllowed = true, bool CommaLastAllowed = true)
        {
            int QDigits = 0, QCommas = 0, QSigns = 0, QOrders = 0, QOther = 0;
            int OrderN = 0, SignN = 0, CommaN = 0;
            int L = s.Length;
            int verdict = 0;
            string cs;
            for (int i = 1; i <= L; i++)
            {
                cs = s.Substring(i - 1, 1);
                if (DigitOf(cs, SysBase) > -1) QDigits++;
                else if ((cs.Equals(".") || cs.Equals(",") || cs.Equals("б") || cs.Equals("ю")) && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 0)
                {
                    QCommas++; CommaN = i;
                }
                else if ((cs.Equals(".") || cs.Equals(",")) && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 1)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals(".") && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 2)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals(",") && CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 == 3)
                {
                    QCommas++; CommaN = i;
                }
                else if (cs.Equals("E") || cs.Equals("e"))
                {
                    QOrders++; CommaN = i;
                }
                else if (cs.Equals(OrderSignForSomeSystems) && OrderSignForSomeSystems.Equals("") == false)
                {
                    QOrders++; OrderN = i;
                }
                else if (cs.Equals("+") || cs.Equals("-"))
                {
                    QSigns++; SignN = i;
                }
                else QOther++;
            }
            if (QDigits > 0 && QCommas <= 1 && ((QSigns <= 1 && QOrders == 0) || (QSigns <= 2 && QOrders == 1)) && QOther == 0 && (SignN <= 1 || SignN == OrderN + 1) && (OrderN == 0 || CommaN==0 || CommaN <= OrderN) && (CommaFirstAllowed == true || CommaN > 1) && (CommaLastAllowed == true || CommaN < L))
            {
                verdict = 1;
                if (QCommas == 0) verdict = 2;
            }
            else verdict = 0;
            return verdict;
        }
        public static bool IsCorrectNumber(string s, int CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 = 1, int SysBase = 10, string OrderSignForSomeSystems = "", bool CommaFirstAllowed = true, bool CommaLastAllowed = true)
        {
            int type_of_content = IsCorrectNumber_No0Real1Int2(s, CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3, SysBase, OrderSignForSomeSystems, CommaFirstAllowed, CommaLastAllowed);
            return (type_of_content > 0);
        }   
        public static bool IsCorrectInteger(string s, int SysBase = 10, string OrderSignForSomeSystems = "")
        {
            int type_of_content = IsCorrectNumber_No0Real1Int2(s, 0, SysBase, OrderSignForSomeSystems, true, true);
            return (type_of_content == 2);
        }
        public static bool IsCorrectNumberArray(string[] s, int Q, int CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3 = 1, int SysBase = 10, string OrderSignForSomeSystems = "", bool CommaFirstAllowed = true, bool CommaLastAllowed = true)
        {
            bool verdict = true;
            int type_of_content, QMin, L;
            L=s.Length;
            if(Q<L&&Q>0)QMin=Q; else QMin=L;
            for (int i = 1; i <= QMin; i++)
            {
                type_of_content = IsCorrectNumber_No0Real1Int2(s[i-1], CommaOnlySign_Any4_0_Any2_1_DotOnly_2_CommaOnly_3, SysBase, OrderSignForSomeSystems, CommaFirstAllowed, CommaLastAllowed);
                if (type_of_content < 1) verdict = false;
            }
            return verdict;
        }
        public static bool IsCorrectIntegerArray(string[] s, int Q, int SysBase = 10, string OrderSignForSomeSystems = "")
        {
            bool verdict = true;
            int type_of_content, QMin, L;
            L=s.Length;
            if(Q<L&& Q>0)QMin=Q; else QMin=L;
            for (int i = 1; i <= QMin; i++)
            {
                type_of_content = IsCorrectNumber_No0Real1Int2(s[i-1], 0, SysBase, OrderSignForSomeSystems, true, true);
                if (type_of_content < 2) verdict = false;
            }
            return verdict;
        }
        //
        
    }//cl
}//ns
