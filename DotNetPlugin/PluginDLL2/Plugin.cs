using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PluginDLL2
{
    public class Plugin
    {
        public string GetName()
        {
            return "Calculator";
        }

        public UserControl GetControl()
        {
            return new CalControl();
        }
    }
}
