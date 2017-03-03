using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyControl
{
    [DesignerAttribute(typeof(MyDesigner))]//смарт теги

    [Description("Компоненнт Label з градієнтним заповненням")]
    [DefaultProperty("StartColor")]

    public partial class MyProgressBar: ProgressBar
    {
        private bool round = false;

        [Category("Gradient"), Description("Початковий колір заповнення")]

        public bool Round
        {
            get
            {               
                return round;
            }
            set
            {
                round = value;
                if (onRoundIs != null) // Якщо подія зареєстрована
                {
                    // Згенерувати подію 
                    onRoundIs(this, new MyEventArgs(round));
                }
                OnChangeProperties();
            }
        }

        private event EventHandler<MyEventArgs> onRoundIs;
        [Category("Gradient"), Description("Викликається при зміні початкового  кольору")]

        public event EventHandler<MyEventArgs> OnRoundIs
        {
            add { onRoundIs += value; }
            remove { onRoundIs -= value; }
        }

        private void OnChangeProperties()
        {
            Invalidate();
            if (round)
            {
                GraphicsPath gr = new GraphicsPath();
                gr.AddEllipse(ClientRectangle);
                this.Region = new Region(gr);
            }
            else
            {
                GraphicsPath gr = new GraphicsPath();
                gr.AddRectangle(ClientRectangle);
                this.Region = new Region(gr);
            }
        }

        protected override void OnPrint(PaintEventArgs pe)
        {
            // Викли базового OnPaint
            base.OnPaint(pe);   
            // Заповнення
            //Color c1 = Color.FromArgb(100, startColor);
            //Color c2 = Color.FromArgb(100, endColor);
            //Brush b = new System.Drawing.Drawing2D.
            //LinearGradientBrush(ClientRectangle, c1, c2, 10);
            //pe.Graphics.FillRectangle(b, ClientRectangle);
            //b.Dispose();
        }

        public MyProgressBar()
        {
            InitializeComponent();
        }
    }
}
