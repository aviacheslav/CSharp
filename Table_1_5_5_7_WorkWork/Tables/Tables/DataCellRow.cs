using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class DataCellRow
    {
        DataCell[] cell;
        int Q;
        //
        //
        //public DataCellRow()
        //{
       //     Q = 1;
        //    cell = new DataCell[Q];
        //    for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell();
        //}
        public DataCellRow(bool NotEmptyFirst=true)
        {
            if (NotEmptyFirst == false)
            {
                this.cell = null;
            }
            else
            {
                Q = 1;
                cell = new DataCell[Q];
                for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell();
            }
        }
        public DataCellRow(DataCellTypeInfo[] cfg, int Q)
        {
            this.Q = Q;
            this.cell = new DataCell[Q];
            if (cfg != null)
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell(cfg[i - 1].GetTypeN(), cfg[i - 1].GetLength());
                }
            }
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell();
                }
            }
        }
        public DataCellRow(DataTypeRow cfg, int Q)
        {
            this.Q = Q;
            this.cell = new DataCell[Q];
            if (cfg != null)
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell(cfg.GetTypeN(i), cfg.GetLength(i));
                }
            }
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell();
                }
            }
        }
        public DataCellRow(DataCellTypeInfo cfg, int Q)
        {
            if (cfg != null)
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell(cfg.GetTypeN(), cfg.GetLength());
                }
            }
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    this.cell[i - 1] = new DataCell();
                }
            }
            this.Q = Q;
        }
        public DataCellRow(DataCell[] row, int Q)
        {
            this.Q = Q;
            this.cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) {
                this.cell[i - 1] = new DataCell(); this.cell[i - 1] = row[i - 1];
            }
        }
        public DataCellRow(DataCell cell, int Q=1)
        {
            this.Q = Q;
            this.cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) { this.cell[i - 1] = new DataCell(); this.cell[i - 1] = cell; }
        }
        public DataCellRow(int[] types, int[] lengths, int Quantity, TableCellAccessConfiguration cfgExt)
        {
            //in C++ cell=null; Q=0;
            this.Q = Quantity;
            cell = new DataCell[Q];
            SetTypes(types, lengths, cfgExt);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int type, int length, int Quantity, TableCellAccessConfiguration cfgExt)
        {
            //in C++ cell=null; Q=0;
            this.Q = Quantity;
            cell = new DataCell[Q];
            SetSingleType(type, length, Quantity, cfgExt);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(double[] row, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(float[] row, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int[] row, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(bool[] row, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(string[] row, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(string[] row1, string[] row2, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row1, row2, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int[] row1, int[] row2, int Q)
        {
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell = new DataCell[Q];
            SetSingleType(row1, row2, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(double val, int Q=1)
        {
            this.Q = Q;
            cell = new DataCell[Q];
            for(int i=1; i<=Q; i++)cell[i - 1] = new DataCell(val);
        }
        public DataCellRow(float val, int Q = 1)
        {
            this.Q = Q;
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
        }
        public DataCellRow(int val, int Q = 1)
        {
            this.Q = Q;
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
        }
        public DataCellRow(bool val, int Q = 1)
        {
            this.Q = Q;
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
        }
        public DataCellRow(string val, int Q = 1)
        {
            this.Q = Q;
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
        }
        public DataCellRow(string val1, string val2, int Q = 1)
        {
            string[] vals = new string[2];
            vals[1 - 1] = val1;
            vals[2 - 1] = val2;
            this.Q = Q;
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(vals, 2);
        }
        //public DataCellRow(int val1, int val2)
        //{
        //    int[] vals = new int[2];
        //    vals[1 - 1] = val1;
        //    vals[2 - 1] = val2;
        //    Q = 1;
        //    cell = new DataCell[1];
        //    cell[1 - 1] = new DataCell(vals, 2);
        //}
        
        //
        public void Add(DataCell cell)
        {
            //if (this.cell == null)
            //{
            //    this.cell = new DataCell[1];
            //    this.cell[1-1] = new DataCell();
            //    this.cell[1-1].Assign(cell);
            //}
            //else
            //{
                MyLib.AddToVector(ref this.cell, ref this.Q, cell);
            //}
        }
        public void InsertToN(DataCell cell, int N)
        {
            if (N >= 1 && N < MyLib.MaxInt) MyLib.InsToVector(ref this.cell, ref this.Q, cell, N);
        }
        public void DeleteN(int N)
        {
            if (N >= 1 && N < MyLib.MaxInt) MyLib.DelInVector(ref cell, ref this.Q, N);
        }
        public void Add(double val)
        {
            DataCell cell = new DataCell(val);
            Add(cell);
        }
        public void Add(float val)
        {
            DataCell cell = new DataCell(val);
            Add(cell);
        }
        public void Add(int val)
        {
            DataCell cell = new DataCell(val);
            Add(cell);
        }
        public void Add(bool val)
        {
            DataCell cell = new DataCell(val);
            Add(cell);
        }
        public void Add(string val)
        {
            DataCell cell = new DataCell(val);
            Add(cell);
        }
        public void InsertToN(double val, int N)
        {
            DataCell cell = null;
            if (N >= 1 && N < MyLib.MaxInt)
            {
                cell = new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(float val, int N)
        {
            DataCell cell = null;
            if (N >= 1 && N < MyLib.MaxInt)
            {
                cell = new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(int val, int N)
        {
            DataCell cell = null;
            if (N >= 1 && N < MyLib.MaxInt)
            {
                cell = new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(bool val, int N)
        {
            DataCell cell = null;
            if (N >= 1 && N < MyLib.MaxInt)
            {
                cell = new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(string val, int N)
        {
            DataCell cell = null;
            if (N >= 1 && N < MyLib.MaxInt)
            {
                cell = new DataCell(val);
                InsertToN(cell, N);
            }
        }
        //
        public int GetSize() { return Q; }
        public void SetSize(int Q, bool PreserveVals)
        {
            int MinQ = 0;
            DataCell[] newRow = null;
            if (Q > 1 && Q < MyLib.MaxInt && Q != this.Q)
            {
                if (Q <= this.Q) MinQ = Q; else MinQ = this.Q;
                if (PreserveVals)
                {
                    newRow = new DataCell[Q];
                    for (int i = 1; i <= MinQ; i++) newRow[i - 1] = cell[i - 1];
                }
                //in C++ amda mus be del[]cell
                cell = new DataCell[Q];
                if (PreserveVals)
                {
                    for (int i = 1; i <= MinQ; i++) cell[i - 1] = newRow[i - 1];
                    //in C++ amda mus be del[]newRow or better cell=newRow 
                }
            }
        }
        //
        public DataCell GetCellN(int N)
        {
            DataCell acell = null;
            if (N >= 1 && N <= Q) acell = cell[N - 1];
            return acell;
        }
        public double GetDoubleValOfCellN(int N)
        {
            double y = 0;
            if (N > 1 && N < Q)
            {
                y = cell[N - 1].GetDoubleVal();
            }
            return y;
        }
        public float GetFloatValOfCellN(int N)
        {
            float y = 0;
            if (N > 1 && N < Q)
            {
                y = cell[N - 1].GetFloatVal();
            }
            return y;
        }
        public int GetIntValOfCellN(int N)
        {
            int y = 0;
            if (N > 1 && N < Q)
            {
                y = cell[N - 1].GetIntVal();
            }
            return y;
        }
        public bool GetBoolValOfCellN(int N)
        {
            bool y = MyLib.BoolValByDefault;
            if (N > 1 && N < Q)
            {
                y = cell[N - 1].GetBoolVal();
            }
            return y;
        }
        public string CellNToString(int N)
        {
            string y = "";
            if (N > 1 && N < Q)
            {
                y = cell[N - 1].ToString();
            }
            return y;
        }
        //
        public void GetDoubleArrOfCellN(int N, ref double[] arr, ref int Length)
        {
            if (N > 1 && N < Q)
            {
                cell[N - 1].GetDoubleArr(ref arr, ref Length);
            }
        }
        public void GetFloatArrOfCellN(int N, ref float[] arr, ref int Length)
        {
            if (N > 1 && N < Q)
            {
                cell[N - 1].GetFloatArr(ref arr, ref Length);
            }
        }
        public void GetIntArrOfCellN(int N, ref int[] arr, ref int Length)
        {
            if (N > 1 && N < Q)
            {
                cell[N - 1].GetIntArr(ref arr, ref Length);
            }
        }
        public void GetBoolArrOfCellN(int N, ref bool[] arr, ref int Length)
        {
            if (N > 1 && N < Q)
            {
                cell[N - 1].GetBoolArr(ref arr, ref Length);
            }
        }
        public void GetCellNToStringArr(int N, ref string[] arr, ref int Length)
        {
            if (N > 1 && N < Q)
            {
                cell[N - 1].GetStringArr(ref arr, ref Length);
            }
        }
        //
        public void SetTypes(DataCellTypeInfo[] typesInfExt, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableCellAccessConfiguration();
            DataCellTypeInfo[] typesInf = new DataCellTypeInfo[this.Q];
            if (typesInfExt != null) { for (int i = 1; i <= this.Q; i++) typesInf[i - 1] = typesInfExt[1 - 1]; }
            else { for (int i = 1; i <= this.Q; i++) typesInf[i - 1] = new DataCellTypeInfo(); }
            for (int i = 1; i <= this.Q; i++)
            {
                cfgExt.LengthOfArrCellTypes = typesInf[i - 1].GetLength();
                cell[i - 1].SetTypeN(typesInf[i - 1].GetTypeN(), cfgExt);
            }
        }
        public void SetTypes(int[] types, int[] Lengths, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            int TypeN = 0, length = 2;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableCellAccessConfiguration();
            for (int i = 1; i <= Q; i++)
            {
                //public void SetTypeN(int TypeN, TableCellAccessConfiguration cfgExt)
                if (types != null && TableConsts.TypeNIsCorrect(types[i - 1])) TypeN = types[i - 1];
                else
                {
                    TypeN = TableConsts.DefaultAnyCellTypeN;
                }
                if (Lengths != null && Lengths[i - 1] > 0 && Lengths[i - 1] < MyLib.MaxInt) length = Lengths[i - 1];
                else
                {
                    length = 2;
                }
                cfg.LengthOfArrCellTypes = length;
                if (cell[i - 1] == null) cell[i - 1] = new DataCell(types[i - 1], length);
                else cell[i - 1].SetTypeN(types[i - 1], cfg);
            }
        }
        public void SetSingleType(double[] row, int Q)
        {
            double val = 0;
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            if (row != null) for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(row[i - 1]);
            else for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
            this.Q = Q;
        }
        public void SetSingleType(float[] row, int Q)
        {
            double val = 0;
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            if (row != null) for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(row[i - 1]);
            else for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
            this.Q = Q;
        }
        public void SetSingleType(int[] row, int Q)
        {
            double val = 0;
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            if (row != null) for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(row[i - 1]);
            else for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
            this.Q = Q;
        }
        public void SetSingleType(bool[] row, int Q)
        {
            bool val = MyLib.BoolValByDefault;
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            if (row != null) for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(row[i - 1]);
            else for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
            this.Q = Q;
        }
        public void SetSingleType(string[] row, int Q)
        {
            string val = "";
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            if (row != null) for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(row[i - 1]);
            else for (int i = 1; i <= Q; i++) cell[i - 1] = new DataCell(val);
            this.Q = Q;
        }
        public void SetSingleType(string[] row1, string[] row2, int Q)
        {
            double val = 0;
            string[] row = new string[2];
            for (int i = 1; i <= 2; i++) row[i - 1] = "";
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++)
            {
                if (row1 != null) row[1 - 1] = row1[i - 1];
                if (row2 != null) row[2 - 1] = row2[i - 1];
                cell[i - 1] = new DataCell(row, 2);
            }
            this.Q = Q;
        }
        public void SetSingleType(int[] row1, int[] row2, int Q)
        {
            double val = 0;
            int[] row = new int[2];
            for (int i = 1; i <= 2; i++) row[i - 1] = 0;
            //in C++ amda sol be if(!NULL)delete[]
            cell = new DataCell[Q];
            for (int i = 1; i <= Q; i++)
            {
                if (row1 != null) row[1 - 1] = row1[i - 1];
                if (row2 != null) row[2 - 1] = row2[i - 1];
                cell[i - 1] = new DataCell(row, 2);
            }
            this.Q = Q;
        }
        public void SetSingleType(int type, int length, int Q, TableCellAccessConfiguration cfgExt)
        {
            int[] types = new int[Q];
            int[] Lengths = new int[Q];
            //for (int i = 1; i <= Q; i++)
            //{
            //    if(this.cell[i-1])types[i - 1] = type;
            //}
            if (TableConsts.TypeNIsCorrect(type))
            {
                for (int i = 1; i <= Q; i++)
                {
                    types[i - 1] = type;
                }
            }
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    types[i - 1] = TableConsts.DefaultAnyCellTypeN;
                }
            }
            if (length > 0 && length < MyLib.MaxInt)
            {
                for (int i = 1; i <= Q; i++)
                {
                    Lengths[i - 1] = length;
                }
            }
            else
            {
                for (int i = 1; i <= Q; i++)
                {
                    Lengths[i - 1] = 2;
                }
            }
            this.Q = Q;
            SetTypes(types, Lengths, cfgExt);
        }
        public void SetSingleType(DataCellTypeInfo typesInfExt, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableCellAccessConfiguration();
            DataCellTypeInfo[] typesInf = new DataCellTypeInfo[this.Q];
            if (typesInfExt != null) { for (int i = 1; i <= this.Q; i++) typesInf[i - 1] = typesInfExt; }
            else { for (int i = 1; i <= this.Q; i++) typesInf[i - 1] = new DataCellTypeInfo(); }
            SetTypes(typesInf, cfgExt);
        }
        //===========================================================================================================================
        //
        ///---GETTERS--------------------------------------------------------------------------------------------------------------------
        //
        public double GetDoubleVal(int CellN)
        {
            double R=0;
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetDoubleVal();
            return R;
        }
        public float GetFloatVal(int CellN)
        {
            float R=0;
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetFloatVal();
            return R;
        }
        public int GetIntVal(int CellN)
        {
            int R = 0;
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetIntVal();
            return R;
        }
        public bool GetBoolVal(int CellN)
        {
            bool R = MyLib.BoolValByDefault;
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetBoolVal();
            return R;
        }
        public string ToString(int CellN)
        {
            string R="";
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].ToString();
            return R;
        }
        //
        public void GetDoubleArr(ref double[] vals, ref int count, int CellN)
        {
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) cell[CellN-1].GetDoubleArr(ref vals, ref count);
        }
        public void GetFloatArr(ref float[] vals, ref int count, int CellN)
        {
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) cell[CellN-1].GetFloatArr(ref vals, ref count);
        }
        public void GetIntArr(ref int[] vals, ref int count, int CellN)
        {
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) cell[CellN-1].GetIntArr(ref vals, ref count);
        }
        public void GetBoolArr(ref bool[] vals, ref int count, int CellN)
        {
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) cell[CellN-1].GetBoolArr(ref vals, ref count);
        }
        public void ToStringArr(ref string[] vals, ref int count, int CellN)
        {
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) cell[CellN-1].GetStringArr(ref vals, ref count);
        }
        //
        public double GetDoubleValN(int N, int CellN)
        {
            double R=0;
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetDoubleValN(N);
            return R;
        }
        public float GetFloatValN(int N, int CellN)
        {
            float R=0;
            //return cell.GetDoubleVal();
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetFloatValN(N);
            return R;
        }
        public int GetIntValN(int N, int CellN)
        {
            int R=0;
            //return cell.GetDoubleVal();
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetIntValN(N);
            return R;
        }
        public bool GetBoolValN(int N, int CellN)
        {
            bool R=MyLib.BoolValByDefault;
            //return cell.GetDoubleVal();
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].GetBoolValN(N);
            return R;
        }
        public string ToStringN(int N, int CellN)
        {
            string R="";
            //return cell.GetDoubleVal();
            if(CellN>=1 && CellN<=Q && cell[CellN-1]!=null) R=cell[CellN-1].ToStringN(N);
            return R;
        }
        //
        public int GetTypeN(int CellN) {
            int R = 0;
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) R=cell[CellN-1].GetTypeN();
            return R;
        }
        public int GetLength(int CellN)
        {
            int RN = 0;
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) RN = cell[CellN - 1].GetLength();
            return RN;
        }
        public int GetActiveN(int CellN)
        {
            int RN = 0;
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) RN = cell[CellN - 1].GetActiveN();
            return RN;
        }
        //
        public DataTypeRow GetTypeInfo()
        {
            int Q=this.GetSize();
            DataCellTypeInfo[] CellTypes = new DataCellTypeInfo[Q];
            for (int i = 1; i <= Q; i++) CellTypes[i - 1] = new DataCellTypeInfo(this.GetCellN(i).GetTypeN(), this.GetCellN(i).GetLength());
            DataTypeRow TypeRow = new DataTypeRow(Q, CellTypes);
            return TypeRow;
        }
        //
        //---SETTERS--------------------------------------------------------------------------------------------------------------------
        //
        public void SetActiveN(int CellItemN, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetActiveN(CellItemN);
        }
        public void SetLength(int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetLength(Length);
        }
        //
        public void DelValN(int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].DelValN(N);
        }
        //
        public void AddOrInsDoubleVal(double val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AddOrInsDoubleVal(val, N);
        }
        public void AddOrInsFloatVal(float val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AddOrInsFloatVal(val, N);
        }
        public void AddOrInsIntVal(int val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AddOrInsIntVal(val, N);
        }
        public void AddOrInsBoolVal(bool val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AddOrInsBoolVal(val, N);
        }
        public void AddOrInsStringVal(string val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AddOrInsStringVal(val, N);
        }
        //
        public void Assign(double val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val);
        }
        public void Assign(float val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val);
        }
        public void Assign(int val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val);
        }
        public void Assign(bool val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val);
        }
        public void Assign(string val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val);
        }
        public void Assign(double val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, N);
        }
        public void Assign(float val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, N);
        }
        public void Assign(int val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, N);
        }
        public void Assign(bool val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, N);
        }
        public void Assign(string val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, N);
        }
        public void Assign(double[] val, int count, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, count);
        }
        public void Assign(float[] val, int count, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, count);
        }
        public void Assign(int[] val, int count, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, count);
        }
        public void Assign(bool[] val, int count, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, count);
        }
        public void Assign(string[] val, int count, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(val, count);
        }
        public void Assign(TDataCell obj, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(obj);
        }
        public void Assign(DataCell obj, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].Assign(obj);
        }//fn asgn
        //
        public void AssignBy(TDataCell CellFrom, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AssignBy(CellFrom);
        }
        public void AssignBy(DataCell obj, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].AssignBy(obj);
        }
        //
        public void SetTypeN(int TypeN, TableCellAccessConfiguration cfgExt, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetTypeN(TypeN, cfgExt);
        }
        //
        public void SetValAndTypeDouble(double val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeDouble(val);
        }
        public void SetValAndTypeFloat(float val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeFloat(val);
        }
        public void SetValAndTypeInt(int val, int CellN)
        {
           if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeInt(val);
        }
        public void SetValAndTypeBool(bool val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeBool(val);
        }
        public void SetValAndTypeString(string val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeString(val);
        }
        public void SetArrAndTypeDouble(double[] arr, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetArrAndTypeDouble(arr, Length);
        }
        public void SetArrAndTypeFloat(float[] arr, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetArrAndTypeFloat(arr, Length);
        }
        public void SetArrAndTypeInt(int[] arr, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetArrAndTypeInt(arr, Length);
        }
        public void SetArrAndTypeBool(bool[] arr, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetArrAndTypeBool(arr, Length);
        }
        public void SetArrAndTypeString(string[] arr, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetArrAndTypeString(arr, Length);
        }
        public void SetValAndTypeUniqueIntNumKeeper(int val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetValAndTypeUniqueIntNumKeeper(val);
        }
        //
        public void SetByValDouble(double val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValDouble(val);
        }
        public void SetByValFloat(float val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValFloat(val);
        }
        public void SetByValInt(int val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValInt(val);
        }
        public void SetByValBool(bool val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValBool(val);
        }
        public void SetByValString(string val, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValString(val);
        }
        //
        public void SetByValDoubleN(double val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValDoubleN(val, N);
        }
        public void SetByValFloatN(float val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValFloatN(val, N);
        }
        public void SetByValIntN(int val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValIntN(val, N);
        }
        public void SetByValBoolN(bool val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValBoolN(val, N);
        }
        public void SetByValStringN(string val, int N, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByValStringN(val, N);
        }
        //
        public void SetByArrDouble(double[] val, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByArrDouble(val, Length);
        }
        public void SetByArrFloat(float[] val, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByArrFloat(val, Length);
        }
        public void SetByArrInt(int[] val, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByArrInt(val, Length);
        }
        public void SetByArrBool(bool[] val, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByArrBool(val, Length);
        }
        public void SetByArrString(string[] val, int Length, int CellN)
        {
            if (CellN >= 1 && CellN <= Q && cell[CellN - 1] != null) cell[CellN - 1].SetByArrString(val, Length);
        }
		public string[] GetAsStringArray()
        {
            string[] sa = null;
            int Q=this.GetSize();
            if (Q > 0)
            {
                sa=new string[Q];
                for (int i = 1; i <= Q; i++)
                {
                    sa[i - 1] = this.CellNToString(i);
                }
            }
            return sa;
        }
        DataCell SetUniqueForThisRow(DataCell cellProposed, string bef="", string aft="_")
        {
            DataCell cellNew=null;//, cellCur;
            string[] sa1 = null, sa2=null, sa3=null;
            string Name1ini = "", Name2ini = "", Name1or2ini = "", Name1new = "", Name2new = "", Name1or2new="";
            int Q = this.GetSize(), generalTypeN=0, cellProposedTypeN=0;
            if (Q > 0)
            {
                sa1=this.GetAsStringArray_Names1();
                Name1ini=cellProposed.GetName1();
                Name1new=MyLib.CorrectStringValToBeUniqueForStringArray(sa1, Name1ini, bef, aft); 
                sa2=this.GetAsStringArray_Names2();
                Name2ini=cellProposed.GetName2();
                Name2new=MyLib.CorrectStringValToBeUniqueForStringArray(sa2, Name2ini, bef, aft);
                sa3=this.GetAsStringArray();
                Name1or2ini = cellProposed.ToString();
                Name1or2new = MyLib.CorrectStringValToBeUniqueForStringArray(sa2, Name1or2ini, bef, aft);
                //
                generalTypeN=this.GetRowType();
                cellProposedTypeN=cellProposed.GetTypeN();
                switch(generalTypeN){
                    case 0:
                    case TableConsts.BoolArrayTypeN:
                    case TableConsts.BoolTypeN:
                    case TableConsts.DoubleArrayTypeN:
                    case TableConsts.FloatArrayTypeN:
                    case TableConsts.IntArrayTypeN:
                    //case TableConsts.IntItemHeaderDependentTypeN:
                    //case TableConsts.
                        //NOp - ignoring these types
                    break;
                    case TableConsts.StringTypeN:
                        switch(cellProposedTypeN){
                            case TableConsts.BoolArrayTypeN:
                            case TableConsts.BoolTypeN:
                            case TableConsts.DoubleArrayTypeN:
                            case TableConsts.FloatArrayTypeN:
                            case TableConsts.IntArrayTypeN:
                            case TableConsts.IntItemHeaderDependentTypeN:
                            //case TableConsts.
                                //NOp - ignoring these types
                            break;
                            case TableConsts.DoubleTypeN:
                            case TableConsts.FloatTypeN:
                            case TableConsts.IntTypeN:
                                //NOp - ignoring these types
                            break;
                            case TableConsts.StringTypeN://this!
                                if(!(Name1ini.Equals(Name1new))){
                                    cellNew=new DataCell(Name1new);
                                    cellNew.SetValAndTypeString(Name1new);
                                }else{
                                    cellNew=(DataCell)cellProposed.Clone();
                                }
                            break;
                            case TableConsts.DBTableHeaderTypeN:
                                cellNew=(DataCell)cellProposed.Clone();
                                if(!(Name1ini.Equals(Name1new))){
                                    cellNew.SetDBTableNameToDisplay(Name1new);
                                }
                            break;
                            case TableConsts.ColHeaderDBFieldOrItemsTypeN:
                                cellNew=(DataCell)cellProposed.Clone();
                                if(!(Name1ini.Equals(Name1new))){
                                    cellNew.SetDBFieldNameToDisplay(Name1new);
                                }
                            break;
                        }//switch(cellProposedTypeN)
                    break;
                    case TableConsts.StringArrayTypeN:
                        //NOp - ignoring these types
                    break;
                    case TableConsts.DBTableHeaderTypeN:
                        switch(cellProposedTypeN){
                            case TableConsts.BoolArrayTypeN:
                            case TableConsts.BoolTypeN:
                            case TableConsts.DoubleArrayTypeN:
                            case TableConsts.FloatArrayTypeN:
                            case TableConsts.IntArrayTypeN:
                            case TableConsts.IntItemHeaderDependentTypeN:
                            //case TableConsts.
                                //NOp - ignoring these types
                            break;
                            case TableConsts.DoubleTypeN:
                            case TableConsts.FloatTypeN:
                            case TableConsts.IntTypeN:
                                //NOp - ignoring these types
                            break;
                            case TableConsts.StringTypeN:
                                Name1or2new=MyLib.CorrectStringValToBeUniqueForStringArray(sa3, Name1or2ini, bef, aft);
                                if (!(Name1or2ini.Equals(Name1or2new)))
                                {
                                    cellNew = new DataCell(Name1or2new);
                                }else{
                                    cellNew=(DataCell)cellProposed.Clone();
                                }
                            break;
                            case TableConsts.DBTableHeaderTypeN://this!
                                cellNew = (DataCell)cellProposed.Clone();
                                if (!(Name1ini.Equals(Name1new)))
                                {
                                    cellNew.SetDBTableNameToDisplay(Name1new);
                                }
                                if (!(Name2ini.Equals(Name2new)))
                                {
                                    cellNew.SetDBTableNameInDB(Name2new);
                                }
                            break;
                            case TableConsts.ColHeaderDBFieldOrItemsTypeN:
                                cellNew=(DataCell)cellProposed.Clone();
                                if(!(Name1ini.Equals(Name1new))){
                                    cellNew.SetDBFieldNameToDisplay(Name1new);
                                }
                            break;
                        }//switch(cellProposedTypeN)
                    break;
                    case TableConsts.ColHeaderDBFieldOrItemsTypeN:
                        switch(cellProposedTypeN){
                            case TableConsts.BoolArrayTypeN:
                            case TableConsts.BoolTypeN:
                            case TableConsts.DoubleArrayTypeN:
                            case TableConsts.FloatArrayTypeN:
                            case TableConsts.IntArrayTypeN:
                            case TableConsts.IntItemHeaderDependentTypeN:
                            //case TableConsts.
                                //NOp - ignoring these types
                            break;
                            case TableConsts.DoubleTypeN:
                            case TableConsts.FloatTypeN:
                            case TableConsts.IntTypeN:
                                //NOp - ignoring these types
                            break;
                            case TableConsts.StringTypeN:
                                Name1new = MyLib.CorrectStringValToBeUniqueForStringArray(sa3, Name1ini, bef, aft); 
                                if(!(Name1or2ini.Equals(Name1or2new))){
                                    cellNew = new DataCell(Name1or2new);
                                }else{
                                    cellNew=(DataCell)cellProposed.Clone();
                                }
                            break;
                            case TableConsts.DBTableHeaderTypeN://this!
                                cellNew = (DataCell)cellProposed.Clone();
                                if (!(Name1ini.Equals(Name1new)))
                                {
                                    cellNew.SetDBTableNameToDisplay(Name1new);
                                }
                                if (!(Name2ini.Equals(Name2new)))
                                {
                                    cellNew.SetDBTableNameInDB(Name2new);
                                }
                            break;
                            case TableConsts.ColHeaderDBFieldOrItemsTypeN://this!
                                cellNew = (DataCell)cellProposed.Clone();
                                if (!(Name1ini.Equals(Name1new)))
                                {
                                    cellNew.SetDBFieldNameToDisplay(Name1new);
                                }
                                if (!(Name2ini.Equals(Name2new)))
                                {
                                    cellNew.SetDBFieldNameInTable(Name2new);
                                }
                            break;
                        }//switch(cellProposedTypeN)
                    break;
                }
            }
            return cellNew;
        }
        public string[] GetAsStringArray_Names1()
        {
            string[] sa = null;
            int Q = this.GetSize();
            if (Q > 0)
            {
                sa = new string[Q];
                for (int i = 1; i <= Q; i++)
                {
                    sa[i - 1] = this.CellNToString(i);
                }
            }
            return sa;
        }
        public string[] GetAsStringArray_Names2()
        {
            string[] sa = null;
            int Q = this.GetSize();
            if (Q > 0)
            {
                sa = new string[Q];
                for (int i = 1; i <= Q; i++)
                {
                    sa[i - 1] = this.ToStringN(2, i); 
                }
            }
            return sa;
        }
        public string correctNewValToBeUnique(DataCell cell, string bef, string aft)
        {
            string val = cell.ToString();
            string[]arr=this.GetAsStringArray();
            val = MyLib.CorrectStringValToBeUniqueForStringArray(arr, val, bef, aft);
            return val;
        }
        public void GetTypes(ref int Q, ref int[] typeNs, ref int[] lengthes)
        {
            Q = 0;
            typeNs = null;
            lengthes = null;
            if (Q > 0)
            {
                typeNs = new int[Q];
                lengthes = new int[Q];
                for (int i = 1; i <= Q; i++)
                {
                    typeNs[i - 1] = this.GetTypeN(i);
                    lengthes[i - 1] = this.GetLength(i);
                }
            }
        }
        public int GetRowType()
        {
            int generalTypeN=0;
            int minTypeN=0, maxTypeN=0;
            int[] typeNs = null, lengthes=null;
            int Q = this.GetSize();
            if (Q > 0)
            {
                this.GetTypes(ref Q, ref typeNs, ref lengthes);
                for (int i = 1; i <= Q; i++)
                {
                    if(i==1 || (i>1 && typeNs[i-1]<minTypeN)) minTypeN=typeNs[i-1];
                    if (i == 1 || (i > 1 && typeNs[i - 1] > maxTypeN)) maxTypeN = typeNs[i - 1];
                }
                if (minTypeN == maxTypeN)
                {
                    generalTypeN = minTypeN;
                }
            }
            return generalTypeN;
        }
    }//cl
 //===================================================================================================================================
   
 //===================================================================================================================================
    public class DataCellRowCoHeader
    {
        DataCell header;
        DataCellRow content;
		public DataCellRowCoHeader(bool NotEmptyFirst = true, bool WithHeaderFirst = true)
        {
            this.content = new DataCellRow(NotEmptyFirst);
            if (WithHeaderFirst == false)
            {
                this.header = null;
            }
            else
            {
                this.header = new DataCell();
            }
        }
        public DataCellRowCoHeader(DataCell header, DataCellRow content) { this.header = header; this.content = content; }
        //
        public DataCell GetHeader() { return header; }
        public DataCellRow GetContent() { return content; }
        public int GetQContentCells() { return content.GetSize(); }
        public DataCell GetContentCellN(int CellN) { return content.GetCellN(CellN); }
        //
        public void SetHeader(DataCell Hdr) { this.header = Hdr; }
        public void SetContent(DataCellRow Cnt) { this.content = Cnt; }
        /*
        public string GetHeaderName();
        public string GetHeaderName2();
        public string GetHeaderNameN(int N);
        public string GetHeaderNameOfCellN(int CellN);
        public string GetHeaderName2OfCellN(int CellN);
        public string GetHeaderNameNOfCellN(int CellN, int ItemN);
        public void GetStringArrOfHeader(ref string arr, ref int length);
        public void GetStringArrOfContentCellN(ref string arr, ref int length, int CellN);
        public double GetDoubleValOfHeader();
        public double GetDoubleValNOfHeader(int ItemN);
        public double GetDoubleValOfCellN(int CellN);
        public double GetDoubleValNOfCellN(int CellN, int ItemN);
        public void GetDoubleArrOfHeader(ref double arr, ref int length);
        public void GetDoubleArrOfContentCellN(ref double arr, ref int length, int CellN);
        public float GetFloatValOfHeader();
        public float GetFloatValNOfHeader(int ItemN);
        public float GetFloatValOfCellN(int CellN);
        public float GetFloatValNOfCellN(int CellN, int ItemN);
        public void GetFloatArrOfHeader(ref float arr, ref int length);
        public void GetFloatArrOfContentCellN(ref float arr, ref int length, int CellN);
        public int GetIntValOfHeader();
        public int GetIntValNOfHeader(int ItemN);
        public int GetIntValOfCellN(int CellN);
        public int GetIntValNOfCellN(int CellN, int ItemN);
        public void GetIntArrOfHeader(ref int arr, ref int length);
        public void GetIntArrOfContentCellN(ref int arr, ref int length, int CellN);
        public bool GetBoolValOfHeader();
        public bool GetBoolValNOfHeader(int ItemN);
        public bool GetBoolValOfCellN(int CellN);
        public bool GetBoolValNOfCellN(int CellN, int ItemN);
        public void GetBoolArrOfHeader(ref bool arr, ref int length);
        public void GetBoolArrOfContentCellN(ref bool arr, ref int length, int CellN);
       */
	   public void Add(DataCell cell)
        {
            //MyLib.AddToVector(ref this.cell, ref this.Q, cell);
            this.content.Add(cell);
        }
        public void InsertToN(DataCell cell, int N)
        {
            //if (N >= 1 && N < MyLib.MaxInt) MyLib.InsToVector(ref this.cell, ref this.Q, cell, N);
            this.content.InsertToN(cell, N);
        }
        public void DeleteN(int N)
        {
            //if (N >= 1 && N < MyLib.MaxInt) MyLib.DelInVector(ref cell, ref this.Q, N);
            this.content.DeleteN(N);
        }
        public void Add(double val)
        {
            //DataCell cell = new DataCell(val);
            //Add(cell);
            this.content.Add(val);
        }
        public void Add(float val)
        {
            //DataCell cell = new DataCell(val);
            //Add(cell);
            this.content.Add(val);
        }
        public void Add(int val)
        {
            //DataCell cell = new DataCell(val);
            //Add(cell);
            this.content.Add(val);
        }
        public void Add(bool val)
        {
            //DataCell cell = new DataCell(val);
            //Add(cell);
            this.content.Add(val);
        }
        public void Add(string val)
        {
            //DataCell cell = new DataCell(val);
            //Add(cell);
            this.content.Add(val);
        }
        public void InsertToN(double val, int N)
        {
            //DataCell cell = null;
            //if (N >= 1 && N < MyLib.MaxInt)
            //{
            //    cell = new DataCell(val);
            //    InsertToN(cell, N);
            //}
            this.content.InsertToN(val, N);
        }
        public void InsertToN(float val, int N)
        {
            //DataCell cell = null;
            //if (N >= 1 && N < MyLib.MaxInt)
            //{
            //    cell = new DataCell(val);
            //    InsertToN(cell, N);
            //}
            this.content.InsertToN(val, N);
        }
        public void InsertToN(int val, int N)
        {
            //DataCell cell = null;
            //if (N >= 1 && N < MyLib.MaxInt)
            //{
            //    cell = new DataCell(val);
            //    InsertToN(cell, N);
            //}
            this.content.InsertToN(val, N);
        }
        public void InsertToN(bool val, int N)
        {
            //DataCell cell = null;
            //if (N >= 1 && N < MyLib.MaxInt)
           // {
            //    cell = new DataCell(val);
            //    InsertToN(cell, N);
            //}
            this.content.InsertToN(val, N);
        }
        public void InsertToN(string val, int N)
        {
            //DataCell cell = null;
            //if (N >= 1 && N < MyLib.MaxInt)
            //{
            //    cell = new DataCell(val);
            //    InsertToN(cell, N);
            //}
            this.content.InsertToN(val, N);
        }
        //
        public int GetSize() {//
            //return Q; 
            return this.content.GetSize();
        }
        public void SetSize(int Q, bool PreserveVals)
        {
            //int MinQ = 0;
            //DataCell[] newRow = null;
            //if (Q > 1 && Q < MyLib.MaxInt && Q != this.Q)
           // {
           //     if (Q <= this.Q) MinQ = Q; else MinQ = this.Q;
            //    if (PreserveVals)
            //    {
            //        newRow = new DataCell[Q];
            //        for (int i = 1; i <= MinQ; i++) newRow[i - 1] = cell[i - 1];
            //    }
             //   //in C++ amda mus be del[]cell
             //   cell = new DataCell[Q];
            //    if (PreserveVals)
            //    {
            //        for (int i = 1; i <= MinQ; i++) cell[i - 1] = newRow[i - 1];
            //        //in C++ amda mus be del[]newRow or better cell=newRow 
           //     }
            //}
            this.content.SetSize(Q, PreserveVals);
        }
        public string[] GetAsStringArray()
        {
            return this.content.GetAsStringArray();
        }
        public string correctNewValToBeUnique(DataCell cell, string bef, string aft)
        {
            return this.content.correctNewValToBeUnique(cell, bef, aft);
        }
    }//cl
}//ns
