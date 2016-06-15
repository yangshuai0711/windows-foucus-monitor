using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace com.mocoder.tools.focus_monitor
{
    public partial class Form1 : Form
    {
        private string preStr = "";
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();//获取当前激活窗口

        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
        IntPtr hWnd, //窗口句柄
        StringBuilder lpString, //标题
        int nMaxCount  //最大值
        );

        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd, //句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
        );
        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        private static extern int GetWindowThreadProcessId(
            IntPtr hWnd,
            out int pid
        );

        public Form1()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Opacity = 0.5;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr myPtr = GetForegroundWindow();

            // 窗口标题
            StringBuilder title = new StringBuilder(255);
            GetWindowText(myPtr, title, title.Capacity);

            // 窗口类名
            StringBuilder className = new StringBuilder(256);
            GetClassName(myPtr, className, className.Capacity);
            int pid = 0;
            GetWindowThreadProcessId(myPtr, out pid);
            string  str =  DateTime.Now.ToShortTimeString() + " ### 标题:" + title.ToString() +" 进程id:"+pid+ " 句柄:" + myPtr.ToString() + " 类:" + className.ToString();
           
            if (preStr != myPtr.ToString())
            {
               if (richTextBox1.TextLength > richTextBox1.MaxLength)
               {
                   richTextBox1.ResetText();
               }
                richTextBox1.Text +=str+"\n";
                preStr = myPtr.ToString();
           }
           
        }

     

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
