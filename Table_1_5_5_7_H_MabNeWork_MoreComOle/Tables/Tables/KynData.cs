using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class TKyn
    {
        //public bool XExists { set; get; }
        //public bool YExists { set; get; }
        //public bool ZExists { set; get; }
        //public bool FiXExists { set; get; }
        //public bool FiYExists { set; get; }
        //public bool FiZExists { set; get; }
        //public bool Deriv2Exists { set; get; }
        public int PointsQuantity { set; get; }
        //public int DerivsQuantity { set; get; }
        //private int XN, YN, ZN, FiXN, FiYN, FiZN;
        int DerivsAndDoFsBin;
        private double[][] x;
        //
        public TKyn()
        {
            int XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists, Deriv2Exists;
            x = null;
            PointsQuantity = 1;
            //
            XExists = 1;
            YExists = 0;
            ZExists = 0;
            FiXExists = 0;
            FiYExists = 0;
            FiZExists = 0;
            //
            Deriv2Exists = 0;
            //
            Set_StructIni(PointsQuantity, Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
        }
        public TKyn(int QPoints, int XExists, int YExists, int ZExists, int FiXExists, int FiYExists, int FiZExists, int Deriv2Exists)
        {
            x = null;
            PointsQuantity = QPoints;
            Deriv2Exists = 0;
            Set_StructIni(PointsQuantity, Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
        }
        public TKyn(int QPoints, double[] x, double[] y, double[] z, double[] fiX, double[] fiY, double[] fiZ, double[] Vx, double[] Vy, double[] Vz, double[] Wx, double[] Wy, double[] Wz, double[] ax, double[] ay, double[] az, double[] ex, double[] ey, double[] ez)
        {
            x = null;
            PointsQuantity = 0;
            DerivsAndDoFsBin = 0;
            //SetPointsDofsAndDerivsIni(int PointsQuantity, int Deriv2Exists, int XExists, int YExists, int ZExists, int FiXExists, int FiYExists, int FiZExists);
            SetWhole(QPoints, x, y, z, fiX, fiY, fiZ, Vx, Vy, Vz, Wx, Wy, Wz, ax, ay, az, ex, ey, ez);
        }
        public TKyn(int Deriv2Exists, double[] X, double[] Y, double[] Z, double[] FiX, double[] FiY, double[] FiZ)
        {
            int XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists;
            PointsQuantity = 1;
            if (X != null) XExists = 1; else XExists = 0;
            if (Y != null) YExists = 1; else YExists = 0;
            if (Z != null) ZExists = 1; else ZExists = 0;
            if (FiX != null) FiXExists = 1; else FiXExists = 0;
            if (FiY != null) FiYExists = 1; else FiYExists = 0;
            if (FiZ != null) FiZExists = 1; else FiZExists = 0;
            Set_StructIni(PointsQuantity, Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
            SetDoFsOfPointN(1, X, Y, Z, FiX, FiY, FiZ);
        }
        //
        public int Calc_DoFsAndDerivs_binary(int Deriv2Exists, int XExists, int YExists, int ZExists, int FiXExists, int FiYExists, int FiZExists)
        {
            int[] digit = new int[7];
            int DoFsAndDerivsBin = 0;
            digit[0] = Deriv2Exists;
            digit[1] = XExists;
            digit[2] = YExists;
            digit[3] = ZExists;
            digit[4] = FiXExists;
            digit[5] = FiYExists;
            digit[6] = FiZExists;
            for (int i = 0; i <= 6; i++)
            {
                DoFsAndDerivsBin += digit[i] * (int)Math.Pow(2, i);
            }
            return DoFsAndDerivsBin;
        }
        public void CalcDofsAndDerivsExistanceByBin(int DoFsAndDerivsBin, ref int Deriv2Exists, ref int XExists, ref int YExists, ref int ZExists, ref int FiXExists, ref int FiYExists, ref int FiZExists)
        {
            int[] digit;
            int order = 0;
            digit = new int[8];
            NumberParse.IntToDigits(DoFsAndDerivsBin, 2, ref digit, ref order);
            Deriv2Exists = digit[0];
            XExists = digit[1];
            YExists = digit[2];
            ZExists = digit[3];
            FiXExists = digit[4];
            FiYExists = digit[5];
            FiZExists = digit[6];
        }
        public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN)
        {
            int[] digit;
            digit = new int[8];
            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1;
            CalcDofsAndDerivsExistanceByBin(DoFsAndDerivsBin, ref Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            if (Deriv2Exists == 1) QDerivs = 3; else QDerivs = 2;
            CountDoFs = 0;
            if (XExists == 1)
            {
                XN = CountDoFs + 1;
                CountDoFs++;
            }
            else XN = 0;
            if (YExists == 1)
            {
                YN = CountDoFs + 1;
                CountDoFs++;
            }
            else YN = 0;
            if (ZExists == 1)
            {
                ZN = CountDoFs + 1;
                CountDoFs++;
            }
            else ZN = 0;
            if (FiXExists == 1)
            {
                FiXN = CountDoFs + 1;
                CountDoFs++;
            }
            else FiXN = 0;
            if (FiYExists == 1)
            {
                FiYN = CountDoFs + 1;
                CountDoFs++;
            }
            else FiYN = 0;
            if (FiZExists == 1)
            {
                FiZN = CountDoFs + 1;
                CountDoFs++;
            }
            else FiZN = 0;
        }
        //
        public int GetQDoFs()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return CountDoFs;
        }
        public int GetQDerivs()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return QDerivs;
        }
        public int GetQRows()
        {
            int QDoFs = GetQDoFs(), QDerivs = GetQDerivs(), QRows;
            QRows = QDoFs * QDerivs;
            return QRows;
        }
        public int GetDoFsAndDerivsBinary()
        {
            return DerivsAndDoFsBin;
        }
        //
        public int get_XN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return XN;
        }
        public int get_YN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return YN;
        }
        public int get_ZN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return ZN;
        }
        public int get_FiXN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return FiXN;
        }
        public int get_FiYN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return FiYN;
        }
        public int get_FiZN()
        {
            int DoFsAndDerivsBin = -1, QDerivs = -1, CountDoFs = -1, XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1;
            //public void CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN);
            DoFsAndDerivsBin = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsNsByBin(DoFsAndDerivsBin, ref QDerivs, ref CountDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);
            return FiZN;
        }
        public int get_VxN()
        {
            int XN = get_XN();
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            int VxN = 0;
            if (XN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                VxN = QDoFs + XN;
            }
            return VxN;
        }
        public int get_VyN()
        {
            int YN = get_YN();
            int VyN = 0;
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            if (YN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                VyN = QDoFs + YN;
            }
            return VyN;
        }
        public int get_VzN()
        {
            int ZN = get_YN();
            int VzN = 0;
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            if (ZN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                VzN = QDoFs + ZN;
            }
            return VzN;
        }
        public int get_WxN()
        {
            int FiXN = get_FiXN();
            int WxN = 0;
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            if (FiXN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                WxN = QDoFs + FiXN;
            }
            return WxN;
        }
        public int get_WyN()
        {
            int FiYN = get_FiYN();
            int WyN = 0;
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            if (FiYN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                WyN = QDoFs + FiYN;
            }
            return WyN;
        }
        public int get_WzN()
        {
            int FiZN = get_FiZN();
            int WzN = 0;
            int QDoFs = GetQDoFs();
            int QDerivs = GetQDerivs();
            if (FiZN != 0)
            {
                //VxN = (XN - 1) * QDerivs + XN;
                WzN = QDoFs + FiZN;
            }
            return WzN;
        }
        public int get_axN()
        {
            int XN = get_XN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int axN = 0;
            if (XN != 0 && QDerivs >= 3)
            {
                axN = QDoFs * 2 + XN;
            }
            return axN;
        }
        public int get_ayN()
        {
            int YN = get_YN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int ayN = 0;
            if (YN != 0 && QDerivs >= 3)
            {
                ayN = QDoFs * 2 + YN;
            }
            return ayN;
        }
        public int get_azN()
        {
            int ZN = get_ZN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int azN = 0;
            if (ZN != 0 && QDerivs >= 3)
            {
                azN = QDoFs * 2 + ZN;
            }
            return azN;
        }
        public int get_exN()
        {
            int FiXN = get_FiXN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int exN = 0;
            if (FiXN != 0 && QDerivs >= 3)
            {
                exN = QDoFs * 2 + FiXN;
            }
            return exN;
        }
        public int get_eyN()
        {
            int FiYN = get_FiYN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int eyN = 0;
            if (FiYN != 0 && QDerivs >= 3)
            {
                eyN = QDoFs * 2 + FiYN;
            }
            return eyN;
        }
        public int get_ezN()
        {
            int FiZN = get_FiZN();
            int QDerivs = GetQDerivs();
            int QDoFs = GetQDoFs();
            int ezN = 0;
            if (FiZN != 0 && QDerivs >= 3)
            {
                ezN = QDoFs * 2 + FiZN;
            }
            return ezN;
        }
        //
        public void Set_StructIni(int PointsQuantity, int Deriv2Exists, int XExists, int YExists, int ZExists, int FiXExists, int FiYExists, int FiZExists)
        {
            int QDerivs = 0, QDoFs = 0, QRows;
            x = null;
            this.DerivsAndDoFsBin = Calc_DoFsAndDerivs_binary(Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
            this.PointsQuantity = PointsQuantity;
            QDoFs = GetQDoFs();
            QDerivs = GetQDerivs();
            QRows = QDoFs * QDerivs;
            x = new double[PointsQuantity][];
            for (int i = 1; i <= PointsQuantity; i++)
            {
                x[i - 1] = new double[QRows];
            }
            for (int i = 1; i <= PointsQuantity; i++)
            {
                for (int j = 1; j <= QRows; j++)
                {
                    x[i - 1][j - 1] = 0;
                }
            }
        }
        public void Set_Struct(int PointsQuantity, int Deriv2Exists, int XExists, int YExists, int ZExists, int FiXExists, int FiYExists, int FiZExists)
        {
            int Deriv2Existed = -1, XExisted = -1, YExisted = -1, ZExisted = -1, FiXExisted = -1, FiYExisted = -1, FiZExisted = -1;
            int QPointsWas, QPointsMin, QDerivs = 0, QDoFs = 0, QDerivsAndDoFsBinWas, QRows;
            int XN = -1, YN = -1, ZN = -1, FiXN = -1, FiYN = -1, FiZN = -1, VxN = -1, VyN = -1, VzN = -1, WxN = -1, WyN = -1, WzN = -1, axN = -1, ayN = -1, azN = -1, exN = -1, eyN = -1, ezN = -1;//, QDoFs, QDerivs;
            bool PrevValsExistToSave;
            double[] X, Y, Z, FiX, FiY, FiZ, Vx, Vy, Vz, Wx, Wy, Wz, aX, aY, aZ, eX, eY, eZ;
            //Plan
            //1 Save prev vals
            //2 create new struct
            //3 assign old vals
            X = null; Y = null; Z = null; FiX = null; FiY = null; FiZ = null; Vx = null; Vy = null; Vz = null; Wx = null; Wy = null; Wz = null; aX = null; aY = null; aZ = null; eX = null; eY = null; eZ = null;
            QDerivsAndDoFsBinWas = this.DerivsAndDoFsBin;
            CalcDofsAndDerivsExistanceByBin(QDerivsAndDoFsBinWas, ref Deriv2Existed, ref XExisted, ref YExisted, ref ZExisted, ref FiXExisted, ref FiYExisted, ref FiZExisted);
            QPointsWas = this.PointsQuantity;
            //previous vals ut ved qu save vals
            PrevValsExistToSave = (QDerivsAndDoFsBinWas > 1 && x != null);
            if (PrevValsExistToSave)
            {//else No DoFs exist
                //CalcDofsAndDerivsNsByBin(int DoFsAndDerivsBin, ref int QDerivs, ref int CountDoFs, ref int XN, ref int YN, ref int ZN, ref int FiXN, ref int FiYN, ref int FiZN)
                XN = get_XN();
                YN = get_YN();
                ZN = get_ZN();
                FiXN = get_FiXN();
                FiYN = get_FiYN();
                FiZN = get_FiZN();
                VxN = get_VxN();
                VyN = get_VyN();
                VzN = get_VzN();
                WxN = get_WxN();
                WyN = get_WyN();
                WzN = get_WzN();
                axN = get_axN();
                ayN = get_ayN();
                azN = get_azN();
                exN = get_exN();
                eyN = get_eyN();
                ezN = get_ezN();
                //
                if (XN != 0)
                {
                    X = new double[QPointsWas];
                    Vx = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        X[i - 1] = this.x[i - 1][XN - 1];
                        Vx[i - 1] = this.x[i - 1][VxN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        aX = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            aX[i - 1] = this.x[i - 1][axN - 1];
                        }
                    }
                }
                if (YN != 0)
                {
                    Y = new double[QPointsWas];
                    Vy = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        Y[i - 1] = this.x[i - 1][YN - 1];
                        Vy[i - 1] = this.x[i - 1][VyN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        aY = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            aY[i - 1] = this.x[i - 1][ayN - 1];
                        }
                    }
                }
                if (ZN != 0)
                {
                    Z = new double[QPointsWas];
                    Vz = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        Z[i - 1] = this.x[i - 1][ZN - 1];
                        Vz[i - 1] = this.x[i - 1][VzN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        aZ = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            aZ[i - 1] = this.x[i - 1][azN - 1];
                        }
                    }
                }
                if (FiXN != 0)
                {
                    FiX = new double[QPointsWas];
                    Wx = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        FiX[i - 1] = this.x[i - 1][FiXN - 1];
                        Wx[i - 1] = this.x[i - 1][WxN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        eX = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            eX[i - 1] = this.x[i - 1][exN - 1];
                        }
                    }
                }
                if (FiYN != 0)
                {
                    FiY = new double[QPointsWas];
                    Wy = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        FiY[i - 1] = this.x[i - 1][FiYN - 1];
                        Wy[i - 1] = this.x[i - 1][WyN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        eY = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            eY[i - 1] = this.x[i - 1][eyN - 1];
                        }
                    }
                }
                if (FiZN != 0)
                {
                    FiZ = new double[QPointsWas];
                    Wz = new double[QPointsWas];
                    for (int i = 1; i <= QPointsWas; i++)
                    {
                        FiZ[i - 1] = this.x[i - 1][FiZN - 1];
                        Wz[i - 1] = this.x[i - 1][WzN - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        eZ = new double[QPointsWas];
                        for (int i = 1; i <= QPointsWas; i++)
                        {
                            eZ[i - 1] = this.x[i - 1][ezN - 1];
                        }
                    }
                }
            }
            //Further
            this.DerivsAndDoFsBin = Calc_DoFsAndDerivs_binary(Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
            this.PointsQuantity = PointsQuantity;
            if (Deriv2Exists == 1) QDerivs = 3;
            else QDerivs = 2;
            QDoFs = GetQDoFs();
            QRows = QDoFs * QDerivs;
            if (this.x != null) this.x = null;
            this.x = new double[PointsQuantity][];
            for (int i = 1; i <= PointsQuantity; i++)
            {
                x[i - 1] = new double[QRows];
            }
            for (int i = 1; i <= PointsQuantity; i++)
            {
                for (int j = 1; j <= QRows; j++)
                {
                    this.x[i - 1][j - 1] = 0;
                }
            }
            // 
            if (PrevValsExistToSave)
            {
                if (PointsQuantity <= QPointsWas) QPointsMin = PointsQuantity;
                else QPointsMin = QPointsWas;
                //
                CalcDofsAndDerivsNsByBin(this.DerivsAndDoFsBin, ref QDerivs, ref QDoFs, ref XN, ref YN, ref ZN, ref FiXN, ref FiYN, ref FiZN);

                //XN = get_XN();
                //YN = get_YN();
                //ZN = get_ZN();
                //FiXN = get_FiXN();
                //FiYN = get_FiYN();
                //FiZN = get_FiZN();
                VxN = get_VxN();
                VyN = get_VyN();
                VzN = get_VzN();
                WxN = get_WxN();
                WyN = get_WyN();
                WzN = get_WzN();
                axN = get_axN();
                ayN = get_ayN();
                azN = get_azN();
                exN = get_exN();
                eyN = get_eyN();
                ezN = get_ezN();
                //
                if (XN != 0 && XExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][XN - 1] = X[i - 1];
                        this.x[i - 1][VxN - 1] = Vx[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][axN - 1] = aX[i - 1];
                        }
                    }
                }
                if (YN != 0 && YExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][YN - 1] = Y[i - 1];
                        this.x[i - 1][VyN - 1] = Vy[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][ayN - 1] = aY[i - 1];
                        }
                    }
                }
                if (ZN != 0 && ZExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][ZN - 1] = Z[i - 1];
                        this.x[i - 1][VzN - 1] = Vz[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][azN - 1] = aZ[i - 1];
                        }
                    }
                }
                if (FiXN != 0 && FiXExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][FiXN - 1] = FiX[i - 1];
                        this.x[i - 1][WxN - 1] = Wx[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][exN - 1] = eX[i - 1];
                        }
                    }
                }
                if (FiYN != 0 && FiYExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][FiYN - 1] = FiY[i - 1];
                        this.x[i - 1][WyN - 1] = Wy[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][eyN - 1] = eY[i - 1];
                        }
                    }
                }
                if (FiZN != 0 && FiZExisted == 1)
                {
                    for (int i = 1; i <= QPointsMin; i++)
                    {
                        this.x[i - 1][FiZN - 1] = FiZ[i - 1];
                        this.x[i - 1][WzN - 1] = Wz[i - 1];
                    }
                    if (Deriv2Existed == 1)
                    {
                        for (int i = 1; i <= QPointsMin; i++)
                        {
                            this.x[i - 1][ezN - 1] = eZ[i - 1];
                        }
                    }
                }//if FiZ
            }//if prev vals
        }//fn
        public void SetDoFsOfPointN(int PointN, double[] X, double[] Y, double[] Z, double[] FiX, double[] FiY, double[] FiZ)
        {
            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1;
            CalcDofsAndDerivsExistanceByBin(this.DerivsAndDoFsBin, ref Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            if (XExists == 1)
            {
                if (X != null)
                {
                    set_x(X[1 - 1], PointN);
                    set_Vx(X[2 - 1], PointN);
                    if (Deriv2Exists == 1) set_aX(X[3 - 1], PointN);
                }
                else
                {
                    set_x(0, PointN);
                    set_Vx(0, PointN);
                    if (Deriv2Exists == 1) set_aX(0, PointN);
                }
            }
            if (YExists == 1)
            {
                {
                    if (Y != null)
                    {
                        set_y(Y[1 - 1], PointN);
                        set_Vy(Y[2 - 1], PointN);
                        if (Deriv2Exists == 1) set_aY(Y[3 - 1], PointN);
                    }
                    else
                    {
                        set_y(0, PointN);
                        set_Vy(0, PointN);
                        if (Deriv2Exists == 1) set_aY(0, PointN);
                    }
                }
            }
            if (ZExists == 1)
            {
                if (Z != null)
                {
                    set_z(Z[1 - 1], PointN);
                    set_Vz(Z[2 - 1], PointN);
                    if (Deriv2Exists == 1) set_aZ(Z[3 - 1], PointN);
                }
                else
                {
                    set_z(0, PointN);
                    set_Vz(0, PointN);
                    if (Deriv2Exists == 1) set_aZ(0, PointN);
                }
            }
            if (FiXExists == 1)
            {
                if (FiX != null)
                {
                    set_FiX(FiX[1 - 1], PointN);
                    set_Wx(FiX[2 - 1], PointN);
                    if (Deriv2Exists == 1) set_ex(FiX[3 - 1], PointN);
                }
                else
                {
                    set_FiX(0, PointN);
                    set_Wx(0, PointN);
                    if (Deriv2Exists == 1) set_ex(0, PointN);
                }
            }
            if (FiYExists == 1)
            {
                if (FiY != null)
                {
                    set_FiY(FiY[1 - 1], PointN);
                    set_Wy(FiY[2 - 1], PointN);
                    if (Deriv2Exists == 1) set_ey(FiY[3 - 1], PointN);
                }
                else
                {
                    set_FiY(0, PointN);
                    set_Wy(0, PointN);
                    if (Deriv2Exists == 1) set_ey(0, PointN);
                }
            }
            if (FiZExists == 1)
            {
                if (FiZ != null)
                {
                    set_FiZ(FiZ[1 - 1], PointN);
                    set_Wz(FiZ[2 - 1], PointN);
                    if (Deriv2Exists == 1) set_ez(FiZ[3 - 1], PointN);
                }
                else
                {
                    set_FiZ(0, PointN);
                    set_Wz(0, PointN);
                    if (Deriv2Exists == 1) set_ez(0, PointN);
                }
            }
        }
        //
        public void Set_DoFN_OfPointN(int PointN, int DoFN, double q, double dq, double d2q)
        {
            //double[] X, Y, Z, FiX, FiY, FiZ;
            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1, QDerivs;
            //X = null; Y = null; Z = null; FiX = null; FiY = null; FiZ = null;
            this.CalcDofsAndDerivsExistanceByBin(this.DerivsAndDoFsBin, ref Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            if (XExists == 1 && DoFN == 1)
            {

                set_x(q, PointN);
                set_Vx(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_aX(d2q);
                }
            }
            if (YExists == 1 && DoFN == 2)
            {

                set_y(q, PointN);
                set_Vy(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_aY(d2q);
                }
            }
            if (ZExists == 1 && DoFN == 2)
            {
                set_z(q, PointN);
                set_Vz(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_aZ(d2q);
                }
            }

            if (FiXExists == 1 && DoFN == 4)
            {

                set_FiX(q, PointN);
                set_Wx(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_ex(d2q);
                }
            }
            if (FiYExists == 1 && DoFN == 5)
            {

                set_FiY(q, PointN);
                set_Wy(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_ey(d2q);
                }
            }
            if (FiZExists == 1 && DoFN == 6)
            {
                set_FiZ(q, PointN);
                set_Wz(dq, PointN);
                if (Deriv2Exists == 1)
                {
                    set_ez(d2q);
                }
            }
        }
        public void Set_DoFN_OfPointN(int PointN, int DoFN, double q, double dq)
        {
            //double[] X, Y, Z, FiX, FiY, FiZ;
            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1, QDerivs;
            //X = null; Y = null; Z = null; FiX = null; FiY = null; FiZ = null;
            this.CalcDofsAndDerivsExistanceByBin(this.DerivsAndDoFsBin, ref Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            if (XExists == 1 && DoFN == 1)
            {

                this.set_x(q, PointN);
                set_Vx(dq, PointN);
            }
            if (YExists == 1 && DoFN == 2)
            {

                set_y(q, PointN);
                set_Vy(dq, PointN);
            }
            if (ZExists == 1 && DoFN == 2)
            {
                set_z(q, PointN);
                set_Vz(dq, PointN);
            }

            if (FiXExists == 1 && DoFN == 4)
            {

                set_FiX(q, PointN);
                set_Wx(dq, PointN);
            }
            if (FiYExists == 1 && DoFN == 5)
            {

                set_FiY(q, PointN);
                set_Wy(dq, PointN);
            }
            if (FiZExists == 1 && DoFN == 6)
            {
                set_FiZ(q, PointN);
                set_Wz(dq, PointN);
            }
        }
        //
        public void set_x(double val, int PointN)
        {
            int XN = get_XN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][XN - 1] = val;
            }
        }
        public void set_y(double val, int PointN)
        {
            int YN = get_YN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][YN - 1] = val;
            }
        }
        public void set_z(double val, int PointN)
        {
            int ZN = get_ZN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][ZN - 1] = val;
            }
        }
        public void set_FiX(double val, int PointN)
        {
            int FiXN = get_FiXN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][FiXN - 1] = val;
            }
        }
        public void set_FiY(double val, int PointN)
        {
            int FiYN = get_FiYN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][FiYN - 1] = val;
            }
        }
        public void set_FiZ(double val, int PointN)
        {
            int FiZN = get_FiZN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][FiZN - 1] = val;
            }
        }
        public void set_Vx(double val, int PointN)
        {
            int XN = get_XN();
            int VxN = get_VxN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VxN - 1] = val;
            }
        }
        public void set_Vy(double val, int PointN)
        {
            int YN = get_YN();
            int VyN = get_VyN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VyN - 1] = val;
            }
        }
        public void set_Vz(double val, int PointN)
        {
            int ZN = get_ZN();
            int VzN = get_VzN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VzN - 1] = val;
            }
        }
        public void set_Wx(double val, int PointN)
        {
            int FiXN = get_FiXN();
            int WxN = get_WxN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WxN - 1] = val;
            }
        }
        public void set_Wy(double val, int PointN)
        {
            int FiYN = get_FiYN();
            int WyN = get_WyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WyN - 1] = val;
            }
        }
        public void set_Wz(double val, int PointN)
        {
            int FiZN = get_FiZN();
            int WzN = get_WzN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WzN - 1] = val;
            }
        }
        public void set_aX(double val, int PointN)
        {
            int XN = get_XN();
            int axN = get_axN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][axN - 1] = val;
            }
        }
        public void set_aY(double val, int PointN)
        {
            int YN = get_YN();
            int ayN = get_ayN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][ayN - 1] = val;
            }
        }
        public void set_aZ(double val, int PointN)
        {
            int ZN = get_ZN();
            int axN = get_axN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][axN - 1] = val;
            }
        }
        public void set_ex(double val, int PointN)
        {
            int FiXN = get_FiXN();
            int exN = get_exN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][exN - 1] = val;
            }
        }
        public void set_ey(double val, int PointN)
        {
            int FiYN = get_FiYN();
            int eyN = get_eyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][eyN - 1] = val;
            }
        }
        public void set_ez(double val, int PointN)
        {
            int FiZN = get_FiZN();
            int ezN = get_ezN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][ezN - 1] = val;
            }
        }
        //Setters for first or single point
        public void set_x(double val)
        {
            int XN = get_XN();
            if (XN != 0)
            {
                this.x[1 - 1][XN - 1] = val;
            }
        }
        public void set_y(double val)
        {
            int YN = get_YN();
            if (YN != 0)
            {
                this.x[1 - 1][YN - 1] = val;
            }
        }
        public void set_z(double val)
        {
            int ZN = get_ZN();
            if (ZN != 0)
            {
                this.x[1 - 1][ZN - 1] = val;
            }
        }
        public void set_FiX(double val)
        {
            int PointN = 1;
            int FiXN = get_FiXN();
            if (FiXN != 0)
            {
                this.x[PointN - 1][FiXN - 1] = val;
            }
        }
        public void set_FiY(double val)
        {
            int PointN = 1;
            int FiYN = get_FiYN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][FiYN - 1] = val;
            }
        }
        public void set_FiZ(double val)
        {
            int FiZN = get_FiZN();
            int PointN = 1;
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][FiZN - 1] = val;
            }
        }
        public void set_Vx(double val)
        {
            int XN = get_XN();
            int PointN = 1;
            int VxN = get_VxN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VxN - 1] = val;
            }
        }
        public void set_Vy(double val)
        {
            int YN = get_YN();
            int PointN = 1;
            int VyN = get_VyN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VyN - 1] = val;
            }
        }
        public void set_Vz(double val)
        {
            int ZN = get_ZN();
            int PointN = 1;
            int VzN = get_VzN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][VzN - 1] = val;
            }
        }
        public void set_Wx(double val)
        {
            int FiXN = get_FiXN();
            int PointN = 1;
            int WxN = get_WxN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WxN - 1] = val;
            }
        }
        public void set_Wy(double val)
        {
            int FiYN = get_FiYN();
            int PointN = 1;
            int WyN = get_WyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WyN - 1] = val;
            }
        }
        public void set_Wz(double val)
        {
            int FiZN = get_FiZN();
            int PointN = 1;
            int WzN = get_WzN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][WzN - 1] = val;
            }
        }
        public void set_aX(double val)
        {
            int XN = get_XN();
            int PointN = 1;
            int axN = get_axN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][axN - 1] = val;
            }
        }
        public void set_aY(double val)
        {
            int YN = get_YN();
            int PointN = 1;
            int ayN = get_ayN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][ayN - 1] = val;
            }
        }
        public void set_aZ(double val)
        {
            int ZN = get_ZN();
            int PointN = 1;
            int axN = get_axN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][axN - 1] = val;
            }
        }
        public void set_ex(double val)
        {
            int FiXN = get_FiXN();
            int PointN = 1;
            int exN = get_exN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][exN - 1] = val;
            }
        }
        public void set_ey(double val)
        {
            int FiYN = get_FiYN();
            int PointN = 1;
            int eyN = get_exN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][eyN - 1] = val;
            }
        }
        public void set_ez(double val)
        {
            int FiZN = get_FiZN();
            int PointN = 1;
            int ezN = get_ezN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                this.x[PointN - 1][ezN - 1] = val;
            }
        }
        //
        public void SetWholeVals(double[] x, double[] y, double[] z, double[] fiX, double[] fiY, double[] fiZ, double[] Vx, double[] Vy, double[] Vz, double[] Wx, double[] Wy, double[] Wz, double[] ax, double[] ay, double[] az, double[] ex, double[] ey, double[] ez)
        {
            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1;
            int QPoints = PointsQuantity;
            CalcDofsAndDerivsExistanceByBin(this.DerivsAndDoFsBin, ref Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            //
            if (XExists == 1)
            {
                if (x != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_x(x[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_x(0, i);
                    }
                }
                if (Vx != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vx(Vx[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vx(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (ax != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aX(ax[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aX(0, i);
                        }
                    }
                }
            }//XExists
            if (YExists == 1)
            {
                if (y != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_y(y[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_y(0, i);
                    }
                }
                if (Vy != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vy(Vy[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vy(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (ay != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aY(ay[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aY(0, i);
                        }
                    }
                }
            }//YExists
            if (ZExists == 1)
            {
                if (z != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_z(z[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_z(0, i);
                    }
                }
                if (Vz != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vz(Vz[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Vz(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (az != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aZ(az[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_aZ(0, i);
                        }
                    }
                }
            }//ZExists
            if (FiXExists == 1)
            {
                if (fiX != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiX(fiX[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiX(0, i);
                    }
                }
                if (Wx != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wx(Wx[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wx(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (ex != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ex(ex[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ex(0, i);
                        }
                    }
                }
            }//FiXExists
            if (FiYExists == 1)
            {
                if (fiY != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiY(fiY[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiY(0, i);
                    }
                }
                if (Wy != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wy(Wy[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wy(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (ey != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ey(ey[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ey(0, i);
                        }
                    }
                }
            }//FiYExists
            if (FiZExists == 1)
            {
                if (fiZ != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiZ(fiZ[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_FiZ(0, i);
                    }
                }
                if (Wz != null)
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wz(Wz[i - 1], i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QPoints; i++)
                    {
                        set_Wz(0, i);
                    }
                }
                if (Deriv2Exists == 1)
                {
                    if (ez != null)
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ez(ez[i - 1], i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QPoints; i++)
                        {
                            set_ez(0, i);
                        }
                    }
                }
            }//FiZExists
        }//fn set whole vals
        public void SetWhole(int QPoints, double[] x, double[] y, double[] z, double[] fiX, double[] fiY, double[] fiZ, double[] Vx, double[] Vy, double[] Vz, double[] Wx, double[] Wy, double[] Wz, double[] ax, double[] ay, double[] az, double[] ex, double[] ey, double[] ez)
        {
            int Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists;
            this.PointsQuantity = QPoints;
            if (ax != null) Deriv2Exists = 1; else Deriv2Exists = 0;
            if (x != null) XExists = 1; else XExists = 0;
            if (y != null) YExists = 1; else YExists = 0;
            if (z != null) ZExists = 1; else ZExists = 0;
            if (fiX != null) FiXExists = 1; else FiXExists = 0;
            if (fiY != null) FiYExists = 1; else FiYExists = 0;
            if (fiZ != null) FiZExists = 1; else FiZExists = 0;
            this.Set_Struct(QPoints, Deriv2Exists, XExists, YExists, ZExists, FiXExists, FiYExists, FiZExists);
            //
            SetWholeVals(x, y, z, fiX, fiY, fiZ, Vx, Vy, Vz, Wx, Wy, Wz, ax, ay, az, ex, ey, ez);
        }//fn set whole
        //
        //Getters
        //
        public double get_x(int PointN)
        {
            double val = 0;
            int XN = get_XN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][XN - 1];
            }
            return val;
        }
        public double get_y(int PointN)
        {
            double val = 0;
            int YN = get_YN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][YN - 1];
            }
            return val;
        }
        public double get_z(int PointN)
        {
            double val = 0;
            int ZN = get_ZN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][ZN - 1];
            }
            return val;
        }
        public double get_FiX(int PointN)
        {
            double val = 0;
            int FiXN = get_FiXN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][FiXN - 1];
            }
            return val;
        }
        public double get_FiY(int PointN)
        {
            double val = 0;
            int FiYN = get_FiYN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][FiYN - 1];
            }
            return val;
        }
        public double get_FiZ(int PointN)
        {
            double val = 0;
            int FiZN = get_FiZN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][FiZN - 1];
            }
            return val;
        }
        public double get_Vx(int PointN)
        {
            double val = 0;
            int XN = get_XN();
            int VxN = get_VxN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VxN - 1];
            }
            return val;
        }
        public double get_Vy(int PointN)
        {
            double val = 0;
            int YN = get_YN();
            int VyN = get_VyN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VyN - 1];
            }
            return val;
        }
        public double get_Vz(int PointN)
        {
            double val = 0;
            int ZN = get_ZN();
            int VzN = get_VzN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VzN - 1];
            }
            return val;
        }
        public double get_Wx(int PointN)
        {
            double val = 0;
            int FiXN = get_FiXN();
            int WxN = get_WxN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WxN - 1];
            }
            return val;
        }
        public double get_Wy(int PointN)
        {
            double val = 0;
            int FiYN = get_FiYN();
            int WyN = get_WyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WyN - 1];
            }
            return val;
        }
        public double get_Wz(int PointN)
        {
            double val = 0;
            int FiZN = get_FiZN();
            int WzN = get_WzN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WzN - 1];
            }
            return val;
        }
        public double get_aX(int PointN)
        {
            double val = 0;
            int XN = get_XN();
            int axN = get_axN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][axN - 1];
            }
            return val;
        }
        public double get_aY(int PointN)
        {
            double val = 0;
            int YN = get_YN();
            int ayN = get_ayN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][ayN - 1];
            }
            return val;
        }
        public double get_aZ(int PointN)
        {
            double val = 0;
            int ZN = get_ZN();
            int axN = get_axN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][axN - 1];
            }
            return val;
        }
        public double get_ex(int PointN)
        {
            double val = 0;
            int FiXN = get_FiXN();
            int exN = get_exN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][exN - 1];
            }
            return val;
        }
        public double get_ey(int PointN)
        {
            double val = 0;
            int FiYN = get_FiYN();
            int eyN = get_eyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][eyN - 1];
            }
            return val;
        }
        public double get_ez(int PointN)
        {
            double val = 0;
            int FiZN = get_FiZN();
            int ezN = get_ezN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][ezN - 1];
            }
            return val;
        }
        //Getters for first or single point
        public double get_x()
        {
            double val = 0;
            int XN = get_XN();
            if (XN != 0)
            {
                val = this.x[1 - 1][XN - 1];
            }
            return val;
        }
        public double get_y()
        {
            double val = 0;
            int YN = get_YN();
            if (YN != 0)
            {
                val = this.x[1 - 1][YN - 1];
            }
            return val;
        }
        public double get_z()
        {
            double val = 0;
            int ZN = get_ZN();
            if (ZN != 0)
            {
                val = this.x[1 - 1][ZN - 1];
            }
            return val;
        }
        public double get_FiX()
        {
            double val = 0;
            int PointN = 1;
            int FiXN = get_FiXN();
            if (FiXN != 0)
            {
                val = this.x[PointN - 1][FiXN - 1];
            }
            return val;
        }
        public double get_FiY()
        {
            double val = 0;
            int PointN = 1;
            int FiYN = get_FiYN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][FiYN - 1];
            }
            return val;
        }
        public double get_FiZ()
        {
            double val = 0;
            int FiZN = get_FiZN();
            int PointN = 1;
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][FiZN - 1];
            }
            return val;
        }
        public double get_Vx()
        {
            double val = 0;
            int XN = get_XN();
            int PointN = 1;
            int VxN = get_VxN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VxN - 1];
            }
            return val;
        }
        public double get_Vy()
        {
            double val = 0;
            int YN = get_YN();
            int PointN = 1;
            int VyN = get_VyN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VyN - 1];
            }
            return val;
        }
        public double get_Vz()
        {
            double val = 0;
            int ZN = get_ZN();
            int PointN = 1;
            int VzN = get_VzN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][VzN - 1];
            }
            return val;
        }
        public double get_Wx()
        {
            double val = 0;
            int FiXN = get_FiXN();
            int PointN = 1;
            int WxN = get_WxN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WxN - 1];
            }
            return val;
        }
        public double get_Wy()
        {
            double val = 0;
            int FiYN = get_FiYN();
            int PointN = 1;
            int WyN = get_WyN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WyN - 1];
            }
            return val;
        }
        public double get_Wz()
        {
            double val = 0;
            int FiZN = get_FiZN();
            int PointN = 1;
            int WzN = get_WzN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][WzN - 1];
            }
            return val;
        }
        public double get_aX()
        {
            double val = 0;
            int XN = get_XN();
            int PointN = 1;
            int axN = get_axN();
            if (XN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][axN - 1];
            }
            return val;
        }
        public double get_aY()
        {
            double val = 0;
            int YN = get_YN();
            int PointN = 1;
            int ayN = get_ayN();
            if (YN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][ayN - 1];
            }
            return val;
        }
        public double get_aZ()
        {
            double val = 0;
            int ZN = get_ZN();
            int PointN = 1;
            int axN = get_axN();
            if (ZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][axN - 1];
            }
            return val;
        }
        public double get_ex()
        {
            double val = 0;
            int FiXN = get_FiXN();
            int PointN = 1;
            int exN = get_exN();
            if (FiXN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][exN - 1];
            }
            return val;
        }
        public double get_ey()
        {
            double val = 0;
            int FiYN = get_FiYN();
            int PointN = 1;
            int eyN = get_exN();
            if (FiYN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][eyN - 1];
            }
            return val;
        }
        public double get_ez()
        {
            double val = 0;
            int FiZN = get_FiZN();
            int PointN = 1;
            int ezN = get_ezN();
            if (FiZN != 0 && PointN >= 1 && PointN <= PointsQuantity)
            {
                val = this.x[PointN - 1][ezN - 1];
            }
            return val;
        }
        public void Show(TValsShowHide vsh)
        {
            string s;
            s = "";

            int Deriv2Exists = -1, XExists = -1, YExists = -1, ZExists = -1, FiXExists = -1, FiYExists = -1, FiZExists = -1;
            this.CalcDofsAndDerivsExistanceByBin(this.DerivsAndDoFsBin, ref  Deriv2Exists, ref XExists, ref YExists, ref ZExists, ref FiXExists, ref FiYExists, ref FiZExists);
            for (int i = 1; i <= PointsQuantity; i++)
            {
                s = "PtN= " + i.ToString() + " ";
                if (i == 0)
                {
                    //NOp;
                }
                else
                {
                    //X
                    if (XExists == 1) { s = s + "X= " + (get_x(i)).ToString() + " "; }
                    //Y
                    if (YExists == 1) { s = s + "Y= " + (get_y(i)).ToString() + " "; }
                    //Z
                    if (ZExists == 1) { s = s + "Z= " + (get_z(i)).ToString() + " "; }
                    //FiX
                    if (FiXExists == 1) { s = s + "FiX= " + (get_FiX(i)).ToString() + " "; }
                    //Fi
                    if (FiYExists == 1) { s = s + "FiY= " + (get_FiY(i)).ToString() + " "; }
                    //FiZ
                    if (FiZExists == 1) { s = s + "FiZ= " + (get_FiZ(i)).ToString() + " "; }
                    //VX
                    if (XExists == 1) { s = s + "Vx= " + (get_Vx(i)).ToString() + " "; }
                    //VY
                    if (YExists == 1) { s = s + "Vy= " + (get_Vy(i)).ToString() + " "; }
                    //VZ
                    if (ZExists == 1) { s = s + "Vz= " + (get_Vz(i)).ToString() + " "; }
                    //W
                    if (FiXExists == 1) { s = s + "Wx= " + (get_Wx(i)).ToString() + " "; }
                    //WY
                    if (FiYExists == 1) { s = s + "Wy= " + (get_Wy(i)).ToString() + " "; }
                    //WZ
                    if (FiZExists == 1) { s = s + "Wz= " + (get_Wz(i)).ToString() + " "; }
                    if (Deriv2Exists == 1)
                    {
                        //X
                        if (XExists == 1) { s = s + "aX= " + (get_aX(i)).ToString() + " "; }
                        //Y
                        if (YExists == 1) { s = s + "aY= " + (get_aY(i)).ToString() + " "; }
                        //Z
                        if (ZExists == 1) { s = s + "aZ= " + (get_aZ(i)).ToString() + " "; }
                        //FiX
                        if (FiXExists == 1) { s = s + "eX= " + (get_ex(i)).ToString() + " "; }
                        //FiY
                        if (FiYExists == 1) { s = s + "eY= " + (get_ey(i)).ToString() + " "; }
                        //FiZ
                        if (FiZExists == 1) { s = s + "eZ= " + (get_ez(i)).ToString() + " "; }
                    }
                }
                MyLib.writeln(vsh, s);
            }//for
        }//fn
        
    }//cl
}//ns
