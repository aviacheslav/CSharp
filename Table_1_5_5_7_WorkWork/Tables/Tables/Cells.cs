using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//

namespace Tables
{
    public static class TableCellsCompareByVal
    {
        public static int CompareCellsByValues(TCell C1, TCell C2){
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
                            Result_E1L2G3 = 1+(MyLib.CompareStrings_E0L1G2(s1.ToCharArray(), s2.ToCharArray(), s1.Length, s2.Length));
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
        public static bool ET(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsByValues(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        //
    }
    public static class TableCellsCompareFull
    {
        public static int CompareCellsFull(TCell C1, TCell C2)
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
            L1=C1.GetLength();
            L2=C2.GetLength();
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
                            Result_InCb0E1L2G3=0;
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
                                if (Result_InCb0E1L2G3==3)
                                {
                                    Result_InCb0E1L2G3 = 3;
                                    contin = false;
                                }
                                else if(Result_InCb0E1L2G3==2)
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
        public static bool ET(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 1);
            return verdict;
        }
        public static bool NE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 1);
            return verdict;
        }
        public static bool LT(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 2);
            return verdict;
        }
        public static bool LE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 2);
            return verdict;
        }
        public static bool GT(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d == 3);
            return verdict;
        }
        public static bool GE(TCell C1, TCell C2)
        {
            bool verdict;
            int d;
            d = CompareCellsFull(C1, C2);
            verdict = (d != 3);
            return verdict;
        }
        //
        //
    }
    public abstract class TCell
    {
        public abstract  int GetTypeN();
        public abstract int GetActiveN();
        public abstract void SetActiveN(int N);
        public abstract int GetLength();
        public abstract void SetLength(int L);
        //
        public abstract double GetDoubleVal();
        public abstract float GetFloatVal();
        public abstract int GetIntVal();
        public abstract bool GetBoolVal();
        abstract public override string ToString();
        //
        public abstract double GetDoubleValN(int N);
        public abstract float GetFloatValN(int N);
        public abstract int GetIntValN(int N);
        public abstract bool GetBoolValN(int N);
        public abstract string ToStringN(int N);
        //
        public abstract void SetByDoubleVal(double val);
        public abstract void SetByFloatVal(float val);
        public abstract void SetByIntVal(int val);
        public abstract void SetByBoolVal(bool val);
        public abstract void SetByStringVal(string val);
        //
        public abstract void SetByDoubleValN(double val, int N);
        public abstract void SetByFloatValN(float val, int N);
        public abstract void SetByIntValN(int val, int N);
        public abstract void SetByBoolValN(bool val, int N);
        public abstract void SetByStringValN(string val, int N);
        //
        public abstract void SetVal(double val);
        public abstract void SetVal(int val);
        public abstract void SetVal(bool val);
        public abstract void SetVal(string val);
        //
        public abstract void SetValN(double val, int N);
        public abstract void SetValN(int val, int N);
        public abstract void SetValN(bool val, int N);
        public abstract void SetValN(string val, int N);
        //
        public abstract void SetByDoubleArr(double[] val, int Q);
        public abstract void SetByFloatArr(float[] val, int Q);
        public abstract void SetByIntArr(int[] val, int Q);
        public abstract void SetByBoolArr(bool[] val, int Q);
        public abstract void SetByStringArr(string[] val, int Q);
        //
        public abstract void SetByArr(double[] val, int Q);
        public abstract void SetByArr(int[] val, int Q);
        public abstract void SetByArr(bool[] val, int Q);
        public abstract void SetByArr(string[] val, int Q);
        //
        public abstract void AddOrInsDoubleVal(double val, int N);
        public abstract void AddOrInsFloatVal(float val, int N);
        public abstract void AddOrInsIntVal(int val, int N);
        public abstract void AddOrInsBoolVal(bool val, int N);
        public abstract void AddOrInsStringVal(string val, int N);
        //
        //
        public abstract void DelValN(int N);
        //
        //public abstract InsDoubleValN(double val, int N);
        //public abstract InsFloatValN(float val, int N);
        //public abstract InsIntValN(int val, int N);
        //public abstract InsBoolValN(bool val, int N);
        //public abstract InsStringValN(string val, int N);
        //
        //public abstract AddDoubleValN(double val, int N);
        //public abstract AddFloatValN(float val, int N);
        //public abstract AddIntValN(int val, int N);
        //public abstract AddBoolValN(bool val, int N);
        //public abstract AddStringValN(string val, int N);
    }//cl
    //
    public class TCellDouble:TCell
    {
        double val;
        public TCellDouble() { val = 0; }
        public TCellDouble(double val) { SetByDoubleVal(val); }
        public TCellDouble(float val) { SetByFloatVal(val); }
        public TCellDouble(int val) { SetByIntVal(val); }
        public TCellDouble(bool val) { SetByBoolVal(val); }
        public TCellDouble(string val) { SetByStringVal(val); }
        //
        public TCellDouble(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellDouble(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellDouble(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellDouble(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellDouble(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 1; }
        public override int GetActiveN() { return 1;}
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L){}
        //
        public override double GetDoubleVal() { return val; }
        public override float GetFloatVal() {
            float r;
            r = (float)val;
            return r;
        }
        public override int GetIntVal()
        {
            int r;
            r =(int)Math.Round(val);
            return r;
        }
        public override bool GetBoolVal() {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) {return val.ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val = (double)val; }
        public override void SetByFloatVal(float val) { this.val = (double)val; }
        public override void SetByIntVal(int val) { this.val = (double)val; }
        public override void SetByBoolVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val=(double)i;
        }
        public override void SetByStringVal(string val) { this.val = Convert.ToDouble(val); }
        //
        public override void SetByDoubleValN(double val, int N) { SetByDoubleVal(val); }
        public override void SetByFloatValN(float val, int N) { SetByFloatVal(val); }
        public override void SetByIntValN(int val, int N) { SetByIntVal(val); }
        public override void SetByBoolValN(bool val, int N) { SetByBoolVal(val); }
        public override void SetByStringValN(string val, int N) { SetByStringVal(val); }
        //
        public override void SetVal(double val) { this.val = (double)val; }
        public override void SetVal(int val) { this.val = (double)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (double)i;
        }
        public override void SetVal(string val) { this.val = Convert.ToDouble(val); }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q){
            if(val!=null)SetByDoubleVal(val[1-1]);
            else SetByDoubleVal(0);
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            if (val != null) SetByFloatVal(val[1 - 1]);
            else SetByFloatVal(0);
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void SetByArr(double[] val, int Q){
            if(val!=null)SetByDoubleVal(val[1-1]);
            else SetByDoubleVal(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = (double)val;
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = (double)val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (double)MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val=Convert.ToDouble(val);
        }
        //
        public override void DelValN(int N) { }
    }//cl
    public class TCellFloat : TCell
    {
        float val;
        public TCellFloat() { val = 0; }
        public TCellFloat(double val) { SetByDoubleVal(val); }
        public TCellFloat(float val) { SetByFloatVal(val); }
        public TCellFloat(int val) { SetByIntVal(val); }
        public TCellFloat(bool val) { SetByBoolVal(val); }
        public TCellFloat(string val) { SetByStringVal(val); }
        //
        public TCellFloat(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellFloat(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellFloat(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellFloat(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellFloat(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 2; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal() {
            //float r;
            //r = (float)val;
            //return r;
            return (double)val;
        }
        public override float GetFloatVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return val;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val = (float)val; }
        public override void SetByFloatVal(float val) { this.val = (float)val; }
        public override void SetByIntVal(int val) { this.val = (float)val; }
        public override void SetByBoolVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetByStringVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val = (float)d;
        }
        //
        public override void SetByDoubleValN(double val, int N) { SetByDoubleVal(val); }
        public override void SetByFloatValN(float val, int N) { SetByFloatVal(val); }
        public override void SetByIntValN(int val, int N) { SetByIntVal(val); }
        public override void SetByBoolValN(bool val, int N) { SetByBoolVal(val); }
        public override void SetByStringValN(string val, int N) { SetByStringVal(val); }
        //
        public override void SetVal(double val) { this.val = (float)val; }
        public override void SetVal(int val) { this.val = (float)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val = (float)d;
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            if (val != null) SetByFloatVal(val[1 - 1]);
            else SetByFloatVal(0);
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = (float)val;
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = (float)val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (float)MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = (float)Convert.ToDouble(val);
        }
        //
        public override void DelValN(int N) { }
    }//cl
    public class TCellInt : TCell
    {
        int val;
        public TCellInt() { val = 0; }
        public TCellInt(double val) { SetByDoubleVal(val); }
        public TCellInt(float val) { SetByFloatVal(val); }
        public TCellInt(int val) { SetByIntVal(val); }
        public TCellInt(bool val) { SetByBoolVal(val); }
        public TCellInt(string val) { SetByStringVal(val); }
        //
        public TCellInt(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellInt(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellInt(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellInt(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellInt(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 3; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (double)val;
        }
        public override float GetFloatVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (float)val;
        }
        public override int GetIntVal()
        {
            return val;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N){ return val; }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val = (int)val; }
        public override void SetByFloatVal(float val) { this.val = (int)val; }
        public override void SetByIntVal(int val) { this.val = (int)val; }
        public override void SetByBoolVal(bool val)
        {
            this.val =  MyLib.BoolToInt(val);
        }
        public override void SetByStringVal(string val)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void SetByDoubleValN(double val, int N) { SetByDoubleVal(val); }
        public override void SetByFloatValN(float val, int N) { SetByFloatVal(val); }
        public override void SetByIntValN(int val, int N) { SetByIntVal(val); }
        public override void SetByBoolValN(bool val, int N) { SetByBoolVal(val); }
        public override void SetByStringValN(string val, int N) { SetByStringVal(val); }
        //
        public override void SetVal(double val) { this.val = (int)val; }
        public override void SetVal(int val) { this.val = (int)val; }
        public override void SetVal(bool val)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void SetVal(string val)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            if (val != null) SetByFloatVal(val[1 - 1]);
            else SetByFloatVal(0);
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = (int)Math.Round(val);
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = (int)Math.Round(val);
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void DelValN(int N) { }
    }//cl
    public class TCellBool : TCell
    {
        bool val;
        public TCellBool() { val = false; }
        public TCellBool(double val) { SetByDoubleVal(val); }
        public TCellBool(float val) { SetByFloatVal(val); }
        public TCellBool(int val) { SetByIntVal(val); }
        public TCellBool(bool val) { SetByBoolVal(val); }
        public TCellBool(string val) { SetByStringVal(val); }
        //
        public TCellBool(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellBool(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellBool(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellBool(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellBool(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 4; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            int i;
            i=MyLib.BoolToInt(val);
            return (double)i;
        }
        public override float GetFloatVal()
        {
            int i;
            i = MyLib.BoolToInt(val);
            return (float)i;
        }
        public override int GetIntVal()
        {
            int i;
            i = MyLib.BoolToInt(val);
            return i;
        }
        public override bool GetBoolVal()
        {
            return val;
        }
        public override string ToString() {
            int i;
            i = MyLib.BoolToInt(val);
            return i.ToString();
        }
        //
        public override double GetDoubleValN(int N) {
            double r;
            r = GetDoubleVal();
            return r;
        }
        public override float GetFloatValN(int N)
        {
            float r;
            r = GetFloatVal();
            return r;
        }
        public override int GetIntValN(int N)
        {
            int r;
            r = GetIntVal();
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            r = GetBoolVal();
            return r;
        }
        public override string ToStringN(int N) {
            string r;
            r = ToString();
            return r;
        }
        //
        public override void SetByDoubleVal(double val) {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByFloatVal(float val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByIntVal(int val) {
            this.val =  MyLib.IntToBool(val);
        }
        public override void SetByBoolVal(bool val)
        {
            this.val = val;
        }
        public override void SetByStringVal(string val)
        {
            int i;
            i=Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i); 
        }
        //
        public override void SetByDoubleValN(double val, int N) { SetByDoubleVal(val); }
        public override void SetByFloatValN(float val, int N) { SetByFloatVal(val); }
        public override void SetByIntValN(int val, int N) { SetByIntVal(val); }
        public override void SetByBoolValN(bool val, int N) { SetByBoolVal(val); }
        public override void SetByStringValN(string val, int N) { SetByStringVal(val); }
        //
        public override void SetVal(double val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetVal(int val)
        {
            this.val = MyLib.IntToBool(val);
        }
        public override void SetVal(bool val)
        {
            this.val = val;
        }
        public override void SetVal(string val)
        {
            int i;
            i=Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i); 
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            if (val != null) SetByFloatVal(val[1 - 1]);
            else SetByFloatVal(0);
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = MyLib.IntToBool((int)Math.Round(val));
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = MyLib.IntToBool((int)Math.Round(val));
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = MyLib.IntToBool(val);
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = MyLib.IntToBool(Convert.ToInt32(val));
        }
        //
        public override void DelValN(int N) { }
    }//cl
    public class TCellString : TCell
    {
        string val;
        public TCellString() { val = ""; }
        public TCellString(double val) { SetByDoubleVal(val); }
        public TCellString(float val) { SetByFloatVal(val); }
        public TCellString(int val) { SetByIntVal(val); }
        public TCellString(bool val) { SetByBoolVal(val); }
        public TCellString(string val) { SetByStringVal(val); }
        //
        public TCellString(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellString(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellString(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellString(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellString(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 5; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            double n;
            n = NumberParse.StrToFloat(val);
            return n;
        }
        public override float GetFloatVal()
        {
            float n;
            n = (float)NumberParse.StrToFloat(val);
            return n;
        }
        public override int GetIntVal()
        {
            int n;
            n = (int)NumberParse.StrToFloat(val);
            return n;
        }
        public override bool GetBoolVal()
        {
            bool b;
            int n;
            n = (int)NumberParse.StrToFloat(val);
            b = MyLib.IntToBool(n);
            return b;
        }
        public override string ToString()
        {
            return val;
        }
        //
        public override double GetDoubleValN(int N)
        {
            double r;
            r = GetDoubleVal();
            return r;
        }
        public override float GetFloatValN(int N)
        {
            float r;
            r = GetFloatVal();
            return r;
        }
        public override int GetIntValN(int N)
        {
            int r;
            r = GetIntVal();
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            r = GetBoolVal();
            return r;
        }
        public override string ToStringN(int N)
        {
            string r;
            r = ToString();
            return r;
        }
        //
        public override void SetByDoubleVal(double val)
        {
             this.val = val.ToString();
        }
        public override void SetByFloatVal(float val)
        {
            this.val = val.ToString();
        }
        public override void SetByIntVal(int val)
        {
            this.val = val.ToString();
        }
        public override void SetByBoolVal(bool val)
        {
            int n= MyLib.BoolToInt(val);
            this.val =n.ToString();
        }
        public override void SetByStringVal(string val)
        {
            this.val = val;
        }
        //
        public override void SetByDoubleValN(double val, int N) { SetByDoubleVal(val); }
        public override void SetByFloatValN(float val, int N) { SetByFloatVal(val); }
        public override void SetByIntValN(int val, int N) { SetByIntVal(val); }
        public override void SetByBoolValN(bool val, int N) { SetByBoolVal(val); }
        public override void SetByStringValN(string val, int N) { SetByStringVal(val); }
        //
        public override void SetVal(double val)
        {
            this.val = val.ToString();
        }
        public override void SetVal(int val)
        {
            this.val = val.ToString();
        }
        public override void SetVal(bool val)
        {
            int n = MyLib.BoolToInt(val);
            this.val = n.ToString();
        }
        public override void SetVal(string val)
        {
            this.val = val;
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            if (val != null) SetByFloatVal(val[1 - 1]);
            else SetByFloatVal(0);
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByDoubleVal(val[1 - 1]);
            else SetByDoubleVal(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByIntVal(val[1 - 1]);
            else SetByIntVal(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByBoolVal(val[1 - 1]);
            else SetByBoolVal(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (MyLib.BoolToInt(val)).ToString();
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = val;
        }
        //
        public override void DelValN(int N) { }
    }//cl
    //
    public class TCellDoubleMemo : TCell
    {
        double[] val;
        int QVals, ActiveValN;
        public TCellDoubleMemo() {
            val = new double[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellDoubleMemo(double val) { SetByDoubleVal(val); }
        public TCellDoubleMemo(float val) { SetByFloatVal(val); }
        public TCellDoubleMemo(int val) { SetByIntVal(val); }
        public TCellDoubleMemo(bool val) { SetByBoolVal(val); }
        public TCellDoubleMemo(string val) { SetByStringVal(val); }
        //
        public TCellDoubleMemo(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellDoubleMemo(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellDoubleMemo(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellDoubleMemo(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellDoubleMemo(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 10; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<double>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal() {
            //return val[1-1];
            return val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            float r;
            r = (float)val[ActiveValN - 1];
            return r;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val[ActiveValN - 1]);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return val[N - 1]; }
        public override float GetFloatValN(int N) { return (float)val[N - 1]; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val[N - 1]);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByFloatVal(float val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByIntVal(int val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByBoolVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (double)i;
        }
        public override void SetByStringVal(string val) { this.val[ActiveValN - 1] = Convert.ToDouble(val); }
        //
        public override void SetByDoubleValN(double val, int N) { this.val[N - 1] = val; }
        public override void SetByFloatValN(float val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByIntValN(int val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByBoolValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)i;
        }
        public override void SetByStringValN(string val, int N) { this.val[N - 1] = Convert.ToDouble(val); }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (double)i;
        }
        public override void SetVal(string val) { this.val[ActiveValN - 1] = Convert.ToDouble(val); }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = (double)val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)i;
        }
        public override void SetValN(string val, int N) { this.val[N - 1] = Convert.ToDouble(val); }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            this.val = new double[Q];
            if(val!=null){
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }else{
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(0, i); }
            }
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByStringVal(val[1 - 1]);
            else SetByStringVal("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsFloatVal(float val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsIntVal(int val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val), N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, Convert.ToDouble(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, Convert.ToDouble(val));
            }
        }
        //
        public override void DelValN(int N) {
            MyLib.DelInVector(ref val, ref QVals, N);       
        }
    }//cl
    public class TCellFloatMemo : TCell
    {
        float[] val;
        int QVals, ActiveValN;
        public TCellFloatMemo()
        {
            val = new float[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellFloatMemo(double val) { SetByDoubleVal(val); }
        public TCellFloatMemo(float val) { SetByFloatVal(val); }
        public TCellFloatMemo(int val) { SetByIntVal(val); }
        public TCellFloatMemo(bool val) { SetByBoolVal(val); }
        public TCellFloatMemo(string val) { SetByStringVal(val); }
        //
        public TCellFloatMemo(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellFloatMemo(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellFloatMemo(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellFloatMemo(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellFloatMemo(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 20; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<float>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            return (double)val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            return val[ActiveValN - 1]; ;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val[ActiveValN - 1]);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val[N - 1]; }
        public override float GetFloatValN(int N) { return val[N - 1]; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val[N - 1]);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetByFloatVal(float val) { this.val[ActiveValN - 1] = val; }
        public override void SetByIntVal(int val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetByBoolVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (float)i;
        }
        public override void SetByStringVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val[ActiveValN - 1] = (float)d;
        }
        //
        public override void SetByDoubleValN(double val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByFloatValN(float val, int N) { this.val[N - 1] = val; }
        public override void SetByIntValN(int val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByBoolValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (float)i;
        }
        public override void SetByStringValN(string val, int N) {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (float)i;
        }
        public override void SetVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val[ActiveValN - 1] = (float)d;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = (float)val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (float)i;
        }
        public override void SetValN(string val, int N) {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(0, i); }
            }
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)MyLib.BoolToInt(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)Convert.ToDouble(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)Convert.ToDouble(val));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
    }//cl
    public class TCellIntMemo : TCell
    {
        int[] val;
        int QVals, ActiveValN;
        public TCellIntMemo()
        {
            val = new int[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellIntMemo(double val) { SetByDoubleVal(val); }
        public TCellIntMemo(float val) { SetByFloatVal(val); }
        public TCellIntMemo(int val) { SetByIntVal(val); }
        public TCellIntMemo(bool val) { SetByBoolVal(val); }
        public TCellIntMemo(string val) { SetByStringVal(val); }
        //
        public TCellIntMemo(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellIntMemo(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellIntMemo(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellIntMemo(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellIntMemo(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 30; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<int>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            //return val[1-1];
            return val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            float r;
            r = (float)val[ActiveValN - 1];
            return r;
        }
        public override int GetIntVal()
        {
            //int r;
            //r = (int)Math.Round(val[ActiveValN - 1]);
            return (int)val[ActiveValN - 1]; ;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val[N - 1]; }
        public override float GetFloatValN(int N) { return (float)val[N - 1]; }
        public override int GetIntValN(int N)
        {
            return val[N - 1];
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByDoubleVal(double val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByFloatVal(float val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByIntVal(int val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByBoolVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = i;
        }
        public override void SetByStringVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = d;
        }
        //
        public override void SetByDoubleValN(double val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByFloatValN(float val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByIntValN(int val, int N) { this.val[N - 1] = val; }
        public override void SetByBoolValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = i;
        }
        public override void SetByStringValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = d;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = i;
        }
        public override void SetVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = d;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = (int)val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = i;
        }
        public override void SetValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = d;
        }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(0, i); }
            }
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (int)Math.Round(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (int)Math.Round(val));
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (int)Math.Round(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (int)Math.Round(val));
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.BoolToInt(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, Convert.ToInt32(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, Convert.ToInt32(val));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
    }//cl
    public class TCellBoolMemo : TCell
    {
        bool[] val;
        int QVals, ActiveValN;
        public TCellBoolMemo()
        {
            val = new bool[1];
            val[1 - 1] = false;
            QVals = 1;
            ActiveValN=1;
        }
        public TCellBoolMemo(double val) { SetByDoubleVal(val); }
        public TCellBoolMemo(float val) { SetByFloatVal(val); }
        public TCellBoolMemo(int val) { SetByIntVal(val); }
        public TCellBoolMemo(bool val) { SetByBoolVal(val); }
        public TCellBoolMemo(string val) { SetByStringVal(val); }
        //
        public TCellBoolMemo(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellBoolMemo(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellBoolMemo(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellBoolMemo(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellBoolMemo(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 40; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<bool>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = false;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return (double)d;
        }
        public override float GetFloatVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return (float)d;
        }
        public override int GetIntVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return d;
        }
        public override bool GetBoolVal()
        {
            return val[ActiveValN - 1];
        }
        public override string ToString() {
            int i;
            i = MyLib.BoolToInt(val[ActiveValN - 1]);
            return i.ToString();
        }
        //
        public override double GetDoubleValN(int N) {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return (double)i;
        }
        public override float GetFloatValN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return (float)i;
        }
        public override int GetIntValN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return i;
        }
        public override bool GetBoolValN(int N)
        {
            return val[N - 1];
        }
        public override string ToStringN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return i.ToString();
        }
        //
        public override void SetByDoubleVal(double val) {
            this.val[ActiveValN - 1] = MyLib.IntToBool((int)val);
        }
        public override void SetByFloatVal(float val) { this.val[ActiveValN - 1] = MyLib.IntToBool((int)val); }
        public override void SetByIntVal(int val) { this.val[ActiveValN - 1] =  MyLib.IntToBool((int)val); }
        public override void SetByBoolVal(bool val)
        {
            this.val[ActiveValN - 1] = val;
        }
        public override void SetByStringVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetByDoubleValN(double val, int N) {
            this.val[N - 1] =  MyLib.IntToBool((int)val);
        }
        public override void SetByFloatValN(float val, int N) {
            this.val[N - 1] =  MyLib.IntToBool((int)val);
        }
        public override void SetByIntValN(int val, int N)
        {
            this.val[N - 1] =  MyLib.IntToBool(val);
        }
        public override void SetByBoolValN(bool val, int N)
        {
            this.val[N - 1] = val;
        }
        public override void SetByStringValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = MyLib.IntToBool((int)val); }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = MyLib.IntToBool(val); }
        public override void SetVal(bool val)
        {
            this.val[ActiveValN - 1] = val;
        }
        public override void SetVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = MyLib.IntToBool((int)val); }
        public override void SetValN(int val, int N) { this.val[N - 1] = MyLib.IntToBool(val); }
        public override void SetValN(bool val, int N)
        {
            this.val[N - 1] = val;
        }
        public override void SetValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(0, i); }
            }
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)));
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)));
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool(val));
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool(Convert.ToInt32(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool(Convert.ToInt32(val)));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
    }//cl
    public class TCellStringMemo : TCell
    {
        string[] val;
        int QVals, ActiveValN;
        public TCellStringMemo()
        {
            val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellStringMemo(double val) { SetByDoubleVal(val); }
        public TCellStringMemo(float val) { SetByFloatVal(val); }
        public TCellStringMemo(int val) { SetByIntVal(val); }
        public TCellStringMemo(bool val) { SetByBoolVal(val); }
        public TCellStringMemo(string val) { SetByStringVal(val); }
        //
        public TCellStringMemo(double[] val, int Q) { SetByDoubleArr(val, Q); }
        public TCellStringMemo(float[] val, int Q) { SetByFloatArr(val, Q); }
        public TCellStringMemo(int[] val, int Q) { SetByIntArr(val, Q); }
        public TCellStringMemo(bool[] val, int Q) { SetByBoolArr(val, Q); }
        public TCellStringMemo(string[] val, int Q) { SetByStringArr(val, Q); }
        //
        public override int GetTypeN() { return 50; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<string>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = "";
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            return NumberParse.StrToFloat(val[ActiveValN - 1]);
        }
        public override float GetFloatVal()
        {
            return (float)(NumberParse.StrToFloat(val[ActiveValN - 1]));
        }
        public override int GetIntVal()
        {
            double d, d1; 
            d = NumberParse.StrToFloat(val[ActiveValN - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolVal()
        {
            return MyLib.StrToBool(val[ActiveValN - 1]);
        }
        public override string ToString()
        {
            return val[ActiveValN - 1];
        }
        //
        public override double GetDoubleValN(int N)
        {
            return NumberParse.StrToFloat(val[N - 1]);
        }
        public override float GetFloatValN(int N)
        {
            return (float)(NumberParse.StrToFloat(val[N - 1]));
        }
        public override int GetIntValN(int N)
        {
            double d, d1;
            d = NumberParse.StrToFloat(val[N - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolValN(int N)
        {
            return MyLib.StrToBool(val[N - 1]);
        }
        public override string ToStringN(int N)
        {
            return val[N - 1];
        }
        //
        public override void SetByDoubleVal(double val){ this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByFloatVal(float val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByIntVal(int val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByBoolVal(bool val) { this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0"); }
        public override void SetByStringVal(string val){this.val[ActiveValN - 1] = val;}
        //
        public override void SetByDoubleValN(double val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByFloatValN(float val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByIntValN(int val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByBoolValN(bool val, int N)
        {
            int n;
            n=MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetByStringValN(string val, int N)
        {
            this.val[N - 1] = val;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetVal(bool val)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = n.ToString();
        }
        public override void SetVal(string val)
        {
            this.val[ActiveValN - 1] = val;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val.ToString(); }
        public override void SetValN(int val, int N) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetValN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetValN(string val, int N){ this.val[N - 1] = val; }
        //
        public override void SetByDoubleArr(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByFloatArr(float[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByFloatValN(0, i); }
            }
        }
        public override void SetByIntArr(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByBoolArr(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByStringArr(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByDoubleValN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByIntValN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByBoolValN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByStringValN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
    }//cl
    //
    public class TableStructure
    {
        public bool ColOfLineHeaderExists, LineOfColHeaderExists, LC_Matrix_Not_CL_DB;
        public TableStructure()
        {
            ColOfLineHeaderExists=true;
            LineOfColHeaderExists=true;
            LC_Matrix_Not_CL_DB = true;
        }
    }
    public class TableSize
    {
        public int QColumns, QLines;
        public TableSize()
        {
            QColumns = 1; QLines = 1;
        }
        public TableSize(int QColumns, int QLines)
        {
            this.QColumns = QColumns; this.QLines = QLines;
        }
    }
    public class TableGeneralRepresentation
    {
        public bool ShowColOfLineHeader, ShowLineOfColHeader;
        public int LRecom, Len_NoLim0RecomVal1GenMaxLen2MaxByCol3;
        public TableGeneralRepresentation(){
            ShowColOfLineHeader=true; ShowLineOfColHeader=true;
            LRecom=6; Len_NoLim0RecomVal1GenMaxLen2MaxByCol3=0;
        }
    }
    public class TableHeaderCellRepresentation
    {
        public bool RowName;
		public bool InBrackets;
		public int Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7;
		public int BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7;
        public bool GenRowNameBef, RowNBef;//, RowNameBef;
        public bool GenRowNameAft, RowNAft;//, RowNameAft;
		public int AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7;
        public int Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8;
        public TableHeaderCellRepresentation(){
            RowName=true;
			GenRowNameBef=true; RowNBef=true; //RowNameBef=true;
            GenRowNameAft=false; RowNAft=false; //RowNameAft=false;
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7=0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7=0;
            InBrackets=false;
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7=0;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8=0;
        }
    }
    public class TContentCellRepresentation
    {
        //THeaderCellRepresentation LineHeaderBef, ColHeaderBef, LineHeaderAft, ColHeaderAft;
        public TableHeaderCellRepresentation LineHeader, ColHeader;
        public bool LineHeaderBefExists, ColHeaderBefExists, LineHeaderAftExists, ColHeaderAftExists;
        public bool Bef_LH_IsBef_CH, Aft_LH_IsBef_CH, HeadersInBrackets;
        public TContentCellRepresentation(){
            //LineHeaderBef=null; ColHeaderBef=null; LineHeaderAft=null; ColHeaderAft=null;
            LineHeader=null; ColHeader=null; 
            LineHeaderBefExists=false; ColHeaderBefExists=false; LineHeaderAftExists=false; ColHeaderAftExists=false;
            Bef_LH_IsBef_CH=false; Aft_LH_IsBef_CH=false; HeadersInBrackets=false;
        }
    }
    public class TableRepresentation{
        public TableGeneralRepresentation GenRepr;
        public THeaderCellRepresentation LineHeaderRepr, ColHeaderRepr;
        public TContentCellRepresentation ContentRepr;
        public TableRepresentation()
        {
            ContentRepr=null;
            LineHeaderRepr=null;
            ColHeaderRepr=null;
        }
        public void SetNull(){
            ContentRepr=null;
            LineHeaderRepr=null;
            ColHeaderRepr=null;
        }
        public void CreateContentByDefault(){
            ContentRepr=new TContentCellRepresentation();
        }
        public void SetColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1){
            if(ColHeaderExists_No0Yes1!=0){
                ColHeaderRepr=new THeaderCellRepresentation();
                if(ContentRepr.ColHeader!=null)ContentRepr.ColHeader=new THeaderCellRepresentation();
            }else{
                ColHeaderRepr=null;
                ContentRepr.ColHeader=null;
            }
        }
        public void SetLineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1){
            if(LineHeaderExists_No0Yes1!=0){
                LineHeaderRepr=new THeaderCellRepresentation();
                if(ContentRepr.LineHeader!=null)ContentRepr.LineHeader=new THeaderCellRepresentation();
            }else{
                LineHeaderRepr=null;
                ContentRepr.LineHeader=null;
            }
        }
    }
    //
    public class TableUssagePolicy
    {
        //public int Rows, Columns, Content, Both;
        public bool LinesCanAdd, LinesCanDel, LinesCanIns, LinesCanReplace;
        public bool ColumnsCanAdd, ColumnsCanDel, ColumnsCanIns, ColumnsCanReplace;
        public bool BothCanAdd, BothCanDel, BothsCanIns, BothCanReplace;
        public bool LH_Can_Edit, CH_Can_Edit, ContentsCanEdit;
        public bool ContentCellsCanReplace;
        public TableUssagePolicy()
        {
            AllowAll();
        }
        public void AllowAll()
        {
            LinesCanAdd=true; LinesCanDel=true; LinesCanIns=true; LinesCanReplace=true;
            ColumnsCanAdd=true; ColumnsCanDel=true; ColumnsCanIns=true; ColumnsCanReplace=true;
            BothCanAdd=true; BothCanDel=true; BothsCanIns=true; BothCanReplace=true;
            ContentCellsCanReplace = true;
            LH_Can_Edit = true; CH_Can_Edit = true; ContentsCanEdit = true;
        }
        public void ForbidAll()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; LinesCanReplace = false;
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; ColumnsCanReplace = false;
            BothCanAdd = false; BothCanDel = false; BothsCanIns = false; BothCanReplace = false;
            ContentCellsCanReplace = false;
            LH_Can_Edit = false; CH_Can_Edit = false; ContentsCanEdit = false;
        }
        public void AllowColumns()
        {
            ColumnsCanAdd = true; ColumnsCanDel = true; ColumnsCanIns = true; ColumnsCanReplace = true; CH_Can_Edit = true;
        }
        public void AllowLines()
        {
            LinesCanAdd = true; LinesCanDel = true; LinesCanIns = true; LinesCanReplace = true; LH_Can_Edit = true;
        }
        public void AllowBoth()
        {
            BothCanAdd = true; BothCanDel = true; BothsCanIns = true; BothCanReplace = true;
        }
        public void ForbidColumns()
        {
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; ColumnsCanReplace = false; CH_Can_Edit = false;
        }
        public void ForbidLines()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; LinesCanReplace = false; LH_Can_Edit = false;
        }
        public void ForbidBoth()
        {
            BothCanAdd = false; BothCanDel = false; BothsCanIns = false; BothCanReplace = false;
        }
        public void FixRowsQuantity()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; 
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; 
            BothCanAdd = false; BothCanDel = false; BothsCanIns = false; 
        }
    }
    public class TableRowsGeneralNames{
        public string LinesGeneralName, ColsGeneralName;
        public TableRowsGeneralNames(){
            LinesGeneralName=""; ColsGeneralName="";
        }
    }
    public class TableRowsQuantities{
        public int  QLines, QColumns;
        public TableRowsQuantities(){
            QLines=1; QColumns=1;
        }
    }
    public class TableInfo{
        public TableStructure Str;
        public TableRowsGeneralNames RowsGeneralNames;
        public TableRowsQuantities RowsQuantities;
        public TableUssagePolicy UssagePolicy;
        public TableRepresentation Repr;
        public TableInfo(){
            Str = new TableStructure();
            RowsGeneralNames=null;
            RowsQuantities=new TableRowsQuantities();
            UssagePolicy = null;
            CellsRepresentation = null;
        }
    }
    //
    public class TTable
    {
        TableInfo TblInf;
        int id;
        TCell TableName, SpecCell;
        TCell[] LineOfColHeader, ColOfLineHeader;
        TCell[][] ContentCell;
        //string LinesGeneralName, ColsGeneralName;
        //int QLines, QColumns;
        public TTable()
        {
            this.TblInf=new TableInfo();
            this.TblInf.RowsQuantities.QLines = 1;
            this.TblInf.RowsQuantities.QColumns = 1;
            SpecCell=null;
            TableName=new TCellString();
        }
        //
        public int GetQLines() { return this.TblInf.RowsQuantities.QLines; }
        public int GetQColumns() { return this.TblInf.RowsQuantities.QColumns; }
        public string GetTableName(int N) { return TableName.ToStringN(N); }
        public string GetLinesGeneralName() { return this.TblInf.RowsGeneralNames.LinesGeneralName; }
        public string GetColsGeneralName() { return this.TblInf.RowsGeneralNames.ColsGeneralName; }
        public int GetTableNameSize() { return TableName.GetLength(); }
        bool GetIfLineOfColHeaderExists() { return (LineOfColHeader != null); }
        bool GetIfColOfLineHeaderExists() { return (ColOfLineHeader != null); }
        public bool GetIf_LC_Matrix_Not_CL_DB()
        {
            return this.TblInf.Str.LC_Matrix_Not_CL_DB;
        }
        public void Set_LC_Matrix_Not_CL_DB(bool LC_Matrix_Not_CL_DB)
        {
            if (LC_Matrix_Not_CL_DB != this.TblInf.Str.LC_Matrix_Not_CL_DB)
            {
                MyLib.TransposeTable(ref this.ContentCell, ref this.TblInf.RowsQuantities.QLines, ref this.TblInf.RowsQuantities.QColumns);
            }
        }
        public bool GetIfLineNExists(int N)
        {
            bool b;
            b = (N >= 1 && N <= this.TblInf.RowsQuantities.QLines);
            return b;
        }
        public bool GetIfColumnNExists(int N)
        {
            bool b;
            b = (N >= 1 && N <= this.TblInf.RowsQuantities.QColumns);
            return b;
        }

        TCell GetCell(int LineN, int ColumnN)
        {
            TCell cell;
            cell = null;
            if (LineN == 0)
            {
                if (ColumnN != 0)
                {
                    if (this.TblInf.Str.LineOfColHeaderExists == true)
                    {
                        if (ColOfLineHeader != null)
                        {
                            if (ColumnN >= 1 && ColumnN <= this.TblInf.RowsQuantities.QColumns)
                            {
                                cell = LineOfColHeader[ColumnN - 1];
                            }
                        }
                    }
                }
            }
            else if (ColumnN == 0)
            {
                if (LineN != 0)
                {
                    if (this.TblInf.Str.ColOfLineHeaderExists == true)
                    {
                        if (ColOfLineHeader != null)
                        {
                            if (LineN >= 1 && LineN <= this.TblInf.RowsQuantities.QLines)
                            {
                                cell = ColOfLineHeader[LineN - 1];
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                {
                    if (LineN >= 1 && LineN <= this.TblInf.RowsQuantities.QLines && ColumnN >= 1 && ColumnN <= this.TblInf.RowsQuantities.QColumns)
                    {
                        cell = ContentCell[LineN - 1][ColumnN - 1];
                    }
                }
                else
                {
                    if (LineN >= 1 && LineN <= this.TblInf.RowsQuantities.QLines && ColumnN >= 1 && ColumnN <= this.TblInf.RowsQuantities.QColumns)
                    {
                        cell = ContentCell[ColumnN - 1][LineN - 1];
                    }
                }
            }
            return cell;
        }
        //public int GetColOfLineHeaderSize() {
        //    int Q;
        //    bool exists=GetIfLineOfColHeaderExists();
        //    if (!exists) Q = 0;
        //    else Q = LineOfColHeader[1 - 1].GetLength();
        //    return Q;
        //}
        //public int SetColOfLineHeaderSize(int L)
        //{
           
        //}
        //
        //
        TableRepresentation GetTableRepresentation(){
            return this.TblInf.Repr;
        }
        TContentCellRepresentation GetContentCellRepresentation(){
            return this.TblInf.Repr.ContentRepr;
        }
        TableHeaderCellRepresentation GetColOfLineHeaderRepresentation(){
            return this.TblInf.Repr.LineHeaderRepr;
        }
        TableHeaderCellRepresentation GetLineOfColHeaderRepresentation(){
            return this.TblInf.Repr.ColHeaderRepr;
        }
        TableGeneralRepresentation GetTableGeneralRepresentation(){
            return this.TblInf.Repr.GenRepr;
        }
        //
        void SetTableRepresentation(TableRepresentation repr){
            this.TblInf.Repr=repr;
        }
        void SetContentCellRepresentation(TContentCellRepresentation repr){
            this.TblInf.Repr.ContentRepr=repr;
        }
        void GetColOfLineHeaderRepresentation(TableHeaderCellRepresentation repr){
            this.TblInf.Repr.LineHeaderRepr=repr;
        }
        void GetLineOfColHeaderRepresentation(TableHeaderCellRepresentation repr){
            this.TblInf.Repr.ColHeaderRepr=repr;
        }
        void GetTableGeneralRepresentation(TableGeneralRepresentation repr){
            this.TblInf.Repr.GenRepr=repr;
        }
        //
        TableUssagePolicy GetTableUssagePolicy(){
            return this.TblInf.UssagePolicy;
        }
        void GetTableUssagePolicy(TableUssagePolicy policy){
            this.TblInf.UssagePolicy=policy;
        }
        //
        public void SetSize(int QLines, int QColumns)
        {
            int QLinesNew=QLines, QColumnsNew=QColumns;
            if (QLines >= 1 && QLines <= MyLib.MaxInt && QColumns >= 1 && QColumns <= MyLib.MaxInt)
            {
                if(ContentCell!=null)MyLib.ResizeTable(ref ContentCell, GetQLines(), GetQColumns(), QLinesNew, QColumnsNew, 1);
                if (GetIfColOfLineHeaderExists()) MyLib.ResizeVector(ref ColOfLineHeader, GetQLines(), QLinesNew, 1);
                if (GetIfLineOfColHeaderExists()) MyLib.ResizeVector(ref LineOfColHeader, GetQColumns(), QColumnsNew, 1);
            }
        }
        public void SetTableName(string name) { }
        public void SetTableName1(string name) { }
        public void SetTableName2(string name) { }
        public void SetTableName(string name1, string name2) { }
        public void SetTableName(string name, int N) { }
        public void SetTableNameSize1() { }
        public void SetTableNameSize2() { }
        public void SetColOfLineHeaderSize1() { }
        public void SetColOfLineHeaderSize2() { }
        public void SetLineOfColHeaderSize1() { }
        public void SetLineOfColHeaderSize2() { }
        public void SetSpecCellSize(int Q) { }
        public void SetLinesGeneralName(string name) { }
        public void SetColsGeneralName(string name) { }
        //
        
        //
        //Any Cell
        //
        public  int GetTypeN(int LineN, int ColN){
            int TypeN;
            TypeN=0;
            TCell cell;
            cell=GetCell(LineN, ColN);
            if (cell != null) TypeN = cell.GetTypeN();
            return TypeN;
        }
        public int GetActiveN(int LineN, int ColN)
        {
            int ActiveN;
            ActiveN = 0;
            TCell cell;
            cell = GetCell(LineN, ColN);
            if (cell != null) ActiveN = cell.GetActiveN();
            return ActiveN;
        }
        //public  void SetActiveN(int LineN, int ColN, int ValN){
        //    TCell cell;
        //    cell=GetCell(LineN, ColN);
        //    if (cell != null)
        //    {
        //        if (LineN == 0)
        //        {
        //            if(GetIfColumnNExists(ColN)){
        //                if(this.TblInf.Str.ColOfLineHeaderExists==true){
        //                    if(LineOfColHeader!=null){
        //                        LineOfColHeader[ColN-1].SetActiveN(ValN);
        //                    }
        //                }
        //            }
        //        }
        //        else if (ColN == 0)
        //        {
        //            if(GetIfLineNExists(LineN)){
        //                if(this.TblInf.Str.ColOfLineHeaderExists==true){
        //                    if(ColOfLineHeader!=null){
        //                        ColOfLineHeader[ColN-1].SetActiveN(ValN);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (GetIfColumnNExists(ColN) && GetIfLineNExists(LineN))
        //            {
        //                if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
        //                {
        //                    ContentCell[LineN - 1][ColN - 1].SetActiveN(ValN);
        //                }
        //                else
        //                {
        //                    ContentCell[ColN - 1][LineN - 1].SetActiveN(ValN);
        //                }
        //            }
        //        }
        //    }
        //}
        public void SetActiveN(int LineN, int ColN, int ValN)
        {
            TCell cell;
            cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetActiveN(ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetActiveN(ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetActiveN(ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetActiveN(ValN);
                    }
                }
            }
        }
        public  int GetLength(int LineN, int ColN){
            int LR;
            TCell cell=GetCell(LineN, ColN);
            LR=cell.GetLength();
            return LR;
        }
        public  void SetLength(int LineN, int ColN, int L){
            TCell cell;
            cell=GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetLength(L);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetLength(L);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetLength(L);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetLength(L);
                    }
                }
            }
        }
        //
        public  double GetDoubleVal(int LineN, int ColN){
            double dr;
            dr = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                dr = cell.GetDoubleVal();
            }
            return dr;
        }
        public float GetFloatVal(int LineN, int ColN)
        {
            float fr;
            fr = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                fr = cell.GetFloatVal();
            }
            return fr;
        }
        public int GetIntVal(int LineN, int ColN)
        {
            int ir;
            ir = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                ir = cell.GetIntVal();
            }
            return ir;
        }
        public bool GetBoolVal(int LineN, int ColN)
        {
            bool br;
            br = false;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                br = cell.GetBoolVal();
            }
            return br;
        }
        public string ToString(int LineN, int ColN){
            string sr;
            sr = "";
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public double GetDoubleValN(int LineN, int ColN, int ValN)
        {
            double dr;
            dr = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                dr = cell.GetDoubleValN(ValN);
            }
            return dr;
        }
        public float GetFloatValN(int LineN, int ColN, int ValN)
        {
            float fr;
            fr = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                fr = cell.GetFloatValN(ValN);
            }
            return fr;
        }
        public int GetIntValN(int LineN, int ColN, int ValN)
        {
            int ir;
            ir = 0;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                ir = cell.GetIntValN(ValN);
            }
            return ir;
        }
        public bool GetBoolValN(int LineN, int ColN, int ValN)
        {
            bool br;
            br = false;
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                br = cell.GetBoolValN(ValN);
            }
            return br;
        }
        public string ToStringN(int LineN, int ColN, int ValN)
        {
            string sr;
            sr = "";
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public void SetByDoubleVal(int LineN, int ColN, double val){
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByDoubleVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByDoubleVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByDoubleVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByDoubleVal(val);
                    }
                }
            }
        }
        public void SetByFloatVal(int LineN, int ColN, float val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByFloatVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByFloatVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByFloatVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByFloatVal(val);
                    }
                }
            }
        }
        public void SetByIntVal(int LineN, int ColN, int val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByIntVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByIntVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByIntVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByIntVal(val);
                    }
                }
            }
        }
        public void SetByBoolVal(int LineN, int ColN, bool val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByBoolVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByBoolVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByBoolVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByBoolVal(val);
                    }
                }
            }
        }
        public void SetByStringVal(int LineN, int ColN, string val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByStringVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByStringVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByStringVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByStringVal(val);
                    }
                }
            }
        }
        //
        public void SetByDoubleValN(int LineN, int ColN, double val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByDoubleValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByDoubleValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByDoubleValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByDoubleValN(val, ValN);
                    }
                }
            }
        }
        public void SetByFloatValN(int LineN, int ColN, float val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByFloatValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByFloatValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByFloatValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByFloatValN(val, ValN);
                    }
                }
            }
        }
        public void SetByIntValN(int LineN, int ColN, int val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByIntValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByIntValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByIntValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByIntValN(val, ValN);
                    }
                }
            }
        }
        public void SetByBoolValN(int LineN, int ColN, bool val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByBoolValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByBoolValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByBoolValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByBoolValN(val, ValN);
                    }
                }
            }
        }
        public void SetByStringValN(int LineN, int ColN, string val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByStringValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByStringValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByStringValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByStringValN(val, ValN);
                    }
                }
            }
        }
        //
        public void SetVal(int LineN, int ColN, double val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, int val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, bool val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, string val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        //
        public void SetValN(int LineN, int ColN, double val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, int val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, bool val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, string val, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        //
        public void DelValN(int LineN, int ColN, int ValN)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].DelValN(ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].DelValN(ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].DelValN(ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].DelValN(ValN);
                    }
                }
            }
        }
        //
        public void SetDoubleValAndType(int LineN, int ColN, double val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1] = new TCellDouble(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1] = new TCellDouble(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1] = new TCellDouble(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1] = new TCellDouble(val);
                    }
                }
            }
        }
        public void SetFloatValAndType(int LineN, int ColN, float val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1] = new TCellFloat(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1] = new TCellFloat(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1] = new TCellFloat(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1] = new TCellFloat(val);
                    }
                }
            }
        }
        public void SetIntValAndType(int LineN, int ColN, int val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1] = new TCellInt(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1] = new TCellInt(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1] = new TCellInt(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1] = new TCellInt(val);
                    }
                }
            }
        }
        public void SetBoolValAndType(int LineN, int ColN, bool val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1] = new TCellBool(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1] = new TCellBool(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1] = new TCellBool(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1] = new TCellBool(val);
                    }
                }
            }
        }
        public void SetStringValAndType(int LineN, int ColN, string val)
        {
            TCell cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1] = new TCellString(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1] = new TCellString(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1] = new TCellString(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1] = new TCellString(val);
                    }
                }
            }
        }
        //
        //Content
        //
        //
        //ColOfLineHeader
        //
        //
        //LineOfColHeader
        // 
        //
        //
        //Show
        //
        public int GetMaxLength(){
            int curL, maxL, QL, QC, ErstLN, ErstCN;
            TCell cell;
            QL=GetQLines(); QC=GetQColumns();
            cell=GetCell(1-1,1-1);
            maxL=(cell.ToString()).Length;
            if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==true){
                ErstLN=0; ErstCN=0;
            }else if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==false){
                ErstLN=0; ErstCN=1;
            }else if(GetIfLineOfColHeaderExists()==false && GetIfColOfLineHeaderExists()==true){
                ErstLN=1; ErstCN=0;
            }else{
                 ErstLN=1; ErstCN=1;
            }
            for(int i=ErstLN; i<=QL; i++){
                for(int j=ErstCN; j<=QC; j++){
                    cell=GetCell(i,j);
                    curL=(cell.ToString()).Length;
                    if(curL>maxL) maxL=curL;
                }
            }
            return maxL;
        }
        private void GetMaxColLength(int[] ColMaxL, ref int ErstCN, ref int QColumns){
            int curL, maxL, QL, ErstLN;//, QC, ErstCN;
            TCell cell;
            QL=GetQLines(); QColumns=GetQColumns();
            ColMaxL=new int[QColumns+1];
            if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==true){
                ErstLN=0; ErstCN=0;
            }else if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==false){
                ErstLN=0; ErstCN=1;
                ColMaxL[0]=0;
            }else if(GetIfLineOfColHeaderExists()==false && GetIfColOfLineHeaderExists()==true){
                ErstLN=1; ErstCN=0;
            }else{
                ErstLN=1; ErstCN=1;
                ColMaxL[0]=0;
            }
            for(int j=ErstCN; j<=QColumns; j++){
                cell=GetCell(1-1,j);
                maxL=(cell.ToString()).Length;
                for(int i=ErstLN; i<=QL; i++){
                    cell=GetCell(i,j);
                    curL=(cell.ToString()).Length;
                    if(curL>maxL) maxL=curL;
                }
                ColMaxL[j]=maxL;
            }
        }
        public string GetCorner()
        {
            TCell cell;
            string s;
            s="";
            bool LineOfColHeaderExists=GetIfLineOfColHeaderExists();
            bool ColOfLineHeaderExists=GetIfColOfLineHeaderExists();
            bool LinesGeneralNameExists = GetIfLineOfColHeaderExists();
            bool ColsGeneralNameExists = GetIfColOfLineHeaderExists();
            string LinesGeneralName = GetLinesGeneralName();
            string ColumnsGeneralName = GetColsGeneralName();
            if (LineOfColHeaderExists == true && ColOfLineHeaderExists == true)
            {
                if (ColumnsGeneralName != "" && LinesGeneralName != "")
                {
                    s = GetLinesGeneralName() + "\\" + GetColsGeneralName();
                }
                else if (GetColsGeneralName() !="" && GetLinesGeneralName() =="")
                {
                    s = GetColsGeneralName();
                }
                else if (GetColsGeneralName() == "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName();
                }//else s="";
            }
            else if (LineOfColHeaderExists == false && ColOfLineHeaderExists == true)
            {
                cell=GetCell(1,0);
                if (GetColsGeneralName() != "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName() + "\\" + GetColsGeneralName()+": "+cell.ToString();
                }
                else if (GetColsGeneralName() != "" && GetLinesGeneralName() == "")
                {
                    s = GetColsGeneralName()+": "+cell.ToString();
                }
                else if (GetColsGeneralName() == "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName()+": "+cell.ToString();
                }
            }
            else if (LineOfColHeaderExists == true && ColOfLineHeaderExists == false)
            {
                cell=GetCell(0,1);
                if (GetColsGeneralName() != "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName() + "\\" + GetColsGeneralName()+": "+cell.ToString();
                }
                else if (GetColsGeneralName() != "" && GetLinesGeneralName() == "")
                {
                    s = GetColsGeneralName()+": "+cell.ToString();
                }
                else if (GetColsGeneralName() == "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName()+": "+cell.ToString();
                }
            }
            else if (LineOfColHeaderExists == false && ColOfLineHeaderExists == false)
            {
                cell = GetCell(1, 1);
                if (GetColsGeneralName() != "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName() + "\\" + GetColsGeneralName() + ": " + cell.ToString();
                }
                else if (GetColsGeneralName() != "" && GetLinesGeneralName() == "")
                {
                    s = GetColsGeneralName() + ": " + cell.ToString();
                }
                else if (GetColsGeneralName() == "" && GetLinesGeneralName() != "")
                {
                    s = GetLinesGeneralName() + ": " + cell.ToString();
                }
            }
            return s;
        }
        //public string GetHeaderCellCoSupplInf(int LineN, int ColN, TableRepresentation ReprExt){
            //this.TblInf.Repr.ColHeaderRepr
            //this.TblInf.Repr.LineHeaderRepr
        //    THeaderCellRepresentation Repr;
        //    string s, s_ownVal;
        //    TCell cell;
        //    cell=GetCell(N, 0);
        //    if(cell==null){
        //        Repr=null;
        //        if(ReprExt==null){
        //            if(LineN==0) Repr=GetLineOfColHeaderRepresentation();
        //            if(ColN==0) Repr=GetColOfLineHeaderRepresentation();
        //        }
        //        cell=GetCell(LineN,ColN);
        //        if(cell!=null)s_ownVal=cell.ToString();else s_ownVal="";
        //        if(Repr==null) s=s_ownVal="";
        //        else{
        //            if(LineN==0){

        //            }
        //            if(ColN==0) Repr=GetColOfLineHeaderRepresentation();
        //            }
        //    }
        //    return s;
        //}
        public string GetLineHeaderCellCoSupplInf(int N, TableHeaderCellRepresentation ReprExt){
            //this.TblInf.Repr.ColHeaderRepr
            //this.TblInf.Repr.LineHeaderRepr
            TableHeaderCellRepresentation Repr;
            string s, s_ownVal;
            TCell cell;
            cell=GetCell(N, 0);
            s="";
            if(cell!=null){
                Repr=null;
                if(ReprExt==null) Repr=GetColOfLineHeaderRepresentation();
                s_ownVal=cell.ToString();
                if(Repr.InBrackets) s=s+"[";
                if(Repr.GenRowNameBef) s=s+GetLinesGeneralName();
                if(Repr.RowNBef){
                    switch(Repr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7){
                        case 1:
                            s+=" N";
                            break;
                        case 2:
                            s+=" NCol ";
                            break;
                        case 3:
                            s+=" ColN ";
                            break;
                        case 4:
                            s+=" Col ";
                            break;
                        case 5:
                            s+=" NLine ";
                            break;
                        case 6:
                            s+=" LineN ";
                            break;
                        case 7:
                            s+=" Line ";
                            break;
                    }
                    //
                    s=s+N.ToString();
                    //
                    switch(Repr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7){
                        case 1:
                            s+=") ";
                            break;
                        case 2:
                            s+="th ";
                            break;
                        case 3:
                            s+="th Line ";
                            break;
                        case 4:
                            s+="th Col ";
                            break;
                        case 5:
                            s+=": ";
                            break;
                        case 6:
                            s+="- ";
                            break;
                        case 7:
                            s+=", ";
                            break;
                    }
                }
                //
                if(Repr.RowName){
                    s+=s+" ";
                    s=s+s_ownVal;
                    s+=s+" ";
                }
                //
                if(Repr.GenRowNameAft) s+=GetLinesGeneralName();
                //
                if(Repr.RowNAft){
                    switch(Repr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7){
                        case 1:
                            s+="N";
                            break;
                        case 2:
                            s+="NCol ";
                            break;
                        case 3:
                            s+="ColN ";
                            break;
                        case 4:
                            s+="Col ";
                            break;
                        case 5:
                            s+="NLine ";
                            break;
                        case 6:
                            s+="LineN ";
                            break;
                        case 7:
                            s+="Line ";
                            break;
                    }
                    //
                    s=s+N.ToString();
                    //
                    switch(Repr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7){
                        case 1:
                            s+=") ";
                            break;
                        case 2:
                            s+="th ";
                            break;
                        case 3:
                            s+="th Line ";
                            break;
                        case 4:
                            s+="th Col ";
                            break;
                        case 5:
                            s+=": ";
                            break;
                        case 6:
                            s+="- ";
                            break;
                        case 7:
                            s+=", ";
                            break;
                    }
                }
                //
                if(Repr.InBrackets) s=s+"]";
            }
            return s;
        }
        public string GetLineHeaderCellCoSupplInf(int N, TableRepresentation ReprExt){
            string s_OwnVal, s_AllInf, s_FinFormatted;
            s_FinFormatted=""; s_AllInf="";
            TableGeneralRepresentation ReprGen;
            TableHeaderCellRepresentation ReprCell;
            TCell cell;
            cell=GetCell(N,0);
            if(cell!=null){
                s_OwnVal=cell.ToString();
                if(ReprExt==null){
                    ReprCell=GetColOfLineHeaderRepresentation();
                }
                else{
                    ReprCell=ReprExt.LineHeaderRepr;
                }
                s_AllInf=GetLineHeaderCellCoSupplInf(N, ReprExt);
                s_FinFormatted=MyLib.
            }
            return s_FinFormatted;
        }
        public string CellToStringWithSupplInf(int LineN, int ColN, TableRepresentation repr)
        {
            string s_cellOwnVal, s_SupplInf, s_wholeInf, s_Format, s_Fin, s;
            TCell cell, ContentCell, LineOfColHeader, ColOfLineHeader;
            cell = GetCell(LineN, ColN);
            if (cell != null)
            {
                
                if (LineN == 0 && ColN == 0)
                {
                    s_cellOwnVal = GetCorner();
                    s_SupplInf="";
                    s_wholeInf=s_cellOwnVal;
                }
                else
                {
                    //Own Val
                    s_cellOwnVal = cell.ToString();
                    //Suppl inf
                    if (LineN == 0 || ColN == 0){
                        
                    }else{

                    }
                
            }

            return s_Fin;
        }//fn
    }//cl
}//ns
