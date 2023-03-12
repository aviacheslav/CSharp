
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class Matrix
    {
        double[][] c;
        int QLines, QColumns;
        public Matrix()
        {
            QLines = 1; QColumns = 1;
            c = new double[QLines][];
            for (int i = 1; i <= QColumns; i++)
            {
                c[i - 1] = new double[QColumns];
            }
            c[1 - 1][1 - 1] = 0;
        }
        public Matrix(int QLines, int QColumns)
        {
            this.c = null;
            this.c = new double[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.c[i - 1] = new double[QColumns];
            }
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    this.c[i - 1][j - 1] = 0;
                }
            }
            Set(c, QLines, QColumns);
        }
        public Matrix(double[][] c, int QLines, int QColumns)
        {
            this.c = null;
            Set(c, QLines, QColumns);
        }
        public Matrix(double[] c, int QRows, bool IsVector)
        {
            this.c = null;
            Set(c, QLines, true);
        }
        public int GetQLines()
        {
            return QLines;
        }
        public int GetQColumns()
        {
            return QColumns;
        }
        public void SetComponent(double x, int LineN, int ColN)
        {
            if (LineN >= 1 && LineN <= QLines && ColN >= 1 && ColN <= QColumns && c != null)
            {
                c[LineN - 1][ColN - 1] = x;
            }
        }
        public double GetComponent(int LineN, int ColN)
        {
            double y = 0;
            if (LineN >= 1 && LineN <= QLines && ColN >= 1 && ColN <= QColumns && c != null)
            {
                y = c[LineN - 1][ColN - 1];
            }
            return y;
        }
        public double C(int LineN, int ColN)
        {
            return GetComponent(LineN, ColN);
        }
        public void Set(double[][] x, int QLines, int QColumns)
        {
            if (QLines >= 1 && QLines <= MyLib.MaxInt && QColumns >= 1 && QColumns <= MyLib.MaxInt /*&& c != null*/)
            {
                c = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    c[i - 1] = new double[QColumns];
                }
                if (x != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            c[i - 1][j - 1] = x[i - 1][j - 1];
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            c[i - 1][j - 1] = 0;
                        }
                    }
                }
            }
            this.QLines = QLines; this.QColumns = QColumns;
        }
        public void Set(double[] x, int QRows, bool IsVector)
        {
            if (IsVector)
            {
                QLines = QRows;
                QColumns = 1;
                c = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    c[i - 1] = new double[QColumns];
                }
                if (x != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        c[i - 1][1 - 1] = x[i - 1];
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        c[i - 1][1 - 1] = 0;
                    }
                }
            }
            else//Not vector
            {
                QColumns = QRows;
                QLines = 1;
                c = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    c[i - 1] = new double[QColumns];
                }
                if (x != null)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        c[1 - 1][j - 1] = x[j - 1];
                    }
                }
                else
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        c[1 - 1][j - 1] = 0;
                    }
                }
            }
        }
        public void Set3DVector(double x, double y, double z)
        {
            c = new double[3][];
            for (int i = 1; i <= 3; i++)
            {
                c[i - 1] = new double[1];
            }
            c[1 - 1][1 - 1] = x;
            c[2 - 1][1 - 1] = y;
            c[3 - 1][1 - 1] = z;
            QLines = 3;
            QColumns = 1;
        }
        public void Get3Coords(ref double x, ref double y, ref double z)
        {
            int QL;
            QL = GetQLines();
            y = 0; z = 0;
            if (QL >= 2) y = GetComponent(2, 1);
            if (QL > 3) z = GetComponent(3, 1);
        }
        public void Get(ref double[][] c, ref int QLines, ref int QColumns)
        {
            c = this.c; QLines = this.QLines; QColumns = this.QColumns;
        }
        public double GetX() { return c[1 - 1][1 - 1]; }
        public double GetY()
        {
            double r;
            if (QLines < 2) r = 0;
            else r = c[2 - 1][1 - 1];
            return r;
        }
        public double GetZ()
        {
            double r;
            if (QLines < 3) r = 0;
            else r = c[3 - 1][1 - 1];
            return r;
        }
        public void SetSize(int QLines, int QColumns, int PreserveVals_No0Yes1Construct2 = 1)
        {
            double[][] c = null;
            int QLinesMin, QColumnsMin;
            if (this.QLines != QLines || this.QColumns != QColumns && (QLines >= 1 && QLines <= MyLib.MaxInt && QColumns >= 1 && QColumns <= MyLib.MaxInt))
            {
                switch (PreserveVals_No0Yes1Construct2)
                {
                    case 0:
                        //if(this.c!=null)delete c
                        this.c = new double[QLines][];
                        for (int i = 1; i <= QLines; i++)
                        {
                            this.c[i - 1] = new double[QColumns];
                        }
                        for (int i = 1; i <= QLines; i++)
                        {
                            for (int j = 1; j <= QColumns; j++)
                            {
                                this.c[i - 1][j - 1] = 0;
                            }
                        }
                        break;
                    case 1:
                        if (this.c != null)
                        {
                            if (this.QLines <= QLines) QLinesMin = this.QLines; else QLinesMin = QLines;
                            if (this.QColumns <= QColumns) QColumnsMin = this.QColumns; else QColumnsMin = QColumns;
                            c = new double[QLines][];
                            for (int i = 1; i <= QLines; i++) c[i - 1] = new double[QColumns];
                            for (int i = 1; i <= QLines; i++)
                            {
                                for (int j = 1; j <= QColumns; j++)
                                {
                                    c[i - 1][j - 1] = 0;
                                }
                            }
                            for (int i = 1; i <= QLinesMin; i++)
                            {
                                for (int j = 1; j <= QColumnsMin; j++)
                                {
                                    c[i - 1][j - 1] = this.c[i - 1][j - 1];
                                }
                            }
                            //delete this.c;
                            this.c = c;
                        }
                        break;
                    case 2:
                        this.c = new double[QLines][];
                        for (int i = 1; i <= QLines; i++)
                        {
                            this.c[i - 1] = new double[QColumns];
                        }
                        for (int i = 1; i <= QLines; i++)
                        {
                            for (int j = 1; j <= QColumns; j++)
                            {
                                this.c[i - 1][j - 1] = 0;
                            }
                        }
                        break;
                }
            }//if nesessary
        }//fn set size
        public void SetFromTable(TTable tbl, TableInfo tblInfExt = null)
        {
            int QLines, QColumns;
            double[][] c;
            TableInfo TblInf = tbl.Choose_TableInfo_StrSize_ByExtAndInner(tblInfExt);
            if (tbl == null)
            {
                QLines = 1; QColumns = 1;

            }
            else
            {
                QLines = TblInf.GetQLines();
                QColumns = TblInf.GetQColumns();
            }
            c = new double[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                c[i - 1] = new double[QColumns];
            }
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    c[i - 1][j - 1] = tbl.GetDoubleVal(i, j);
                }
            }
            this.Set(c, QLines, QColumns);
        }
        public TTable GetAsTable(string name = null, bool WriteInfo = true, bool BothOnly = false, TableUssagePolicy UsePol = null)
        {
            TTable tbl = null;
            TableHeaders Hdr = null;
            double[] line = new double[this.QColumns];
            DataCellRow[] rows = new DataCellRow[this.QLines];
            for (int i = 1; i <= this.QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++) line[j - 1] = c[i - 1][j - 1];
                rows[i - 1] = new DataCellRow(line, this.QColumns);
            }
            if (name != null && name != "") Hdr = new TableHeaders(new DataCell(name), null, null);
            TableInfo TblInf = new TableInfo(true, false, false, this.QLines, this.QColumns);
            if (WriteInfo == true)
            {
                TblInf.UssagePolicy = UsePol;
                //TblInf.UssagePolicy = new TableUssagePolicy;
                //if(UsePol!=null)TblInf.UssagePolicy=(TableUssagePolicy)UsePol.Clone(); else TblInf.UssagePolicy=null;
                if (UsePol == null)
                {
                    TblInf.UssagePolicy = new TableUssagePolicy();
                }
                if (BothOnly == true)
                {
                    TblInf.UssagePolicy.ForbidAll();
                    TblInf.UssagePolicy.BothCanAdd = true;
                    TblInf.UssagePolicy.BothCanDel = true;
                    TblInf.UssagePolicy.BothCanIns = true;
                    TblInf.UssagePolicy.BothCanReplace = true;
                }
                //
                TblInf.Repr_Text = new TableRepresentation();
                TblInf.Repr_Text.Set_Matrix();
            }
            tbl = new TTable(
                //new TableInfo(true, false, false, this.QLines, this.QColumns),
                TblInf,
                false,//ob by lines
                rows,
                null, null, Hdr,
                WriteInfo
            );
            return tbl;
        }
        //
        public Matrix TransposeTo()
        {
            Matrix M;
            double[][] y;
            //M = new Matrix();
            y = new double[QColumns][];
            for (int i = 1; i <= QColumns; i++)
            {
                y[i - 1] = new double[QLines];
            }
            for (int i = 1; i <= QColumns; i++)
            {
                for (int j = 1; j <= QLines; j++)
                {
                    //y[j - 1][i - 1] = c[i - 1][j - 1];
                    //y[i-1][j-1]=new double();
                    y[i - 1][j - 1] = c[j - 1][i - 1];
                }
            }
            //M.Set(y, QColumns, QLines);
            M = new Matrix(y, QColumns, QLines);
            return M;
        }
        void Transpose()
        {
            MyLib.TransposeTable(ref c, ref QLines, ref QColumns);
        }
        Matrix SubVector(int N, bool ColumnNotLine)
        {
            Matrix M;
            double[][] y;
            if (ColumnNotLine)
            {
                y = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new double[1 - 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        y[i - 1][j - 1] = c[i - 1][N - 1];
                    }
                }
                M = new Matrix(y, QLines, 1);
            }
            else
            {
                y = new double[QColumns][];
                for (int i = 1; i <= QColumns; i++)
                {
                    y[i - 1] = new double[1 - 1];
                }
                for (int i = 1; i <= 1; i++)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        y[j - 1][i - 1] = c[N - 1][j - 1];
                    }
                }
                M = new Matrix(y, QColumns, 1);
            }
            return M;
        }
        Matrix SubVector(Matrix M, int N, bool ColumnNotLine)
        {
            Matrix MR;
            double[][] y;
            if (ColumnNotLine)
            {
                y = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new double[1 - 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        y[i - 1][j - 1] = M.GetComponent(i, N);
                    }
                }
                MR = new Matrix(y, QLines, 1);
            }
            else
            {
                y = new double[QColumns][];
                for (int i = 1; i <= QColumns; i++)
                {
                    y[i - 1] = new double[1 - 1];
                }
                for (int i = 1; i <= 1; i++)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        y[j - 1][i - 1] = M.GetComponent(N, j);
                    }
                }
                MR = new Matrix(y, QColumns, 1);
            }
            return MR;
        }
        public Matrix SubMatrixTo(int L1, int L2, int C1, int C2)
        {
            Matrix M;
            double[][] y;
            int QLinesRes = 0, QColumnsRes = 0;
            y = null;
            MyLib.SubTableByNs(this.c, ref y, this.QLines, this.QColumns, L1, C1, L2, C2, ref QLinesRes, ref QColumnsRes);
            M = new Matrix(y, QLinesRes, QColumnsRes);
            return M;
        }
        public Matrix DelLineTo(int N)
        {
            Matrix M;
            double[][] y;
            int QLinesRes = QLines, QColumnsRes = QColumns; //obligatory so
            y = c; //obligatory so
            MyLib.DelLineFromTable(ref y, N, ref QLinesRes, ref QColumnsRes);
            M = new Matrix(y, QLinesRes, QColumnsRes);
            return M;
        }
        public void DelLine(int N)
        {
            MyLib.DelLineFromTable(ref c, N, ref QLines, ref QColumns);
        }
        public Matrix DelColTo(int N)
        {
            Matrix M;
            double[][] y;
            int QLinesRes = QLines, QColumnsRes = QColumns; //obligatory so
            y = c; //obligatory so
            MyLib.DelColumnFromTable(ref y, N, ref QLinesRes, ref QColumnsRes);
            M = new Matrix(y, QLinesRes, QColumnsRes);
            return M;
        }
        public void DelCol(int N)
        {
            MyLib.DelColumnFromTable(ref c, N, ref QLines, ref QColumns);
        }
        public Matrix MinorTo(int LineN, int ColN)
        {
            Matrix M;
            M = this.DelLineTo(LineN);
            M = M.DelColTo(ColN);
            return M;
        }
        public Matrix MinorTo(Matrix M, int LineN, int ColN)
        {
            Matrix MR;
            MR = M.DelLineTo(LineN);
            MR = MR.DelColTo(ColN);
            return MR;
        }
        public void Minor(int LineN, int ColumnN)
        {
            DelCol(ColumnN);
            DelLine(LineN);
        }
        public double AlgSuppl(int LineN, int ColumnN)
        {
            double d, r;
            Matrix M;
            M = new Matrix();
            if ((LineN < 1) || (LineN > QLines) || (ColumnN < 1) || (ColumnN > QColumns))
            {
                r = 666;
            }
            else
            {
                M = (Matrix)this.MemberwiseClone();
                M = MinorTo(M, LineN, ColumnN);
                d = M.Determinant();
                r = d;
                if ((LineN + ColumnN)%2 != 0)
                {
                    r *= (-1);
                }
            }
            return r;
        }
        public double Determinant()
        {
            double r, d, AlgSpl;
            int RowN;
            if (QColumns != QLines) return 666;
            else
            {
                if (QLines == 1)
                {
                    r = c[1 - 1][1 - 1];
                }
                else if (QLines == 2)
                {
                    r = c[1 - 1][1 - 1] * C(2, 2) - c[1 - 1][2 - 1] * c[2 - 1][1 - 1];
                }
                else if (QLines == 3)
                {
                    r = C(1, 1) * C(2, 2) * C(3, 3) + C(1, 3) * C(2, 1) * C(3, 2) + C(3, 1) * C(1, 2) * C(2, 3) -
                        C(1, 3) * C(2, 2) * C(3, 1) - C(1, 1) * C(2, 3) * C(3, 2) - C(3, 3) * C(1, 2) * C(2, 1);
                }
                else
                {
                    RowN = 1;
                    r = 0;
                    for (int j = 1; j <= QColumns; j++)
                    {
                        r += GetComponent(RowN, j) * AlgSuppl(RowN, j);
                    }
                }
            }
            return r;
        }
        /*public Matrix UnionMatrix()
        {
            int QLines=this.GetQLines(), QColumns=this.GetQColumns();
            int TQLines=QColumns, TQColumns=QLines;
            //Matrix MT = new Matrix();
            //MT = this.TransposeTo();
            Matrix MUR=new Matrix();
            double[][]c;
            double CurAlgSuppl, det=this.Determinant();
            c=new double[TQLines][];
            for(int i=1; i<=TQLines; i++){
                c[i-1]=new double[TQColumns];
            }
            if (det != 0)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        CurAlgSuppl = this.AlgSuppl(i, j);
                        c[j - 1][i - 1] = CurAlgSuppl / det;
                    }
                }
                
            }
            else
            {
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        c[j - 1][i - 1] = this.GetComponent(j, i);
                    }
                }
            }
            MUR = new Matrix(c, TQLines, TQColumns);
            return MUR;
        }*/
        public Matrix UnionMatrix()
        {
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            int TQLines = QColumns, TQColumns = QLines;
            //Matrix MT = new Matrix();
            //MT = this.TransposeTo();
            Matrix MUR = new Matrix();
            double[][] c;
            double CurAlgSuppl;//, det = this.Determinant();
            c = new double[TQLines][];
            for (int i = 1; i <= TQLines; i++)
            {
                c[i - 1] = new double[TQColumns];
            }
            //
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    CurAlgSuppl = this.AlgSuppl(i, j);
                    c[j - 1][i - 1] = CurAlgSuppl;
                }
            }
            //
            MUR = new Matrix(c, TQLines, TQColumns);
            return MUR;
        }
        public Matrix InverseMatrix()
        {
            Matrix MIR;
            double det = this.Determinant();
            MIR = this.UnionMatrix();
            if (det != 0) MIR = MIR * (1 / det);
            return MIR;
        }
        public static Matrix operator +(Matrix M1, Matrix M2)
        {
            int QLines = 1, QColumns = 1;
            Matrix MR;
            MR = new Matrix();
            double[][] y;
            bool OperandsFit;
            y = null;
            OperandsFit = (M1.GetQLines() == M2.GetQLines() && M1.GetQColumns() == M2.GetQColumns());
            if (OperandsFit)
            {
                QLines = M1.GetQLines();
                QColumns = M1.GetQColumns();
                y = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new double[QColumns];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        y[i - 1][j - 1] = M1.GetComponent(i, j) + M2.GetComponent(i, j);
                    }
                }
                MR.Set(y, QLines, QColumns);
            }
            return MR;
            //return this; //static - not allowed
        }
        public static Matrix operator -(Matrix M1, Matrix M2)
        {
            int QLines = 1, QColumns = 1;
            Matrix MR;
            MR = new Matrix();
            double[][] y;
            bool OperandsFit;
            y = null;
            OperandsFit = (M1.GetQLines() == M2.GetQLines() && M1.GetQColumns() == M2.GetQColumns());
            if (OperandsFit)
            {
                QLines = M1.GetQLines();
                QColumns = M1.GetQColumns();
                y = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new double[QColumns];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        y[i - 1][j - 1] = M1.GetComponent(i, j) - M2.GetComponent(i, j);
                    }
                }
                MR.Set(y, QLines, QColumns);
            }
            return MR;
        }
        public static Matrix operator *(Matrix M1, Matrix M2)
        {
            int QLines = 1, QColumns = 1, QMultiplications = 0;
            Matrix MR;
            MR = new Matrix();
            double[][] y;
            double c, c1, c2;
            bool OperandsFit;
            y = null;
            OperandsFit = (M1.GetQColumns() == M2.GetQLines());
            if (OperandsFit)
            {
                QLines = M1.GetQLines();
                QColumns = M2.GetQColumns();
                QMultiplications = M1.GetQColumns();
                y = new double[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    y[i - 1] = new double[QColumns];
                }
                //for(int i=1; i<=
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        //y[i - 1][j - 1] = M1.GetComponent(i, j) * M2.GetComponent(j, i);
                        c = 0;
                        for (int k = 1; k <= QMultiplications; k++)
                        {
                            c1 = M1.GetComponent(i, k);
                            c2 = M2.GetComponent(k, j);
                            c = c + c1 * c2;
                            y[i - 1][j - 1] = c;
                            //c = c+M1.GetComponent(i, k) * M2.GetComponent(k, j);
                        }
                    }
                }
                //}
                MR.Set(y, QLines, QColumns);
            }
            return MR;
        }
        public static Matrix operator *(Matrix M1, double k)
        {
            int QLines = 1, QColumns = 1;
            Matrix MR;
            MR = new Matrix();
            double[][] y;
            y = null;

            QLines = M1.GetQLines();
            QColumns = M1.GetQColumns();
            y = new double[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                y[i - 1] = new double[QColumns];
            }
            //for(int i=1; i<=
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    y[i - 1][j - 1] = M1.GetComponent(i, j) * k;
                }
            }
            //}
            MR.Set(y, QLines, QColumns);
            return MR;
        }
        public static Matrix operator *(double k, Matrix M1)
        {
            int QLines = 1, QColumns = 1;
            Matrix MR;
            MR = new Matrix();
            double[][] y;
            y = null;

            QLines = M1.GetQLines();
            QColumns = M1.GetQColumns();
            y = new double[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                y[i - 1] = new double[QColumns];
            }
            //for(int i=1; i<=
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    y[i - 1][j - 1] = M1.GetComponent(i, j) * k;
                }
            }
            //}
            MR.Set(y, QLines, QColumns);
            return MR;
        }
        public static Matrix operator /(Matrix M1, Matrix M2)
        {
            Matrix MR, MI;
            MI = M1.InverseMatrix();
            MR = MI * M2;
            return MR;
        }
        //
        /*
        public Matrix DirCossByEulersAngles(double Gamma, double Psi, double Theta)
        {
            Matrix MR=new Matrix(3,3);
            //double Gamma=Angles.GetX(), Psi=Angles.GetY(), Theta=Angles.GetZ();
            MR.SetComponent(Math.Cos(Psi)*(Math.Cos(Theta)),                                 1,1);
            MR.SetComponent((Math.Sin(Psi) * (Math.Sin(Gamma) - (Math.Cos(Psi) * (Math.Sin(Theta) * (Math.Cos(Gamma)))), 1, 2);
            MR.SetComponent((Math.Sin(Psi) * (Math.Cos(Gamma) + (Math.Cos(Psi) * (Math.Sin(Theta) * (Math.Sin(Gamma)), 1, 3);
            MR.SetComponent((Math.Sin(Theta), 2, 1);
            MR.SetComponent((Math.Cos(Theta) * (Math.Cos(Gamma), 2, 2);
            MR.SetComponent(-(Math.Cos(Theta) * Math.Sin(Gamma), 2, 3);
            MR.SetComponent(-Math.Sin(Psi) * (Math.Cos(Theta), 3, 1);
            MR.SetComponent((Math.Cos(Psi) * (Math.Sin(Gamma) + (Math.Sin(Psi) * (Math.Sin(Theta) * (Math.Cos(Gamma)), 3, 2);
            MR.SetComponent((Math.Cos(Psi) * (Math.Cos(Gamma) - (Math.Sin(Psi) * (Math.Sin(Theta) * (Math.Sin(Gamma)), 3, 3);
            return MR;
        }
         */
        /*
         Matrix TrfrmCoordsBtwGroundAndAircraftCSAirdynAngles(Matrix IniCoords, Matrix Angles, Matrix CSDist, bool FromEarthCSIntoAircraftCS, bool DistInEarthCSNotAircraftCS){
    //version 2, with messages; not class member
    //Matrix*MGost=new Matrix(), *RsltM=new Matrix(); //changed 2015-08-12
    Matrix *MGost=new Matrix(), RsltM; //changed 2015-08-12
    *MGost=MGost->GostMatrixForCoordTrfmByADAngles(Angles); //changed 2015-08-12
    if(FromEarthCSIntoAircraftCS){
        MGost->Inverse();
        MGost->ShowInMessageWithCaption("Matrix by GOST (inversed)");
        if(DistInEarthCSNotAircraftCS){
            //*RsltM=(*(MGost->InverseTo()))*(IniCoords-CSDist);
            RsltM=(*(MGost))*(IniCoords-CSDist);  //changed 2015-08-12
            RsltM=(*(MGost))*(IniCoords-CSDist);  //changed 2015-08-12
        }else{//dist in Aircraft CS
            //*RsltM=(*(MGost->InverseTo()))*IniCoords+CSDist;
            //RsltM=(*(MGost))*IniCoords+CSDist;  //changed 2015-08-12
            RsltM=(*(MGost))*IniCoords+CSDist;  //changed 2015-08-12
        }
    }else{//from aircraft into land
        MGost->ShowInMessageWithCaption("Matrix by GOST");
        if(DistInEarthCSNotAircraftCS){
            //*RsltM=(*(MGost))*IniCoords+CSDist;    //changed 2015-08-12
            RsltM=(*(MGost))*IniCoords+CSDist;    //changed 2015-08-12
        }else{//dist in Aircraft CS
            //*RsltM=(*(MGost))*(IniCoords-CSDist);  //changed 2015-08-12
            RsltM=(*(MGost))*(IniCoords-CSDist);  //changed 2015-08-12
        }
    }
    delete MGost; //2015-08-11 here must be delete MGost
    //return *RsltM; //changed 2015-08-12
    return RsltM; //changed 2015-08-12
}

         */
        public void Set3DVector()
        {
            //int QLMin;
            //double[] c = new double[3];
            //if (this.QLines <= 3) QLMin = QLines; else QLMin = 3;
            //for (int i = 1; i <= 3; i++) c[i - 1] = 0;
            //for (int i = 1; i <= QLMin; i++) c[i - 1] = this.GetComponent(i,1);
            this.SetSize(3, 1, 1);
        }
        //public void Set3DVector(double x, double y, double z)
        //{
        //    int QLMin;
        //    double[] c = new double[3];
        //    if (this.QLines <= 3) QLMin = QLines; else QLMin = 3;
        //    for (int i = 1; i <= 3; i++) c[i - 1] = 0;
        //    for (int i = 1; i <= QLMin; i++) c[i - 1] = this.GetComponent(i,1);
        //    this.Set(c, 3, true);
        //}
        public void Set3DTransform()
        {
            this.SetSize(3, 3, 1);
        }
    }//cl
    public class MatrixCalculator
    {
        Matrix M1, M2, M3, M4, M5;
        TableUssagePolicy[] usePol;
        //string[] names;
        int ActiveN;
        //
        public MatrixCalculator()
        {
            M1 = new Matrix(); M2 = new Matrix(); M3 = new Matrix(); M4 = new Matrix(); M5 = new Matrix();
            ActiveN = 1;
            //
            usePol = new TableUssagePolicy[5];
            for (int i = 1; i <= 5; i++)
            {
                usePol[i - 1] = new TableUssagePolicy();
                usePol[i - 1].ForbidAll();
                usePol[i - 1].AllowEditContents();
            }
            usePol[5 - 1].ForbidEditContents();
            //
            //names = new string[5];
            //names[1 - 1] = "M1";
            //names[2 - 1] = "M2";
            //names[3- 1] = "M3";
            //names[4 - 1] = "M4";
            //names[5 - 1] = "M5";
        }
        public void SetActiveN(int ActiveN)
        {
            if (ActiveN <= 1) this.ActiveN = 1;
            else if (ActiveN >= 5) this.ActiveN = 5;
            else this.ActiveN = ActiveN;
        }
        public Matrix GetM1() { return M1; }
        public Matrix GetM2() { return M2; }
        public Matrix GetM3() { return M3; }
        public Matrix GetM4() { return M4; }
        public Matrix GetM5() { return M5; }
        public Matrix GetCurrentMatrix()
        {
            Matrix R = null;
            switch (ActiveN)
            {
                case 1:
                    R = M1;
                    break;
                case 2:
                    R = M2;
                    break;
                case 3:
                    R = M3;
                    break;
                case 4:
                    R = M4;
                    break;
                case 5:
                    R = M5;
                    break;
            }
            return R;
        }
        //public int GetActiveN()
        //{
        //    int ActiveN=0;

        //    return ActiveN;
        //}
        public void Addition()
        {
            M3 = M1 + M2;
        }
        public void Subtraction()
        {
            M3 = M1 - M2;
        }
        public void Multiplicaction()
        {
            M3 = M1 * M2;
        }
        public void Division()
        {
            M3 = M1 / M2;
        }
        public double Determinant(Matrix M)
        {
            double det = 0;
            //Matrix M = GetCurrentMatrix();
            det = M.Determinant();
            return det;
        }
        public Matrix Minor(Matrix M, int LineN, int ColN)
        {
            Matrix mnr;
            mnr = M.MinorTo(LineN, ColN);
            return mnr;
        }
        public void SetFromTable(TTable tbl, int N)
        {
            this.SetActiveN(N);
            switch (this.ActiveN)
            {
                case 1:
                    M1.SetFromTable(tbl);
                    break;
                case 2:
                    M2.SetFromTable(tbl);
                    break;
                case 3:
                    M3.SetFromTable(tbl);
                    break;
                case 4:
                    M4.SetFromTable(tbl);
                    break;
                case 5:
                    M5.SetFromTable(tbl);
                    break;
            }
        }
        public TTable GetAsTable()
        {
            TTable tbl = null;
            switch (this.ActiveN)
            {
                case 1:
                    tbl = M1.GetAsTable();
                    break;
                case 2:
                    tbl = M2.GetAsTable();
                    break;
                case 3:
                    tbl = M3.GetAsTable();
                    break;
                case 4:
                    tbl = M4.GetAsTable();
                    break;
                case 5:
                    tbl = M5.GetAsTable();
                    break;
            }
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            return tbl;
        }
        public void Assign(int N1, int N2)
        {
            switch (N1)
            {
                case 1:
                    switch (N2)
                    {
                        case 1:
                            //M1 = M1;
                            break;
                        case 2:
                            M1 = M2;
                            break;
                        case 3:
                            M1 = M3;
                            break;
                        case 4:
                            M1 = M4;
                            break;
                        case 5:
                            M1 = M5;
                            break;
                    }
                    break;
                case 2:
                    switch (N2)
                    {
                        case 1:
                            M2 = M1;
                            break;
                        case 2:
                            //M2 = M2;
                            break;
                        case 3:
                            M2 = M3;
                            break;
                        case 4:
                            M2 = M4;
                            break;
                        case 5:
                            M2 = M5;
                            break;
                    }
                    break;
                case 3:
                    switch (N2)
                    {
                        case 1:
                            M3 = M1;
                            break;
                        case 2:
                            M3 = M2;
                            break;
                        case 3:
                            //M3 = M3;
                            break;
                        case 4:
                            M3 = M4;
                            break;
                        case 5:
                            M3 = M5;
                            break;
                    }
                    break;
                case 4:
                    switch (N2)
                    {
                        case 1:
                            M4 = M1;
                            break;
                        case 2:
                            M4 = M2;
                            break;
                        case 3:
                            M4 = M3;
                            break;
                        case 4:
                            //M4 = M4;
                            break;
                        case 5:
                            M4 = M5;
                            break;
                    }
                    break;
                case 5:
                    switch (N2)
                    {
                        case 1:
                            M5 = M1;
                            break;
                        case 2:
                            M5 = M2;
                            break;
                        case 3:
                            M5 = M3;
                            break;
                        case 4:
                            M5 = M4;
                            break;
                        case 5:
                            //M5 = M5;
                            break;
                    }
                    break;
            }
        }
        /*public Matrix operator +(Matrix M1, Matrix M2)//Error operator must be of containing type!
        {
            int QLines, QColumns;
            Matrix MR;
            double[][] y;
            bool OpperandsFit;
            OperandsFit = (M1.GetQLines() == M2.GetQLines() && M1.GetQColumns() == M2.GetQColumns());
            if (OperandsFit)
            {
                QLines = M1.GetQLines();
                QColumns = M1.GetQColumns();
            }
            y = new double[QLines - 1][];
            for (int i = 1; i <= QLines; i++)
            {
                y[i - 1] = new double[QColumns];
            }
            for (int i = 1; i <= 1; i++)
            {
                for (int j = 1; j <= 1; j++)
                {
                    y[i - 1][j - 1] = M1.GetComponent(i, j) + M2.GetComponent(i, j); ;
                }
            }
            MR.Set(y, QLines, QColumns);
            return MR;
        }*/
        Matrix CalcMatrixOfDirCossByEulersAngles(Matrix MEulerAngles)
        {
            Matrix MR = new Matrix(3, 3);
            double gamma = MEulerAngles.GetX() * Math.PI / 180,
                   psi = MEulerAngles.GetY() * Math.PI / 180,
                   theta = MEulerAngles.GetZ() * Math.PI / 180;
            MR.SetComponent(Math.Cos(psi) * Math.Cos(theta), 1, 1);
            MR.SetComponent(Math.Sin(psi) * Math.Sin(gamma) - Math.Cos(psi) * Math.Sin(theta) * Math.Cos(gamma), 1, 2);
            MR.SetComponent(Math.Sin(psi) * Math.Cos(gamma) + Math.Cos(psi) * Math.Sin(theta) * Math.Sin(gamma), 1, 3);
            MR.SetComponent(Math.Sin(theta), 2, 1);
            MR.SetComponent(Math.Cos(theta) * Math.Cos(gamma), 2, 2);
            MR.SetComponent(-Math.Cos(theta) * Math.Sin(gamma), 2, 3);
            MR.SetComponent(-Math.Sin(psi) * Math.Cos(theta), 3, 1);
            MR.SetComponent(Math.Cos(psi) * Math.Sin(gamma) + Math.Sin(psi) * Math.Sin(theta) * Math.Cos(gamma), 3, 2);
            MR.SetComponent(Math.Cos(psi) * Math.Cos(gamma) - Math.Sin(psi) * Math.Sin(theta) * Math.Sin(gamma), 3, 3);
            return MR;
        }
        public void CalcMatrixOfDirCossByEulersAngles()
        {
            M5.SetSize(3, 1, 1);
            M2 = CalcMatrixOfDirCossByEulersAngles(M5);
        }
        //
        public void Set3DVector(int N, bool FixedValues = false)
        {
            switch (N)
            {
                case 1:
                    M1.SetSize(3, 1, 1);
                    break;
                case 2:
                    M2.SetSize(3, 1, 1);
                    break;
                case 3:
                    M3.SetSize(3, 1, 1);
                    break;
                case 4:
                    M4.SetSize(3, 1, 1);
                    break;
                case 5:
                    M5.SetSize(3, 1, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
        }
        public void Set3DTransform(int N, bool FixedValues = false)
        {
            switch (N)
            {
                case 1:
                    M1.SetSize(3, 3, 1);
                    break;
                case 2:
                    M2.SetSize(3, 3, 1);
                    break;
                case 3:
                    M3.SetSize(3, 3, 1);
                    break;
                case 4:
                    M4.SetSize(3, 3, 1);
                    break;
                case 5:
                    M5.SetSize(3, 3, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
        }
        public void SetAnyVector(int ord, int N, bool FixedDimensionsQuantity = false, bool FixedValues = false)
        {
            switch (N)
            {
                case 1:
                    M1.SetSize(ord, 1, 1);
                    break;
                case 2:
                    M2.SetSize(ord, 1, 1);
                    break;
                case 3:
                    M3.SetSize(ord, 1, 1);
                    break;
                case 4:
                    M4.SetSize(ord, 1, 1);
                    break;
                case 5:
                    M5.SetSize(ord, 1, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedDimensionsQuantity) usePol[N - 1].AllowLines();
        }
        public void SetSquare(int ord, int N, bool FixedDimensionsQuantity = false, bool FixedValues = false)
        {
            switch (N)
            {
                case 1:
                    M1.SetSize(ord, ord, 1);
                    break;
                case 2:
                    M2.SetSize(ord, ord, 1);
                    break;
                case 3:
                    M3.SetSize(ord, ord, 1);
                    break;
                case 4:
                    M4.SetSize(ord, ord, 1);
                    break;
                case 5:
                    M5.SetSize(ord, ord, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedDimensionsQuantity) usePol[N - 1].AllowBoth();
        }
        public void SetLinEq(int ord, int N, bool FixedEquationsQuantity = false, bool FixedValues = false)
        {
            switch (N)
            {
                case 1:
                    M1.SetSize(ord, ord + 1, 1);
                    break;
                case 2:
                    M2.SetSize(ord, ord + 1, 1);
                    break;
                case 3:
                    M3.SetSize(ord, ord + 1, 1);
                    break;
                case 4:
                    M4.SetSize(ord, ord + 1, 1);
                    break;
                case 5:
                    M5.SetSize(ord, ord + 1, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedEquationsQuantity) usePol[N - 1].AllowBoth();
        }
        public void SetAnyMatrix(int N, bool FixedEquationsQuantity = false, bool FixedValues = false)
        {
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedEquationsQuantity)
            {
                usePol[N - 1].AllowLines();
                usePol[N - 1].AllowColumns();
                usePol[N - 1].AllowBoth();
            }
        }
        //
        public void SetMatrixOf3DTransforms(int N)
        {
            Set3DTransform(N);
        }
        public void SetSquareMatrixOfTransforms(int N)
        {
            SetSquare(N, 3);
        }
        //
        public void SetCoordTransformMatrixOfIniCords()
        {
            Set3DVector(1);
        }
        public void SetCoordTransformMatrixOfDistances()
        {
            Set3DVector(3);
        }
        public void SetCoordTransformMatrixOfEulerAngles()
        {
            Set3DVector(5);
        }
        public void SetCoordTransformMatrixOfDirectionalCosines()
        {
            Set3DTransform(2);
        }
        public void SetCoordTransformMatrixOfDirectionalAnglesInDegrees()
        {
            Set3DTransform(5);
        }
        public void SetCoordTransformMatrixOfCalcdCords()
        {
            Set3DVector(4);
        }
        public void SetSystemOfLinearEquationsMatrixOfAllCoefficients(bool FixedEquationsQuantity = false, bool FixedValues = false)
        {
            int N = 1;
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedEquationsQuantity) usePol[N - 1].AllowBoth();
        }
        public void SetSystemOfLinearEquationsMatrixOfAllCoefficients(int ord, bool FixedEquationsQuantity = false, bool FixedValues = false)
        {
            int N = 1;
            if (ord < 1) ord = 1;
            if (ord > MyLib.MaxInt) ord = MyLib.MaxInt;
            switch (N)
            {
                case 1:
                    M1.SetSize(ord, ord + 1, 1);
                    break;
                case 2:
                    M2.SetSize(ord, ord + 1, 1);
                    break;
                case 3:
                    M3.SetSize(ord, ord + 1, 1);
                    break;
                case 4:
                    M4.SetSize(ord, ord + 1, 1);
                    break;
                case 5:
                    M5.SetSize(ord, ord + 1, 1);
                    break;
            }
            usePol[N - 1].ForbidAll();
            if (!FixedValues) usePol[N - 1].AllowEditContents();
            if (!FixedEquationsQuantity) usePol[N - 1].AllowBoth();
        }
        //
        public void SetIniCoordsAsTestExample()
        {
            /*M1 = new Matrix(3, 1);
            M1.SetComponent(40, 1, 1);
            M1.SetComponent(55, 2, 1);
            M1.SetComponent(20, 3, 1);*/
            M1.Set3DVector(40, 55, 20);
            Set3DVector(1);
        }
        public void SetNewCordsAsTestExample()
        {
            M1.Set3DVector(35.94, 7.09, 4.03);
            Set3DVector(1);
        }
        public void SetEulerAnglesAsTestExample()
        {
            M5.Set3DVector(-23.95, -20, 30);
            Set3DVector(1);
        }
        public void SetDirectionalCosinesAsTestExample()
        {
            M2 = new Matrix(3, 3);
            M2.SetComponent(0.814, 1, 1); M2.SetComponent(0.5, 1, 2); M2.SetComponent(0.296, 1, 3);
            M2.SetComponent(-0.291, 2, 1); M2.SetComponent(0.791, 2, 2); M2.SetComponent(-0.538, 2, 3);
            M2.SetComponent(-0.503, 3, 1); M2.SetComponent(0.352, 3, 2); M2.SetComponent(0.789, 3, 3);
            //
            M2.SetComponent(0.814, 1, 1); M2.SetComponent(0.5, 1, 2); M2.SetComponent(-0.296, 1, 3);
            M2.SetComponent(-0.291, 2, 1); M2.SetComponent(0.791, 2, 2); M2.SetComponent(0.538, 2, 3);
            M2.SetComponent(-0.503, 3, 1); M2.SetComponent(0.352, 3, 2); M2.SetComponent(0.789, 3, 3);
            //
            Set3DTransform(2);
        }
        public void SetDirectionalAnglesAsTestExample()
        {
            M5 = new Matrix(3, 3);
            M5.SetComponent(35.53, 1, 1); M5.SetComponent(106.89, 1, 2); M5.SetComponent(120.22, 1, 3);
            M5.SetComponent(60, 2, 1); M5.SetComponent(37.68, 2, 2); M5.SetComponent(69.42, 2, 3);
            M5.SetComponent(72.77, 3, 1); M5.SetComponent(122.53, 3, 2); M5.SetComponent(37.87, 3, 3);
            //
            Set3DTransform(5);
        }
        public void SetDistancesAsTestExample()
        {
            M3 = new Matrix(3, 1);
            M3.SetComponent(14.8, 1, 1);
            M3.SetComponent(30, 2, 1);
            M3.SetComponent(9.99, 3, 1);
        }
        public void SetSystemOfLinearEquationsAsTestExample()
        {
            //later
        }
        public void SetIniCordsFromTable(TTable tbl)
        {
            double[] c = null;
            int QLines, QColumns;
            M1.SetFromTable(tbl);
            M1.SetSize(3, 1, 1);
        }
        public void SetEulerAnglesFromTable(TTable tbl)
        {
            double[] c = null;
            int QLines, QColumns;
            M5.SetFromTable(tbl);
            M5.SetSize(3, 1, 1);
            //
            M2 = this.CalcMatrixOfDirCossByEulersAngles(M5);
        }
        public void SetDirectionalCosinesFromTable(TTable tbl)
        {
            M2.SetFromTable(tbl);
            M2.SetSize(3, 3, 1);
        }
        public void SetDistancesFromTable(TTable tbl)
        {
            M3.SetFromTable(tbl);
            M3.SetSize(3, 3, 1);
        }
        public void SetSystemOfLinearEquationsFromTable(TTable tbl)
        {
            M1.SetFromTable(tbl);
        }
        public Matrix GetEulerAngles()
        {
            M5.SetSize(3, 1, 1);
            return M5;
        }
        public Matrix GetCoordsGiven()
        {
            M1.SetSize(3, 1, 1);
            return M1;
        }
        public Matrix GetMatrixOfDirCossByEulersAngles()
        {
            //M5.SetSize(3, 1, 1);
            M2 = CalcMatrixOfDirCossByEulersAngles(M5);
            return M2;
        }
        public Matrix GetDistances()
        {
            M3.SetSize(3, 1, 1);
            return M3;
        }
        //
        public Matrix GetCoordTransformIniDataMatrixOfIniCoords()
        {
            SetCoordTransformMatrixOfIniCords();
            return M1;
        }
        public TTable GetCoordTransformIniDataTableOfIniCoords()
        {
            SetCoordTransformMatrixOfIniCords();
            ActiveN = 1;
            TTable tbl = null;
            tbl = this.GetAsTable(); //according to ActiveN
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            tbl.SetTableName("M1 = Matrix of Ini Coords");
            return tbl;
        }
        public Matrix GetCoordTransformIniDataMatrixOfDistances()
        {
            SetCoordTransformMatrixOfDistances();
            return M3;
        }
        public TTable GetCoordTransformIniDataTableOfDistances()
        {
            ActiveN = 3;
            SetCoordTransformMatrixOfDistances();
            TTable tbl = null;
            tbl = this.GetAsTable();
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            tbl.SetTableName("M3 = Matrix of Distances");
            return tbl;
        }
        public Matrix GetCoordTransformIniDataMatrixOfEulerAngles()
        {
            SetCoordTransformMatrixOfEulerAngles();
            return M5;
        }
        public TTable GetCoordTransformIniDataTableOfEulerAngles()
        {
            ActiveN = 5;
            SetCoordTransformMatrixOfEulerAngles();
            TTable tbl = null;
            tbl = this.GetAsTable();
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            tbl.SetTableName("M5 = Euler angles");
            return tbl;
        }
        public Matrix GetCoordTransformIniDataMatrixOfDirectionalCosines()
        {
            SetCoordTransformMatrixOfDirectionalCosines();
            return M2;
        }
        public TTable GetCoordTransformIniDataTableOfDirectionalCosines()
        {
            ActiveN = 2;
            SetCoordTransformMatrixOfDirectionalCosines();
            TTable tbl = null;
            tbl = this.GetAsTable();
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            tbl.SetTableName("M2 = Matrix of directional cosines");
            return tbl;
        }
        public Matrix GetCoordTransformResult()
        {
            //SetCoordTransformMatrixOfDirectionalCosines();
            M4.SetSize(3, 1, 1);
            return M4;
        }
        public TTable GetCoordTransformResultTable()
        {
            ActiveN = 4;
            bool FixedVals = true;
            //SetCoordTransformMatrixOfDirectionalCosines();
            Set3DVector(ActiveN, FixedVals);
            TTable tbl = null;
            tbl = this.GetAsTable();
            tbl.SetTableUssagePolicy(usePol[ActiveN - 1]);
            tbl.SetTableName("M4 = Result of Coords Transform");
            return tbl;
        }
        //
        public void CalcCoordsTransformCoordsFromOldCSToNew()
        {
            Matrix M6, M7 = null;
            M1.SetSize(3, 1, 1);
            M3.SetSize(3, 1, 1);
            M2.SetSize(3, 3, 1);
            //M7 = M2.TransposeTo();
            M7 = M2.InverseMatrix();
            M6 = M1 - M3;
            M4 = M7 * M6;
        }
        public void CalcCoordsTransformCoordsFromNewCSToOld()
        {
            Matrix M6 = null;
            M1.SetSize(3, 1, 1);
            M3.SetSize(3, 1, 1);
            M2.SetSize(3, 3, 1);
            M6 = M2 * M1;
            M4 = M6 + M3;
        }
        public void CalcDirCossByDirAnglesDeg()
        {
            double angle, cosine;
            M5.SetSize(3, 3, 1);
            M2.SetSize(3, 3, 0);
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    angle = M5.GetComponent(i, j);
                    cosine = Math.Cos(Math.PI / 180 * angle);
                    M2.SetComponent(cosine, i, j);
                }
            }
        }

    }//cl
}//ns