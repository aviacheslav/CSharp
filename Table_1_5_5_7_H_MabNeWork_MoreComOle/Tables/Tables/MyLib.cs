using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.IO;//sTREAMwRITER
using System.Windows.Forms;
//
//mark1 - 1672,
//mark2- no,
//fin -   1865 
//
namespace Tables
{
    
    public class TValsShowHide
    {
        public int Show1Hide0;
        public bool ConsoleInterface;
        public StreamWriter file;
        public ListBox box;
        public string FileToAppendName;
        public TValsShowHide()
        {
            Show1Hide0 = 1;
            ConsoleInterface = false;
            file = null;
            box=null;
            FileToAppendName = "";
        }
        public TValsShowHide(int Show1Hide0, int ConsoleInterfaceNo1Yes1, StreamWriter file,ListBox box)
        {
            this.Show1Hide0 = Show1Hide0;
            this.ConsoleInterface = MyLib.IntToBool(ConsoleInterfaceNo1Yes1);
            this.file = file;
            this.box = box;
        }
        public void EnableWriting(){Show1Hide0=1;}
        public void DisableWriting(){Show1Hide0=0;}
        /*public void SetConsoleInterface(int ConsoleInterface){
            this.ConsoleInterface=MyLib.IntToBool(ConsoleInterface);
        }
        public void SetFile(StreamWriter file){this.file=file;}
        public void SetFile(ListBox box){this.box=box;}*/
    }

    public class StringShaublin
    {
        public int ReqLen, Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, ErstIfCut;
        public bool IsNum, SpaceNotUL;
        public StringShaublin()
        {
            ReqLen = 6;
            Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 1;
            ErstIfCut = 1;
            IsNum = false;
            SpaceNotUL = true;
        }
        public StringShaublin(int AlignmentN, int Length)
        {
            ReqLen = Length;
            Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = AlignmentN;
            ErstIfCut = 1;
            IsNum = false;
            SpaceNotUL = true;
        }
        public void AlignLeft(){Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6=1;}
        public void AlignRight() { Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 4; }
        public void AlignCenterLeft() { Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 2; }
        public void AlignCenterRight() { Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 3; }
        public void SetAlignmentAsInExcel() { Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 5; }
        public void SetAlignmentAsInExcelCenter() { Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = 6; }
        public void SetNoHidden() { ErstIfCut = 1; }
        public void HideOneMore() { ErstIfCut += 1; }
        public void HideOneLess() { ErstIfCut -= 1; }
        public void SetLength(int L) { if(L>1 && L<MyLib.MaxInt) ReqLen = L; else ReqLen=5;}
    }
    
    public static class MyLib
    {
        public const int MaxInt = 65000;
        public const bool BoolValByDefault = false;
        //
        //public static string ReturnByShaublin(string Word, int ReqLen, bool IsNum, int Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, int ErstIfCut, bool SpaceNotUL)
        //{
        //    //ReqLen>=5!
        //    string s, sc, sp;
        //    //char[] ca = s.ToCharArray();
        //    sc = "";
        //    int L, Erst, LHalf, N1Max;
        //    bool EvenNotOdd;
        //    L = Word.Length;
        //    if (SpaceNotUL) sp = " ";
        //    else sp = "_";
        //    if (L > ReqLen)
        //    {
        //        N1Max = L - (ReqLen - 2) + 1;
        //        if (ErstIfCut > 1 && ErstIfCut <= N1Max)
        //        {
        //            Erst = ErstIfCut;
        //        }
        //        else
        //        {
        //            Erst = 1;
        //        }
        //        //s = Word.SubString(Erst, ReqLen - 2);
        //        s = Word.Substring(Erst-1, ReqLen - 2);
        //        if (Erst == 1)
        //        {
        //            s += ">>";
        //        }
        //        else
        //        {
        //            if (Erst + ReqLen - 2 - 1 == L)
        //            {
        //                s = "<<" + s;
        //            }
        //            else
        //            {
        //                s = "<" + s + ">";
        //            }
        //        }
        //    }
        //    else if (ReqLen > L)
        //    {
        //        s = Word;
        //        switch (Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6)
        //        {
        //            case 1:
        //                for (int i = 1; i <= ReqLen - L; i++)
        //                {
        //                    s += sp;
        //                }
        //                break;
        //            case 2:
        //                for (int i = 1; i <= ReqLen - L; i++)
        //                {
        //                    sc += sp;

        //                }
        //                s = sc + s;
        //                break;
        //            case 3:
        //                EvenNotOdd = ((ReqLen - L) % 2 == 0);
        //                if (EvenNotOdd)
        //                {
        //                    LHalf = (ReqLen - L) / 2;
        //                    for (int i = 1; i <= LHalf; i++)
        //                    {
        //                        sc += sp;
        //                    }
        //                    s = sc + s + sc;
        //                }
        //                else
        //                {
        //                    LHalf = (ReqLen - L - 1) / 2;
        //                    for (int i = 1; i <= LHalf; i++)
        //                    {
        //                        sc += sp;
        //                    }
        //                    s = sc + s + sp + sc;
        //                }
        //                break;
        //            case 4:
        //                EvenNotOdd = ((ReqLen - L) % 2 == 0);
        //                if (EvenNotOdd)
        //                {
        //                    LHalf = (ReqLen - L) / 2;
        //                    for (int i = 1; i <= LHalf; i++)
        //                    {
        //                        sc += sp;
        //                    }
        //                    s = sc + s + sc;
        //                }
        //                else
        //                {
        //                    LHalf = (ReqLen - L - 1) / 2;
        //                    for (int i = 1; i <= LHalf; i++)
        //                    {
        //                        sc += sp;
        //                    }
        //                    s = sc + sp + s + sc;
        //                }
        //                break;
        //            case 5:
        //                if (IsNum)
        //                {
        //                    for (int i = 1; i <= ReqLen - L; i++)
        //                    {
        //                        sc += sp;

        //                    }
        //                    s = sc + s;
        //                }
        //                else
        //                {
        //                    for (int i = 1; i <= ReqLen - L; i++)
        //                    {
        //                        s += sp;
        //                    }
        //                }
        //                break;
        //            case 6:
        //                if (IsNum)
        //                {
        //                    EvenNotOdd = ((ReqLen - L) % 2 == 0);
        //                    if (EvenNotOdd)
        //                    {
        //                        LHalf = (ReqLen - L) / 2;
        //                        for (int i = 1; i <= LHalf; i++)
        //                        {
        //                            sc += sp;
        //                        }
        //                        s = sc + s + sc;
        //                    }
        //                    else
        //                    {
        //                        LHalf = (ReqLen - L - 1) / 2;
        //                        for (int i = 1; i <= LHalf; i++)
        //                        {
        //                            sc += sp;
        //                        }
        //                        s = sc + sp + s + sc;
        //                    }
        //                }
        //                else
        //                {
        //                    EvenNotOdd = ((ReqLen - L) % 2 == 0);
        //                    if (EvenNotOdd)
        //                    {
        //                        LHalf = (ReqLen - L) / 2;
        //                        for (int i = 1; i <= LHalf; i++)
        //                        {
        //                            sc += sp;
        //                        }
        //                        s = sc + s + sc;
        //                    }
        //                    else
        //                    {
        //                        LHalf = (ReqLen - L - 1) / 2;
        //                        for (int i = 1; i <= LHalf; i++)
        //                        {
        //                            sc += sp;
        //                        }
        //                        s = sc + s + sp + sc;
        //                    }
        //                }
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        s = Word;
        //    }
        //    return s;
        //}
        public static string ReturnByShaublin(string Word, StringShaublin ReprExt)
        {
            //ReqLen>=5!
            StringShaublin repr;
            if(ReprExt!=null) repr=ReprExt; else repr=new StringShaublin();
            int ReqLen, Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, ErstIfCut;
            bool IsNum, SpaceNotUL;
            //
            ReqLen=repr.ReqLen;
            Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6 = repr.Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6;
            ErstIfCut = repr.ErstIfCut; ;
            IsNum = repr.IsNum;
            SpaceNotUL= repr.SpaceNotUL;
            //
            string s, sc, sp;
            //char[] ca = s.ToCharArray();
            sc = "";
            int L, Erst, LHalf, N1Max;
            bool EvenNotOdd;
            L = Word.Length;
            if (SpaceNotUL) sp = " ";
            else sp = "_";
            if (L > ReqLen)
            {
                N1Max = L - (ReqLen - 2) + 1;
                if (ErstIfCut > 1 && ErstIfCut <= N1Max)
                {
                    Erst = ErstIfCut;
                }
                else
                {
                    Erst = 1;
                }
                //s = Word.SubString(Erst, ReqLen - 2);
                s = Word.Substring(Erst - 1, ReqLen - 2);
                if (Erst == 1)
                {
                    s += ">>";
                }
                else
                {
                    if (Erst + ReqLen - 2 - 1 == L)
                    {
                        s = "<<" + s;
                    }
                    else
                    {
                        s = "<" + s + ">";
                    }
                }
            }
            else if (ReqLen > L)
            {
                s = Word;
                switch (Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6)
                {
                    case 1:
                        for (int i = 1; i <= ReqLen - L; i++)
                        {
                            s += sp;
                        }
                        break;
                    case 2:
                        for (int i = 1; i <= ReqLen - L; i++)
                        {
                            sc += sp;

                        }
                        s = sc + s;
                        break;
                    case 3:
                        EvenNotOdd = ((ReqLen - L) % 2 == 0);
                        if (EvenNotOdd)
                        {
                            LHalf = (ReqLen - L) / 2;
                            for (int i = 1; i <= LHalf; i++)
                            {
                                sc += sp;
                            }
                            s = sc + s + sc;
                        }
                        else
                        {
                            LHalf = (ReqLen - L - 1) / 2;
                            for (int i = 1; i <= LHalf; i++)
                            {
                                sc += sp;
                            }
                            s = sc + s + sp + sc;
                        }
                        break;
                    case 4:
                        EvenNotOdd = ((ReqLen - L) % 2 == 0);
                        if (EvenNotOdd)
                        {
                            LHalf = (ReqLen - L) / 2;
                            for (int i = 1; i <= LHalf; i++)
                            {
                                sc += sp;
                            }
                            s = sc + s + sc;
                        }
                        else
                        {
                            LHalf = (ReqLen - L - 1) / 2;
                            for (int i = 1; i <= LHalf; i++)
                            {
                                sc += sp;
                            }
                            s = sc + sp + s + sc;
                        }
                        break;
                    case 5:
                        if (IsNum)
                        {
                            for (int i = 1; i <= ReqLen - L; i++)
                            {
                                sc += sp;

                            }
                            s = sc + s;
                        }
                        else
                        {
                            for (int i = 1; i <= ReqLen - L; i++)
                            {
                                s += sp;
                            }
                        }
                        break;
                    case 6:
                        if (IsNum)
                        {
                            EvenNotOdd = ((ReqLen - L) % 2 == 0);
                            if (EvenNotOdd)
                            {
                                LHalf = (ReqLen - L) / 2;
                                for (int i = 1; i <= LHalf; i++)
                                {
                                    sc += sp;
                                }
                                s = sc + s + sc;
                            }
                            else
                            {
                                LHalf = (ReqLen - L - 1) / 2;
                                for (int i = 1; i <= LHalf; i++)
                                {
                                    sc += sp;
                                }
                                s = sc + sp + s + sc;
                            }
                        }
                        else
                        {
                            EvenNotOdd = ((ReqLen - L) % 2 == 0);
                            if (EvenNotOdd)
                            {
                                LHalf = (ReqLen - L) / 2;
                                for (int i = 1; i <= LHalf; i++)
                                {
                                    sc += sp;
                                }
                                s = sc + s + sc;
                            }
                            else
                            {
                                LHalf = (ReqLen - L - 1) / 2;
                                for (int i = 1; i <= LHalf; i++)
                                {
                                    sc += sp;
                                }
                                s = sc + s + sp + sc;
                            }
                        }
                        break;
                }
            }
            else
            {
                s = Word;
            }
            return s;
        }
        //
        public static string StringFormat(string data, int inLength, int QHidden, int AlignL1R2CL3CR4, string FillAft=".", string FillBef=" ", string BefCut="<", string AftCut=">", string BefNonCut=" ", string AftNonCut=" ", string BefMark="+", string AftMark=" ", TValsShowHide vsh=null){
            string R="";
            int q=data.Length, dLLeft, dLRight, Li1, QHiddenAft, minL, curL=0, N1=0;
            string StrFull=data;
            string StrToPlace = "";
            string StrToIns;
            MyLib.writeln(vsh, "StringFormat starts working");
            if (q <= inLength) minL = q; else minL = inLength;
            MyLib.writeln(vsh, ("q=" + q.ToString() + "QHidden=" + QHidden.ToString() + " inLength=" + inLength.ToString() + " minL=" + minL.ToString()));
            if (QHidden >=minL){
                R="";
                MyLib.writeln(vsh, "nothing to show, all string is hidden");
            }else{
                MyLib.writeln(vsh, "Forming word part to show:"); 
                //if (q >= inLength)
                //{
                    //MyLib.writeln(vsh, "Possible to work: q=" + q.ToString() + ">= inLength=" + inLength.ToString());
                    //curL = minL - QHidden + 1;
                    if (QHidden == 0)
                    {
                        N1=0;
                        curL = minL;
                        MyLib.writeln(vsh, "QHidden=0=" + QHidden.ToString() + "curL=" + curL.ToString() + " = minL = " + minL.ToString());
                    }
                    else
                    {
                        N1=QHidden+1 - 1;
                        //MyLib.writeln(vsh, "q - QHidden="+(q - QHidden).ToString());
                        if (q - QHidden <= inLength)
                        {
                            curL = q - QHidden ;
                            MyLib.writeln(vsh, "q - QHidden=" + (q - QHidden).ToString() + " <= inLength=" + inLength.ToString() + " => curL = " + curL.ToString() + "q - QHidden=" + (q - QHidden).ToString());
                        }
                        else
                        {
                            curL = minL;
                            MyLib.writeln(vsh, "q - QHidden=" + (q - QHidden).ToString() + " > inLength=" + inLength.ToString() + " => curL = " + curL.ToString() + "minL=" + (minL).ToString());
                        }
                        
                    }
                    StrToPlace = StrFull.Substring(N1, curL);   
                    //for (int i = 1; i <= minL; i++)
                    //{
                    //    StrToPlace = StrToPlace+StrFull.Substring(QHidden+i-1, 1);
                    //    MyLib.writeln(vsh, StrToPlace); 
                    //}
                //}
                /*else//q<inLebgth
                {
                    if (QHidden == 0)
                    {
                        N1 = 0;
                        curL = minL;//minL=q
                        MyLib.writeln(vsh, "QHidden=0=" + QHidden.ToString() + "curL=" + curL.ToString() + " = minL = " + minL.ToString());
                    }
                    else
                    {
                        N1 = QHidden + 1 - 1;
                        //MyLib.writeln(vsh, "q - QHidden="+(q - QHidden).ToString());
                        if (q - QHidden <= inLength)
                        {
                            curL = q - QHidden;
                            MyLib.writeln(vsh, "q - QHidden=" + (q - QHidden).ToString() + " <= inLength=" + inLength.ToString() + " => curL = " + curL.ToString() + "q - QHidden=" + (q - QHidden).ToString());
                        }
                        else//no
                        {
                            curL = minL;
                            MyLib.writeln(vsh, "q - QHidden=" + (q - QHidden).ToString() + " > inLength=" + inLength.ToString() + " => curL = " + curL.ToString() + "minL=" + (minL).ToString());
                        }

                    }
                    StrToPlace = StrFull.Substring(N1, curL); 
                    StrToPlace = StrFull;

                }*/
                MyLib.writeln(vsh, "Word part to show: " + StrToPlace + "=from " + (N1+1).ToString() + " L=" + curL.ToString() + " of " + StrFull); 
                //if(vsh!=null){
                //    writeln(vsh, "StringFormat starts working");
                //}
                //if(vsh!=null){
                //     writeln(vsh, "q="+q.ToString()+" QHidden="+QHidden.ToString());
                //}
                Li1 = StrToPlace.Length;
                //if(vsh!=null){
                //    writeln(vsh,"q=",q.ToString()," StrFull=",StrFull," StrToPlace=",StrToPlace," QHidden=",QHidden.ToString()," Li1=",Li1.ToString());
                //}
                //
                //if(vsh!=null){
                //    writeln("justifying");
                //}
                if (AlignL1R2CL3CR4 == 1)
                {
                    dLLeft = 0;
                    dLRight = inLength - Li1;
                }
                else if (AlignL1R2CL3CR4 == 2)
                {
                    dLLeft = inLength - Li1;
                    dLRight = 0;
                }
                else if (AlignL1R2CL3CR4 == 3)
                {
                    if ((inLength - Li1) % 2 == 0)
                    {
                        dLLeft = (inLength - Li1) / 2;
                        dLRight = (inLength - Li1) / 2;
                    }
                    else
                    {
                        dLLeft = (inLength - Li1 - 1) / 2;
                        dLRight = (inLength - Li1) - dLLeft;
                    }
                }
                else if (AlignL1R2CL3CR4 == 4)
                {
                    if ((inLength - Li1) % 2 == 0)
                    {
                        dLLeft = (inLength - Li1) / 2;
                        dLRight = (inLength - Li1) / 2;
                    }
                    else
                    {
                        dLLeft = (inLength - Li1 - 1) / 2 + 1;
                        dLRight = (inLength - Li1) - dLLeft;
                    }
                }
                else
                {
                    dLLeft = 0;
                    dLRight = inLength - Li1;
                }
                //
                StrToIns = FillBef.Substring(0, 1);
                for (int i = 1; i <= dLLeft; i++)
                {
                    R = R + StrToIns;
                }
                R = R + StrToPlace;
                StrToIns = FillAft.Substring(0, 1);
                for (int i = 1; i <= dLRight; i++)
                {
                    R = R + StrToIns;
                }
                MyLib.writeln(vsh, "Formatting: dLLeft=" + dLLeft.ToString() + " dLRight=" + dLRight.ToString());
                MyLib.writeln(vsh, "R=" + R);
                //
                MyLib.writeln(vsh, "Marking cut before: QHidden=" + QHidden.ToString());
                if (QHidden == 0)
                {
                    R = BefNonCut + R;
                }
                else
                {
                    R = BefCut + R;
                }
                MyLib.writeln(vsh, "R=" + R);
                QHiddenAft = (q - QHidden) - Li1;
                MyLib.writeln(vsh, "Marking cut after: QHiddenAft=" + QHiddenAft.ToString());
                if (QHiddenAft > 0)
                {
                    R = R + AftCut;
                }
                else
                {
                    R = R + AftNonCut;
                }
                MyLib.writeln(vsh, "Marking");
                R = BefMark + R + AftMark;
                MyLib.writeln(vsh, "R=" + R);
            }
            MyLib.writeln(vsh, "finally R="+R);
            MyLib.writeln(vsh, "StringFormat finishes working");
            return R;
        }//fn
        //
        /*
        public static string ReturnByShaublin(string s, int ReqLen, int Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, int ErstIfCut)
        {
            string r;
            r = ReturnByShaublin(s, ReqLen, false, Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, ErstIfCut, true);
            return r;
        }
        public static string ReturnByShaublin(string s, int ReqLen, int Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6)
        {
            string r;
            r = ReturnByShaublin(s, ReqLen, false, Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, 1, true);
            return r;
        }*/
        //
        //
        //public static int CompareString(string str1, string str2, int L1, int L2)
        public static int CompareStrings_E0L1G2(char[] s1, char[] s2, int L1, int L2)
        {
            bool contin, IsEqual;// verdict;
            int LMin, Result_ET0_LT1_GT1;
            //char[] s1=str1.ToCharArray();
            //char[] s2 = str1.ToCharArray();
            if (L1 > s1.Length|| L1<=0) L1 = s1.Length;
            if (L2 > s2.Length || L2 <= 0) L2 = s2.Length;
            if (L1 <= L2) LMin = L1; else LMin = L2;
            //verdict = false;
            Result_ET0_LT1_GT1 = 0;
            int n = 0;
            IsEqual = true;
            contin = true;
            while (contin)
            {
                n++;
                if (s1[n - 1] < s2[n - 1])
                {
                    contin = false;
                    //verdict = false;
                    IsEqual = false;
                    Result_ET0_LT1_GT1 = 1;
                }
                else if (s1[n - 1] > s2[n - 1])
                {
                    contin = false;
                    //verdict = true;
                    IsEqual = false;
                    Result_ET0_LT1_GT1 = 2;
                }
                else if (n == LMin) contin = false;
            }
            if (IsEqual)
            {
                if (L1 < L2)
                {
                    //verdict = false;
                    Result_ET0_LT1_GT1 = 1;
                }
                else if (L1 > L2)
                {
                    //verdict = true;
                    Result_ET0_LT1_GT1 = 2;
                }//else =0;
            }
            //return verdict;
            return Result_ET0_LT1_GT1;
        }
        //
        //
        public static void EncodeBooleanArray(bool[] options, int L, ref int CodeNumber)
        {
            int BaseDec = 2;
            L=options.Length;
            int []digit;
            digit = new int[L];
            CodeNumber = 0;
            for (int i = 1; i <= L; i++)
            {
                digit[i - 1] = MyLib.BoolToInt(options[i - 1]);
                CodeNumber = CodeNumber * BaseDec + digit[i - 1] * (int)Math.Pow(BaseDec, i - 1);
            }
        }
        public static void DecodeBooleanArray(int CodeNumber, ref int Q, ref bool[] options)
        {
            int BaseDec, order;
            int [] digits;
            digits=null;
            BaseDec=2; order=0; options=null;
            NumberParse.IntToDigits(CodeNumber, BaseDec, ref digits, ref order);
            Q = order + 1;
            options =new bool[Q];
            for(int i=1; i<=Q;  i++){
                options[i-1]=IntToBool(digits[i-1]);
            }
        }
        //
        //
        //
        public static void Swap<T>(ref T x1, ref T x2)
        {
            T buf;
            buf = x1;
            x1 = x2;
            x2 = buf;
        }
        //
        //
        public static void FindInVector<T>(ref T[] x, int Q, int FromN, T x1, ref int count, ref int ErstN)
        {
            count = 0; ErstN = 0;
            if(Q>x.Length) Q=x.Length;
            if (x != null && x1!=null && FromN >= 1 && FromN <= Q)
            {
                for (int i = Q; i <= FromN; i--)
                {
                    if (x[i - 1].Equals(x1))
                    {
                        count++;
                        ErstN = i;
                    }
                }
            }
        }
        public static void SeekValInVector<T>(T[] X, int Q, T val, ref int[] Ns, ref int count, int FromN=1, int ToN=0)
        {
            Ns = null;
            count=0;
            Q=0;
            if(X!=null && (Q<1 || Q>X.Length)){
                Q=X.Length;
                if (ToN < 1)
                {
                    ToN = Q;
                }
            }
            for (int i = FromN; i <= ToN; i++)
            {
                if(X[i-1].Equals(val)){
                    MyLib.AddToVector(ref Ns, ref count, i);
                }
            }
        }
        public static bool IsSubVectorAtPos<T>(T[] Arr, T[]SubArr, int PosN, int ArrL=0, int SubArrL=0)
        {
            bool b = false;
            int CurN;
            T Cur;
            if (Arr != null && SubArr != null)
            {
                if (ArrL < 1 || ArrL > Arr.Length)
                {
                    ArrL = Arr.Length;
                }
                if (SubArrL < 1 || SubArrL > SubArr.Length)
                {
                    SubArrL = SubArr.Length;
                }
                if (PosN + SubArrL - 1 <= ArrL)
                {
                    b = true;
                    for (int i = 1; i <= SubArrL; i++)
                    {
                        CurN = PosN + i - 1;
                        if (Arr[CurN - 1].Equals(SubArr[i - 1]) == false)
                        {
                            b = false;
                        }
                    }
                }
            }
            return b;
        } 
        public static void SeekSubArr<T>(T[] Arr, T[] SubArr, ref int[] Ns, ref int count, int ArrL = 0, int SubArrL = 0, int FromN = 1, int ToN = 0)
        {
            count=0;
            Ns=null;
            if (Arr != null && SubArr != null)
            {
                if (ArrL < 1 || ArrL > Arr.Length)
                {
                    ArrL = Arr.Length;
                }
                if (SubArrL < 1 || SubArrL > SubArr.Length)
                {
                    SubArrL = SubArr.Length;
                }
                if (ToN < 1 || ToN > ArrL)
                {
                    ToN = ArrL;
                }
                //
                if (ToN - FromN + 1 >= SubArrL)
                {
                    //Ns = null;
                    for (int i = FromN; i <= ToN; i++)
                    {
                        if (IsSubVectorAtPos(Arr, SubArr, i))
                        {
                            MyLib.AddToVector(ref Ns, ref count, i);
                        }
                    }
                }
            }
        }//fn
        public static int FirstValInVectorPosN<T>(T[] Arr, int L, T val, int FromN = 1, int ToN = 0)
        {
            int R = 0;
            int[] Ns = null;
            int count = 0;
            SeekValInVector(Arr, L, val, ref Ns, ref count, FromN, ToN);
            if (Ns != null)
            {
                R = Ns[1 - 1];
            }
            return R;
        }
        public static int LastValInVectorPosN<T>(T[] Arr, int L, T val, int FromN = 1, int ToN = 0)
        {
            int R = 0;
            int[] Ns = null;
            int count = 0;
            SeekValInVector(Arr, L, val, ref Ns, ref count, FromN, ToN);
            if (Ns != null)
            {
                R = Ns[count - 1];
            }
            return R;
        }
        public static int FirstSubArrInVectorPosN<T>(T[] Arr, int ArrL, T[] SubArr, int SubArrL, int FromN = 1, int ToN = 0)
        {
            int R = 0;
            int[] Ns = null;
            int count = 0;
            SeekSubArr(Arr, SubArr, ref Ns, ref count, ArrL, SubArrL, FromN, ToN);
            //SeekValInVector(Arr, L, val, ref Ns, ref count, FromN, ToN);
            if (Ns != null)
            {
                R = Ns[1 - 1];
            }
            return R;
        }
        public static int LastSubArrInVectorPosN<T>(T[] Arr, int ArrL, T[] SubArr, int SubArrL, int FromN = 1, int ToN = 0)
        {
            int R = 0;
            int[] Ns = null;
            int count = 0;
            SeekSubArr(Arr, SubArr, ref Ns, ref count, ArrL, SubArrL, FromN, ToN);
            //SeekValInVector(Arr, L, val, ref Ns, ref count, FromN, ToN);
            if (Ns != null)
            {
                R = Ns[count - 1];
            }
            return R;
        }
        //
        public static void AddToVector<T>(ref T[] x, ref int L, T x1)
        {
            T[] y;
            //
            if (x == null) L = 0;
            else if (L > x.Length) L = x.Length;
            //
            y = new T[L + 1];
            for (int i = 1; i <= L; i++)
            {
                y[i - 1] = x[i - 1];
            }
            y[L + 1 - 1] = x1;
            x = new T[L + 1];
            for (int i = 1; i <= (L + 1); i++)
            {
                x[i - 1] = y[i - 1];
            }
            L = L + 1;
        }
        public static void DelInVector<T>(ref T[] x, ref int L, int N)
        {
            T[] y;
            if (L > x.Length) L = x.Length;
            y = new T[L- 1];
            for (int i = 1; i <= L-1; i++)
            {
                if (i < N) y[i - 1] = x[i - 1];
                else if(i>=N) y[i-1]=x[i+1-1];
            }
            x = new T[L- 1];
            for (int i = 1; i <= (L - 1); i++)
            {
                x[i - 1] = y[i - 1];
            }
        }
        public static void InsToVector<T>(ref T[] x, ref int L, T x1, int N)
        {
            T[] y;
            if (L > x.Length) L = x.Length;
            y = new T[L + 1];
            for (int i = 1; i <= (L + 1); i++)
            {
                if (i < N) y[i - 1] = x[i - 1];
                else if (i > N) y[i - 1] = x[i - 1 - 1];
                else
                {
                    if (N > L) N = L + 1;
                    y[i - 1] = x[N - 1];
                }
            }
            x = new T[L + 1];
            for (int i = 1; i <= (L + 1); i++)
            {
                x[i - 1] = y[i - 1];
            }
            L = L + 1;
        }
        public static void SubVectorByNs<T>(T[] x, ref T[] y, int L, int N1, int N2)
        {
            int L1 = N2 - N1 + 1;
            if (N2 > N1 && N1 >= 1 && N2 <= L && L <= MyLib.MaxInt && x != null)
            {
                y = new T[L1];
                for (int i = 1; i <= L1; i++)
                {
                    y[i - 1] = x[N1 + i - 1 - 1];
                }
            }
        }
        public static void SubVectorByQ<T>(T[] x, ref T[] y, int L, int N1, int L1)
        {
            int N2 = N1+L1-1;
            if (N2 > N1 && N1 >= 1 && N2 <= L && L <= MyLib.MaxInt && x != null)
            {
                y = new T[L1];
                for (int i = 1; i <= L1; i++)
                {
                    y[i - 1] = x[N1 + i - 1 - 1];
                }
            }
        }
        //
        public static void SwapInVector<T>(ref T[] x, int Q, int N1, int N2)
        {
            if(Q>x.Length)Q=x.Length;
            if(N1>=1 && N1<=Q && N2>=1 && N2<=Q && N1!=N2){
                Swap(ref x[N1-1], ref x[N2-1]);
            }
        }
        //
        public static void SortVectorUpsideDown<T>(ref T[] x, int L)
        {
            int Middle;
            if (L > x.Length) L = x.Length;
            bool IsEvenNotOdd = MyMathLib.IsEvenNotOdd(L);
            if (IsEvenNotOdd) Middle = L / 2;
            else Middle = (L-1) / 2;
            for (int i = 1; i <= Middle; i++)
            {
                Swap(ref x[i - 1], ref x[L - i - 1]);
            }
        }
        public static void ResizeVector<T>(ref T[] x, int LOld, int LNew, int PreserveVals_No0Yes1)
        {
            T[]y;
            int MinQ;
            //LOld = x.Length;
            y = null;
            if (LOld <= LNew) MinQ = LOld;
            else MinQ = LNew;
            if (LNew <= 0 || LNew > MyLib.MaxInt || LNew==LOld)
            {
                //NOp;
            }else{
                if (x == null)
                {
                    x = new T[LNew];
                }
                else
                {
                    if (PreserveVals_No0Yes1 == 0)
                    {
                        x = new T[LNew];
                    }
                    else
                    {
                        y = new T[LNew];
                        for (int i = 1; i <= MinQ; i++)
                        {
                            y[i - 1] = x[i-1];
                        }
                        x = new T[LNew];
                        for (int i = 1; i <= LNew; i++)
                        {
                            x[i - 1] = y[i - 1];
                        }
                    }
                }
            }
        }
        //
        public static void ShowVector<T>(T[] x, int Q, TValsShowHide vsh, string Caption, string MemberName, bool NumbersAreRequired)
        {
            string s;
            if (Q > x.Length) Q = x.Length;
            if (Caption != null) writeln(vsh, Caption);
            for (int i = 1; i <= Q; i++)
            {
                s="";
                if (MemberName != null)
                {
                    s += MemberName;
                    if (NumbersAreRequired)
                    {
                        s += "[ ";
                        s += i.ToString();
                        s += " ]";
                    }
                    s += "= ";
                }
                else
                {
                    if (NumbersAreRequired)
                    {
                        s += i.ToString();
                        s += " )";
                    }
                    s += " ";
                }
                s += x.ToString();
                writeln(vsh, s);
            }
        }
        //
        //
        public static void AddLineToTable<T>(ref T[][] x, T[] Line, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null)
            {
                y = new T[QLines+1][];
                for (int i = 1; i <= QLines+1; i++)
                {
                    y[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines + 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        if(i<(QLines+1)){
                            y[i-1][j-1]=x[i-1][j-1];
                        }else{
                            if(Line!=null){
                                y[i-1][j-1]=Line[j-1];
                            }
                        }
                    }
                }
                x = new T[QLines+1][];
                for (int i = 1; i <= QLines+1; i++)
                {
                    x[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines + 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        x[i-1][j-1]=y[i-1][j-1];
                    }
                }
                QLines=QLines+1;
            }
        }
        public static void InsLineToTable<T>(ref T[][] x, T[] Line, int N, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null && N>=1 && N<=QLines)
            {
                y = new T[QLines + 1][];
                for (int i = 1; i <= QLines+1; i++)
                {
                    y[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines + 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        if (i < N)
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                        else if (i > N)
                        {
                            y[i - 1][j - 1] = x[i-1 - 1][j - 1];
                        }
                        else
                        {
                            if (Line != null)
                            {
                                y[i - 1][j - 1] = Line[j - 1];
                            }
                        }
                    }
                }
                x = new T[QLines + 1][];
                for (int i = 1; i <= QLines+1; i++)
                {
                    x[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines + 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
                QLines = QLines + 1;
            }
        }
        public static void DelLineFromTable<T>(ref T[][] x, int N, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null && N >= 1 && N <= (QLines + 1))
            {
                y = new T[QLines - 1][];
                for (int i = 1; i <= QLines-1; i++)
                {
                    y[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines - 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        if (i < N)
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                        else if (i >= N)
                        {
                            y[i - 1][j - 1] = x[i + 1 - 1][j - 1];
                        }
                    }
                }
                    //for (int i = 1; i <= QLines ; i++)
                    //{
                    //    for (int j = 1; j <= QColumns; j++)
                    //    {
                    //        if (i < N)
                    //        {
                    //            y[i - 1][j - 1] = x[i - 1][j - 1];
                    //        }
                    //        else if (i > N)
                    //        {
                    //            y[i-1 - 1][j - 1] = x[i - 1][j - 1];
                    //        }
                    //    }
                    //}
                x = new T[QLines - 1][];
                for (int i = 1; i <= QLines-1; i++)
                {
                    x[i - 1] = new T[QColumns];
                }
                for (int i = 1; i <= QLines - 1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
                QLines = QLines - 1;
            }
        }//fn
        //
        public static void SwapLinesInTable<T>(ref T[][] x, int QLines, int QColumns, int N1, int N2)
        {
            if (N1 >= 1 && N1 >= QLines && N2 >= 1 && N2 <= QLines && N1 != N2)
            {
                for(int j=1; j<=QColumns; j++){
                    Swap(ref x[N1 - 1][j - 1], ref x[N2 - 1][j - 1]);
                }
            }
        }
        public static void SwapColumnsInTable<T>(ref T[][] x, int QLines, int QColumns, int N1, int N2)
        {
            if (N1 >= 1 && N1 >= QLines && N2 >= 1 && N2 <= QLines && N1 != N2)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    Swap(ref x[i - 1][N1 - 1], ref x[i - 1][N2 - 1]);
                }
            }
        }
        //
        public static void AddColumnToTable<T>(ref T[][] x, T[] Column, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null)
            {
                y = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new T[QColumns+1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns + 1; j++)
                    {
                        if (j < (QColumns + 1))
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                        else
                        {
                            if (Column != null)
                            {
                                y[i - 1][j - 1] = Column[i - 1];
                            }
                        }
                    }
                }
                x = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    x[i - 1] = new T[QColumns + 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns + 1; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
                QColumns = QColumns + 1;
            }
        }
        public static void InsColumnToTable<T>(ref T[][] x, T[] Column, int N, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null)
            {
                y = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new T[QColumns + 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns + 1; j++)
                    {
                        if (j < N)
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                        else if (j > N)
                        {
                            y[i - 1][j - 1] = x[i - 1][j-1 - 1];
                        }
                        else
                        {
                            if (Column != null)
                            {
                                y[i - 1][j - 1] = Column[i - 1];
                            }
                        }
                    }
                }
                x = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    x[i - 1] = new T[QColumns + 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns + 1; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
                QColumns = QColumns + 1;
            }
        }
        public static void DelColumnFromTable<T>(ref T[][] x, int N, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null)
            {
                y = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new T[QColumns - 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        if (j < N)
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                        else if (j > N)
                        {
                            y[i - 1][j-1 - 1] = x[i - 1][j - 1];
                        }
                        //else NOp
                    }
                }
                x = new T[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    x[i - 1] = new T[QColumns - 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns - 1; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
                QColumns = QColumns - 1;
            }
        }
        //
        public static void SortTableLinesUpsideDown<T>(ref T[][] x, int QLines, int QColumns)
        {
            int L, Middle;
            L = QLines;
            bool IsEvenNotOdd = MyMathLib.IsEvenNotOdd(L);
            if (IsEvenNotOdd) Middle = L / 2;
            else Middle = (L - 1) / 2;
            for (int i = 1; i <= Middle; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    Swap(ref x[i - 1][j - 1], ref x[L - i - 1][j - 1]);
                }
            }
        }
        public static void SortTableColumnsUpsideDown<T>(ref T[][] x,  int QLines,  int QColumns)
        {
            int L, Middle;
            L = QColumns;
            bool IsEvenNotOdd = MyMathLib.IsEvenNotOdd(L);
            if (IsEvenNotOdd) Middle = L / 2;
            else Middle = (L - 1) / 2;
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= Middle; j++)
                {
                    Swap(ref x[i - 1][j - 1], ref x[i - 1][L - j - 1]);
                }
            }
        }
        //
        public static void TransposeTable<T>(ref T[][] x, ref int QLines, ref int QColumns)
        {
            T[][] y;
            y = null;
            if (x != null)
            {
                y = new T[QColumns][];
                for (int i = 1; i <= QColumns; i++)
                {
                    y[i - 1] = new T[QLines];
                }
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        y[i - 1][j - 1] = x[j - 1][i - 1];
                    }
                }
            }
            x = y;
            Swap(ref QLines, ref QColumns);
        }
        //
        public static void ResizeTable<T>(ref T[][] x, int QLinesOld, int QColumnsOld, int QLinesNew, int QColumnsNew, int PreserveVals_No0Yes1)
        {
            
            T[][] y;
            int MinQLines, MinQColumns;
            //LOld = x.Length;
            y = null;
            if (QLinesOld <= QLinesNew) MinQLines = QLinesOld; else MinQLines = QLinesNew;
            if (QColumnsOld <= QColumnsNew) MinQColumns = QColumnsOld; else MinQColumns = QColumnsNew;
            if (QLinesNew <= 0 || QLinesNew > MyLib.MaxInt || QColumnsOld <= 0 || QColumnsNew > MyLib.MaxInt || (QLinesOld == QLinesNew && QColumnsOld == QColumnsNew))
            {
                //NOp;
            }
            else
            {
                if (PreserveVals_No0Yes1 == 1)
                {
                    y = new T[QLinesNew][];
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        y[i - 1] = new T[QColumnsNew];
                    }
                    //
                    for (int i = 1; i <= MinQLines; i++)
                    {
                        for (int j = 1; j <= MinQColumns; j++)
                        {
                            y[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                    }
                    //
                    x = new T[QLinesNew][];
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        x[i - 1] = new T[QColumnsNew];
                    }
                    //
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        for (int j = 1; j <= QColumnsNew; j++)
                        {
                            x[i - 1][j - 1] = y[i - 1][j - 1];
                        }
                    }
                }
                else
                {
                    x = new T[QLinesNew][];
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        x[i - 1] = new T[QColumnsNew];
                    }
                }
            }
        }
        //
        /*public static bool operator >(string s1, string s2)
        {
            bool b;

            return b;
        }
        public static bool operator <(string s1, string s2)
        {
            bool b;

            return b;
        }*/
        //
        public static void LineFromTable<T>(T[][] x, int QLines, int QColumns, ref T[] y, int N)
        {
            if (x == null || N < 1 || N > QLines) y = null;
            else
            {
                y = new T[QColumns];
                for (int j = 1; j <= QColumns; j++)
                {
                    y[j - 1] = x[N - 1][j - 1];
                }
            }
        }
        public static void ColumnFromTable<T>(T[][] x, int QLines, int QColumns, ref T[] y, int N)
        {
            if (x == null || N < 1 || N > QLines) y = null;
            else
            {
                y = new T[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = x[i - 1][N - 1];
                }
            }
        }
        public static void SubTableByNs<T>(T[][] x, ref T[][] y, int QLinesOrig, int QColumnsOrig, int Line1N, int Column1N, int Line2N, int Column2N, ref int QLinesRes, ref int QColumnsRes)
        {
            if (x == null) y = null;
            else if (Line1N < Line2N && Line1N >= 1 && Line2N <= QLinesOrig && Column1N < Column2N && Column1N >= 1 && Column2N <= QColumnsOrig && x != null)
            {
                QLinesRes = Line2N - Line1N + 1;
                QColumnsRes = Column2N - Column1N + 1;
                //
                y = new T[QLinesRes][];
                for (int i = 1; i <= QLinesRes; i++)
                {
                    y[i - 1] = new T[QColumnsRes];
                }
                //
                for (int i = 1; i <= QLinesRes; i++)
                {
                    for (int j = 1; j <= QColumnsRes; j++)
                    {
                        y[i - 1][j - 1] = x[i + Line1N - 1 - 1][j + Column1N - 1 - 1];
                    }
                }
                //
                x = new T[QLinesRes][];
                for (int i = 1; i <= QLinesRes; i++)
                {
                    x[i - 1] = new T[QColumnsRes];
                }
                for (int i = 1; i <= QLinesRes; i++)
                {
                    for (int j = 1; j <= QColumnsRes; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
            }
            else
            {
                y = x;
            }
        }
        public static void SubTableByQ<T>(T[][] x, ref T[][] y, int QLinesOrig, int QColumnsOrig, int Line1N, int Column1N, int QLinesRes, int QColumnsRes, ref int Line2N, ref int Column2N)
        {
            Line2N = Line1N + QLinesRes - 1;
            Column2N = Column1N + QColumnsRes - 1;
            if (x == null) y = null;
            else if (Line1N < Line2N && Line1N >= 1 && Line2N <= QLinesOrig && Column1N < Column2N && Column1N >= 1 && Column2N <= QColumnsOrig && x != null)
            {
                //
                //QLinesRes = Line2N - Line1N + 1;
                //QColumnsRes = Column2N - Column1N + 1;
                //
                y = new T[QLinesRes][];
                for (int i = 1; i <= QLinesRes; i++)
                {
                    y[i - 1] = new T[QColumnsRes];
                }
                //
                for (int i = 1; i <= QLinesRes; i++)
                {
                    for (int j = 1; j <= QColumnsRes; j++)
                    {
                        y[i - 1][j - 1] = x[i + Line1N - 1 - 1][j + Column1N - 1 - 1];
                    }
                }
                //
                x = new T[QLinesRes][];
                for (int i = 1; i <= QLinesRes; i++)
                {
                    x[i - 1] = new T[QColumnsRes];
                }
                for (int i = 1; i <= QLinesRes; i++)
                {
                    for (int j = 1; j <= QColumnsRes; j++)
                    {
                        x[i - 1][j - 1] = y[i - 1][j - 1];
                    }
                }
            }
            else
            {
                y = x;
            }
        }
        //
        public static void ShowTable<T>(T[] x, int QLines, int QColumns, TValsShowHide vsh, string Caption, string MemberName, bool NumbersAreRequired)
        {
            string s;
            if (Caption != null) writeln(vsh, Caption);
            for (int i = 1; i <= QLines; i++)
            {
                s = "";
                for (int j = 1; j <= QColumns; j++)
                {
                    if (MemberName != null)
                    {
                        s += MemberName;
                        if (NumbersAreRequired)
                        {
                            s += "[  ";
                            s += i.ToString();
                            s+=" ][ ";
                            s += j.ToString();
                            s += " ]";
                        }
                        s += "= ";
                    }
                    else
                    {
                        if (NumbersAreRequired)
                        {
                            s += i.ToString();
                            s += ")";
                        }
                        s += " ";
                    }
                    s += x.ToString();
                    s += " ; ";
                }
                writeln(vsh, s);
            }
        }
        //
        public static string ArraySimpleString<T>(T[] x, string delim = " ")
        {
            string s = "";
            if (x != null)
            {
                for (int i = 1; i <= x.Length - 1; i++)
                {
                    s = s + x[i - 1].ToString();
                    s = s + delim;
                }
                if (x.Length > 0)
                {
                    s = s + x[x.Length - 1].ToString();
                }
            }
            return s;
        }
        //
        public static int IsInArray<T>(T[] x, T y, int Q, int FromN=1, bool ErstNotCount=true)
        {
            int MinQ, ErstN=0, count = 0, R=0;
            if(Q<x.Length && Q!=0) MinQ=Q; else MinQ=x.Length;
            for (int i = MinQ; i >= FromN; i--)
            {
                if (x[i - 1].Equals(y))
                {
                    count++;
                    ErstN = i;
                }
            }
            if (ErstNotCount) R = ErstN;
            else R = count;
            return R;
        }
        public static int IsInArray<T>(T[] x, int Q, T[] y, int L, int FromN = 1, bool ErstNotCount = true)
        {    //  to check! Ne checked, abl be errors!
            int MinQ, MinL, ErstN = 0, count = 0, R = 0;
            if (Q <= x.Length && Q > 0) MinQ = Q; else MinQ = x.Length;
            if (L <= y.Length && L > 0) MinL = L; else MinL = y.Length;
            for (int i = MinQ; i >= FromN+MinL-1; i--){
                for (int j = 1; j <= MinL; j++){
                    if (x[i-1+j - 1].Equals(y[j-1]))
                    {
                        count++;
                        ErstN = i;
                    }
                }
            }
            if (ErstNotCount) R = ErstN;
            else R = count;
            return R;
        }
        //
        public static int Array2DMinLength<T>(T[][] x)
        {
            int minL = 0, maxL = 0, QE=x.Length;
            for (int i = 1; i <= QE; i++)
            {
                if (i == 1 || (i > 1 && minL > x[i - 1].Length)) minL = x[i - 1].Length;
                if (i == 1 || (i > 1 && maxL < x[i - 1].Length)) maxL = x[i - 1].Length;
            }
            return minL;
        }
        public static int Array2DMaxLength<T>(T[][] x)
        {
            int minL = 0, maxL = 0, QE = x.Length;
            for (int i = 1; i <= QE; i++)
            {
                if (i == 1 || (i > 1 && minL > x[i - 1].Length)) minL = x[i - 1].Length;
                if (i == 1 || (i > 1 && maxL < x[i - 1].Length)) maxL = x[i - 1].Length;
            }
            return maxL;
        }
        //
        public static bool IsCorrectBool(string s, string[] trueValsExt=null, string[] falseValsExt=null, int QTrueVals = 0, int QFalseVals = 0)
        {
            bool IsTrue, IsFalse, IsBool;
            string[]TrueValsInner = { "1", "+", "y","Y", "t", "T",
                                    "Yes", "yES","yEs", "yeS","yes",
                                    "YES", "YEs", "YeS", 
                                    "True","tRUE","tRUe","tRuE","tRue","trUE","trUe","truE","true",
                                    "TRUE","TRUe","TRuE","TRue","TrUE","TrUe","TruE",
                                    "Ver", "vER","vEr", "veR","ver",
                                    "VER", "VEr", "VeR"};
            string[] FalseValsInner = { "0", "-", "n","N", "f", "F",
                                    "NO", "No","nO", "no",
                                    "fAlse","faLSE","faLSe","faLsE","faLse","falSE", "falSe", "falsE", "false",
                                    "fALSE","fALSe","fALsE","fALse","fAlSE","fAlse", 
                                    "FAlse","FaLSE","FaLSe","FaLsE","FaLse","FalSE", "FalSe", "FalsE", "False",
                                    "FALSE","FALSe","FALsE","FALse","FAlSE","FAlse",
                                    "Irr", "iRR","iRr", "irR","irr",
                                    "IRR", "IRr", "IrR"};
            string[] TrueVal, FalseVal;
            if (trueValsExt != null) TrueVal = trueValsExt; else TrueVal = TrueValsInner;
            if (falseValsExt != null) FalseVal = falseValsExt; else FalseVal = FalseValsInner;
            IsTrue = (IsInArray(TrueVal, s, QTrueVals) > 0);
            IsFalse = (IsInArray(FalseVal, s, QFalseVals) > 0);
            IsBool = IsTrue || IsFalse;
            return IsBool;
        }
        public static bool IsTrue(string s, string[] trueValsExt = null, string[] falseValsExt = null, int QTrueVals = 0, int QFalseVals = 0)
        {
            bool IsTrue, IsFalse, IsBool;
            string[]TrueValsInner = { "1", "+", "y","Y", "t", "T",
                                    "Yes", "yES","yEs", "yeS","yes",
                                    "YES", "YEs", "YeS", 
                                    "True","tRUE","tRUe","tRuE","tRue","trUE","trUe","truE","true",
                                    "TRUE","TRUe","TRuE","TRue","TrUE","TrUe","TruE",
                                    "Ver", "vER","vEr", "veR","ver",
                                    "VER", "VEr", "VeR"};
            string[] FalseValsInner = { "0", "-", "n","N", "f", "F",
                                    "NO", "No","nO", "no",
                                    "fAlse","faLSE","faLSe","faLsE","faLse","falSE", "falSe", "falsE", "false",
                                    "fALSE","fALSe","fALsE","fALse","fAlSE","fAlse", 
                                    "FAlse","FaLSE","FaLSe","FaLsE","FaLse","FalSE", "FalSe", "FalsE", "False",
                                    "FALSE","FALSe","FALsE","FALse","FAlSE","FAlse",
                                    "Irr", "iRR","iRr", "irR","irr",
                                    "IRR", "IRr", "IrR"};
            string[] TrueVal, FalseVal;
            if (trueValsExt != null) TrueVal = trueValsExt; else TrueVal = TrueValsInner;
            if (falseValsExt != null) FalseVal = falseValsExt; else FalseVal = FalseValsInner;
            IsTrue = (IsInArray(TrueVal, s, QTrueVals) > 0);
            IsFalse = (IsInArray(FalseVal, s, QFalseVals) > 0);
            IsBool = IsTrue || IsFalse;
            return IsTrue;
        }
        public static bool IsFalse(string s, string[] trueValsExt = null, string[] falseValsExt = null, int QTrueVals = 0, int QFalseVals = 0)
        {
            bool IsTrue, IsFalse, IsBool;
            string[] TrueValsInner = { "1", "+", "y","Y", "t", "T",
                                    "Yes", "yES","yEs", "yeS","yes",
                                    "YES", "YEs", "YeS", 
                                    "True","tRUE","tRUe","tRuE","tRue","trUE","trUe","truE","true",
                                    "TRUE","TRUe","TRuE","TRue","TrUE","TrUe","TruE",
                                    "Ver", "vER","vEr", "veR","ver",
                                    "VER", "VEr", "VeR"};
            string[] FalseValsInner = { "0", "-", "n","N", "f", "F",
                                    "NO", "No","nO", "no",
                                    "fAlse","faLSE","faLSe","faLsE","faLse","falSE", "falSe", "falsE", "false",
                                    "fALSE","fALSe","fALsE","fALse","fAlSE","fAlse", 
                                    "FAlse","FaLSE","FaLSe","FaLsE","FaLse","FalSE", "FalSe", "FalsE", "False",
                                    "FALSE","FALSe","FALsE","FALse","FAlSE","FAlse",
                                    "Irr", "iRR","iRr", "irR","irr",
                                    "IRR", "IRr", "IrR"};
            string[] TrueVal, FalseVal;
            if (trueValsExt != null) TrueVal = trueValsExt; else TrueVal = TrueValsInner;
            if (falseValsExt != null) FalseVal = falseValsExt; else FalseVal = FalseValsInner;
            IsTrue = (IsInArray(TrueVal, s, QTrueVals) > 0);
            IsFalse = (IsInArray(FalseVal, s, QFalseVals) > 0);
            IsBool = IsTrue || IsFalse;
            return IsFalse;
        }
        public static bool IsBoolArray(string[] s, int Q, string[] trueValsExt = null, string[] falseValsExt = null, int QTrueVals = 0, int QFalseVals = 0)
        {
            bool verdict = true;
            int MinQ, L=s.Length;
            if(Q<L && Q>0) MinQ=Q; else MinQ=L;
            for (int i = 1; i <= MinQ; i++)
            {
                verdict = verdict && IsCorrectBool(s[i-1], trueValsExt, falseValsExt, QTrueVals, QFalseVals);
            }
            return verdict;
        }
        //
        //
        //
        public static bool IntToBool(int x) { return (x == 1); }
        public static bool BoolOfInt(int x) { return (x != 0); }
        public static int BoolToInt(bool x) {
            int y;
            if (x == true) y = 1;
            else y = 0;
            return y;
        }
        public static int IntOfBool(bool x)
        {
            int y;
            if (x != false) y = 1;
            else y = 0;
            return y;
        }
        public static bool StrToBool(string s)
        {
            bool b;
            if (s.Equals("t") || s.Equals("T") || s.Equals("true") || s.Equals("True") || s.Equals("TRUE") || s.Equals("1") || s.Equals("+") || s.Equals("y") || s.Equals("Y") || s.Equals("yes") || s.Equals("Yes") || s.Equals("YES"))
            {
                b = true;
            }
            else if (s.Equals("f") || s.Equals("F") || s.Equals("false") || s.Equals("False") || s.Equals("FALSE") || s.Equals("0") || s.Equals("-") || s.Equals("n") || s.Equals("N") || s.Equals("no") || s.Equals("No") || s.Equals("NO"))
            {
                b = false;
            }
            else b = false;
            return b;
        }
        public static string BoolToStr(bool val, string TrueVal, string FalseVal)
        {
            string r;
            //r = "-";
            if(val){
                if (TrueVal != null && TrueVal != "")
                {
                    r = "+";
                }
                else r = TrueVal;
            }else{
                if (FalseVal != null && FalseVal != "")
                {
                    r = "-";
                }
                else r = FalseVal;
            }
            return r;
        }
        //
        //
        public static void writeln(TValsShowHide vsh, string text=""){
            //StreamReader sr;
            //StreamWriter sw;
            //string TmpFileName = null;
            if(vsh!=null){
                if(vsh.Show1Hide0!=0){
                    if(vsh.ConsoleInterface){
                        Console.WriteLine(text);
                    }
                    if(vsh.box!=null){
                        vsh.box.Items.Add(text);
                    }
                    if(vsh.file!=null){
                        vsh.file.WriteLine(text);
                    }
                    if (vsh.FileToAppendName != null && vsh.FileToAppendName != "")
                    {
                        if (File.Exists(vsh.FileToAppendName))
                        {
                            File.AppendAllText(vsh.FileToAppendName, text);
                        }
                        else
                        {
                            File.WriteAllText(vsh.FileToAppendName, text);
                        }
                    }
                }
            }
        }//fn
        //
        public static int fNOfNatN(int NatN, int Orig)
        {
            int N;
            N = NatN + Orig - 1;
            return N;
        }
        public static int fNatNOfN(int N, int Orig)
        {
            int NatN;
            NatN = N - Orig + 1;
            return NatN;
        }
        //
        public static void FindSubstring(string where, string what, ref int count, ref int[] Ns)
        {
            int LWhere = where.Length;
            int LWhat = what.Length;
            int NLast = LWhere - LWhat;
            int Length = LWhere - LWhat;
            string s;
            Ns = null;
            count = 0;
            if (NLast == 0 && where.Equals(what))
            {
                Ns = new int[1];
                count = 1;
                Ns[1 - 1] = 1;
            }
            else if (NLast > 0)
            {
                Ns = new int[Length];
                for (int i = 1; i < NLast; i++) Ns[i - 1] = 0;
                for(int i=1; i<NLast; i++){
                    s = where.Substring(i - 1, LWhat);
                    if (s.Equals(what))
                    {
                        count++;
                        Ns[count - 1] = i;
                    }
                }
            }//if main
        }//fn
        //
        public static void FindStringInArray(string[] where, int Length, string what, ref int count, ref int[] Ns)
        {
            int NLast = Length;
            Ns = null;
            count = 0;
            Ns = new int[Length];
            for (int i = 1; i < NLast; i++) Ns[i - 1] = 0;
            for (int i = 1; i < NLast; i++)
            {
                if ((where[i-1]).Equals(what))
                {
                    count++;
                    Ns[count - 1] = i;
                }
            }
        }//fn
        //
        public static string ComposeTableCorner(string LinesGenName, string ColsGenName, string TableName = "")
        {
            string corner;
            corner="";
            if (TableName != null && TableName != "") {
                corner = corner + TableName; //else corner = corner + ""; // ce uz if ":" is nesessary
                corner = corner + ":";
            }
            //else corner = corner + "";
            if (LinesGenName != null && LinesGenName != "") corner = corner + LinesGenName; //else corner = corner + "";
            corner = corner + "\\";
            if (ColsGenName != null && ColsGenName != "") corner = corner + ColsGenName; //else corner = corner + "";
            return corner;
        }
        public static void ParseNamesOfTableCorner(string corner, ref bool correct, ref string LinesGenName, ref string ColsGenName, ref string TableName)
        {
            string cur;
            int L = corner.Length;
            int ColonN = 0, ColonCount = 0, SlashN = 0, SlashCount = 0;
            //LinesGenName = ""; ColsGenName = ""; TableName = ""; //why? Let them be co ini vals!
            for (int i = 1; i <= L; i++)
            {
                cur = corner.Substring(i - 1, 1);
                if (cur.Equals(":"))
                {
                    ColonCount++;
                    ColonN = i;
                }
            }
            for (int i = 1; i <= L; i++)
            {
                cur = corner.Substring(i - 1, 1);
                if (cur.Equals("\\"))
                {
                    SlashCount++;
                    SlashN = i;
                }
            }
            if (L==0 || ColonCount > 1 || SlashCount > 1 || ColonCount > SlashCount) correct = false;
            if (correct){
                if (ColonCount == 1 && ColonN > 1) {
                    TableName = corner.Substring(1 - 1, ColonN - 1);
                }//else no table name
                if (ColonN != L){
                    if (SlashCount == 1) {
                        LinesGenName = corner.Substring(ColonN + 1 - 1, SlashN - ColonN - 1);
                        if (SlashN < L) {
                            //ColsGenName = corner.Substring(SlashN + 1 - 1, L - 1);//Java
                            ColsGenName = corner.Substring(SlashN + 1 - 1, L - SlashN - 1);
                        }
                    }
                    else //no slashes => SlashN=0 => whole part af corner s' LGN
                    {
                        LinesGenName = corner.Substring(ColonN + 1 - 1, L - ColonN);
                    }
                }//  else // Colon s'Last, ce ne alt't l'fml
            }
        }//fn
        /*public static void Make2DStringArrayRectangular(ref string[][] arr, ref int FinLength, int QRows, int[] Lengths, int Max0Min1ConcreteValue2)//, int value = 0)
        {
            string[][] ArrNew = null;
            int MaxLength = 0, MinLength = 0, CurMinLength = 0;
            for (int i = 1; i <= QRows; i++)
            {
                if (i == 1 || (i > 1 && Lengths[i - 1] > MaxLength)) MaxLength = Lengths[i - 1];
                if (i == 1 || (i > 1 && Lengths[i - 1] < MinLength)) MinLength = Lengths[i - 1];
            }
            if (Max0Min1ConcreteValue2 == 0) FinLength = MaxLength;
            else if (Max0Min1ConcreteValue2 == 1) FinLength = MinLength;
            else if (FinLength < 1) FinLength = 1;
            //else NOp;
            ArrNew = new string[QRows][];
            for (int i = 1; i <= QRows; i++) ArrNew[i - 1] = new string[FinLength];
            for (int i = 1; i <= QRows; i++)
            {
                if (Lengths[i - 1] > FinLength) CurMinLength = FinLength; else CurMinLength = Lengths[i - 1];
                for (int j = 1; j <= FinLength; j++)
                {
                    if (j <= CurMinLength) ArrNew[i - 1][j - 1] = arr[i - 1][j - 1];
                    else ArrNew[i - 1][j - 1] = "";
                }
            }
            arr = ArrNew;
        }
        public static void ReadCSV(string FullName, ref int CountLines, ref int[] length, ref string[][] words, char delimiter = ';', int ToAvoid = 0)
        {
            string text, CurLine="";
            string[] line;
            StreamReader sr = new StreamReader(FullName);
            int QL, QC;
            CountLines = 0;
            bool contin = true;
            while (contin)
            {
                CountLines++;
                while (CountLines <= ToAvoid)
                {
                    CurLine = sr.ReadLine();
                    if (sr == null) break;
                }
                CurLine = sr.ReadLine();
                if (CurLine != null)
                {
                    line = CurLine.Split(delimiter);
                    QC = line.Length;
                    if (CountLines == 1)
                    {
                        words = new string[1][];
                        length = new int[1];
                        QL = CountLines;
                        words[1 - 1] = new string[QC];
                        //words[1 - 1] = line;
                    }
                    else
                    {
                        QL = CountLines;
                        AddToVector<int>(ref length, ref QL, QC);
                        QL--;
                        //public static void AddLineToTable<T>(ref T[][] x, T[] Line, ref int QLines, ref int QColumns)
                        AddLineToTable<string>(ref words, line, ref QL, ref QC);
                    }
                    length[QL - 1] = QC;
                    for (int i = 1; i <= QC; i++)
                    {
                        words[QL - 1][i - 1] = line[i - 1];
                    }
                }
                else
                {
                    CountLines--;
                    contin = false;
                }
            }//while
        }//fn
        */
        //mark1
        public static void FillIntArray(int value, int Quantity, ref int[] Array)
        {
            Array = new int[Quantity];
            for (int i = 1; i <= Quantity; i++)
            {
                Array[i - 1] = value;
            }
        }
        /*
        public static bool fCellsAreEqual(DataCell cell1, DataCell cell2, int AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 = 1, TableSize Cell1Ns = null, TableSize Cell2Ns = null)
        {
            bool verdict = false, equalItems = true, equalNames = true;
            int LengthOfNamesSet1 = 0, LengthOfNamesSet2 = 0, LengthOfItemsSet1 = 0, LengthOfItemsSet2, Type1N, Type2N;
            string[] names1 = null, names2 = null, items1 = null, items2 = null;
            double[] dArr1 = null, dArr2 = null;
            float[] fArr1 = null, fArr2 = null;
            int[] intArr1 = null, intArr2 = null;
            bool[] bArr1 = null, bArr2 = null;
            string sVal1, sVal2;
            double dVal1, dVal2;
            float fVal1, fVal2;
            int intVal1, intVal2;
            bool bVal1, bVal2;
            switch (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6)
            {
                case 0:
                    verdict = (Cell1Ns.QLines == Cell2Ns.QLines && Cell1Ns.QColumns == Cell2Ns.QColumns);
                    break;
                case 1:
                    Type1N = cell1.GetTypeN(); Type2N = cell2.GetTypeN();
                    if (TableConsts.TypeNIsCorrectHeaderOfDBColWithItems(Type1N))
                    {
                        sVal1 = cell1.GetName1();
                    }
                    else
                    {
                        sVal1 = cell1.ToString();
                    }
                    if (TableConsts.TypeNIsCorrectHeaderOfDBColWithItems(Type2N))
                    {
                        sVal2 = cell2.GetName1();
                    }
                    else
                    {
                        sVal2 = cell2.ToString();
                    }
                    verdict = (sVal1.Equals(sVal2));
                    break;
                case 2:
                    verdict = (cell1.GetDoubleVal() == cell2.GetDoubleVal());
                    break;
                case 3:
                    verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                    break;
                case 4:
                    verdict = (cell1.ToString().Equals(cell2.ToString()));
                    break;
                //if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 0 && Cell1Ns.QLines == Cell2Ns.QLines && Cell1Ns.QColumns == Cell2Ns.QColumns) verdict = true;
                //else if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 1 && cell1.ToString().Equals(Cell2Ns.ToString())) verdict = true;
                //else if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 6)
                case 6:
                    Type1N = cell1.GetTypeN(); Type2N = cell2.GetTypeN();
                    LengthOfItemsSet1 = cell1.GetLength(); LengthOfItemsSet2 = cell2.GetLength();
                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    if (Type1N == Type2N)
                    {
                        if (LengthOfItemsSet1 == LengthOfItemsSet2 && LengthOfNamesSet1 == LengthOfNamesSet2)
                        {
                            switch (Type1N)
                            {
                                case TableConsts.DoubleTypeN:
                                    dVal1 = cell1.GetDoubleVal();
                                    dVal2 = cell2.GetDoubleVal();
                                    verdict = (dVal1 == dVal2);
                                    //verdict = (cell1.GetDoubleVal() == cell2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    fVal1 = cell1.GetFloatVal();
                                    fVal2 = cell2.GetFloatVal();
                                    verdict = (fVal1 == fVal2);
                                    //verdict = (cell1.GetFloatVal() == cell2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    intVal1 = cell1.GetIntVal();
                                    intVal2 = cell2.GetIntVal();
                                    verdict = (intVal1 == intVal2);
                                    //verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    bVal1 = cell1.GetBoolVal();
                                    bVal2 = cell2.GetBoolVal();
                                    verdict = (bVal1 == bVal2);
                                    //verdict = (cell1.GetBoolVal() == cell2.GetBoolVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    sVal1 = cell1.ToString();
                                    sVal2 = cell2.ToString();
                                    verdict = sVal1.Equals(sVal2);
                                    //verdict = (cell1.ToString() == cell2.ToString());//ne writes error
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    cell1.GetDoubleArr(ref dArr1, ref LengthOfItemsSet1);
                                    cell2.GetDoubleArr(ref dArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetDoubleValN(i) != cell2.GetDoubleValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    cell1.GetFloatArr(ref fArr1, ref LengthOfItemsSet1);
                                    cell2.GetFloatArr(ref fArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetFloatValN(i) != cell2.GetFloatValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    cell1.GetIntArr(ref intArr1, ref LengthOfItemsSet1);
                                    cell2.GetIntArr(ref intArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    cell1.GetBoolArr(ref bArr1, ref LengthOfItemsSet1);
                                    cell2.GetBoolArr(ref bArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetBoolValN(i) != cell2.GetBoolValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    cell1.ToStringArr(ref items1, ref LengthOfItemsSet1);
                                    cell2.ToStringArr(ref items2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (!cell1.ToStringN(i).Equals(cell2.ToStringN(i))) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.DoubleItemsFieldHeaderCellTypeN:
                                    cell1.GetDoubleArr(ref dArr1, ref LengthOfItemsSet1);
                                    cell2.GetDoubleArr(ref dArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetDoubleValN(i) != cell2.GetDoubleValN(i)) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;
                                case TableConsts.IntItemsFieldHeaderCellTypeN:
                                    cell1.GetIntArr(ref intArr1, ref LengthOfItemsSet1);
                                    cell2.GetIntArr(ref intArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;
                                case TableConsts.StringItemsFieldHeaderCellTypeN:
                                    cell1.ToStringArr(ref items1, ref LengthOfItemsSet1);
                                    cell2.ToStringArr(ref items2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (!cell1.ToStringN(i).Equals(cell2.ToStringN(i))) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;//case StrindgItemsDbColHeader
                            }//switchTypeN
                        }//if LN=LN && LI=LI
                    }//if TypeN1=TypeN2
                    break;
            }//switch
            return verdict;
        }//fn
        */
        public static bool fCellsAreEqual(DataCell cell1, DataCell cell2, int AreEqualBy_N0_Names_1_2_21__ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableSize Cell1Ns = null, TableSize Cell2Ns = null)
        //public static bool fCellsAreEqual(DataCell cell1, DataCell cell2, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableSize Cell1Ns = null, TableSize Cell2Ns = null)
        {
            bool verdict = false, equalItems = true, equalNames = true;
            int LengthOfNamesSet1 = 0, LengthOfNamesSet2 = 0, LengthOfItemsSet1 = 0, LengthOfItemsSet2 = 0, Type1N, Type2N;
            string[] names1 = null, names2 = null, items1 = null, items2 = null;
            double[] dArr1 = null, dArr2 = null;
            float[] fArr1 = null, fArr2 = null;
            int[] intArr1 = null, intArr2 = null;
            bool[] bArr1 = null, bArr2 = null;
            string sVal1, sVal2;
            double dVal1, dVal2;
            float fVal1, fVal2;
            int intVal1, intVal2;
            bool bVal1, bVal2;
            switch (AreEqualBy_N0_Names_1_2_21__ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13)
            //switch (AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13)
            {
                case 0:
                    verdict = (Cell1Ns.QLines == Cell2Ns.QLines && Cell1Ns.QColumns == Cell2Ns.QColumns);
                    break;
                case 1:
                    //Type1N = cell1.GetTypeN(); Type2N = cell2.GetTypeN();
                    //if (TableConsts.TypeNIsCorrectHeaderOfDBColWithItems(Type1N))
                    //{
                    //    sVal1 = cell1.GetName1();
                    //}
                    //else
                    //{
                    //    sVal1 = cell1.ToString();
                    //}
                    //if (TableConsts.TypeNIsCorrectHeaderOfDBColWithItems(Type2N))
                    //{
                    //    sVal2 = cell2.GetName1();
                    //}
                    //else
                    //{
                    //    sVal2 = cell2.ToString();
                    //}
                    //
                    sVal1 = cell1.GetName1();
                    sVal2 = cell2.GetName1();
                    verdict = (sVal1.Equals(sVal2));
                    break;
                case 2:
                    verdict = false;
                    //cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    //cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    //if (LengthOfNamesSet1>=2 )
                    verdict = ((cell1.GetName2()).Equals(cell2.GetName2()));
                    break;
                //case 3://not needed
                //    verdict = false;
                //    //cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                //    //cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                //    //if (LengthOfNamesSet1>=2 )
                //    //verdict = ((cell1.GetName3()).Equals(cell2.GetName3()));
                //    break;
                case 4:
                    verdict = (cell1.GetActiveN() == cell2.GetActiveN());
                    break;
                case 21:
                    verdict = false;
                    //cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    //cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    //if (LengthOfNamesSet1>=2 )
                    verdict = ((cell1.GetName1()).Equals(cell2.GetName1()) && (cell1.GetName2()).Equals(cell2.GetName2()));
                    break;
                //case 31://not needed
                //    verdict = false;
                //    //cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                //    //cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                //    //if (LengthOfNamesSet1>=2 )
                //    //verdict = ((cell1.GetName1()).Equals(cell2.GetName1()) && (cell1.GetName3()).Equals(cell2.GetName3()));
                //    break;
                //case 32://no needed
                //    verdict = false;
                //    //cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                //    //cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                //    //if (LengthOfNamesSet1>=2 )
                //    //verdict = ((cell1.GetName2()).Equals(cell2.GetName2()) && (cell1.GetName3()).Equals(cell2.GetName3()));
                //    break;
                case 10:
                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    equalNames = (LengthOfNamesSet1 == LengthOfNamesSet2);
                    if (equalNames)
                    {
                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                        {
                            if ((cell1.GetNameN(i)).Equals(cell2.GetNameN(i)) == false) equalNames = false;
                        }
                    }
                    verdict = equalNames;
                    break;
                case 11:
                    cell1.GetStringArr(ref items1, ref LengthOfItemsSet1);
                    cell2.GetStringArr(ref items2, ref LengthOfItemsSet2);
                    equalItems = (LengthOfItemsSet1 == LengthOfItemsSet2);
                    if (equalItems)
                    {
                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                        {
                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalNames = false;
                        }
                    }
                    verdict = equalItems;
                    break;
                case 12:
                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    equalNames = (LengthOfNamesSet1 == LengthOfNamesSet2);
                    if (equalNames)
                    {
                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                        {
                            if ((cell1.GetNameN(i)).Equals(cell2.GetNameN(i)) == false) equalNames = false;
                        }
                    }
                    cell1.GetStringArr(ref items1, ref LengthOfItemsSet1);
                    cell2.GetStringArr(ref items2, ref LengthOfItemsSet2);
                    equalItems = (LengthOfItemsSet1 == LengthOfItemsSet2);
                    if (equalItems)
                    {
                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                        {
                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalNames = false;
                        }
                    }
                    verdict = equalItems && equalItems;
                    break;
                case 13:
                    cell1.GetStringArr(ref items1, ref LengthOfItemsSet1);
                    cell2.GetStringArr(ref items2, ref LengthOfItemsSet2);
                    equalItems = (LengthOfItemsSet1 == LengthOfItemsSet2);
                    if (equalItems)
                    {
                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                        {
                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalNames = false;
                        }
                    }
                    verdict = equalItems && (cell1.GetActiveN() == cell2.GetActiveN());
                    break;
                case 5:
                    verdict = (cell1.GetDoubleVal() == cell2.GetDoubleVal());
                    break;
                case 6:
                    verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                    break;
                case 7:
                    verdict = (cell1.GetBoolVal() == cell2.GetBoolVal());
                    break;
                case 8:
                    verdict = (cell1.ToString().Equals(cell2.ToString()));
                    break;
                //if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 0 && Cell1Ns.QLines == Cell2Ns.QLines && Cell1Ns.QColumns == Cell2Ns.QColumns) verdict = true;
                //else if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 1 && cell1.ToString().Equals(Cell2Ns.ToString())) verdict = true;
                //else if (AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 == 6)
                case 9:
                    Type1N = cell1.GetTypeN(); Type2N = cell2.GetTypeN();
                    LengthOfItemsSet1 = cell1.GetLength(); LengthOfItemsSet2 = cell2.GetLength();
                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                    if (Type1N == Type2N)
                    {
                        if (LengthOfItemsSet1 == LengthOfItemsSet2 && LengthOfNamesSet1 == LengthOfNamesSet2)
                        {
                            switch (Type1N)
                            {
                                case TableConsts.DoubleTypeN:
                                    dVal1 = cell1.GetDoubleVal();
                                    dVal2 = cell2.GetDoubleVal();
                                    verdict = (dVal1 == dVal2);
                                    //verdict = (cell1.GetDoubleVal() == cell2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    fVal1 = cell1.GetFloatVal();
                                    fVal2 = cell2.GetFloatVal();
                                    verdict = (fVal1 == fVal2);
                                    //verdict = (cell1.GetFloatVal() == cell2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    intVal1 = cell1.GetIntVal();
                                    intVal2 = cell2.GetIntVal();
                                    verdict = (intVal1 == intVal2);
                                    //verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    bVal1 = cell1.GetBoolVal();
                                    bVal2 = cell2.GetBoolVal();
                                    verdict = (bVal1 == bVal2);
                                    //verdict = (cell1.GetBoolVal() == cell2.GetBoolVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    sVal1 = cell1.ToString();
                                    sVal2 = cell2.ToString();
                                    verdict = sVal1.Equals(sVal2);
                                    //verdict = (cell1.ToString() == cell2.ToString());//ne writes error
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    verdict = (cell1.GetIntVal() == cell2.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    cell1.GetDoubleArr(ref dArr1, ref LengthOfItemsSet1);
                                    cell2.GetDoubleArr(ref dArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetDoubleValN(i) != cell2.GetDoubleValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    cell1.GetFloatArr(ref fArr1, ref LengthOfItemsSet1);
                                    cell2.GetFloatArr(ref fArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetFloatValN(i) != cell2.GetFloatValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    cell1.GetIntArr(ref intArr1, ref LengthOfItemsSet1);
                                    cell2.GetIntArr(ref intArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    cell1.GetBoolArr(ref bArr1, ref LengthOfItemsSet1);
                                    cell2.GetBoolArr(ref bArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetBoolValN(i) != cell2.GetBoolValN(i)) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    cell1.GetStringArr(ref items1, ref LengthOfItemsSet1);
                                    cell2.GetStringArr(ref items2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (!cell1.ToStringN(i).Equals(cell2.ToStringN(i))) equalItems = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems;
                                    break;
                                case TableConsts.DoubleItemsFieldHeaderCellTypeN:
                                    cell1.GetDoubleArr(ref dArr1, ref LengthOfItemsSet1);
                                    cell2.GetDoubleArr(ref dArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetDoubleValN(i) != cell2.GetDoubleValN(i)) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;
                                case TableConsts.IntItemsFieldHeaderCellTypeN:
                                    cell1.GetIntArr(ref intArr1, ref LengthOfItemsSet1);
                                    cell2.GetIntArr(ref intArr2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (cell1.GetIntValN(i) != cell2.GetIntValN(i)) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;
                                case TableConsts.StringItemsFieldHeaderCellTypeN:
                                    cell1.GetStringArr(ref items1, ref LengthOfItemsSet1);
                                    cell2.GetStringArr(ref items2, ref LengthOfItemsSet2);
                                    equalItems = true;
                                    if (LengthOfItemsSet1 == LengthOfItemsSet2)
                                    {
                                        equalItems = true;
                                        for (int i = 1; i <= LengthOfItemsSet1; i++)
                                        {
                                            if (!cell1.ToStringN(i).Equals(cell2.ToStringN(i))) equalItems = false;
                                        }
                                    }
                                    cell1.GetNames(ref names1, ref LengthOfNamesSet1);
                                    cell2.GetNames(ref names2, ref LengthOfNamesSet2);
                                    equalNames = true;
                                    if (LengthOfNamesSet1 == LengthOfNamesSet2)
                                    {
                                        equalNames = true;
                                        for (int i = 1; i <= LengthOfNamesSet1; i++)
                                        {
                                            if (!cell1.GetNameN(i).Equals(cell2.GetNameN(i))) equalNames = false;
                                        }
                                    }
                                    verdict = (LengthOfItemsSet1 == LengthOfItemsSet2) && equalItems && (LengthOfNamesSet1 == LengthOfNamesSet2) && equalNames;
                                    break;//case StrindgItemsDbColHeader
                            }//switchTypeN
                        }//if LN=LN && LI=LI
                    }//if TypeN1=TypeN2
                    break;
            }//switch
            return verdict;
        }//fn
        public static DataCell SetDataCellFromStringValParsing(string val, TableReadingTypesParams rules)
        //exchange conversion to numbers to own from NumberParse!
        {
            DataCell cell = null;
            double xd;
            int xi;
            bool xb;
            int Type_Str1Real2Int3Bool4 = 1;
            int NumberType_No0Real1Int2 = NumberParse.IsCorrectNumber_No0Real1Int2(val);
            if (NumberType_No0Real1Int2 > 0)
            {
                if (MyLib.IsCorrectBool(val))
                {
                    if (rules.BoolPriorThanStr)
                    {
                        if (MyLib.IsTrue(val)) cell = new DataCell(true);
                        else if (MyLib.IsFalse(val)) cell = new DataCell(false);
                        else cell = new DataCell(val);
                    }
                    else
                    {
                        if (NumberType_No0Real1Int2 == 2)
                        {
                            if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                            else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                        else
                        {
                            if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                    }
                }
                else
                { //not bool
                    if (NumberType_No0Real1Int2 == 2)
                    {  //int number
                        if (rules.BoolPriorThanInt)
                        {
                            if (Convert.ToInt32(val) == 1) cell = new DataCell(true);
                            else if (Convert.ToInt32(val) == 0) cell = new DataCell(false);
                            else
                            {
                                if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                                else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                                else cell = new DataCell(val);
                            }
                        }
                        else
                        {//val is int, ma ne allowed int to bool
                            if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                            else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                    }
                    else if (NumberType_No0Real1Int2 == 1) //real number
                    {
                        if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                        else cell = new DataCell(val);
                    }
                    else
                    { //not a number
                        //including val="";
                        cell = new DataCell(val);
                    }
                }
            }
            else cell = new DataCell(val);
            return cell;
        }//fn 
        public static int DefineDataTypeOfStringValParsing(string val, TableReadingTypesParams rules)
        {
            int TypeN = 0;
            DataCell cell;
            cell=SetDataCellFromStringValParsing(val, rules);
            TypeN = cell.GetTypeN();
            return TypeN;
        }
        //
        public static void ReadCSV_MakingRectangular(string FullName, ref int CountLines, ref int QColumns, ref string[][] words, char delimiter = ';', int ToAvoid = 0)
        {
            int[] Lengths = null;
            string CurLine = "";
            string[] line, col = null;
            //string sngl;
            StreamReader sr = new StreamReader(FullName);
            int QL = 0, QC=0, QCtmp;
            int MaxLength = 0;
            CountLines = 0;
            bool contin = true;
            while (contin)
            {
                CountLines++;
                //QL = CountLines;
                while (CountLines <= ToAvoid)
                {
                    CurLine = sr.ReadLine();
                    if (sr == null) break;
                }
                CurLine = sr.ReadLine();
                if (CurLine != null)
                {
                    line = CurLine.Split(delimiter);
                    QC = line.Length;
                    if (CountLines == 1)
                    {
                        words = new string[1][];
                        Lengths = new int[1];
                        words[1 - 1] = new string[QC];
                        //words[1 - 1] = line;
                        MaxLength = QC;
                        QL = CountLines;
                    }
                    else
                    {
                        if (QC > MaxLength)
                        {
                            QL = CountLines - 1;
                            QCtmp = MaxLength;
                            col = new string[QL];
                            for (int i = 1; i <= QL ; i++) col[i - 1] = "";
                            for (int i = 1; i <= (QC - MaxLength); i++) AddColumnToTable<string>(ref words, col, ref QL, ref QCtmp);
                            MaxLength = QC;
                        }
                        else if (QC < MaxLength)
                        {
                            QCtmp = QC;
                            //sngl = "";
                            for (int i = 1; i <= (MaxLength - QCtmp); i++) AddToVector<string>(ref line, ref QC, "");
                            //
                        }
                        QL = CountLines;
                        AddToVector<int>(ref Lengths, ref QL, QC);
                        QL--;
                        //public static void AddLineToTable<T>(ref T[][] x, T[] Line, ref int QLines, ref int QColumns)
                        AddLineToTable<string>(ref words, line, ref QL, ref QC);
                    }
                    Lengths[QL - 1] = QC;
                    for (int i = 1; i <= QC; i++)
                    {
                        words[QL - 1][i - 1] = line[i - 1];
                    }
                }
                else
                {
                    CountLines--;
                    contin = false;
                }
            }//while
            QColumns = QC;
            sr.Close();
        }//fn
        public static void StringArrToCSV(string FullName, string[][] ss, TableSize ArrSize, string delimiter = ";")
        {
            //string[][] ss = null;
            string CurLine;
            StreamWriter sw;
            //TableSize ArrSize = null;
            //ToStringArray(ref ss, ref ArrSize, TblInfExt, QForHeaderCells);
            int QArrayLines = ArrSize.QLines, QArrayColumns = ArrSize.QColumns;
            //if(ArrSize!=null) QArrayLines = ArrSize.QLines, QArrayColumns = ArrSize.QColumns;
            //else QArrayLines==ss.L
            if (ss == null) MessageBox.Show("nil ecri!");
            else
            {
                sw = new StreamWriter(FullName);
                for (int i = 1; i <= QArrayLines; i++)
                {
                    CurLine = "";
                    for (int j = 1; j <= QArrayColumns; j++)
                    {
                        CurLine = CurLine + ss[i - 1][j - 1];
                        if (j < QArrayColumns) CurLine = CurLine + delimiter;
                        //else CurLine = CurLine + "\n";//ce do'tm sw 
                    }
                    sw.WriteLine(CurLine);
                }
                sw.Close();
            }//if-else es ecri
        }//fn
        //
        //
        public static string GetConnectionString(int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5, string DBFileFullName)
        {
            string connStr = "";
            switch(DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5){
                case 1:
                    connStr="";
                break;
                case 2:
                    connStr="";
                break;
                case 3:
                    connStr="";
                break;
                case 4:
                    connStr="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileFullName;
                break;
                case 5:
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;DataSource=" + DBFileFullName;
                break;
            }
            return connStr;
        }//fn
		//
        public static void SeekFirst(string[] sa, string val, ref int count, ref int FirstN, ref int[] Ns, int FromN = 1, int ToN = 0, TValsShowHide vsh=null)
        {
            writeln(vsh, "SeekFirst starts working");
            int Q = sa.Length;
            count = 0;
            int L=0;
            Ns = null;
            FirstN = 0;
            if (Q > 0)
            {
                writeln(vsh, "Q="+Q.ToString()+" > 0");
                if (ToN == 0)
                {
                    ToN = Q;
                }
                if (FromN < ToN)
                {
                    writeln(vsh, " FromN=" + FromN.ToString() + " < ToN=" + ToN.ToString());
                    writeln(vsh, " So:");
                    for (int i = ToN; i >= FromN; i--)
                    {
                        writeln(vsh, "Comparing "+val+" to "+sa[i-1]);
                        if (sa[i - 1].Equals(val))
                        {
                            count++;
                            FirstN = i;
                            if (count == 1)
                            {
                                Ns = new int[1];
                                Ns[1 - 1] = i;
                            }
                            else
                            {
                                L = count;
                                MyLib.AddToVector<int>(ref Ns, ref L, i);
                            }
                            writeln(vsh, "Comparing " + val + " to " + sa[i - 1] + " - they are same, i="+i.ToString());
                        }
                        else
                        {
                            writeln(vsh, "Comparing " + val + " to " + sa[i - 1]+" - they are different");
                        }
                    }
                }
                else
                {
                    writeln(vsh, " FromN=" + FromN.ToString() + " >= ToN=" + ToN.ToString() );
                }
            }else{
                writeln(vsh, "Q="+Q.ToString()+" < 0");
            }
            writeln(vsh, "SeekFirst finishes working");
        }//fn
        public static string CorrectStringValToBeUniqueForStringArray(string[] sa, string val, string bef = "", string aft = "", TValsShowHide vsh = null)
        {
            writeln(vsh,"CorrectValToBeUniqueForArray starts working");
            string R = val;
            bool contin;
            contin = (sa!=null && val!="");
            int countSteps = 0;
            int Q = sa.Length;
            int countResults = 0, FirstN = 0;
            int[] Ns = null;
            if (Q > 0)
            {
                while (contin)
                {
                    countSteps++;
                    //SeekFirst(string[] sa, string val,    ref int count, ref int FirstN, ref int[] Ns, int FromN = 1, int ToN = 0)
                    SeekFirst(           sa,        R, ref countResults,     ref FirstN,       ref Ns,            1,           0, vsh);
                    if (FirstN == 0)
                    {
                        contin = false;
                    }
                    else
                    {
                        R = bef + R + aft;
                    }
                    writeln(vsh, "step " + countSteps.ToString() + " val " + R + " is found at pos " + FirstN.ToString());
                }
            }
            writeln(vsh, "answer: "+R);
            writeln(vsh, "CorrectValToBeUniqueForArray finishes working");
            return R;
        }
        //
        public static int FirstSubstringPosN(string where, string what, int FirstN=1)
        {
            int R = 0, N=0;
            int LWhere=0, LWhat = 0, Q;
            bool AllSame;
            string cur;
            if (where != null && what != null)
            {
                LWhere = where.Length;
                LWhat = what.Length;
                if (LWhere > 0 && LWhat > 0 && LWhere >= LWhat)
                {
                    Q = LWhere - LWhat-FirstN+1+1;
                    for (int i = Q; i >=1 ; i--)
                    {
                        //AllSame=true;
                        N=FirstN+i-1;
                        cur = where.Substring(N - 1, LWhat);
                        if(what.Equals(cur)){
                            R = N;
                        }
                        //if (AllSame)
                        //{
                        //    R = N;
                        //}
                    }
                }
            }
            return R;
        }
        public static int[] FindAllPossOfSubstr(string where, string what){
            int[]Ns = null;
            int LWhat = what.Length, LWhere = where.Length, Q = LWhere - LWhat + 1, count=0;
            string cur;
            for (int i = 1; i <= Q; i++)
            {
                cur = where.Substring(i, LWhat);
                if (cur.Equals(what))
                {
                    MyLib.AddToVector(ref Ns, ref count, i);
                }
            }
            return Ns;
        }
        public static string DelAllSubstringSamples(string where, string delim)
        {    
            string r="", cur;
            int LWhere = where.Length, LWhat = delim.Length, Q = LWhere - LWhat+1, L;
            //int[] Ns=null;
            int FromN=1, count=0, N1, N2;
            //
            r = "";
            //for (int i = 1; i <= Q; i++)
            //{
            N1 = FirstSubstringPosN(where, delim, FromN);
            while (N1 > 0)
            {
                N2 = N1 + LWhat;
                L = N1-1-FromN+1;
                cur = where.Substring(FromN-1, L);
                r = r + cur;
                FromN=N2;
                N1 = FirstSubstringPosN(where, delim, FromN);
            }
            if (FromN <= LWhere)
            {
                L = LWhere - FromN + 1;
                cur = where.Substring(FromN-1, L);
                r = r + cur;
            }
            return r;
        }
        public static string DelAllSubstrings(string Where, string[] delims)
        {
            string r = Where;
            int Q = delims.Length;
            for (int i = 1; i <= Q; i++)
            {
                r = DelAllSubstringSamples(r, delims[i - 1]);
            }
            return r;
        }//fn
        public static string SubstringBetweenSubstrings(string where,string substring1, string substring2 = null)
        {
            string found="";;
            int SS1_N1=0, SS1_N2=0, SS2_N1, SS2_N2, L1, L2=0, LWhere, N1=1, N2, LToSeek=0;
            LWhere=where.Length;
            L1 = substring1.Length;

            if (substring2 != null)
            {
                L2 = substring2.Length;
            }
            SS1_N1= FirstSubstringPosN(where, substring1);
            SS1_N2=SS1_N1+L1-1;
            N1=SS1_N2+1;
            if (L2 == 0)
            {
                SS2_N1 = LWhere+1;
                SS2_N2 = SS2_N1;
            }
            else
            {
                SS2_N1= FirstSubstringPosN(where, substring2);
                SS2_N2=SS2_N1+substring2.Length-1;
            }
            N2=SS2_N1-1;
            LToSeek = N2 - N1 + 1;
            if (LToSeek > 0)
            {
                found = where.Substring(N1-1, LToSeek); 
            }
            return found;
        }
    }//cl
}//ns
