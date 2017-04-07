﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Edward;

namespace BarcodeScan
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            this.Text = "Setting... <" + Application.ProductName + "Ver:" + Application.ProductVersion + ">";
            loadUI();
        }


        #region SetPort

        private void combPLC_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.PLC_Baud_Rate = combPLC_BaudRate.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.PLC_COM.ToString(), "PLC_Baud_Rate", p.PLC_Baud_Rate, p.IniFilePath);
        }

        private void combBar_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_Baud_Rate = combBar_BaudRate.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_Baud_Rate", p.Scan_Baud_Rate, p.IniFilePath);
        }

        private void combPLC_DataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.PLC_Data_Bits = combPLC_DataBits.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.PLC_COM.ToString(), "PLC_Data_Bits", p.PLC_Data_Bits, p.IniFilePath);
        }

        private void combBar_DataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_Data_Bits = combBar_DataBits.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_Data_Bits", p.Scan_Data_Bits, p.IniFilePath);
        }

        private void combPLC_StopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

            p.PLC_Stop_Bits = (StopBits)Enum.Parse(typeof(StopBits), combPLC_StopBits.SelectedItem.ToString());
            IniFile.IniWriteValue(p.IniSection.PLC_COM.ToString(), "PLC_Stop_Bits", p.PLC_Stop_Bits.ToString(), p.IniFilePath);
        }

        private void combBarStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_Stop_Bits = (StopBits)Enum.Parse(typeof(StopBits), combBarStopBits.SelectedItem.ToString());
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "PLC_Stop_Bits", p.Scan_Stop_Bits.ToString(), p.IniFilePath);
        }

        private void combPLC_Parity_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.PLC_Parity = (Parity)Enum.Parse(typeof(Parity), combPLC_Parity.SelectedItem.ToString());
            IniFile.IniWriteValue(p.IniSection.PLC_COM.ToString(), "PLC_Parity", p.PLC_Parity.ToString(), p.IniFilePath);
        }

        private void combBar_Parity_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_Parity = (Parity)Enum.Parse(typeof(Parity), combBar_Parity.SelectedItem.ToString());
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "PLC_Parity", p.Scan_Parity.ToString(), p.IniFilePath);
        }

        #endregion

        #region loadUI

        private void loadUI()
        {
            //
            this.combPLC_BaudRate.Text = p.PLC_Baud_Rate;
            this.combPLC_DataBits.Text = p.PLC_Data_Bits;
            this.combPLC_StopBits.Text = p.PLC_Stop_Bits.ToString();
            this.combPLC_Parity.Text = p.PLC_Parity.ToString();
            //
            this.combBar_BaudRate.Text = p.Scan_Baud_Rate;
            this.combBar_DataBits.Text = p.PLC_Data_Bits;
            this.combBarStopBits.Text = p.Scan_Stop_Bits.ToString();
            this.combBar_Parity.Text = p.Scan_Parity.ToString();
            //
            this.txtOpen_Scan_Command.Text = p.Open_Scan_Command.Trim();
            this.txtClose_Scan_Command.Text = p.Close_Scan_Command.Trim();
            //
            this.chkOpen_Add_Enter.Checked = Convert.ToBoolean(p.Open_Add_Enter);
            this.chkClose_Add_Enter.Checked = Convert.ToBoolean(p.Close_Add_Enter);

        }


        #endregion

        private void txtOpen_Scan_Command_TextChanged(object sender, EventArgs e)
        {
            p.Open_Scan_Command = txtOpen_Scan_Command.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Open_Scan_Command", p.Open_Scan_Command, p.IniFilePath);
        }

        private void txtClose_Scan_Command_TextChanged(object sender, EventArgs e)
        {
            p.Close_Scan_Command = txtClose_Scan_Command.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Close_Scan_Command", p.Close_Scan_Command, p.IniFilePath);
        }

        private void chkOpen_Add_Enter_CheckedChanged(object sender, EventArgs e)
        {
            p.Open_Add_Enter = chkOpen_Add_Enter.Checked;
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Open_Add_Enter", p.Open_Add_Enter.ToString(), p.IniFilePath);
        }

        private void chkClose_Add_Enter_CheckedChanged(object sender, EventArgs e)
        {
            p.Close_Add_Enter = chkClose_Add_Enter.Checked;
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Close_Add_Enter", p.Close_Add_Enter.ToString(), p.IniFilePath);
        }




    }



}
