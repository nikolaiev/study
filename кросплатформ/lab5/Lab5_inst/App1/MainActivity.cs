/*using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}*/

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ClassLibrary1;

namespace App1
{
    // атрибути визначають, зокрема, що ця активність є головною і завантажується першою
    [Activity(Label = "AndroidApplication1", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        // лічильник кліків
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            MyClass instance = new MyClass();//
            // Встановлюється зміст відповідно до опису розташування з файлу "main" 
            SetContentView(Resource.Layout.Main);

            // З ресурсів вибирається кнопка з вказаним ідентифікатором
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            // З ресурсів вибирається EditText та TextView
            EditText editTextString = FindViewById<EditText>(Resource.Id.editText);

            EditText editTextNumber = FindViewById<EditText>(Resource.Id.editTextNumb);

            var textView = FindViewById<TextView>(Resource.Id.textView);
            // приєднується обробник подій 
            button.Click += delegate {
                /*button.Text = string.Format("{0} clicks!",
                                              instance.Summ(count++));*/
                String str = editTextString.Text;
                Int32 numb = Int32.Parse(editTextNumber.Text);
                textView.Text = instance.GetElem(numb, str);
            };

            /*

            // приєднується обробник подій
            editText.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //--- сховати віртуальну клавіатуру
                    Android.Views.InputMethods.InputMethodManager
                    imm = (Android.Views.InputMethods.InputMethodManager)
                                           GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(editText.WindowToken,
                                   Android.Views.InputMethods.HideSoftInputFlags.None);
                    //-----------------------

                    Toast.MakeText(this, editText.Text, ToastLength.Long).Show();
                    e.Handled = true;
                }
            };
            // приєднується обробник подій
            editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                textView.Text = e.Text.ToString();
            };*/

        }
    }
}


