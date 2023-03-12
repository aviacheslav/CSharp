using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Threading;

namespace CW_2015_01_18_p1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        //
        int ChosenTrainN;
        int CardN; 
        int TrainN;
        double ChosenPrice;
        double TeaPrice, LingeriePrice, SumPrice;
        double CardSum;
        

        public Form1()
        {
            InitializeComponent();
            ButtonPay.Visible = false;
            label3.Visible = false;
            textCardN.Visible = false;
            
            TeaPrice=12;
            LingeriePrice = 25;
        }

        private bool Connect()
        {
            bool b = false;
            try
            {
                SqlConnectionStringBuilder ConB = new SqlConnectionStringBuilder();
                ConB.DataSource = "10.3.0.5";//for ClassWork
                ConB.DataSource = "(local)";//for HomeComp
                ConB.InitialCatalog = "TrainsTownsTickets";
               // ConB.InitialCatalog = "Trains";//ForHomeComp
                //ConB.InitialCatalog = "ÀfoninGroupPP2209_Trains";//?
                ConB.IntegratedSecurity = false;//ForClassWork
                ConB.IntegratedSecurity = true;//for home comp
                //ConB.UserID = "pp2022";//for classWork
                //ConB.Password = "pp2022";//for classWork
                //ConB.UserID & ConB.Password - commented for HomeComp
                con = new SqlConnection();
                con.ConnectionString = ConB.ConnectionString;
                con.Open();
                b=true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Невозможно открыть соединение: "+exc.Message);
                try
                {
                    con.Close();
                }
                catch (Exception exc1)
                {
                    MessageBox.Show("Невозможно закрыть соединение");
                }
            }
            return b;
        }
        private bool Disconnect(){
            bool b=false;
            try
            {
                con.Close();
                b = true;
            }
            catch (Exception exc1)
            {
                MessageBox.Show("Невозможно закрыть соединение");
            }
            return b;
        }

        private void ButtonDemand_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;//Индикатор урок 2
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 150;
            progressBar1.Step = 1;
            //
            for (int i = 0; i <= 150; i++)//Работа индикатора
            {

                progressBar1.PerformStep();
                this.Update();
                Thread.Sleep(50);

            }
            ShowRoots();
        }//fn

        private void ShowBank()
        {
            if (Connect())
            {
                int QColumns=2;
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 0;// 2;
                String ShowBankCommand = "Select CardN, Sum from BankCardsStr";
                String[] row = new String[QColumns];
                com = new SqlCommand(ShowBankCommand, con);
                reader = com.ExecuteReader();
                for (int i = 0; i < QColumns; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }
                while (reader.Read())
                {
                    for (int i = 0; i < QColumns; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    dataGridView1.Rows.Add(row);
                }
            }
        }
        private void ShowRoots()
        {
            if (Connect())
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 0;
                String From = textWhereFrom.Text;
                String To = textWhereTo.Text;
                String Train_N = textTrainN.Text;
                String FromIncl = " TownFrom like '" + textWhereFrom.Text + "'",
                       ToIncl = " TownTo like '" + textWhereTo.Text + "'",
                       TrNIncl = " train_id = '" + Train_N + "'",
                    //1 111 Заданы From, To и TrainN:
                       SupplFromAndToAndTrN = FromIncl + " and " + ToIncl + " and " + TrNIncl,
                    //2 110 Заданы From и To:
                       SupplFromAndTo = FromIncl + " and " + ToIncl,
                    //3 101 Заданы From и TrainN:
                       SupplFromAndTrN = FromIncl + " and " + TrNIncl,
                    //4 100 1 Задано From:
                       SupplFromOnly = FromIncl,
                    //5 011 Заданы To и TrainN:
                       SupplToAndTrN = ToIncl + " and " + TrNIncl,
                    //6 010  Задано To:
                       SupplToOnly = ToIncl,
                    //7 001  Задано TrainN:
                       SupplTrnNOnly = TrNIncl,
                    //8 000 не задано ничего
                    //SupplNull=" ",
                       FinalCommand = null;
                //SupplFromAndToAndTrN=FromIncl+" and "+ToIncl;
                string select = "Select id_train as 'Номер поезда', TownFrom as 'Город отправления',TownTo as 'Город прибытия', date as 'Дата отправления',QPk as 'Кол-во плацкартных мест',PkPrice as 'Цена плацкартных мест',QSv as 'Кол-во мест СВ',SvPrice as 'Цена места СВ',QKp as 'Кол-во мест купе',KpPrice as 'Цена места купе' from myview";//trains_Id";//v_trains";
                //1) 111
                if (!string.IsNullOrEmpty(From) && !string.IsNullOrEmpty(To) && !string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplFromAndToAndTrN;
                    MessageBox.Show("From And To And TrN");
                }
                //2  110
                if (!string.IsNullOrEmpty(From) && !string.IsNullOrEmpty(To) && string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplFromAndTo;
                    MessageBox.Show("From And To");
                }
                //3 101
                if (!string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To) && !string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + SupplFromAndTrN;
                    MessageBox.Show("From And TrN");
                }
                //4) 100
                if (!string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To) && string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplFromOnly;
                    MessageBox.Show("From");
                }
                //5 011
                if (string.IsNullOrEmpty(From) && !string.IsNullOrEmpty(To) && !string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplToAndTrN;
                    MessageBox.Show("To And TrN");
                }
                //6 010
                if (string.IsNullOrEmpty(From) && !string.IsNullOrEmpty(To) && string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplToOnly;
                    MessageBox.Show("To");
                }
                //7) 001
                if (string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To) && !string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select + " where " + SupplTrnNOnly;
                    MessageBox.Show("TrnN");
                }
                //8) 000
                if (string.IsNullOrEmpty(From) && string.IsNullOrEmpty(To) && string.IsNullOrEmpty(Train_N))
                {
                    FinalCommand = select;
                }

                com = new SqlCommand(FinalCommand, con);
                //com = con.CreateCommand();      //also w...
                //com.CommandText = FinalCommand; //...also work (these 2 lines together)
                reader = com.ExecuteReader();

                int QColumns = reader.FieldCount;
                dataGridView1.Visible = true;

               for (int i = 0; i < QColumns; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }
                String[] row = new String[QColumns];
                while (reader.Read())
                {
                    for (int i = 0; i < QColumns; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    dataGridView1.Rows.Add(row);
                }
                try
                {
                    reader.Close();
                    con.Close();
                }
                catch (Exception exc2)
                {
                    MessageBox.Show("Невозможно закрыть соединение");
                }
                ButtonPay.Visible = true;
                label3.Visible = true;
                textCardN.Visible = true;
                //MessageBox.Show(dataGridView1);
            }//if connect
        }

        private void ButtonPay_Click(object sender, EventArgs e)
        {
            if (Connect())
            {
                //int CurCardN;
                string CurCardNStr=null, CurSumStr, CardNStr;
                double CurSum = 0,
                       KpPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[10 - 1].Value),
                       PkPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[06 - 1].Value),
                       SvPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[08 - 1].Value);
                bool PkChosen = false, KpChosen = false, SvChosen = false, SumEnough = false, PlaceExists = false, CardExists = false;
                int CurLinN = dataGridView1.CurrentRow.Index,
                    Qkp = Convert.ToInt32(dataGridView1.CurrentRow.Cells[09 - 1].Value),
                    Qpk = Convert.ToInt32(dataGridView1.CurrentRow.Cells[05 - 1].Value),
                    QSv = Convert.ToInt32(dataGridView1.CurrentRow.Cells[07 - 1].Value),
                    ChosenTrainN = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1 - 1].Value);
                MessageBox.Show("поезд " + ChosenTrainN.ToString()+ "\n Купе " + Qkp.ToString() + " по " + KpPrice.ToString() + "\n плацкарт " + Qpk.ToString() + " по " + PkPrice.ToString() + "\n СВ " + QSv.ToString() + " по " + SvPrice.ToString());//+" \n Стоимость: "+SumPrice.ToString());

                CardNStr = textCardN.Text;
                if ((CardNStr != null) && (CardNStr != ""))
                {
                    //CardN = Convert.ToInt32(CardNStr);
                    TrainN = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    //pk
                    if (radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
                    {
                        PkChosen = true;
                        ChosenPrice = PkPrice;// Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].ToString());
                    }
                    //kp
                    if (!radioButton1.Checked && radioButton2.Checked && !radioButton3.Checked)
                    {
                        KpChosen = true;
                        ChosenPrice = KpPrice; //Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    }
                    //sv
                    if (!radioButton1.Checked && !radioButton2.Checked && radioButton3.Checked)
                    {
                        SvChosen = true;
                        ChosenPrice = SvPrice; //Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    }
                    SumPrice = ChosenPrice;
                    if (checkBoxTea.Checked) SumPrice += TeaPrice;
                    if (checkBoxBedLingerie.Checked) SumPrice += LingeriePrice;

                    string ACommand = "select * from BankCardsStr where CardN= '" + CardNStr + "'";
                    com = new SqlCommand(ACommand, con);
                    reader = com.ExecuteReader();
                    int QColumns = reader.FieldCount;
                    while (reader.Read())
                    {
                        CurCardNStr = reader[2 - 1].ToString();
                        // CurCardN=Convert.ToInt32(CurCardNStr);
                        if (CurCardNStr.Equals(CardNStr))
                        {
                            CardExists = true;
                            CurSumStr = reader[3 - 1].ToString();
                            CurSum = Convert.ToDouble(CurSumStr);
                            //MessageBox.Show("Here's the Card: " + CurCardNStr);
                            if (CurSum >= SumPrice)
                            {
                                SumEnough = true;
                            }
                            MessageBox.Show("Here's the Card: " + CurCardNStr + " sum=" + CurSum);
                        }
                        else
                        {
                            MessageBox.Show("Card (not demanded): " + CurCardNStr);
                        }
                    }
                    try
                    {
                        reader.Close();
                        con.Close();
                    }
                    catch (Exception exc2)
                    {
                        MessageBox.Show("Невозможно закрыть соединение");
                    }
                    if (PkChosen && (Qpk > 0)) PlaceExists = true;
                    if (KpChosen && (Qkp > 0)) PlaceExists = true;
                    if (SvChosen && (QSv > 0)) PlaceExists = true;
                    if (!PlaceExists)
                    {
                        MessageBox.Show("Нет свободных мест этого типа");
                    }
                    if (!CardExists)
                    {
                        MessageBox.Show("The card with such a number isn't registered in the bank");
                    }
                    if (!SumEnough)
                    {
                        MessageBox.Show("Not enough cash to pay for the ticket");
                    }
                    if (PlaceExists && CardExists && SumEnough)
                    {
                        //
                        if (PkChosen)
                        {
                            MessageBox.Show("1 билет \n поезд " + ChosenTrainN.ToString()  + "\n плацкарт ("  + PkPrice.ToString() + ") \n Стоимость: " + SumPrice.ToString());
                        }
                        if (KpChosen)
                        {
                            MessageBox.Show("1 билет \n поезд " + ChosenTrainN.ToString() + "\n купе (" + KpPrice.ToString() + ") \n Стоимость: " + SumPrice.ToString());
                        }
                        if (SvChosen)
                        {
                            MessageBox.Show("1 билет \n поезд " + ChosenTrainN.ToString() + "\n СВ (" + SvPrice.ToString() + ") \n Стоимость: " + SumPrice.ToString());
                        }
                        //
                        MessageBox.Show("Now you'll see cash");
                        ShowBank();
                        //
                        String CommandToPay = "Begin Transaction ";
                        CommandToPay += "UPDATE BankCardsStr SET Sum= Sum-" + SumPrice.ToString() + " WHERE CardN= '" + CurCardNStr+"' ";
                        CommandToPay += " UPDATE BankCardsStr SET Sum= Sum+" + SumPrice.ToString() + " WHERE CardN=" + "'6666'";
                        MessageBox.Show("demanded to update cards");
                        if (PkChosen)
                        {
                            CommandToPay += " UPDATE Roots SET QPk= QPk-1 where id_Train=" + ChosenTrainN.ToString();
                            MessageBox.Show("demanded to update Pk");
                        }
                        if (KpChosen)
                        {
                            CommandToPay += " UPDATE Roots SET QKp= QKp-1 where id_Train=" + ChosenTrainN.ToString();
                            MessageBox.Show("demanded to update Kp");
                        }
                        if (SvChosen)
                        {
                            CommandToPay += " UPDATE Roots SET QSv= QSv-1 where id_Train=" + ChosenTrainN.ToString();
                            MessageBox.Show("demanded to update Sv");
                        }
                        CommandToPay += " Commit Transaction";
                       
                        if(Connect()){
                            com = new SqlCommand(CommandToPay, con);
                            /*SqlDataReader*/ reader/*1**/ = com.ExecuteReader();
                            try
                            {
                                reader/*1*/.Close();
                                con.Close();
                            }
                            catch (Exception exc3)
                            {
                                MessageBox.Show("Connection can't be closed");
                            }
                            MessageBox.Show("Cash after operation");
                            ShowBank();
                            MessageBox.Show("Again to tickets...");
                            ShowRoots();
                        }
                    }
                }
            } 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } //fn
    }//cl
}//ns
//Доработать приложение "Онлайн покупка ЖД билетов". Добавить возможность оплаты выбранного билета (по номеру поезда, типу вагона, дополнительным опциям).
//Реализовать транзакционный режим работы с базой.
//
//* Реализовать оплату с пластиковой карты (из одной базы списывается сумма со счета,а в другую базу сумма заносится на счет).