using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WbService
{
    [DataContract]
    public class Data
    {
        [DataMember(Order = 1)]
        public string Msg;
        [DataMember(Order = 2)]
        public string Target;
        [DataMember(Order = 3)]
        public string Type;

        public Data(string m, string t, string ty)
        {
            Msg = m;
            Target = t;
            Type = ty;
        }

    }

    [DataContract]
    public class Device
    {  
      
        [DataMember(Order = 1)]
        public bool Power { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public int Channel { get; set; }

        public Device(bool power,string name,int channel)
        {
            Power = power;
            Name = name;
            Channel = channel;
        }
    }

}
