using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CryptoLib;
using info.lundin.Math;

namespace TritemiumLab2
{
    public partial class TritemiumForm : Form
    {
        public TritemiumForm()
        {
            InitializeComponent();
            tbPath.LostFocus += tbPath_LostFocus;
            
            cBAlphabetText.DataSource = Enum.GetValues(typeof(Alphabets));

            tBKey.Text = "3";

            tBKey.LostFocus += tBOffsetText_LostFocus;

            cBKeyType.Items.Add("Expression"); 
            cBKeyType.Items.Add("Motto");
            cBKeyType.SelectedIndex = 0;
        }

        void tBOffsetText_LostFocus(object sender, EventArgs e)
        {
            switch (cBKeyType.SelectedItem.ToString())
            {
                case "Expression":
                {
                    ExpressionParser expressionParser = new ExpressionParser();
                    Hashtable variables = new Hashtable();
                    variables.Add("t", "1");
                    try
                    {
                        double result = expressionParser.Parse(tBKey.Text.Trim(), variables);
                        errorPr.Clear();
                    }
                    catch (Exception)
                    {
                        errorPr.SetError(tBKey, "Incorrect input! Please, input correct expression (Varibles' name is t.");
                    }
                    break;
                }
                case "Motto":
                {
                    if (tBKey.Text.Length > 0)
                    {
                        errorPr.Clear();
                    }
                    else
                    {
                        errorPr.SetError(tBKey, "Incorrect input! Please, input motto (lenght>0).");
                    }
                    break;
                }
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
                newFile.Write(CryptFile());
                newFile.Close();
                Process.Start("C:\\Windows\\System32\\notepad.exe", ((SaveFileDialog) sender).FileName);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, "Некоректний символ: " + ex.Message);
            }
        }

        private string CryptText()
        {
            switch (cBKeyType.SelectedItem.ToString())
            {
                case "Expression":
                    {
                        Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, true);
                        return cz.Crypt(rTBInput.Text, tBKey.Text.Trim());
                    }
                case "Motto":
                    {
                        try
                        {
                            Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, false);
                            return cz.Crypt(rTBInput.Text, tBKey.Text.Trim());
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        return String.Empty;
                    }
            }
            throw new NotImplementedException();
        }

        private string CryptFile()
        {
            switch (cBKeyType.SelectedItem.ToString())
            {
                case "Expression":
                    {
                        Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, true);
                        return cz.CryptFile(tbPath.Text, tBKey.Text.Trim());
                    }
                case "Motto":
                    {
                        try
                        {
                            Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, false);
                            return cz.CryptFile(tbPath.Text, tBKey.Text.Trim());
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return String.Empty;
                    }
            }
            throw new NotImplementedException();
        }

        private string DecryptText()
        {
            switch (cBKeyType.SelectedItem.ToString())
            {
                case "Expression":
                    {
                        Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, true);
                        return cz.Decrypt(rTBInput.Text, tBKey.Text.Trim());
                    }
                case "Motto":
                    {
                        try
                        {
                            Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, false);
                            return cz.Decrypt(rTBInput.Text, tBKey.Text.Trim());
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return String.Empty;
                    }
            }
            throw new NotImplementedException();
        }

        private string DecryptFile()
        {
            switch (cBKeyType.SelectedItem.ToString())
            {
                case "Expression":
                    {
                        Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, true);
                        return cz.DecryptFile(tbPath.Text, tBKey.Text.Trim());
                    }
                case "Motto":
                    {
                        try
                        {
                            Tritemium cz = new Tritemium((Alphabets)cBAlphabetText.SelectedItem, false);
                            return cz.DecryptFile(tbPath.Text, tBKey.Text.Trim());
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return String.Empty;
                    }
            }
            throw new NotImplementedException();
        }

        private void sfDialog2_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                StreamWriter newFile = File.CreateText(((SaveFileDialog) sender).FileName.Replace('\\', '/'));
                newFile.Write(DecryptFile());
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
                    rTBOutput.Text=CryptText();
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
                    rTBOutput.Text=DecryptText();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Некоректний символ: " + ex.Message);
                }
            }
        }


    }
}
