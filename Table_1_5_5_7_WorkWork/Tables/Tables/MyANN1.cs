using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tables
{
    
    public static class MyANN1Info{
        public const int QXs = 8;
        public const int QYs = 2;
        //public const int QHs = 9;//in ANN =QXs+1
        public const int QLayers=1;
        //
        public static double gammaLrnRt = 0.01;//This added
        public static double deltaFinDif = 0.01;//This added
        //
        public static int NatPow(int x, int p){
            int y=1;
            for(int i=1; i<=p; i++){
                y*=x;
            }
            return y;
        }
        public static int GetQHs(){
            return QXs >= QYs ? QXs + 1 : QYs + 1;
        }
        public static int fMaxVal(){
            int s=0, cur=0;
            for(int i=0; i<=QXs-1; i++){
                cur=NatPow(2, i);
                s=s+cur;
            }
            return s;
        }
        public static int generateRandom(){
            int LB=0, HB=fMaxVal(), y=0;
            y=y;
            return y;
        }
        public static int GeneralN_ToN_In_Layer(int memberN){
            int N_In_Layer = 0, QFullLayers, QHs = GetQHs();
            QFullLayers = memberN / QHs;//memberN div LayerN;
            N_In_Layer = memberN - QFullLayers * QHs;
            N_In_Layer = memberN % QFullLayers * QHs;
            return N_In_Layer;
        }
        public static int GeneralN_ToN_Of_Layer(int memberN)
        {
            int N_Of_Layer = 0, QFullLayers, QHs = GetQHs();
            QFullLayers = memberN / QHs;//memberN div LayerN;
            N_Of_Layer=QFullLayers+1;
            return N_Of_Layer;
        }
        public static int LayerNToGeneralN(int memberN, int LayerN){
            int ResN=0, QHs=0;
            ResN = (LayerN - 1) * QHs + memberN;
            return ResN;
        }
    }//cl
    
    class MyDataForANN
    {
        double[] x;
        int answer;
        MyDataForANN() {
            x = new double[MyANN1Info.QXs];
            for (int i = 0; i <= MyANN1Info.QXs - 1; i++)
            {
                x[i - 1] = 0;//random()
            }
        }
    }
    class MyANN1
    {
        double[] X, Y;
        double[][] H;
        double[] curH;
        double[][] WB1, WB2;
        double[][][] W1, W2;
        double[][] curW1, curW2;
        double[] curWB1, curWB2;
        double[] B;
        double curB;
        int QHs;
        MyANN1()
        {
            int CurLayerN=1;
            QHs = MyANN1Info.GetQHs();
            X = new double[MyANN1Info.QXs];
            Y = new double[MyANN1Info.QYs];
            H=new double [MyANN1Info.QLayers][];
            for (int i = 1; i <= MyANN1Info.QLayers; i++)
            {
                H[i - 1] = new double[QHs];
            }
            
            //WB1 = new double[MyAANN1Info.QXs];
            //WB2 = new double[MyAANN1Info.QYs];
            W1 = new double[MyANN1Info.QLayers][][];
            W2 = new double[MyANN1Info.QLayers][][];
            for (int i = 1; i <= MyANN1Info.QLayers; i++)
            {
                W1[i - 1] = new double[MyANN1Info.QXs][];
                W2[i - 1] = new double[MyANN1Info.QYs][];
                for (int j = 1; j <= QHs; j++)
                {
                    W1[i - 1][j - 1] = new double[MyANN1Info.QXs];
                    if (i == MyANN1Info.QLayers)
                    {
                        W2[i - 1][j - 1] = new double[MyANN1Info.QYs];
                    }
                    else
                    {
                        W2[i - 1][j - 1] = new double[QHs];
                    }
                }
            }
            WB1 = new double[MyANN1Info.QLayers][];
            WB2 = new double[MyANN1Info.QLayers][];
            B = new double[MyANN1Info.QLayers];
            curW1 = new double[MyANN1Info.QXs][];
            curW2 = new double[MyANN1Info.QYs][];
            for (int i = 1; i <= QHs; i++)
            {
                curW1[i - 1] = new double[MyANN1Info.QXs];
                if (CurLayerN == MyANN1Info.QLayers) //this case for 1-layer perceptron
                {
                    curW2[i - 1] = new double[MyANN1Info.QYs];
                }
                else 
                {
                    curW2[i - 1] = new double[QHs];
                }
            }
            curH = new double[QHs];
            //curB- double;
        }//fn
        void SetCurLayerN(int CurLayerN){
            for(int i=1; i<=QHs; i++){
                curW1[i-1]=W1[CurLayerN-1][i-1];
            }
            if (CurLayerN < MyANN1Info.QLayers)
            { //this case for 1-layer perceptron
                for (int i = 1; i <= QHs; i++)
                {
                    curW2[i - 1] = W2[CurLayerN - 1][i - 1];
                }
            }
            else
            {
                for (int i = 1; i <= MyANN1Info.QYs; i++)
                {
                    curW2[i - 1] = W2[CurLayerN - 1][i - 1];
                }
            }
        }
        void PropagationForwardToOneLayer(int CurLayerN)
        {
            SetCurLayerN(CurLayerN);

        }
    }//cl
}//ns
