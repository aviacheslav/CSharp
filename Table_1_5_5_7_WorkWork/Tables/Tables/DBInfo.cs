using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    class DBInfo
    {
    }

    //public static class DBConsts{
    //    public const string TDBTableCreationData_DBNameInDBCS="";
    //    public const string TDBTableCreationData_DBTypeName="";
    //    public const string TDBTableCreationData_DBTypeN="";
    //    public const string TDBTableCreationData_DBFileFullName="";
    //}
    
    public class TDBTableCreationData : ICloneable
    {
        //public string DBNameInDBCS;
        public string DBTypeName;
        public int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5;
        public string DBFileFullName;
        public string DBNameInDBCS;
        //
        public TDBTableCreationData(string DBTypeName = "", int DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0, string DBFileFullName = "", string DBNameInDBCS="")
        {
            //DBNameInDBCS="";
            this.DBTypeName = DBTypeName;
            this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5;
            this.DBFileFullName = DBFileFullName;
            this.DBNameInDBCS = DBNameInDBCS;
        }
        //
        public object Clone()
        {
            return (TDBTableCreationData)this.MemberwiseClone();
        }
        //
        //public void SetDBTableDataFromTable(TTable tbl) // No Need
        //public TTable GetDBTableDataAsTable() // No Need
        public void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        {
            string cur;
            //Arr = null;
            //QItems = 0;
            //
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + "DB Name In DBCS:";
            }
            cur = cur + this.DBNameInDBCS;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + "DB Type Name:";
            }
            cur = cur + this.DBTypeName;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + "DB Type N:";
            }
            cur = cur + (this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5).ToString();
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur + "DB File Full Name:";
            }
            cur = cur + this.DBFileFullName;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            //}
        }//fn
        public void SetFromStringArray(string[] Arr, int QItemsExt, int FromN=1)
        {
            string s1, s2, s3;
            string[] delims = { " ", ",", ";" };
            int QItems=QItemsExt-FromN+1;
            //
            //this.DBNameInDBCS = "";
            //this.DBTypeName = "";
            //this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0;
            //this.DBFileFullName = "";
            //
            if (Arr == null)
            {
                if (QItems >= 1)
                {
                    //this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                    this.DBNameInDBCS = "";
                    this.DBTypeName = "";
                    this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0;
                    this.DBFileFullName = "";
                }
            }
            if (Arr != null)
            {
                if (QItems >= 1)
                {
                    s1 = Arr[FromN + 0 - 1];
                    s2 = MyLib.DelAllSubstrings(s1, delims);
                    s3 = MyLib.DelAllSubstringSamples(s2, "DBNameInDBCS:");
                    //this.DBTableHeaderData.DataSuppl = new TDBTableCreationData();
                    this.DBNameInDBCS = s3;
                    if (QItems >= 2)
                    {
                        s1 = Arr[FromN + 1 - 1];
                        s2 = MyLib.DelAllSubstrings(s1, delims);
                        s3 = MyLib.DelAllSubstringSamples(s2, "DBTypeName:");
                        this.DBTypeName = s3;
                        if (QItems >= 3)
                        {
                            s1 = Arr[FromN + 2 - 1];
                            s2 = MyLib.DelAllSubstrings(s1, delims);
                            s3 = MyLib.DelAllSubstringSamples(s2, "DBTypeN:");
                            this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = Convert.ToInt32(s3);
                            if (QItems >= 4)
                            {
                                s1 = Arr[FromN + 3 - 1];
                                s2 = MyLib.DelAllSubstrings(s1, delims);
                                s3 = MyLib.DelAllSubstringSamples(s2, "DBFileFullName:");
                                this.DBFileFullName = s3;
                            }
                            else// if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
                            {
                                this.DBFileFullName = "";
                            }
                        }
                        else// if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl != null)
                        {
                            this.DBTypeN_SQLite_1_MySql_2_MsSqlSrv_3_MSAccess2003_4_MSAccess2007_5 = 0;
                        }
                    }
                    else// if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl.DBTypeName != null)
                    {
                        this.DBTypeName = "";
                    }
                }
                else// if (this.DBTableHeaderData != null && this.DBTableHeaderData.DataSuppl.DBTypeName != null)
                {
                    this.DBNameInDBCS = "";
                }
            }//if (Arr != null)
        }//fn
    }//cl
    public class TDBTableHeaderData : ICloneable
    {
        public string DBTableNameInDB;
        public TDBTableCreationData DataSuppl;
        //
        public TDBTableHeaderData(string DBTableNameInDB="", TDBTableCreationData DataSuppl=null)
        {
            this.DBTableNameInDB = DBTableNameInDB;
            this.DataSuppl = DataSuppl;
        }
        //
        public object Clone()
        {
            TDBTableHeaderData obj=new TDBTableHeaderData();
            obj.DBTableNameInDB = this.DBTableNameInDB;
            if(this.DataSuppl!=null){
                obj.DataSuppl = (TDBTableCreationData)this.DataSuppl.Clone();
            }
            return obj;
        }
        public void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true){
            string[]ArrContent=null;
            int QItemsContent=0;
            string name = "DBTableName: ", cur;
            //Arr=null;
            //QItems=0;
            cur = "";
            if (WriteSupplInfo)
            {
                cur = cur+name;
            }
            cur = cur + this.DBTableNameInDB;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            if(this.DataSuppl!=null){
                this.DataSuppl.ToStringArray(ref ArrContent, ref QItemsContent, WriteSupplInfo, WriteWholeInfo);
            }else if(WriteWholeInfo){
                this.DataSuppl=new TDBTableCreationData();
                this.DataSuppl.ToStringArray(ref ArrContent, ref QItemsContent, WriteSupplInfo, WriteWholeInfo);
                this.DataSuppl = null;
            }
            if(ArrContent!=null){
                for(int i=1; i<=QItemsContent; i++){
                    MyLib.AddToVector(ref Arr, ref QItems, ArrContent[i-1]);
                }
            }
        }//fn
        public void SetFromStringArray(string[] Arr, int QItemsExt, int FromN = 1)
        {
            string s1, s2, s3, name = "DBTableName: ";
            string[] sContent = null;
            int QItems = QItemsExt - FromN + 1;
            if (Arr != null)
            {
                if (QItems >0)
                {
                    s1 = Arr[FromN + 0 - 1]; ;
                    if (s1.Substring(1 - 1, name.Length).Equals(name))
                    {
                        s2 = s1.Substring(name.Length + 1 - 1, (s1.Length - name.Length));
                    }
                    else
                    {
                        s2 = s1;
                    }
                    this.DBTableNameInDB = s2;
                    //this.DBTableNameInDB = Arr[FromN + 0 - 1];
                    if (QItems > 1)
                    {
                        this.DataSuppl = new TDBTableCreationData();
                        this.DataSuppl.SetFromStringArray(Arr, QItemsExt, FromN + 1);
                    }
                }
            }
        }//fn
    }//cl

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    public class TDBItemsTableData : ICloneable
    {
        public string ItemsTableName;
        public string ItemsTableItemsFieldName;
        public string ItemsTableKeyFieldName;
        //
        public TDBItemsTableData(string ItemsTableName="", string ItemsTableItemsFieldName="", string ItemsTableKeyFieldName="") {
            this.ItemsTableName = ItemsTableName;
            this.ItemsTableItemsFieldName = ItemsTableItemsFieldName;
            this.ItemsTableKeyFieldName = ItemsTableKeyFieldName;
        }
        //
        public object Clone()
        {
           // DBItemsTableData obj = new DBItemsTableData();
            //obj.ItemsTableItemsFieldName = this.ItemsTableItemsFieldName;
            //obj.ItemsTableKeyFieldName = this.ItemsTableKeyFieldName;
            //obj.ItemsTableName = this.ItemsTableName;
            //return obj;
            return this.MemberwiseClone();
        }
        //
        public TTable GetItemsAsTable()
        {
            TTable tbl = null;
            string[] items = new string[3];
            string[] captions = new string[3];
            captions[1 - 1] = "Items Table Name"; items[1 - 1] = this.ItemsTableName;
            captions[2 - 1] = "Items Field Name"; items[2 - 1] = this.ItemsTableItemsFieldName;
            captions[3 - 1] = "Key Field Name"; items[3 - 1] = this.ItemsTableKeyFieldName;
                tbl = new TTable(
                    new TableInfo(),
                    true,
                    new DataCellRowCoHeader[] { new DataCellRowCoHeader(new DataCell("Items:"), new DataCellRow(items, items.Length)) },
                    new DataCellRow(captions, captions.Length),
                    new TableHeaders(new DataCell("ItemsTableName"), new DataCell("Names"), null),
                    true
                );
            return tbl;
        }
        public void SetFromTable(TTable tbl)
        {
            if (tbl != null)
            {
                this.ItemsTableName = tbl.ToString(1, 1);
                this.ItemsTableItemsFieldName = tbl.ToString(2, 1);
                this.ItemsTableKeyFieldName = tbl.ToString(3, 1);
            }
        }
        //public  void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true){
        //    string cur;
        //    //cur = "Joined Table Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //         cur = "Joined Table Name:";
        //         cur = cur + " ";
        //    }
        //    cur = cur + this.ItemsTableName;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Items Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Items Field Name:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.ItemsTableItemsFieldName;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Items Key Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Items Key Field Name:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.ItemsTableKeyFieldName;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //}//fn
        //public void SetFromStringArray(string[]Arr, int QItems, int FromN=1)
        //{
        //    string curIni, curFin;
        //    string[] delims = { ",", " ", ";"};
        //    //
        //    curIni = MyLib.DelAllSubstrings(Arr[FromN+0 - 1], delims);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "JoinedTableName:");
        //    this.ItemsTableName = curFin;
        //    //
        //    curIni = MyLib.DelAllSubstrings(Arr[FromN+1 - 1], delims);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "ItemsFieldName:");
        //    this.ItemsTableItemsFieldName = curFin;
        //    //
        //    curIni = MyLib.DelAllSubstrings(Arr[FromN+2 - 1], delims);
        //    curFin = MyLib.DelAllSubstringSamples(curIni, "ItemsKeyFieldName:");
        //    this.ItemsTableKeyFieldName = curFin;
        //}//fn
    }//cl DBItemsTableData
    //
    public class TDBFieldHeaderCreationData : ICloneable
    {
        public int FieldTypeN;
        public string FieldTypeName;
        public int FieldLength;
        public int DBFieldCharacteristicsNumber;
        //9
        public bool isKeyField;
        public bool isCounter;
        public bool isNotNull;
        public bool isAutoIncrement;
        //
        public TDBFieldHeaderCreationData(int FieldTypeN=0, string FieldTypeName="", int FieldLength=0, int DBFieldCharacteristicsNumber=0, bool isKeyField = MyLib.BoolValByDefault, bool isCounter = MyLib.BoolValByDefault, bool isNotNull = MyLib.BoolValByDefault, bool isAutoIncrement = MyLib.BoolValByDefault)
        {
            this.FieldTypeN = FieldTypeN;
            this.FieldTypeName = FieldTypeName;
            this.FieldLength = FieldLength;
            this.DBFieldCharacteristicsNumber = DBFieldCharacteristicsNumber;
            //9
            this.isKeyField = isKeyField;
            this.isCounter = isCounter;
            this.isNotNull = isNotNull;
            this.isAutoIncrement = isAutoIncrement;
        }
        //
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        //public  void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true)
        //{
        //    string cur;//, strN;
        //    Arr=null;
        //    QItems=0;
        //    //
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "FieldTypeN:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.FieldTypeN;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "FieldTypeName:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //       cur = "FieldTypeName:";
        //       cur = cur + " ";
        //    }
        //    cur = cur + this.FieldTypeName;
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "FieldLength:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //       cur = "FieldLength:";
        //       cur = cur + " ";
        //    }
        //    cur = cur + this.FieldLength.ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "FieldCharacteristicNumber:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Field Characteristic Number:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + this.DBFieldCharacteristicsNumber.ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Is Key Field:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Is Key Field:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + MyLib.BoolToInt(this.isKeyField).ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Is Counter:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Is Counter:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + MyLib.BoolToInt(this.isCounter).ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Is Not Null:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Is Not Null:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + MyLib.BoolToInt(this.isNotNull).ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //    //cur = "Is AutoIncrement:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
        //    cur = "";
        //    if (WriteSupplInfo)
        //    {
        //        cur = "Is AutoIncrement:";
        //        cur = cur + " ";
        //    }
        //    cur = cur + MyLib.BoolToInt(this.isAutoIncrement).ToString();
        //    MyLib.AddToVector(ref Arr, ref QItems, cur);
        //}//fn
        ////
        //public  void SetFromStringArray(string[] Arr, int QItemsExt, int FromN=1)
        //{
        //    string curIni, curFin;
        //    string[] delims = { " ", ",", ";" };
        //    //if(QItemsExt>) = Arr.Length;
        //    int QItems=QItemsExt-FromN+1;
        //    //
        //    if (Arr != null)
        //    {
        //        QItems = Arr.Length;
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+0 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldTypeN:");
        //        this.FieldTypeN = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+1 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldTypeName:");
        //        this.FieldTypeName = curFin;
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+2 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldLength:");
        //        this.FieldLength = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+3 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "FieldCharacteristicNumber:");
        //        this.DBFieldCharacteristicsNumber = Convert.ToInt32(curFin);
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+4 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsKeyField:");
        //        this.isKeyField = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+5 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsCounter:");
        //        this.isCounter = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+6 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsNotNull:");
        //        this.isNotNull = MyLib.IntToBool(Convert.ToInt32(curFin));
        //        //
        //        curIni = MyLib.DelAllSubstrings(Arr[FromN+7 - 1], delims);
        //        curFin = MyLib.DelAllSubstringSamples(curIni, "IsAutoIncrement:");
        //        this.isAutoIncrement = MyLib.IntToBool(Convert.ToInt32(curFin));
        //    }
        //}//fn
    }//cl
    //
    public class TDBFieldCreationDataWithItemsTable : ICloneable
    {
        public TDBFieldHeaderCreationData DBFieldCreationData;
        public TDBItemsTableData ItemsTableData;
        //
        public TDBFieldCreationDataWithItemsTable(TDBFieldHeaderCreationData DBFieldCreationData = null, TDBItemsTableData ItemsTableData = null)
        {
            this.DBFieldCreationData = null;
            if (DBFieldCreationData != null)
            {
                this.DBFieldCreationData = (TDBFieldHeaderCreationData)DBFieldCreationData.Clone();
            }
            //
            this.ItemsTableData = null;
            if (ItemsTableData != null)
            {
                this.ItemsTableData = (TDBItemsTableData)ItemsTableData.Clone();
            }
        }
        //
        public object Clone()
        {
            TDBFieldCreationDataWithItemsTable obj = new TDBFieldCreationDataWithItemsTable();
            if (this.DBFieldCreationData != null)
            {
                obj.DBFieldCreationData = (TDBFieldHeaderCreationData)DBFieldCreationData.Clone();
            }
            if (this.ItemsTableData != null)
            {
                obj.ItemsTableData = (TDBItemsTableData)ItemsTableData.Clone();
            }
            return obj;
            //return this.MemberwiseClone();
        }
        public  void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true){
            //Arr=null;
            string cur;
            string[]ArrTbl=null;
            int QTblItems=0;
            //QItems=0;
            //if(this.DBFieldCreationData!=null){
            //    this.DBFieldCreationData.ToStringArray(ref Arr, ref QItems, WriteSupplInfo, WriteWholeInfo);
            //}else if(WriteWholeInfo){
            //    this.DBFieldCreationData=new TDBFieldHeaderCreationData();
            //    this.DBFieldCreationData.ToStringArray(ref Arr, ref QItems, WriteSupplInfo, WriteWholeInfo);
            //    this.DBFieldCreationData=null;
            //}   
            //if(this.ItemsTableData!=null){
            //    this.ItemsTableData.ToStringArray(ref ArrTbl, ref QTblItems, WriteSupplInfo, WriteWholeInfo);
            //    for(int i=1; i<=QTblItems; i++){
            //        MyLib.AddToVector(ref Arr, ref QItems, ArrTbl[i-1]);
            //    }
            //}else if(WriteWholeInfo){
            //    this.ItemsTableData=new TDBItemsTableData();
            //    this.ItemsTableData.ToStringArray(ref ArrTbl, ref QTblItems, WriteSupplInfo, WriteWholeInfo);
            //    for(int i=1; i<=QTblItems; i++){
            //        MyLib.AddToVector(ref Arr, ref QItems, ArrTbl[i-1]);
            //    }
            //    this.ItemsTableData=null;
            //}
            //
            if (this.DBFieldCreationData != null)
            {
                //string cur;//, strN;
                //Arr=null;
                //QItems=0;
                //
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldTypeN:";
                    cur = cur + " ";
                }
                cur = cur + this.DBFieldCreationData.FieldTypeN.ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldTypeName:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldTypeName:";
                cur = cur + " ";
                }
                cur = cur + this.DBFieldCreationData.FieldTypeName;
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldLength:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldLength:";
                    cur = cur + " ";
                }
                cur = cur + this.DBFieldCreationData.FieldLength.ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldCharacteristicNumber:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Field Characteristic Number:";
                    cur = cur + " ";
                }
                cur = cur + this.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Key Field:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Key Field:";
                    cur = cur + " ";
                }
                cur = cur + MyLib.BoolToInt(this.DBFieldCreationData.isKeyField).ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Counter:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Counter:";
                    cur = cur + " ";
                }
                cur = cur + MyLib.BoolToInt(this.DBFieldCreationData.isCounter).ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Not Null:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Not Null:";
                    cur = cur + " ";
                }
                cur = cur + MyLib.BoolToInt(this.DBFieldCreationData.isNotNull).ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is AutoIncrement:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is AutoIncrement:";
                    cur = cur + " ";
                }
                cur = cur + MyLib.BoolToInt(this.DBFieldCreationData.isAutoIncrement).ToString();
                MyLib.AddToVector(ref Arr, ref QItems, cur);
            }
            else if (WriteWholeInfo)
            {
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldTypeN:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldTypeName:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldTypeName:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldLength:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "FieldLength:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "FieldCharacteristicNumber:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Field Characteristic Number:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Key Field:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Key Field:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Counter:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Counter:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is Not Null:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is Not Null:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Is AutoIncrement:" + " " + MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Is AutoIncrement:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
            }
            if (this.ItemsTableData != null)
            {
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Joined Table Name:";
                    cur = cur + " ";
                }
                cur = cur + this.ItemsTableData.ItemsTableName;
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Items Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Items Field Name:";
                    cur = cur + " ";
                }
                cur = cur + this.ItemsTableData.ItemsTableItemsFieldName;
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Items Key Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Items Key Field Name:";
                    cur = cur + " ";
                }
                cur = cur + this.ItemsTableData.ItemsTableKeyFieldName;
                MyLib.AddToVector(ref Arr, ref QItems, cur);
            }
            else if (WriteWholeInfo)
            {
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Joined Table Name:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Items Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Items Field Name:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
                //cur = "Items Key Field Name:" + " " + this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName.ToString();
                cur = "";
                if (WriteSupplInfo)
                {
                    cur = "Items Key Field Name:";
                    cur = cur + " ";
                }
                cur = cur + "";
                MyLib.AddToVector(ref Arr, ref QItems, cur);
            }
        }//fn
        public void SetFromStringArray(string[] Arr, int QItemsExt, int FromN=1){
            int QItems=QItemsExt-FromN+1, LastN;
            string s1, s2, s3;
            string[]delims = {" ", ",", ";"};
            if(Arr!=null){
                //QItems=Arr.Length;
                if(QItems>0){
                    this.DBFieldCreationData=new TDBFieldHeaderCreationData();
                    //this.DBFieldCreationData.SetFromStringArray(Arr, QItems, 1);
                    //
                    s1 = Arr[FromN + 0 - 1];
                    s2 = MyLib.DelAllSubstrings(s1, delims);
                    s3 = MyLib.DelAllSubstringSamples(s2, "FieldTypeN:");
                    this.DBFieldCreationData.FieldTypeN = Convert.ToInt32(s3);
                    if(QItems>=2){
                        s1 = Arr[FromN + 1 - 1];
                        s2 = MyLib.DelAllSubstrings(s1, delims);
                        s3 = MyLib.DelAllSubstringSamples(s2, "FieldTypeName:");
                        this.DBFieldCreationData.FieldTypeName = s3;
                        LastN = FromN + 1;
                        if (QItems >= 3)
                        {
                            s1 = Arr[FromN + 2 - 1];
                            s2 = MyLib.DelAllSubstrings(s1, delims);
                            s3 = MyLib.DelAllSubstringSamples(s2, "FieldLength:");
                            this.DBFieldCreationData.FieldLength = Convert.ToInt32(s3);
                            LastN = FromN + 2;
                            if (QItems >= 4)
                            {
                             s1 = Arr[FromN + 3 - 1];
                                s2 = MyLib.DelAllSubstrings(s1, delims);
                                s3 = MyLib.DelAllSubstringSamples(s2, "FieldCharacteristicNumber:");
                                this.DBFieldCreationData.DBFieldCharacteristicsNumber = Convert.ToInt32(s3);
                                LastN = FromN + 3;
                                if (QItems >= 5)
                                {
                                    s1 = Arr[FromN + 4 - 1];
                                    s2 = MyLib.DelAllSubstrings(s1, delims);
                                    s3 = MyLib.DelAllSubstringSamples(s2, "IsKeyField:");
                                    this.DBFieldCreationData.isKeyField = MyLib.IntToBool(Convert.ToInt32(s3));
                                    LastN = FromN + 4;
                                    if (QItems >= 6)
                                    {
                                        s1 = Arr[FromN + 5 - 1];
                                        s2 = MyLib.DelAllSubstrings(s1, delims);
                                        s3 = MyLib.DelAllSubstringSamples(s2, "IsCounter:");
                                        this.DBFieldCreationData.isCounter = MyLib.IntToBool(Convert.ToInt32(s3));
                                        LastN = FromN + 5;
                                        if (QItems >= 6)
                                        {
                                            s1 = Arr[FromN + 6 - 1];
                                            s2 = MyLib.DelAllSubstrings(s1, delims);
                                            s3 = MyLib.DelAllSubstringSamples(s2, "IsNotNull:");
                                            this.DBFieldCreationData.isNotNull = MyLib.IntToBool(Convert.ToInt32(s3));
                                            LastN = FromN + 6;
                                            if (QItems >= 7)
                                            {
                                                s1 = Arr[FromN + 7 - 1];
                                                s2 = MyLib.DelAllSubstrings(s1, delims);
                                                s3 = MyLib.DelAllSubstringSamples(s2, "IsAutoIncrement:");
                                                this.DBFieldCreationData.isAutoIncrement = MyLib.IntToBool(Convert.ToInt32(s3));
                                                //
                                                LastN = FromN + 7;
                                                //
                                                if (QItems >= 8)
                                                {
                                                    this.ItemsTableData = new TDBItemsTableData();
                                                    //this.ItemsTableData.SetFromStringArray(Arr, QItems, FromN + 8);
                                                    //
                                                    s1 = Arr[LastN + 1 - 1];
                                                    s2 = MyLib.DelAllSubstrings(s1, delims);
                                                    s3 = MyLib.DelAllSubstringSamples(s2, "JoinedTableName:");
                                                    this.ItemsTableData.ItemsTableName = s3;
                                                    if (QItems >= 9)
                                                    {
                                                        s1 = Arr[LastN + 2 - 1];
                                                        s2 = MyLib.DelAllSubstrings(s1, delims);
                                                        s3 = MyLib.DelAllSubstringSamples(s2, "ItemsFieldName:");
                                                        this.ItemsTableData.ItemsTableItemsFieldName = s3;
                                                        if (QItems >= 10)
                                                        {
                                                            s1 = Arr[LastN + 3 - 1];
                                                            s2 = MyLib.DelAllSubstrings(s1, delims);
                                                            s3 = MyLib.DelAllSubstringSamples(s2, "ItemsKeyFieldName:");
                                                            this.ItemsTableData.ItemsTableKeyFieldName = s3;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }//fn SetFromStringArray
    }//cl
    //
    public class TDBFieldHeaderData : ICloneable
    {
        public string DBFieldNameToDBTable;
        public TDBFieldCreationDataWithItemsTable DBFieldHeaderDataSupplSpecial;
        //string[] items;
        //
        public TDBFieldHeaderData(string DBFieldNameToDBTable = "")
        {
            this.DBFieldNameToDBTable = DBFieldNameToDBTable;
            this.DBFieldHeaderDataSupplSpecial = null;
            //this.items = null;
        }
        public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
        {
            this.DBFieldNameToDBTable = DBFieldNameToDBTable;
            if (DBTableHeaderDataSupplSpecial != null)
            {
                this.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                this.DBFieldHeaderDataSupplSpecial = (TDBFieldCreationDataWithItemsTable)DBTableHeaderDataSupplSpecial.Clone();
            }
        }
        public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldHeaderCreationData DBFieldCreationData = null, TDBItemsTableData DBItemsTableData = null)
        {
            this.DBFieldNameToDBTable = DBFieldNameToDBTable;
            //public                                 TDBFieldHeaderDataSupplWithTableSpecial(TDBFieldHeaderDataSupplSpecial DBFieldCreationData = null, TDBItemsTableData ItemsTableData = null)
            this.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable(DBFieldCreationData, DBItemsTableData);
        }
        //
        public object Clone()
        {
            TDBFieldHeaderData obj=new TDBFieldHeaderData();
            obj.DBFieldNameToDBTable = this.DBFieldNameToDBTable;
            if (this.DBFieldHeaderDataSupplSpecial != null)
            {
                obj.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                obj.DBFieldHeaderDataSupplSpecial = (TDBFieldCreationDataWithItemsTable)this.DBFieldHeaderDataSupplSpecial;
            }
            return obj;
        }//fn Clone
        //
        public void ToStringArray(ref string[] Arr, ref int QItems, bool WriteSupplInfo = true, bool WriteWholeInfo = true){
            bool DBFieldHeaderDataSupplSpecial_exist = (DBFieldHeaderDataSupplSpecial != null);
            //Arr=null;
            string[]Arr1=null;
            int QContent=0;
            //QItems=0;
            string cur = "", name="DBFieldName: ";
            if (WriteSupplInfo)
            {
                cur = cur + name;
            }
            cur = cur + this.DBFieldNameToDBTable;
            MyLib.AddToVector(ref Arr, ref QItems, cur);
            if (this.DBFieldHeaderDataSupplSpecial != null || WriteWholeInfo)
            {
                if (this.DBFieldHeaderDataSupplSpecial == null && WriteWholeInfo)
                {
                    this.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                }
                this.DBFieldHeaderDataSupplSpecial.ToStringArray(ref Arr1, ref QContent, WriteSupplInfo, WriteWholeInfo);
                if (DBFieldHeaderDataSupplSpecial_exist == false)
                {
                    this.DBFieldHeaderDataSupplSpecial = null;
                }
                for (int i = 1; i <= QContent; i++)
                {
                    MyLib.AddToVector(ref Arr, ref QItems, Arr1[i - 1]);
                }
            }
        }//fn
        public void SetFromStringArray(string[] Arr, int QItemsExt, int FromN=1){
            string arrI=null;
            //string[] delims = {" ", ";", "," };
            string s1, s2, s3, name = "DBFieldName: ";
            int QItems;
            if(Arr!=null){
                QItems = QItemsExt - FromN + 1;
                if(QItems>=1){
                    s1 = Arr[FromN + 0 - 1];
                    s2 = s1;// MyLib.DelAllSubstrings(s1, delims);
                    if (s2.Length > name.Length && (s2.Substring(1 - 1, name.Length).Equals(name)))
                    {
                        s3 = s2.Substring(name.Length + 1 - 1, (s2.Length - name.Length));
                    }
                    else
                    {
                        s3 = s2;
                    }
                    this.DBFieldNameToDBTable = s3;
                    if(QItems>=2){
                        this.DBFieldHeaderDataSupplSpecial=new TDBFieldCreationDataWithItemsTable();
                        this.DBFieldHeaderDataSupplSpecial.SetFromStringArray(Arr, QItemsExt, FromN+1);
                    }
                }
            }
        }//fn
    }//cl
}//ns
