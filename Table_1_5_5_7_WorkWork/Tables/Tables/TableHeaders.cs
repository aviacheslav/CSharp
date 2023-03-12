using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    /*public class TableRowsGeneralNames
    {
        public string LinesGeneralName, ColsGeneralName;
        public TableRowsGeneralNames()
        {
            LinesGeneralName = ""; ColsGeneralName = "";
        }
    }*/
    public class TableHeaders:ICloneable
    {
        public DataCell TableHeader, LinesGeneralHeader, ColumnsGeneralHeader;
        public TableHeaders()
        {
            SetNull();
        }
        public TableHeaders(DataCell TableHeader, DataCell LinesGeneralName, DataCell ColumnsGeneralName)
        {
            SetNull();
            this.TableHeader = TableHeader;
            this.LinesGeneralHeader = LinesGeneralName;
            this.ColumnsGeneralHeader = ColumnsGeneralName;
        }
        public TableHeaders(string TableHeader1, string TableHeader2, string LinesGeneralName1, string LinesGeneralName2, string ColumnsGeneralName1, string ColumnsGeneralName2)
        {
            SetTableHeaderNames(TableHeader1, TableHeader2);
            SetLinesGeneralNames(LinesGeneralName1, LinesGeneralName2);
            SetColumnsGeneralNames(ColumnsGeneralName1, ColumnsGeneralName2);
        }
        public TableHeaders(int TableHeaderSize, int LinesGeneralNameSize, int ColumnsGeneralNameSize)
        {
            SetAllSizes(TableHeaderSize, LinesGeneralNameSize, ColumnsGeneralNameSize);
        }
        public TableHeaders(string TableCorner)
        {
            bool correct = true; 
            string TableName="", LinesGeneralName="", ColumnsGeneralName="";
            MyLib.ParseNamesOfTableCorner(TableCorner, ref correct, ref LinesGeneralName, ref ColumnsGeneralName, ref TableName);
            if (correct)
            {
                this.ColumnsGeneralHeader = new DataCell(ColumnsGeneralName);
                this.LinesGeneralHeader = new DataCell(LinesGeneralName);
                this.TableHeader = new DataCell(TableName);
            }

        }
        public object Clone()
        {
            DataCell TableHeader=null, LinesGeneralName=null, ColumnsGeneralName=null;
            if (this.TableHeader != null) TableHeader = (DataCell)this.TableHeader.Clone();
            if (this.LinesGeneralHeader != null) LinesGeneralName = (DataCell)this.LinesGeneralHeader.Clone();
            if (this.ColumnsGeneralHeader != null) ColumnsGeneralName = (DataCell)this.ColumnsGeneralHeader.Clone();
            return new TableHeaders( TableHeader, LinesGeneralName, ColumnsGeneralName);
        }
        public void SetNull()
        {
            TableHeader = null;
            LinesGeneralHeader = null;
            ColumnsGeneralHeader = null;
        }
        //
        public void CreateTableHeader()
        {
            string name = "";
            if (this.TableHeader != null) TableHeader = new DataCell(name);
        }
        public void DeleteTableHeader()
        {
            this.TableHeader = null;
        }
        public void CreateLinesGeneralName()
        {
            string name = "";
            if (this.LinesGeneralHeader != null) LinesGeneralHeader = new DataCell(name);
        }
        public void DeleteLinesGeneralName()
        {
            this.LinesGeneralHeader = null;
        }
        public void CreateColumnsGeneralName()
        {
            string name = "";
            if (this.ColumnsGeneralHeader != null) ColumnsGeneralHeader = new DataCell(name);
        }
        public void DeleteColumnsGeneralName()
        {
            this.ColumnsGeneralHeader = null;
        }
        //
        public void SetTableHeaders(DataCell TableHeader, DataCell LinesGeneralName, DataCell ColumnsGeneralName)
        {
            this.TableHeader = TableHeader;
            this.LinesGeneralHeader = LinesGeneralName;
            this.ColumnsGeneralHeader = ColumnsGeneralName;
        }
        public void SetTableHeader(DataCell TableHeader)
        {
            this.TableHeader = TableHeader;
        }
        public void SetLinesGeneralHeader(DataCell LinesGeneralName)
        {
            this.LinesGeneralHeader = LinesGeneralName;
        }
        public void SetColumnsGeneralHeader(DataCell ColumnsGeneralName)
        {
            this.ColumnsGeneralHeader = ColumnsGeneralName;
        }
        //
        public DataCell GetTableHeader()
        {
            return TableHeader;
        }
        public TDataCell GetTableHeaderInner()
        {
            return TableHeader.GetCell();
        }
        public string GetTableHeaderName()
        {
            return TableHeader.ToStringN(1);
        }
        public string GetTableHeaderName1()
        {
            return TableHeader.ToStringN(1);
        }
        public string GetTableHeaderName2()
        {
            return TableHeader.ToStringN(2);
        }
        //
        public void SetTableHeaderNames(string name1, string name2)
        {
            string[] Names = new string[2];
            if (name2 != null)
            {
                if (TableHeader != null)
                {
                    if (TableHeader.GetTypeN() != TableConsts.StringArrayTypeN || TableHeader.GetLength() != 2)
                    {
                        if (name1 != null)
                        {
                            Names[1 - 1] = name1;
                        }
                        Names[2 - 1] = name2;
                        TableHeader = new DataCell(Names, 2);
                    }
                    else
                    {
                        TableHeader.SetByArrString(Names, 2);
                    }
                }
                else //TableHeader == null
                {
                    Names[1 - 1] = name1; Names[2 - 1] = name2;
                    TableHeader = new DataCell(Names, 2);
                }
            }
            else //name2 == null
            {
                if (name1 != null)
                {
                    //name1=new string;
                    name1 = "";
                }
                if (TableHeader != null)
                {
                    if (TableHeader.GetTypeN() != TableConsts.StringTypeN || TableHeader.GetLength() != 1)
                    {
                        TableHeader = new DataCell(name1);
                    }
                    else
                    {
                        TableHeader.SetValAndTypeString(name1);
                    }
                }
                else
                {
                    TableHeader = new DataCell(name1);
                }
            }
        }//fn
        public void SetTableHeaderName(string name)
        {
            SetTableHeaderNames(name, null);
        }
        public void SetTableHeaderName1(string name)
        {
            TableHeader.SetByValStringN(name, 1);
        }
        public void SetTableHeaderName2(string name)
        {
            TableHeader.SetByValStringN(name, 2);
        }
        public void SetTableHeaderNameN(string name, int N)
        {
            TableHeader.SetByValStringN(name, N);
        }
        //
        public void SetLinesGeneralNames(string name1, string name2)
        {
            string[] Names = new string[2];
            if (name2 != null)
            {
                if (LinesGeneralHeader != null)
                {
                    if (LinesGeneralHeader.GetTypeN() != TableConsts.StringArrayTypeN || LinesGeneralHeader.GetLength() != 2)
                    {
                        if (name1 != null)
                        {
                            Names[1 - 1] = name1;
                        }
                        Names[2 - 1] = name2;
                        LinesGeneralHeader = new DataCell(Names, 2);
                    }
                    else
                    {
                        LinesGeneralHeader.SetByArrString(Names, 2);
                    }
                }
                else //LinesGeneralName == null
                {
                    Names[1 - 1] = name1; Names[2 - 1] = name2;
                    LinesGeneralHeader = new DataCell(Names, 2);
                }
            }
            else //name2 == null
            {
                if (name1 != null)
                {
                    //name1=new string;
                    name1 = "";
                }
                if (LinesGeneralHeader != null)
                {
                    if (LinesGeneralHeader.GetTypeN() != TableConsts.StringTypeN || LinesGeneralHeader.GetLength() != 1)
                    {
                        LinesGeneralHeader = new DataCell(name1);
                    }
                    else
                    {
                        LinesGeneralHeader.SetValAndTypeString(name1);
                    }
                }
                else
                {
                    LinesGeneralHeader = new DataCell(name1);
                }
            }
        }//fn
        public void SetLinesGeneralName(string name)
        {
            SetLinesGeneralNames(name, null);
        }
        public void SetLinesGeneralName1(string name)
        {
            LinesGeneralHeader.SetByValStringN(name, 1);
        }
        public void SetLinesGeneralName2(string name)
        {
            LinesGeneralHeader.SetByValStringN(name, 2);
        }
        public void SetLinesGeneralNameN(string name, int N)
        {
            LinesGeneralHeader.SetByValStringN(name, N);
        }
        //
        public DataCell GetLinesGeneralHeader()
        {
            return LinesGeneralHeader;
        }
        public TDataCell GetLinesGeneralHeaderInner()
        {
            return LinesGeneralHeader.GetCell();
        }
        public string GetLinesGeneralName()
        {
            string sr="";
            if (LinesGeneralHeader!=null) sr=LinesGeneralHeader.ToStringN(1);
            return sr;
        }
        public string GetLinesGeneralName1()
        {
            return LinesGeneralHeader.ToStringN(1);
        }
        public string GetLinesGeneralName2()
        {
            return LinesGeneralHeader.ToStringN(2);
        }
        //
        public void SetColumnsGeneralNames(string name1, string name2)
        {
            string[] Names = new string[2];
            if (name2 != null)
            {
                if (ColumnsGeneralHeader != null)
                {
                    if (ColumnsGeneralHeader.GetTypeN() != TableConsts.StringArrayTypeN || ColumnsGeneralHeader.GetLength() != 2)
                    {
                        if (name1 != null)
                        {
                            Names[1 - 1] = name1;
                        }
                        Names[2 - 1] = name2;
                        ColumnsGeneralHeader = new DataCell(Names, 2);
                    }
                    else
                    {
                        ColumnsGeneralHeader.SetByArrString(Names, 2);
                    }
                }
                else //ColumnsGeneralName == null
                {
                    Names[1 - 1] = name1; Names[2 - 1] = name2;
                    ColumnsGeneralHeader = new DataCell(Names, 2);
                }
            }
            else //name2 == null
            {
                if (name1 != null)
                {
                    //name1=new string;
                    name1 = "";
                }
                if (ColumnsGeneralHeader != null)
                {
                    if (ColumnsGeneralHeader.GetTypeN() != TableConsts.StringTypeN || ColumnsGeneralHeader.GetLength() != 1)
                    {
                        ColumnsGeneralHeader = new DataCell(name1);
                    }
                    else
                    {
                        ColumnsGeneralHeader.SetValAndTypeString(name1);
                    }
                }
                else
                {
                    ColumnsGeneralHeader = new DataCell(name1);
                }
            }
        }//fn
        public void SetColumnsGeneralName(string name)
        {
            SetColumnsGeneralNames(name, null);
        }
        public void SetColumnsGeneralName1(string name)
        {
            ColumnsGeneralHeader.SetByValStringN(name, 1);
        }
        public void SetColumnsGeneralName2(string name)
        {
            ColumnsGeneralHeader.SetByValStringN(name, 2);
        }
        public void SetColumnsGeneralNameN(string name, int N)
        {
            ColumnsGeneralHeader.SetByValStringN(name, N);
        }
        //
        public DataCell GetColumnsGeneralHeader()
        {
            return ColumnsGeneralHeader;
        }
        public TDataCell GetColumnsGeneralHeaderInner()
        {
            return ColumnsGeneralHeader.GetCell();
        }
        public string GetColumnsGeneralName()
        {
            string sr="";
            if (ColumnsGeneralHeader != null) sr = ColumnsGeneralHeader.ToStringN(1);
            return sr;
        }
        public string GetColumnsGeneralName1()
        {
            return ColumnsGeneralHeader.ToStringN(1);
        }
        public string GetColumnsGeneralName2()
        {
            return ColumnsGeneralHeader.ToStringN(2);
        }
        //
        public void SetTableHeaderSize(int TableHeaderSize)
        {
            string name = "";
            string[] Names = null;
            //int PrevLength;
            switch (TableHeaderSize)
            {
                case 1:
                    if (TableHeader != null)
                    {
                        name = TableHeader.ToString();
                        if (TableHeader.GetTypeN() != TableConsts.StringTypeN || TableHeader.GetLength() != 1)
                        {
                            TableHeader = new DataCell(name);
                        }
                    }
                    else
                    {
                        TableHeader = new DataCell(name);
                    }
                    break;
                case 2:
                    if (TableHeader != null)
                    {
                        Names = new string[2];
                        Names[1 - 1] = TableHeader.ToStringN(1); Names[2 - 1] = TableHeader.ToStringN(2);
                        if (TableHeader.GetTypeN() != TableConsts.StringArrayTypeN || TableHeader.GetLength() != 2)
                        {
                            TableHeader = new DataCell(Names, 2);
                        }
                    }
                    else
                    {
                        TableHeader = new DataCell(name);
                    }
                    break;
                default:
                    this.TableHeader = null;
                    break;
            }
        }
        public void SetLinesGeneralNameSize(int LinesGeneralNameSize)
        {
            string name = "";
            string[] Names = null;
            //int PrevLength;
            switch (LinesGeneralNameSize)
            {
                case 1:
                    if (LinesGeneralHeader != null)
                    {
                        name = LinesGeneralHeader.ToString();
                        if (LinesGeneralHeader.GetTypeN() != TableConsts.StringTypeN || LinesGeneralHeader.GetLength() != 1)
                        {
                            LinesGeneralHeader = new DataCell(name);
                        }
                    }
                    else
                    {
                        LinesGeneralHeader = new DataCell(name);
                    }
                    break;
                case 2:
                    if (LinesGeneralHeader != null)
                    {
                        Names = new string[2];
                        Names[1 - 1] = LinesGeneralHeader.ToStringN(1); Names[2 - 1] = LinesGeneralHeader.ToStringN(2);
                        if (LinesGeneralHeader.GetTypeN() != TableConsts.StringArrayTypeN || LinesGeneralHeader.GetLength() != 2)
                        {
                            LinesGeneralHeader = new DataCell(Names, 2);
                        }
                    }
                    else
                    {
                        LinesGeneralHeader = new DataCell(name);
                    }
                    break;
                default:
                    this.TableHeader = null;
                    break;
            }
        }
        public void SetColumnsGeneralNameSize(int ColumnsGeneralNameSize)
        {
            string name = "";
            string[] Names = null;
            //int PrevLength;
            switch (ColumnsGeneralNameSize)
            {
                case 1:
                    if (ColumnsGeneralHeader != null)
                    {
                        name = ColumnsGeneralHeader.ToString();
                        if (ColumnsGeneralHeader.GetTypeN() != TableConsts.StringTypeN || ColumnsGeneralHeader.GetLength() != 1)
                        {
                            ColumnsGeneralHeader = new DataCell(name);
                        }
                    }
                    else
                    {
                        ColumnsGeneralHeader = new DataCell(name);
                    }
                    break;
                case 2:
                    if (ColumnsGeneralHeader != null)
                    {
                        Names = new string[2];
                        Names[1 - 1] = ColumnsGeneralHeader.ToStringN(1); Names[2 - 1] = ColumnsGeneralHeader.ToStringN(2);
                        if (ColumnsGeneralHeader.GetTypeN() != TableConsts.StringArrayTypeN || ColumnsGeneralHeader.GetLength() != 2)
                        {
                            ColumnsGeneralHeader = new DataCell(Names, 2);
                        }
                    }
                    else
                    {
                        ColumnsGeneralHeader = new DataCell(name);
                    }
                    break;
                default:
                    this.TableHeader = null;
                    break;
            }
        }
        public void SetAllSizes(int TableHeaderSize, int LinesGeneralNameSize, int ColumnsGeneralNameSize)
        {
            SetTableHeaderSize(TableHeaderSize);
            SetLinesGeneralNameSize(LinesGeneralNameSize);
            SetColumnsGeneralNameSize(ColumnsGeneralNameSize);
        }//fn
        // DB ------------------------------------------------------------------------------------------------
        // Table ---------------------------------------------------------------------------------------------
        public string GetDBTableNameToDisplay()
        {
            string s="";
            if (this.TableHeader != null)
            {
                s=this.TableHeader.GetDBTableNameToDisplay();
            }
            return s;
        }
        public void SetDBTableNameToDisplay(string name)
        {
            if (this.TableHeader == null)
            {
                this.TableHeader =new DataCell();
            }
            this.TableHeader.SetDBFieldNameToDisplay(name);
        }
        //2 Тип БД BType
        public int GetDBTypeN()
        {
            int y = 0;
            if (this.TableHeader != null)
            {
                y = this.TableHeader.GetDBTypeN();
            }
            return y;
        }
        public void SetDBTypeN(int TypeN = 1) {
            if (this.TableHeader == null)
            {
                this.TableHeader = new DataCell();
            }
            this.TableHeader.SetDBTypeN(TypeN);
        }
        public string GetDBConnectionString()
        {
            string cs = "", DBFileFullName="";
            int DBTypeN=0;
            if (this.TableHeader != null)
            {
                DBFileFullName = this.GetDBFileFullName();// TableHeader.GetDBFileFullName();
                DBTypeN = this.TableHeader.GetDBTypeN();
                cs = MyLib.GetConnectionString(DBTypeN, DBFileFullName);
            }
            return cs;
        }
        //public override void SetDBConnectiobString(string ConnStr){
        //    this.
        //}
        //3 Путь к БД DBFileFullName
        public string GetDBFileFullName()
        {
            string DBFileFullName = "";
            if (this.TableHeader != null)
            {
                DBFileFullName = this.TableHeader.GetDBFileFullName();
            }
            return DBFileFullName;
        }
        public void SetDBFileFullName(string name)
        {
            if (this.TableHeader == null)
            {
                this.TableHeader = new DataCell();
            }
            this.TableHeader.SetDBFileFullName(name);
        }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public string GetDBNameInSDBC()
        {
            string s = "";
            if (this.TableHeader != null)
            {
                s = this.TableHeader.GetDBNameInSDBC();
            }
            return s;
        }
        public void SetDBNameInSDBC(string name)
        {
            if (this.TableHeader == null)
            {
                this.TableHeader = new DataCell();
            }
            this.TableHeader.SetDBNameInSDBC(name);
        }
        //5 Имя таблицы в БД
        public string GetDBTableNameInDB()
        {
            string s = "";
            if (this.TableHeader != null)
            {
                s = this.TableHeader.GetDBTableNameInDB();
            }
            return s;
        }
        public void SetDBTableNameInDB(string name)
        {
            if (this.TableHeader == null)
            {
                this.TableHeader = new DataCell();
            }
            this.TableHeader.SetDBTableNameInDB(name);
        }
        // Field LGH -----------------------------------------------------------------------------------------
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay_LGH() {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            return s;
        }
        public void SetDBFieldNameToDisplay_LGH(string name) {
            string s = "";
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldNameToDisplay(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable_LGH()
        {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetDBFieldNameInTable();
            }
            return s;
        }
        public void SetDBFieldNameInTable_LGH(string name)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldNameInTable(name);
        }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public string GetItemsDBTableNameInDB_LGH()
        {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetItemsDBTableNameInDB();
            }
            return s;
        }
        public void SetItemsDBTableNameInDB_LGH(string name)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetItemsDBTableNameInDB(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов Pr return ""; imaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName_LGH()
        {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetItemsDBTablePrimaryKeyFieldName();
            }
            return s;
        }
        public void SetItemsDBTablePrimaryKeyFieldName_LGH(string name)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetItemsDBTablePrimaryKeyFieldName(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName_LGH()
        {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetItemsDBTableItemsFieldName();
            }
            return s;
        }
        public void SetItemsDBTableItemsFieldName_LGH(string name)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetItemsDBTableItemsFieldName(name);
        }
        //6 Тип данных поля DB Field data type
        public int GetDBFieldTypeN_LGH()
        {
            int n = 0;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.LinesGeneralHeader.GetDBFieldTypeN();
            }
            return n;
        }
        public void SetDBFieldTypeN_LGH(int TypeN)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldTypeN(TypeN);
        }
        public string GetDBFieldTypeName_LGH()
        {
            string s = "";
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.LinesGeneralHeader.GetDBFieldTypeName();
            }
            return s;
        }
        public void SetDBFieldTypeName_LGH(string name)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldTypeName(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength_LGH()
        {
            int n = 0;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.LinesGeneralHeader.GetDBFieldLength();
            }
            return n;
        }
        public void SetDBFieldLength_LGH(int L)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldLength(L);
        }
        //8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity_LGH()
        //{
        //    int n = 0;
        //    if (this.LinesGeneralHeader != null)
        //    {
        //        //this.LinesGeneralHeader=new DataCell();
        ////        n = this.LinesGeneralHeader.GetDBFieldLength();
        //    }
        //    return n;
        //    
        //}
        public void SetItems_LGH(string[] items, int Q)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetItems(items, Q);
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
        public int GetDBFieldCharacteristicsNumber_LGH()
        {
            int n = 0;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.LinesGeneralHeader.GetDBFieldCharacteristicsNumber();
            }
            return n;
        }
        public void SetDBFieldCharacteristicsNumber_LGH(int number)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetDBFieldCharacteristicsNumber(number);
        }
        public bool IsKeyField_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.LinesGeneralHeader.IsKeyField();
            }
            return b;
        }
        public void SetIfKeyField_LGH(bool KeyField)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetIfKeyField(KeyField);
        }
        public void SetKeyField_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetKeyField();
        }
        public void SetNotKeyField_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetNotKeyField();
        }
        public bool IsCounter_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.LinesGeneralHeader.IsCounter();
            }
            return b;
        }
        public void SetIfCounter_LGH(bool isCounter)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetIfCounter(isCounter);
        }
        public void SetCounter_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetCounter();
        }
        public void SetNotCounter_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetNotCounter();
        }
        public bool IsAutoIncrement_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.LinesGeneralHeader.IsCounter();
            }
            return b;
        }
        public void SetIfAutoIncrement_LGH(bool isAutoIncrement)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetIfAutoIncrement(isAutoIncrement);
        }
        public void SetAutoIncrement_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetAutoIncrement();
        }
        public void SetNotAutoIncrement_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetNotAutoIncrement();
        }
        //
        public bool IsNotNull_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.LinesGeneralHeader != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.LinesGeneralHeader.IsNotNull();
            }
            return b;
        }
        public void SetIfNotNull_LGH(bool NotNull)
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetIfNotNull(NotNull);
        }
        public void SetNotNull_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetNotNull();
        }
        public void SetNotNotNull_LGH()
        {
            if (this.LinesGeneralHeader == null)
            {
                this.LinesGeneralHeader = new DataCell();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.LinesGeneralHeader.SetNotNotNull();
        }
        // Field_CGH -------------------------------------------------------------------------------------------
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            return s;
        }
        public void SetDBFieldNameToDisplay_CGH(string name)
        {
            string s = "";
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldNameToDisplay(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetDBFieldNameInTable();
            }
            return s;
        }
        public void SetDBFieldNameInTable_CGH(string name)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldNameInTable(name);
        }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public string GetItemsDBTableNameInDB_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetItemsDBTableNameInDB();
            }
            return s;
        }
        public void SetItemsDBTableNameInDB_CGH(string name)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetItemsDBTableNameInDB(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов Pr return ""; imaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetItemsDBTablePrimaryKeyFieldName();
            }
            return s;
        }
        public void SetItemsDBTablePrimaryKeyFieldName_CGH(string name)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetItemsDBTablePrimaryKeyFieldName(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetItemsDBTableItemsFieldName();
            }
            return s;
        }
        public void SetItemsDBTableItemsFieldName_CGH(string name)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetItemsDBTableItemsFieldName(name);
        }
        //6 Тип данных поля DB Field data type
        public int GetDBFieldTypeN_CGH()
        {
            int n = 0;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                n = this.ColumnsGeneralHeader.GetDBFieldTypeN();
            }
            return n;
        }
        public void SetDBFieldTypeN_CGH(int TypeN)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldTypeN(TypeN);
        }
        public string GetDBFieldTypeName_CGH()
        {
            string s = "";
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                s = this.ColumnsGeneralHeader.GetDBFieldTypeName();
            }
            return s;
        }
        public void SetDBFieldTypeName_CGH(string name)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldTypeName(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength_CGH()
        {
            int n = 0;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                n = this.ColumnsGeneralHeader.GetDBFieldLength();
            }
            return n;
        }
        public void SetDBFieldLength_CGH(int L)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldLength(L);
        }
        //8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity_CGH()
        //{
        //    int n = 0;
        //    if (this.ColumnsGeneralHeader != null)
        //    {
        //        //this.ColumnsGeneralHeader=new DataCell();
        ////        n = this.ColumnsGeneralHeader.GetDBFieldLength();
        //    }
        //    return n;
        //    
        //}
        public void SetItems_CGH(string[] items, int Q)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetItems(items, Q);
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
        public int GetDBFieldCharacteristicsNumber_CGH()
        {
            int n = 0;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                n = this.ColumnsGeneralHeader.GetDBFieldCharacteristicsNumber();
            }
            return n;
        }
        public void SetDBFieldCharacteristicsNumber_CGH(int number)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetDBFieldCharacteristicsNumber(number);
        }
        public bool IsKeyField_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                b = this.ColumnsGeneralHeader.IsKeyField();
            }
            return b;
        }
        public void SetIfKeyField_CGH(bool KeyField)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetIfKeyField(KeyField);
        }
        public void SetKeyField_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetKeyField();
        }
        public void SetNotKeyField_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetNotKeyField();
        }
        public bool IsCounter_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                b = this.ColumnsGeneralHeader.IsCounter();
            }
            return b;
        }
        public void SetIfCounter_CGH(bool isCounter)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetIfCounter(isCounter);
        }
        public void SetCounter_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetCounter();
        }
        public void SetNotCounter_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetNotCounter();
        }
        public bool IsAutoIncrement_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                b = this.ColumnsGeneralHeader.IsCounter();
            }
            return b;
        }
        public void SetIfAutoIncrement_CGH(bool isAutoIncrement)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetIfAutoIncrement(isAutoIncrement);
        }
        public void SetAutoIncrement_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetAutoIncrement();
        }
        public void SetNotAutoIncrement_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetNotAutoIncrement();
        }
        //
        public bool IsNotNull_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.ColumnsGeneralHeader != null)
            {
                //this.ColumnsGeneralHeader=new DataCell();
                b = this.ColumnsGeneralHeader.IsNotNull();
            }
            return b;
        }
        public void SetIfNotNull_CGH(bool NotNull)
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetIfNotNull(NotNull);
        }
        public void SetNotNull_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetNotNull();
        }
        public void SetNotNotNull_CGH()
        {
            if (this.ColumnsGeneralHeader == null)
            {
                this.ColumnsGeneralHeader = new DataCell();
                //s = this.ColumnsGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.ColumnsGeneralHeader.SetNotNotNull();
        }
    }//cl TblHdrs
}//ns   //2020-08-12
