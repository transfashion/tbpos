using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBPOS
{

    // class untuk menampund data json dari server 
    // {"version":"7.1.1", "md5hash":"ee195ed9b0c28ef2b4c1ddea20b109de"}

    public class PosVersion
    {
        public string version { get; set; }
        public string md5hash { get; set; }

    }
}
