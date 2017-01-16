using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoLib;

namespace DESStream
{
    public partial class Form1 : Form
    {
        private String outputData;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.FileOk += openFileDialog_FileOk;
            openFileDialog.ShowDialog(this);
        }

        void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            tBPath.Text = ((OpenFileDialog) sender).FileName;
        }

        private void btnCrypt_Click(object sender, EventArgs e)
        {
            DES2 des2 = new DES2();
            outputData = des2.Crypt(File.ReadAllBytes(tBPath.Text), tBKey.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileOk += saveFileDialog_FileOk;
            saveFileDialog.ShowDialog(this);
        }

        void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            /*
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(data));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(key)), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            var result = reader.ReadToEnd();
            cryptoStream.Close();
            memoryStream.Close();
            reader.Close();
            return result;
             * */
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            DES2 des2 = new DES2();
            outputData = des2.Decrypt(File.ReadAllBytes(tBPath.Text), tBKey.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileOk += saveFileDialog_FileOk;
            saveFileDialog.ShowDialog(this);
        }
    }
}
