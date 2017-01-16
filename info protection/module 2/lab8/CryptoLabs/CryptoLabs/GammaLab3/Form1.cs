using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using CryptoLib;

namespace CaezazLab1
{
    public partial class Form1 : Form
    {
        private int offsetText = 3;
        public Form1()
        {
            InitializeComponent();
            tbPath.LostFocus += tbPath_LostFocus;
            
            cBAlphabetText.DataSource = Enum.GetValues(typeof(Alphabets));

            tBOffsetText.Text = "3";

            tBOffsetText.LostFocus += tBOffsetText_LostFocus;
        }

        void tBOffsetText_LostFocus(object sender, EventArgs e)
        {
            int result;
            if (!int.TryParse(tBOffsetText.Text, out result))
            {
                errorPr.SetError(tBOffsetText, "Incorrect input! Please, input integer.");
            }
            else
            {
                offsetText = result;
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
                Gamma cz = new Gamma((Alphabets) cBAlphabetText.SelectedItem);
                string codyfiedText = cz.CryptFile(tbPath.Text, offsetText);
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
                Gamma cz = new Gamma((Alphabets) cBAlphabetText.SelectedItem);
                string codyfiedText = cz.DecryptFile(tbPath.Text, offsetText);
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
                    Gamma cz = new Gamma((Alphabets) cBAlphabetText.SelectedItem);
                    rTBOutput.Text = cz.Crypt(rTBInput.Text, offsetText);
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
                    Gamma cz = new Gamma((Alphabets) cBAlphabetText.SelectedItem);
                    rTBOutput.Text = cz.Decrypt(rTBInput.Text, offsetText);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Некоректний символ: " + ex.Message);
                }
            }
        }


    }
}
