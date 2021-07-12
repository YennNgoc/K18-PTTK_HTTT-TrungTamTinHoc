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
    public partial class LapHoaDon : Form
    {
        SqlConnection con = new SqlConnection(Account.connectString);
        public LapHoaDon()
        {
            InitializeComponent();
            con.Open();
        }

        private void butt_check_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "TraCuuDSHP";
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = tb_maHV.Text;
            cmd.Parameters.Add("@mahk", SqlDbType.Char, 4).Value = tb_maHK.Text;

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = "tongHD_return";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = tb_maHV.Text;
            cmd2.Parameters.Add("@mahk", SqlDbType.Char, 4).Value = tb_maHK.Text;
            var returnParameter = cmd.Parameters.Add("@sum", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd2.ExecuteNonQuery();
                textBox1.Text = returnParameter.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "LapHD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@manv", SqlDbType.Char, 8).Value = Account.username;
            cmd.Parameters.Add("@mahv", SqlDbType.Char, 8).Value = tb_maHV.Text;
            cmd.Parameters.Add("@mahk", SqlDbType.Char, 4).Value = tb_maHK.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
