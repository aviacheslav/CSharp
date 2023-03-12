using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class PositionInSuccession
    {
        public bool IsLess, IsGreater, IsWithin;
        public int EqualN, LessN;
        public PositionInSuccession()
        {
            IsLess=false; IsGreater=false; IsWithin=false;
            EqualN = 0; LessN = 0;
        }
        public void SetLessThanMin()
        {
            IsLess = true; IsGreater = false; IsWithin = false;
            EqualN = 0; LessN = 0;
        }
        public void SetGreaterThanMax()
        {
            IsLess = false; IsGreater = false; IsWithin = false;
            EqualN = 0; LessN = 0;
        }
        public void SetEqual(int N)
        {
            IsLess = false; IsGreater = false; IsWithin = true;
            EqualN = N; LessN = 0;
        }
        public void SetLessN(int N)
        {
            IsLess = false; IsGreater = false; IsWithin = true;
            EqualN = 0; LessN = N;
        }
    }
    public class MathApprox{
        public double precision;
        public MathApprox()
        {
            precision = 1E-6;
        }
        public MathApprox(double eps)
        {
            precision = Math.Abs(eps);
        }
        public bool ET(double v1, double v2)
        {
            bool b;
            double eps = this.precision;
            b=(Math.Abs(v1-v2)<=eps);
            return b;
        }
        public bool NE(double v1, double v2)
        {
            bool b;
            double eps = this.precision;
            b = (Math.Abs(v1 - v2) > eps);
            return b;
        }
        public bool GT(double v1, double v2)
        {
            bool b;
            double eps = this.precision;
            b = ((v1 - v2) > eps);
            return b;
        }
        public bool LT(double v1, double v2)
        {
            bool b;
            b = this.GT(v2,v1);
            return b;
        }
        public bool GE(double v1, double v2)
        {
            bool gt, et, b;
            gt = this.GT(v1, v2);
            et = this.ET(v1, v2);
            b = gt || et;
            return b;
        }
        public bool LE(double v1, double v2)
        {
            bool lt, et, b;
            lt = this.LT(v1, v2);
            et = this.ET(v1, v2);
            b = lt || et;
            return b;
        }
    }//MathApprox
    public class IterationsPrecision
    {
        public double PrecisionX, PrecisionY;
        public int QX, QY;
        //
        public IterationsPrecision()
        {
            PrecisionX=0.00001; PrecisionY=0.00001; QX=50; QY=50;
        }
        public IterationsPrecision(double PrecisionX, double PrecisionY, int QX, int QY)
        {
            this.PrecisionX=PrecisionX;
            this.PrecisionY=PrecisionY;
            this.QX=QX;
            this.QY = QY;
            if (this.PrecisionX < 0) this.PrecisionX = -this.PrecisionX;
            if (this.PrecisionY < 0) this.PrecisionY = -this.PrecisionY;
            if (this.QX < 0) this.QX = -this.QX;
            if (this.QY < 0) this.QY = -this.QY;
        }
        public void CalcEqualSectsBounds(double a, double b, double eps, int QIni, bool QSectsNotBounds, int Q1Eps2And3Or4, ref int QFin, ref double[]bound){
            int QBounds;
            double dx;
            bound=null;
            QFin = QIni;
            if (QSectsNotBounds)
            {
                QBounds = QIni+1;
            }
            else
            {
                QBounds = QIni;
            }
            if (a != b && QIni>0 && QIni<MyLib.MaxInt)
            {
                if (a > b) MyLib.Swap(ref a, ref b);
                dx = (b - a) / (QBounds - 1);
                if (Q1Eps2And3Or4==2 ||Q1Eps2And3Or4==3)
                {
                    while (dx > eps)
                    {
                        QBounds++;
                        dx = (b - a) / (QBounds - 1);
                        QFin++;
                    }
                }
                bound = new double[QBounds];
                bound[1 - 1] = a;
                for (int i = 1; i <= QBounds-1; i++)
                {
                    bound[i] = a + i * dx;
                }
            }
        }//fn
    }//cl
    public class IterationsConfiguration
    {
        public IterationsPrecision Precision;
        public int Q1Eps2And3Or4;
        public bool QSectsNotBounds;
        public IterationsConfiguration(){
            Precision = new IterationsPrecision();
            Q1Eps2And3Or4 = 3;
            QSectsNotBounds = true;
        }
        public IterationsConfiguration(IterationsPrecision Precision, int Q1Eps2And3Or4, bool QSectsNotBounds)
        {
            this.Precision = Precision;
            this.QSectsNotBounds = QSectsNotBounds;
            this.Q1Eps2And3Or4 = Q1Eps2And3Or4;
            if (Q1Eps2And3Or4 < 1 || Q1Eps2And3Or4 > 41) Q1Eps2And3Or4 = 3;
        }
        public void Show(TValsShowHide vsh)
        {
            //MyLib.writeln(vsh,"Iterations Configuration:");
            MyLib.writeln(vsh, " PrecisionX=" + Precision.PrecisionX.ToString() + " QX=" + Precision.QX.ToString());
            MyLib.writeln(vsh, " PrecisionY=" + Precision.PrecisionY.ToString() + " QY=" + Precision.QY.ToString());
            MyLib.writeln(vsh, " Quantity of sects, not bounds:=" + (MyLib.BoolToInt(QSectsNotBounds)).ToString());
            MyLib.writeln(vsh, " Bounds distribution prioriry: 1 - Quantity of sects/bounds, 2 =- precision, 3 - AND, 4 - OR: " + Q1Eps2And3Or4.ToString());
        }
        public void CalcEqualSectsBounds(double a, double b, double eps, int QIni, bool QSectsNotBounds, int Q1Eps2And3Or4, ref int QFin, ref double[]bound){
            this.CalcEqualSectsBounds(a, b, this.Precision.PrecisionX, this.Precision.QX, this.QSectsNotBounds, this.Q1Eps2And3Or4, ref QFin, ref bound);
        }
    }//cl
    public class DihotSingleSect
    {
        public double a, b, c, x, fa, fb, fc, y;
        public bool SolutionFound;
        public DihotSingleSect()
        {
            a = 0; b = 0; c = 0; x = 0; fa = 0; fb = 0; fc = 0; y = 0;
            SolutionFound = false;
        }
    }
    public static class MyMathLib
    {
        public static bool IsMultiple(int x1, int x2)
        {
            bool verdict;
            int y = 0, y1 = Math.Abs(x1), y2 = Math.Abs(x2);
            while (y < y1)
            {
                y += y2;
            }
            verdict = (y == y1);
            return verdict;
        }
        public static bool IsEvenNotOdd(int x)
        {
            bool verdict;
            verdict = IsMultiple(x,2);
            return verdict;
        }
        //
        public static PositionInSuccession DefPosInSucc(double x, double[] X, int Q){
            PositionInSuccession res;
            res = new PositionInSuccession();
            if(Q>X.Length)Q=X.Length;
            if (x < X[1 - 1]) res.SetLessThanMin();
            else if (x > X[Q - 1]) res.SetGreaterThanMax();
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    if (X[i - 1] == x)
                    {
                        res.SetEqual(i);
                    }
                }
                if (res.EqualN == 0)
                {
                    for (int i = 1; i <= Q-1; i++)
                    {
                        if (X[i - 1] < x && X[i+1-1]>x)
                        {
                            res.SetLessN(i);
                        }
                    }
                }
            }
            return res;
        }
        public static double LInterp(double x, double[]X, double[]Y, int Qe){
            double y=0;
            double x1, x2, y1, y2, k;
            int Qi;
            if (Qe <= X.Length) Qi = Qe;
            else Qi = X.Length;
            if (Qi > Y.Length) Qi = Y.Length;
            PositionInSuccession pos=DefPosInSucc(x,  X, Qi);
            if(pos.EqualN>0){
                y=Y[pos.EqualN-1];
            }
            else{
                if (pos.IsLess)
                {
                    x1 = X[1 - 1];
                    x2 = X[2 - 1];
                    y1 = Y[1 - 1];
                    y2 = Y[2 - 1];
                }
                else if (pos.IsGreater)
                {
                    x1 = X[Qi-1 - 1];
                    x2 = X[Qi - 1];
                    y1 = Y[Qi - 1 - 1];
                    y2 = Y[Qi - 1];
                }
                else
                {
                    x1 = X[pos.LessN - 1];
                    x2 = X[pos.LessN + 1 - 1];
                    y1 = Y[pos.LessN - 1];
                    y2 = Y[pos.LessN + 1 - 1];
                }
                k = (y2 - y1) / (x2 - x1);
                y = k * (x - x1) + y1;
            }
            return y;
        }
        //
        public static void InsertToPosBySort(ref double[]arr, ref int L, double val)
        {
            PositionInSuccession PosData=DefPosInSucc(val, arr, L);
            L=arr.Length;
            if(PosData.IsWithin){
                if(PosData.LessN>0){
                    MyLib.InsToVector(ref arr, ref L, val, PosData.LessN + 1);
                }//else NOP, already exists
            }else{
                if(PosData.IsGreater){
                    MyLib.AddToVector(ref arr, ref L, val);
                }else{
                    MyLib.InsToVector(ref arr, ref L, val, 1);
                }
            }
        }
        //
        public static double IntPower(double x, int p)
        {
            double y = 1;
            if (p == 0) y = 1;
            else if (p == 1) y = x;
            else if (p < 0)
            {
                for (int i = 1; i <= -p; i++)
                {
                    y /= x;
                }
            }
            else
            {
                for (int i = 1; i <= p; i++)
                {
                    y *= x;
                }
            }
            return y;
        }
        public static int fIntNonNegativePower(int x, int p)
        {
            int y = 1;
            if (p < 0) p = -p;
            if (p == 0) y = 1;
            else if (p == 1) y = x;
            else
            {
                for (int i = 1; i <= p; i++)
                {
                    y *= x;
                }
            }
            return y;
        }
        //
        //
        public static void CalcEqualSectsBounds(double a, double b, double eps, int QIni, bool QSectsNotBounds, int Q1Eps2And3Or4, ref int QFin, ref double[] bound)
        {
            int QBounds;
            double dx;
            bound = null;
            QFin = QIni;
            if (QSectsNotBounds)
            {
                QBounds = QIni + 1;
            }
            else
            {
                QBounds = QIni;
            }
            if (a != b && QIni > 0 && QIni < MyLib.MaxInt)
            {
                if (a > b) MyLib.Swap(ref a, ref b);
                dx = (b - a) / (QBounds - 1);
                if (Q1Eps2And3Or4 == 2 || Q1Eps2And3Or4 == 3)
                {
                    while (dx > eps)
                    {
                        QBounds++;
                        dx = (b - a) / (QBounds - 1);
                        QFin++;
                    }
                }
                bound = new double[QBounds];
                bound[1 - 1] = a;
                for (int i = 1; i <= QBounds - 1; i++)
                {
                    bound[i] = a + i * dx;
                }
            }
        }//fn
        //
        //
        public static bool ET(double x1, double x2, MathApprox appr){
            bool verdict;
            if(appr==null){
                if(x1==x2)verdict=true;
                else verdict=false;
            }else{
                if (Math.Abs(x1 - x2) <= Math.Abs(appr.precision)) verdict = true;
                else verdict = false;
            }
            return verdict;
        }
        public static bool NE(double x1, double x2, MathApprox appr)
        {
            bool verdict;
            if (appr == null)
            {
                if (x1 != x2) verdict = true;
                else verdict = false;
            }
            else
            {
                if (Math.Abs(x1 - x2) > Math.Abs(appr.precision)) verdict = true;
                else verdict = false;
            }
            return verdict;
        }
        public static bool GT(double x1, double x2, MathApprox appr)
        {
            bool verdict;
            if (appr == null)
            {
                if (x1 > x2) verdict = true;
                else verdict = false;
            }
            else
            {
                if (x1 > x2 && Math.Abs(x1 - x2) > Math.Abs(appr.precision)) verdict = true;
                else verdict = false;
            }
            return verdict;
        }
        public static bool GE(double x1, double x2, MathApprox appr)
        {
            bool verdict;
            if(ET(x1,x2,appr)||GT(x1,x2,appr)) verdict=true;
            else verdict=false;
            return verdict;
        }
        public static bool LT(double x1, double x2, MathApprox appr)
        {
            bool verdict;
            if (appr == null)
            {
                if (x1 < x2) verdict = true;
                else verdict = false;
            }
            else
            {
                if (x1 < x2 && Math.Abs(x1 - x2) > Math.Abs(appr.precision)) verdict = true;
                else verdict = false;
            }
            return verdict;
        }
        public static bool LE(double x1, double x2, MathApprox appr)
        {
            bool verdict;
            if (ET(x1, x2, appr) || LT(x1, x2, appr)) verdict = true;
            else verdict = false;
            return verdict;
        }
        //
        public static bool ET(double x1, double x2, double eps)
        {
            bool verdict;
            if (Math.Abs(x1 - x2) <= Math.Abs(eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        public static bool NE(double x1, double x2, double eps)
        {
            bool verdict;
            if (Math.Abs(x1 - x2) > Math.Abs(eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        public static bool GT(double x1, double x2, double eps)
        {
            bool verdict;
            if (x1 > x2 && Math.Abs(x1 - x2) > Math.Abs(eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        public static bool GE(double x1, double x2, double eps)
        {
            bool verdict;
            if (ET(x1, x2, eps) || GT(x1, x2, eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        public static bool LT(double x1, double x2, double eps)
        {
            bool verdict;
            if (x1 < x2 && Math.Abs(x1 - x2) > Math.Abs(eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        public static bool LE(double x1, double x2, double eps)
        {
            bool verdict;
            if (ET(x1, x2, eps) || LT(x1, x2, eps)) verdict = true;
            else verdict = false;
            return verdict;
        }
        //
        //
        public static int fNOfNatN(int NatN, int Orig)
        {
            int N;
            N = NatN + Orig - 1;
            return N;
        }
        public static int fNatNOfN(int N, int Orig){
            int NatN;
            NatN = N - Orig + 1;
            return NatN;
        }
        //
        //
        //public static double IntTrap(Delegate fn, double a, double b, Matrix Params){
        //    double r;
        //    r = 0;
        //    return r;
        //}
        //
        //
        public static void QuadraticEquation(double a, double b, double c, ref double D, ref double Re1, ref double Im1, ref double Re2, ref double Im2){
            D=b*b-4*a*c;
            Re1=-b/(2*a);
            Re2=-b/(2*a);
            if(D<0){
                Im1=-Math.Sqrt(-D)/(2*a);
                Im2 = Math.Sqrt(-D) / (2 * a);
            }else{
                Re1 -= Math.Sqrt(D) / (2 * a);
                Re2 += Math.Sqrt(D) / (2 * a);
                Im1=0;
                Im2=0;
            }
        }
        public static void CubicEquation(double c3, double c2, double c1, double c0, ref double Re1, ref double Re2, ref double Im2, ref double Re3, ref double Im3, ref string[]s){
            s=new string[6];
            s[1-1]="c3="+c3.ToString()+" c2="+c2.ToString()+" c1="+c1.ToString()+" c0="+c0.ToString();
            double a, b, c, A, B, p, q, Q, alfa, CosAlfa, ReY1, ReY2, ReY3;
            a=c2/c3; b=c1/c3; c=c0/c3;
            p=-a*a/3+b;
            q=2*a*a*a/27-a*b/3+c;
            Q=p*p*p/27+q*q/4;
            B = 0; CosAlfa = 0; alfa = 0; A = 0;
            s[2-1]="p="+p.ToString()+" q="+q.ToString()+" Q="+Q.ToString();
            if(Q<0){
                s[3-1]="Equation has 3 real not equal roots";
                CosAlfa=-q/(2*Math.Sqrt(-(p/3)*(p/3)*(p/3)));
                alfa=Math.Acos(CosAlfa);
                ReY1 = 2.0 * Math.Sqrt(-(p / 3.0)) * Math.Cos(alfa / 3.0);
                ReY2 = 2 * Math.Sqrt(-(p / 3)) * Math.Cos(alfa / 3 + 2 * Math.PI / 3);
                ReY3 = 2 * Math.Sqrt(-(p / 3)) * Math.Cos(alfa / 3 - 2 * Math.PI / 3);
                Im2=0; Im3=0;
            }else{
                if(Q>0)s[3-1]="Equation has 1 real and 2 complex roots";
                else  s[3-1]="Equation has 3 real roots, min 2 of them are equal";
                if ((-q / 2 + Math.Sqrt(Q)) >= 0)
                {
                    A = Math.Pow((-q / 2 + Math.Sqrt(Q)), 1 / 3.0);
                }else{
                    A = -Math.Pow(-(-q / 2 + Math.Sqrt(Q)), 1 / 3.0);
                }
                if ((-q / 2 - Math.Sqrt(Q)) >= 0)
                {
                    B = Math.Pow((-q / 2 - Math.Sqrt(Q)), 1 / 3.0);
                }else{
                    B = -Math.Pow(-(-q / 2 - Math.Sqrt(Q)), 1 / 3.0);
                }
                ReY1=A+B;
                //Im1=0;
                ReY2=-(A+B)/2;
                Im2 = (A - B) / 2.0 * Math.Sqrt(3);
                ReY3=ReY2;
                Im3=-Im2;
            }
            s[4-1]="-(p/3)*(p/3)*(p/3)="+(-(p/3)*(p/3)*(p/3)).ToString()+" ";
            if(!(Q<0))s[4-1]+=" A="+A.ToString()+" B="+B.ToString();
            else s[4-1]+=" can't calculate A & B ";
            if (!(Q > 0)) s[4 - 1] += " Cos(alfa)= " + (CosAlfa).ToString() + " alfa=" + (alfa).ToString();
            else s[4-1]+=" can't calculate cos & alfa ";
            s[5 - 1] += " ReY1=" + (ReY1).ToString() + " ReY2=" + (ReY2).ToString() + " ReY3=" + (ReY3).ToString();
            Re1=ReY1-a/3;
            Re2=ReY2-a/3;
            Re3=ReY3-a/3;
            s[6 - 1] += " Re1=" + (Re1).ToString() + " Re2=" + (Re2).ToString() + " Re3=" + (Re3).ToString();
        }

        public static bool EquationOf4thPower(double c4, double c3, double c2, double c1, double c0, ref double Re1, ref double Im1, ref double Re2, ref double Im2, ref double Re3, ref double Im3, ref double Re4, ref double Im4,ref string[]s){
            double e2pD;
            bool AllRight=true;
            string[] si=new string[27];
            string []ResolveStr=null;
            double ResolvC3, ResolvC2, ResolvC1, ResolvC0;//, CubicReRoot1;
            double Eq1C2,  Eq1C1, Eq1C0, Eq2C2,  Eq2C1, Eq2C0;
            double Root1Eq1Re1, Root1Eq1Im1, Root2Eq1Re2, Root2Eq1Im2,
               Root3Eq2Re1, Root3Eq2Im1, Root4Eq2Re2, Root4Eq2Im2,
               ResolvRe1, ResolvRe2, ResolvIm2, ResolvRe3, ResolvIm3;
            double p,q,r;
            double a=c3/c4, b=c2/c4, c=c1/c4, d=c0/c4;
            //
            e2pD = 0; ResolvRe1 = 0; ResolvRe2 = 0; ResolvIm2 = 0; ResolvRe3 = 0; 
            ResolvIm3 = 0; Root3Eq2Re1 = 0; Root3Eq2Im1 = 0; Root4Eq2Re2 = 0; Root4Eq2Im2 = 0;
            Root1Eq1Re1 = 0; Root1Eq1Im1 = 0; Root2Eq1Re2 = 0; Root2Eq1Im2 = 0;   
            //Root1Eq2Re1 = 0; Root1Eq2Im1 = 0; Root2Eq2Re2 = 0; Root2Eq2Im2 = 0;
            //
            p=b-3*a*a/8;
            q=a*a*a/8-a*b/2+c;
            r=-3*a*a*a*a/256+a*a*b/16-c*a/4+d;
            ResolvC3=2;
            ResolvC2=-p;
            ResolvC1=-2*r;
            ResolvC0=r*p-q*q/4;
            si[1-1]="Supplementary Coefficients p="+p.ToString()+" q="+q.ToString()+" r="+r.ToString();
            si[2-1]="Cubic resolvent: "+ResolvC3.ToString()+"*y^3+"+ResolvC2.ToString()+"*y^2+"+ResolvC1.ToString()+"*y+"+ResolvC0.ToString()+"=0";
            CubicEquation(ResolvC3, ResolvC2, ResolvC1, ResolvC0, ref ResolvRe1, ref ResolvRe2, ref ResolvIm2, ref ResolvRe3, ref ResolvIm3, ref ResolveStr);
            si[3-1]="1st Solution of Cubic Resolvent: "+ResolvRe1.ToString();
            si[4-1]="Checking: "+(ResolvC3*ResolvRe1*ResolvRe1*ResolvRe1+ResolvC2*ResolvRe1*ResolvRe1+ResolvC1*ResolvRe1+ResolvC0).ToString();
            si[5-1]=ResolveStr[1-1];
            si[6-1]=ResolveStr[2-1];
                si[7-1]=ResolveStr[3-1];
            si[8-1]=ResolveStr[4-1];
            si[9-1]=ResolveStr[5-1];
                si[10-1]=ResolveStr[6-1];
            si[11-1]="It was info from cubic resolvent. Now again equation of 4th power";
            if(ResolvRe1<=p/2){
                //MessageBox.Show("Equation can't be replaced by equivalent quadratic equations with real coefs!");
                AllRight=false;
                Root1Eq1Re1=666; Root1Eq1Im1=666; Root2Eq1Re2=666; Root2Eq1Im2=666;
                Root3Eq2Re1=666; Root3Eq2Im1=666; Root4Eq2Re2=666; Root4Eq2Im2=666;
                si[12-1]="can't calculate the real coefs of equivalent cuadratic equations";
                si[13-1]="2y1-p=2*"+ResolvRe1.ToString()+"-"+p.ToString()+"="+(2*ResolvRe1-p).ToString();
                for(int i=14; i<=27; i++){
                    si[14-1]=" ";
                }
            }else{
                si[12-1]="No problem with solution";
                Eq1C2=1;
                Eq1C1=-Math.Sqrt(2*ResolvRe1-p);
                Eq1C0 = q / (2 * Math.Sqrt(2 * ResolvRe1 - p)) + ResolvRe1;
                si[13-1]="First quadratic equation: "+Eq1C2.ToString()+"*x^2+"+Eq1C1.ToString()+"*x+"+Eq1C0.ToString()+"=0";
                Eq2C2=Eq1C2;
                Eq2C1=-Eq1C1;
                Eq2C0=-q/(2*Math.Sqrt(2*ResolvRe1-p))+ResolvRe1;
                si[14-1]="Second quadratic equation: "+Eq2C2.ToString()+"*x^2+"+Eq2C1.ToString()+"*x+"+Eq2C0.ToString()+"=0";
                QuadraticEquation(Eq1C2, Eq1C1, Eq1C0, ref e2pD,  ref Root1Eq1Re1, ref Root1Eq1Im1, ref Root2Eq1Re2, ref Root2Eq1Im2);
                QuadraticEquation(Eq2C2, Eq2C1, Eq2C0, ref e2pD,  ref Root3Eq2Re1, ref Root3Eq2Im1, ref Root4Eq2Re2, ref Root4Eq2Im2);
                si[15-1]="ANSWER:";
                si[16-1]="1st Y: ";
                if(Root1Eq1Im1==0){
                    si[16-1]+=Root1Eq1Re1.ToString();
                }else{
                    si[16-1]+=Root1Eq1Re1.ToString()+"+i*"+Root1Eq1Im1.ToString();
                }
                si[17-1]="2nd Y: ";
                if(Root2Eq1Im2==0){
                    si[17-1]+=Root2Eq1Re2.ToString();
                }else{
                    si[17-1]+=Root2Eq1Re2.ToString()+"+i*"+Root2Eq1Im2.ToString();
                }
                si[18-1]="3rd Y: ";
                if (Root3Eq2Im1 == 0)
                {
                    si[18 - 1] += Root3Eq2Re1.ToString();
                }
                else
                {
                    si[18 - 1] += Root3Eq2Re1.ToString() + "+i*" + Root3Eq2Im1.ToString();
                }
                si[19-1]="4th Y: ";
                if(Root4Eq2Im2==0){
                    si[19-1]+=Root4Eq2Re2.ToString();
                }else{
                    si[19-1]+=Root4Eq2Re2.ToString()+"+i*"+Root4Eq2Im2.ToString();
                }
                //
                Root1Eq1Re1-=a/4;
                Root2Eq1Re2-=a/4;
                Root3Eq2Re1-=a/4;
                Root4Eq2Re2-=a/4;
                si[20-1]="1st Root: ";
                if(Root1Eq1Im1==0){
                    si[20-1]+=Root1Eq1Re1.ToString();
                }else{
                    si[20-1]+=Root1Eq1Re1.ToString()+"+i*"+Root1Eq1Im1.ToString();
                }
                si[21-1]="2nd Root: ";
                if(Root2Eq1Im2==0){
                    si[21-1]+=Root2Eq1Re2.ToString();
                }else{
                    si[21 - 1] += Root2Eq1Re2.ToString() + "+i*" + Root2Eq1Im2.ToString();
                }
                si[22-1]="3rd Root: ";
                if(Root3Eq2Im1==0){
                    si[22 - 1] += Root3Eq2Re1.ToString();
                }else{
                    si[22-1]+=Root3Eq2Re1.ToString()+"+i*"+Root3Eq2Im1.ToString();
                }
                si[23-1]="4th Root: ";
                if(Root4Eq2Im2==0){
                    si[23-1]+=Root4Eq2Re2.ToString();
                }else{
                    si[23 - 1] += Root4Eq2Re2.ToString() + "+i*" + Root4Eq2Im2.ToString();
                }
                //
                if(Root1Eq1Im1==0){
                    si[24-1]="Checking Root 1: "+(Root1Eq1Re1*Root1Eq1Re1*Root1Eq1Re1*Root1Eq1Re1+a*Root1Eq1Re1*Root1Eq1Re1*Root1Eq1Re1+b*Root1Eq1Re1*Root1Eq1Re1+c*Root1Eq1Re1+d).ToString();
                }else{
                    si[24-1]="  ";
                }
                if(Root2Eq1Im2==0){
                    si[25 - 1] = "Checking Root 2: " + (Root2Eq1Re2 * Root2Eq1Re2 * Root2Eq1Re2 * Root2Eq1Re2 + a * Root2Eq1Re2 * Root2Eq1Re2 * Root2Eq1Re2 + b * Root2Eq1Re2 * Root2Eq1Re2 + c * Root2Eq1Re2 + d).ToString();
                }else{
                    si[25-1]="  ";
                }
                if(Root3Eq2Im1==0){
                    si[26 - 1] = "Checking Root 3: " + (Root3Eq2Re1 * Root3Eq2Re1 * Root3Eq2Re1 * Root3Eq2Re1 + a * Root3Eq2Re1 * Root3Eq2Re1 * Root3Eq2Re1 + b * Root3Eq2Re1 * Root3Eq2Re1 + c * Root3Eq2Re1 + d).ToString();
                }else{
                    si[26-1]="  ";
                }
                if(Root4Eq2Im2==0){
                    si[27 - 1] = "Checking Root 4: " + (Root4Eq2Re2 * Root4Eq2Re2 * Root4Eq2Re2 * Root4Eq2Re2 + a * Root4Eq2Re2 * Root4Eq2Re2 * Root4Eq2Re2 + b * Root4Eq2Re2 * Root4Eq2Re2 + c * Root4Eq2Re2 + d).ToString();
                }else{
                    si[27-1]="  ";
                }
            }
            Re1=Root1Eq1Re1; Im1=Root1Eq1Im1; Re2=Root2Eq1Re2; Im2=Root2Eq1Im2;
            Re3=Root3Eq2Re1; Im3=Root3Eq2Im1; Re4=Root4Eq2Re2; Im4=Root4Eq2Im2;
            s=si;
            return AllRight;
        }
        public static void SolvePolynomialEquation(double[] c, int MaxPow, ref double[] ReX, ref double[] ImX, ref int Err, ref string[] ControlStr)
        {
            double Discr = 0;
            ReX = null; ImX = null; ControlStr = null;
            if (c[MaxPow] != 0 && MaxPow >= 1 && MaxPow < MyLib.MaxInt)
            {
                ReX = new double[MaxPow + 1];
                ImX = new double[MaxPow + 1];
                if (MaxPow == 1)
                {
                    ReX[0] = -c[0] / c[1];
                    ImX[0] = 0;
                }
                else if (MaxPow == 2)
                {
                    MyMathLib.QuadraticEquation(c[2], c[1], c[0], ref Discr, ref ReX[1 - 1], ref ImX[1 - 1], ref ReX[2 - 1], ref ImX[2 - 1]);
                }
                else if (MaxPow == 3)
                {
                    ImX[1 - 1] = 0;
                    //void CubicEquation(double c3, double c2, double c1, double c0, ref double Re1, ref double Re2, ref double Im2, ref double Re3, ref double Im3, ref string[]s){
                    MyMathLib.CubicEquation(c[3], c[2], c[1], c[0], ref ReX[1 - 1], ref ReX[2 - 1], ref ImX[2 - 1], ref ReX[3 - 1], ref ImX[3 - 1], ref ControlStr);
                }
                else if (MaxPow == 4)
                {
                    MyMathLib.EquationOf4thPower(c[4], c[3], c[2], c[1], c[0], ref ReX[1 - 1], ref ImX[1 - 1], ref ReX[2 - 1], ref ImX[2 - 1], ref ReX[3 - 1], ref ImX[3 - 1], ref ReX[4 - 1], ref ImX[4 - 1], ref ControlStr);
                }
                else
                {

                }
            }
        }
        //
        public static double F(double x, int FnN = 1)
        {
            double y = 0;
            switch (FnN)
            {
                case 1:
                    y = Math.Sin(x);
                    break;
            }
            return y;
        }

        public static DihotSingleSect Dihot_Single(double LBnd, double HBnd, IterationsPrecision precision, int FnN=1)
        {
            DihotSingleSect r = new DihotSingleSect();
            bool cond = true;
            r.a = LBnd;
            r.b = HBnd;
            r.fa = F(r.a, FnN);
            r.fb = F(r.b, FnN);
            cond = (r.b - r.a < precision.PrecisionX || Math.Abs(r.fa) < precision.PrecisionY || Math.Abs(r.fb) < precision.PrecisionY || r.fa * r.fb < 0);
            while (cond)
            {
                r.c = (r.a + r.b) / 2;
                if (r.fa * r.fc < 0) r.b = r.c;
                if (r.fc * r.fb < 0) r.c = r.a;
                r.fa = F(r.a, FnN);
                r.fb = F(r.b, FnN);
                r.fc = F(r.c, FnN);
                cond = (r.b - r.a < precision.PrecisionX || Math.Abs(r.fa) < precision.PrecisionY || Math.Abs(r.fb) < precision.PrecisionY || Math.Abs(r.fc) < precision.PrecisionY);
            }
            if (cond)
            {
                if (r.b - r.a < precision.PrecisionX)
                {
                    r.x = r.c;
                    r.y = r.fc;
                }
                if (Math.Abs(r.fa) < precision.PrecisionY)
                {
                    r.x = r.a;
                    r.y = r.fa;
                }
                if (Math.Abs(r.fb) < precision.PrecisionY)
                {
                    r.x = r.b;
                    r.y = r.fb;
                }
                if (Math.Abs(r.fc) < precision.PrecisionY)
                {
                    r.x = r.c;
                    r.y = r.fc;
                }
            }
            r.SolutionFound = cond;
            return r;
        }//Dihot single
        public static void Dichotomy_SimpleFull(double LBnd, double HBnd, IterationsConfiguration cfg, ref int CountRoots, ref double[] roots, ref double[] vals, ref double[] bounds, int FnN = 1, TValsShowHide vsh = null)
        {
            //int count_tmp;
            CountRoots = 0;
            //double[] bounds = null;
            bool QSectsNotBounds = cfg.QSectsNotBounds;
            int Q1Eps2And3Or4 = cfg.Q1Eps2And3Or4;
            int QSectsOrBoundsFin = cfg.Precision.QX;
            int QBoundsFin;
            DihotSingleSect CurSectResult;
            bounds=null;
            //public void CalcEqualSectsBounds(double a, double b, double eps, int QIni, bool QSectsNotBounds, int Q1Eps2And3Or4, ref int QFin, ref double[]bound)/
            cfg.Precision.CalcEqualSectsBounds(LBnd, HBnd, cfg.Precision.PrecisionX, cfg.Precision.QX, QSectsNotBounds, Q1Eps2And3Or4, ref QSectsOrBoundsFin, ref bounds);
            if (QSectsNotBounds) QBoundsFin = QSectsOrBoundsFin + 1;
            else QBoundsFin = QSectsOrBoundsFin;
            MyLib.writeln(vsh, "Iterations Configuration:");
            cfg.Show(vsh);
            MyLib.writeln(vsh, "Bounds of sects defined:");
            for (int i = 1; i <= QBoundsFin - 1; i++) MyLib.writeln(vsh, i.ToString() + ") " + bounds[i - 1] + " ... " + bounds[i]);
            MyLib.writeln(vsh, "Solution:");
            for (int i = 1; i <= QBoundsFin - 1; i++)
            {
                CurSectResult = Dihot_Single(bounds[i - 1], bounds[i], cfg.Precision, FnN);
                if (CurSectResult.SolutionFound)
                {
                    //CountRoots++;
                    if (CountRoots == 1)
                    {
                        roots = new double[1];
                        vals = new double[1];
                        roots[CountRoots - 1] = CurSectResult.x;
                        vals[CountRoots - 1] = CurSectResult.y;
                    }
                    else
                    {
                        //count_tmp=CountRoots-1;
                        MyLib.AddToVector<double>(ref roots, ref CountRoots, CurSectResult.x);
                        CountRoots--;//tmp'y
                        MyLib.AddToVector<double>(ref vals, ref CountRoots, CurSectResult.y);
                    }
                }
            }
        }//dihot simple full
        //
        public static Matrix MatrixOfDirCossByEulersAngles(double gamma, double psi, double theta)
        {
            Matrix MR=new Matrix(3,3);
            MR.SetComponent(Math.Cos(psi)*Math.Cos(theta),1,1);
            MR.SetComponent(Math.Sin(psi)*Math.Sin(gamma)-Math.Cos(psi)*Math.Sin(theta)*Math.Cos(gamma),1,2);
            MR.SetComponent(Math.Sin(psi)*Math.Cos(gamma)+Math.Cos(psi)*Math.Sin(theta)*Math.Sin(gamma),1,3);
            MR.SetComponent(Math.Sin(theta),2,1);
            MR.SetComponent(Math.Cos(theta)*Math.Cos(gamma),2,2);
            MR.SetComponent(-Math.Cos(theta)*Math.Sin(gamma),2,3);
            MR.SetComponent(-Math.Sin(psi)*Math.Cos(theta),3,1);
            MR.SetComponent(Math.Cos(psi)*Math.Sin(gamma)+Math.Sin(psi)*Math.Sin(theta)*Math.Cos(gamma),3,2);
            MR.SetComponent(Math.Cos(psi) * Math.Cos(gamma) - Math.Sin(psi) * Math.Sin(theta) * Math.Sin(gamma), 3, 3);
            return MR;
        }
    }//cl
    public class PolynomialEquation
    {
        double[] c, ReX, ImX;
        int MaxPow;
        bool solved;
        //
        public PolynomialEquation() {
            Set0();
        }
        public PolynomialEquation(int MaxPow)
        { this.SetPowFirst(MaxPow); }
        public PolynomialEquation(int MaxPow, double[] c)
        { this.SetTask(MaxPow, c); }
        public void Set(int MaxPow, double[] c){
            this.MaxPow=MaxPow;
            if (MaxPow > 0 && MaxPow < MyLib.MaxInt)
            {
                this.c = new double[MaxPow + 1];
                for (int i = 1; i <= MaxPow + 1; i++)
                {
                    this.c[i - 1] = c[i - 1];
                }
            }
            solved = false;
        }
        
        public void SetPowFirst(int MaxPow)
        {
            this.MaxPow = MaxPow;
            c = new double[MaxPow + 1];
            ReX = new double[MaxPow];
            ImX = new double[MaxPow];
            c[0] = 0;
            for (int i = 1; i <= MaxPow; i++)
            {
                c[i - 1] = 0; ReX[i - 1] = 0; ImX[i - 1] = 0;
            }
            solved = false;
        }
        public void SetPowNew(int MaxPow)
        {
            SetPowFirst(MaxPow);
        }
        public void SetTask(int MaxPow, double[] c)
        {
            SetPowFirst(MaxPow);
            for(int i=0; i<=MaxPow; i++){
                this.c[i] = c[i];
            }
            ReX = new double[MaxPow];
            ImX = new double[MaxPow];
            for (int i = 1; i <= MaxPow; i++)
            {
                ReX[i - 1] = 0; ImX[i - 1] = 0;
            }
            solved = false;
        }
        public void SetPow_ChangingTo(int MaxPowNew)
        {
            int MaxPowOld=MaxPow, diff=MaxPowNew - MaxPowOld;
            if (diff > 0)
            {
                for (int i = 1; i <= diff; i++){
                    MyLib.AddToVector(ref c, ref MaxPow, 0);
                    MaxPow=MaxPowOld;
                    MyLib.AddToVector(ref ReX, ref MaxPow, 0);
                    MaxPow=MaxPowOld;
                    MyLib.AddToVector(ref ImX, ref MaxPow, 0);
                }
            }
            else if(diff<0)
            {
                for (int i = 1; i <= -diff; i++)
                {
                    MyLib.DelInVector(ref c, ref MaxPow, MaxPow);
                    MaxPow = MaxPowOld;
                    MyLib.DelInVector(ref ReX, ref MaxPow, MaxPow - 1);
                    MaxPow = MaxPowOld;
                    MyLib.DelInVector(ref ImX, ref MaxPow, MaxPow - 1);
                }
            }
            solved = false;
        }
        public void Set0()
        {
            double[] c = new double[2];
            for (int i = 0; i <= 1; i++) c[i] = 0;
            SetTask(1, c);
            solved = false;
        }
        public void Get(ref int MaxPow, ref double[] c)
        {
            MaxPow=this.MaxPow;
            c=new double[MaxPow+1];
            for(int i=1; i<=MaxPow+1;i++){
                c[i-1]=this.c[i-1];
            }
        }
        public void Solve(ref double[] ReX, ref double[] ImX, ref int Err, ref string[] ControlStr)
        {
            MyMathLib.SolvePolynomialEquation(this.c, this.MaxPow, ref ReX, ref ImX, ref Err, ref ControlStr);
            solved = true;
        }
        public void Solve()
        {
            int Err=0;
            string[] ControlStr=null;
            Solve(ref ReX, ref ImX, ref Err, ref  ControlStr);
        }
        public void ShowIniData(TValsShowHide vsh)
        {
            for(int i=0; i<=MaxPow; i++){
                MyLib.writeln(vsh, "c" + i.ToString() + "=" + c[i].ToString());
            }
        }
        public void ShowResults(TValsShowHide vsh)
        {
            if (!solved) MyLib.writeln(vsh, "Not solved yet");
            else
            {
                for (int i = 1; i <= MaxPow; i++)
                {
                    MyLib.writeln(vsh, " ReX"+i.ToString()+"= " + ReX[i - 1].ToString() + " ImX"+i.ToString()+"= " + ImX[i - 1].ToString());
                    if (ImX[i - 1] > 0)
                    {
                         MyLib.writeln(vsh, "Root " + i.ToString()+": "+ReX[i-1].ToString()+" + i*"+ImX[i-1].ToString());
                    }
                    else if (ImX[i - 1] < 0)
                    {
                        MyLib.writeln(vsh, "Root " + i.ToString() + ": " + ReX[i - 1].ToString() + " - i*" + ImX[i - 1].ToString());
                    }
                    else
                    {
                        MyLib.writeln(vsh, "Root " + i.ToString() + ": " + ReX[i - 1].ToString());
                    }
                }
            }
        }
        /*public TTable IniDataToTable()
        {
            //double[] C = new double[1];
            TTable tbl;
            tbl = new TTable(TableConsts.DoubleTypeN, TableConsts.StringTypeN, 0, 1);
            string TableName="EqCoefs", LGHeader="C";
            bool PreserveVals=false, WriteInfo=false;
            //public void SetTableAs_1ParamList(string ListName, string ItemsGenName, bool ItemNamesExist, int[]ItemTypeN, string[] ItemName, int QItems)
            //tbl.SetTableAs_1ParamList(TableName, LGHeader, false, null, null, this.MaxPow + 1);
            tbl.SetTableAs_1ParamList(null, this.MaxPow + 1, new DataCell(TableName), new DataCellRow(c, this.MaxPow + 1), PreserveVals, WriteInfo); 
            //C[1-1]=c[1-1];
            //tbl.SetLine_SnglType(1, "", C);
            //for (int i = 2; i <= this.MaxPow+1; i++)
            //{
            //    C[1-1]=c[i-1];
            //    tbl.AddLine_SnglType(C);
            //}
            TableRepresentation repr = new TableRepresentation();
            repr.GenRepr.ShowColOfLineHeader = true;
            repr.GenRepr.LoCHNumerationStartFromN=0;
            repr.LineHeaderRepr.Set_SimpleNumerated();
            tbl.SetTableRepresentation(repr);
            return tbl;
        }*/
        public TTable IniDataToTable()
        {
            TTable tbl;
            tbl = new TTable(); //tbl = new TTable(TableConsts.DoubleTypeN, TableConsts.StringTypeN, 0, 1);
            //bool PreserveVals = false, WriteInfo = false;
            //public void SetTableAs_1ParamList(string[] ItemNames, int QItems, DataCellRow Items, DataCell ListName, string ItemsGenNameExt="", bool PreserveVals = false, bool WriteInfo = true, TableInfo TblInfOldExt = null)
            tbl.SetTableAs_1ParamList(null, this.MaxPow + 1, new DataCellRow(c, this.MaxPow + 1), new DataCell("Equation Coefficients"), "C");
            //
            TableRepresentation repr = new TableRepresentation();
            TableUssagePolicy UsePol = new TableUssagePolicy();
            //
            repr.dets.GenRepr.ShowColOfLineHeader = true;
            repr.dets.GenRepr.LinesNumerationStartFromN = 0;
            repr.dets.GenRepr.LinesNumerationStep = 1;
            repr.dets.LineHeaderRepr.Set_SimpleNumerated(); //power
            repr.dets.LineHeaderRepr.GenRowNameBef = true; //C
            //
            repr.dets.ColHeaderRepr.GenRowNameAft = false;
            repr.dets.ColHeaderRepr.GenRowNameBef = false;
            repr.dets.ColHeaderRepr.RowNAft = false;
            repr.dets.ColHeaderRepr.RowNBef = false;
            //
            repr.dets.ContentRepr.LineHeaderExists = false;
            repr.dets.ContentRepr.ColHeaderExists = false;
            //
            //-----------------------------------------
            //repr.GenRepr.ShowColOfLineHeader = true;
            //repr.GenRepr.LinesNumerationStartFromN = 0;
            //repr.GenRepr.LinesNumerationStep = 1;
            //repr.LineHeaderRepr.Set_SimpleNumerated(); //power
            //repr.LineHeaderRepr.GenRowNameBef = true; //C
            ////
            //repr.ColHeaderRepr.GenRowNameAft = false;
            //repr.ColHeaderRepr.GenRowNameBef = false;
            //repr.ColHeaderRepr.RowNAft = false;
            //repr.ColHeaderRepr.RowNBef = false;
            ////
            //repr.ContentRepr.LineHeaderExists = false;
            //repr.ContentRepr.ColHeaderExists = false;
            //
            tbl.SetTableTextRepresentation(repr);
            tbl.SetTableGridRepresentation(repr);
            //tbl.SetTableRepresentation(repr);
            UsePol.ForbidAll();
            UsePol.LinesCanAdd = true;
            UsePol.LinesCanDel = true;
            UsePol.LinesCanIns = true;
            UsePol.QLinesMinDefined = true;
            UsePol.QLinesMin = 2;
            UsePol.QLinesMaxDefined = true;
            UsePol.QLinesMax = 6;
            tbl.SetUssagePolicy(UsePol);
            //
            return tbl;
        }
        public TTable ResultsToTable()
        {
            TTable tbl;
            string TableName = "EqRoots", LGHeader = "C";
            string[] ParamName;
            bool ParamsNotItems=true;
            int[]ItemTypeN;
            ItemTypeN=new int[this.MaxPow+1];
            for(int i=1; i<=this.MaxPow+1; i++) ItemTypeN[i-1]=3;
            tbl = new TTable();
            ParamName=new string[2];
            ParamName[1-1]="ReX"; ParamName[2-1]="ImX";
            DataCellRow[] cnt=new DataCellRow[2];
            for(int i=1; i<=2; i++){
                if(i==1) cnt[i-1]=new DataCellRow(ReX,MaxPow); 
                if(i==2) cnt[i-1]=new DataCellRow(ImX,MaxPow);
            }
            //public void SetTableAs_MultyParamList(string[] ItemNames, int QItems, bool ParamsNotItems, DataCell ListName, DataCellRow[] ItemsOrParams, DataCellRow ParamsNames, string ItemsGeneralName="", bool PreserveVals=false, bool WriteInfo=true, TableInfo TblInfOldExt = null)
            tbl.SetTableAs_MultyParamList(
                null,
                MaxPow,
                2,
                ParamsNotItems,
                new DataCell(TableName),
                cnt,
                new DataCellRow(ParamName,2)
            );
            /*TableRepresentation repr = new TableRepresentation();
            repr.GenRepr.ShowColOfLineHeader = true;
            repr.GenRepr.LoCHNumerationStartFromN = 0;
            repr.LineHeaderRepr.Set_SimpleNumerated();
            
            tbl.SetTableRepresentation(repr);*/
            TableRepresentation repr = new TableRepresentation();
            //
            //repr.GenRepr.ShowColOfLineHeader = true;
            //////repr.GenRepr.LoCHNumerationStartFromN = 0;
            ////repr.GenRepr.CoLHNumerationStartFromN = 0;
            //repr.GenRepr.LinesNumerationStartFromN =1;
            //repr.GenRepr.LinesNumerationStep = 1;
            //repr.LineHeaderRepr.Set_SimpleNumerated(); //power
            //repr.LineHeaderRepr.GenRowNameBef = true; //C
            ////
            //repr.ColHeaderRepr.GenRowNameAft = false;
            //repr.ColHeaderRepr.GenRowNameBef = false;
            //repr.ColHeaderRepr.RowNAft = false;
            //repr.ColHeaderRepr.RowNBef = false;
            ////
            //repr.ContentRepr.LineHeaderExists = false;
            //repr.ContentRepr.ColHeaderExists = false;
            //
            //
            repr.dets.GenRepr.ShowColOfLineHeader = true;
            ////repr.GenRepr.LoCHNumerationStartFromN = 0;
            //repr.GenRepr.CoLHNumerationStartFromN = 0;
            repr.dets.GenRepr.LinesNumerationStartFromN = 1;
            repr.dets.GenRepr.LinesNumerationStep = 1;
            repr.dets.LineHeaderRepr.Set_SimpleNumerated(); //power
            repr.dets.LineHeaderRepr.GenRowNameBef = true; //C
            //
            repr.dets.ColHeaderRepr.GenRowNameAft = false;
            repr.dets.ColHeaderRepr.GenRowNameBef = false;
            repr.dets.ColHeaderRepr.RowNAft = false;
            repr.dets.ColHeaderRepr.RowNBef = false;
            //
            repr.dets.ContentRepr.LineHeaderExists = false;
            repr.dets.ContentRepr.ColHeaderExists = false;
            //
            //
            tbl.SetTableTextRepresentation(repr);
            tbl.SetTableGridRepresentation(repr);
            //tbl.SetTableRepresentation(repr);
            return tbl;
        }
    }//cl
    //
    public class PolynomialEqSolver
    {
        bool solved;
        double[] c;
        double[] ReX, ImX;
        int ord;
        public PolynomialEqSolver() {
            SetIni();
        }
        public PolynomialEqSolver(int ord, double[]c) {
            set(ord, c);
        }
        public void set(int ord, double[] c)
        {
            this.ord = ord;
            this.c = new double[ord + 1];
            for (int i = 1; i <= ord + 1; i++) this.c[i - 1] = c[i - 1];
            this.ReX = new double[ord];
            this.ImX = new double[ord];
            for (int i = 1; i <= ord; i++)
            {
                ReX[i - 1] = 0; ImX[i - 1] = 0;
            }
            solved = false;
        }
        public void SetIni()
        {
            this.ord = 1;
            this.c = new double[ord + 1];
            for (int i = 1; i <= ord + 1; i++) this.c[i - 1] = 0;
            this.ReX = new double[ord];
            this.ImX = new double[ord];
            for (int i = 1; i <= ord; i++)
            {
                ReX[i - 1] = 0; ImX[i - 1] = 0;
            }
            solved = false;
        }
        public void SetZB1()
        {
            double[] c = { 2, 2 };
            set(1, c);
        }
        public void SetZB2()
        {
            double[] c = { 4, 4, 1};
            set(2, c);
        }
        public void SetFromTable(TTable tbl, TableInfo tblInfExt=null){
            ord = tbl.GetQLines(tblInfExt) - 1;
            c = new double[ord + 1];
            for (int i = 1; i <= ord + 1; i++) this.c[i - 1] = tbl.GetDoubleVal(i, 1, tblInfExt);
            for (int i = 1; i <= ord; i++)
            {
                ReX[i - 1] = 0; ImX[i - 1] = 0;
            }
            solved = false;
        }
        public bool GetIfSolved() { return solved; }
        public bool GetIfCorrect() { return (ord>0 && c!=null && c[ord]!=0); }
        public void GetSolution(ref int ord, ref double[] ReX, ref double[] ImX)
        {
            if (GetIfCorrect())
            {
                if (!solved)
                {
                    Solve();
                }
            }
            ord = this.ord;
            for (int i = 1; i <= ord; i++)
            {
                this.ReX[i - 1] = ReX[i - 1]; this.ImX[i - 1] = ImX[i - 1];
            }
        }
        public void Solve()
        {
            //double d;
            //switch (ord)
            //{
            //    case 1:
            //        ReX[1-1]=-c[1-1]/c[2-1];
            //        break;
            //    case 2:
            //        d = c[1] * c[1] - 4 * c[2] * c[0];
            //        if (d >= 0)
            //        {
            //            ReX[1-1] = (-c[1] - Math.Sqrt(d)) / (2 * c[2]);
            //            ReX[2-1] = (-c[1] + Math.Sqrt(d)) / (2 * c[2]);
            //        }
            //        else
            //        {
            //            ReX[1 - 1] = -c[1] / (2 * c[2]);
            //            ReX[2 - 1] = ReX[1 - 1];
            //            ImX[1-1]= - Math.Sqrt(-d) / (2 * c[2]);
            //            ImX[2 - 1] = Math.Sqrt(-d) / (2 * c[2]);
            //        }
            //        break;
            //    case 3:

            //        break;

            //    case 4:

            //        break;
            //    default:

            //        break;
            //}
            int Err = 0;
            string[] str = null;
            MyMathLib.SolvePolynomialEquation(this.c, this.ord, ref ReX, ref ImX, ref Err, ref str);
            solved = true;
        }
        public void SetEquationFromTable(TTable tbl, TableInfo TblInfExt=null)
        {
            int QLines, order;
            double[] c = null;
            TableInfo TblInf=null;//new TableInfo();
            //if (sizeExt != null) TblInf.RowsQuantities = sizeExt;
            //else if(tbl.GetIfInfoBlockExists()==true) TblInf=tbl.Choose_TableInfo_StrSize_ByExtAndInner(null)
            TblInf = tbl.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            QLines = TblInf.GetQLines();
            order = QLines - 1;
            c = new double[order+1];
            for (int i = 1; i <= order+1; i++) c[i - 1] = tbl.GetDoubleVal(i, 1, TblInf);
            this.set(order, c);
        }
        public TTable GetEquationAsTable()
        {
            TTable tbl=null;
            bool ByColsNotLines = true, WriteInfo = true;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[1];
            rows[1-1]=new DataCellRowCoHeader(new DataCell("C"), new DataCellRow(this.c, ord + 1));
            //TableHeaders headers = new TableHeaders(new DataCell("Polynomial Equation of " + ord.ToString() + " order"), null, new DataCell("X^"));
            TableHeaders headers = new TableHeaders(new DataCell("Polynomial Equation of " + ord.ToString() + " order"), new DataCell("X^"), null);
            TableInfo TblInf=new TableInfo(true, false, true ,ord+1, 1);
            TableRepresentation repr_Text = new TableRepresentation();
            TableRepresentation repr_Grid = new TableRepresentation();
            repr_Text.dets.LineHeaderRepr.RowNBef = true;
            repr_Text.dets.GenRepr.LinesNumerationStartFromN = 0;
            repr_Text.dets.GenRepr.LinesNumerationStep = 1;
            repr_Text.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Text.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Text.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Text.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Text.dets.ColHeaderRepr.RowNBef = false;
            //
            repr_Grid.dets.LineHeaderRepr.RowNBef = true;
            repr_Grid.dets.GenRepr.LinesNumerationStartFromN = 0;
            repr_Grid.dets.GenRepr.LinesNumerationStep = 1;
            repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Grid.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Grid.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Grid.dets.ColHeaderRepr.RowNBef = false;

            TblInf.Repr_Text = repr_Text;
            TblInf.Repr_Grid = repr_Grid;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.LinesCanAdd = true;
            UsePol.LinesCanDel = true;
            UsePol.LinesCanIns = true;
            UsePol.QLinesMinDefined = true;
            UsePol.QLinesMin = 2;
            UsePol.QLinesMaxDefined = true;
            UsePol.QLinesMax = 6;
            UsePol.ContentsCanEdit = true;
            TblInf.UssagePolicy = UsePol;
            tbl = new TTable(TblInf, ByColsNotLines, rows, null, headers, WriteInfo);
            return tbl;
        }
        public TTable GetSolutionAsTable()
        {
            TTable tbl = null;
            bool ByColsNotLines = true, WriteInfo = true;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[2];
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("ReX"), new DataCellRow(this.ReX, ord));
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell("ImX"), new DataCellRow(this.ImX, ord));
            TableHeaders headers = new TableHeaders(new DataCell("Solution"), null, new DataCell("RootN"));
            TableInfo TblInf = new TableInfo(true, false, true, ord , 2);
            TableRepresentation repr_Text = new TableRepresentation();
            TableRepresentation repr_Grid = new TableRepresentation();
            repr_Text.dets.LineHeaderRepr.RowNBef = true;
            repr_Text.dets.GenRepr.LinesNumerationStartFromN = 1;
            repr_Text.dets.GenRepr.LinesNumerationStep = 1;
            repr_Text.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Text.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Text.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Text.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Text.dets.ColHeaderRepr.GenRowNameBef = false;
            repr_Text.dets.ColHeaderRepr.RowNBef = false;
            //
            repr_Grid.dets.LineHeaderRepr.RowNBef = true;
            repr_Grid.dets.GenRepr.LinesNumerationStartFromN = 1;
            repr_Grid.dets.GenRepr.LinesNumerationStep = 1;
            repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Grid.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Grid.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Grid.dets.ColHeaderRepr.GenRowNameBef = false;
            repr_Grid.dets.ColHeaderRepr.RowNBef = false;
            //
            TblInf.Repr_Text = repr_Text;
            TblInf.Repr_Grid = repr_Grid;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.LinesCanAdd = true;
            UsePol.LinesCanDel = true;
            UsePol.LinesCanIns = true;
            TblInf.UssagePolicy = UsePol;
            tbl = new TTable(TblInf, ByColsNotLines, rows, null, headers, WriteInfo);
            return tbl;
        }//fn
        public void RunEqGenerator(double[] ReX, int QRoots, double K = 1)
        {
            double a30, a31, a32, a33,
                   a40, a41, a42, a43, a44,
                   a50, a51, a52, a53, a54, a55,
                   a60, a61, a62, a63, a64, a65, a66,
                   a70, a71, a72, a73, a74, a75, a76, a77;
            if (QRoots >= 3 && QRoots <= 4)
            {
                this.ord = QRoots;
                this.c = new double[ord + 1];
                this.ReX = new double[QRoots];
                this.ImX = new double[QRoots];
                for (int i = 1; i <= QRoots; i++)
                {
                    this.ReX[i - 1] = ReX[i - 1];
                    this.ImX[i - 1] = 0;
                }
                //
                a33 = K * 1;
                a32 = -K * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1]);
                a31 = K * (ReX[1 - 1] + ReX[2 - 1]) * +ReX[3 - 1] + ReX[1 - 1] * ReX[2 - 1];
                a30 = -K * (ReX[1 - 1] * ReX[2 - 1] * ReX[3 - 1]);
                //
                a44 = a33;
                a43 = a32 - ReX[4 - 1] * a33;
                a43 = -K * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1] + ReX[4 - 1]);
                a42 = a31 - ReX[4 - 1] * a32;
                a42 = K * ((ReX[1 - 1] + ReX[2 - 1]) * ReX[3 - 1] + ReX[1 - 1] * ReX[2 - 1] + ReX[4 - 1] * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1]));
                a41 = a30 - ReX[4 - 1] * a31;
                a40 = -ReX[4 - 1] * a30;
                a40 = K * ReX[1 - 1] * ReX[2 - 1] * ReX[3 - 1] * ReX[4 - 1];
                //
                //
                switch (QRoots)
                {
                    case 2:

                        break;
                    case 3:
                        this.c[0] = a30;
                        this.c[1] = a31;
                        this.c[2] = a32;
                        this.c[3] = a33;
                        break;
                    case 4:
                        this.c[0] = a40;
                        this.c[1] = a41;
                        this.c[2] = a42;
                        this.c[3] = a43;
                        this.c[4] = a44;
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                }
            }
        }//RunEqGenerator
        public void RunEqGenerator()
        {
            int K = 1;
            double
                   a10, a11,
                   a20, a21, a22,
                   a30 = 0, a31 = 0, a32 = 0, a33 = 0,
                   a40 = 0, a41 = 0, a42 = 0, a43 = 0, a44 = 0,
                   a50, a51, a52, a53, a54, a55,
                   a60, a61, a62, a63, a64, a65, a66,
                   a70, a71, a72, a73, a74, a75, a76, a77;
            //if (QRoots >= 3 && QRoots <= 4)
            //{
            //this.ord = QRoots;
            //this.c = new double[ord + 1];
            //this.ReX = new double[QRoots];
            //this.ImX = new double[QRoots];
            //for (int i = 1; i <= QRoots; i++)
            //{
            //    this.ReX[i - 1] = ReX[i - 1];
            //    this.ImX[i - 1] = 0;
            //}
            //
            a11 = 1; a10 = -ReX[1 - 1];
            if (ord > 1)
            {
                a20 = 1; a21 = -(ReX[1 - 1] + ReX[2 - 1]); a22 = ReX[1 - 1] * ReX[2 - 1];
            }
            if (ord > 2)
            {
                a33 = K * 1;
                a32 = -K * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1]);
                a31 = K * (ReX[1 - 1] + ReX[2 - 1]) * +ReX[3 - 1] + ReX[1 - 1] * ReX[2 - 1];
                a30 = -K * (ReX[1 - 1] * ReX[2 - 1] * ReX[3 - 1]);
            }
            //
            if (ord > 3)
            {
                a44 = a33;
                a43 = a32 - ReX[4 - 1] * a33;
                a43 = -K * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1] + ReX[4 - 1]);
                a42 = a31 - ReX[4 - 1] * a32;
                a42 = K * ((ReX[1 - 1] + ReX[2 - 1]) * ReX[3 - 1] + ReX[1 - 1] * ReX[2 - 1] + ReX[4 - 1] * (ReX[1 - 1] + ReX[2 - 1] + ReX[3 - 1]));
                a41 = a30 - ReX[4 - 1] * a31;
                a40 = -ReX[4 - 1] * a30;
                a40 = K * ReX[1 - 1] * ReX[2 - 1] * ReX[3 - 1] * ReX[4 - 1];
            }
            //
            //
            switch (ord)
            {
                case 2:

                    break;
                case 3:
                    this.c[0] = a30;
                    this.c[1] = a31;
                    this.c[2] = a32;
                    this.c[3] = a33;
                    break;
                case 4:
                    this.c[0] = a40;
                    this.c[1] = a41;
                    this.c[2] = a42;
                    this.c[3] = a43;
                    this.c[4] = a44;
                    break;
                case 5:

                    break;
                case 6:

                    break;
            }
            //}
        }//RunEqGenerator
        public void SetGeneratorFromTable(TTable tbl, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = tbl.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines();
            this.ord = QLines;
            this.ReX = new double[ord];
            this.ImX = new double[ord];
            for (int i = 1; i <= ord; i++)
            {
                this.ReX[i - 1] = tbl.GetDoubleVal(i, 1, TblInf);
                this.ImX[i - 1] = 0;
            }
        }
        public TTable GetGeneratorAsTable()
        {
            TTable tbl = null;
            bool ByColsNotLines = true, WriteInfo = true;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[1];
            //DataCellRowCoHeader[] rows = new DataCellRowCoHeader[2];
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("ReX"), new DataCellRow(this.ReX, ord));
            //rows[2 - 1] = new DataCellRowCoHeader(new DataCell("ImX"), new DataCellRow(this.ImX, ord));
            TableHeaders headers = new TableHeaders(new DataCell("Real_Roots"), null, new DataCell("RootN"));
            //TableInfo TblInf = new TableInfo(true, false, true, ord, 2);
            TableInfo TblInf = new TableInfo(true, false, true, ord, 1);
            TableRepresentation repr_Text = new TableRepresentation();
            TableRepresentation repr_Grid = new TableRepresentation();
            repr_Text.dets.LineHeaderRepr.RowNBef = true;
            repr_Text.dets.GenRepr.LinesNumerationStartFromN = 1;
            repr_Text.dets.GenRepr.LinesNumerationStep = 1;
            repr_Text.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Text.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Text.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Text.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Text.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Text.dets.ColHeaderRepr.GenRowNameBef = false;
            repr_Text.dets.ColHeaderRepr.RowNBef = false;
            //
            repr_Grid.dets.LineHeaderRepr.RowNBef = true;
            repr_Grid.dets.GenRepr.LinesNumerationStartFromN = 1;
            repr_Grid.dets.GenRepr.LinesNumerationStep = 1;
            repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInButtons = true;
            repr_Grid.dets.GenRepr.ShowTableNameInCorner = false;
            repr_Grid.dets.GenRepr.ShowRowsGenNamesInCorner = true;
            repr_Grid.dets.LineHeaderRepr.GenRowNameBef = true;
            repr_Grid.dets.ColHeaderRepr.GenRowNameBef = false;
            repr_Grid.dets.ColHeaderRepr.RowNBef = false;
            //
            TblInf.Repr_Text = repr_Text;
            TblInf.Repr_Grid = repr_Grid;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.LinesCanAdd = true;
            UsePol.LinesCanDel = true;
            UsePol.LinesCanIns = true;
            UsePol.QLinesMinDefined = true;
            UsePol.QLinesMin = 1;
            UsePol.QLinesMaxDefined = true;
            UsePol.QLinesMax = 4;
            UsePol.ContentsCanEdit = true;
            TblInf.UssagePolicy = UsePol;
            tbl = new TTable(TblInf, ByColsNotLines, rows, null, headers, WriteInfo);
            return tbl;
        }
    }//cl
    //
}//ns   //2020-08-12


