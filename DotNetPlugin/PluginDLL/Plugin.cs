using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PluginDLL
{
    public class Plugin
    {
        public string GetName()
        {
            return "MessageBox";
        }

        public UserControl GetControl(){
            return new MsgControl();
        }
    }
}
