﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PTTK
{
    public partial class Update_InfoHV : Form
    {
        SqlConnection con = new SqlConnection(Account.connectString);
        string fr_maHV;
        public Update_InfoHV(string maHV)
        {
            InitializeComponent();
            textBox2.Visible = false;
            label2.Visible = false;
            fr_maHV = maHV;
        }
        public Update_InfoHV()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox3.Enabled = false;
        }

        private void Update_InfoHV_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "TraCuuThongTin";
            cmd.CommandType = CommandType.StoredProcedure;

            if (Account.username.Contains("QLHV"))
            {
                cmd.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = fr_maHV;                
            }
            else
            {
                cmd.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = Account.username;
            }
            cmd.ExecuteNonQuery();
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
            textBox4.Text = dt.Rows[0].ItemArray[3].ToString();
            textBox5.Text = dt.Rows[0].ItemArray[4].ToString();
            textBox6.Text = dt.Rows[0].ItemArray[5].ToString();
            textBox7.Text = dt.Rows[0].ItemArray[6].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "ChinhSuaThongTin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = textBox1.Text;
            cmd.Parameters.Add("@pw", SqlDbType.VarChar, 20).Value = textBox2.Text;
            cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 50).Value = textBox3.Text;
            cmd.Parameters.Add("@cccd", SqlDbType.Char, 12).Value = textBox4.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = textBox5.Text;
            cmd.Parameters.Add("@sdt", SqlDbType.Char, 10).Value = textBox6.Text;
            cmd.Parameters.Add("@ngaysinh", SqlDbType.Date, 8).Value = textBox7.Text;


            try
            { 
            cmd.ExecuteNonQuery();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
    }
}
