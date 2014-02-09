using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;

namespace MainWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Create *.dll list from plugins directory
            String[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "plugins","*.dll");

            //Create List to hold plugin references
            List<Plugin> plugins = new List<Plugin>();

            listBox1.Items.Add(files.Count() + " dlls found");

            //Iterate through *.dll file list
            foreach(String dll in files){

                //Load Dll file
                Assembly DLL = Assembly.LoadFile(dll);

                //Iterate through all types in dll to find Plugin class
                foreach (Type type in DLL.GetExportedTypes())
                {
                    //check type name for Plugin class
                    if (type.FullName.IndexOf(".Plugin") > 0)
                    {
                        //Create dynamic Instance of Plugin calss from the dll
                        dynamic obj = Activator.CreateInstance(type);

                        //ObjectHandle oh = Activator.CreateComInstanceFrom(dll, "PluginDLL.Plugin");
                        //dynamic obj = oh.Unwrap();

                        //add plugin reference to plugin list for future reference
                        plugins.Add(new Plugin(obj.GetName(), dll, obj));

                        listBox1.Items.Add("Plugin found : " + obj.GetName());

                        //Add User control from plugin to the UI
                        UserControl wnd = obj.GetControl();
                        WrapPanel panel = new WrapPanel();
                        panel.Children.Add(wnd);
                        panel.Width = wnd.Width;
                        panel.Height = wnd.Height;

                        stackPanel1.Height += panel.Height;
                        stackPanel1.Width = (stackPanel1.Width > panel.Width ? stackPanel1.Width : panel.Width);

                        stackPanel1.Children.Add(panel);

                        break;
                    }
                    
                }
            }
        }
    }
}
