using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20181107마지막_시험_클라
{
    class AiController
    {
        MainWindow mainwindow;

        public AiController(MainWindow main)
        {
            mainwindow = main;
        }


        void MessageType()
        {
            string str = mainwindow.tb_main.Text;
        }
    }
}
