namespace CaezazLab1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butOpenFile = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chBWTF = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tBOffsetText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDecryptionText = new System.Windows.Forms.Button();
            this.btnEncryptionText = new System.Windows.Forms.Button();
            this.cBAlphabetText = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rTBInput = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rTBOutput = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorPr = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPr)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.butOpenFile);
            this.groupBox1.Controls.Add(this.tbPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // butOpenFile
            // 
            this.butOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpenFile.Location = new System.Drawing.Point(548, 14);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(24, 23);
            this.butOpenFile.TabIndex = 2;
            this.butOpenFile.Text = "...";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(73, 16);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(469, 20);
            this.tbPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to file:";
            // 
            // chBWTF
            // 
            this.chBWTF.AutoSize = true;
            this.chBWTF.Location = new System.Drawing.Point(350, 141);
            this.chBWTF.Name = "chBWTF";
            this.chBWTF.Size = new System.Drawing.Size(79, 17);
            this.chBWTF.TabIndex = 9;
            this.chBWTF.Text = "Write to file";
            this.chBWTF.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chBWTF);
            this.groupBox2.Controls.Add(this.tBOffsetText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnDecryptionText);
            this.groupBox2.Controls.Add(this.btnEncryptionText);
            this.groupBox2.Controls.Add(this.cBAlphabetText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rTBInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // tBOffsetText
            // 
            this.tBOffsetText.Location = new System.Drawing.Point(244, 139);
            this.tBOffsetText.Name = "tBOffsetText";
            this.tBOffsetText.Size = new System.Drawing.Size(100, 20);
            this.tBOffsetText.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Offset:";
            // 
            // btnDecryptionText
            // 
            this.btnDecryptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecryptionText.Location = new System.Drawing.Point(497, 159);
            this.btnDecryptionText.Name = "btnDecryptionText";
            this.btnDecryptionText.Size = new System.Drawing.Size(75, 23);
            this.btnDecryptionText.TabIndex = 7;
            this.btnDecryptionText.Text = "Decryption";
            this.btnDecryptionText.UseVisualStyleBackColor = true;
            this.btnDecryptionText.Click += new System.EventHandler(this.btnDecryptionText_Click);
            // 
            // btnEncryptionText
            // 
            this.btnEncryptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncryptionText.Location = new System.Drawing.Point(416, 159);
            this.btnEncryptionText.Name = "btnEncryptionText";
            this.btnEncryptionText.Size = new System.Drawing.Size(75, 23);
            this.btnEncryptionText.TabIndex = 7;
            this.btnEncryptionText.Text = "Encryption";
            this.btnEncryptionText.UseVisualStyleBackColor = true;
            this.btnEncryptionText.Click += new System.EventHandler(this.btnEncryptionText_Click);
            // 
            // cBAlphabetText
            // 
            this.cBAlphabetText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cBAlphabetText.FormattingEnabled = true;
            this.cBAlphabetText.Location = new System.Drawing.Point(67, 139);
            this.cBAlphabetText.Name = "cBAlphabetText";
            this.cBAlphabetText.Size = new System.Drawing.Size(121, 21);
            this.cBAlphabetText.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alphabet:";
            // 
            // rTBInput
            // 
            this.rTBInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBInput.Location = new System.Drawing.Point(10, 37);
            this.rTBInput.Name = "rTBInput";
            this.rTBInput.Size = new System.Drawing.Size(562, 96);
            this.rTBInput.TabIndex = 1;
            this.rTBInput.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Input text:";
            // 
            // rTBOutput
            // 
            this.rTBOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBOutput.Location = new System.Drawing.Point(22, 269);
            this.rTBOutput.Name = "rTBOutput";
            this.rTBOutput.Size = new System.Drawing.Size(562, 102);
            this.rTBOutput.TabIndex = 5;
            this.rTBOutput.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Output text:";
            // 
            // errorPr
            // 
            this.errorPr.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rTBOutput);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "Caezar Crypto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butOpenFile;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecryptionText;
        private System.Windows.Forms.RichTextBox rTBOutput;
        private System.Windows.Forms.Button btnEncryptionText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBAlphabetText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rTBInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorPr;
        private System.Windows.Forms.CheckBox chBWTF;
        private System.Windows.Forms.TextBox tBOffsetText;
    }
}

