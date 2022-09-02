//#define SUPPORT_CMD_WIN         //控制台打印输出

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// 控制台输出，需加入此库
using System.Runtime.InteropServices;

namespace Mytest1
{
    static class Program
    {
#if SUPPORT_CMD_WIN
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
#endif

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
#if SUPPORT_CMD_WIN
            // 允许调用控制台输出
            AllocConsole();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());                           //调用Form1类的构造函数，创建一个Form对象

            Form1 MyForm = new Form1();
            Application.Run(MyForm);


            Application.Exit();
            System.Environment.Exit(0);                               //这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净
#if SUPPORT_CMD_WIN
            // 释放
            FreeConsole();
#endif
        }
    }
}
