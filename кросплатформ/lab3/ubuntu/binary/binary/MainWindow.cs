using System;
using Gtk;
using MyLibLab3;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void Exit (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}



	protected void BtnClck (object sender, EventArgs e)
	{
		int N=int.Parse(entry2.Text);
		Result res = Binary.Resolve (N);
		label1.Text = "Binary : "+res.binarStr.ToString();
		label2.Text = "Ones : "+res.count.ToString();
	}
}
