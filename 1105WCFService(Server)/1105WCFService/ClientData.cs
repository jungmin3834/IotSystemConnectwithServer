using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbService
{
    class DeviceData
    {
        public DeviceDel UserDevice { get; set; }
        public bool Power { get; set; }

        public string Name { get; set; }

        public int Channel { get; set; }

        public DeviceData(DeviceDel deiv, bool power, string name, int channel)
        {
             UserDevice=deiv;
            Power = power;
            Name = name;
            Channel = channel;
        }
    }


 
    
    
}
