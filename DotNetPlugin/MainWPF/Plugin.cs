using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainWPF
{
    class Plugin
    {
        private String pluginName;
        private String pluginPath;
        private dynamic pluginDynamic;


        public Plugin(String name, String path, dynamic obj)
        {
            this.pluginDynamic = obj;
            this.pluginName = name;
            this.pluginPath = path;
        }

        public String GetName()
        {
            return pluginName;
        }

        public String GetPath()
        {
            return pluginPath;
        }

        public dynamic GetDynamic()
        {
            return pluginDynamic;
        }
    }
}
