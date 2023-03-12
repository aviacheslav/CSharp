using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;//for  DataGridView
//
//
//mark1- 1475
//mark2- 2834
//mark3 - 4395
//mark4 - 5586
//mark5 - 6195
//mark6 - 7100
//mark7 - 8444
//mark8 - 9404
//fin - 10219
//
namespace Tables
{
    public abstract class TDataCell : ICloneable
    {
        public virtual void construct(int n = 1) { }
        //
        public abstract int GetTypeN();
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
        //public abstract string GetNameN(int N);//for db1
        //
        public abstract void SetByValDouble(double val);
        public abstract void SetByValFloat(float val);
        public abstract void SetByValInt(int val);
        public abstract void SetByValBool(bool val);
        public abstract void SetByValString(string val);
        //
        //public abstract void SetByValStringName(string val);//for db2
        //
        public abstract void SetByValDoubleN(double val, int N);
        public abstract void SetByValFloatN(float val, int N);
        public abstract void SetByValIntN(int val, int N);
        public abstract void SetByValBoolN(bool val, int N);
        public abstract void SetByValStringN(string val, int N);
        //
        //public abstract void SetByValStringNameN(string val, int N);//for db3
        //
        public abstract void SetVal(double val);
        public abstract void SetVal(int val);
        public abstract void SetVal(bool val);
        public abstract void SetVal(string val);
        //
        //public abstract void SetValToName(string val);//for db4
        //
        public abstract void SetValN(double val, int N);
        public abstract void SetValN(int val, int N);
        public abstract void SetValN(bool val, int N);
        public abstract void SetValN(string val, int N);
        //
        //public abstract void SetValToNameN(string val, int N);//for db5
        //
        public abstract void SetByArrDouble(double[] val, int Q);
        public abstract void SetByArrFloat(float[] val, int Q);
        public abstract void SetByArrInt(int[] val, int Q);
        public abstract void SetByArrBool(bool[] val, int Q);
        public abstract void SetByArrString(string[] val, int Q);
        //
        //public abstract void SetByArrStringToNames(string[] val, int Q);//for db6
        //
        public abstract void SetByArr(double[] val, int Q);
        public abstract void SetByArr(int[] val, int Q);
        public abstract void SetByArr(bool[] val, int Q);
        public abstract void SetByArr(string[] val, int Q);
        //
        //public abstract void SetByArrToNames(string[] val, int Q);//for db6
        //
        public abstract void AddOrInsDoubleVal(double val, int N);
        public abstract void AddOrInsFloatVal(float val, int N);
        public abstract void AddOrInsIntVal(int val, int N);
        public abstract void AddOrInsBoolVal(bool val, int N);
        public abstract void AddOrInsStringVal(string val, int N);
        //
        //public abstract void AddOrInsStringValToNames(string[] val, int Q);//for db7
        //
        //
        public abstract void GetDoubleArr(ref double[] Arr, ref int QItems);
        public abstract void GetFloatArr(ref float[] Arr, ref int QItems);
        public abstract void GetIntArr(ref int[] Arr, ref int QItems);
        public abstract void GetBoolArr(ref bool[] Arr, ref int QItems);
        public abstract void GetStringArr(ref string[] Arr, ref int QItems);
        //
        public abstract void DelValN(int N);
        //
        //
        public abstract void SetNameN(string name, int N);
        public abstract void SetName1(string name);
        public abstract void SetName2(string name);
        //public abstract void SetName3(string name);
        public abstract void SetNames(string[] Arr, int Q);
        public abstract string GetNameN(int N);
        public abstract string GetName1();
        public abstract string GetName2();
        //public abstract string GetName3();
        public abstract void GetNames(ref string[] Arr, ref int QItems);
        public abstract int GetLengthOfNamesList();
        //
        public abstract void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true);
        public abstract void SetFromStringArray(string[] Arr, int QItems=0, int FromN=1);
        //
        public abstract void GetItems(ref string[] Arr, ref int QItems);
        //public abstract void SetItems(string[] Arr, int QItems);
        //
        //public abstract void SetItemN(string name, int N);
        //public abstract void SetItems(string[] Arr, int Q);
        //public abstract string GetItemN(int N);
        //public abstract void GetItems(ref string[] Arr, ref int QItems);
        //public abstract int GetLengthOfItemsList();
        //public abstract int GetTypeOfItemsList();
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
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public abstract string GetDBTableNameToDisplay();
        public abstract void SetDBTableNameToDisplay(string name);
        //2 Тип БД BType
        public abstract int GetDBTypeN();
        public abstract void SetDBTypeN(int TypeN);
        public abstract string GetDBConnectionString();
        //public abstract void SetDBConnectionString(string ConnStr);
        //3 Путь к БД DBFileFullName
        public abstract string GetDBFileFullName();
        public abstract void SetDBFileFullName(string name);
        //4 Имя БД в списке СУБД DBNameInSDBC
        public abstract string GetDBNameInSDBC();
        public abstract void SetDBNameInSDBC(string name);
        //5 Имя таблицы в БД
        public abstract string GetDBTableNameInDB();
        public abstract void SetDBTableNameInDB(string name);
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public abstract string GetDBFieldNameToDisplay();
        public abstract void SetDBFieldNameToDisplay(string name);
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public abstract string GetDBFieldNameInTable();
        public abstract void SetDBFieldNameInTable(string name);
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public abstract string GetItemsDBTableNameInDB();
        public abstract void SetItemsDBTableNameInDB(string name);
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public abstract string GetItemsDBTablePrimaryKeyFieldName();
        public abstract void SetItemsDBTablePrimaryKeyFieldName(string name);
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public abstract string GetItemsDBTableItemsFieldName();
        public abstract void SetItemsDBTableItemsFieldName(string name);
        //6 Тип данных поля DB Field data type
        public abstract int GetDBFieldTypeN();
        public abstract void SetDBFieldTypeN(int TypeN);
        public abstract string GetDBFieldTypeName();
        public abstract void SetDBFieldTypeName(string name);
        //7 Длина поля Field Length (not the same as Array length)
        public abstract int GetDBFieldLength();
        public abstract void SetDBFieldLength(int L);
        //8 Длина списка пунктов и прочее
        public abstract int GetItemsQuantity();
        public abstract void SetItems(string [] items, int Q);
        //public abstract void SetItems(DataCell [] ItemsCells, int Q);
        //public abstract SetItemN(string item, int N);
        //public abstract InsItemN(string item, int N);
        //public abstract AddItem(string item);
        //public abstract DelItemN(int N);
        //public abstract int GetNamesQuantity();
        //public abstract void SetNames(string [] items, int Q);
        //public abstract void SetNames(DataCell [] NamesCells, int Q);
        //public abstract SetNameN(string item, int N);
        //public abstract InsNameN(string item, int N);
        //public abstract AddName(string item);
        //public abstract DelNameN(int N);
        //9 Характеристики поля булевы одним числом
        public abstract int GetDBFieldCharacteristicsNumber();//!
        public abstract void SetDBFieldCharacteristicsNumber(int number);//!
        public abstract bool IsKeyField();
        public abstract void SetIfKeyField(bool KeyField);
        public abstract void SetKeyField();
        public abstract void SetNotKeyField();
        public abstract bool IsCounter();
        public abstract  void SetIfCounter(bool isCounter);
        public abstract void SetCounter();
        public abstract void SetNotCounter();
        public abstract bool IsAutoIncrement();
        public abstract void SetIfAutoIncrement(bool isAutoIncrement);
        public abstract void SetAutoIncrement();
        public abstract void SetNotAutoIncrement();
        public abstract bool IsNotNull();
        public abstract void SetIfNotNull(bool isNotNull);
        public abstract void SetNotNull();
        public abstract void SetNotNotNull();
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public abstract void SetDBTableHeaderData(TDBTableHeaderData data);
        public abstract TDBTableHeaderData GetDBTableHeaderData();
        public abstract void SetDBTableCreationData(TDBTableCreationData data);
        public abstract TDBTableCreationData GetDBTableCreationData();
        public abstract void SetDBFieldHeaderData(TDBFieldHeaderData data);
        public abstract TDBFieldHeaderData GetDBFieldHeaderData();
        public abstract void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data);
        public abstract TDBFieldHeaderCreationData GetDBFieldHeaderCreationData();
        public abstract void SetDBItemsTableData(TDBItemsTableData data);
        public abstract TDBItemsTableData GetDBItemsTableData();
        //
        public string GetCellCharacteristicString(bool WriteSupplInfo)
        {
            string s;
            if (WriteSupplInfo)
            {
                s = "Cell Type N:" + (this.GetTypeN()).ToString() + " Length: " + (this.GetLength()).ToString() + " Active N: " + (this.GetActiveN()).ToString();
            }
            else
            {
                s = (this.GetTypeN()).ToString() + ";" + (this.GetLength()).ToString() + ";" + (this.GetActiveN()).ToString();
            }
            return s;
        }
        public void ParseCharacteristicString(string data, ref int TypeN, ref int Length, ref int ActiveN)
        {
            string s;
            string[]delims = { " ", ";", "," };
            string[] names = { "CellTypeN:", "Length:", "ActiveN:" };
            s = MyLib.DelAllSubstrings(data, delims);
            //int N1 = MyLib.FirstSubstringPosN(s, names[1 - 1]), N2 = MyLib.FirstSubstringPosN(s, names[2 - 1]), N3= MyLib.FirstSubstringPosN(s, names[3 - 1]);
            int Name1Start = MyLib.FirstSubstringPosN(s, names[1 - 1]), Name2Start = MyLib.FirstSubstringPosN(s, names[2 - 1]), Name3Start = MyLib.FirstSubstringPosN(s, names[3 - 1]);
            int Name1Fin = Name1Start + names[1 - 1].Length - 1, Name2Fin = Name1Start + names[2 - 1].Length - 1, Name3Fin = Name3Start + names[3 - 1].Length - 1;
            int Val1Start = Name1Fin + 1, Val2Start = Name2Fin + 1, Val3Start = Name3Fin+1;
            int Val1Fin = Name2Start - 1, Val2Fin = Name3Fin - 1, Val3Fin = s.Length;
            int Val1L = Val1Fin - Val1Start + 1, Val2L = Val2Fin - Val2Start + 1, Val3L = Val3Fin - Val3Start + 1;
            string val1S = s.Substring(Val1Start - 1, Val1L), val2S = s.Substring(Val2Start - 1, Val2L), val3S = s.Substring(Val3Start - 1, Val3L);
            int val1 = Convert.ToInt32(val1S), val2 = Convert.ToInt32(val2S), val3 = Convert.ToInt32(val3S);
            TypeN = val1;
            Length = val2;
            ActiveN = val3;
        }
        //
        public abstract object Clone();
        //
        //public bool HeaderIsEqualTo(DataCell CellToCompar, int EqualIfFirstName1AllNames2TypeAndLength3 = 2)
        //{
        //    bool b = true, names1, names2, names3, TypeAndLength;
        //    names1 = ((this.GetName1()).Equals(CellToCompar.GetName1()));
        //    names2 = ((this.GetName2()).Equals(CellToCompar.GetName2()));
        //    names3 = ((this.GetName3()).Equals(CellToCompar.GetName2()));
        //    TypeAndLength = (this.GetTypeN() == CellToCompar.GetTypeN() && this.GetLength() == CellToCompar.GetLength());
        //    switch (EqualIfFirstName1AllNames2TypeAndLength3)
        //    {
        //        case 1:
        //            b = names1;
        //            break;
        //        case 2:
        //            b = names1 && names2 && names3;
        //            break;
        //        case 3:
        //            b = TypeAndLength;
        //            break;
        //    }
        //    return b;
        //}
    }//cl
    //
    
    //
    public class TCellDBTableHeader : TDataCell
    {
        public string TableNameToDisplay;
        public TDBTableHeaderData DBTableHeaderData;
        //public string TableNameInDB;
        //public string DBNameInDBCS;
        //public string DBTypeName;
        //public int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5;
        //public string DBFileFullName;
        //
        public TCellDBTableHeader(){ construct(); }
        //
        public virtual void construct(int n = 1) {
            this.TableNameToDisplay="";
            this.DBTableHeaderData = new TDBTableHeaderData();
            this.DBTableHeaderData.DBTableNameInDB = "";
            this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
            this.DBTableHeaderData.DataSuppl.DBNameInDBCS="";
            this.DBTableHeaderData.DataSuppl.DBTypeName="";
            this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5=0;
            //this.DBTableHeaderData.DataSuppl.DBTypeN=0;
            this.DBTableHeaderData.DataSuppl.DBFileFullName="";
        }
        //public  void ToStringArray1(ref string[] Arr, ref int QItems, bool WriteInfo=true)
        //{
        //    //int ContentN, BusyN, CurN;
        //    Arr = new string[3];
        //    Arr[1 - 1] = "Cell Type:";
        //    Arr[2 - 1] = TableConsts.DBTableHeaderTypeN.ToString();
        //    //ContentN = 0;
        //    //BusyN = 2;
        //    //ContentN++;
        //    //CurN = BusyN + ContentN;
        //    Arr[3 - 1] = "Table Name To Display";
        //    //CurN = CurN + 1;
        //    Arr[4 - 1] = this.TableNameToDisplay;
        //    Arr[5 - 1] = "DBTableHeaderData exists:";
        //    if (this.DBTableHeaderData == null)
        //    {
        //        Arr[6 - 1] = "0";
        //    }
        //    else
        //    {
        //        Arr[6 - 1] = "1";
        //        Arr[7 - 1] = "DBTableHeaderData content:";
        //        Arr[8 - 1] = "DB Table Name in DB:";
        //        Arr[9 - 1] = this.DBTableHeaderData.DBTableNameInDB;
        //        Arr[10 - 1] = "DB Table Supplementary data exist:";
        //        if (this.DBTableHeaderData.DataSuppl == null)
        //        {
        //            Arr[11 - 1] = "0";
        //        }
        //        else
        //        {
        //            Arr[11 - 1] = "1";
        //            Arr[12 - 1] = "DB Table Supplementary data content:";
        //            Arr[13 - 1] = "DB Name In DBCS:";
        //            Arr[14 - 1] = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
        //            Arr[15 - 1] = "DBTypeName:";
        //            Arr[16 - 1] = this.DBTableHeaderData.DataSuppl.DBTypeName;
        //            Arr[17 - 1] = "DBTypeN (SQLite: 1; MySql: 2; MsSqlSrv: 3; MSAccess2003: 4; MSAccess2007: 5):";
        //            Arr[18 - 1] = this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5.ToString();
        //            Arr[19 - 1] = "DB File Full Name:";
        //            Arr[20 - 1] = this.DBTableHeaderData.DataSuppl.DBFileFullName;
        //        }
        //        QItems = 20;
        //    }
        //}//fn
        //public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        //{
        //    string cur;
        //    Arr = null;
        //    QItems = 0;
        //    //
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = cur + "Cell Type:";
        //    }
        //    cur = cur + TableConsts.DBTableHeaderTypeN.ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = cur + "Length:";
        //    }
        //    cur = cur + this.GetLength().ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = cur + "ActiveN:";
        //    }
        //    cur = cur + this.GetActiveN().ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = cur + "Table Name To Display:";
        //    }
        //    cur = cur + this.TableNameToDisplay;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //
        //    if(this.DBTableHeaderData!=null)
        //    {
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Table Name in DB:";
        //        }
        //        cur = cur + this.DBTableHeaderData.DBTableNameInDB;
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    }else if(WriteWholeInfo){
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Table Name In DB:";
        //        }
        //        cur = cur + "";
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    }
        //    //
        //    if (this.DBTableHeaderData!=null && this.DBTableHeaderData.DataSuppl != null)
        //    {
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Name In DBCS:";
        //        }
        //        cur = cur + this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Type Name:";
        //        }
        //        cur = cur + this.DBTableHeaderData.DataSuppl.DBTypeName;
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Type N:";
        //        }
        //        cur = cur + (this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5).ToString();
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB File Full Name:";
        //        }
        //        cur = cur + this.DBTableHeaderData.DataSuppl.DBFileFullName;
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    }
        //    else if(WriteWholeInfo)
        //    {// if (WriteWholeInfo)
        //        //CreoData==null, ma all other ms' write
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Name In DBCS:";
        //        }
        //        cur = cur + "";
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Type Name:";
        //        }
        //        cur = cur + "";
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB Type N:";
        //        }
        //        cur = cur + "";
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = cur + "DB File Full Name:";
        //        }
        //        cur = cur + "";
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        //
        //    }
        //}//fn
        //public override void SetFromStringArray(string[] Arr, int QItems)
        //{
        //    string s1, s2, s3;
        //    string[]delims={" ", ",", ";"};
        //    int TypeN, Length, ActiveN;
        //    //
        //    if (Arr == null)
        //    {
        //        this.TableNameToDisplay = "";
        //        if (QItems >= 5)
        //        {
        //            this.DBTableHeaderData = new TDBTableHeaderData();
        //            this.DBTableHeaderData.DBTableNameInDB = "";
        //            if (QItems >= 6)
        //            {
        //                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
        //                this.DBTableHeaderData.DataSuppl.DBNameInDBCS = "";
        //                this.DBTableHeaderData.DataSuppl.DBTypeName = "";
        //                this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0;
        //                this.DBTableHeaderData.DataSuppl.DBFileFullName = "";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //(Arr != null)
        //        if (QItems >= 1)
        //        {
        //            s1 = Arr[1 - 1];
        //            s2 = MyLib.DelAllSubstrings(s1, delims);
        //            s3 = MyLib.DelAllSubstringSamples(s2, "CellType:");
        //            TypeN = Convert.ToInt32(s3);
        //            if (QItems >= 2)
        //            {
        //                s1 = Arr[2 - 1];
        //                s2 = MyLib.DelAllSubstrings(s1, delims);
        //                s3 = MyLib.DelAllSubstringSamples(s2, "Length:");
        //                Length = Convert.ToInt32(s3);
        //                if (QItems >= 3)
        //                {
        //                    s1 = Arr[3 - 1];
        //                    s2 = MyLib.DelAllSubstrings(s1, delims);
        //                    s3 = MyLib.DelAllSubstringSamples(s2, "ActiveN:");
        //                    ActiveN = Convert.ToInt32(s3);
        //                    if (QItems >= 4)
        //                    {
        //                        s1 = Arr[4 - 1];
        //                        s2 = MyLib.DelAllSubstrings(s1, delims);
        //                        s3 = MyLib.DelAllSubstringSamples(s2, "TableNameToDisplay:");
        //                        this.TableNameToDisplay = s3;
        //                        if (QItems >= 5)
        //                        {
        //                            s1 = Arr[5 - 1];
        //                            s2 = MyLib.DelAllSubstrings(s1, delims);
        //                            s3 = MyLib.DelAllSubstringSamples(s2, "DBTableNameInDB:");
        //                            this.DBTableHeaderData = new TDBTableHeaderData();
        //                            this.DBTableHeaderData.DBTableNameInDB = s3;
        //                            if (QItems >= 6)
        //                            {
        //                                s1 = Arr[6 - 1];
        //                                s2 = MyLib.DelAllSubstrings(s1, delims);
        //                                s3 = MyLib.DelAllSubstringSamples(s2, "DBNameInDBCS:");
        //                                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
        //                                this.DBTableHeaderData.DataSuppl.DBNameInDBCS = s3;
        //                                if (QItems >= 7)
        //                                {
        //                                    s1 = Arr[7 - 1];
        //                                    s2 = MyLib.DelAllSubstrings(s1, delims);
        //                                    s3 = MyLib.DelAllSubstringSamples(s2, "DBTypeName:");
        //                                    this.DBTableHeaderData.DataSuppl.DBTypeName = s3;
        //                                    if (QItems >= 8)
        //                                    {
        //                                        s1 = Arr[8 - 1];
        //                                        s2 = MyLib.DelAllSubstrings(s1, delims);
        //                                        s3 = MyLib.DelAllSubstringSamples(s2, "DBTypeN:");
        //                                        this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = Convert.ToInt32(s3);
        //                                        if (QItems >= 9)
        //                                        {
        //                                            s1 = Arr[9 - 1];
        //                                            s2 = MyLib.DelAllSubstrings(s1, delims);
        //                                            s3 = MyLib.DelAllSubstringSamples(s2, "DBFileFullName:");
        //                                            this.DBTableHeaderData.DataSuppl.DBFileFullName = s3;
        //                                        }
        //                                        else if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
        //                                        {
        //                                            this.DBTableHeaderData.DataSuppl.DBFileFullName = "";
        //                                        }
        //                                    }
        //                                    else if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
        //                                    {
        //                                        this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0;
        //                                    }
        //                                }
        //                                else if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl.DBTypeName != null)
        //                                {
        //                                    this.DBTableHeaderData.DataSuppl.DBTypeName = "";
        //                                }
        //                            }
        //                            else if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl.DBTypeName != null)
        //                            {
        //                                this.DBTableHeaderData.DataSuppl.DBNameInDBCS = "";
        //                            }
        //                        }
        //                        else if (this.DBTableHeaderData != null)
        //                        {
        //                            this.DBTableHeaderData.DBTableNameInDB = "";
        //                        }
        //                    }
        //                    else this.TableNameToDisplay = "";
        //                }//params of cell general
        //            }//params of cell general
        //        }//if QItems>0
        //    }
            
        //}//fn
        //public  void SetFromStringArray1(string[] Arr, int QItems = 0)
        //{
        //    //this.SetType//type is known
        //    int ArrLen=Arr.Length, LastN=0, CurN;
        //    if (Arr != null)
        //    {
        //        if(ArrLen>=4){
        //            this.TableNameToDisplay=Arr[4-1];
        //            LastN = 4;
        //            if (ArrLen >= 6)
        //            {
        //                if(Arr[6-1].Equals("1")){
        //                    this.DBTableHeaderData = new TDBTableHeaderData();
        //                    LastN = 6;
        //                    if (ArrLen >= 9)
        //                    {
        //                        this.DBTableHeaderData.DBTableNameInDB = Arr[9 - 1];
        //                        LastN = 9;
        //                        if (ArrLen >= 11)
        //                        {
        //                            if (Arr[11 - 1].Equals("1"))
        //                            {
        //                                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
        //                                LastN = 11;
        //                                if (ArrLen >= 14)
        //                                {
        //                                    this.DBTableHeaderData.DataSuppl.DBNameInDBCS=Arr[14-1];
        //                                    LastN = 14;
        //                                    if (ArrLen >= 16)
        //                                    {
        //                                        this.DBTableHeaderData.DataSuppl.DBTypeName=Arr[16-1];
        //                                        LastN = 16;
        //                                        if (ArrLen >= 18)
        //                                        {
        //                                            this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5=Convert.ToInt32(Arr[18-1]);
        //                                            LastN = 18;
        //                                            if (ArrLen >= 20)
        //                                            {
        //                                                this.DBTableHeaderData.DataSuppl.DBFileFullName = Arr[20 - 1];
        //                                                LastN = 18;

        //                                            }
        //                                            else LastN = Arr.Length;
        //                                        }
        //                                        else LastN = Arr.Length;
        //                                    }
        //                                    else LastN = Arr.Length;
        //                                }
        //                                else LastN = Arr.Length;
        //                            }
        //                            else LastN = Arr.Length;
        //                        }
        //                        else LastN = Arr.Length;//zB, 10
        //                    }//if Arr>9, HdrData
        //                }
        //            }
        //        }
        //    }
        //}//fn
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            string[]sarr = null;
            int QItemsContent=0;
            Arr = null;
            QItems=0;
            string cur;
            //
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + "TableNameToDisplay:";
                cur = cur + " ";
            }
            cur = cur + this.TableNameToDisplay;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //
            if ((this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null) || WriteWholeInfo)
            {
                if (WriteWholeInfo && this.DBTableHeaderData == null)
                {
                    this.DBTableHeaderData = new TDBTableHeaderData();
                }
                this.DBTableHeaderData.ToStringArray(ref sarr, ref QItemsContent, WriteSupplInfo, WriteWholeInfo);
                for (int i = 1; i <= QItemsContent; i++)
                {
                    cur = sarr[i - 1];
                    MyLib.AddToVector(ref Arr, ref QItems, cur);
                }
            }
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN = 1)
        {
            //throw new NotImplementedException();
            string[]delims={" ", ",", ";"};
            string s1, s2, s3, name="TableNameToDisplay: ";
            if (Arr != null)
            {
                if (QItems > 0)
                {
                    s1 = Arr[FromN - 1];
                    s2 = s1;// MyLib.DelAllSubstrings(s1, delims);
                    if (s2.Length > name.Length && (s2.Substring(1 - 1, name.Length).Equals(name)))
                    {
                        s3 = s2.Substring(name.Length + 1 - 1, (s2.Length - name.Length));
                    }
                    else
                    {
                        s3 = s2;
                    }
                    this.TableNameToDisplay = s3;
                    if (QItems > 1)
                    {
                        if (this.DBTableHeaderData == null)
                        {
                            this.DBTableHeaderData = new TDBTableHeaderData();
                        }
                        this.DBTableHeaderData.SetFromStringArray(Arr, QItems, 2);
                    }
                }//if QItems>0
            }//Arr!=null
        }//fn
        public override void SetItems(string[] Arr, int QItems)
        {
            this.SetNames(Arr, QItems);
            //throw new NotImplementedException();
        }
        public override void GetItems(ref string[] Arr, ref int QItems)
        {
            //throw new NotImplementedException();
            this.GetNames(ref Arr, ref QItems);
        }
        //
        public override int GetTypeN() {
            //return TableConsts.DBTableHeaderTypeN;
            int TypeN = TableConsts.DBTableHeaderTypeN;
            if (this.DBTableHeaderData == null)
            {
                TypeN = TableConsts.DBTableHeader_TableHeaderOnly_TypeN;
            }
            else
            {
                if (this.DBTableHeaderData.DataSuppl == null)
                {
                    TypeN = TableConsts.DBTableHeader_HeadersBothForDemoAndDB_TypeN;
                }
                else
                {
                    TypeN = TableConsts.DBTableHeader_DBFullInf_TypeN;
                }
            }
            return TypeN;
        }//{ return TableConsts.DBFieldHeaderTypeN; }
        public override int GetActiveN() { return 0; }
        public override  void SetActiveN(int N) { }
        public override int GetLength() {
            //return 0;
            int L = 0;
            if (this.DBTableHeaderData == null)
            {
                L=1;
            }
            else
            {
                if (this.DBTableHeaderData.DataSuppl == null)
                {
                    L=2;
                }
                else
                {
                    L=6;
                }
            }
            return L;
        }//{ return this.QItems; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal() { return 0; }
        public override float GetFloatVal() { return 0; }
        public override int GetIntVal() { return 0; }
        public override bool GetBoolVal() { return MyLib.BoolValByDefault; }
        public override  string ToString() { return this.TableNameToDisplay; }
        //
        public override  double GetDoubleValN(int N) { return 0; }
        public override float GetFloatValN(int N) { return 0; }
        public override int GetIntValN(int N) { return 0; }
        public override bool GetBoolValN(int N) { return MyLib.BoolValByDefault; }
        public override string ToStringN(int N)
        {
            string s = "";
            switch (N)
            {
                case 1:
                    s = this.TableNameToDisplay;
                break;
                case 2:
                    if (this.DBTableHeaderData != null)
                    {
                        s = this.DBTableHeaderData.DBTableNameInDB;
                    }
                break;
                case 3:
                if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
                    {
                        s = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
                    }
                break;
                case 4:
                    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
                    {
                        s = this.DBTableHeaderData.DataSuppl.DBTypeName;
                    }
                break;
                case 5:
                    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
                    {
                        s = this.DBTableHeaderData.DataSuppl.DBFileFullName;
                    }
                break;
            }
            return s;
        }
        //
        //public override abstract string GetNameN(int N);//for db1
        //
        public override void SetByValDouble(double val) { }
        public override void SetByValFloat(float val) { }
        public override void SetByValInt(int val) { }
        public override void SetByValBool(bool val) { }
        public override void SetByValString(string val) { }
        //
        //public override abstract void SetByValStringName(string val);//for db2
        //
        public override void SetByValDoubleN(double val, int N) { }
        public override void SetByValFloatN(float val, int N) { }
        public override void SetByValIntN(int val, int N) { }
        public override void SetByValBoolN(bool val, int N) { }
        public override void SetByValStringN(string val, int N) {
            //string s = "";
            switch (N)
            {
                case 1:
                    this.TableNameToDisplay = val;
                    break;
                case 2:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData=new TDBTableHeaderData();
                    }
                    this.DBTableHeaderData.DBTableNameInDB = val;
                    break;
                case 3:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData=new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBNameInDBCS = val;
                    break;
                case 4:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData=new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBTypeName = val;
                    break;
                case 5:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBFileFullName = val;
                    break;
            }
            //return s;
        }
        //
        //public override abstract void SetByValStringNameN(string val, int N);//for db3
        //
        public override void SetVal(double val) { }
        public override void SetVal(int val) { }
        public override void SetVal(bool val) { }
        public override void SetVal(string val) { this.TableNameToDisplay = val; }
        //
        //public override abstract void SetValToName(string val);//for db4
        //
        public override void SetValN(double val, int N) { }
        public override void SetValN(int val, int N) { }
        public override void SetValN(bool val, int N) { }
        public override void SetValN(string val, int N)
        {
            //string s = "";
            switch (N)
            {
                case 1:
                    this.TableNameToDisplay=val;
                    break;
                case 2:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    //if(this.DBTableHeaderData.DataSuppl==null){
                    //    this.DBTableHeaderData.DataSuppl=new TDBTableHeaderDataSupplSpecial();
                    //}
                    this.DBTableHeaderData.DBTableNameInDB = val;
                    break;
                case 3:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBNameInDBCS = val;
                    break;
                case 4:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBTypeName = val;
                    break;
                case 5:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if(this.DBTableHeaderData.DataSuppl==null){
                        this.DBTableHeaderData.DataSuppl=new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBFileFullName = val;
                    break;
            }
            //return s;
        }
        //
        //public override abstract void SetValToNameN(string val, int N);//for db5
        //
        public override void SetByArrDouble(double[] val, int Q) { }
        public override void SetByArrFloat(float[] val, int Q) { }
        public override void SetByArrInt(int[] val, int Q) { }
        public override void SetByArrBool(bool[] val, int Q) { }
        public override void SetByArrString(string[] val, int Q) {
            if (Q >= 5 && val.Length >= 5)
            {
                this.TableNameToDisplay = val[1-1];
                if (Q >= 1)
                {
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    //if(this.DBTableHeaderData.DataSuppl==null){
                    //    this.DBTableHeaderData.DataSuppl=new TDBTableHeaderDataSupplSpecial();
                    //}
                    if (Q >=2){
                        
                        this.DBTableHeaderData.DBTableNameInDB = val[2 - 1];
                        if (Q >= 3)
                        {
                            if (this.DBTableHeaderData.DataSuppl == null)
                            {
                                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                            }
                            this.DBTableHeaderData.DataSuppl.DBNameInDBCS = val[3 - 1];
                            if (Q >= 4)
                            {
                                this.DBTableHeaderData.DataSuppl.DBTypeName = val[4 - 1];
                                if (Q >= 5)
                                {
                                    this.DBTableHeaderData.DataSuppl.DBFileFullName = val[5 - 1];
                                }
                            }
                        }
                    }
                }
            }
        }
        //
        //public override abstract void SetByArrStringToNames(string[] val, int Q);//for db6
        //
        public override void SetByArr(double[] val, int Q) { }
        public override void SetByArr(int[] val, int Q) { }
        public override void SetByArr(bool[] val, int Q) { }
        public override void SetByArr(string[] val, int Q)
        {
            if (Q >= 5 && val.Length >= 5)
            {
                this.TableNameToDisplay = val[1 - 1];
                if (Q >= 1)
                {
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    //if(this.DBTableHeaderData.DataSuppl==null){
                    //    this.DBTableHeaderData.DataSuppl=new TDBTableHeaderDataSupplSpecial();
                    //}
                    if (Q >= 2)
                    {

                        this.DBTableHeaderData.DBTableNameInDB = val[2 - 1];
                        if (Q >= 3)
                        {
                            if (this.DBTableHeaderData.DataSuppl == null)
                            {
                                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                            }
                            this.DBTableHeaderData.DataSuppl.DBNameInDBCS = val[3 - 1];
                            if (Q >= 4)
                            {
                                this.DBTableHeaderData.DataSuppl.DBTypeName = val[4 - 1];
                                if (Q >= 5)
                                {
                                    this.DBTableHeaderData.DataSuppl.DBFileFullName = val[5 - 1];
                                }
                            }
                        }
                    }
                }
            }
        }
        //
        //public override abstract void SetByArrToNames(string[] val, int Q);//for db6
        //
        public override void AddOrInsDoubleVal(double val, int N) { }
        public override void AddOrInsFloatVal(float val, int N) { }
        public override void AddOrInsIntVal(int val, int N) { }
        public override void AddOrInsBoolVal(bool val, int N) { }
        public override void AddOrInsStringVal(string val, int N) { }
        //
        //public override abstract void AddOrInsStringValToNames(string[] val, int Q);//for db7
        //
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems) { Arr=null; QItems=0;}
        public override void GetFloatArr(ref float[] Arr, ref int QItems){ Arr=null; QItems=0;}
        public override void GetIntArr(ref int[] Arr, ref int QItems) { Arr=null; QItems=0;}
        public override void GetBoolArr(ref bool[] Arr, ref int QItems){ Arr=null; QItems=0;}
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            Arr = null;
            Arr = new string[1];
            Arr[1 - 1]=this.TableNameToDisplay;
            QItems = 1;
            if (this.DBTableHeaderData != null)
            {
                Arr[2 - 1] = this.DBTableHeaderData.DBTableNameInDB;
                QItems = 2;
                if (this.DBTableHeaderData.DataSuppl != null)
                {
                    Arr[3 - 1] = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
                    Arr[4 - 1] = this.DBTableHeaderData.DataSuppl.DBTypeName;
                    Arr[5 - 1] = this.DBTableHeaderData.DataSuppl.DBFileFullName;
                    QItems = 5;
                }
            }
        }//fn
        //
        //
        public override void DelValN(int N) { }
        //
        //
        public override void SetNameN(string name, int N)
        {
            //string s = "";
            switch (N)
            {
                case 1:
                    this.TableNameToDisplay = name;
                    break;
                case 2:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    //if(this.DBTableHeaderData.DataSuppl==null){
                    //    this.DBTableHeaderData.DataSuppl=new TDBTableHeaderDataSupplSpecial();
                    //}
                    this.DBTableHeaderData.DBTableNameInDB = name;
                    break;
                case 3:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if (this.DBTableHeaderData.DataSuppl == null)
                    {
                        this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBNameInDBCS = name;
                    break;
                case 4:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if (this.DBTableHeaderData.DataSuppl == null)
                    {
                        this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBTypeName = name;
                    break;
                case 5:
                    if (this.DBTableHeaderData == null)
                    {
                        this.DBTableHeaderData = new TDBTableHeaderData();
                    }
                    if (this.DBTableHeaderData.DataSuppl == null)
                    {
                        this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                    }
                    this.DBTableHeaderData.DataSuppl.DBFileFullName = name;
                break;
            }
            //return s;
        }
        public override void SetName1(string name) { }
        public override void SetName2(string name) { }
        //public override void SetName3(string name) { }
        public override void SetNames(string[] Arr, int Q)
        {
            this.TableNameToDisplay = Arr[1 - 1];
            if (Q >= 1)
            {
                if (this.DBTableHeaderData == null)
                {
                    this.DBTableHeaderData = new TDBTableHeaderData();
                }
                //if(this.DBTableHeaderData.DataSuppl==null){
                //    this.DBTableHeaderData.DataSuppl=new TDBTableHeaderDataSupplSpecial();
                //}
                if (Q >= 2)
                {
                    this.DBTableHeaderData.DBTableNameInDB = Arr[2 - 1];
                    if (Q >= 3)
                    {
                        if (this.DBTableHeaderData.DataSuppl == null)
                        {
                            this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                        }
                        this.DBTableHeaderData.DataSuppl.DBNameInDBCS = Arr[3 - 1];
                        if (Q >= 4)
                        {
                            this.DBTableHeaderData.DataSuppl.DBTypeName = Arr[4 - 1];
                            if (Q >= 5)
                            {
                                this.DBTableHeaderData.DataSuppl.DBFileFullName = Arr[5 - 1];
                            }
                        }
                    }
                }
            }
        }
        public override string GetNameN(int N)
        {
            string s = "";
            switch (N)
            {
                case 1:
                    s = this.TableNameToDisplay;
                break;
                case 2:
                if (this.DBTableHeaderData != null)
                {
                    s = this.DBTableHeaderData.DBTableNameInDB;
                }
                break;
                case 3:
                    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl!=null)
                    {
                        s=this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
                    }
                break;
                case 4:
                    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl!=null)
                    {
                        s=this.DBTableHeaderData.DataSuppl.DBTypeName;
                    }
                break;
                case 5:
                    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl!=null)
                    {
                        s=this.DBTableHeaderData.DataSuppl.DBFileFullName;
                    }
                break;
            }
            return s;
        }
        public override string GetName1(){return this.TableNameToDisplay;}
        public override string GetName2(){
            string s="";
            if (this.DBTableHeaderData != null)
            {
                s = this.DBTableHeaderData.DBTableNameInDB;
            }
            return s;
        }
        //public override string GetName3()
        //{
        //    string s = "";
        //    if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl!=null)
        //    {
        //        s = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
        //    }
        //    return s;
        //}
        public override void GetNames(ref string[] Arr, ref int QItems)
        {
            Arr = null;
            Arr = new string[1];
            Arr[1 - 1] = this.TableNameToDisplay;
            QItems = 1;
            if (this.DBTableHeaderData != null)
            {
                Arr[2 - 1] = this.DBTableHeaderData.DBTableNameInDB;
                QItems = 2;
                if (this.DBTableHeaderData.DataSuppl != null)
                {
                    Arr[3 - 1] = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
                    Arr[4 - 1] = this.DBTableHeaderData.DataSuppl.DBTypeName;
                    Arr[5 - 1] = this.DBTableHeaderData.DataSuppl.DBFileFullName;
                    QItems = 5;
                }
            }
        }
        public override int GetLengthOfNamesList() { return 5; }
        //
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){
            return this.TableNameToDisplay;
        }
        public override void SetDBTableNameToDisplay(string name){
            this.TableNameToDisplay=name;
        }
        //2 Тип БД BType
        public override int GetDBTypeN(){
            int y=0;
            if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
            {
                y = this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5;
            }
            return y;
        }
        public override void SetDBTypeN(int TypeN=1){
            if (this.DBTableHeaderData == null)
            {
                this.DBTableHeaderData = new TDBTableHeaderData();
            }
            if (this.DBTableHeaderData.DataSuppl == null)
            {
                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
            }
            this.DBTableHeaderData.DataSuppl.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = TypeN;
        }
        public override string GetDBConnectionString(){
            string s = "";
            int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = this.GetDBTypeN();
            string DBFileFullName = this.GetDBFileFullName();
            return MyLib.GetConnectionString(DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5, DBFileFullName);
        }
        //public override void SetDBConnectiobString(string ConnStr){
        //    this.
        //}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){
            string s = "";
            if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
            {
                s = this.DBTableHeaderData.DataSuppl.DBFileFullName;
            }
            return s;
        }
        public override void SetDBFileFullName(string name){
            if (this.DBTableHeaderData == null)
            {
                this.DBTableHeaderData = new TDBTableHeaderData();
            }
            if (this.DBTableHeaderData.DataSuppl == null)
            {
                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
            }
            this.DBTableHeaderData.DataSuppl.DBFileFullName = name;
        }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){
            string s = "";
            if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
            {
                s = this.DBTableHeaderData.DataSuppl.DBNameInDBCS;
            }
            return s;
        }
        public override void SetDBNameInSDBC(string name){
            if (this.DBTableHeaderData == null)
            {
                this.DBTableHeaderData = new TDBTableHeaderData();
            }
            if (this.DBTableHeaderData.DataSuppl == null)
            {
                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
            }
            this.DBTableHeaderData.DataSuppl.DBNameInDBCS = name;
        }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){
            string s = "";
            if (this.DBTableHeaderData != null)
            {
                s = this.DBTableHeaderData.DBTableNameInDB;
            }
            return s;
        }
        public override void SetDBTableNameInDB(string name){
            if (this.DBTableHeaderData == null)
            {
                this.DBTableHeaderData = new TDBTableHeaderData();
            }
            this.DBTableHeaderData.DBTableNameInDB = name;
        }
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        //public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //;
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { this.DBTableHeaderData = (TDBTableHeaderData)data.Clone(); }
        public override TDBTableHeaderData GetDBTableHeaderData() { return this.DBTableHeaderData;}
        public override void SetDBTableCreationData(TDBTableCreationData data)
        {
            if (this.DBTableHeaderData == null)
            {
                this.DBTableHeaderData = new TDBTableHeaderData();
            }
            if (this.DBTableHeaderData.DataSuppl == null)
            {
                this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
            }
            if (data != null)
            {
                this.DBTableHeaderData.DataSuppl = (TDBTableCreationData)data.Clone();
            }
        }
        public override TDBTableCreationData GetDBTableCreationData()
        {
            TDBTableCreationData R = null;
            if (this.DBTableHeaderData != null)
            {
                R = this.DBTableHeaderData.DataSuppl;
            }
            return R;
        }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            TCellDBTableHeader obj=new TCellDBTableHeader();
            TDBTableHeaderData DBTableHeaderData = (TDBTableHeaderData)obj.DBTableHeaderData.Clone();
            //obj.TableNameToDisplay=this.TableNameToDisplay;
            //obj.TableNameInDB=this.TableNameInDB;
            //obj.DBNameInDBCS=this.DBNameInDBCS;
            //obj.DBTypeName=this.DBTypeName;
            //obj.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5;
            //obj.DBFileFullName=this.DBFileFullName;
            return obj;
        }
    }

    public class TCellDBFieldOrItemsHeader : TDataCell
    {
        public string ColNameToDisplay;
        //
        //
        //public string ItemsTableName;
        //public string ItemsTableItemsFieldName;
        //public string ItemsTableKeyFieldName;
        public TDBFieldHeaderData DBFieldHeaderData;
        //public TDBItemsTableData DBItemsTableData;
        //
        public int QItems;
        //
        public string[] items;
        //
        public TCellDBFieldOrItemsHeader(string ColNameToDisplay = "", string[]items=null, TDBFieldHeaderData DBFieldHeaderData=null, TDBItemsTableData DBItemsTableData=null) {
            this.construct();
            //
            this.ColNameToDisplay = ColNameToDisplay;
            if(items!=null){
                this.items = new string[items.Length];
                for (int i = 1; i <= items.Length; i++)
                {
                    this.items[i - 1] = items[i - 1];
                }
            }
            if (DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
                this.DBFieldHeaderData =(TDBFieldHeaderData) DBFieldHeaderData.Clone();
            }
            //if (DBItemsTableData != null)
            //{
            //    this.DBItemsTableData = new TDBItemsTableData();
            //    this.DBItemsTableData = (TDBItemsTableData)DBItemsTableData.Clone();
            //}
        }//fn
        //
        public override  void construct(int n = 1) {
            this.ColNameToDisplay = "";
            this.DBFieldHeaderData = null;// new TDBFieldHeaderData();
            //this.DBItemsTableData = null;// new TDBItemsTableData();
            this.QItems=0;
            this.items=null;
        }
        //
        //public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        //{
        //    string cur, strN;
        //    int n, TypeN=this.GetTypeN(), Length=this.GetLength(), ActiveN=this.GetActiveN();
        //    Arr=null;
        //    QItems=0;
        //    n=this.GetTypeN();
        //    //cur = "CellCharacteristics:TypeN:" + " " + TypeN.ToString() + " " + "Length:" + " " + Length.ToString() + " " + "ActiveN:" + " " + ActiveN.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "CellCharacteristics:TypeN:" ;
        //        cur = cur+ " ";
        //    }
        //    cur = cur + TypeN.ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Length:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.GetLength().ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "ActiveN:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.GetActiveN().ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "ColName:";
        //        cur = cur + " ";
        //    }
        //    cur = cur +  this.ColNameToDisplay;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    if (this.DBFieldHeaderData != null)
        //    {
        //        //cur = "DBFieldName:" + " " + this.DBFieldHeaderData.DBFieldNameToDBTable;
        //        cur = "";
        //        if (WriteSupplInfo)
        //        {
        //            cur = "DBFieldName:";
        //            cur = cur + " ";
        //        }
        //        cur = cur + this.DBFieldHeaderData.DBFieldNameToDBTable;
        //        MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
        //        {
        //            //cur = "FieldTypeN:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "FieldTypeN:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN;
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "FieldTypeName:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "FieldTypeName:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName;
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "FieldLength:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "FieldLength:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "FieldCharacteristicNumber:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Field Characteristic Number:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Is Key Field:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Is Key Field:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Is Counter:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Is Counter:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Is Not Null:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Is Not Null:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Is AutoIncrement:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Is AutoIncrement:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement).ToString();
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //
        //            //LastN=
        //        }
        //        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
        //        {
        //            //cur = "Joined Table Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Joined Table Name:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName;
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Items Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Items Field Name:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //            //cur = "Items Key Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName.ToString();
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Items Key Field Name:";
        //                cur = cur + " ";
        //            }
        //            cur = cur + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName;
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        }
        //    }
        //    if (items != null)
        //    {
        //        //MyLib.AddToVector(ref Arr, ref QItems, "Items:");
        //        for (int i = 1; i <= this.QItems; i++)
        //        {
        //            cur = "";
        //            if (WriteSupplInfo)
        //            {
        //                cur = "Item#";
        //                strN = i.ToString();
        //                while (strN.Length < 5)
        //                {
        //                    strN = "0" + strN;
        //                }
        //                cur = cur + strN;
        //                cur = cur + ": ";
        //            }
        //            cur = cur + this.items[i - 1];
        //            MyLib.AddToVector(ref Arr, ref QItems, cur);
        //        }
        //    }
        //}//fn
        ////
        //public override void SetFromStringArray(string[] Arr, int QItems)
        //{
        //    string curIni, curFin;
        //    int n, TypeN=0, Length=0, ActiveN, CurN, LastN;
        //    string[]delims={" ",",",";"};
        //    QItems = Arr.Length;
        //    n = this.GetTypeN();
        //    if (QItems > 3)
        //    {
        //        curIni = MyLib.DelAllSubstrings(Arr[1 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "CellCharacteristics:TypeN:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "CellCharacteristics:TypeN:");
        //        TypeN = Convert.ToInt32(curFin);
        //        curIni = MyLib.DelAllSubstrings(Arr[2 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "Length:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "Length:");
        //        Length = Convert.ToInt32(curFin);
        //        curIni = MyLib.DelAllSubstrings(Arr[3 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "ActiveN:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "ActiveN:");
        //        ActiveN = Convert.ToInt32(curFin);
        //        //switch(TypeN){
        //        //    case TableConsts.ColHeaderDBFieldOrItems_colHdrOnly_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_Items_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBInfo_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBFullInfo_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN:

        //        //        break;
        //        //    case TableConsts.ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN:

        //        //        break;
        //        //     case TableConsts.ColHeaderDBFieldOrItemsTypeN:

        //        //        break;
        //        //}//break
        //    }//if len...
        //    //cur = "CellCharacteristics:TypeN:" + " " + TypeN.ToString() + " " + "Length:" + " " + Length.ToString() + " " + "ActiveN:" + " " + ActiveN.ToString();
        //    curIni = MyLib.DelAllSubstrings(Arr[4 - 1], delims);
        //    //curFin = MyLib.SubstringBetweenSubstrings(curIni, "ColName:", null);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "ColName:");
        //    this.ColNameToDisplay=curFin;
        //    //
        //    curIni = MyLib.DelAllSubstrings(Arr[5 - 1], delims);
        //    //curFin = MyLib.SubstringBetweenSubstrings(curIni, "DBFieldName:", null);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "DBFieldName:");
        //    if (curFin != null && curFin != "" || TableConsts.TypeNIsCorrectHeaderOfDBFieldOrItems_DBDataExist(TypeN))
        //    {
        //        this.DBFieldHeaderData=new TDBFieldHeaderData();
        //        this.DBFieldHeaderData.DBFieldNameToDBTable=curFin;
        //    }
        //    //
        //    curIni = MyLib.DelAllSubstrings(Arr[6 - 1], delims);
        //    //curFin = MyLib.SubstringBetweenSubstrings(curIni, "FieldTypeN:", null);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "FieldTypeN:");
        //    if (curFin != null && curFin != "" || TableConsts.TypeNIsCorrectHeaderOfDBFieldOrItems_DBCreationDataExist(TypeN))
        //    {
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial=new TDBFieldCreationDataWithItemsTable();
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData=new TDBFieldHeaderCreationData();
        //        this.DBFieldHeaderData.DBFieldNameToDBTable=curFin;
        //    }
        //    //
        //    if (this.DBFieldHeaderData != null)
        //    {
        //        curIni = MyLib.DelAllSubstrings(Arr[6 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "FieldTypeN:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldTypeN:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[7 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "FieldTypeName:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldTypeName:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName = curFin;
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[8 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "FieldLength:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldLength:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[9 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "FieldCharacteristicNumber:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldCharacteristicNumber:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[10 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "IsKeyField:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsKeyField:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[11 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "IsCounter:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsCounter:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[12 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "IsNotNull:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsNotNull:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[13 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "IsAutoIncrement:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsAutoIncrement:");
        //        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[14 - 1], delims);
        //        //curFin = MyLib.SubstringBetweenSubstrings(curIni, "JoinedTableName:", null);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "JoinedTableName:");
        //        if(curFin!=null && curFin!="" || TableConsts.TypeNIsCorrectHeaderOfDBFieldOrItems_DBJoinedItemsTableExists(TypeN)){
        //            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
        //            //
        //            curIni = MyLib.DelAllSubstrings(Arr[14 - 1], delims);
        //            //curFin = MyLib.SubstringBetweenSubstrings(curIni, "JoinedTableName:", null);
        //            curFin = MyLib.DelAllSubstringSamples(curIni, "JoinedTableName:");
        //            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName = curFin;
        //            //
        //            curIni = MyLib.DelAllSubstrings(Arr[15 - 1], delims);
        //            //curFin = MyLib.SubstringBetweenSubstrings(curIni, "ItemsFieldName:", null);
        //            curFin = MyLib.DelAllSubstringSamples(curIni, "ItemsFieldName:");
        //            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName = curFin;
        //            //
        //            curIni = MyLib.DelAllSubstrings(Arr[16 - 1], delims);
        //            //curFin = MyLib.SubstringBetweenSubstrings(curIni, "ItemsKeyFieldName:", null);
        //            curFin = MyLib.DelAllSubstringSamples(curIni, "ItemsKeyFieldName:");
        //            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName = curFin;
        //            //
        //            LastN=16;
        //        }else{
        //            LastN=13;
        //        }
        //    }else{
        //        LastN=4;
        //    }
        //    //QItems = LastN;//possible but no need
        //    //if(QItems>LastN+1){
        //    LastN = 16;
        //    this.QItems = 0;//ma ms'b nua tal
        //    if(QItems>LastN){
        //        //LastN=LastN+1;
        //        for(int i=1; i<=Length; i++){
        //            CurN=LastN+i;
        //            //MyLib.AddToVector(ref this.items, ref this.QItems, Arr[CurN-1]);
        //            curIni = MyLib.DelAllSubstrings(Arr[CurN - 1], delims);
        //            curFin = MyLib.DelAllSubstringSamples(curIni, "Item#");
        //            if (curFin.Length < curIni.Length)
        //            {
        //                curIni = curFin;
        //                curFin = curIni.Substring(6, (curFin.Length-6));
        //            }
        //            MyLib.AddToVector(ref this.items, ref this.QItems, curFin);
        //        }
        //    }
        //}//fn
        ////
        //public void ToStringArray1(ref string[] Arr, ref int QItems)//override
        //{
        //    //throw new NotImplementedException();
        //    int CurN, LastN;
        //    Arr[1 - 1] = "Cell type:";
        //    Arr[2 - 1] = TableConsts.ColHeaderDBFieldOrItemsTypeN.ToString();
        //    Arr[3 - 1] = "Col Name:";
        //    Arr[4 - 1] = this.ColNameToDisplay;
        //    Arr[5 - 1] = "DB data exist:";
        //    if (this.DBFieldHeaderData == null)
        //    {
        //        Arr[6 - 1] = "0";
        //    }
        //    else
        //    {
        //        Arr[6 - 1] = "1";
        //    }
        //    Arr[7 - 1] = "DB data exist:";
        //    if (this.DBFieldHeaderData == null || this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
        //    {
        //        Arr[8 - 1] = "0";
        //    }
        //    else
        //    {
        //        Arr[8 - 1] = "1";
        //    }
        //    Arr[9 - 1] = "DB Items Table Data exists:";
        //    if (this.DBFieldHeaderData == null || this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null || this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData==null)
        //    {
        //        Arr[10 - 1] = "0";
        //    }
        //    else
        //    {
        //        Arr[10 - 1] = "1";
        //    }
        //    Arr[11 - 1] = "Items Quantity (and existance):";
        //    if (this.items == null)
        //    {
        //        Arr[12 - 1] = "0";
        //    }
        //    else
        //    {
        //        Arr[12 - 1] = this.QItems.ToString();
        //    }
        //    LastN = 12;
        //    //
        //    //if (this.DBFieldHeaderData == null)
        //    //{
        //    //    Arr[6 - 1] = "0";
        //    //}
        //    if (this.DBFieldHeaderData != null)//2022-09-26
        //    {
        //        //Arr[6 - 1] = "1";
        //        Arr[13 - 1] = "DB data content:";
        //        Arr[14 - 1] = "DB field Name:";
        //        Arr[15 - 1] = this.DBFieldHeaderData.DBFieldNameToDBTable;
        //        //if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
        //        // {
        //        //    Arr[17 - 1] = "0";
        //        //}
        //        //else
        //        //{
        //        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null){
        //            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
        //            {
        //                //Arr[17 - 1] = "1";
        //                Arr[16 - 1] = "DB field Creation data:";
        //                Arr[17 - 1] = "Field Type N:";
        //                Arr[18 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN.ToString();
        //                Arr[19 - 1] = "Field Type Name:";
        //                Arr[20 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName;
        //                Arr[21 - 1] = "Field Length:";
        //                Arr[22 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
        //                Arr[23 - 1] = "DB Field Characteristics Number:";
        //                Arr[24 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
        //                Arr[25 - 1] = "is Key Field:";
        //                Arr[26 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
        //                Arr[27 - 1] = "is Counter:";
        //                Arr[28 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
        //                Arr[29 - 1] = "is Not Null:";
        //                Arr[30 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //                Arr[31 - 1] = "is Auto-Increment:";
        //                Arr[32 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement).ToString();
        //            }
        //        }
        //        //
        //        if (this.DBFieldHeaderData!=null)
        //        {
        //            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData!=null)
        //            {
        //                LastN = 32;
        //            }
        //            else
        //            {
        //                LastN = 17;
        //            }
        //        }
        //        else
        //        {
        //            LastN = 12;
        //        }
        //        //
        //        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData!=null)
        //        {
        //            CurN = LastN+1;
        //            Arr[CurN - 1] = "Items Table Name:";
        //            CurN = LastN + 2;
        //            Arr[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName;
        //            CurN = LastN + 3;
        //            Arr[CurN - 1] = "Items Table Items Field Name";
        //            CurN = LastN + 4;
        //            Arr[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
        //            CurN= LastN + 5;
        //            Arr[CurN - 1] = "Items Table Items Field Name";
        //            CurN = LastN + 6;
        //            Arr[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
        //            LastN = CurN;
        //        }
        //    }//if DB
        //    //
        //    if (this.DBFieldHeaderData != null)
        //    {
        //        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
        //        {
        //            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
        //            {
        //                LastN = 38;
        //            }
        //            else
        //            {
        //                LastN = 32;
        //            }
        //        }
        //        else
        //        {
        //            LastN = 17;
        //        }
        //    }
        //    else
        //    {
        //        LastN = 12;
        //    }
        //    //
        //    if (this.items != null)
        //    {
        //        CurN = LastN + 1;
        //        Arr[CurN - 1] = "Items:";
        //        LastN = LastN + 1;
        //        CurN = LastN;
        //        for (int i = 1; i <= this.QItems; i++)
        //        {
        //            CurN = CurN + 1;
        //            Arr[CurN - 1] = "Item N";
        //            CurN = CurN + 1;
        //            Arr[CurN - 1] = i.ToString();
        //             CurN = CurN + 1;
        //            Arr[CurN - 1] = "Item content:";
        //            CurN = CurN + 1;
        //            Arr[CurN - 1] = this.items[i-1];
        //        }
        //        LastN = CurN;
        //    }
        //    QItems = LastN;
        //}//fn
        //public void SetFromStringArray1(string[] Arr, int QItems = 0) // override
        //{
        //    //this.SetType//type is known
        //    //string[] ArrInner;
        //    int ArrLen = Arr.Length, LastN = 0, CurN, countItems, countFix;
        //    bool contin, LastNReached, RealDataEmpty;
        //    string curVal;
        //    if (Arr != null)
        //    {
        //        if (ArrLen >= 4)
        //        {
        //            this.ColNameToDisplay = Arr[4 - 1];
        //            LastN = 4;
        //            if (ArrLen >= 6)
        //            {
        //                if (Arr[6 - 1].Equals("1"))
        //                {
        //                    this.DBFieldHeaderData = new TDBFieldHeaderData();
        //                    LastN = 6;
        //                    if (ArrLen >= 8)
        //                    {
        //                        if (Arr[8 - 1].Equals("1"))
        //                        {
        //                            if (this.DBFieldHeaderData != null)
        //                            {
        //                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
        //                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
        //                            }
        //                            LastN = 8;
        //                            if (ArrLen >= 10)
        //                            {
        //                                //if(this.DBFieldHeaderData!=null){
        //                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
        //                                //}
        //                                LastN = 10;
        //                                if (ArrLen >= 12)
        //                                {
        //                                    this.QItems = Convert.ToInt32(Arr[12 - 1]);
        //                                    LastN = 12;
        //                                }
        //                                else LastN = 11;
        //                                //
        //                                if (this.DBFieldHeaderData != null)
        //                                {
        //                                    if (ArrLen >= 15)
        //                                    {
        //                                        this.DBFieldHeaderData.DBFieldNameToDBTable = Arr[15 - 1];
        //                                        LastN = 15;
        //                                    }
        //                                    else LastN = Arr.Length;
        //                                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
        //                                    {
        //                                        if (ArrLen >= 18)
        //                                        {
        //                                            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = Convert.ToInt32(Arr[18 - 1]);
        //                                            LastN = 18;
        //                                            if (ArrLen >= 20)
        //                                            {
        //                                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName = Arr[20 - 1];
        //                                                LastN = 20;
        //                                                if (ArrLen >= 22)
        //                                                {
        //                                                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = Convert.ToInt32(Arr[22 - 1]);
        //                                                    LastN = 22;
        //                                                    if (ArrLen >= 24)
        //                                                    {
        //                                                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber = Convert.ToInt32(Arr[24 - 1]);
        //                                                        LastN = 24;
        //                                                        if (ArrLen >= 26)
        //                                                        {
        //                                                            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = MyLib.IntToBool(Convert.ToInt32(Arr[26 - 1]));
        //                                                            LastN = 26;
        //                                                            if (ArrLen >= 28)
        //                                                            {
        //                                                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = MyLib.IntToBool(Convert.ToInt32(Arr[28 - 1]));
        //                                                                LastN = 28;
        //                                                                if (ArrLen >= 30)
        //                                                                {
        //                                                                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = MyLib.IntToBool(Convert.ToInt32(Arr[30 - 1]));
        //                                                                    LastN = 30;
        //                                                                    if (ArrLen >= 32)
        //                                                                    {
        //                                                                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = MyLib.IntToBool(Convert.ToInt32(Arr[32 - 1]));
        //                                                                        LastN = 32;
        //                                                                    }
        //                                                                    else LastN = Arr.Length;
        //                                                                }
        //                                                                else LastN = Arr.Length;
        //                                                            }
        //                                                            else LastN = Arr.Length;
        //                                                        }
        //                                                        else LastN = Arr.Length;
        //                                                    }
        //                                                    else LastN = Arr.Length;
        //                                                }
        //                                                else LastN = Arr.Length;
        //                                            }
        //                                            else LastN = Arr.Length;
        //                                        }
        //                                        else LastN = Arr.Length;
        //                                    }//if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
        //                                    //vikt! amda ms'b DBItemsTableData
        //                                }//if (this.DBFieldHeaderData != null)
        //                                if (this.DBFieldHeaderData!= null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial!=null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData!=null)
        //                                {
        //                                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
        //                                    {
        //                                        LastN = 32;
        //                                    }
        //                                    else
        //                                    {
        //                                        LastN = 17;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    LastN = 12;
        //                                }
        //                                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
        //                                {
        //                                    CurN=LastN+2;
        //                                    if (ArrLen >= CurN)
        //                                    {
        //                                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName = Arr[CurN - 1];
        //                                        LastN = CurN;
        //                                        CurN = LastN + 2;
        //                                        if (ArrLen >= CurN)
        //                                        {
        //                                            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName = Arr[CurN - 1];
        //                                            LastN = CurN;
        //                                            CurN = LastN + 2;
        //                                            if (ArrLen >= CurN)
        //                                            {
        //                                                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName = Arr[CurN - 1];
        //                                                LastN = CurN;
        //                                                //CurN = LastN + 2;
        //                                            }
        //                                            else LastN = Arr.Length; 
        //                                        }
        //                                        else LastN = Arr.Length; 
        //                                    }
        //                                    else LastN = Arr.Length;
        //                                }//if (this.DBItemsTableData != null)
        //                                if (this.DBFieldHeaderData != null)
        //                                {
        //                                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
        //                                    {
        //                                        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
        //                                        {
        //                                            LastN = 38;
        //                                        }
        //                                        else
        //                                        {
        //                                            LastN = 32;
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        LastN = 17;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    LastN = 12;
        //                                }
        //                                //
        //                                if (this.QItems > 0)
        //                                {
        //                                    //CurN = LastN + 3;
        //                                    CurN = LastN + 1;//Text "Items:"
        //                                    //contin, LastNReached, RealDataEmpty;
        //                                    //MyLib.AddToVector(ref this.items, ref countItems, Arr[CurN-1]);
        //                                    countItems=0;
        //                                    RealDataEmpty=(QItems<LastN+1+4);
        //                                    LastNReached=(countItems<this.QItems);
        //                                    contin=(!LastNReached && !RealDataEmpty);
        //                                    while(contin)
        //                                    {
        //                                        CurN = CurN + 4;
        //                                        curVal=Arr[CurN - 1];
        //                                        if(CurN<=QItems){
        //                                            MyLib.AddToVector(ref this.items, ref countItems, curVal);
        //                                        }else{
        //                                            contin=false;
        //                                        }
        //                                        LastNReached=(countItems>=this.QItems);
        //                                        RealDataEmpty=(QItems<LastN+1+4*this.QItems);
        //                                        if(LastNReached){
        //                                            contin=false;
        //                                        }
        //                                        if(RealDataEmpty){
        //                                            contin=false;
        //                                        }
        //                                    }
        //                                    if(RealDataEmpty &&!LastNReached){
        //                                        countFix = countItems;
        //                                        for (int i = countFix + 1; i <= this.QItems; i++)
        //                                        {
        //                                            curVal="";
        //                                            MyLib.AddToVector(ref this.items, ref countItems, curVal);
        //                                        }
        //                                    }
        //                                    LastN = CurN;//no need
        //                                }//if (this.QItems > 0)
        //                            }
        //                            else LastN = 9;
        //                        }//if (Arr[8 - 1].Equals("1"))
        //                    }
        //                    else LastN = 7;
        //                }//if (Arr[6 - 1].Equals("1"))
        //            }//if (ArrLen >= 6)
        //        }//if (ArrLen >= 4)
        //    }//if (Arr != null)
        //}//fn
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            int QItemsContent = 0;
            string[] ArrContent = null;
            string[]delims={" ", ";", ","};
            string s1, s2, s3, name="ColName: ", sN, cur;
            Arr = null;
            QItems = 0;
            bool DataExist=(this.DBFieldHeaderData!=null);
            //
            //s1 = Arr[1 - 1];
            //s2=MyLib.DelAllSubstrings(s1, delims);
            //if(s2.Length>name.Length && (s2.Substring(1-1, name.Length).Equals(name)){
            //    s3=s2.Substring(name.Length+1-1, (s2.Length-name.Length));
            //}else{
            //    s3=s2;
            //}
            //this.ColNameToDisplay =s3;
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + name;
            }
            cur = cur + this.ColNameToDisplay;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //
            if(this.DBFieldHeaderData!=null || WriteWholeInfo){
                if(this.DBFieldHeaderData==null){
                    this.DBFieldHeaderData=new TDBFieldHeaderData();
                }
                this.DBFieldHeaderData.ToStringArray(ref ArrContent, ref QItemsContent, WriteSupplInfo, WriteWholeInfo);
                for(int i=1; i<=QItemsContent; i++){
                    cur=ArrContent[i-1];
                    MyLib.AddToVector(ref Arr, ref QItems, cur);
                }
                if (!DataExist)
                {
                    this.DBFieldHeaderData = null;
                }
            }
            if(this.items!=null){
                if(WriteSupplInfo){
                    for(int i=1; i<=this.QItems; i++){
                        name = "item#";
                        sN = i.ToString();
                        while (sN.Length < 4)
                        {
                            sN = "0" + sN;
                        }
                        name =name+ sN;
                        cur=name+": ";
                        cur=cur+this.items[i-1];
                        MyLib.AddToVector(ref Arr, ref QItems, cur);
                    }
                }else{
                     for(int i=1; i<=this.QItems; i++){
                        cur=this.items[i-1];
                        MyLib.AddToVector(ref Arr, ref QItems, cur);
                    }
                }
            }//if items exist
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            string s1, s2, s3, name="ColName: ", sN;
            //string[]delims={" ", ";", ","};
            int QDataItems=11+2;
            int countInnerItems=0;
            if (Arr != null)
            {
                if (QItems > 0)
                {
                    s1 = Arr[FromN - 1];
                    s2 = s1;// MyLib.DelAllSubstrings(s1, delims);
                    if(s2.Length>name.Length && (s2.Substring(1-1, name.Length).Equals(name))){
                        s3=s2.Substring(name.Length+1-1, (s2.Length-name.Length));
                    }else{
                        s3=s2;
                    }
                    this.ColNameToDisplay =s3;
                    //
                    if(QItems>1){
                        this.DBFieldHeaderData=new TDBFieldHeaderData();
                        this.DBFieldHeaderData.SetFromStringArray(Arr, QItems, FromN+1);
                        //
                        if(QItems>QDataItems){
                            this.items=null;
                            while (FromN - 1 + QDataItems + countInnerItems < QItems)
                            {
                                countInnerItems++;
                                s1 = Arr[FromN-1+QDataItems+countInnerItems- 1];
                                s2 = s1;// MyLib.DelAllSubstrings(s1, delims);
                                name="item#";
                                sN=countInnerItems.ToString();
                                while(sN.Length<4){
                                    sN="0"+sN;
                                }
                                name=name+sN+": ";
                                if(s2.Length>name.Length && (s2.Substring(1-1, name.Length).Equals(name))){
                                    s3=s2.Substring(name.Length+1-1, (s2.Length-name.Length));
                                }else{
                                    s3=s2;
                                }
                                MyLib.AddToVector(ref this.items, ref this.QItems, s3);
                            }
                        }//if QItems>QDataItems
                    }//if Items>1
                }
            }
        }//fn
        //
        public override void GetItems(ref string[] Arr, ref int QItems)
        {
            // throw new NotImplementedException();
            // Arr = this.items;
            QItems = this.QItems;
            Arr=new string[QItems];
            for (int i = 1; i <= this.QItems; i++) { Arr[i - 1] = this.items[i - 1]; }
        }
        //
        public override int GetTypeN() {
            //return TableConsts.ColHeaderDBFieldOrItemsTypeN;
            int TypeN = TableConsts.ColHeaderDBFieldOrItemsTypeN;
            if (this.DBFieldHeaderData == null)
            {
                if (this.items == null)
                {
                    TypeN = TableConsts.ColHeaderDBFieldOrItems_colHdrOnly_TypeN;
                }
                else
                {
                    TypeN = TableConsts.ColHeaderDBFieldOrItems_Items_TypeN;
                }
            }
            else
            {
                if (this.items == null)
                {
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                    {
                        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
                        {
                            TypeN = TableConsts.ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN; //no need
                        }
                        else
                        {
                            TypeN = TableConsts.ColHeaderDBFieldOrItems_DBFullInfo_TypeN;
                        }
                    }
                    else
                    {
                        TypeN = TableConsts.ColHeaderDBFieldOrItems_DBInfo_TypeN;
                    }
                }
                else
                {
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                    {
                        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
                        {
                            TypeN = TableConsts.ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN; //all
                        }
                        else
                        {
                            TypeN = TableConsts.ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN;
                        }
                    }
                    else
                    {
                        TypeN = TableConsts.ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN;
                    }
                }
            }
            return TypeN;
        }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return this.QItems; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal() { return 0; }
        public override float GetFloatVal() { return 0; }
        public override int GetIntVal() { return 0; }
        public override bool GetBoolVal() { return MyLib.BoolValByDefault; }
        public override  string ToString() { return this.ColNameToDisplay; }
        //
        public override  double GetDoubleValN(int N) { return 0; }
        public override float GetFloatValN(int N) { return 0; }
        public override int GetIntValN(int N) { return 0; }
        public override bool GetBoolValN(int N) { return MyLib.BoolValByDefault; }
        public override string ToStringN(int N)
        {
            string s = "";
            if (this.items != null && N>=1 && N<=items.Length)
            {
                s = this.items[N - 1];
            }
            //switch(N){
            //    case 1:
            //        s=this.DBFieldNameToDisplay;
            //    break;
            //    case 2:
            //    s = this.DBFieldNameToDBTable = "";
            //    break;
            //    case 3:
            //        //s = this.DBItemsTable = new DBItemsTableData();
            //    break;
            //    case 4:
            //        s=this.FieldTypeN.ToString();
            //    break;
            //    case 5:
            //        s = this.FieldLength.ToString();
            //    break;
            //    //case 6:
            //    //    this.IsKeyField = false;
            //    //break;
            //    //case 7:
            //    //    this.IsCounter = false;
            //    //break;
            //    //case 7:
            //    //    this.IsAutoIncrement = false;
            //    //break;
            //    case 6:
            //        s=this.DBFieldCharacteristicsNumber.ToString();
            //    break;
            //    case 7:
            //        s = this.QItems.ToString();
            //    break;
            //    this.items = null;
            //}
            return s;
        }
        //
        //public override abstract string GetNameN(int N);//for db1
        //
        public override void SetByValDouble(double val) { }
        public override void SetByValFloat(float val) { }
        public override void SetByValInt(int val) { }
        public override void SetByValBool(bool val) { }
        public override void SetByValString(string val) { }
        //
        //public override abstract void SetByValStringName(string val);//for db2
        //
        public override void SetByValDoubleN(double val, int N) { }
        public override void SetByValFloatN(float val, int N) { }
        public override void SetByValIntN(int val, int N) { }
        public override void SetByValBoolN(bool val, int N) { }
        public override void SetByValStringN(string val, int N) {
            //string s = "";
            if (this.items != null && N >= 1 && N <= items.Length)
            {
                this.items[N - 1] = val;
            }
            //switch (N)
            //{
            //    case 1:
            //        this.TableNameToDisplay = val;
            //        break;
            //    case 2:
            //        this.TableNameInDB = val;
            //        break;
            //    case 3:
            //        this.DBNameInDBCS = val;
            //        break;
            //    case 4:
            //        this.DBTypeName = val;
            //        break;
            //    case 5:
            //        this.DBFileFullName = val;
            //        break;
            //}
            ////return s;
        }
        //
        //public override abstract void SetByValStringNameN(string val, int N);//for db3
        //
        public override void SetVal(double val) { }
        public override void SetVal(int val) { }
        public override void SetVal(bool val) { }
        public override void SetVal(string val) { this.ColNameToDisplay = val; }
        //
        //public override abstract void SetValToName(string val);//for db4
        //
        public override void SetValN(double val, int N) { }
        public override void SetValN(int val, int N) { }
        public override void SetValN(bool val, int N) { }
        public override void SetValN(string val, int N)
        {
            this.SetByValStringN(val, N);
            //string s = "";
            //switch (N)
            //{
            //    case 1:
            //        this.TableNameToDisplay=val;
            //        break;
            //    case 2:
            //        this.TableNameInDB = val;
            //        break;
            //    case 3:
            //        this.DBNameInDBCS = val;
            //        break;
            //    case 4:
            //        this.DBTypeName = val;
            //        break;
            //    case 5:
            //        this.DBFileFullName = val;
            //        break;
            //}
            ////return s;
        }
        //
        //public override abstract void SetValToNameN(string val, int N);//for db5
        //
        public override void SetByArrDouble(double[] val, int Q) { }
        public override void SetByArrFloat(float[] val, int Q) { }
        public override void SetByArrInt(int[] val, int Q) { }
        public override void SetByArrBool(bool[] val, int Q) { }
        public override void SetByArrString(string[] val, int Q) {
            if (this.items == null || this.items.Length!=val.Length)
            {
                Q = val.Length;
                this.items = new string[Q];
                for (int i = 1; i <= Q; i++)
                {
                    items[i - 1] = val[i - 1];
                }
            }
        }
        //
        //public override abstract void SetByArrStringToNames(string[] val, int Q);//for db6
        //
        public override void SetByArr(double[] val, int Q) { }
        public override void SetByArr(int[] val, int Q) { }
        public override void SetByArr(bool[] val, int Q) { }
        public override void SetByArr(string[] val, int Q)
        {
            //if (Q >= 5 && val.Length >= 5)
            this.SetByArrString(val, Q);
        }
        //
        //public override abstract void SetByArrToNames(string[] val, int Q);//for db6
        //
        public override void AddOrInsDoubleVal(double val, int N) { }
        public override void AddOrInsFloatVal(float val, int N) { }
        public override void AddOrInsIntVal(int val, int N) { }
        public override void AddOrInsBoolVal(bool val, int N) { }
        public override void AddOrInsStringVal(string val, int N) {
            string[] items = null; 
            if (this.items == null)
            {
                this.items = new string[1];
                this.items[1 - 1] = val;
            }
            else//if (N >= 1 && N <= this.items.Length+1)
            {
                items =new string[this.QItems+1];
                if(N<=0 || N>=this.QItems) N=QItems+1;
                for (int i = 1; i <= N-1; i++)
                {
                    items[i - 1] = this.items[i - 1];
                }
                items[N - 1] = val;
                for (int i = N; i <= this.QItems; i++)
                {
                    items[i - 1 + 1] = this.items[i - 1];
                }
                this.items = items;
                this.QItems++;
            }
        }
        //
        //public override abstract void AddOrInsStringValToNames(string[] val, int Q);//for db7
        //
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems) { Arr=null; QItems=0;}
        public override void GetFloatArr(ref float[] Arr, ref int QItems){ Arr=null; QItems=0;}
        public override void GetIntArr(ref int[] Arr, ref int QItems) { Arr=null; QItems=0;}
        public override void GetBoolArr(ref bool[] Arr, ref int QItems){ Arr=null; QItems=0;}
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            //Arr[1 - 1]=this.TableNameToDisplay;
            //Arr[2 - 1]=this.TableNameInDB;
            //Arr[3 - 1]=this.DBNameInDBCS;
            //Arr[4 - 1]=this.DBTypeName;
            //Arr[5 - 1]=this.DBFileFullName;
            //QItems=5;
            //if (this.items != null)
            //{
            //
            //}
            Arr = this.items;
            QItems = this.QItems;
        }
        //
        //
        public override void DelValN(int N) {
            string[] items = null;
            if (items!=null && N >= 1 && N <= this.QItems)
            {
                items = new string[this.QItems - 1];
                for (int i = 1; i <= N - 1; i++)
                {
                    items[i - 1] = this.items[i - 1];
                }
                for (int i = N; i <= this.QItems; i++)
                {
                    items[i-1-1] = this.items[i - 1];
                }
                this.items = items;
                this.QItems--;
            }
        }
        //
        //
        public override void SetNameN(string name, int N)
        {
            //string s = "";
            //this.DBItemsTable=null;
            this.items=null;
            switch (N)
            {
                case 1:
                    this.ColNameToDisplay = name;
                    break;
                case 2:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData =new TDBFieldHeaderData();
                    this.DBFieldHeaderData.DBFieldNameToDBTable = name;
                    break;
                case 3:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new  TDBFieldCreationDataWithItemsTable();
                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = Convert.ToInt32(name);
                    break;
                case 4:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = Convert.ToInt32(name);
                    break;
                //case 6:
                //    this.DBFieldCharacteristicsNumber = Convert.ToInt32(name);
                //    break;
                case 5:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = MyLib.StrToBool(name);
                    break;
                case 6:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = MyLib.StrToBool(name);
                    break;
                case 7:
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                    this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = MyLib.StrToBool(name);
                    break;
                //case 9://for thuis nmust be SetVals or AddVal
                //    this.QItems = Convert.ToInt32(name);
                //    break;
            }//switch
            //return s;
        }
        public override void SetName1(string name) { }
        public override void SetName2(string name) { }
        //public override void SetName3(string name) { }
        public override void SetNames(string[] Arr, int Q)
        {
            if (Q >= 1 && Arr.Length >= 1)
            {
                this.ColNameToDisplay = Arr[1 - 1];
                if (Q >= 2 && Arr.Length >= 2)
                {
                    //
                    if (this.DBFieldHeaderData == null) this.DBFieldHeaderData = new TDBFieldHeaderData();
                    //
                    this.DBFieldHeaderData.DBFieldNameToDBTable = Arr[2 - 1];
                    if (Q >= 8 && Arr.Length >= 8)
                    {
                        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                        if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null) this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData(); 
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = Convert.ToInt32(Arr[3 - 1]);
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = Convert.ToInt32(Arr[4 - 1]);
                        //this.FieldLength = Convert.ToInt32(Arr[5 - 1]);
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = MyLib.StrToBool(Arr[5 - 1]);
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = MyLib.StrToBool(Arr[6 - 1]);
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = MyLib.StrToBool(Arr[7 - 1]);
                        //this.DBFileFullName = Arr[5 - 1];
                        this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber = Convert.ToInt32(Arr[8 - 1]);
                    }
                }
            }
        }
        public override  string GetNameN(int N)
        {
            string s = "";
            switch (N)
            {
                case 1:
                    s = this.ColNameToDisplay;
                break;
                case 2:
                if (this.DBFieldHeaderData != null)
                {
                    s = this.DBFieldHeaderData.DBFieldNameToDBTable;
                }
                break;
                case 3:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial!=null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData!=null)
                {
                    s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN.ToString();
                }
                break;
                case 4:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                {
                    s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
                }
                break;
                case 5:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                {
                    s = MyLib.BoolToStr(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField, TableConsts.TrueWord, TableConsts.FalseWord);
                }
                break;
                case 6:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                {
                    s = MyLib.BoolToStr(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter, TableConsts.TrueWord, TableConsts.FalseWord);
                }
                break;
                case 7:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                {
                    s = MyLib.BoolToStr(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement, TableConsts.TrueWord, TableConsts.FalseWord);
                }
                break;
                case 8:
                if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                {
                    s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
                }
                break;
                //
                case 9:
                    //if(this.DBFieldHeaderData!=null && this.d
                break;
            }
            return s;
        }
        public override string GetName1() {
            
            return this.ColNameToDisplay; 
        }
        public override string GetName2() {
            string s = "";
            if (this.DBFieldHeaderData != null)
            {
                s = this.DBFieldHeaderData.DBFieldNameToDBTable;
            }
            return s;
        }
        //public override string GetName3() { return ""; }
        public override void GetNames(ref string[] Arr, ref int QItems)
        {
            Arr = new string[7];
            for(int i=1; i<=7; i++){
                Arr[i - 1] = this.GetNameN(i);
            }
            QItems = this.QItems;
        }
        public override int GetLengthOfNamesList(){ return 5;}
        //
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return this.ColNameToDisplay; }
        public override void SetDBFieldNameToDisplay(string name){ this.ColNameToDisplay=name; }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){
            string s = "";
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            s = this.DBFieldHeaderData.DBFieldNameToDBTable;
            return s;
        }
        public override void SetDBFieldNameInTable(string name){
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            this.DBFieldHeaderData.DBFieldNameToDBTable=name;
        }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){
            string s="";
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData!=null)
            {
                s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName;
            }
            return s; 
        }
        public override void SetItemsDBTableNameInDB(string name){
            if(this.DBFieldHeaderData==null){
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName = name;
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов Pr return ""; imaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){
            string s="";
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName;
            }
            return s; 
        }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName = name;
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){
            string s="";
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
            }
            return s; 
        }
        public override void SetItemsDBTableItemsFieldName(string name)
        {
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName = name;
        }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){
            int n = 0;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                n = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN;
            }
            return n;
        }
        public override void SetDBFieldTypeN(int TypeN){
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = TypeN;
        }
        public override string GetDBFieldTypeName(){
            string s = "";
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                s = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName;
            }
            return s;
        }
        public override void SetDBFieldTypeName(string name){
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new  TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName = name;
        }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){
            int n = 0;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                n = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength;
            }
            return n;
        }
        public override void SetDBFieldLength(int L){
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = L;
        }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){
            return this.QItems;
        }
        public override void SetItems(string [] items, int Q){
            Q=items.Length;
            this.items=new string[Q];
            for(int i=1; i<=Q; i++){
                this.items[i-1]=items[i-1];
            }
            this.QItems=Q;
        }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber()
        {
            int n = 0;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                n = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength;
            }
            return n;
        }
        public override void SetDBFieldCharacteristicsNumber(int number)
        {
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData==null){
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber = number;
        }
        public override bool IsKeyField()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                b = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField;
            }
            return b;
        }
        public override void SetIfKeyField(bool KeyField)
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = KeyField;
        }
        public override void SetKeyField()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = true;
        }
        public override void SetNotKeyField()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = false;
        }
        public override bool IsCounter()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                b = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter;
            }
            return b;
        }
        public override void SetIfCounter(bool isCounter)
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = isCounter;
        }
        public override void SetCounter()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = true;
        }
        public override void SetNotCounter()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = false;
        }
        public override bool IsAutoIncrement()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                b = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement;
            }
            return b;
        }
        public override void SetIfAutoIncrement(bool isAutoIncrement)
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = isAutoIncrement;
        }
        public override void SetAutoIncrement()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = true;
        }
        public override void SetNotAutoIncrement()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = false;
        }
        //
        public override bool IsNotNull()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                b = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull;
            }
            return b;
        }
        public override void SetIfNotNull(bool isNotNull)
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull = isNotNull;
        }
        public override void SetNotNull()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull = true;
        }
        public override void SetNotNotNull()
        {
            if (this.DBFieldHeaderData != null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull = false;
        }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) {  }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { this.DBFieldHeaderData = (TDBFieldHeaderData)data.Clone();  }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return this.DBFieldHeaderData; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data)
        {
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData == null){
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
            }
            if(data!=null){
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = (TDBFieldHeaderCreationData)data.Clone();
            }
        }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData()
        {
            TDBFieldHeaderCreationData R = null;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
            {
                R=(TDBFieldHeaderCreationData)this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.Clone();//or clone?
            }
            return R;
        }
        public override void SetDBItemsTableData(TDBItemsTableData data)
        {
            if (this.DBFieldHeaderData == null)
            {
                this.DBFieldHeaderData = new TDBFieldHeaderData();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
            }
            if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData== null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
            }
            if (data != null)
            {
                this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = (TDBItemsTableData)data.Clone();
            }
        }
        public override TDBItemsTableData GetDBItemsTableData()
        {
            TDBItemsTableData R = null;
            if (this.DBFieldHeaderData != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
            {
                R = (TDBItemsTableData)this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.Clone();//or clone?
            }
            return R;
        }
        //
        public override object Clone()
        {
            TCellDBFieldOrItemsHeader obj = new TCellDBFieldOrItemsHeader();
            obj.ColNameToDisplay = this.ColNameToDisplay;
            if(this.items!=null){
                obj.items=new string[this.items.Length];
                for(int i=1; i<=this.items.Length; i++){
                    obj.items[i-1]=this.items[i-1];
                }
            }
            if (this.DBFieldHeaderData != null)
            {
                obj.DBFieldHeaderData = (TDBFieldHeaderData)this.DBFieldHeaderData.Clone();
                if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
                {
                    obj.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = (TDBFieldCreationDataWithItemsTable)this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.Clone();
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                    {
                        obj.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = (TDBFieldHeaderCreationData)this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.Clone();
                    }
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
                    {
                        obj.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = (TDBItemsTableData)this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.Clone();
                    }
                }
            }
            return obj;
        }//fn Clone
    }//class TCellDBFieldHeader
    //
    public class TCellDouble : TDataCell
    {
        double val;
        public TCellDouble() { val = 0; }
        public TCellDouble(double val) { SetByValDouble(val); }
        public TCellDouble(float val) { SetByValFloat(val); }
        public TCellDouble(int val) { SetByValInt(val); }
        public TCellDouble(bool val) { SetByValBool(val); }
        public TCellDouble(string val) { SetByValString(val); }
        //
        public TCellDouble(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellDouble(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellDouble(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellDouble(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellDouble(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            //Arr = new string[1];
            if (WriteSupplInfo) Arr[1 - 1] = "Value: " + this.val.ToString();
            else Arr[1 - 1] = this.val.ToString();
            QItems = 1;
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            //QItems=Arr.Length;
            //if (QItems >= 4)
            //{
            //    this.val = Convert.ToDouble(Arr[4-1]);
            //}
            string s1, s2, s3;
            string[] delims = { " ",  ";" };//ma ne ",", ob ce alt name uz "."
            string name="Value:";
            s1 = Arr[FromN - 1];
            if (s1.Substring(1, 6).Equals(name))
            {
                s2 = MyLib.DelAllSubstrings(s1, delims);
                s3 = s2.Substring(7, s2.Length - name.Length);
            }
            else
            {
                s3 = s1;
            }
            this.val = Convert.ToDouble(s3);
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.DoubleTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal() { return val; }
        public override float GetFloatVal()
        {
            float r;
            r = (float)val;
            return r;
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
        public override void SetByValDouble(double val) { this.val = (double)val; }
        public override void SetByValFloat(float val) { this.val = (double)val; }
        public override void SetByValInt(int val) { this.val = (double)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (double)i;
        }
        public override void SetByValString(string val)
        {
            //this.val = Convert.ToDouble(val);
            this.val = NumberParse.StrToFloat(val);
        } //hin S' ne abl convert!!
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
            this.val = Convert.ToDouble(val);
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int num) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) {  }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellDouble(this.GetDoubleVal());
        }
    }//cl
    public class TCellFloat : TDataCell
    {
        float val;
        public TCellFloat() { val = 0; }
        public TCellFloat(double val) { SetByValDouble(val); }
        public TCellFloat(float val) { SetByValFloat(val); }
        public TCellFloat(int val) { SetByValInt(val); }
        public TCellFloat(bool val) { SetByValBool(val); }
        public TCellFloat(string val) { SetByValString(val); }
        //
        public TCellFloat(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellFloat(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellFloat(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellFloat(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellFloat(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            //Arr = new string[1];
            if (WriteSupplInfo) Arr[1 - 1] = "Value: " + this.val.ToString();
            else Arr[1 - 1] = this.val.ToString();
            QItems = 1;
        }
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            //QItems=Arr.Length;
            //if (QItems >= 4)
            //{
            //    this.val = Convert.ToDouble(Arr[4-1]);
            //}
            string s1, s2, s3;
            string[] delims = { " ", ";" };//ma ne ",", ob ce alt name uz "."
            string name = "Value:";
            s1 = Arr[FromN - 1];
            if (s1.Substring(1, 6).Equals(name))
            {
                s2 = MyLib.DelAllSubstrings(s1, delims);
                s3 = s2.Substring(7, s2.Length - name.Length);
            }
            else
            {
                s3 = s1;
            }
            this.val = (float)Convert.ToDouble(s3);
        }
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.FloatTypeN; }
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
        public override void SetByValDouble(double val) { this.val = (float)val; }
        public override void SetByValFloat(float val) { this.val = (float)val; }
        public override void SetByValInt(int val) { this.val = (float)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetByValString(string val)
        {
            double d;
            //d = Convert.ToDouble(val);
            d = NumberParse.StrToFloat(val);
            this.val = (float)d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val) { this.val = (float)val; }
        public override void SetVal(int val) { this.val = (float)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetVal(string val)
        {
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellFloat(this.GetFloatVal());
        }
        //
    }//cl
    public class TCellInt : TDataCell
    {
        int val;
        public TCellInt() { val = 0; }
        public TCellInt(double val) { SetByValDouble(val); }
        public TCellInt(float val) { SetByValFloat(val); }
        public TCellInt(int val) { SetByValInt(val); }
        public TCellInt(bool val) { SetByValBool(val); }
        public TCellInt(string val) { SetByValString(val); }
        //
        public TCellInt(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellInt(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellInt(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellInt(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellInt(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            //Arr = new string[1];
            if (WriteSupplInfo) Arr[1 - 1] = "Value: " + this.val.ToString();
            else Arr[1 - 1] = this.val.ToString();
            QItems = 1;
        }
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            //QItems=Arr.Length;
            //if (QItems >= 4)
            //{
            //    this.val = Convert.ToDouble(Arr[4-1]);
            //}
            string s1, s2, s3;
            string[] delims = { " ", ";" };//ma ne ",", ob ce alt name uz "."
            string name = "Value:";
            s1 = Arr[FromN - 1];
            if (s1.Substring(1, 6).Equals(name))
            {
                s2 = MyLib.DelAllSubstrings(s1, delims);
                s3 = s2.Substring(7, s2.Length - name.Length);
            }
            else
            {
                s3 = s1;
            }
            this.val = Convert.ToInt32(s3);
        }
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        } 
        //
        public override int GetTypeN() { return TableConsts.IntTypeN; }
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
        public override int GetIntValN(int N) { return val; }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByValDouble(double val) { this.val = (int)val; }
        public override void SetByValFloat(float val) { this.val = (int)val; }
        public override void SetByValInt(int val) { this.val = (int)val; }
        public override void SetByValBool(bool val)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void SetByValString(string val)
        {
            double d;
            //this.val = Convert.ToInt32(val);
            d = NumberParse.StrToFloat(val);
            this.val = (int)d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellInt(this.GetIntVal());
        }
    }//cl TCellInt
    public class TCellBool : TDataCell
    {
        bool val;
        public TCellBool() { val = false; }
        public TCellBool(double val) { SetByValDouble(val); }
        public TCellBool(float val) { SetByValFloat(val); }
        public TCellBool(int val) { SetByValInt(val); }
        public TCellBool(bool val) { SetByValBool(val); }
        public TCellBool(string val) { SetByValString(val); }
        //
        public TCellBool(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellBool(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellBool(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellBool(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellBool(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            //Arr = new string[1];
            if (WriteSupplInfo) Arr[1 - 1] = "Value: " + this.val.ToString();
            else Arr[1 - 1] = this.val.ToString();
            QItems = 1;
        }
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            //QItems=Arr.Length;
            //if (QItems >= 4)
            //{
            //    this.val = Convert.ToDouble(Arr[4-1]);
            //}
            string s1, s2, s3;
            string[] delims = { " ", ";" };//ma ne ",", ob ce alt name uz "."
            string name = "Value:";
            s1 = Arr[FromN - 1];
            if (s1.Substring(1, 6).Equals(name))
            {
                s2 = MyLib.DelAllSubstrings(s1, delims);
                s3 = s2.Substring(7, s2.Length - name.Length);
            }
            else
            {
                s3 = s1;
            }
            //this.val = Convert.ToInt32(s3);
            if (MyLib.IsTrue(s3))
            {
                this.val = true;
            }
            else if (MyLib.IsFalse(s3))
            {
                this.val = false;
            }
            else
            {
                this.val = MyLib.BoolValByDefault;
            }
        }
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.BoolTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            int i;
            i = MyLib.BoolToInt(val);
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
        public override string ToString()
        {
            int i;
            i = MyLib.BoolToInt(val);
            return i.ToString();
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
        public override void SetByValDouble(double val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByValFloat(float val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByValInt(int val)
        {
            this.val = MyLib.IntToBool(val);
        }
        public override void SetByValBool(bool val)
        {
            this.val = val;
        }
        public override void SetByValString(string val)
        {
            int i;
            i = Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i);
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
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
            i = Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i);
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellBool(this.GetBoolVal());
        }
    }//cl
    public class TCellString : TDataCell
    {
        string val;
        public TCellString() { val = ""; }
        public TCellString(double val) { SetByValDouble(val); }
        public TCellString(float val) { SetByValFloat(val); }
        public TCellString(int val) { SetByValInt(val); }
        public TCellString(bool val) { SetByValBool(val); }
        public TCellString(string val) { SetByValString(val); }
        //
        public TCellString(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellString(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellString(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellString(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellString(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.DoubleTypeN.ToString();
            //Arr[3 - 1] = "Value";
            //Arr[4 - 1] = this.val;
            //QItems = 4;
            //
            //Arr[1 - 1] = "";
            //if (WriteSupplInfo)
            //{
            //    Arr[1 - 1] = Arr[1 - 1]  + "Value: ";
            //}
            //Arr[1 - 1] = Arr[1 - 1]  + this.val;
            //QItems = 1;
            Arr[1 - 1] = this.val;
        }
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException();
            //QItems = Arr.Length;
            //if (QItems >= 4)
            //{
            //    this.val = Arr[4 - 1];
            //}
            //
            //if (Arr[1 - 1].Length >= 6 && Arr[1 - 1].Substring(1 - 1, 6).Equals("Value:"))
            //{
            //    if (Arr[1 - 1].Length > 6)
            //    {
            //        this.val = Arr[1 - 1].Substring(7 - 1, (Arr[1 - 1].Length - 6));
            //    }
            //    else
            //    {
            //        this.val = "";
            //    }
            //}
            //else
            //{
            //    this.val = Arr[1 - 1];
            //}
            //
            //string s1, s2;//, s3;
            //string[] delims = { " ", ";" };//ma ne ",", ob ce alt name uz "."
            //string name = "Value: ";
            //s1 = Arr[1 - 1];
            //if (s1.Substring(1, 6).Equals(name))
            //{
            //    s2 = MyLib.DelAllSubstrings(s1, delims);
            //    //s3 = s2.Substring(7, s2.Length - name.Length);
            //}
            //else
            //{
            //    s2 = s1;
            //}
            //this.val = s2;
            ////
            //this.val = Arr[1 - 1];
        }
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.StringTypeN; }
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
        public override void SetByValDouble(double val)
        {
            this.val = val.ToString();
        }
        public override void SetByValFloat(float val)
        {
            this.val = val.ToString();
        }
        public override void SetByValInt(int val)
        {
            this.val = val.ToString();
        }
        public override void SetByValBool(bool val)
        {
            int n = MyLib.BoolToInt(val);
            this.val = n.ToString();
        }
        public override void SetByValString(string val)
        {
            this.val = val;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellString(this.ToString());
        }
    }//cl
    /*
    public class TCellIntItemsDependent : TDataCell
    {
        int val;
        public TCellIntItemsDependent() { val = 0; }
        public TCellIntItemsDependent(double val) { SetByValDouble(val); }
        public TCellIntItemsDependent(float val) { SetByValFloat(val); }
        public TCellIntItemsDependent(int val) { SetByValInt(val); }
        public TCellIntItemsDependent(bool val) { SetByValBool(val); }
        public TCellIntItemsDependent(string val) { SetByValString(val); }
        //
        public TCellIntItemsDependent(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellIntItemsDependent(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellIntItemsDependent(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellIntItemsDependent(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellIntItemsDependent(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo=true, bool WriteWholeInfo=true)
        {
            //throw new NotImplementedException();
            Arr[1 - 1] = "Cell type:";
            Arr[2 - 1] = TableConsts.IntItemHeaderDependentTypeN.ToString();
            Arr[3 - 1] = "Value";
            Arr[4 - 1] = this.val.ToString();
            QItems = 4;
        }
        public override void SetFromStringArray(string[] Arr, int QItems = 0)
        {
            //throw new NotImplementedException();
            QItems = Arr.Length;
            if (QItems >= 4)
            {
                this.val = Convert.ToInt32(Arr[4 - 1]);
            }
        }
        //
        public override int GetTypeN() { return TableConsts.IntItemHeaderDependentTypeN; }
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
        public override int GetIntValN(int N) { return val; }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByValDouble(double val) { this.val = (int)val; }
        public override void SetByValFloat(float val) { this.val = (int)val; }
        public override void SetByValInt(int val) { this.val = (int)val; }
        public override void SetByValBool(bool val)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void SetByValString(string val)
        {
            double d;
            //this.val = Convert.ToInt32(val);
            d = NumberParse.StrToFloat(val);
            this.val = (int)d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override object Clone()
        {
            return new TCellIntItemsDependent(this.GetIntVal());
        }
    }//cl TCellIntItemsDependent
    */

    //
    public class TCellUniqueNumKeeper : TCellInt//TDataCell
    {
        int val;
        public TCellUniqueNumKeeper() { val = 0; }
        public TCellUniqueNumKeeper(double val) { SetByValDouble(val); }
        public TCellUniqueNumKeeper(float val) { SetByValFloat(val); }
        public TCellUniqueNumKeeper(int val) { this.val = val; }
        public TCellUniqueNumKeeper(bool val) { SetByValBool(val); }
        public TCellUniqueNumKeeper(string val) { SetByValString(val); }
        //
        public TCellUniqueNumKeeper(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellUniqueNumKeeper(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellUniqueNumKeeper(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellUniqueNumKeeper(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellUniqueNumKeeper(string[] val, int Q) { SetByArrString(val, Q); }
        //
        
        //public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        //{
        //    ////throw new NotImplementedException();
        //    //Arr[1 - 1] = "Cell type:";
        //    //Arr[2 - 1] = TableConsts.UniqueIntValKeeperTypeN.ToString();
        //    //Arr[3 - 1] = "Value";
        //    //Arr[4 - 1] = this.val.ToString();
        //    //QItems = 4;
        //}
        //public override void SetFromStringArray(string[] Arr, int QItems = 0)//how to do it 1 time? or make this function empty?
        //{
        //    ////throw new NotImplementedException();
        //    //QItems = Arr.Length;
        //    //if (QItems >= 4)
        //    //{
        //    //    this.val = Convert.ToInt32(Arr[4 - 1]);
        //    //}
        //}
        ////
        //public override void GetItems(ref string[] arr, ref int QItems)
        //{
        //    this.GetNames(ref arr, ref QItems);
        //}
        ////
        public override int GetTypeN() { return TableConsts.UniqueIntValKeeperTypeN; }
        //public override int GetActiveN() { return 1; }
        //public override void SetActiveN(int N) { }
        //public override int GetLength() { return 1; }
        //public override void SetLength(int L) { }
        ////
        //public override double GetDoubleVal()
        //{
        //    //float r;
        //    //r = (float)val;
        //    //return r;
        //    return (double)val;
        //}
        //public override float GetFloatVal()
        //{
        //    //float r;
        //    //r = (float)val;
        //    //return r;
        //    return (float)val;
        //}
        //public override int GetIntVal()
        //{
        //    return val;
        //}
        //public override bool GetBoolVal()
        //{
        //    bool r;
        //    if (val == 1) r = true;
        //    else r = false;
        //    return r;
        //}
        //public override string ToString() { return val.ToString(); }
        ////
        //public override double GetDoubleValN(int N) { return (double)val; }
        //public override float GetFloatValN(int N) { return (float)val; }
        //public override int GetIntValN(int N) { return val; }
        //public override bool GetBoolValN(int N)
        //{
        //    bool r;
        //    if (val == 1) r = true;
        //    else r = false;
        //    return r;
        //}
        //public override string ToStringN(int N) { return val.ToString(); }
        //
        //
        public override void SetByValDouble(double val) { }
        public override void SetByValFloat(float val) { }
        public override void SetByValInt(int val) { }
        public override void SetByValBool(bool val) { }
        public override void SetByValString(string val) { }
        //
        public override void SetByValDoubleN(double val, int N) { }
        public override void SetByValFloatN(float val, int N) { }
        public override void SetByValIntN(int val, int N) { }
        public override void SetByValBoolN(bool val, int N) { }
        public override void SetByValStringN(string val, int N) { }
        //
        public override void SetVal(double val) { }
        public override void SetVal(int val) { }
        public override void SetVal(bool val) { }
        public override void SetVal(string val) { }
        //
        public override void SetValN(double val, int N) { }
        public override void SetValN(int val, int N) { }
        public override void SetValN(bool val, int N) { }
        public override void SetValN(string val, int N) { }
        //
        public override void SetByArrDouble(double[] val, int Q) { }
        public override void SetByArrFloat(float[] val, int Q) { }
        public override void SetByArrInt(int[] val, int Q) { }
        public override void SetByArrBool(bool[] val, int Q) { }
        public override void SetByArrString(string[] val, int Q) { }
        //
        public override void SetByArr(double[] val, int Q) { }
        public override void SetByArr(int[] val, int Q) { }
        public override void SetByArr(bool[] val, int Q) { }
        public override void SetByArr(string[] val, int Q) { }
        //
        public override void AddOrInsDoubleVal(double val, int N) { }
        public override void AddOrInsFloatVal(float val, int N) { }
        public override void AddOrInsIntVal(int val, int N) { }
        public override void AddOrInsBoolVal(bool val, int N) { }
        public override void AddOrInsStringVal(string val, int N) { }
        //
        public override void DelValN(int N) { }
        //
        //public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new double[QItems];
        //    Arr[1 - 1] = GetDoubleVal();
        //}
        //public override void GetFloatArr(ref float[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new float[QItems];
        //    Arr[1 - 1] = GetFloatVal();
        //}
        //public override void GetIntArr(ref int[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new int[QItems];
        //    Arr[1 - 1] = GetIntVal();
        //}
        //public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new bool[QItems];
        //    Arr[1 - 1] = GetBoolVal();
        //}
        //public override void GetStringArr(ref string[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new string[QItems];
        //    Arr[1 - 1] = ToString();
        //}
        //
        public override void SetNameN(string name, int N) {}//{ SetByValStringN(name, N); }
        public override void SetName1(string name) {}//{ SetByValStringN(name, 1); }
        public override void SetName2(string name){}// { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) {}//{ SetByArrString(Arr, Q); }
        //public override string GetNameN(int N) { return ToStringN(N); }
        //public override string GetName1() { return ToStringN(1); }
        //public override string GetName2() { return ToStringN(2); }
        ////public override string GetName3() { return ToStringN(3); }
        //public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        //public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        //public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        //public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        //public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        //public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        //public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        //public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        //public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        //public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        //public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        //public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        //public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        //public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        //public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        //public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        //public override int GetDBFieldCharacteristicsNumber(){ return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        //public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        //public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        //public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        //public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellUniqueNumKeeper(this.GetIntVal());
        }
    }//cl

    //
    //mark1
    public class TCellDoubleMemo : TDataCell
    {
        double[] val;
        int QVals, ActiveValN;
        public TCellDoubleMemo()
        {
            /*val = new double[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TCellDoubleMemo(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TCellDoubleMemo(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TCellDoubleMemo(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TCellDoubleMemo(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TCellDoubleMemo(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TCellDoubleMemo(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TCellDoubleMemo(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TCellDoubleMemo(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TCellDoubleMemo(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TCellDoubleMemo(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            val = new double[QVals];
            for (int i = 1; i <= QVals; i++) val[1 - 1] = 0;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            int LastN = 4, CurN;
            //throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.DoubleArrayTypeN.ToString();
            //Arr[3 - 1] = "Items Quantity:";
            //Arr[4 - 1] = this.QVals.ToString();
            //Arr[5 - 1] = "Active N:";
            //Arr[6 - 1] = this.ActiveValN.ToString();
            //LastN = 6;
            //CurN=LastN;
            //for (int i = 1; i <= this.QVals; i++)
            //{
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item N";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = i.ToString();
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item content:";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = this.val[i-1].ToString();
            //}
            //LastN = CurN;
            //QItems = LastN;
            string name = "Item#", SN, s;
            if (WriteSupplInfo)
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    SN = i.ToString();
                    while (SN.Length < 4)
                    {
                        SN = "0" + SN;
                    }
                    s = name + SN + ": " + (this.val[i - 1]).ToString();
                    MyLib.AddToVector(ref Arr, ref QItems, s);
                }
            }
            else
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, (this.val[i - 1]).ToString());
                }
            }
        }
        public override void SetFromStringArray(string[] Arr, int QItemsExt = 0, int FromNExt=1)
        {
            //throw new NotImplementedException();
            //int LastN = 6, CurN, countItems, countFix=0;
            //double curNum;
            //bool contin, NoDataLeftReally, LastNReached;
            //if (Arr != null)
            //{
            //    QItems = Arr.Length;
            //    if (QItems >= 4)
            //    {
            //        this.ActiveValN = Convert.ToInt32(Arr[4 - 1]);
            //        if (QItems >= 6)
            //        {
            //            CurN=6;
            //            countItems = 0;
            //            this.QVals = Convert.ToInt32(Arr[6 - 1]);
            //            NoDataLeftReally = (QItems >= 6+2);
            //            LastNReached = (countItems >= this.QVals);
            //            contin = (!NoDataLeftReally && !LastNReached);
            //            while (contin)
            //            {
            //                CurN = CurN + 2;
            //                if (QItems >= CurN)
            //                {
            //                    curNum = Convert.ToDouble(Arr[CurN - 1]);
            //                    //countItems++;
            //                    MyLib.AddToVector(ref this.val, ref countItems, curNum);
            //                }
            //                else
            //                {
            //                    contin = false;
            //                    NoDataLeftReally = true;
            //                }
            //                NoDataLeftReally = (6 + 2 * this.QVals<QItems);
            //                LastNReached=(countItems>=this.QVals);
            //                if (LastNReached)
            //                {
            //                    contin = false;
            //                }
            //                if (NoDataLeftReally)
            //                {
            //                    contin = false;
            //                }
            //            }//while
            //            if (NoDataLeftReally && !LastNReached)
            //            {
            //                contin = false;
            //                countFix = countItems;
            //                for (int i = countFix + 1; i <= this.QVals; i++)
            //                {
            //                    MyLib.AddToVector(ref this.val, ref countItems, 0);
            //                }
            //            }
            //        }
            //    }
            //}
            int N;
            string name, nameInitial = "Item#", SN;
            double curDoubleVal;
            string s1, s2, s3, chs;
            string[] delims = { " ", ";", ","};
            //
            int FromN;
            int TypeN = 0, Length = 0, QItems = QItemsExt;
            FromN = FromNExt;
            N = FromN;
            chs = Arr[N - 1];
            this.ParseCharacteristicString(chs, ref TypeN, ref Length, ref this.ActiveValN);
            FromN++;
            //
            for (int i = 1; i <= QItems; i++)
            {
                N = FromN + i - 1;
                s1 = Arr[N - 1];
                SN = i.ToString();
                while (SN.Length < 4)
                {
                    SN = "0" + SN;
                }
                name = nameInitial + SN + ":";
                s2 = MyLib.DelAllSubstrings(s1, delims);
                if (s2.Substring(1 - 1, name.Length).Equals(name))
                {
                    s3 = s2.Substring(name.Length + 1 - 1, s2.Length - name.Length);
                }
                else
                {
                    s3 = s2;
                }
                curDoubleVal = Convert.ToDouble(s3);
                MyLib.AddToVector(ref this.val, ref this.QVals, curDoubleVal);
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.DoubleArrayTypeN; }
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
        public override string ToStringN(int N) { return val[N - 1].ToString(); }
        //
        //public override void SetByValDouble(double val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = (double)val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = (double)val;
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = (double)val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = (double)i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //this.val[ActiveValN - 1] = Convert.ToDouble(val);
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)i;
        }
        public override void SetByValStringN(string val, int N) { this.val[N - 1] = Convert.ToDouble(val); }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = (double)val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = (double)i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //this.val[ActiveValN - 1] = Convert.ToDouble(val);
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N < 1 && N > this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N < 1 && N > this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N < 1 && N > this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N < 1 && N > this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val), N);
            }
            else
            {
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
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);
            }
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            double[] Arr = null;
            int Q = 0;
            this.GetDoubleArr(ref Arr, ref Q);
            return new TCellDoubleMemo(Arr, Q);
        }
        //
    }//cl
    public class TCellFloatMemo : TDataCell
    {
        float[] val;
        int QVals, ActiveValN;
        public TCellFloatMemo()
        {
            //val = new float[1];
            //val[1 - 1] = 0;
            //QVals = 1;
            //ActiveValN = 1;
            construct();
        }
        public TCellFloatMemo(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TCellFloatMemo(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TCellFloatMemo(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TCellFloatMemo(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TCellFloatMemo(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TCellFloatMemo(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TCellFloatMemo(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TCellFloatMemo(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TCellFloatMemo(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TCellFloatMemo(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            val = new float[QVals];
            for (int i = 1; i <= QVals; i++) val[1 - 1] = 0;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //int LastN = 4, CurN;
            ////throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.FloatArrayTypeN.ToString();
            //Arr[3 - 1] = "Items Quantity:";
            //Arr[4 - 1] = this.QVals.ToString();
            //Arr[5 - 1] = "Active N:";
            //Arr[6 - 1] = this.ActiveValN.ToString();
            //LastN = 6;
            //CurN = LastN;
            //for (int i = 1; i <= this.QVals; i++)
            //{
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item N";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = i.ToString();
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item content:";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = this.val[i - 1].ToString();
            //}
            //LastN = CurN;
            //QItems = LastN;
            string name = "Item#", SN, s;
            if (WriteSupplInfo)
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    SN = i.ToString();
                    while (SN.Length < 4)
                    {
                        SN = "0" + SN;
                    }
                    s = name + SN + ": " + (this.val[i - 1]).ToString();
                    MyLib.AddToVector(ref Arr, ref QItems, s);
                }
            }
            else
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, (this.val[i - 1]).ToString());
                }
            }
        }
        public override void SetFromStringArray(string[] Arr, int QItemsExt = 0, int FromNExt=1)
        {
            //throw new NotImplementedException();
            int LastN = 6, CurN, countItems, countFix;
            float curNum;
            //bool contin, NoDataLeftReally, LastNReached;
            //if (Arr != null)
            //{
            //    QItems = Arr.Length;
            //    if (QItems >= 4)
            //    {
            //        this.ActiveValN = Convert.ToInt32(Arr[4 - 1]);
            //        if (QItems >= 6)
            //        {
            //            CurN = 6;
            //            this.QVals = Convert.ToInt32(Arr[6 - 1]);
            //            countItems = 0;
            //            contin = (QItems >= 8 && this.QVals > 0);
            //            while (contin)
            //            {
            //                CurN = CurN + 2;
            //                if (QItems >= CurN)
            //                {
            //                    curNum = (float)Convert.ToDouble(Arr[CurN - 1]);
            //                    //countItems++;
            //                    MyLib.AddToVector(ref this.val, ref countItems, curNum);
            //                }
            //                else
            //                {
            //                    contin = false;
            //                }
            //                NoDataLeftReally = (CurN + 2 > QItems);
            //                LastNReached = (countItems >= this.QVals);
            //                if (LastNReached)
            //                {
            //                    contin = false;
            //                }
            //                if (NoDataLeftReally)//here must be exception!
            //                {
            //                    contin = false;
            //                    countFix = countItems;
            //                    for (int i = countFix + 1; i <= this.QVals; i++)
            //                    {
            //                        MyLib.AddToVector(ref this.val, ref countItems, 0);
            //                    }
            //                }
            //            }//while
            //        }
            //    }
            //}
            int N;
            string name, nameInitial = "Item#", SN;
            float curFloatVal;
            string s1, s2, s3;
            string[] delims = { " ", ";", "," };
            //
            int FromN;
            string chs;
            int TypeN = 0, Length = 0, QItems = QItemsExt;
            FromN = FromNExt;
            N = FromN;
            chs = Arr[N - 1];
            this.ParseCharacteristicString(chs, ref TypeN, ref Length, ref this.ActiveValN);
            FromN++;
            //
            for (int i = 1; i <= QItems; i++)
            {
                N = FromN + i - 1;
                s1 = Arr[N - 1];
                SN = i.ToString();
                while (SN.Length < 4)
                {
                    SN = "0" + SN;
                }
                name = nameInitial + SN + ":";
                s2 = MyLib.DelAllSubstrings(s1, delims);
                if (s2.Substring(1 - 1, name.Length).Equals(name))
                {
                    s3 = s2.Substring(name.Length + 1 - 1, s2.Length - name.Length);
                }
                else
                {
                    s3 = s2;
                }
                curFloatVal = (float)Convert.ToDouble(s3);
                MyLib.AddToVector(ref this.val, ref this.QVals, curFloatVal);
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.FloatArrayTypeN; }
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
        public override string ToStringN(int N) { return val[N - 1].ToString(); }
        //
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = (float)val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = val;
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = (float)val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = (float)i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //double d;
            //d = Convert.ToDouble(val);
            //this.val[ActiveValN - 1] = (float)d;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (float)i;
        }
        public override void SetByValStringN(string val, int N)
        {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = (float)val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = (float)i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //double d;
            //d = Convert.ToDouble(val);
            //this.val[ActiveValN - 1] = (float)d;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
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
        public override void SetValN(string val, int N)
        {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);
            }
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            float[] Arr = null;
            int Q = 0;
            this.GetFloatArr(ref Arr, ref Q);
            return new TCellFloatMemo(Arr, Q);
        }
    }//cl
    public class TCellIntMemo : TDataCell
    {
        int[] val;
        int QVals, ActiveValN;
        public TCellIntMemo()
        {
            /*val = new int[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TCellIntMemo(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TCellIntMemo(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TCellIntMemo(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TCellIntMemo(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TCellIntMemo(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TCellIntMemo(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TCellIntMemo(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TCellIntMemo(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TCellIntMemo(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TCellIntMemo(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            val = new int[QVals];
            for (int i = 1; i <= QVals; i++) val[1 - 1] = 0;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //int LastN = 4, CurN;
            ////throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.IntArrayTypeN.ToString();
            //Arr[3 - 1] = "Items Quantity:";
            //Arr[4 - 1] = this.QVals.ToString();
            //Arr[5 - 1] = "Active N:";
            //Arr[6 - 1] = this.ActiveValN.ToString();
            //LastN = 6;
            //CurN = LastN;
            //for (int i = 1; i <= this.QVals; i++)
            //{
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item N";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = i.ToString();
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item content:";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = this.val[i - 1].ToString();
            //}
            //LastN = CurN;
            //QItems = LastN;
            string name = "Item#", SN, s;
            if (WriteSupplInfo)
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    SN = i.ToString();
                    while (SN.Length < 4)
                    {
                        SN = "0" + SN;
                    }
                    s = name + SN + ": " + (this.val[i - 1]).ToString();
                    MyLib.AddToVector(ref Arr, ref QItems, s);
                }
            }
            else
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, (this.val[i - 1]).ToString());
                }
            }
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItemsExt = 0, int FromNExt=1)
        {
            //throw new NotImplementedException();
            int LastN = 6, CurN, countItems, countFix;
            //int curNum;
            //bool contin, NoDataLeftReally, LastNReached;
            //if (Arr != null)
            //{
            //    QItems = Arr.Length;
            //    if (QItems >= 4)
            //    {
            //        this.ActiveValN = Convert.ToInt32(Arr[4 - 1]);
            //        if (QItems >= 6)
            //        {
            //            CurN = 6;
            //            this.QVals = Convert.ToInt32(Arr[6 - 1]);
            //            countItems = 0;
            //            contin = (QItems >= 8 && this.QVals > 0);
            //            while (contin)
            //            {
            //                CurN = CurN + 2;
            //                if (QItems >= CurN)
            //                {
            //                    curNum = Convert.ToInt32(Arr[CurN - 1]);
            //                    //countItems++;
            //                    MyLib.AddToVector(ref this.val, ref countItems, curNum);
            //                }
            //                else
            //                {
            //                    contin = false;
            //                }
            //                NoDataLeftReally = (CurN + 2 > QItems);
            //                LastNReached = (countItems >= this.QVals);
            //                if (LastNReached)
            //                {
            //                    contin = false;
            //                }
            //                if (NoDataLeftReally)//here must be exception!
            //                {
            //                    contin = false;
            //                    countFix = countItems;
            //                    for (int i = countFix + 1; i <= this.QVals; i++)
            //                    {
            //                        MyLib.AddToVector(ref this.val, ref countItems, 0);
            //                    }
            //                }
            //            }//while
            //        }
            //    }
            //}
            int N;
            string name, nameInitial = "Item#", SN;
            int curIntVal;
            string s1, s2, s3;
            string[] delims = { " ", ";", "," };
            //
            int FromN;
            string chs;
            int TypeN = 0, Length = 0, QItems = QItemsExt;
            FromN = FromNExt;
            N = FromN;
            chs = Arr[N - 1];
            this.ParseCharacteristicString(chs, ref TypeN, ref Length, ref this.ActiveValN);
            FromN++;
            //
            for (int i = 1; i <= QItems; i++)
            {
                N = FromN + i - 1;
                s1 = Arr[N - 1];
                SN = i.ToString();
                while (SN.Length < 4)
                {
                    SN = "0" + SN;
                }
                name = nameInitial + SN + ":";
                s2 = MyLib.DelAllSubstrings(s1, delims);
                if (s2.Substring(1 - 1, name.Length).Equals(name))
                {
                    s3 = s2.Substring(name.Length + 1 - 1, s2.Length - name.Length);
                }
                else
                {
                    s3 = s2;
                }
                curIntVal = Convert.ToInt32(s3);
                MyLib.AddToVector(ref this.val, ref this.QVals, curIntVal);
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.IntArrayTypeN; }
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
        public override string ToStringN(int N) { return val[N - 1].ToString(); }
        //
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = (int)val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = (int)val;
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = (int)val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //int d;
            //d = Convert.ToInt32(val);
            //this.val[ActiveValN - 1] = d;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = i;
        }
        public override void SetByValStringN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = d;
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = (int)val;
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val;
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int i;
            //i = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = i;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //int d;
            //d = Convert.ToInt32(val);
            //this.val[ActiveValN - 1] = d;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);
            }
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            int[] Arr = null;
            int Q = 0;
            this.GetIntArr(ref Arr, ref Q);
            return new TCellIntMemo(Arr, Q);
        }
    }//cl
    //mark2
    public class TCellBoolMemo : TDataCell
    {
        bool[] val;
        int QVals, ActiveValN;
        public TCellBoolMemo()
        {
            val = new bool[1];
            val[1 - 1] = false;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellBoolMemo(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TCellBoolMemo(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TCellBoolMemo(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TCellBoolMemo(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TCellBoolMemo(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TCellBoolMemo(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TCellBoolMemo(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TCellBoolMemo(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TCellBoolMemo(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TCellBoolMemo(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            val = new bool[QVals];
            for (int i = 1; i <= QVals; i++) val[i - 1] = MyLib.BoolValByDefault;//false;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //int LastN = 4, CurN;
            ////throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.IntArrayTypeN.ToString();
            //Arr[3 - 1] = "Items Quantity:";
            //Arr[4 - 1] = this.QVals.ToString();
            //Arr[5 - 1] = "Active N:";
            //Arr[6 - 1] = this.ActiveValN.ToString();
            //LastN = 6;
            //CurN = LastN;
            //for (int i = 1; i <= this.QVals; i++)
            //{
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item N";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = i.ToString();
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item content:";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = (MyLib.BoolToInt(this.val[i - 1])).ToString();
            //}
            //LastN = CurN;
            //QItems = LastN;
            string name = "Item#", SN, s;
            if (WriteSupplInfo)
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    SN = i.ToString();
                    while (SN.Length < 4)
                    {
                        SN = "0" + SN;
                    }
                    s = name + SN + ": " + (MyLib.BoolToInt(this.val[i - 1])).ToString();
                    MyLib.AddToVector(ref Arr, ref QItems, s);
                }
            }
            else
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, (MyLib.BoolToInt(this.val[i - 1])).ToString());
                }
            }
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItemsExt = 0, int FromNExt=1)
        {
            //throw new NotImplementedException();
            //int LastN = 6, CurN, countItems, countFix;
            //bool curVal;
            //bool contin, NoDataLeftReally, LastNReached;
            //if (Arr != null)
            //{
            //    QItems = Arr.Length;
            //    if (QItems >= 4)
            //    {
            //        this.ActiveValN = Convert.ToInt32(Arr[4 - 1]);
            //        if (QItems >= 6)
            //        {
            //            CurN = 6;
            //            this.QVals = Convert.ToInt32(Arr[6 - 1]);
            //            countItems = 0;
            //            contin = (QItems >= 8 && this.QVals > 0);
            //            while (contin)
            //            {
            //                CurN = CurN + 2;
            //                if (QItems >= CurN)
            //                {
            //                    curVal = MyLib.IntToBool(Convert.ToInt32(Arr[CurN - 1]));
            //                    //countItems++;
            //                    MyLib.AddToVector(ref this.val, ref countItems, curVal);
            //                }
            //                else
            //                {
            //                    contin = false;
            //                }
            //                NoDataLeftReally = (CurN + 2 > QItems);
            //                LastNReached = (countItems >= this.QVals);
            //                if (LastNReached)
            //                {
            //                    contin = false;
            //                }
            //                if (NoDataLeftReally)//here must be exception!
            //                {
            //                    contin = false;
            //                    countFix = countItems;
            //                    for (int i = countFix + 1; i <= this.QVals; i++)
            //                    {
            //                        curVal = MyLib.BoolValByDefault;
            //                        MyLib.AddToVector(ref this.val, ref countItems,curVal);
            //                    }
            //                }
            //            }//while
            //        }
            //    }
            //}
            int N;
            string name, nameInitial = "Item#", SN;
            int curIntVal;
            bool curBoolVal;
            string s1, s2, s3;
            string[] delims = { " ", ";", "," };
            //
            int FromN;
            string chs;
            int TypeN = 0, Length = 0, QItems = QItemsExt;
            FromN = FromNExt;
            N = FromN;
            chs = Arr[N - 1];
            this.ParseCharacteristicString(chs, ref TypeN, ref Length, ref this.ActiveValN);
            FromN++;
            //
            for (int i = 1; i <= QItems; i++)
            {
                N = FromN + i - 1;
                s1 = Arr[N - 1];
                SN = i.ToString();
                while (SN.Length < 4)
                {
                    SN = "0" + SN;
                }
                name = nameInitial + SN + ":";
                s2 = MyLib.DelAllSubstrings(s1, delims);
                if (s2.Substring(1 - 1, name.Length).Equals(name))
                {
                    s3 = s2.Substring(name.Length + 1 - 1, s2.Length - name.Length);
                }
                else
                {
                    s3 = s2;
                }
                curIntVal = Convert.ToInt32(s3);
                curBoolVal = MyLib.IntToBool(curIntVal);
                MyLib.AddToVector(ref this.val, ref this.QVals, curBoolVal);
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.BoolArrayTypeN; }
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
        public override string ToString()
        {
            int i;
            i = MyLib.BoolToInt(val[ActiveValN - 1]);
            return i.ToString();
        }
        //
        public override double GetDoubleValN(int N)
        {
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
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = MyLib.IntToBool((int)val);
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = MyLib.IntToBool((int)val);
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] =  MyLib.IntToBool((int)val);
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //this.val[ActiveValN - 1] = val;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //int d;
            //d = Convert.ToInt32(val);
            //this.val[ActiveValN - 1] = MyLib.IntToBool(d);
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = MyLib.IntToBool((int)val);
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = MyLib.IntToBool((int)val);
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = MyLib.IntToBool(val);
        }
        public override void SetByValBoolN(bool val, int N)
        {
            this.val[N - 1] = val;
        }
        public override void SetByValStringN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = MyLib.IntToBool((int)val);
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = MyLib.IntToBool(val);
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //this.val[ActiveValN - 1] = val;
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //int d;
            //d = Convert.ToInt32(val);
            //this.val[ActiveValN - 1] = MyLib.IntToBool(d);
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
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
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);
            }
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay() { return ""; }
        public override void SetDBTableNameToDisplay(string name) { }
        //2 Тип БД BType
        public override int GetDBTypeN() { return 0; }
        public override void SetDBTypeN(int TypeN) { }
        public override string GetDBConnectionString() { return ""; }
        //public override void SetDBConnectiobString(string ConnStr) { }
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName() { return ""; }
        public override void SetDBFileFullName(string name) { }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC() { return ""; }
        public override void SetDBNameInSDBC(string name) { }
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB() { return ""; }
        public override void SetDBTableNameInDB(string name) { }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay() { return ""; }
        public override void SetDBFieldNameToDisplay(string name) { }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable() { return ""; }
        public override void SetDBFieldNameInTable(string name) { }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB() { return ""; }
        public override void SetItemsDBTableNameInDB(string name) { }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName() { return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN() { return 0; }
        public override void SetDBFieldTypeN(int TypeN) { }
        public override string GetDBFieldTypeName() { return ""; }
        public override void SetDBFieldTypeName(string name) { }
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength() { return 0; }
        public override void SetDBFieldLength(int L) { }
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity() { return 0; }
        public override void SetItems(string[] items, int Q) { }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber() { return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            bool[] Arr = null;
            int Q = 0;
            this.GetBoolArr(ref Arr, ref Q);
            return new TCellBoolMemo(Arr, Q);
        }
    }//cl
    public class TCellStringMemo : TDataCell
    {
        string[] val;
        int QVals, ActiveValN;
        public TCellStringMemo()
        {
            /*val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TCellStringMemo(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TCellStringMemo(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TCellStringMemo(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TCellStringMemo(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TCellStringMemo(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TCellStringMemo(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TCellStringMemo(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TCellStringMemo(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TCellStringMemo(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TCellStringMemo(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            val = new string[QVals];
            for (int i = 1; i <= QVals; i++) val[i - 1] = "";
            //QVals = 1;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            //int LastN = 4, CurN;
            ////throw new NotImplementedException();
            //Arr[1 - 1] = "Cell type:";
            //Arr[2 - 1] = TableConsts.IntArrayTypeN.ToString();
            //Arr[3 - 1] = "Items Quantity:";
            //Arr[4 - 1] = this.QVals.ToString();
            //Arr[5 - 1] = "Active N:";
            //Arr[6 - 1] = this.ActiveValN.ToString();
            //LastN = 6;
            //CurN = LastN;
            //for (int i = 1; i <= this.QVals; i++)
            //{
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item N";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = i.ToString();
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = "Item content:";
            //    CurN = CurN + 1;
            //    Arr[CurN - 1] = this.val[i - 1].ToString();
            //}
            //LastN = CurN;
            //QItems = LastN;
            string name = "Item#", SN, s;
            if (WriteSupplInfo)
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    SN = i.ToString();
                    while (SN.Length < 4)
                    {
                        SN = "0" + SN;
                    }
                    s = name + SN + ":" + (this.val[i - 1]).ToString();
                    MyLib.AddToVector(ref Arr, ref QItems, s);
                }
            }
            else
            {
                for (int i = 1; i <= this.QVals; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, (this.val[i - 1]).ToString());
                }
            }
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItemsExt = 0, int FromNExt=1)
        {
            //throw new NotImplementedException();
            //int LastN = 6, CurN, countItems, countFix;
            //string curVal;
            //bool contin, NoDataLeftReally, LastNReached;
            //if (Arr != null)
            //{
            //    QItems = Arr.Length;
            //    if (QItems >= 4)
            //    {
            //        this.ActiveValN = Convert.ToInt32(Arr[4 - 1]);
            //        if (QItems >= 6)
            //        {
            //            CurN = 6;
            //            this.QVals = Convert.ToInt32(Arr[6 - 1]);
            //            countItems = 0;
            //            contin = (QItems >= 8 && this.QVals > 0);
            //            while (contin)
            //            {
            //                CurN = CurN + 2;
            //                if (QItems >= CurN)
            //                {
            //                    curVal = Arr[CurN - 1];
            //                    //countItems++;
            //                    MyLib.AddToVector(ref this.val, ref countItems, curVal);
            //                }
            //                else
            //                {
            //                    contin = false;
            //                }
            //                NoDataLeftReally = (CurN + 2 > QItems);
            //                LastNReached = (countItems >= this.QVals);
            //                if (LastNReached)
            //                {
            //                    contin = false;
            //                }
            //                if (NoDataLeftReally)//here must be exception!
            //                {
            //                    contin = false;
            //                    countFix = countItems;
            //                    for (int i = countFix + 1; i <= this.QVals; i++)
            //                    {
            //                        curVal = "";
            //                        MyLib.AddToVector(ref this.val, ref countItems, curVal);
            //                    }
            //                }
            //            }//while
            //        }
            //    }
            //}
            int N;
            string name, nameInitial = "Item#", SN;
            string curStrVal;
            string s1, s2, s3;
            //string[] delims = { " ", ";", "," };
            //
            int FromN;
            string chs;
            int TypeN = 0, Length = 0, QItems = QItemsExt;
            FromN = FromNExt;
            N = FromN;
            chs = Arr[N - 1];
            this.ParseCharacteristicString(chs, ref TypeN, ref Length, ref this.ActiveValN);
            FromN++;
            //
            for (int i = 1; i <= QItems; i++)
            {
                N = FromN + i - 1;
                s1 = Arr[N - 1];
                SN = i.ToString();
                while (SN.Length < 4)
                {
                    SN = "0" + SN;
                }
                name = nameInitial + SN + ":";
                //s2 = MyLib.DelAllSubstrings(s1, delims);
                s2 = s1;
                if (s2.Substring(1 - 1, name.Length).Equals(name))
                {
                    s3 = s2.Substring(name.Length + 1 - 1, s2.Length - name.Length);
                }
                else
                {
                    s3 = s2;
                }
                curStrVal =s3;
                MyLib.AddToVector(ref this.val, ref this.QVals, curStrVal);
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.StringArrayTypeN; }
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
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0");
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValBoolN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetByValStringN(string val, int N)
        {
            this.val[N - 1] = val;
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int n;
            //n = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = n.ToString();
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
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
        public override void SetValN(string val, int N) { this.val[N - 1] = val; }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
            this.QVals = Q;
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);// Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);//Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);// Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);//Arr[1 - 1] = ToString();
            }
        }
        //
        public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        public override void SetName1(string name) { SetByValStringN(name, 1); }
        public override void SetName2(string name) { SetByValStringN(name, 2); }
        //public override void SetName3(string name) { SetByValStringN(name, 3); }
        public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        public override string GetNameN(int N) { return ToStringN(N); }
        public override string GetName1() { return ToStringN(1); }
        public override string GetName2() { return ToStringN(2); }
        //public override string GetName3() { return ToStringN(3); }
        public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        public override int GetLengthOfNamesList() { return 1; }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name) { }
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber(){ return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            string[] Arr = null;
            int Q = 0;
            this.GetStringArr(ref Arr, ref Q);
            return new TCellStringMemo(Arr, Q);
        }
    }//cl
    //

    public class TDataBaseFieldHeader_WithItems_Double : TDataCell
    {
        double[] val;//items;
        string[] names;
        int QVals, ActiveValN_ByDefault;
        public TDataBaseFieldHeader_WithItems_Double()
        {
            /*val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TDataBaseFieldHeader_WithItems_Double(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TDataBaseFieldHeader_WithItems_Double(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TDataBaseFieldHeader_WithItems_Double(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TDataBaseFieldHeader_WithItems_Double(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TDataBaseFieldHeader_WithItems_Double(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TDataBaseFieldHeader_WithItems_Double(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Double(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Double(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Double(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Double(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public TDataBaseFieldHeader_WithItems_Double(double[] val, int Q, string Name1, string Name2)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            SetName1(Name1);
            SetName2(Name2);
        }
        public TDataBaseFieldHeader_WithItems_Double(double[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 3) MinQ = names.Length;
            else MinQ = 3;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Double(double[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 3) MinQ = QNames;
            else MinQ = 3;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Double(int[] val, int Q, string Name1, string Name2)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            SetName1(Name1);
            SetName2(Name2);
        }
        public TDataBaseFieldHeader_WithItems_Double(int[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Double(int[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //public TDataBaseFieldHeader_WithItems_Double(string[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrString(val, Q);  //SetByArrString(val, Q);
        //    //SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //    for(int i=1; i<=7; i++) SetNameN
        //}
        public TDataBaseFieldHeader_WithItems_Double(string[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrString(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Double(string[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrString(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            names = new string[7];
            for (int i = 1; i <= 7; i++) names[i - 1] = "";

            val = new double[QVals];
            //items
            for (int i = 1; i <= QVals; i++) val[i - 1] = 0;
            //QVals = 1;
            //ActiveValN = 1;
            ActiveValN_ByDefault = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            int LastN, CurN, QNames=this.names.Length;
            //throw new NotImplementedException();
            Arr[1 - 1] = "Cell type:";
            Arr[2 - 1] = TableConsts.DoubleItemsFieldHeaderCellTypeN.ToString();
            Arr[3 - 1] = "Items Quantity:";
            Arr[4 - 1] = this.QVals.ToString();
            Arr[5 - 1] = "Names Quantity:";
            Arr[6 - 1] = QNames.ToString();
            Arr[7 - 1] = "Active N (by default):";
            Arr[8 - 1] = this.ActiveValN_ByDefault.ToString();
            LastN = 8;
            CurN = LastN;
            if (this.QVals > 0)
            {
                CurN = LastN + 1;
                Arr[CurN - 1] = "Vals:";//9
                LastN = CurN;
                for (int i = 1; i <= this.QVals; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item N";//10 or >
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();//11 or >
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item content:";//12 or >
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.val[i - 1].ToString();//13 or >
                }
                LastN = CurN;
            }
            //
            if (QNames > 0)
            {
                CurN = LastN+1;
                Arr[CurN - 1] = "Names:";
                LastN = CurN;
                for (int i = 1; i <= QNames; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name N";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name content:";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.names[i - 1];
                }
            }
            LastN = CurN;
            QItems = LastN;
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException(
            int QNames = 0, LastN, CurN, count, countFix;
            bool contin, NoDataLeftReally, LastNReached;//RealDataQ_LT_GivenQVal;
            QItems = Arr.Length;
            double CurNum;
            if (QItems > 4 + FromN-1)
            {
                this.QVals = Convert.ToInt32(Arr[4 + FromN - 1 - 1]);
                if (QItems > 6 + FromN - 1)
                {
                    QNames = Convert.ToInt32(Arr[6 + FromN - 1 - 1]);
                    if (QItems > 0)
                    {
                        this.ActiveValN_ByDefault = Convert.ToInt32(Arr[8 + FromN - 1 - 1]);
                        //Items
                        contin = (this.QVals > 0 && QItems >= 13 + FromN - 1);
                        LastN = 9 + FromN - 1;
                        CurN=LastN;
                        count=0;
                        while (contin)
                        {
                            CurN = CurN + 4;
                            if (CurN <= QItems)
                            {
                                CurNum = Convert.ToDouble(Arr[CurN - 1]);
                                MyLib.AddToVector(ref this.val, ref count, CurNum);
                            }
                            else
                            {
                                contin = false;
                            }
                            //RealDataQ_LT_GivenQVal
                            NoDataLeftReally = (CurN + 4 > QItems);
                            LastNReached = (count >= this.QVals || CurN >= LastN + 4 * this.QVals);
                            if (LastNReached)
                            {
                                contin=false;
                            }
                            if (NoDataLeftReally)
                            {
                                contin = false;
                                countFix = count;
                                for (int i = countFix + 1; i <= this.QVals; i++)
                                {
                                    CurNum = 0;
                                    MyLib.AddToVector(ref this.val, ref count, CurNum);
                                }
                            }
                        }//wh
                        LastN = LastN + 4 * QVals;
                        //so must be, ma mab no data be really da, so
                        LastN = CurN;
                    }//if (QItems > 0)
                }
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.DoubleItemsFieldHeaderCellTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<double>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN_ByDefault; }
        public override void SetActiveN(int N) { this.ActiveValN_ByDefault = N; }
        //
        public override double GetDoubleVal()
        {
            int ActiveValN = 1;
            return /*NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
        }
        public override float GetFloatVal()
        {
            int ActiveValN = 1;
            return (float)/*(NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
        }
        public override int GetIntVal()
        {
            double d, d1;
            int ActiveValN = 1;
            d = /*NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolVal()
        {
            int d = GetIntVal();
            return MyLib.IntToBool(d);
        }
        public override string ToString()
        {
            int ActiveValN = 1;
            return val[ActiveValN - 1].ToString();
        }
        //
        public override double GetDoubleValN(int N)
        {
            return /*NumberParse.StrToFloat(*/val[N - 1];//);
        }
        public override float GetFloatValN(int N)
        {
            return (float)/*(NumberParse.StrToFloat(*/val[N - 1];//));
        }
        public override int GetIntValN(int N)
        {
            double d, d1;
            d = val[N - 1];//NumberParse.StrToFloat(val[N - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolValN(int N)
        {
            int d = GetIntValN(N);
            return MyLib.IntToBool(d);
        }
        public override string ToStringN(int N)
        {
            return val[N - 1].ToString();
        }
        //
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0");
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = val;//.ToString();
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = (double)val;//.ToString();
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = (double)val;//.ToString();
        }
        public override void SetByValBoolN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)n;//.ToString();
        }
        public override void SetByValStringN(string val, int N)
        {
            this.val[N - 1] = NumberParse.ConvertToNumber(val, 10);//qu so?
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int n;
            //n = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = n.ToString();
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val;/*.ToString();*/ }
        public override void SetValN(int val, int N)
        {
            int ActiveValN = 1;
            this.val[ActiveValN - 1] = (double)val/*.ToString()*/;
        }
        public override void SetValN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)n;//.ToString();
        }
        public override void SetValN(string val, int N) { this.val[N - 1] = NumberParse.ConvertToNumber(val, 10); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
            this.QVals = Q;
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val/*.ToString()*/);
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/, N); //ac (double) also works
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/); //ac (double) also works
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/, N); //ac (double) also works
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/); //ac (double) also works
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val)/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val)/*.ToString()*/);
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, NumberParse.ConvertToNumber(val)/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, NumberParse.ConvertToNumber(val)/*.ToString()*/);
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);// Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);//Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);// Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);//Arr[1 - 1] = ToString();
            }
        }
        //
        //public void SetNameN(string name, int N) { SetByValStringN(name, N); }
        //public void SetName1(string name) { SetByValStringN(name, 1); }
        //public void SetName2(string name) { SetByValStringN(name, 2); }
        //public void SetName3(string name) { SetByValStringN(name, 3); }
        //public void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        //public string GetNameN(int N) { return ToStringN(N); }
        //public string GetName1() { return ToStringN(1); }
        //public string GetName2() { return ToStringN(2); }
        //public string GetName3() { return ToStringN(3); }
        //public void GetNames(ref string[] Arr, ref int QItems) { ToStringArr(ref Arr, ref QItems); }
        //
        public override void SetNameN(string name, int N) { if (N >= 1 && N <= 7) names[N - 1] = name; }
        public override void SetName1(string name) { names[1 - 1] = name; ; }
        public override void SetName2(string name) { names[2 - 1] = name; ; }
        //public override void SetName3(string name) { names[3 - 1] = name; ; }
        public override void SetNames(string[] Arr, int Q)
        {
            int MinQ;
            if (Q < 7) MinQ = Q; else MinQ = 7;
            for (int i = 1; i <= 3; i++) names[i - 1] = Arr[i - 1];
        }
        public override string GetNameN(int N) { return names[N - 1]; }
        public override string GetName1() { return names[1 - 1]; }
        public override string GetName2() { return names[2 - 1]; }
        //public override string GetName3() { return names[3 - 1]; }
        public override void GetNames(ref string[] Arr, ref int QItems)
        {
            Arr = names;
            QItems = 3;
            for (int i = 1; i <= 3; i++) { if (names[i - 1] != null && (!(names[i - 1].Equals("")))) QItems = i; }
        }
        public override int GetLengthOfNamesList()
        {
            int R = 3;
            while (names[R - 1] == null || names[R - 1] == "") R--;
            return R;
        }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber(){ return 0; }
        public override void SetDBFieldCharacteristicsNumber(int TypeN) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            string[] Names = null;
            double[] Items = null;
            int QItems, QNames = 0;
            QNames = this.GetLengthOfNamesList();
            QItems = this.GetLength();
            this.GetNames(ref Names, ref QNames);
            this.GetDoubleArr(ref Items, ref QItems);
            return new TDataBaseFieldHeader_WithItems_Double(Items, QItems, Names, QNames);
        }
    }//cl TDataBaseFieldHeader_WithItems_Double
    //mark3
    public class TDataBaseFieldHeader_WithItems_Int : TDataCell
    {
        double[] val;
        string[] names;
        int QVals, ActiveValN;
        public TDataBaseFieldHeader_WithItems_Int()
        {
            /*val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TDataBaseFieldHeader_WithItems_Int(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TDataBaseFieldHeader_WithItems_Int(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TDataBaseFieldHeader_WithItems_Int(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TDataBaseFieldHeader_WithItems_Int(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TDataBaseFieldHeader_WithItems_Int(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TDataBaseFieldHeader_WithItems_Int(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Int(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Int(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Int(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_Int(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        public TDataBaseFieldHeader_WithItems_Int(double[] val, int Q, string Name1, string Name2)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            SetName1(Name1);
            SetName2(Name2); 
        }
        public TDataBaseFieldHeader_WithItems_Int(double[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Int(double[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //public TDataBaseFieldHeader_WithItems_Int(int[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrInt(val, Q);  //SetByArrString(val, Q);
        //    SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //}
        public TDataBaseFieldHeader_WithItems_Int(int[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Int(int[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //public TDataBaseFieldHeader_WithItems_Int(string[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrString(val, Q);  //SetByArrString(val, Q);
        //    SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //}
        public TDataBaseFieldHeader_WithItems_Int(string[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrString(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_Int(string[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrString(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            names = new string[7];
            for (int i = 1; i <= 7; i++) names[i - 1] = "";
            val = new double[QVals];
            for (int i = 1; i <= QVals; i++) val[i - 1] = 0;
            //QVals = 1;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            int LastN, CurN, QNames = this.names.Length;
            //throw new NotImplementedException();
            Arr[1 - 1] = "Cell type:";
            Arr[2 - 1] = TableConsts.IntItemsFieldHeaderCellTypeN.ToString();
            Arr[3 - 1] = "Items Quantity:";
            Arr[4 - 1] = this.QVals.ToString();
            Arr[5 - 1] = "Names Quantity:";
            Arr[6 - 1] = QNames.ToString();
            Arr[7 - 1] = "Active N (by default):";
            Arr[8 - 1] = this.ActiveValN.ToString();
            LastN = 8;
            CurN = LastN;
            if (this.QVals > 0)
            {
                CurN = LastN + 1;
                Arr[CurN - 1] = "Vals:";
                LastN = CurN;
                for (int i = 1; i <= this.QVals; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item N";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item content:";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.val[i - 1].ToString();
                }
                LastN = CurN;
            }
            //
            if (QNames > 0)
            {
                CurN = LastN + 1;
                Arr[CurN - 1] = "Names:";
                LastN = CurN;
                for (int i = 1; i <= QNames; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name N";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name content:";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.names[i - 1];
                }
            }
            LastN = CurN;
            QItems = LastN;
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException(
            int QNames = 0, LastN, CurN, count, countFix;
            bool contin, NoDataLeftReally, LastNReached;//RealDataQ_LT_GivenQVal;
            QItems = Arr.Length;
            int CurNum;
            if (QItems > 4 + FromN - 1)
            {
                this.QVals = Convert.ToInt32(Arr[4 + FromN - 1 - 1]);
                if (QItems > 6 + FromN - 1)
                {
                    QNames = Convert.ToInt32(Arr[6 + FromN - 1 - 1]);
                    if (QItems > 0)
                    {
                        this.ActiveValN = Convert.ToInt32(Arr[8 + FromN - 1 - 1]);
                        //Items
                        contin = (this.QVals > 0 && QItems >= 13 + FromN - 1);
                        LastN = 9;
                        CurN = LastN;
                        count = 0;
                        while (contin)
                        {
                            CurN = CurN + 4;
                            if (CurN <= QItems)
                            {
                                CurNum = Convert.ToInt32(Arr[CurN - 1]);
                                MyLib.AddToVector(ref this.val, ref count, CurNum);
                            }
                            else
                            {
                                contin = false;
                            }
                            //RealDataQ_LT_GivenQVal
                            NoDataLeftReally = (CurN + 4 > QItems);
                            LastNReached = (count >= this.QVals || CurN >= LastN + 4 * this.QVals);
                            if (LastNReached)
                            {
                                contin = false;
                            }
                            if (NoDataLeftReally)
                            {
                                contin = false;
                                countFix = count;
                                for (int i = countFix + 1; i <= this.QVals; i++)
                                {
                                    CurNum = 0;
                                    MyLib.AddToVector(ref this.val, ref count, CurNum);
                                }
                            }
                        }//wh
                        LastN = LastN + 4 * QVals;
                        //so must be, ma mab no data be really da, so
                        LastN = CurN;
                    }//if (QItems > 0)
                }
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.IntItemsFieldHeaderCellTypeN; }
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
        public override double GetDoubleVal()
        {
            return /*NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
        }
        public override float GetFloatVal()
        {
            return (float)/*(NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
        }
        public override int GetIntVal()
        {
            double d, d1;
            d = /*NumberParse.StrToFloat(*/val[ActiveValN - 1];//);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolVal()
        {
            int d = GetIntVal();
            return MyLib.IntToBool(d);
        }
        public override string ToString()
        {
            return val[ActiveValN - 1].ToString();
        }
        //
        public override double GetDoubleValN(int N)
        {
            return /*NumberParse.StrToFloat(*/val[N - 1];//);
        }
        public override float GetFloatValN(int N)
        {
            return (float)/*(NumberParse.StrToFloat(*/val[N - 1];//));
        }
        public override int GetIntValN(int N)
        {
            double d, d1;
            d = val[N - 1];//NumberParse.StrToFloat(val[N - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolValN(int N)
        {
            int d = GetIntValN(N);
            return MyLib.IntToBool(d);
        }
        public override string ToStringN(int N)
        {
            return val[N - 1].ToString();
        }
        //
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0");
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = val;//.ToString();
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = (double)val;//.ToString();
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = (double)val;//.ToString();
        }
        public override void SetByValBoolN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)n;//.ToString();
        }
        public override void SetByValStringN(string val, int N)
        {
            this.val[N - 1] = NumberParse.ConvertToNumber(val, 10);//qu so?
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int n;
            //n = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = n.ToString();
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val;/*.ToString();*/ }
        public override void SetValN(int val, int N) { this.val[ActiveValN - 1] = (double)val/*.ToString()*/; }
        public override void SetValN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)n;//.ToString();
        }
        public override void SetValN(string val, int N) { this.val[N - 1] = NumberParse.ConvertToNumber(val, 10); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
            this.QVals = Q;
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new double[Q];//string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val/*.ToString()*/);
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/, N); //ac (double) also works
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/); //ac (double) also works
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/, N); //ac (double) also works
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val/*.ToString()*/); //ac (double) also works
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val)/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val)/*.ToString()*/);
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, NumberParse.ConvertToNumber(val)/*.ToString()*/, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, NumberParse.ConvertToNumber(val)/*.ToString()*/);
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);// Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);//Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);// Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);//Arr[1 - 1] = ToString();
            }
        }
        //
        //public void SetNameN(string name, int N) { SetByValStringN(name, N); }
        //public void SetName1(string name) { SetByValStringN(name, 1); }
        //public void SetName2(string name) { SetByValStringN(name, 2); }
        //public void SetName3(string name) { SetByValStringN(name, 3); }
        //public void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        //public string GetNameN(int N) { return ToStringN(N); }
        //public string GetName1() { return ToStringN(1); }
        //public string GetName2() { return ToStringN(2); }
        //public string GetName3() { return ToStringN(3); }
        //public void GetNames(ref string[] Arr, ref int QItems) { ToStringArr(ref Arr, ref QItems); }
        //
        public override void SetNameN(string name, int N) { if (N >= 1 && N <= 7) names[N - 1] = name; }
        public override void SetName1(string name) { names[1 - 1] = name; ; }
        public override void SetName2(string name) { names[2 - 1] = name; ; }
        //public override void SetName3(string name) { names[3 - 1] = name; ; }
        public override void SetNames(string[] Arr, int Q)
        {
            int MinQ;
            if (Q < 7) MinQ = Q; else MinQ = 7;
            for (int i = 1; i <= 7; i++) names[i - 1] = Arr[i - 1];
        }
        public override string GetNameN(int N) { return names[N - 1]; }
        public override string GetName1() { return names[1 - 1]; }
        public override string GetName2() { return names[2 - 1]; }
        //public override string GetName3() { return names[3 - 1]; }
        public override void GetNames(ref string[] Arr, ref int QItems)
        {
            Arr = names;
            QItems = 7;
            for (int i = 1; i <= 7; i++) { if (names[i - 1] != null && (!(names[i - 1].Equals("")))) QItems = i; }
        }
        public override int GetLengthOfNamesList()
        {
            int R = 7;
            while (names[R - 1] == null || names[R - 1] == "") R--;
            return R;
        }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectionString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber(){ return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            string[] Names = null;
            int[] Items = null;
            int QItems, QNames = 0;
            QNames = this.GetLengthOfNamesList();
            QItems = this.GetLength();
            this.GetNames(ref Names, ref QNames);
            this.GetIntArr(ref Items, ref QItems);
            return new TDataBaseFieldHeader_WithItems_Int(Items, QItems, Names, QNames);
        }
    }//cl
    public class TDataBaseFieldHeader_WithItems_String : TDataCell
    {
        string[] val;
        string[] names;
        int QVals, ActiveValN;
        public TDataBaseFieldHeader_WithItems_String()
        {
            /*val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;*/
            construct();
        }
        public TDataBaseFieldHeader_WithItems_String(double val)
        {
            construct();
            SetByValDouble(val);
        }
        public TDataBaseFieldHeader_WithItems_String(float val)
        {
            construct();
            SetByValFloat(val);
        }
        public TDataBaseFieldHeader_WithItems_String(int val)
        {
            construct();
            SetByValInt(val);
        }
        public TDataBaseFieldHeader_WithItems_String(bool val)
        {
            construct();
            SetByValBool(val);
        }
        public TDataBaseFieldHeader_WithItems_String(string val)
        {
            construct();
            SetByValString(val);
        }
        //
        public TDataBaseFieldHeader_WithItems_String(double[] val, int Q)
        {
            construct(Q);
            SetByArrDouble(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_String(float[] val, int Q)
        {
            construct(Q);
            SetByArrFloat(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_String(int[] val, int Q)
        {
            construct(Q);
            SetByArrInt(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_String(bool[] val, int Q)
        {
            construct(Q);
            SetByArrBool(val, Q);
        }
        public TDataBaseFieldHeader_WithItems_String(string[] val, int Q)
        {
            construct(Q);
            SetByArrString(val, Q);
        }
        //
        //public TDataBaseFieldHeader_WithItems_String(double[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrDouble(val, Q);  //SetByArrString(val, Q);
        //    SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //}
        public TDataBaseFieldHeader_WithItems_String(double[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_String(double[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrDouble(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //public TDataBaseFieldHeader_WithItems_String(int[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrInt(val, Q);  //SetByArrString(val, Q);
        //    SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //}
        public TDataBaseFieldHeader_WithItems_String(int[] val, int Q, string[] names)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (names.Length < 7) MinQ = names.Length;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        public TDataBaseFieldHeader_WithItems_String(int[] val, int Q, string[] names, int QNames)
        {
            construct(Q);
            SetByArrInt(val, Q);  //SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //public TDataBaseFieldHeader_WithItems_String(string[] val, int Q, string Name1, string Name2, string Name3)
        //{
        //    construct(Q);
        //    SetByArrString(val, Q);
        //    SetName1(Name1); SetName2(Name2); SetName3(Name3);
        //}
        //public TDataBaseFieldHeader_WithItems_String(string[] val, int Q, string[] names) //deleted
        public TDataBaseFieldHeader_WithItems_String(string[] val, string[] names, int QExt=0, int QNames = 7)
        {
            int Q;
            if (names != null && QExt >= 1 && QExt <= names.Length) Q = QExt;
            else if (names != null) Q = names.Length;
            else Q = 0;
            construct(Q);
            SetByArrString(val, Q);
            int MinQ;
            if (QNames < 7) MinQ = QNames;
            else MinQ = 7;
            SetNames(names, MinQ);
        }
        //
        public override void construct(int n = 1)
        {
            QVals = n;
            names = new string[7];
            for (int i = 1; i <= 7; i++) names[i - 1] = "";
            val = new string[QVals];
            for (int i = 1; i <= QVals; i++) val[i - 1] = "";
            //QVals = 1;
            ActiveValN = 1;
        }
        //
        public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            int LastN, CurN, QNames = this.names.Length;
            //throw new NotImplementedException();
            Arr[1 - 1] = "Cell type:";
            Arr[2 - 1] = TableConsts.IntItemsFieldHeaderCellTypeN.ToString();
            Arr[3 - 1] = "Items Quantity:";
            Arr[4 - 1] = this.QVals.ToString();
            Arr[5 - 1] = "Names Quantity:";
            Arr[6 - 1] = QNames.ToString();
            Arr[7 - 1] = "Active N (by default):";
            Arr[8 - 1] = this.ActiveValN.ToString();
            LastN = 8;
            CurN = LastN;
            if (this.QVals > 0)
            {
                CurN = LastN + 1;
                Arr[CurN - 1] = "Vals:";
                LastN = CurN;
                for (int i = 1; i <= this.QVals; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item N";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Item content:";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.val[i - 1].ToString();
                }
                LastN = CurN;
            }
            //
            if (QNames > 0)
            {
                CurN = LastN + 1;
                Arr[CurN - 1] = "Names:";
                LastN = CurN;
                for (int i = 1; i <= QNames; i++)
                {
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name N";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    Arr[CurN - 1] = "Name content:";
                    CurN = CurN + 1;
                    Arr[CurN - 1] = this.names[i - 1];
                }
            }
            LastN = CurN;
            QItems = LastN;
        }//fn
        public override void SetFromStringArray(string[] Arr, int QItems = 0, int FromN=1)
        {
            //throw new NotImplementedException(
            int QNames = 0, LastN, CurN, count, countFix;
            bool contin, NoDataLeftReally, LastNReached;//RealDataQ_LT_GivenQVal;
            QItems = Arr.Length;
            string CurVal;
            if (QItems > 4 + FromN - 1)
            {
                this.QVals = Convert.ToInt32(Arr[4 + FromN - 1 - 1]);
                if (QItems > 6 + FromN - 1)
                {
                    QNames = Convert.ToInt32(Arr[6 + FromN - 1 - 1]);
                    if (QItems > 0)
                    {
                        this.ActiveValN = Convert.ToInt32(Arr[8 + FromN - 1 - 1]);
                        //Items
                        contin = (this.QVals > 0 && QItems >= 13 + FromN - 1);
                        LastN = 9 + FromN - 1;
                        CurN = LastN;
                        count = 0;
                        while (contin)
                        {
                            CurN = CurN + 4;
                            if (CurN <= QItems)
                            {
                                CurVal = Arr[CurN - 1];
                                MyLib.AddToVector(ref this.val, ref count, CurVal);
                            }
                            else
                            {
                                contin = false;
                            }
                            //RealDataQ_LT_GivenQVal
                            NoDataLeftReally = (CurN + 4 > QItems);
                            LastNReached = (count >= this.QVals || CurN >= LastN + 4 * this.QVals);
                            if (LastNReached)
                            {
                                contin = false;
                            }
                            if (NoDataLeftReally)
                            {
                                contin = false;
                                countFix = count;
                                for (int i = countFix + 1; i <= this.QVals; i++)
                                {
                                    CurVal = "";
                                    MyLib.AddToVector(ref this.val, ref count, CurVal);
                                }
                            }
                        }//wh
                        LastN = LastN + 4 * QVals;
                        //so must be, ma mab no data be really da, so
                        LastN = CurN;
                    }//if (QItems > 0)
                }
            }
        }//fn
        //
        public override void GetItems(ref string[] arr, ref int QItems)
        {
            this.GetNames(ref arr, ref QItems);
        }
        //
        public override int GetTypeN() { return TableConsts.StringItemsFieldHeaderCellTypeN; }
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
        public override void SetByValDouble(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValFloat(float val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            float[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetFloatArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValInt(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValBool(bool val)
        {
            //this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0");
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetByValString(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValBoolN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetByValStringN(string val, int N)
        {
            this.val[N - 1] = val;
        }
        //
        public override void SetVal(double val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            double[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetDoubleArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(int val)
        {
            //this.val[ActiveValN - 1] = val.ToString();
            int[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetIntArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(bool val)
        {
            //int n;
            //n = MyLib.BoolToInt(val);
            //this.val[ActiveValN - 1] = n.ToString();
            bool[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetBoolArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
        }
        public override void SetVal(string val)
        {
            //this.val[ActiveValN - 1] = val;
            string[] arr = null;
            int length = 0, N = 0, count = 0;
            this.GetStringArr(ref arr, ref length);
            MyLib.FindInVector(ref arr, length, 1, val, ref count, ref N);
            if (N > 0) this.SetActiveN(N);
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
        public override void SetValN(string val, int N) { this.val[N - 1] = val; }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
            this.QVals = Q;
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
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
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleValN(i);
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetFloatValN(i);// Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetIntValN(i);//Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetBoolValN(i);// Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void GetStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = this.GetLength();// GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = ToStringN(i);//Arr[1 - 1] = ToString();
            }
        }
        //
        //public void SetNameN(string name, int N) { SetByValStringN(name, N); }
        //public void SetName1(string name) { SetByValStringN(name, 1); }
        //public void SetName2(string name) { SetByValStringN(name, 2); }
        //public void SetName3(string name) { SetByValStringN(name, 3); }
        //public void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        //public string GetNameN(int N) { return ToStringN(N); }
        //public string GetName1() { return ToStringN(1); }
        //public string GetName2() { return ToStringN(2); }
        //public string GetName3() { return ToStringN(3); }
        //public void GetNames(ref string[] Arr, ref int QItems) { ToStringArr(ref Arr, ref QItems); }
        //
        public override void SetNameN(string name, int N) { if (N >= 1 && N <= 7) names[N - 1] = name; }
        public override void SetName1(string name) { names[1 - 1] = name; ; }
        public override void SetName2(string name) { names[2 - 1] = name; ; }
        //public override void SetName3(string name) { names[3 - 1] = name; ; }
        public override void SetNames(string[] Arr, int Q)
        {
            int MinQ;
            if (Q >0 && Q< 7) MinQ = Q; else MinQ = 7;
            names = new string[MinQ];
            for (int i = 1; i <= MinQ; i++) names[i - 1] = Arr[i - 1];
        }
        public override string GetNameN(int N) { return names[N - 1]; }
        public override string GetName1() { return names[1 - 1]; }
        public override string GetName2() { return names[2 - 1]; }
        //public override string GetName3() { return names[3 - 1]; }
        public override void GetNames(ref string[] Arr, ref int QItems)
        {
            Arr = names;
            QItems = 7;
            for (int i = 1; i <= 7; i++) { if (names[i - 1] != null && (!(names[i - 1].Equals("")))) QItems = i; }
        }
        public override int GetLengthOfNamesList()
        {
            int R = 7;
            while (names[R - 1] == null || names[R - 1] == "") R--;
            return R;
        }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public override string GetDBTableNameToDisplay(){ return ""; } 
        public override void SetDBTableNameToDisplay(string name){}
        //2 Тип БД BType
        public override int GetDBTypeN(){ return 0; }
        public override void SetDBTypeN(int TypeN){}
        public override string GetDBConnectionString(){ return ""; }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public override string GetDBFileFullName(){ return ""; }
        public override void SetDBFileFullName(string name){}
        //4 Имя БД в списке СУБД DBNameInSDBC
        public override string GetDBNameInSDBC(){ return ""; }
        public override void SetDBNameInSDBC(string name){}
        //5 Имя таблицы в БД
        public override string GetDBTableNameInDB(){ return ""; }
        public override void SetDBTableNameInDB(string name){}
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public override string GetDBFieldNameToDisplay(){ return ""; }
        public override void SetDBFieldNameToDisplay(string name){}
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public override string GetDBFieldNameInTable(){ return ""; }
        public override void SetDBFieldNameInTable(string name){}
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public override string GetItemsDBTableNameInDB(){ return ""; }
        public override void SetItemsDBTableNameInDB(string name){}
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public override string GetItemsDBTablePrimaryKeyFieldName(){ return ""; }
        public override void SetItemsDBTablePrimaryKeyFieldName(string name){}
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public override string GetItemsDBTableItemsFieldName(){ return ""; }
        public override void SetItemsDBTableItemsFieldName(string name){}
        //6 Тип данных поля DB Field data type
        public override int GetDBFieldTypeN(){ return 0; }
        public override void SetDBFieldTypeN(int TypeN){}
        public override string GetDBFieldTypeName(){ return ""; }
        public override void SetDBFieldTypeName(string name){}
        //7 Длина поля Field Length (not the same as Array length)
        public override int GetDBFieldLength(){ return 0; }
        public override void SetDBFieldLength(int L){}
        //8 Длина списка пунктов и прочее
        public override int GetItemsQuantity(){ return 0; }
        public override void SetItems(string [] items, int Q){}
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public override int GetDBFieldCharacteristicsNumber(){ return 0; }
        public override void SetDBFieldCharacteristicsNumber(int number) { }
        public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        public override void SetIfKeyField(bool KeyField) { }
        public override void SetKeyField() { }
        public override void SetNotKeyField() { }
        public override bool IsCounter() { return MyLib.BoolValByDefault; }
        public override void SetIfCounter(bool isCounter) { }
        public override void SetCounter() { }
        public override void SetNotCounter() { }
        public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        public override void SetAutoIncrement() { }
        public override void SetNotAutoIncrement() { }
        public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        public override void SetIfNotNull(bool isNotNull) { }
        public override void SetNotNull() { }
        public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            string[] Names = null;
            string[] Items = null;
            int QItems, QNames = 0;
            QNames = this.GetLengthOfNamesList();
            QItems = this.GetLength();
            this.GetNames(ref Names, ref QNames);
            this.GetStringArr(ref Items, ref QItems);
            return new TDataBaseFieldHeader_WithItems_String(Items, Names, QItems, QNames);
        }
    }//cl
    public class TCellIntItemHeaderDependent : TCellInt//TDataCell
    {
        int val;
        public TCellIntItemHeaderDependent() { val = 0; }
        public TCellIntItemHeaderDependent(double val) { SetByValDouble(val); }
        public TCellIntItemHeaderDependent(float val) { SetByValFloat(val); }
        public TCellIntItemHeaderDependent(int val) { SetByValInt(val); }
        public TCellIntItemHeaderDependent(bool val) { SetByValBool(val); }
        public TCellIntItemHeaderDependent(string val) { SetByValString(val); }
        //
        public TCellIntItemHeaderDependent(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellIntItemHeaderDependent(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellIntItemHeaderDependent(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellIntItemHeaderDependent(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellIntItemHeaderDependent(string[] val, int Q) { SetByArrString(val, Q); }
        //
        //public override void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        //{
        //    //throw new NotImplementedException();
        //    Arr[1 - 1] = "Cell type:";
        //    Arr[2 - 1] = TableConsts.IntItemsFieldHeaderCellTypeN.ToString();
        //    Arr[3 - 1] = "Val:";
        //    Arr[4 - 1] = this.val.ToString();
        //    QItems = 4;
        //}//fn
        //public override void SetFromStringArray(string[] Arr, int QItems = 0)
        //{
        //    //throw new NotImplementedException();
        //    QItems = Arr.Length;
        //    if (QItems >= 4)
        //    {
        //        this.val = Convert.ToInt32(Arr[4 - 1]);
        //    }
        //}
        ////
        //public override void GetItems(ref string[] arr, ref int QItems)
        //{
        //    this.GetNames(ref arr, ref QItems);
        //}
        ////
        public override int GetTypeN() { return TableConsts.IntItemHeaderDependentTypeN; }
        //public override int GetActiveN() { return 1; }
        //public override void SetActiveN(int N) { }
        //public override int GetLength() { return 1; }
        //public override void SetLength(int L) { }
        ////
        //public override double GetDoubleVal()
        //{
        //    //float r;
        //    //r = (float)val;
        //    //return r;
        //    return (double)val;
        //}
        //public override float GetFloatVal()
        //{
        //    //float r;
        //    //r = (float)val;
        //    //return r;
        //    return (float)val;
        //}
        //public override int GetIntVal()
        //{
        //    return val;
        //}
        //public override bool GetBoolVal()
        //{
        //    bool r;
        //    if (val == 1) r = true;
        //    else r = false;
        //    return r;
        //}
        //public override string ToString() { return val.ToString(); }
        ////
        //public override double GetDoubleValN(int N) { return (double)val; }
        //public override float GetFloatValN(int N) { return (float)val; }
        //public override int GetIntValN(int N) { return val; }
        //public override bool GetBoolValN(int N)
        //{
        //    bool r;
        //    if (val == 1) r = true;
        //    else r = false;
        //    return r;
        //}
        //public override string ToStringN(int N) { return val.ToString(); }
        ////
        //public override void SetByValDouble(double val) { this.val = (int)val; }
        //public override void SetByValFloat(float val) { this.val = (int)val; }
        //public override void SetByValInt(int val) { this.val = (int)val; }
        //public override void SetByValBool(bool val)
        //{
        //    this.val = MyLib.BoolToInt(val);
        //}
        //public override void SetByValString(string val)
        //{
        //    double d;
        //    //this.val = Convert.ToInt32(val);
        //    d = NumberParse.StrToFloat(val);
        //    this.val = (int)d;
        //}
        ////
        //public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        //public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        //public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        //public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        //public override void SetByValStringN(string val, int N) { SetByValString(val); }
        ////
        //public override void SetVal(double val) { this.val = (int)val; }
        //public override void SetVal(int val) { this.val = (int)val; }
        //public override void SetVal(bool val)
        //{
        //    this.val = MyLib.BoolToInt(val);
        //}
        //public override void SetVal(string val)
        //{
        //    this.val = Convert.ToInt32(val);
        //}
        ////
        //public override void SetValN(double val, int N) { SetVal(val); }
        //public override void SetValN(int val, int N) { SetVal(val); }
        //public override void SetValN(bool val, int N) { SetVal(val); }
        //public override void SetValN(string val, int N) { SetVal(val); }
        ////
        //public override void SetByArrDouble(double[] val, int Q)
        //{
        //    if (val != null) SetByValDouble(val[1 - 1]);
        //    else SetByValDouble(0);
        //}
        //public override void SetByArrFloat(float[] val, int Q)
        //{
        //    if (val != null) SetByValFloat(val[1 - 1]);
        //    else SetByValFloat(0);
        //}
        //public override void SetByArrInt(int[] val, int Q)
        //{
        //    if (val != null) SetByValInt(val[1 - 1]);
        //    else SetByValInt(0);
        //}
        //public override void SetByArrBool(bool[] val, int Q)
        //{
        //    if (val != null) SetByValBool(val[1 - 1]);
        //    else SetByValBool(MyLib.BoolValByDefault);
        //}
        //public override void SetByArrString(string[] val, int Q)
        //{
        //    if (val != null) SetByValString(val[1 - 1]);
        //    else SetByValString("");
        //}
        ////
        //public override void SetByArr(double[] val, int Q)
        //{
        //    if (val != null) SetByValDouble(val[1 - 1]);
        //    else SetByValDouble(0);
        //}
        //public override void SetByArr(int[] val, int Q)
        //{
        //    if (val != null) SetByValInt(val[1 - 1]);
        //    else SetByValInt(0);
        //}
        //public override void SetByArr(bool[] val, int Q)
        //{
        //    if (val != null) SetByValBool(val[1 - 1]);
        //    else SetByValBool(MyLib.BoolValByDefault);
        //}
        //public override void SetByArr(string[] val, int Q)
        //{
        //    if (val != null) SetByValString(val[1 - 1]);
        //    else SetByValString("");
        //}
        ////
        //public override void AddOrInsDoubleVal(double val, int N)
        //{
        //    this.val = (int)Math.Round(val);
        //}
        //public override void AddOrInsFloatVal(float val, int N)
        //{
        //    this.val = (int)Math.Round(val);
        //}
        //public override void AddOrInsIntVal(int val, int N)
        //{
        //    this.val = val;
        //}
        //public override void AddOrInsBoolVal(bool val, int N)
        //{
        //    this.val = MyLib.BoolToInt(val);
        //}
        //public override void AddOrInsStringVal(string val, int N)
        //{
        //    this.val = Convert.ToInt32(val);
        //}
        ////
        //public override void DelValN(int N) { }
        ////
        //public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new double[QItems];
        //    Arr[1 - 1] = GetDoubleVal();
        //}
        //public override void GetFloatArr(ref float[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new float[QItems];
        //    Arr[1 - 1] = GetFloatVal();
        //}
        //public override void GetIntArr(ref int[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new int[QItems];
        //    Arr[1 - 1] = GetIntVal();
        //}
        //public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new bool[QItems];
        //    Arr[1 - 1] = GetBoolVal();
        //}
        //public override void GetStringArr(ref string[] Arr, ref int QItems)
        //{
        //    QItems = 1;
        //    Arr = new string[QItems];
        //    Arr[1 - 1] = ToString();
        //}
        ////
        //public override void SetNameN(string name, int N) { SetByValStringN(name, N); }
        //public override void SetName1(string name) { SetByValStringN(name, 1); }
        //public override void SetName2(string name) { SetByValStringN(name, 2); }
        ////public override void SetName3(string name) { SetByValStringN(name, 3); }
        //public override void SetNames(string[] Arr, int Q) { SetByArrString(Arr, Q); }
        //public override string GetNameN(int N) { return ToStringN(N); }
        //public override string GetName1() { return ToStringN(1); }
        //public override string GetName2() { return ToStringN(2); }
        ////public override string GetName3() { return ToStringN(3); }
        //public override void GetNames(ref string[] Arr, ref int QItems) { GetStringArr(ref Arr, ref QItems); }
        //public override int GetLengthOfNamesList() { return 1; }
        ////
        ////Set of DB functions
        ////
        ////1 Имя таблицы отображаемое TableNameToDisplay
        //public override string GetDBTableNameToDisplay() { return ""; }
        //public override void SetDBTableNameToDisplay(string name) { }
        ////2 Тип БД BType
        //public override int GetDBTypeN() { return 0; }
        //public override void SetDBTypeN(int TypeN) { }
        //public override string GetDBConnectionString() { return ""; }
        ////public override void SetDBConnectiobString(string ConnStr) { }
        ////3 Путь к БД DBFileFullName
        //public override string GetDBFileFullName() { return ""; }
        //public override void SetDBFileFullName(string name) { }
        ////4 Имя БД в списке СУБД DBNameInSDBC
        //public override string GetDBNameInSDBC() { return ""; }
        //public override void SetDBNameInSDBC(string name) { }
        ////5 Имя таблицы в БД
        //public override string GetDBTableNameInDB() { return ""; }
        //public override void SetDBTableNameInDB(string name) { }
        ////
        ////
        ////1 Название столбца отображаемое DBFieldNameToDisplay
        //public override string GetDBFieldNameToDisplay() { return ""; }
        //public override void SetDBFieldNameToDisplay(string name) { }
        ////2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        //public override string GetDBFieldNameInTable() { return ""; }
        //public override void SetDBFieldNameInTable(string name) { }
        ////3 Название связанной таблицы пунктов DBTableNameInDB
        //public override string GetItemsDBTableNameInDB() { return ""; }
        //public override void SetItemsDBTableNameInDB(string name) { }
        ////4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        //public override string GetItemsDBTablePrimaryKeyFieldName() { return ""; }
        //public override void SetItemsDBTablePrimaryKeyFieldName(string name) { }
        ////5 Имя поля названий пунктов в связанной таблице пунктов
        //public override string GetItemsDBTableItemsFieldName() { return ""; }
        //public override void SetItemsDBTableItemsFieldName(string name) { }
        ////6 Тип данных поля DB Field data type
        //public override int GetDBFieldTypeN() { return 0; }
        //public override void SetDBFieldTypeN(int TypeN) { }
        //public override string GetDBFieldTypeName() { return ""; }
        //public override void SetDBFieldTypeName(string name) { }
        ////7 Длина поля Field Length (not the same as Array length)
        //public override int GetDBFieldLength() { return 0; }
        //public override void SetDBFieldLength(int L) { }
        ////8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity() { return 0; }
        //public override void SetItems(string[] items, int Q) { }
        ////public override void SetItems(DataCell [] ItemsCells, int Q){}
        ////public override SetItemN(string item, int N){}
        ////public override InsItemN(string item, int N){}
        ////public override AddItem(string item){}
        ////public override DelItemN(int N){}
        ////public override int GetNamesQuantity(){}
        ////public override void SetNames(string [] items, int Q){}
        ////public override void SetNames(DataCell [] NamesCells, int Q){}
        ////public override SetNameN(string item, int N){}
        ////public override InsNameN(string item, int N){}
        ////public override AddName(string item){}
        ////public override DelNameN(int N){}
        ////9 Характеристики поля булевы одним числом
        //public override int GetDBFieldCharacteristicsNumber() { return 0; }
        //public override void SetDBFieldCharacteristicsNumber(int number) { }
        //public override bool IsKeyField() { return MyLib.BoolValByDefault; }
        //public override void SetIfKeyField(bool KeyField) { }
        //public override void SetKeyField() { }
        //public override void SetNotKeyField() { }
        //public override bool IsCounter() { return MyLib.BoolValByDefault; }
        //public override void SetIfCounter(bool isCounter) { }
        //public override void SetCounter() { }
        //public override void SetNotCounter() { }
        //public override bool IsAutoIncrement() { return MyLib.BoolValByDefault; }
        //public override void SetIfAutoIncrement(bool isAutoIncrement) { }
        //public override void SetAutoIncrement() { }
        //public override void SetNotAutoIncrement() { }
        //public override bool IsNotNull() { return MyLib.BoolValByDefault; }
        //public override void SetIfNotNull(bool isNotNull) { }
        //public override void SetNotNull() { }
        //public override void SetNotNotNull() { }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public override void SetDBTableHeaderData(TDBTableHeaderData data) { }
        public override TDBTableHeaderData GetDBTableHeaderData() { return null; }
        public override void SetDBTableCreationData(TDBTableCreationData data) { }
        public override TDBTableCreationData GetDBTableCreationData() { return null; }
        public override void SetDBFieldHeaderData(TDBFieldHeaderData data) { }
        public override TDBFieldHeaderData GetDBFieldHeaderData() { return null; }
        public override void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { }
        public override TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return null; }
        public override void SetDBItemsTableData(TDBItemsTableData data) { }
        public override TDBItemsTableData GetDBItemsTableData() { return null; }
        //
        public override object Clone()
        {
            return new TCellIntItemHeaderDependent(this.GetIntVal());
        }
    }//cl TCellInt
    //
    //mark4
    public class DataCell : ICloneable
    {
        TDataCell cell;
        public DataCell()
        {
            cell = null;
            SetDefault0();
        }
        //
        public DataCell(double val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeDouble(val);
        }
        public DataCell(float val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeFloat(val);
        }
        public DataCell(int val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeInt(val);
        }
        public DataCell(bool val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeBool(val);
        }
        public DataCell(string val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeString(val);
        }
        public DataCell(double[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeDouble(arr, Length);
        }
        public DataCell(float[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeFloat(arr, Length);
        }
        public DataCell(int[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeInt(arr, Length);
        }
        public DataCell(bool[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeBool(arr, Length);
        }
        public DataCell(string[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeString(arr, Length);
        }
        public DataCell(int val, bool ConstNotVar)
        {
            cell = null;
            SetDefault0();
            if (ConstNotVar)
            {
                cell = new TCellUniqueNumKeeper(val);
            }
            else
            {
                SetValAndTypeInt(val);
            }
        }
        public DataCell(int TypeN, string[] data, int QItems, int ActiveN=1, int FromN=1)
        {
            int ix;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    this.cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    this.cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    this.cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    this.cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    this.cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    this.cell = new TCellDoubleMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                break;
                case TableConsts.FloatArrayTypeN:
                    this.cell = new TCellFloatMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                break;
                case TableConsts.IntArrayTypeN:
                    this.cell = new TCellIntMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                break;
                case TableConsts.BoolArrayTypeN:
                    this.cell = new TCellBoolMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                break;
                case TableConsts.StringArrayTypeN:
                    this.cell = new TCellStringMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                break;
                case TableConsts.DBTableHeaderTypeN:
                    this.cell = new TCellDBTableHeader();
                break;
                case TableConsts.ColHeaderDBFieldOrItemsTypeN:
                    this.cell = new TCellDBFieldOrItemsHeader();
                break;
                case TableConsts.IntItemHeaderDependentTypeN:
                    this.cell = new TCellIntItemHeaderDependent();
                break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    ix=0;
                    if(data!=null && FromN+QItems-1<=data.Length){
                        ix=Convert.ToInt32(data[FromN-1]);
                    }
                    this.cell = new TCellUniqueNumKeeper(ix);
                break;
                this.cell.SetFromStringArray(data, QItems);
            }
        }
        //
        public DataCell(string Name, TDBTableHeaderData data)
        {
            this.cell = new TCellDBTableHeader();
            this.cell.SetDBTableHeaderData(data);
        }
        public DataCell(string Name, TDBFieldHeaderData data, string[]items, int QItems)
        {
            this.cell = new TCellDBFieldOrItemsHeader();
            this.cell.SetDBFieldHeaderData(data);
            if (items != null)
            {
                this.SetItems(items, QItems);
            }
        }
        public DataCell(string ColNameToDisplay, string DBFieldNameInDBTable, TDBFieldHeaderCreationData CreoDat, TDBItemsTableData JounedTableDat, string[] items, int QItems)
        {
            this.cell = new TCellDBFieldOrItemsHeader();
            this.cell.SetDBFieldNameInTable(DBFieldNameInDBTable);
            this.cell.SetDBFieldHeaderCreationData(CreoDat);
            this.cell.SetDBItemsTableData(JounedTableDat);
            if (items != null)
            {
                this.SetItems(items, QItems);
            }
        }
        public DataCell(string[] Names, string[] Items, int QNames = 1, int QItems = 1)
        {
            cell = null;
            SetDefault0();
            //cell=new TDataBaseFieldHeader_WithItems_String(Items, Names, QItems, QNames);
            cell = new TCellDBFieldOrItemsHeader();
            cell.SetByArrString(Names, QNames);
            cell.SetItems(Items, QItems);
        }
        public DataCell(int TypeN, int N)
        {
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                    break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                    break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    cell = new TDataBaseFieldHeader_WithItems_String();
                    break;
            }
            this.cell.SetActiveN(1);
            //SetActiveN(1);
        }
        public DataCell(DataCellTypeInfo TypeInf)
        {
            int TypeN = TypeInf.GetTypeN();
            int length = TypeInf.GetLength();
            int N = length;
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (length < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                    break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                    break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    cell = new TDataBaseFieldHeader_WithItems_String();
                    break;
            }
            this.cell.SetActiveN(1);
        }
        //
        public void SetDefault0()
        {
            int TypeN = TableConsts.DefaultAnyCellTypeN;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    cell = new TCellDoubleMemo();
                    break;
                case TableConsts.FloatArrayTypeN:
                    cell = new TCellFloatMemo();
                    break;
                case TableConsts.IntArrayTypeN:
                    cell = new TCellIntMemo();
                    break;
                case TableConsts.BoolArrayTypeN:
                    cell = new TCellBoolMemo();
                    break;
                case TableConsts.StringArrayTypeN:
                    cell = new TCellStringMemo();
                    break;
            }//swch
            SetActiveN(1);
        }//fn
        //
        public TDataCell GetCell() { return this.cell; }
        //
        public DataCellTypeInfo GetTypeInfo()
        {
            int TypeN = GetTypeN();
            int length = GetLength();
            DataCellTypeInfo TypeInf = new DataCellTypeInfo(TypeN, length);
            return TypeInf;
        }
        public void SetTypeAndDefaultValByTypeInf(DataCellTypeInfo TypeInf, bool PreserveVal = false)
        {
            TableCellAccessConfiguration cfg = new TableCellAccessConfiguration();
            int TypeN = TypeInf.GetTypeN();
            int length = TypeInf.GetLength();
            cfg.LengthOfArrCellTypes = length;
            cfg.PreserveVal = PreserveVal;
            this.SetTypeN(TypeN, cfg);
        }
        /////
        public void SetDataAndType(double val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeDouble(val);
        }
        public void SetDataAndType(float val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeFloat(val);
        }
        public void SetDataAndType(int val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeInt(val);
        }
        public void SetDataAndType(bool val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeBool(val);
        }
        public void SetDataAndType(string val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeString(val);
        }
        public void SetDataAndType(double[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeDouble(arr, Length);
        }
        public void SetDataAndType(float[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeFloat(arr, Length);
        }
        public void SetDataAndType(int[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeInt(arr, Length);
        }
        public void SetDataAndType(bool[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeBool(arr, Length);
        }
        public void SetDataAndType(string[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeString(arr, Length);
        }
        public void SetDataAndType(int val, bool ConstNotVar)
        {
            cell = null;
            SetDefault0();
            if (ConstNotVar)
            {
                cell = new TCellUniqueNumKeeper(val);
            }
            else
            {
                SetValAndTypeInt(val);
            }
        }
        public void SetDataAndType(int TypeN, string[] data, int QItems, int ActiveN = 1, int FromN = 1)
        {
            int ix;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    this.cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    this.cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    this.cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    this.cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    this.cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    this.cell = new TCellDoubleMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                    break;
                case TableConsts.FloatArrayTypeN:
                    this.cell = new TCellFloatMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                    break;
                case TableConsts.IntArrayTypeN:
                    this.cell = new TCellIntMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                    break;
                case TableConsts.BoolArrayTypeN:
                    this.cell = new TCellBoolMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                    break;
                case TableConsts.StringArrayTypeN:
                    this.cell = new TCellStringMemo();
                    if (ActiveN <= this.cell.GetLength() && ActiveN >= 0)
                    {
                        this.cell.SetActiveN(ActiveN);
                    }
                    else
                    {
                        this.cell.SetActiveN(1);
                    }
                    break;
                case TableConsts.DBTableHeaderTypeN:
                    this.cell = new TCellDBTableHeader();
                    break;
                case TableConsts.ColHeaderDBFieldOrItemsTypeN:
                    this.cell = new TCellDBFieldOrItemsHeader();
                    break;
                case TableConsts.IntItemHeaderDependentTypeN:
                    this.cell = new TCellIntItemHeaderDependent();
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    ix = 0;
                    if (data != null && FromN + QItems - 1 <= data.Length)
                    {
                        ix = Convert.ToInt32(data[FromN - 1]);
                    }
                    this.cell = new TCellUniqueNumKeeper(ix);
                    break;
                    this.cell.SetFromStringArray(data, QItems);
            }
        }
        //
        public void SetDataAndType(string Name, TDBTableHeaderData data)
        {
            this.cell = new TCellDBTableHeader();
            this.cell.SetDBTableHeaderData(data);
        }
        public void SetDataAndType(string Name, TDBFieldHeaderData data, string[] items, int QItems)
        {
            this.cell = new TCellDBFieldOrItemsHeader();
            this.cell.SetDBFieldHeaderData(data);
            if (items != null)
            {
                this.SetItems(items, QItems);
            }
        }
        public void SetDataAndType(string ColNameToDisplay, string DBFieldNameInDBTable, TDBFieldHeaderCreationData CreoDat, TDBItemsTableData JounedTableDat, string[] items, int QItems)
        {
            this.cell = new TCellDBFieldOrItemsHeader();
            this.cell.SetDBFieldNameInTable(DBFieldNameInDBTable);
            this.cell.SetDBFieldHeaderCreationData(CreoDat);
            this.cell.SetDBItemsTableData(JounedTableDat);
            if (items != null)
            {
                this.SetItems(items, QItems);
            }
        }
        public void SetDataAndType(string[] Names, string[] Items, int QNames = 1, int QItems = 1)
        {
            cell = null;
            SetDefault0();
            //cell=new TDataBaseFieldHeader_WithItems_String(Items, Names, QItems, QNames);
            cell = new TCellDBFieldOrItemsHeader();
            cell.SetByArrString(Names, QNames);
            cell.SetItems(Items, QItems);
        }
        public void SetDataAndType(int TypeN, int N)
        {
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                    break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                    break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    cell = new TDataBaseFieldHeader_WithItems_String();
                    break;
            }
            this.cell.SetActiveN(1);
            //SetActiveN(1);
        }
        public void SetDataAndType(DataCellTypeInfo TypeInf)
        {
            int TypeN = TypeInf.GetTypeN();
            int length = TypeInf.GetLength();
            int N = length;
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (length < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                    break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                    break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    cell = new TDataBaseFieldHeader_WithItems_String();
                    break;
            }
            this.cell.SetActiveN(1);
        }
        /////
        public double GetDoubleVal()
        {
            return cell.GetDoubleVal();
        }
        public float GetFloatVal()
        {
            return cell.GetFloatVal();
        }
        public int GetIntVal()
        {
            return cell.GetIntVal();
        }
        public bool GetBoolVal()
        {
            return cell.GetBoolVal();
        }
        public override string ToString()
        {
            return cell.ToString();
        }
        //
        public void GetDoubleArr(ref double[] vals, ref int count)
        {
            cell.GetDoubleArr(ref vals, ref count);
        }
        public void GetFloatArr(ref float[] vals, ref int count)
        {
            cell.GetFloatArr(ref vals, ref count);
        }
        public void GetIntArr(ref int[] vals, ref int count)
        {
            cell.GetIntArr(ref vals, ref count);
        }
        public void GetBoolArr(ref bool[] vals, ref int count)
        {
            cell.GetBoolArr(ref vals, ref count);
        }
        public void GetStringArr(ref string[] vals, ref int count)
        {
            cell.GetStringArr(ref vals, ref count);
        }
        //
        public double GetDoubleValN(int N)
        {
            return cell.GetDoubleValN(N);
        }
        public float GetFloatValN(int N)
        {
            return cell.GetFloatValN(N);
        }
        public int GetIntValN(int N)
        {
            return cell.GetIntValN(N);
        }
        public bool GetBoolValN(int N)
        {
            return cell.GetBoolValN(N);
        }
        public string ToStringN(int N)
        {
            return cell.ToStringN(N);
        }
        //
        public void SetVal(double val) { cell.SetVal(val); }
        public void SetVal(int val) { cell.SetVal(val); }
        public void SetVal(bool val) { cell.SetVal(val); }
        public void SetVal(string val) { cell.SetVal(val); }
        //
        public void SetValN(double val, int N) { cell.SetValN(val, N); }
        public void SetValN(float val, int N) { cell.SetValN(val, N); }
        public void SetValN(int val, int N) { cell.SetValN(val, N); }
        public void SetValN(bool val, int N) { cell.SetValN(val, N); }
        public void SetValN(string val, int N) { cell.SetValN(val, N); }
        //
        public int GetTypeN() { return cell.GetTypeN(); }
        public int GetLength()
        {
            int N = 0;
            if (cell != null) N = cell.GetLength();
            return N;
        }
        public int GetActiveN()
        {
            int N = 0;
            if (cell != null) N = cell.GetActiveN();
            return N;
        }
        //
        public void SetActiveN(int N)
        {
            cell.SetActiveN(N);
        }
        public void SetLength(int Length)
        {
            cell.SetLength(Length);
        }
        //
        public void DelValN(int N)
        {
            cell.DelValN(N);
        }
        //
        public void AddOrInsDoubleVal(double val, int N)
        {
            cell.AddOrInsDoubleVal(val, N);
        }
        public void AddOrInsFloatVal(float val, int N)
        {
            cell.AddOrInsFloatVal(val, N);
        }
        public void AddOrInsIntVal(int val, int N)
        {
            cell.AddOrInsIntVal(val, N);
        }
        public void AddOrInsBoolVal(bool val, int N)
        {
            cell.AddOrInsBoolVal(val, N);
        }
        public void AddOrInsStringVal(string val, int N)
        {
            cell.AddOrInsStringVal(val, N);
        }
        //
        public void Assign(double val)
        {
            cell = new TCellDouble();
            cell.SetVal(val);
            //cell.SetValAndT
        }
        public void Assign(float val)
        {
            cell = new TCellFloat();
            cell.SetVal(val);
        }
        public void Assign(int val)
        {
            cell = new TCellInt();
            cell.SetVal(val);
        }
        public void Assign(bool val)
        {
            cell = new TCellBool();
            cell.SetVal(val);
        }
        public void Assign(string val)
        {
            cell = new TCellString();
            cell.SetVal(val);
        }
        public void Assign(double val, int N)
        {
            double[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell == null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new double[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetDoubleValN(N);
                cell = new TCellDoubleMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(float val, int N)
        {
            float[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell == null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new float[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetFloatValN(N);
                cell = new TCellFloatMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(int val, int N)
        {
            int[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell == null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new int[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetIntValN(N);
                cell = new TCellIntMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(bool val, int N)
        {
            bool[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell == null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new bool[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = MyLib.BoolValByDefault;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetBoolValN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(string val, int N)
        {
            string[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell == null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new string[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = "";
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.ToStringN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(double[] val, int count)
        {
            cell = new TCellDoubleMemo(val, count);
        }
        public void Assign(float[] val, int count)
        {
            cell = new TCellFloatMemo(val, count);
        }
        public void Assign(int[] val, int count)
        {
            cell = new TCellIntMemo(val, count);
        }
        public void Assign(bool[] val, int count)
        {
            cell = new TCellBoolMemo(val, count);
        }
        public void Assign(string[] val, int count)
        {
            cell = new TCellStringMemo(val, count);
        }
        public void Assign(double[] val, int CountItems, string[] name, int CountNames)
        {
            cell = new TDataBaseFieldHeader_WithItems_Double(val, CountItems, name, CountNames);
        }
        public void Assign(int[] val, int CountItems, string[] name, int CountNames)
        {
            cell = new TDataBaseFieldHeader_WithItems_Int(val, CountItems, name, CountNames);
        }
        public void Assign(string[] val, int CountItems, string[] name, int CountNames)
        {
            cell = new TDataBaseFieldHeader_WithItems_String(val, name, CountItems, CountNames);
        }
        public void Assign(TDataCell obj)
        {
            cell = obj;
        }
        public void Assign(DataCell obj)
        {
            int TypeN, Length = 0;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (obj == null) cell = null;
            else
            {
                TypeN = obj.GetTypeN();
                switch (TypeN)
                {
                    case TableConsts.DoubleTypeN:
                        DoubleVal = obj.GetDoubleVal();
                        cell = new TCellDouble(DoubleVal);
                        break;
                    case TableConsts.FloatTypeN:
                        FloatVal = obj.GetFloatVal();
                        cell = new TCellFloat(FloatVal);
                        break;
                    case TableConsts.IntTypeN:
                        IntVal = obj.GetIntVal();
                        cell = new TCellInt(IntVal);
                        break;
                    case TableConsts.BoolTypeN:
                        BoolVal = obj.GetBoolVal();
                        cell = new TCellBool(BoolVal);
                        break;
                    case TableConsts.StringTypeN:
                        StringVal = obj.ToString();
                        cell = new TCellString(StringVal);
                        break;
                    case TableConsts.DoubleArrayTypeN:
                        obj.GetDoubleArr(ref DoubleArr, ref Length);
                        cell = new TCellDoubleMemo(DoubleArr, Length);
                        break;
                    case TableConsts.FloatArrayTypeN:
                        obj.GetFloatArr(ref FloatArr, ref Length);
                        cell = new TCellFloatMemo(FloatArr, Length);
                        break;
                    case TableConsts.IntArrayTypeN:
                        obj.GetIntArr(ref IntArr, ref Length);
                        cell = new TCellIntMemo(IntArr, Length);
                        break;
                    case TableConsts.BoolArrayTypeN:
                        obj.GetBoolArr(ref BoolArr, ref Length);
                        cell = new TCellBoolMemo(BoolArr, Length);
                        break;
                    case TableConsts.StringArrayTypeN:
                        obj.GetStringArr(ref StringArr, ref Length);
                        cell = new TCellStringMemo(StringArr, Length);
                        break;
                    case TableConsts.StringItemsFieldHeaderCellTypeN:
                        int QNames=0, QItems=0;
                        string[] names=null, items=null;
                        obj.GetNames(ref names, ref QNames);
                        obj.GetStringArr(ref items, ref QItems);
                        cell = new TDataBaseFieldHeader_WithItems_String(items, names, QItems, QNames);
                        break;
                }//swch
            }//if
        }//fn asgn
        //mark5
        public void AssignBy(TDataCell CellFrom)
        {
            TDataCell CellTo = this.cell;
            int TypeTo = CellTo.GetTypeN(), TypeFrom = CellFrom.GetTypeN(), LenFrom = CellFrom.GetLength(), LenTo = CellTo.GetLength(), LenMin;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (LenFrom >= LenTo) LenMin = LenFrom; else LenMin = LenTo;
            switch (TypeFrom)
            {
                case TableConsts.DoubleTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //DoubleVal=CellFrom.GetDoubleVal();
                            //CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.FloatTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            //CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            //int QNames=0, QItems=0;
                            //string[] names=null, items=null;
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.FloatTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            break;
                        case TableConsts.FloatTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            //IntVal=CellFrom.GetIntVal();
                            //CellTo.SetByValInt(IntVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.IntTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.BoolTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            //CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);//why not
                            CellTo.SetByArrInt(IntArr, LenFrom);//why not
                            break;
                    }//switch
                    break;
                case TableConsts.StringTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.DoubleArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            //CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.FloatArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.IntArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.BoolArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            //CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            //CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.StringArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            //CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            //CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            CellFrom.GetStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                    }//switch
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.DoubleItemsFieldHeaderCellTypeN: //ne done!
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.IntItemsFieldHeaderCellTypeN: //ne done!
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN: //ne done!
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.IntItemsFieldHeaderCellTypeN://ne done!
                            //NOp;
                            break;
                        case TableConsts.StringItemsFieldHeaderCellTypeN://ne done!
                            int QItems=0, QNames=0;
                            string[] items=null, names=null;
                            CellFrom.GetStringArr(ref items, ref QItems);
                            CellFrom.GetNames(ref names, ref QNames);
                            break;
                    }//switch
                    break;
            }//switch 
            this.cell = CellTo;
        }
        public void AssignBy(DataCell obj)
        {
            TDataCell ObjCell = obj.GetCell();
            AssignBy(ObjCell);
        }
        /*
        //mark6
    public class DataCell
    {
        TDataCell cell;
        public DataCell() { 
            cell = null;
            SetDefault0();
        }
        //
        public DataCell(double val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeDouble(val);
        }
        public DataCell(float val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeFloat(val);
        }
        public DataCell(int val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeInt(val);
        }
        public DataCell(bool val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeBool(val);
        }
        public DataCell(string val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeString(val);
        }
        public DataCell(double[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeDouble(arr, Length);
        }
        public DataCell(float[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeFloat(arr, Length);
        }
        public DataCell(int[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeInt(arr, Length);
        }
        public DataCell(bool[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeBool(arr, Length);
        }
        public DataCell(string[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeString(arr, Length);
        }
        public DataCell(int val, bool ConstNotVar)
        {
            cell = null;
            SetDefault0();
            if (ConstNotVar)
            {
                cell = new TCellUniqueNumKeeper(val);
            }
            else
            {
                SetValAndTypeInt(val);
            }
        }
        public DataCell(int TypeN, int N)
        {
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double []DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                break;
            }
            this.cell.SetActiveN(1);
            //SetActiveN(1);
        }
        public DataCell(DataCellTypeInfo TypeInf)
        {
            int TypeN=TypeInf.GetTypeN();
            int length=TypeInf.GetLength();
            int N=length;
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double []DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            //SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    if (length < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                break;
            }
            this.cell.SetActiveN(1);
        }
        //
        public void SetDefault0()
        {
            int TypeN = TableConsts.DefaultAnyCellTypeN;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    cell = new TCellDoubleMemo();
                break;
                case TableConsts.FloatArrayTypeN:
                    cell = new TCellFloatMemo();
                break;
                case TableConsts.IntArrayTypeN:
                    cell = new TCellIntMemo();
                break;
                case TableConsts.BoolArrayTypeN:
                    cell = new TCellBoolMemo();
                break;
                case TableConsts.StringArrayTypeN:
                    cell = new TCellStringMemo();
                break;
            }//swch
            SetActiveN(1);
        }//fn
        //
        public TDataCell GetCell() { return this.cell; }
        //
        public DataCellTypeInfo GetTypeInfo()
        {
            int TypeN = GetTypeN();
            int length = GetLength();
            DataCellTypeInfo TypeInf = new DataCellTypeInfo(TypeN, length);
            return TypeInf;
        }
        public void SetTypeAndDefaultValByTypeInf(DataCellTypeInfo TypeInf, bool PreserveVal=false)
        {
            TableCellAccessConfiguration cfg=new TableCellAccessConfiguration();
            int TypeN = TypeInf.GetTypeN();
            int length = TypeInf.GetLength();
            cfg.LengthOfArrCellTypes=length;
            cfg.PreserveVal=PreserveVal;
            this.SetTypeN(TypeN, cfg); 
        }
        //
        public double GetDoubleVal()
        {
            return cell.GetDoubleVal();
        }
        public float GetFloatVal()
        {
            return cell.GetFloatVal();
        }
        public int GetIntVal()
        {
            return cell.GetIntVal();
        }
        public bool GetBoolVal()
        {
            return cell.GetBoolVal();
        }
        public override string ToString()
        {
            return cell.ToString();
        }
        //
        public void GetDoubleArr(ref double[] vals, ref int count)
        {
            cell.GetDoubleArr(ref vals, ref count);
        }
        public void GetFloatArr(ref float[] vals, ref int count)
        {
            cell.GetFloatArr(ref vals, ref count);
        }
        public void GetIntArr(ref int[] vals, ref int count)
        {
            cell.GetIntArr(ref vals, ref count);
        }
        public void GetBoolArr(ref bool[] vals, ref int count)
        {
            cell.GetBoolArr(ref vals, ref count);
        }
        public void ToStringArr(ref string[] vals, ref int count)
        {
            cell.ToStringArr(ref vals, ref count);
        }
        //
        public double GetDoubleValN(int N)
        {
            return cell.GetDoubleValN(N);
        }
        public float GetFloatValN(int N)
        {
            return cell.GetFloatValN(N);
        }
        public int GetIntValN(int N)
        {
            return cell.GetIntValN(N);
        }
        public bool GetBoolValN(int N)
        {
            return cell.GetBoolValN(N);
        }
        public string ToStringN(int N)
        {
            return cell.ToStringN(N);
        }
        //
        public void SetVal(double val){ cell.SetVal(val); }
        public void SetVal(int val){ cell.SetVal(val); }
        public void SetVal(bool val) { cell.SetVal(val); }
        public void SetVal(string val) { cell.SetVal(val); }
        //
        public void SetValN(double val, int N) { cell.SetValN(val, N); }
        public void SetValN(float val, int N) { cell.SetValN(val, N); }
        public void SetValN(int val, int N) { cell.SetValN(val, N); }
        public void SetValN(bool val, int N) { cell.SetValN(val, N); }
        public void SetValN(string val, int N) { cell.SetValN(val, N); }
        //
        public int GetTypeN() { return cell.GetTypeN(); }
        public int GetLength() {
            int N = 0;
            if (cell != null) N = cell.GetLength();
            return N; 
        }
        public int GetActiveN() {
            int N = 0;
            if (cell != null) N = cell.GetActiveN();
            return N;
        }
        //
        public void SetActiveN(int N)
        {
            cell.SetActiveN(N);
        }
        public void SetLength(int Length){
            cell.SetLength(Length);
        }
        //
        public void DelValN(int N)
        {
            cell.DelValN(N);
        }
        //
        public void AddOrInsDoubleVal(double val, int N)
        {
            cell.AddOrInsDoubleVal(val, N);
        }
        public void AddOrInsFloatVal(float val, int N)
        {
            cell.AddOrInsFloatVal(val, N);
        }
        public void AddOrInsIntVal(int val, int N)
        {
            cell.AddOrInsIntVal(val, N);
        }
        public void AddOrInsBoolVal(bool val, int N)
        {
            cell.AddOrInsBoolVal(val, N);
        }
        public void AddOrInsStringVal(string val, int N)
        {
            cell.AddOrInsStringVal(val, N);
        }
        //
        public void Assign(double val)
        {
            cell = new TCellDouble();
            cell.SetVal(val);
            //cell.SetValAndT
        }
        public void Assign(float val)
        {
            cell = new TCellFloat();
            cell.SetVal(val);
        }
        public void Assign(int val)
        {
            cell = new TCellInt();
            cell.SetVal(val);
        }
        public void Assign(bool val)
        {
            cell = new TCellBool();
            cell.SetVal(val);
        }
        public void Assign(string val)
        {
            cell = new TCellString();
            cell.SetVal(val);
        }
        public void Assign(double val, int N)
        {
            double[]arr=null;
            int ActualLength, PrevLength=cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell=cell;
                if(N<PrevLength) ActualLength=PrevLength; else ActualLength=N;
                if(ActualLength<=PrevLength) MinLength=ActualLength; else MinLength=PrevLength;
                arr=new double[ActualLength];
                for(int i=1; i<=ActualLength; i++) arr[i-1]=0;
                for(int i=1; i<=MinLength; i++) arr[i-1]=bufCell.GetDoubleValN(N);
                cell = new TCellDoubleMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(float val, int N)
        {
            float[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new float[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetFloatValN(N);
                cell = new TCellFloatMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(int val, int N)
        {
            int[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new int[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetIntValN(N);
                cell = new TCellIntMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(bool val, int N)
        {
            bool[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new bool[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = MyLib.BoolValByDefault;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetBoolValN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(string val, int N)
        {
            string[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new string[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = "";
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.ToStringN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(double[] val, int count)
        {
            cell = new TCellDoubleMemo(val, count);
        }
        public void Assign(float[] val, int count)
        {
            cell = new TCellFloatMemo(val, count);
        }
        public void Assign(int[] val, int count)
        {
            cell = new TCellIntMemo(val, count);
        }
        public void Assign(bool[] val, int count)
        {
            cell = new TCellBoolMemo(val,  count);
        }
        public void Assign(string[] val, int count)
        {
            cell = new TCellStringMemo(val, count);
        }
        public void Assign(double[] val, int count, string name1, string name2, string name3)
        {
            cell = new TDataBaseFieldHeader_WithItems_Double(val, count, name1, name2, name3);
        }
        public void Assign(string[] val, int count, string name1, string name2, string name3)
        {
            cell = new TDataBaseFieldHeader_WithItems_String(val, count, name1, name2, name3);
        }
        public void Assign(TDataCell obj)
        {
            cell = obj;
        }
        public void Assign(DataCell obj)
        {
            int TypeN, Length=0;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (obj == null) cell = null;
            else
            {
                TypeN = obj.GetTypeN();
                switch (TypeN)
                {
                    case TableConsts.DoubleTypeN:
                        DoubleVal = obj.GetDoubleVal();
                        cell = new TCellDouble(DoubleVal);
                        break;
                    case TableConsts.FloatTypeN:
                        FloatVal = obj.GetFloatVal();
                        cell = new TCellFloat(FloatVal);
                        break;
                    case TableConsts.IntTypeN:
                        IntVal = obj.GetIntVal();
                        cell = new TCellInt(IntVal);
                        break;
                    case TableConsts.BoolTypeN:
                        BoolVal = obj.GetBoolVal();
                        cell = new TCellBool(BoolVal);
                        break;
                    case TableConsts.StringTypeN:
                        StringVal = obj.ToString();
                        cell = new TCellString(StringVal);
                        break;
                    case TableConsts.DoubleArrayTypeN:
                        obj.GetDoubleArr(ref DoubleArr, ref Length);
                        cell = new TCellDoubleMemo(DoubleArr, Length);
                        break;
                    case TableConsts.FloatArrayTypeN:
                        obj.GetFloatArr(ref FloatArr, ref Length);
                        cell = new TCellFloatMemo(FloatArr, Length);
                        break;
                    case TableConsts.IntArrayTypeN:
                        obj.GetIntArr(ref IntArr, ref Length);
                        cell = new TCellIntMemo(IntArr, Length);
                        break;
                    case TableConsts.BoolArrayTypeN:
                        obj.GetBoolArr(ref BoolArr, ref Length);
                        cell = new TCellBoolMemo(BoolArr, Length);
                        break;
                    case TableConsts.StringArrayTypeN:
                        obj.ToStringArr(ref StringArr, ref Length);
                        cell = new TCellStringMemo(StringArr, Length);
                        break;
                }//swch
            }//if
        }//fn asgn
        //
        public void AssignBy(TDataCell CellFrom) 
        {
            TDataCell CellTo = this.cell;
            int TypeTo = CellTo.GetTypeN(), TypeFrom = CellFrom.GetTypeN(), LenFrom = CellFrom.GetLength(), LenTo = CellTo.GetLength(), LenMin;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (LenFrom >= LenTo) LenMin = LenFrom; else LenMin = LenTo;
            switch (TypeFrom)
            {
                case TableConsts.DoubleTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //DoubleVal=CellFrom.GetDoubleVal();
                            //CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.FloatTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            //CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.FloatTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            break;
                        case TableConsts.FloatTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            //IntVal=CellFrom.GetIntVal();
                            //CellTo.SetByValInt(IntVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.IntTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.BoolTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            //CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.StringTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.DoubleArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            //CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.FloatArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.IntArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.BoolArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            //CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            //CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.StringArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            //CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            //CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.TDataBaseFieldHeaderTypeN://ne done!
                            //NOp;
                            break;
                    }//switch
                break;
                case TableConsts.TDataBaseFieldHeaderTypeN: //ne done!
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                        break;
                        case TableConsts.TDataBaseFieldHeaderTypeN:
                            //NOp;
                        break;
                }//switch
                break;
            }//switch 
            this.cell=CellTo;
        }
        public void AssignBy(DataCell obj)
        {
            TDataCell ObjCell = obj.GetCell();
            AssignBy(ObjCell);
        }
         */
        //mark7
        public void SetTypeN(int TypeN, TableCellAccessConfiguration cfgExt)
        {
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            TDataCell BufCell = null;
            TableCellAccessConfiguration cfg = null;
            if (cfgExt != null) cfg = cfgExt; //qu s'abl?
            else cfg = new TableCellAccessConfiguration();
            if (cfg.PreserveVal)
            {
                BufCell = cell;
            }
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    if (!cfg.PreserveVal) cell = new TCellDouble();
                    else cell = new TCellDouble(BufCell.GetDoubleVal());
                    break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    if (cfg.PreserveVal) cell.SetByValFloat(BufCell.GetFloatVal());
                    break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    if (cfg.PreserveVal) cell.SetByValInt(BufCell.GetIntVal());
                    break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    if (cfg.PreserveVal) cell.SetByValBool(BufCell.GetBoolVal());
                    break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    if (cfg.PreserveVal) cell.SetByValString(BufCell.ToString());
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(cfg.UniqueIntVal);
                    if (cfg.PreserveVal) cell.SetByValInt(BufCell.GetIntVal());
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetDoubleArr(ref DoubleArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellDoubleMemo(DoubleArr, cfg.LengthOfArrCellTypes);
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetFloatArr(ref FloatArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellFloatMemo(FloatArr, cfg.LengthOfArrCellTypes);
                    break;
                case TableConsts.IntArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetIntArr(ref IntArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellIntMemo(IntArr, cfg.LengthOfArrCellTypes);
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetBoolArr(ref BoolArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellBoolMemo(BoolArr, cfg.LengthOfArrCellTypes);
                    break;
                case TableConsts.StringArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetStringArr(ref StringArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellStringMemo(BoolArr, cfg.LengthOfArrCellTypes);
                    break;
            }
        }
        public void SetTypeN(DataCellTypeInfo typeCell, bool ValPreserveNotDefault = true)
        {
            int TypeN, PrevTypeN, LengthOfItemsSet = 0, LengthOfNamesSet = 0;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null, names = null;
            //TDataCell BufCell = null;
            //TableCellAccessConfiguration cfg = null;
            PrevTypeN = this.GetTypeN();
            TypeN = typeCell.GetTypeN();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    if (ValPreserveNotDefault)
                    {
                        DoubleVal = this.GetDoubleVal();
                        this.cell = new TCellDouble(DoubleVal);
                    }
                    else
                    {
                        this.cell = new TCellDouble();
                    }
                    break;
                case TableConsts.FloatTypeN:
                    if (ValPreserveNotDefault)
                    {
                        FloatVal = this.GetFloatVal();
                        this.cell = new TCellFloat(FloatVal);
                    }
                    else
                    {
                        this.cell = new TCellFloat();
                    }
                    break;
                case TableConsts.IntTypeN:
                    if (ValPreserveNotDefault)
                    {
                        IntVal = this.GetIntVal();
                        this.cell = new TCellInt(IntVal);
                    }
                    else
                    {
                        this.cell = new TCellInt();
                    }
                    break;
                case TableConsts.BoolTypeN:
                    if (ValPreserveNotDefault)
                    {
                        BoolVal = cell.GetBoolVal();
                        this.cell = new TCellBool(BoolVal);
                    }
                    else
                    {
                        this.cell = new TCellBool();
                    }
                    break;
                case TableConsts.StringTypeN:
                    if (ValPreserveNotDefault)
                    {
                        StringVal = cell.ToString();
                        this.cell = new TCellString(StringVal);
                    }
                    else
                    {
                        this.cell = new TCellString();
                    }
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    IntVal = this.GetIntVal();
                    this.cell = new TCellUniqueNumKeeper(IntVal);
                    break;
                case TableConsts.DoubleArrayTypeN:
                    if (ValPreserveNotDefault)
                    {
                        this.cell.GetDoubleArr(ref DoubleArr, ref LengthOfItemsSet);
                        cell = new TCellDoubleMemo(DoubleArr, LengthOfItemsSet);
                    }
                    else
                    {
                        this.cell = new TCellDoubleMemo();
                    }
                    break;
                case TableConsts.FloatArrayTypeN:
                    if (ValPreserveNotDefault)
                    {
                        this.cell.GetFloatArr(ref FloatArr, ref LengthOfItemsSet);
                        cell = new TCellFloatMemo(FloatArr, LengthOfItemsSet);
                    }
                    else
                    {
                        this.cell = new TCellFloatMemo();
                    }
                    break;
                case TableConsts.IntArrayTypeN:
                    if (ValPreserveNotDefault)
                    {
                        this.cell.GetIntArr(ref IntArr, ref LengthOfItemsSet);
                        cell = new TCellIntMemo(IntArr, LengthOfItemsSet);
                    }
                    else
                    {
                        this.cell = new TCellIntMemo();
                    }
                    break;
                case TableConsts.BoolArrayTypeN:
                    if (ValPreserveNotDefault)
                    {
                        this.cell.GetBoolArr(ref BoolArr, ref LengthOfItemsSet);
                        cell = new TCellBoolMemo(BoolArr, LengthOfItemsSet);
                    }
                    else
                    {
                        this.cell = new TCellBoolMemo();
                    }
                    break;
                case TableConsts.StringArrayTypeN:
                    if (ValPreserveNotDefault)
                    {
                        this.cell.GetStringArr(ref StringArr, ref LengthOfItemsSet);
                        cell = new TCellStringMemo(StringArr, LengthOfItemsSet);
                    }
                    else
                    {
                        this.cell = new TCellStringMemo();
                    }
                    break;
                case TableConsts.DoubleItemsFieldHeaderCellTypeN:
                    if (ValPreserveNotDefault && TableConsts.TypeNIsCorrectHeaderWithItems(PrevTypeN))
                    {
                        //LengthOfNamesSet = 7;
                        //names = new string[LengthOfNamesSet];
                        //for (int i = 1; i <= LengthOfNamesSet; i++) names[i - 1] = "";
                        this.cell.GetDoubleArr(ref DoubleArr, ref LengthOfItemsSet);
                        cell = new TDataBaseFieldHeader_WithItems_Double(DoubleArr, LengthOfItemsSet);
                    }
                    else
                    {
                        cell = new TDataBaseFieldHeader_WithItems_Double();
                    }
                    break;
                case TableConsts.IntItemsFieldHeaderCellTypeN:
                    if (ValPreserveNotDefault && TableConsts.TypeNIsCorrectHeaderWithItems(PrevTypeN))
                    {
                        //LengthOfNamesSet = 7;
                        //names = new string[LengthOfNamesSet];
                        //for (int i = 1; i <= LengthOfNamesSet; i++) names[i - 1] = "";
                        this.cell.GetIntArr(ref IntArr, ref LengthOfItemsSet);
                        cell = new TDataBaseFieldHeader_WithItems_Int(IntArr, LengthOfItemsSet);
                    }
                    else
                    {
                        cell = new TDataBaseFieldHeader_WithItems_Int();
                    }
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    if (ValPreserveNotDefault && TableConsts.TypeNIsCorrectHeaderWithItems(PrevTypeN))
                    {
                        //this.cell.ToStringArr(ref StringArr, ref LengthOfItemsSet);
                        //cell = new TDataBaseFieldHeader_WithItems_String(IntArr, LengthOfItemsSet);
                        this.cell.GetStringArr(ref names, ref LengthOfNamesSet);
                        cell = new TDataBaseFieldHeader_WithItems_String();
                        cell.SetNames(names, LengthOfNamesSet);
                    }
                    else
                    {
                        cell = new TDataBaseFieldHeader_WithItems_String();
                    }
                    break;
            }
        }//fn
        //
        public void SetValAndTypeDouble(double val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.DoubleTypeN)
            {
                cell = new TCellDouble(val);
            }
            else
            {
                cell.SetByValDouble(val);
            }
        }
        public void SetValAndTypeFloat(float val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.FloatTypeN)
            {
                cell = new TCellFloat(val);
            }
            else
            {
                cell.SetByValFloat(val);
            }
        }
        public void SetValAndTypeInt(int val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.IntTypeN)
            {
                cell = new TCellInt(val);
            }
            else
            {
                cell.SetByValInt(val);
            }
        }
        public void SetValAndTypeBool(bool val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.BoolTypeN)
            {
                cell = new TCellBool(val);
            }
            else
            {
                cell.SetByValBool(val);
            }
        }
        public void SetValAndTypeString(string val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.StringTypeN)
            {
                cell = new TCellString(val);
            }
            else
            {
                cell.SetByValString(val);
            }
        }
        public void SetArrAndTypeDouble(double[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.DoubleArrayTypeN)
            {
                cell = new TCellDoubleMemo(arr, Length);
            }
            else
            {
                cell.SetByArrDouble(arr, Length);
            }
        }
        public void SetArrAndTypeFloat(float[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.FloatArrayTypeN)
            {
                cell = new TCellFloatMemo(arr, Length);
            }
            else
            {
                cell.SetByArrFloat(arr, Length);
            }
        }
        public void SetArrAndTypeInt(int[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.IntArrayTypeN)
            {
                cell = new TCellIntMemo(arr, Length);
            }
            else
            {
                cell.SetByArrInt(arr, Length);
            }
        }
        public void SetArrAndTypeBool(bool[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.BoolArrayTypeN)
            {
                cell = new TCellBoolMemo(arr, Length);
            }
            else
            {
                cell.SetByArrBool(arr, Length);
            }
        }
        public void SetArrAndTypeString(string[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.StringArrayTypeN)
            {
                cell = new TCellStringMemo(arr, Length);
            }
            else
            {
                cell.SetByArrString(arr, Length);
            }
        }
        public void SetValAndTypeUniqueIntNumKeeper(int val)
        {
            cell = new TCellUniqueNumKeeper(val);
        }
        //
        public void SetByValDouble(double val)
        {
            cell.SetByValDouble(val);
        }
        public void SetByValFloat(float val)
        {
            cell.SetByValFloat(val);
        }
        public void SetByValInt(int val)
        {
            cell.SetByValInt(val);
        }
        public void SetByValBool(bool val)
        {
            cell.SetByValBool(val);
        }
        public void SetByValString(string val)
        {
            cell.SetByValString(val);
        }
        //
        public void SetByValDoubleN(double val, int N)
        {
            cell.SetByValDoubleN(val, N);
        }
        public void SetByValFloatN(float val, int N)
        {
            cell.SetByValFloatN(val, N);
        }
        public void SetByValIntN(int val, int N)
        {
            cell.SetByValIntN(val, N);
        }
        public void SetByValBoolN(bool val, int N)
        {
            cell.SetByValBoolN(val, N);
        }
        public void SetByValStringN(string val, int N)
        {
            cell.SetByValStringN(val, N);
        }
        //
        public void SetByArrDouble(double[] val, int Length)
        {
            cell.SetByArrDouble(val, Length);
        }
        public void SetByArrFloat(float[] val, int Length)
        {
            cell.SetByArrFloat(val, Length);
        }
        public void SetByArrInt(int[] val, int Length)
        {
            cell.SetByArrInt(val, Length);
        }
        public void SetByArrBool(bool[] val, int Length)
        {
            cell.SetByArrBool(val, Length);
        }
        public void SetByArrString(string[] val, int Length)
        {
            cell.SetByArrString(val, Length);
        }
        //
        public int GetErstItemNByStringVal(string val)
        {
            int N = 0;
            for (int i = GetLength(); i >= 1; i--)
            {
                if (val.Equals(ToStringN(i))) N = i;
            }
            return N;
        }
        public void SetActiveNByStringVal(string val)
        {
            int N = 0;
            for (int i = GetLength(); i >= 1; i--)
            {
                if (val.Equals(ToStringN(i))) N = i;
            }
            if (N != 0) SetActiveN(N);
        }
        //
        public string GetNameN(int N)
        {
            return cell.GetNameN(N);
        }
        public string GetName1()
        {
            return cell.GetName1();
        }
        public string GetName2()
        {
            return cell.GetName2();
        }
        //public string GetName3()
        //{
        //    return cell.GetName3();
        //}
        public void GetNames(ref string[] Arr, ref int QItems)
        {
            cell.GetNames(ref Arr, ref QItems);
        }
        public int GetLengthOfNamesList()
        {
            return cell.GetLengthOfNamesList();
        }
        //
        public static DataCell operator +(DataCell obj1, DataCell obj2)
        {
            DataCell sum = new DataCell();
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            int Type1N, Type2N, Length1, Length2;
            if (obj1 != null)
            {
                if (obj2 != null) //else NOp;
                {
                    Type1N = obj1.GetTypeN();
                    Type2N = obj2.GetTypeN();
                    switch (Type1N)
                    {
                        case TableConsts.DoubleTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength(); //1
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN: //ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN://ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN: //ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.FloatTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //DoubleArr = new double[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    //}
                                    //sum = new DataCell(DoubleArr, Length1 + Length2);
                                    //
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.IntTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.BoolTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.StringTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.FloatTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.IntTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.BoolTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.StringTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    //CellTo.SetByValBool(CellFrom.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        //mark8
                        case TableConsts.FloatArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.IntArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.BoolArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.StringArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++)
                                    {
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                            }//switch
                            break;
                    }//switch 
                }
                else sum.Assign(obj1);
            }
            else sum.Assign(obj2);
            return sum;
        }//+
        //
        /*public void SetNameN(string name, int N) { this.cell.SetNameN(name, N); }
        public void SetName1(string name) { this.cell.SetName1(name); }
        public void SetName2(string name) { this.cell.SetName2(name); }
        public void SetName3(string name) { this.cell.SetName3(name); }
        public void SetNames(string[] Arr, int Q){this.cell.SetNames(Arr, Q);}
        public string GetNameN(int N) { return this.cell.GetNameN(N); }
        public string GetName1() { return this.cell.GetName1(); }
        public string GetName2() { return this.cell.GetName2(); }
        public string GetName3() { return this.cell.GetName3(); }
        public void GetNames(ref string[] Arr, ref int QItems){this.cell.GetNames(ref Arr, ref QItems);}
        public int GetLengthOfNamesList() { return this.cell.GetLengthOfNamesList();}*/
        //
        public object Clone()
        {
            DataCell cell = null;
            int TypeN = this.GetTypeN(), QItems = this.GetLength(), QNames = this.GetLengthOfNamesList(), ActiveN = this.GetActiveN();
            double[] ItemsDbl = null;
            float[] ItemsFlt = null;
            int[] ItemsInt = null;
            bool[] ItemsBool = null;
            string[] ItemsStr = null;
            string[] Names = null;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new DataCell(this.GetDoubleVal());
                    break;
                case TableConsts.FloatTypeN:
                    cell = new DataCell(this.GetFloatVal());
                    break;
                case TableConsts.IntTypeN:
                    cell = new DataCell(this.GetIntVal());
                    break;
                case TableConsts.BoolTypeN:
                    cell = new DataCell(this.GetBoolVal());
                    break;
                case TableConsts.StringTypeN:
                    cell = new DataCell(this.ToString());
                    break;
                case TableConsts.DoubleArrayTypeN:
                    this.GetDoubleArr(ref ItemsDbl, ref QItems);
                    cell = new DataCell(ItemsDbl, QItems);
                    break;
                case TableConsts.FloatArrayTypeN:
                    this.GetFloatArr(ref ItemsFlt, ref QItems);
                    cell = new DataCell(ItemsFlt, QItems);
                    break;
                case TableConsts.IntArrayTypeN:
                    this.GetIntArr(ref ItemsInt, ref QItems);
                    cell = new DataCell(ItemsInt, QItems);
                    break;
                case TableConsts.BoolArrayTypeN:
                    this.GetBoolArr(ref ItemsBool, ref QItems);
                    cell = new DataCell(ItemsBool, QItems);
                    break;
                case TableConsts.StringArrayTypeN:
                    this.GetStringArr(ref ItemsStr, ref QItems);
                    cell = new DataCell(ItemsStr, QItems);
                    break;
                //case TableConsts.UniqueIntValKeeperTypeN:
                //     this.GetIntArr(ref ItemsInt, ref QItems);
                //     cell=new DataCell(ItemsInt, QItems);
                //     break;
                case TableConsts.DoubleItemsFieldHeaderCellTypeN:
                    this.GetDoubleArr(ref ItemsDbl, ref QItems);
                    this.GetNames(ref Names, ref QNames);
                    cell = new DataCell(ItemsDbl, QItems);
                    break;
                case TableConsts.IntItemsFieldHeaderCellTypeN:
                    this.GetIntArr(ref ItemsInt, ref QItems);
                    this.GetNames(ref Names, ref QNames);
                    cell = new DataCell(ItemsInt, QItems);
                    break;
                case TableConsts.StringItemsFieldHeaderCellTypeN:
                    this.GetStringArr(ref ItemsStr, ref QItems);
                    this.GetNames(ref Names, ref QNames);
                    cell = new DataCell(ItemsStr, QItems);
                    break;
            }//switch
            if (TableConsts.TypeNIsCorrectArray(TypeN)) cell.SetActiveN(ActiveN);
            return cell;
        }
        public void SetFromGridCellValueOnly(DataGridViewCell gridCell, TableReadingTypesParams TypesParams)
        {
            //TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt
            DataGridViewComboBoxCell ComboBoxCell = null;
            DataGridViewCheckBoxCell CheckBoxCell = null;
            double DoubleVal;
            int IntVal, TableCellTypeN;
            bool BoolVal;
            string val, cur;
            TableCellTypeN = this.GetTypeN();
            if (gridCell is DataGridViewComboBoxCell)
            {
                ComboBoxCell = (DataGridViewComboBoxCell)gridCell;
                IntVal = 0;
                val = ComboBoxCell.Value.ToString();
                for (int i = 1; i <= ComboBoxCell.Items.Count; i++)
                {
                    cur = ComboBoxCell.Items[i - 1].ToString();
                    if (val.Equals(cur))
                    {
                        IntVal = i;
                    }
                }
                switch (TableCellTypeN)
                {
                    case TableConsts.IntTypeN:
                    case TableConsts.StringArrayTypeN:
                        this.SetByValInt(IntVal);
                        break;
                    case TableConsts.StringTypeN:
                        this.SetByValString(val);
                        break;
                    default:
                        this.SetByValString(val);
                        break;
                }
            }
            else if (gridCell is DataGridViewCheckBoxCell)
            {
                CheckBoxCell = (DataGridViewCheckBoxCell)gridCell;
                if (MyLib.BoolValByDefault == true)
                {
                    if ((bool)CheckBoxCell.Value)
                    {
                        IntVal = 1;
                        val = TableConsts.TrueWord;
                    }
                    else
                    {
                        IntVal = 2;
                        val = TableConsts.FalseWord;
                    }
                }
                else
                {
                    if ((bool)CheckBoxCell.Value)
                    {
                        IntVal = 2;
                        val = TableConsts.TrueWord;
                    }
                    else
                    {
                        IntVal = 1;
                        val = TableConsts.FalseWord;
                    }
                }
                switch (TableCellTypeN)
                {
                    case TableConsts.BoolTypeN:
                        this.SetByValBool((bool)CheckBoxCell.Value);
                        break;
                    case TableConsts.IntTypeN:
                        this.SetByValInt(MyLib.BoolToInt((bool)CheckBoxCell.Value));
                        break;
                    case TableConsts.StringTypeN:
                        this.SetByValString(val);
                        break;
                    case TableConsts.StringArrayTypeN:
                        this.SetActiveN(IntVal);
                        break;
                    default:
                        this.SetByValBool((bool)CheckBoxCell.Value);
                        break;
                }
            }
            else if (gridCell is DataGridViewTextBoxCell)
            {
                //NOp;
            }
            else
            {
                val = gridCell.Value.ToString();
                this.SetByValString(val);
            }
        }//fn
        public bool HeaderIsEqualTo(DataCell CellToCompar, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)//cases 3,5,8,9 s'exnot
        //EqualIf_FirstName1AllNames2TypeAndLength3 = 2)
        {
            bool b = true, names1, names2;//, names3, 
            bool TypeAndLength, ActineNs;
            names1 = ((this.GetName1()).Equals(CellToCompar.GetName1()));
            names2 = ((this.GetName2()).Equals(CellToCompar.GetName2()));
            //names3 = ((this.GetName3()).Equals(CellToCompar.GetName2()));
            TypeAndLength = (this.GetTypeN() == CellToCompar.GetTypeN() && this.GetLength() == CellToCompar.GetLength());
            ActineNs = (this.GetActiveN() == CellToCompar.GetActiveN());
            switch (EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9)
            {
                case 1:
                    b = names1;
                    break;
                case 2:
                    b = names2;
                    break;
                case 3://not needed
                    //b = names3;
                    break;
                case 4:
                    b = names1 && names2;
                    break;
                case 5://not needed
                    //b = names1 && names2 && names3;
                    break;
                case 6:
                    b = ActineNs;
                    break;
                case 7:
                    b = TypeAndLength;
                    break;
                case 8://not needed
                    //b = TypeAndLength && names1 && names2 && names3;
                    break;
                case 9://not needed
                    //b = TypeAndLength && names1 && names2 && names3 && ActineNs;
                    break;
            }
            return b;
        }
        //
        //Set of DB functions
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public string GetDBTableNameToDisplay() { return this.cell.GetDBTableNameToDisplay(); }
        public void SetDBTableNameToDisplay(string name) { this.cell.SetDBTableNameToDisplay(name);  }
        //2 Тип БД BType
        public int GetDBTypeN() { return this.cell.GetDBTypeN(); }
        public void SetDBTypeN(int TypeN) { this.cell.SetDBTypeN(TypeN); }
        public string GetDBConnectionString() { return this.cell.GetDBConnectionString(); }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public string GetDBFileFullName() { return this.cell.GetDBFileFullName(); }
        public void SetDBFileFullName(string name) { this.cell.SetDBFileFullName(name); }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public string GetDBNameInSDBC() { return this.cell.GetDBNameInSDBC(); }
        public void SetDBNameInSDBC(string name) { this.cell.SetDBNameInSDBC(name); }
        //5 Имя таблицы в БД
        public string GetDBTableNameInDB() { return this.cell.GetDBTableNameInDB(); }
        public void SetDBTableNameInDB(string name) { this.cell.SetDBTableNameInDB(name); }
        //
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay() { return this.cell.GetDBFieldNameToDisplay(); }
        public void SetDBFieldNameToDisplay(string name) { this.cell.SetDBFieldNameToDisplay(name); }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable() { return this.cell.GetDBFieldNameInTable(); }
        public void SetDBFieldNameInTable(string name) { this.cell.SetDBFieldNameInTable(name); }
        //3 Название связанной таблицы пунктов DBTableNa meInDB
        public string GetItemsDBTableNameInDB() { return this.cell.GetItemsDBTableNameInDB(); }
        public void SetItemsDBTableNameInDB(string name) { this.cell.SetItemsDBTableNameInDB(name); }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName() { return this.cell.GetItemsDBTablePrimaryKeyFieldName(); }
        public void SetItemsDBTablePrimaryKeyFieldName(string name) { this.cell.SetItemsDBTablePrimaryKeyFieldName(name); }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName() { return this.cell.GetItemsDBTableItemsFieldName(); }
        public void SetItemsDBTableItemsFieldName(string name) { this.cell.SetItemsDBTableItemsFieldName(name); }
        //6 Тип данных поля DB Field data type 
        public int GetDBFieldTypeN() { return this.cell.GetDBFieldTypeN(); }
        public void SetDBFieldTypeN(int TypeN) { this.cell.SetDBFieldTypeN(TypeN); }
        public string GetDBFieldTypeName() { return this.cell.GetDBFieldTypeName(); }
        public void SetDBFieldTypeName(string name) { this.cell.SetDBFieldTypeName(name); }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength() { return this.cell.GetDBFieldLength(); }
        public void SetDBFieldLength(int L) { this.cell.SetDBFieldLength(L);  }
        //8 Длина списка пунктов и прочее
        public int GetItemsQuantity() { return this.cell.GetItemsQuantity(); }
        public void SetItems(string[] items, int Q) { this.cell.SetItems(items, Q); }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public int GetDBFieldCharacteristicsNumber() { return this.cell.GetDBFieldCharacteristicsNumber(); }
        public void SetDBFieldCharacteristicsNumber(int num) { this.cell.SetDBFieldCharacteristicsNumber(num); }
        public bool IsKeyField() { return this.cell.IsKeyField(); }
        public void SetIfKeyField(bool KeyField) { this.cell.SetIfKeyField(KeyField); }
        public void SetKeyField() { this.cell.SetKeyField(); }
        public void SetNotKeyField() { this.cell.SetNotKeyField(); }
        public bool IsCounter() { return this.cell.IsCounter(); }
        public void SetIfCounter(bool isCounter) {this.cell.SetIfCounter(isCounter); }
        public void SetCounter() { this.cell.SetCounter();  }
        public void SetNotCounter() { this.cell.SetNotCounter(); }
        public bool IsAutoIncrement() { return this.cell.IsAutoIncrement(); }
        public void SetIfAutoIncrement(bool isAutoIncrement) {this.cell.SetIfAutoIncrement(isAutoIncrement); }
        public void SetAutoIncrement() { this.cell.SetAutoIncrement(); }
        public void SetNotAutoIncrement() { this.cell.SetNotAutoIncrement(); }
        public bool IsNotNull() { return this.cell.IsNotNull();  }
        public void SetIfNotNull(bool isNotNull) { this.cell.SetIfNotNull(isNotNull); }
        public void SetNotNull(){ this.cell.SetNotNull(); }
        public void SetNotNotNull() { this.cell.SetNotNotNull(); }
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        public void SetDBTableHeaderData(TDBTableHeaderData data) { this.cell.SetDBTableHeaderData(data);}
        public TDBTableHeaderData GetDBTableHeaderData() { return this.cell.GetDBTableHeaderData(); }
        public void SetDBTableCreationData(TDBTableCreationData data) { this.cell.SetDBTableCreationData(data); }
        public TDBTableCreationData GetDBTableCreationData() { return this.cell.GetDBTableCreationData(); }
        public void SetDBFieldHeaderData(TDBFieldHeaderData data) { this.cell.SetDBFieldHeaderData(data); }
        public TDBFieldHeaderData GetDBFieldHeaderData() { return this.cell.GetDBFieldHeaderData(); }
        public void SetDBFieldHeaderCreationData(TDBFieldHeaderCreationData data) { this.cell.SetDBFieldHeaderCreationData(data); }
        public TDBFieldHeaderCreationData GetDBFieldHeaderCreationData() { return this.cell.GetDBFieldHeaderCreationData(); }
        public void SetDBItemsTableData(TDBItemsTableData data) { this.cell.SetDBItemsTableData(data); }
        public TDBItemsTableData GetDBItemsTableData() { return this.cell.GetDBItemsTableData(); }
        //
        public void SetCellAsDBTableHeader()
        {
            this.cell = new TCellDBTableHeader();
        }
        public void SetCellAsDBTableHeader(string TableNameToDisplay, string TableNameInDB, string DBNameInSCDB="", string DBFileFullName="", int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5=0, string DBTypeName="")
        {
            this.cell = new TCellDBTableHeader();
            this.cell.SetDBTableNameToDisplay(TableNameToDisplay);
            this.cell.SetDBTableNameInDB(TableNameInDB);
            this.cell.SetDBNameInSDBC(DBNameInSCDB);
            this.cell.SetDBFileFullName(DBFileFullName);
            this.cell.SetDBTypeN(DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5);
            //this.cell.SetDBTypeName(DBTypeName);
        }
        public void SetCellAsDBItemsFieldHeader()
        {
            this.cell = new TCellDBFieldOrItemsHeader(); 
        }
    }//cl DataCell
}//ns 