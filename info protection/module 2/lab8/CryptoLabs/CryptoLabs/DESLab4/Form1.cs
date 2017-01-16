using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CryptoLib;
using DES = CryptoLib.DES;

namespace DESLab4
{
    public partial class Form1 : Form
    {
        private string key = "KeyKeyKe";
        public Form1()
        {
            InitializeComponent();
            tbPath.LostFocus += tbPath_LostFocus;


            tBKey.Text = "KeyKeyKe";
            tBKey.LostFocus += tBKey_LostFocus;
            
        }

        void tBKey_LostFocus(object sender, EventArgs e)
        {
            errorPr.SetIconPadding(tBKey, -20);
            if (tBKey.Text.Trim().Length!=8)
            {
                errorPr.SetError(tBKey, "Incorrect input! (Key must have 8 chars).");
                btnEncryptText.Enabled = false;
                btnDecryptText.Enabled = false;
            }
            else
            {
                key = tBKey.Text.Trim();
                btnEncryptText.Enabled = true;
                btnDecryptText.Enabled = true;
                errorPr.Clear();
            }
        }

        void tbPath_LostFocus(object sender, EventArgs e)
        {
            if (!File.Exists(tbPath.Text.Replace('\\','/'))&&tbPath.Text.Length>0)
            {
                errorPr.SetIconPadding(tbPath,-20);
                errorPr.SetError(tbPath, "File does not exists!");
            }
            else
            {
                errorPr.SetError(tbPath,"");
            }
        }


        private void butOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog=new OpenFileDialog();
            ofDialog.FileOk += ofDialog_FileOk;
            ofDialog.Filter = @"Text files (*.txt) |*.txt|All files |*.*";
            ofDialog.ShowDialog(this);
        }

        void ofDialog_FileOk(object sender, CancelEventArgs e)
        {
            tbPath.Text = ((OpenFileDialog) sender).FileName;
            rTBInput.Text = File.ReadAllText(tbPath.Text, Encoding.UTF8);
        }

        void sfDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                StreamWriter newFile = File.CreateText(((SaveFileDialog) sender).FileName.Replace('\\', '/'));
                DES des=new DES();
                string codyfiedText = des.Crypt(rTBInput.Text,key);
                newFile.Write(codyfiedText);
                newFile.Close();
                Process.Start("C:\\Windows\\System32\\notepad.exe", ((SaveFileDialog) sender).FileName);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, "Некоректний символ: " + ex.Message);
            }
        }

        private void sfDialog2_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                StreamWriter newFile = File.CreateText(((SaveFileDialog) sender).FileName.Replace('\\', '/'));
                DES cz = new DES();
                string codyfiedText = cz.DecryptFile(tbPath.Text, key);
                newFile.Write(codyfiedText);
                newFile.Close();
                Process.Start("C:\\Windows\\System32\\notepad.exe", ((SaveFileDialog) sender).FileName);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, "Некоректний символ: " + ex.Message);
            }
        }

        private void btnEncryptionText_Click(object sender, EventArgs e)
        {
            if (chBWTF.Checked)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.FileOk += sfDialog_FileOk;
                sfDialog.Filter = @"Text files (*.txt) |*.txt|All files |*.*";
                sfDialog.ShowDialog(this);
            }
            else
            {
                try
                {
                    DES des = new DES();
                    rTBOutput.Text = des.Crypt(rTBInput.Text, key);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Некоректний символ: " + ex.Message);
                }
            }
        }

        private void btnDecryptionText_Click(object sender, EventArgs e)
        {
            if (chBWTF.Checked)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.FileOk += sfDialog2_FileOk;
                sfDialog.Filter = @"Text files (*.txt) |*.txt|All files |*.*";
                sfDialog.ShowDialog(this);
            }
            else
            {
                try
                {
                    DES des=new DES();
                    
                    rTBOutput.Text = des.Decrypt(rTBInput.Text, key);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Некоректний символ: " + ex.Message);
                }
            }
        }


    }
}
