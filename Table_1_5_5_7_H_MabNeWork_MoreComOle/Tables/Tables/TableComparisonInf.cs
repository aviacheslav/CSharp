using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public static class TablesComparison //cl 2
    {
        public static int CompareCellsByValues(TDataCell C1, TDataCell C2)
        {
            int Result_E1L2G3;
            Result_E1L2G3 = 1;
            //
            double d1, d2;
            int n1, n2, type1, type2, L1, L2, count;
            bool contin;
            string s1, s2;
            type1 = C1.GetTypeN();
            type2 = C2.GetTypeN();
            switch (type1)
            {
                case 1:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 10:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;

                        default:

                            break;
                    }
                    break;
                case 2:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 20:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 30:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 4:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 40:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 5:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        case 50:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 5;
                case 50:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        case 50:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 50;
                default:

                    break;
            }//switch   type1
            return Result_E1L2G3;
        }//fn CompareCells  
        public static bool ET_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE_byVal(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        public static int CompareCellsFull(TDataCell C1, TDataCell C2)
        {
            int Result_InCb0E1L2G3;
            Result_InCb0E1L2G3 = 0;
            //
            double d1, d2;
            int n1, n2, type1, type2, L1, L2, count, LMin;
            bool contin;
            string s1, s2;
            type1 = C1.GetTypeN();
            type2 = C2.GetTypeN();
            L1 = C1.GetLength();
            L2 = C2.GetLength();
            if (L1 <= L2) LMin = L1; else LMin = L2;
            switch (type1)
            {
                case 1:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_InCb0E1L2G3 = 3;
                            else if (d1 < d2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 10:
                            //d1 = C1.GetDoubleVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 10:
                    switch (type2)
                    {
                        case 1:
                            //d1 = C1.GetDoubleVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                d1 = C1.GetDoubleValN(count);
                                d2 = C2.GetDoubleValN(count);
                                if (d1 > d2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (d1 < d2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;

                        default:

                            break;
                    }
                    break;
                case 2:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_InCb0E1L2G3 = 3;
                            else if (d1 < d2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 20:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 20:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                d1 = (double)C1.GetFloatValN(count);
                                d2 = (double)C2.GetFloatValN(count);
                                if (d1 > d2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (d1 < d2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            //
                            break;
                        case 3:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_InCb0E1L2G3 = 3;
                            else if (n1 < n2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 30:
                            //n1 = C1.GetIntVal();
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 30:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = C1.GetIntVal();
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                n1 = C1.GetIntValN(count);
                                n2 = C2.GetIntValN(count);
                                if (n1 > n2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (n1 < n2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 4:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 4:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_InCb0E1L2G3 = 3;
                            else if (n1 < n2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 40:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 40:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                n1 = MyLib.BoolToInt(C1.GetBoolVal());
                                n2 = MyLib.BoolToInt(C2.GetBoolVal());
                                if (n1 > n2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (n1 < n2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 5:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 5:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_InCb0E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            //Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //s1 = C1.ToString();
                            //s2 = C2.ToString();
                            //Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 5;
                case 50:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //s1 = C1.ToString();
                            //s2 = C2.ToString();
                            //Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                s1 = C1.ToStringN(count);
                                s2 = C2.ToStringN(count);
                                Result_InCb0E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                                if (Result_InCb0E1L2G3 == 3)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (Result_InCb0E1L2G3 == 2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 50;
                default:

                    break;
            }//switch   type1
            return Result_InCb0E1L2G3;
        }//fn CompareCells  
        public static bool ET_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE_Fully(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        public static bool TablesAreCompatibleVertically(TTable T1, TTable T2, int ContentType, int HdrsTypes, int HdrsNames)
        {
            bool verdict, condRowsQuantity, condContentType, condHdrsTypes, condHdrsNames;
            verdict = false;
            int QColumns1, QLines1, QColumns2, QLines2;
            int CountTypesIncompatible, CountHeaderTypesIncompatible, CountNamesIncompatible;
            int[] Types1 = null, Types2 = null, HdrTps1 = null, HdrTps2 = null;
            string[] names1 = null, names2 = null;
            QColumns1 = T1.GetQColumns(); QLines1 = T1.GetQLines(); QColumns2 = T2.GetQColumns(); QLines2 = T2.GetQLines();
            verdict = false;
            //
            condRowsQuantity = (QColumns1 == QColumns2);
            //
            if (ContentType == 1)
            {
                Types1 = new int[QLines1];
                Types2 = new int[QLines2];
                for (int i = 1; i <= QLines1; i++) Types1[i - 1] = T1.ContentLineHasSameTypeN(i);
                for (int i = 1; i <= QLines2; i++) Types2[i - 1] = T2.ContentLineHasSameTypeN(i);
                CountTypesIncompatible = 0;
                for (int i = 1; i <= QLines1; i++)
                {
                    if (Types1[i - 1] != Types2[i - 1] && Types1[i - 1] != 0 && Types2[i - 1] != 0) CountTypesIncompatible++;
                }
                condContentType = (CountTypesIncompatible == 0);
            }
            else condContentType = true;
            //
            if (HdrsTypes == 1)
            {
                HdrTps1 = new int[QColumns1];
                HdrTps2 = new int[QColumns2];
                for (int i = 1; i <= QColumns1; i++) HdrTps1[i - 1] = T1.GetTypeN_LineOfColHeader(i);
                for (int i = 1; i <= QColumns2; i++) HdrTps2[i - 1] = T2.GetTypeN_LineOfColHeader(i);
                CountHeaderTypesIncompatible = 0;
                for (int i = 1; i <= QColumns1; i++)
                {
                    if (T1.GetIfLineOfColHeaderExists() == true && T2.GetIfLineOfColHeaderExists() == true && HdrTps1[i - 1] != HdrTps2[i - 1] && HdrTps1[i - 1] != 0 && HdrTps2[i - 1] != 0) CountHeaderTypesIncompatible++;
                }
                condHdrsTypes = (CountHeaderTypesIncompatible == 0);
            }
            else condHdrsTypes = true;
            //
            if (HdrsNames == 1)
            {
                names1 = new string[QColumns1]; names2 = new string[QColumns2];
                for (int i = 1; i <= QColumns1; i++) names1[i - 1] = T1.ToString_OfLineOfColHeader(i);
                for (int i = 1; i <= QColumns2; i++) names2[i - 1] = T2.ToString_OfLineOfColHeader(i);
                CountNamesIncompatible = 0;
                for (int i = 1; i <= QColumns1; i++)
                {
                    if (T1.GetIfLineOfColHeaderExists() == true && T2.GetIfLineOfColHeaderExists() == true && names1[i - 1][i - 1] != names2[i - 1][i - 1] && names1[i - 1] != "" && names2[i - 1] != "") CountNamesIncompatible++;
                }
                condHdrsNames = (CountNamesIncompatible == 0);
            }
            else condHdrsNames = true;
            verdict = condRowsQuantity && condContentType && condHdrsTypes && condHdrsNames;
            return verdict;
        }
        public static bool TablesAreCompatibleVertically(TTable T1, TTable T2)
        {
            return TablesAreCompatibleVertically(T1, T2, 0, 0, 0);
        }
        public static bool TablesAreCompatibleHorisontally(TTable T1, TTable T2, int ContentType, int HdrsTypes, int HdrsNames)
        {
            bool verdict, condRowsQuantity, condContentType, condHdrsTypes, condHdrsNames;
            verdict = false;
            int QColumns1, QLines1, QColumns2, QLines2;
            int CountTypesIncompatible, CountHeaderTypesIncompatible, CountNamesIncompatible;
            int[] Types1 = null, Types2 = null, HdrTps1 = null, HdrTps2 = null;
            string[] names1 = null, names2 = null;
            QColumns1 = T1.GetQColumns(); QLines1 = T1.GetQLines(); QColumns2 = T2.GetQColumns(); QLines2 = T2.GetQLines();
            verdict = false;
            //
            condRowsQuantity = (QLines1 == QLines2);
            //
            if (ContentType == 1)
            {
                Types1 = new int[QLines1];
                Types2 = new int[QLines2];
                for (int i = 1; i <= QLines1; i++) Types1[i - 1] = T1.ContentColumnHasSameTypeN(i);
                for (int i = 1; i <= QLines2; i++) Types2[i - 1] = T2.ContentColumnHasSameTypeN(i);
                CountTypesIncompatible = 0;
                for (int i = 1; i <= QColumns1; i++)
                {
                    if (Types1[i - 1] != Types2[i - 1] && Types1[i - 1] != 0 && Types2[i - 1] != 0) CountTypesIncompatible++;
                }
                condContentType = (CountTypesIncompatible == 0);
            }
            else condContentType = true;
            //
            if (HdrsTypes == 1)
            {
                HdrTps1 = new int[QLines1];
                HdrTps2 = new int[QLines2];
                for (int i = 1; i <= QLines1; i++) HdrTps1[i - 1] = T1.GetTypeN_ColOfLineHeader(i);
                for (int i = 1; i <= QLines2; i++) HdrTps2[i - 1] = T2.GetTypeN_ColOfLineHeader(i);
                CountHeaderTypesIncompatible = 0;
                for (int i = 1; i <= QLines1; i++)
                {
                    if (T1.GetIfLineOfColHeaderExists() == true && T2.GetIfLineOfColHeaderExists() == true && HdrTps1[i - 1] != HdrTps2[i - 1] && HdrTps1[i - 1] != 0 && HdrTps2[i - 1] != 0) CountHeaderTypesIncompatible++;
                }
                condHdrsTypes = (CountHeaderTypesIncompatible == 0);
            }
            else condHdrsTypes = true;
            //
            if (HdrsNames == 1)
            {
                names1 = new string[QLines1]; names2 = new string[QLines2];
                for (int i = 1; i <= QLines1; i++) names1[i - 1] = T1.ToString_OfColOfLineHeader(i);
                for (int i = 1; i <= QLines2; i++) names2[i - 1] = T2.ToString_OfColOfLineHeader(i);
                CountNamesIncompatible = 0;
                for (int i = 1; i <= QColumns1; i++)
                {
                    if (T1.GetIfLineOfColHeaderExists() == true && T2.GetIfLineOfColHeaderExists() == true && names1[i - 1][i - 1] != names2[i - 1][i - 1] && names1[i - 1] != "" && names2[i - 1] != "") CountNamesIncompatible++;
                }
                condHdrsNames = (CountNamesIncompatible == 0);
            }
            else condHdrsNames = true;
            verdict = condRowsQuantity && condContentType && condHdrsTypes && condHdrsNames;
            return verdict;
        }
        public static bool TablesAreCompatibleHorisontally(TTable T1, TTable T2)
        {
            return TablesAreCompatibleHorisontally(T1, T2, 0, 0, 0);
        }
    }//cl 2 TablesComparison
    public static class TableCellsCompareByVal// cl3
    {
        public static int CompareCellsByValues(TDataCell C1, TDataCell C2)
        {
            int Result_E1L2G3;
            Result_E1L2G3 = 1;
            //
            double d1, d2;
            int n1, n2, type1, type2, L1, L2, count;
            bool contin;
            string s1, s2;
            type1 = C1.GetTypeN();
            type2 = C2.GetTypeN();
            switch (type1)
            {
                case 1:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 10:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetDoubleVal();
                            d2 = NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;

                        default:

                            break;
                    }
                    break;
                case 2:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 20:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetFloatVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetIntVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            d1 = C1.GetFloatVal();
                            d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 30:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)C1.GetIntVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            d1 = (double)C1.GetIntVal();
                            d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = C1.GetIntVal();
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 4:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 40:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        default:

                            break;
                    }
                    break;
                case 5:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        case 50:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 5;
                case 50:
                    switch (type2)
                    {
                        case 1:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 10:
                            d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 2:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 20:
                            d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_E1L2G3 = 3;
                            else if (d1 < d2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 3:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 30:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 4:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 40:
                            n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_E1L2G3 = 3;
                            else if (n1 < n2) Result_E1L2G3 = 2;
                            else Result_E1L2G3 = 1;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        case 50:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 50;
                default:

                    break;
            }//switch   type1
            return Result_E1L2G3;
        }//fn CompareCells  
        public static bool ET(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        //
    }//cl 3TableCellsCompareByVal
    public static class TableCellsCompareFull //cl 4
    {
        public static int CompareCellsFull(TDataCell C1, TDataCell C2)
        {
            int Result_InCb0E1L2G3;
            Result_InCb0E1L2G3 = 0;
            //
            double d1, d2;
            int n1, n2, type1, type2, L1, L2, count, LMin;
            bool contin;
            string s1, s2;
            type1 = C1.GetTypeN();
            type2 = C2.GetTypeN();
            L1 = C1.GetLength();
            L2 = C2.GetLength();
            if (L1 <= L2) LMin = L1; else LMin = L2;
            switch (type1)
            {
                case 1:
                    switch (type2)
                    {
                        case 1:
                            d1 = C1.GetDoubleVal();
                            d2 = C2.GetDoubleVal();
                            if (d1 > d2) Result_InCb0E1L2G3 = 3;
                            else if (d1 < d2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 10:
                            //d1 = C1.GetDoubleVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 10:
                    switch (type2)
                    {
                        case 1:
                            //d1 = C1.GetDoubleVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                d1 = C1.GetDoubleValN(count);
                                d2 = C2.GetDoubleValN(count);
                                if (d1 > d2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (d1 < d2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 2:
                            d1 = C1.GetDoubleVal();
                            d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetFloatVal();
                            //verdict = (d1 > d2);
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = C1.GetDoubleVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetDoubleVal();
                            //d2 = NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;

                        default:

                            break;
                    }
                    break;
                case 2:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            d1 = (double)C1.GetFloatVal();
                            d2 = (double)C2.GetFloatVal();
                            if (d1 > d2) Result_InCb0E1L2G3 = 3;
                            else if (d1 < d2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 20:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 20:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                d1 = (double)C1.GetFloatValN(count);
                                d2 = (double)C2.GetFloatValN(count);
                                if (d1 > d2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (d1 < d2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            //
                            break;
                        case 3:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)C2.GetIntVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetFloatVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //d1 = C1.GetFloatVal();
                            //d2 = (float)NumberParse.StrToFloat(C2.ToString());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            n1 = C1.GetIntVal();
                            n2 = C2.GetIntVal();
                            if (n1 > n2) Result_InCb0E1L2G3 = 3;
                            else if (n1 < n2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 30:
                            //n1 = C1.GetIntVal();
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 30:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = C1.GetIntVal();
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                n1 = C1.GetIntValN(count);
                                n2 = C2.GetIntValN(count);
                                if (n1 > n2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (n1 < n2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 4:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //d1 = (double)C1.GetIntVal();
                            //d2 = (double)MyLib.BoolToInt(C2.GetBoolVal());
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = C1.GetIntVal();
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 4:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            if (n1 > n2) Result_InCb0E1L2G3 = 3;
                            else if (n1 < n2) Result_InCb0E1L2G3 = 2;
                            else Result_InCb0E1L2G3 = 1;
                            break;
                        case 40:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            break;
                        case 50:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 40:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (double)MyLib.BoolToInt(C1.GetBoolVal());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                n1 = MyLib.BoolToInt(C1.GetBoolVal());
                                n2 = MyLib.BoolToInt(C2.GetBoolVal());
                                if (n1 > n2)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (n1 < n2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        case 5:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //n1 = MyLib.BoolToInt(C1.GetBoolVal());
                            //n2 = (int)NumberParse.StrToFloat(C2.ToString());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }
                    break;
                case 5:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            s1 = C1.ToString();
                            s2 = C2.ToString();
                            Result_InCb0E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            //Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            //s1 = C1.ToString();
                            //s2 = C2.ToString();
                            //Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            Result_InCb0E1L2G3 = 0;
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 5;
                case 50:
                    switch (type2)
                    {
                        case 1:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 10:
                            //d1 = (double)NumberParse.StrToFloat(C1.ToString());
                            //d2 = C2.GetDoubleVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 2:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 20:
                            //d1 = (float)NumberParse.StrToFloat(C1.ToString());
                            //d2 = (double)C2.GetFloatVal();
                            //if (d1 > d2) Result_E1L2G3 = 3;
                            //else if (d1 < d2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 3:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 30:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = C2.GetIntVal();
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 4:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 40:
                            //n1 = (int)NumberParse.StrToFloat(C1.ToString());
                            //n2 = MyLib.BoolToInt(C2.GetBoolVal());
                            //if (n1 > n2) Result_E1L2G3 = 3;
                            //else if (n1 < n2) Result_E1L2G3 = 2;
                            //else Result_E1L2G3 = 1;
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 5:
                            //s1 = C1.ToString();
                            //s2 = C2.ToString();
                            //Result_E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                            Result_InCb0E1L2G3 = 0;
                            break;
                        case 50:
                            Result_InCb0E1L2G3 = 1;
                            count = 0;
                            contin = true;
                            while (contin)
                            {
                                count++;
                                s1 = C1.ToStringN(count);
                                s2 = C2.ToStringN(count);
                                Result_InCb0E1L2G3 = 1 + (MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
                                if (Result_InCb0E1L2G3 == 3)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if (Result_InCb0E1L2G3 == 2)
                                {
                                    Result_InCb0E1L2G3 = 2;
                                    contin = false;
                                }
                                if (count == LMin) contin = false;
                            }
                            if (Result_InCb0E1L2G3 == 1)
                            {
                                if (L1 > L2) Result_InCb0E1L2G3 = 3;
                                else if (L1 < L2) Result_InCb0E1L2G3 = 2;
                                //else Result_InCb0E1L2G3 == 1;
                            }
                            break;
                        default:

                            break;
                    }//switch type2
                    break;//case 50;
                default:

                    break;
            }//switch   type1
            return Result_InCb0E1L2G3;
        }//fn CompareCells  
        public static bool ET(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE(TDataCell C1, TDataCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        //
    }//cl 4 TableCellsCompareFull
    //
}//ns
