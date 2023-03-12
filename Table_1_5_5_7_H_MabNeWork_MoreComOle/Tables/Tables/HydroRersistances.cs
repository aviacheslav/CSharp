using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public static class HydroResistanceConsts{
        public const int LocResistanceGroupN=1;
        public const int WayResistanceGroupN=2;
        public const string LocResistanceGroupName="Loc.";
        public const string WayResistanceGroupName="Way.";
        //
        public const int ResistanceTypeN_Loc_Simple_Inlet=1;
        public const int ResistanceTypeN_Loc_Simple_Outlet=2;
        public const int ResistanceTypeN_Loc_Simple_TJoint=3;
        public const int ResistanceTypeN_Loc_Simple_TJointUniting=4;
        public const int ResistanceTypeN_Loc_Simple_DuriteSchlange = 5;
        //
        public const string ResistanceTypeName_Loc_Simple_Inlet = "Inlet";
        public const string ResistanceTypeName_Loc_Simple_Outlet = "Outlet";
        public const string ResistanceTypeName_Loc_Simple_TJoint = "TJoint";
        public const string ResistanceTypeName_Loc_Simple_DuriteSchlange = "DuriteSchlange";
        //
        public const int ResistanceTypeN_Loc_Geom_SuddBroad=10;
        public const int ResistanceTypeN_Loc_Geom_SuddNarr=20;
        public const int ResistanceTypeN_Loc_Geom_SuddTurn=30;
        public const int ResistanceTypeN_Loc_Geom_GradTurn=40;
        public const int ResistanceTypeN_Loc_Geom_GradBroad=50;
        public const int ResistanceTypeN_Loc_Geom_GradNarr=60;
        //
        public const string ResistanceTypeName_Loc_Geom_SuddNarr="SuddNarr.";
        public const string ResistanceTypeName_Loc_Geom_SuddTurn="SuddTurn.";
        public const string ResistanceTypeName_Loc_Geom_GradTurn="GradTurn.";
        public const string ResistanceTypeName_Loc_Geom_GradBroad="Diffusor";
        public const string ResistanceTypeName_Loc_Geom_GradNarr="Confusor";
        //
        public const double ResistanceCoef_Loc_Simple_Inlet=1;
        public const double ResistanceCoef_Loc_Simple_Outlet=0.5;
        public const double ResistanceCoef_Loc_Simple_TJoint=2;
        public const double ResistanceCoef_Loc_Simple_TJointUniting=3;
        public const double ResistanceCoef_Loc_Simple_DuriteSchlange = 2.5;
        //
        public const double ResistanceCoef_Loc_Geom_SuddTurn90=1;
        //
        public static double LambdaByNikuradze(double Ra, double Re)
        {
            double lambda = 9;
            double delta;
            double[] deltaNik = new double[6] { 1, 2, 3, 4,5, 6 };
            return lambda;
        }
        //
        public static double[] arr = new double[3] {1,2,3 };
            //
        public static double fDzetaWay(double lambda, double d, double Re)
        {
            double DzetaWay=0;
            //DzetaWay=
            return DzetaWay;
        }
    }//cl
    public class TResistanceSectrionParams
    {
        public double Qv, kr;
        public TResistanceSectrionParams(double kr=0, double Qv=0){this.kr=kr; this.Qv=Qv;}
    }
    public class MyListElement
    {
        MyListElement[] parallel, succ;
        MyListElement upper;
        int NParallel, NSucc;
        //static int count;
        int k;
        public MyListElement()
        {
            setNull();
        }
        public MyListElement(MyListElement upper)
        {
            setNull();
            setUpper(upper);
        }
        public MyListElement(int x)
        {
            setNull();
            setX(x);
        }
        public MyListElement(MyListElement upper, int x)
        {
            setNull();
            setUpper(upper);
            setX(x);
        }
        public MyListElement GetUpper()
        {
            return upper;
        }
        public void setNull(){
            succ = null;
            parallel = null;
            upper = null;
            k = 0;
        }
        public void setUpper(MyListElement upper)
        {
            this.upper = upper;
        }
        public void setX(int x){
            this.k=x;
        }
        public void setParallel(MyListElement[] parallel)
        {
            this.parallel = parallel;
        }
        public void setSucc(MyListElement[] succ)
        {
            this.succ = succ;
        }
        public int getX(){
            return this.k;
        }
        public int getParentX(){
            int px=0;
            if(upper!=null) px=upper.getX();
            return px;
        }
        
        public double CalcParallelK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcSuccK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcQForParallelRN(double Q, int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (parallel != null)
            {
                NParallel = parallel.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
        public double CalcQForSuccRN(int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (succ != null)
            {
                NSucc = succ.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
    }//cl
    public class HydroResistance
    {
        HydroResistance[] parallel, succ;
        HydroResistance upper;
        int NParallel, NSucc;
        double k_parallel_sum, k_succ_sum, k_loc_own, k_way_own, k_sum_own, k_sum_included, k;
        //static int count;
        public HydroResistance()
        {
            setNull();
        }
        public HydroResistance(HydroResistance upper)
        {
            setNull();
            setUpper(upper);
        }
        public HydroResistance(double x)
        {
            setNull();
            setX(x);
        }
        public HydroResistance(HydroResistance upper, double x)
        {
            setNull();
            setUpper(upper);
            setX(x);
        }
        public HydroResistance GetUpper()
        {
            return upper;
        }
        public void setNull()
        {
            succ = null;
            parallel = null;
            upper = null;
            k = 0;
        }
        public void setUpper(HydroResistance upper)
        {
            this.upper = upper;
        }
        public void setX(double x)
        {
            this.k = x;
        }
        public void setParallel(HydroResistance[] parallel)
        {
            this.parallel = parallel;
        }
        public void setSucc(HydroResistance[] succ)
        {
            this.succ = succ;
        }
        public double getX()
        {
            return this.k;
        }
        public double getParentX()
        {
            double px = 0;
            if (upper != null) px = upper.getX();
            return px;
        }
        
        public double CalcParallelK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcSuccK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcQForParallelRN(double Q, int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (parallel != null)
            {
                NParallel = parallel.Length;
                for (int i = 1; i <= NSucc; i++)
                {
                    //if (N != i) //numerator *= parallel[i - 1].;
                }
            }
            return KSum;
        }
        public double CalcQForSuccRN(int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (succ != null)
            {
                NSucc = succ.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
    }//cl
    
    class HydroResistances
    {
    }
}
