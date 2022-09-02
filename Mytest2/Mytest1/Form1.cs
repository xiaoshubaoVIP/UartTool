//#define USE_GET_COM_FUN_1
#if USE_GET_COM_FUN_1
#define USE_GET_COM_FUN_1_1
#endif

//#define DEMO_FUNCTION

#define SUPPORT_READ_BYTE

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;


using System.IO.Ports;

using System.Threading;

using System.Drawing.Drawing2D;     //picture box
using System.Drawing;

using System.IO;                    //写数据到text文本                               

namespace Mytest1
{

    public partial class Form1 : Form
    {
        #region 变量定义和数据初始化
        //SerialPort SerialPort1 = new System.IO.Ports.SerialPort();                                //与下面语句作用一致
        //private SerialPort MySerialPort = new SerialPort();                                       //创建并声明串口操作对象

        private bool SeriesDarkSelectFlag = true;                                                   //判断数据曲线是否可见选项标志
        private bool SeriesLightSelectFlag = true;
        private bool SeriesL_DSelectFlag = true;
        private bool SeriesCoSelectFlag = true;
        private static int LinesSelectValue = 0x0F;                                                           //判断数据曲线是否可见选项标志


        //private static Queue<int> DarkQueue = new Queue<int>();                                   //动态曲线更新数据存储
        //private static Queue<int> LightQueue = new Queue<int>();
        //private static Queue<int> L_DQueue = new Queue<int>();
        //private static Queue<int> CoQueue = new Queue<int>();                                            

        private long ReceiveTotalCnt = 0;                                                           //接收字节长度
        private StringBuilder sb = new StringBuilder();                                             //定义一个字符串构造类型
        private bool UartBusyFlag = false;
        
        private List<Thread> MyThreadList;                                                          //定义一个线程集合
        private static Thread DataMatchThread = new Thread(new ThreadStart(DataMatch));             //创建线程
        private static ManualResetEvent PausedEvent = new ManualResetEvent(false);
        private static bool FirstClikFlag = true;

        private static string UartDataBuf = null;
        private static string[] LabelUnitName1 = { "Co(mV)", "D(mV)", "L(mV)", "L-D(mV)" };
        private static string[] LabelUnitName2 = { "Co(V)", "D(V)", "L(V)", "L-D(V)" };
        private static string[] LabeHeadName = { "CO:", "MCU_Bat:", "CO_Bat:", "Event:" };
        private static bool VolmVUnitDataFlag = false;
        private static bool BatmVUnitDataFlag = false;

        //private List<TextBox[]> TextBoxList = new List<TextBox[]>();
        private TextBox[] MyCoTextBoxList = new TextBox[5];
        private TextBox[] MyDarkTextBoxList = new TextBox[5];
        private TextBox[] MyLightTextBoxList = new TextBox[5];
        private TextBox[] MyL_DTextBoxList = new TextBox[5];
        private TextBox[] MyTempTextBoxList = new TextBox[5];

        //private List<List<TextBox>> MyTextBoxList = new List<List<TextBox>>();
        //private TextBox[][] MyTextBoxList = new TextBox[5];

        private static int[] defaultValue = { 5, 9999, 0, 0, 0};
        private static myValueObject[] ValueObject = {
            new myValueObject("Co=", defaultValue),                           
            new myValueObject("Dark=", defaultValue),   
            new myValueObject("Light=", defaultValue),   
            new myValueObject("L_D=", defaultValue),   
            new myValueObject("T=", defaultValue),   
        };
        #endregion

        //List数据类型
        private static List<float> DisplayDarkData = new List<float>();
        private static List<float> DisplayLightData = new List<float>();
        private static List<float> DisplayL_DData= new List<float>();
        private static List<float> DisplayCokData = new List<float>();

        private static List<float>[] DisplayData = { DisplayDarkData, DisplayLightData, DisplayL_DData, DisplayCokData };
        public Bitmap mybitmap;//用于双缓冲的位图，和画布等大

        #region 窗口初始化
        public static Form1 mainForm; 
        public Form1()
        {
            InitializeComponent();
            MyThreadList = new List<Thread>();
            //MyThreadList.Add(DataMatchThread);                                                      //将线程DataMatchThread添加到线程集合   
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            mainForm = this;

            InitPicBox();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (string portName in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(portName);
            }
            string[] ComNum = SerialPort.GetPortNames();
            comboBox1.Text = ComNum[0];     // COM1;                                //默认第一个数值值作为串口端口显示
            string[] BaudArray = { "9600", "19200", "115200" };
            comboBox2.Items.AddRange(BaudArray);
            comboBox2.Text = BaudArray[0];  // "9600";                              //默认第一个数值值作为串口端口显示

            System.Timers.Timer timer1 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒； 
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);//到时间的时候执行事件； 
            timer1.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
            timer1.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件； 

            mainForm.MyCoTextBoxList[0] = mainForm.textBox_Last_Co;
            mainForm.MyCoTextBoxList[1] = mainForm.textBox_Min_Co;
            mainForm.MyCoTextBoxList[2] = mainForm.textBox_Max_Co;
            mainForm.MyCoTextBoxList[3] = mainForm.textBox_Average_Co;
            mainForm.MyCoTextBoxList[4] = mainForm.textBox_Total_Co;

            mainForm.MyDarkTextBoxList[0] = mainForm.textBox_Last_Dark;
            mainForm.MyDarkTextBoxList[1] = mainForm.textBox_Min_Dark;
            mainForm.MyDarkTextBoxList[2] = mainForm.textBox_Max_Dark;
            mainForm.MyDarkTextBoxList[3] = mainForm.textBox_Average_Dark;
            mainForm.MyDarkTextBoxList[4] = mainForm.textBox_Total_Dark;

            mainForm.MyLightTextBoxList[0] = mainForm.textBox_Last_Light;
            mainForm.MyLightTextBoxList[1] = mainForm.textBox_Min_Light;
            mainForm.MyLightTextBoxList[2] = mainForm.textBox_Max_Light;
            mainForm.MyLightTextBoxList[3] = mainForm.textBox_Average_Light;
            mainForm.MyLightTextBoxList[4] = mainForm.textBox_Total_Light;

            mainForm.MyL_DTextBoxList[0] = mainForm.textBox_Last_L_D;
            mainForm.MyL_DTextBoxList[1] = mainForm.textBox_Min_L_D;
            mainForm.MyL_DTextBoxList[2] = mainForm.textBox_Max_L_D;
            mainForm.MyL_DTextBoxList[3] = mainForm.textBox_Average_L_D;
            mainForm.MyL_DTextBoxList[4] = mainForm.textBox_Total_L_D;

            mainForm.MyTempTextBoxList[0] = mainForm.textBox_Last_Temp;
            mainForm.MyTempTextBoxList[1] = mainForm.textBox_Min_Temp;
            mainForm.MyTempTextBoxList[2] = mainForm.textBox_Max_Temp;
            mainForm.MyTempTextBoxList[3] = mainForm.textBox_Average_Temp;
            mainForm.MyTempTextBoxList[4] = mainForm.textBox_Total_Temp;

        }
        #endregion

        #region PicBox初始化
        public void InitPicBox()
        {
            //float[] DataArray = new float[16] {888.0f, 232, 1111, 4545, 222, 456, 875, 1368, 900, 1120,  234, 4555, 124, 675, 555, 1280};
            //this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            CurvePaint cp = new CurvePaint();
            cp.XkeduCount = 20;
            cp.YkeduCount = 10;

            //for (int i = 0; i < DataArray.Length; i++)
            //{
            //    DisplayData[0].Add((float)DataArray[i]);
            //}

            this.pictureBox1.Image = cp.drawCurve(0x00, DisplayData, this.pictureBox1.Width, this.pictureBox1.Height);
        }
        #endregion

        #region 串口打开操作button1
        private void button1_Click(object sender, EventArgs e)
        {
            CommonOperateFunc(false);
        }

        private void CommonOperateFunc(bool ComNumChangeFlag)
        {
            try
            {
                if (ComNumChangeFlag)
                {
                    if (serialPort1.IsOpen)
                    {
                        while (UartBusyFlag)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        serialPort1.Close();


                        Console.WriteLine("COM:{0}", comboBox1.Text);

                        serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");  //此行非常重要 可解决接收中文乱码问题
                        serialPort1.PortName = comboBox1.Text;                              //得到当前COM选择口
                        serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);             //得到当前设置的波特率
                        serialPort1.Open();
                        mainForm.button1.Text = "关闭串口";
                        mainForm.pictureBox1_On_Off.Image = mainForm.pictureBox1_On_Off.ErrorImage;
                        if (FirstClikFlag == true)
                        {
                            FirstClikFlag = false;
                            DataMatchThread.Start();
                        }             
                    }
                }
                else
                {
                    if (serialPort1.IsOpen)                                             //open状态
                    {
                        while (UartBusyFlag)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        serialPort1.Close();
                        mainForm.button1.Text = "打开串口";
                        mainForm.pictureBox1_On_Off.Image = mainForm.pictureBox1_On_Off.InitialImage;
                    }
                    else
                    {
                        serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");  //此行非常重要 可解决接收中文乱码问题
                        serialPort1.PortName = comboBox1.Text;                              //得到当前COM选择口
                        serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);             //得到当前设置的波特率
                        serialPort1.Open();
                        mainForm.button1.Text = "关闭串口";
                        mainForm.pictureBox1_On_Off.Image = mainForm.pictureBox1_On_Off.ErrorImage;
                        if (FirstClikFlag == true)
                        {
                            FirstClikFlag = false;
                            DataMatchThread.Start();
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                SerialPort SerialPort1 = new System.IO.Ports.SerialPort();              //与下面语句作用一致
                string[] ComNum = SerialPort.GetPortNames();
                comboBox1.Text = ComNum[0];                                             //默认第一个数值值作为串口端口显示,COM1
                //SerialPort SerialPort1 = new SerialPort();
                if (ComNumChangeFlag)
                {
                    if (serialPort1.IsOpen)                                             //open状态
                    {
                        while (UartBusyFlag)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        serialPort1.Close();
                        mainForm.button1.Text = "打开串口";
                        mainForm.pictureBox1_On_Off.Image = mainForm.pictureBox1_On_Off.InitialImage;
                    }              
                }
                MessageBox.Show(ex.Message);
            } 
        }


        #endregion

        #region 串口接收事件处理
        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            UartBusyFlag = true;
            Thread.Sleep(50);
#if SUPPORT_READ_BYTE
            int DataLength = serialPort1.BytesToRead;                   //接收到buffer的字节数
            byte[] DataBuf = new byte[DataLength];
            ReceiveTotalCnt += DataLength;
            serialPort1.Read(DataBuf, 0, DataLength);
            sb.Clear();                                                 //清空
            String LastValue = Encoding.ASCII.GetString(DataBuf);       //将整个数组解码为ASCII数组
            sb.Append(LastValue);                                       //遍历数组进行字符串转化及拼接
#else
            //int DataLength = serialPort1.BytesToRead;                   //接收到buffer的字节数
            //char[] DataBuf = new char[DataLength];

            //ReceiveTotalCnt += DataLength;

            //serialPort1.Read(DataBuf, 0, DataLength);
            
            //string LastValue = new string(DataBuf);

            string LastValue = serialPort1.ReadLine();
            //string LastValue = serialPort1.ReadExisting();
#endif

            PausedEvent.Reset();
            try
            {
                //因为要访问UI资源，所以需要使用invoke方式同步ui  
                //在创建this对象的线程上调用匿名委托.
                //匿名委托的代码就是你看见的那个：
                //delegate {
                //xxx b
                //}
                //这是匿名委托的一种写法,算是C#的语法
                //Invoke((EventHandler)(delegate { this.richTextBox1.AppendText(sb.ToString()); }));  //invoke函数括号中的参数类型必须是委托
                //this.richTextBox1.Focus();                                                          //获取焦点
                //this.richTextBox1.Select(this.richTextBox1.TextLength, 0);                          //光标定位到文本最后
                //this.richTextBox1.ScrollToCaret();                                                  //滚动到光标处

                SetRichTextBox(sb.ToString());

            }
            catch (Exception ex)
            {
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message);
            }

            UartDataBuf += LastValue;
            //for (int i = 0; i < 5; i++ )
            //{
            //    ValueObject[i].DataSourceValue += LastValue;
            //    if (ValueObject[i].DataSourceValue.Length > 1024)
            //    {
            //        ValueObject[i].DataSourceValue = ValueObject[i].DataSourceValue.Remove(0, 1000);
            //    }
            //}
            PausedEvent.Set();
            UartBusyFlag = false;
            //Console.WriteLine("{0}", TempValue);
        }

        private delegate void SetTextCallback(string text);
        private void SetRichTextBox(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (mainForm.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRichTextBox);
                mainForm.Invoke(d, new object[] { text });
            }
            else
            {
                mainForm.richTextBox1.AppendText(text);
                mainForm.richTextBox1.Focus();                                                          //获取焦点
                mainForm.richTextBox1.Select(this.richTextBox1.TextLength, 0);                          //光标定位到文本最后
                mainForm.richTextBox1.ScrollToCaret();                                                  //滚动到光标处
            }
        }

        #endregion

        #region 保存串口信息button 2
        private void button2_Click(object sender, EventArgs e)
        {
            string PathStrValue = System.Windows.Forms.Application.StartupPath;
            Console.WriteLine("Path:{0}", PathStrValue);

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string DataStrValue = currentTime.Year.ToString() + "-" + currentTime.Month.ToString() + "-" + currentTime.Day.ToString() + "-";
            DataStrValue += currentTime.Hour.ToString() + "-" + currentTime.Minute.ToString() + "-" + currentTime.Second.ToString();
            Console.WriteLine("Time:{0}", DataStrValue);

            PathStrValue = PathStrValue+"\\"+DataStrValue+".txt";

            Console.WriteLine("Last:{0}", PathStrValue);

            StreamWriter SW = File.CreateText(PathStrValue);

            SW.Write(richTextBox1.Text);
            SW.Flush();
            SW.Close();

        }
        #endregion

        #region 清除串口信息button 3
        private void button3_Click(object sender, EventArgs e)
        {
            string ZeroStrChar = "0";
            string NullStrChar = "null";
            richTextBox1.Text = "";         //清空接收文本框
            for(int i = 0; i<5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    ValueObject[i].DataValue[j] = defaultValue[j];
                }
            }

            for (int i = 0; i < 5; i++)
            {
                mainForm.MyCoTextBoxList[i].Text = ZeroStrChar;
            }

            for (int i = 0; i < 5; i++)
            {
                mainForm.MyDarkTextBoxList[i].Text = ZeroStrChar;
            }


            for (int i = 0; i < 5; i++)
            {
                mainForm.MyLightTextBoxList[i].Text = ZeroStrChar;
            }

            for (int i = 0; i < 5; i++)
            {
                mainForm.MyL_DTextBoxList[i].Text = ZeroStrChar;
            }

            for (int i = 0; i < 5; i++)
            {
                mainForm.MyTempTextBoxList[i].Text = ZeroStrChar;
            }
            mainForm.textBox_CO_PPM.Text = ZeroStrChar;
            mainForm.textBox_MCU_BAT.Text = ZeroStrChar;
            mainForm.textBox_CO_BAT.Text = ZeroStrChar;
            mainForm.textBox_Event.Text = NullStrChar;

            for (int i = 0; i < 4; i++)
            {
                DisplayData[i].Clear();
            }
            InitPicBox();
        }
        #endregion

        #region 数据处理和显示
        private static void DataMatch()
        {
            int IndexValue1 = 0;
            int IndexValue2 = 0;
            int IndexValue3 = 0;
            int IndexTemp = 0;
            int DataLength = 0;
            int BufLength = 0;
            bool EventPauseFlag = true;
            
            string str = null;
            string strGetName = null;
            Console.WriteLine("Data process in 1");
            PausedEvent.WaitOne();
            Console.WriteLine("Data process in 2");
            while (true)
            {
                #region 电压数据获取
                for (int i = 0; i < 5; i++)
                {
                    EventPauseFlag = true;
                    str = null;
                    IndexTemp = 0;
                    strGetName = ValueObject[i].GetName();
                    IndexValue1 = UartDataBuf.IndexOf(strGetName);
                    BufLength = UartDataBuf.Length;
                    if (IndexValue1 != -1)
                    {
                        EventPauseFlag = false;
                        switch (i)
                        {
                            case 0:
                                IndexValue2 = IndexValue1 + 3;
                                break;

                            case 1:
                                IndexValue2 = IndexValue1 + 5;
                                break;

                            case 2:
                                IndexValue2 = IndexValue1 + 6;
                                break;

                            case 3:
                                IndexValue2 = IndexValue1 + 4;
                                break;

                            case 4:
                                IndexValue2 = IndexValue1 + 2;
                                break;

                            default:
                                break;
                        };

                        if (i == 4)                                                                 //Tempture
                        {
                            //Console.WriteLine("{0}", UartDataBuf.Length);
                            DataLength = BufLength - IndexValue2;

                            if (DataLength >= 5)
                            {
                                DataLength = 5;
                            }
                            for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)
                            {
                                if (UartDataBuf.IndexOf("^C", IndexValue2, IndexValue3) != -1)       //^C结尾的字符
                                {
                                    break;
                                }
                            }
                            if (IndexValue3 < DataLength)
                            {
                                str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 2);
                                if (str != null)
                                {
                                    IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                    //Console.WriteLine("{0},{1},{2},{3}", i, str, IndexValue1, IndexTemp);
                                    //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);      //替换掉已经取走的数据
                                }
                            }
                        }
                        else                                                                        //Voltage
                        {
                            DataLength = BufLength - IndexValue2;
                            if (DataLength >= 7)
                            {
                                DataLength = 7;
                            }
                            for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)          //mV单位数据
                            {
                                //Console.WriteLine("v={0}:{1},{2}",i, IndexValue2,IndexValue3);
                                if (UartDataBuf.IndexOf("mV", IndexValue2, IndexValue3) != -1)
                                {
                                    VolmVUnitDataFlag = true;
                                    break;
                                }
                            }

                            if (IndexValue3 < DataLength)
                            {
                                str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 2);
                                if (str != null)
                                {
                                    IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                    //Console.WriteLine("{0},{1},{2},{3}",i, str, IndexValue1, IndexTemp);
                                    //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);           //替换掉已经取走的数据
                                }
                            }
                            else
                            {
                                for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)          //V为单位
                                {
                                    if (UartDataBuf.IndexOf('V', IndexValue2, IndexValue3) != -1)
                                    {
                                        VolmVUnitDataFlag = false;
                                        break;
                                    }
                                }

                                if (IndexValue3 < DataLength)
                                {
                                    str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 1);
                                    if (str != null)
                                    {
                                        IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                        //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);      //替换掉已经取走的数据
                                    }
                                }
                            }

                            if (str != null)
                            {
                                SetLabelTextFunc(i);
                            }
                        }

                        //Console.WriteLine("1:{0},{1},{2},{3}", i, str, IndexValue1, IndexTemp);

                        if (IndexTemp == 0)
                        {
                            UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexValue2 - IndexValue1);   //替换掉已经取走的数据
                        }
                        else
                        {
                            UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);                  //替换掉已经取走的数据                         
                        }

                        if (str != null)
                        {
                            //Console.WriteLine("Vol:{0},{1}", i,str);
                            LastDataUpdateFunc(i, str);                                                 //最新数据更新显示                                            
                            DataCalculate(i, str);                                                      //数据处理方法，同时更新显示
                        }
                    }
                }
                #endregion

                #region 电池、事件获取
                EventPauseFlag = true;
                for (int i = 0; i < 4; i++)                                                         //获取PPM、电压、事件
                {
                    str = null;
                    IndexTemp = 0;
                    strGetName = LabeHeadName[i];
                    IndexValue1 = UartDataBuf.IndexOf(strGetName);
                    BufLength = UartDataBuf.Length;
                    if (IndexValue1 != -1)
                    {
                        EventPauseFlag = false;
                        switch (i)
                        {
                            case 0:
                                IndexValue2 = IndexValue1 + 3;                                      //CO:xxxppm
                                break;

                            case 1:
                                IndexValue2 = IndexValue1 + 8;                                      //MCU_Bat:xxx
                                break;

                            case 2:
                                IndexValue2 = IndexValue1 + 7;                                      //CO_Bat:
                                break;

                            case 3:
                                IndexValue2 = IndexValue1 + 6;                                      //Event:
                                break;

                            default:
                                break;
                        };

                        if (i == 0)
                        {
                            DataLength = BufLength - IndexValue2;

                            if (DataLength >= 8)
                            {
                                DataLength = 8;
                            }
                            for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)
                            {
                                if (UartDataBuf.IndexOf("ppm", IndexValue2, IndexValue3) != -1)
                                {
                                    break;
                                }
                            }
                            if (IndexValue3 != DataLength)
                            {
                                str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 3);
                                if (str != null)
                                {
                                    IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                     //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);      //替换掉已经取走的数据
                                }
                            }
                        }
                        else if (i == 3)
                        {
                            DataLength = BufLength - IndexValue2;

                            if (DataLength >= 10)
                            {
                                DataLength = 10;
                            }
                            else
                            {
                                DataLength = DataLength + 1;
                            }

                            for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)
                            {
                                if ((UartDataBuf.IndexOf('\0', IndexValue2, IndexValue3) != -1) || (UartDataBuf.IndexOf('\n', IndexValue2, IndexValue3) != -1) ||(UartDataBuf.IndexOf(',', IndexValue2, IndexValue3) != -1))
                                {
                                    break;
                                }
                            }
                            if (IndexValue3 < DataLength)
                            {
                                str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 1);
                                if (str != null)
                                {
                                    IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                     //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);           //替换掉已经取走的数据
                                }
                            }
                        }
                        else 
                        {
                            DataLength = BufLength - IndexValue2;
                            if (DataLength >= 7)
                            {
                                DataLength = 7;
                            }

                            Console.WriteLine("x:{0},{1},{2},{3}", IndexValue2, str, BufLength, UartDataBuf.Length);

                            for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)              //mV单位数据
                            {
                                if (UartDataBuf.IndexOf("mV", IndexValue2, IndexValue3) != -1)
                                {
                                    BatmVUnitDataFlag = true;
                                    break;
                                }
                            }

                            if (IndexValue3 < DataLength)
                            {
                                str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 2);         
                                if (str != null)
                                {
                                    IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                     //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);           //替换掉已经取走的数据
                                }
                            }
                            else
                            {
                                for (IndexValue3 = 1; IndexValue3 < DataLength; IndexValue3++)         //V为单位
                                {
                                    if (UartDataBuf.IndexOf('V', IndexValue2, IndexValue3) != -1)
                                    {
                                        BatmVUnitDataFlag = false;
                                        break;
                                    }
                                }

                                if (IndexValue3 < DataLength)
                                {
                                    str = UartDataBuf.Substring(IndexValue2, IndexValue3 - 1);
                                    if (str != null)
                                    {
                                        IndexTemp = IndexValue2 - IndexValue1 + IndexValue3;
                                         //UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);      //替换掉已经取走的数据
                                    }
                                }
                            }
                        }

                        //Console.WriteLine("2:{0},{1},{2}", i, str, IndexTemp);

                        if (IndexTemp == 0)
                        {
                            UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexValue2 - IndexValue1);   //替换掉已经取走的数据
                        }
                        else
                        {
                            UartDataBuf = UartDataBuf.Remove(IndexValue1, IndexTemp);                   //替换掉已经取走的数据                         
                        }

                        if (str != null)
                        {
                            SetLabelEventTextFunc(i, str);
                        }

                    }
                }
                #endregion

                if (UartDataBuf.Length > 1024)
                {
                    UartDataBuf = UartDataBuf.Remove(0, 768);                                           //替换掉已经取走的数据
                }

                if (EventPauseFlag == true)
                {
                    PausedEvent.WaitOne();
                    Thread.Sleep(1);
                }
            }
        }

        private delegate void SetLabelEventText(int IndexValue,string ShowStr);
        private static void SetLabelEventTextFunc(int Index, string ShowStr)
        {
            switch (Index)
            {
                case 0:
                    if (mainForm.label_Co_Vol.InvokeRequired)
                    {
                        SetLabelEventText d = new SetLabelEventText(SetLabelEventTextFunc);
                        mainForm.Invoke(d, new object[] { Index, ShowStr});
                    }
                    else
                    {
                        mainForm.textBox_CO_PPM.Text = ShowStr;
                    }
                    break;

                case 1:
                    if (mainForm.label_Dark_Vol.InvokeRequired)
                    {
                        SetLabelEventText d = new SetLabelEventText(SetLabelEventTextFunc);
                        mainForm.Invoke(d, new object[] { Index, ShowStr });
                    }
                    else
                    {
                        mainForm.textBox_MCU_BAT.Text = ShowStr;
                        if (BatmVUnitDataFlag)
                        {
                            mainForm.label_Mcu_Bat.Text = "MCU_Bat(mV)";
                        }
                        else
                        {
                            mainForm.label_Mcu_Bat.Text = "MCU_Bat(V)";
                        }
                    }
                    break;

                case 2:
                    if (mainForm.label_Light_Vol.InvokeRequired)
                    {
                        SetLabelEventText d = new SetLabelEventText(SetLabelEventTextFunc);
                        mainForm.Invoke(d, new object[] { Index, ShowStr });
                    }
                    else
                    {
                        mainForm.textBox_CO_BAT.Text = ShowStr;
                        if (BatmVUnitDataFlag)
                        { 
                            mainForm.label_Co_Bat.Text = "CO_Bat(mV)";
                        }
                        else
                        {
                            mainForm.label_Co_Bat.Text = "CO_Bat(V)";
                        }
                    }
                    break;

                case 3:
                    if (mainForm.label_L_D_Vol.InvokeRequired)
                    {
                        SetLabelEventText d = new SetLabelEventText(SetLabelEventTextFunc);
                        mainForm.Invoke(d, new object[] { Index, ShowStr });
                    }
                    else
                    {
                        mainForm.textBox_Event.Text = ShowStr;
                    }
                    break;

                default:
                    break;
            };
        }

        private delegate void SetLabelText(int IndexValue);
        private static void SetLabelTextFunc(int Index)
        {
            switch (Index)
            {
                case 0:
                    //label_Co_Vol.Text = LabelUnitName[0];
                    if (mainForm.label_Co_Vol.InvokeRequired)
                    {
                        SetLabelText d = new SetLabelText(SetLabelTextFunc);
                        mainForm.Invoke(d, new object[] { Index });
                    }
                    else
                    {
                        if (VolmVUnitDataFlag)
                        {
                            mainForm.label_Co_Vol.Text = LabelUnitName1[0];
                        }
                        else
                        {
                            mainForm.label_Co_Vol.Text = LabelUnitName2[0];
                        }
                    }
                    break;

                case 1:
                    //label_Dark_Vol.Text = LabelUnitName[1];
                    if (mainForm.label_Dark_Vol.InvokeRequired)
                    {
                        SetLabelText d = new SetLabelText(SetLabelTextFunc);
                        mainForm.Invoke(d, new object[] { Index });
                    }
                    else
                    {
                        if (VolmVUnitDataFlag)
                        {
                            mainForm.label_Dark_Vol.Text = LabelUnitName1[1];
                        }
                        else
                        {
                            mainForm.label_Dark_Vol.Text = LabelUnitName2[1];
                        }
                    }
                    break;

                case 2:
                    //label_Light_Vol.Text = LabelUnitName[2];
                    if (mainForm.label_Light_Vol.InvokeRequired)
                    {
                        SetLabelText d = new SetLabelText(SetLabelTextFunc);
                        mainForm.Invoke(d, new object[] { Index });
                    }
                    else
                    {
                        if (VolmVUnitDataFlag)
                        {
                            mainForm.label_Light_Vol.Text = LabelUnitName1[2];
                        }
                        else
                        {
                            mainForm.label_Light_Vol.Text = LabelUnitName2[2];
                        }
                    }
                    break;

                case 3:
                    //label_L_D_Vol.Text = LabelUnitName[3];
                    if (mainForm.label_L_D_Vol.InvokeRequired)
                    {
                        SetLabelText d = new SetLabelText(SetLabelTextFunc);
                        mainForm.Invoke(d, new object[] { Index });
                    }
                    else
                    {
                        if (VolmVUnitDataFlag)
                        {
                            mainForm.label_L_D_Vol.Text = LabelUnitName1[3];
                        }
                        else
                        {
                            mainForm.label_L_D_Vol.Text = LabelUnitName2[3];
                        }
                    }
                    break;

                default:
                    break;
            };       
        }

        private delegate void LastDataUpdate(int IndexValue, string StrValue);
        private static void LastDataUpdateFunc(int TextBoxIndex, string DisplayStr)                 //最新数据更新显示
        {
            switch (TextBoxIndex)
            {
                case 0:
                    //textBox_Last_Co.Text = DisplayStr;
                    if (mainForm.textBox_Last_Co.InvokeRequired)
                    {
                        LastDataUpdate d = new LastDataUpdate(LastDataUpdateFunc);
                        mainForm.Invoke(d, new object[] {TextBoxIndex, DisplayStr });
                    }
                    else
                    {
                        mainForm.textBox_Last_Co.Text = DisplayStr;
                    }
                    break;

                case 1:
                    //textBox_Last_Dark.Text = DisplayStr;
                    if (mainForm.textBox_Last_Dark.InvokeRequired)
                    {
                        LastDataUpdate d = new LastDataUpdate(LastDataUpdateFunc);
                        mainForm.Invoke(d, new object[] { TextBoxIndex, DisplayStr });
                    }
                    else
                    {
                        mainForm.textBox_Last_Dark.Text = DisplayStr;
                    }
                    break;

                case 2:
                    //textBox_Last_Light.Text = DisplayStr;
                    if (mainForm.textBox_Last_Light.InvokeRequired)
                    {
                        LastDataUpdate d = new LastDataUpdate(LastDataUpdateFunc);
                        mainForm.Invoke(d, new object[] { TextBoxIndex, DisplayStr });
                    }
                    else
                    {
                        mainForm.textBox_Last_Light.Text = DisplayStr;
                    }
                    break;

                case 3:
                    //textBox_Last_L_D.Text = DisplayStr;
                    if (mainForm.textBox_Last_L_D.InvokeRequired)
                    {
                        LastDataUpdate d = new LastDataUpdate(LastDataUpdateFunc);
                        mainForm.Invoke(d, new object[] { TextBoxIndex, DisplayStr });
                    }
                    else
                    {
                        mainForm.textBox_Last_L_D.Text = DisplayStr;
                    }
                    break;

                case 4:
                    //textBox_Last_Temp.Text = DisplayStr;
                    if (mainForm.textBox_Last_Temp.InvokeRequired)
                    {
                        LastDataUpdate d = new LastDataUpdate(LastDataUpdateFunc);
                        mainForm.Invoke(d, new object[] { TextBoxIndex, DisplayStr });
                    }
                    else
                    {
                        mainForm.textBox_Last_Temp.Text = DisplayStr;
                    }
                    break;

                default:
                    break;
            };
        }

        private static void DataCalculate(int Index, string MatchedStr)                         //数据处理方法，同时更新显示
        {
            //int TextBoxHorizontalIndex = 0;
            int TextBoxVerticalIndex = 0;
            int FloatFlag = 0;

            if (MatchedStr.IndexOf(".") != -1)
            {
                FloatFlag = 1;
            }

            Console.WriteLine("1:{0}", MatchedStr);

            string NumStr = MatchedStr.Replace(".", string.Empty);
            int DataValue = int.Parse(NumStr);

            if (FloatFlag == 1)                                                                 //浮点字串
            {
                if ((MatchedStr.IndexOf("0.00") != -1) || (MatchedStr.IndexOf("0.0") != -1))
                {

                }
                //else if ((MatchedStr.IndexOf("0.0") != -1) && (DataValue < 10))
                //{
                //    DataValue = DataValue * 10;
                //}
                else if ((MatchedStr.IndexOf("0.") != -1))
                {
                    if (DataValue < 10)
                    {
                        DataValue = DataValue * 100;
                    }
                    else if (DataValue < 100)
                    {
                        DataValue = DataValue * 10;
                    }
                }
                else if ((Index != 4) && (DataValue < 10))
                {
                    DataValue = DataValue * 1000;
                }
                else if ((Index != 4) && (DataValue < 100))
                {
                    DataValue = DataValue * 100;
                }
                else if ((Index != 4) && (DataValue < 1000))
                {
                    DataValue = DataValue * 10;
                }
            }
            else if ((Index != 4) && (VolmVUnitDataFlag == false))
            {
                DataValue = DataValue * 1000;
            }


            Console.WriteLine("Num:{0}, {1}", DataValue, ValueObject[Index].DataValue[1]);    //控制台打印当前值和最小值

            TextBoxVerticalIndex = 1;                                                           //Min
            ValueObject[Index].DataValue[0] = DataValue;
            if (ValueObject[Index].DataValue[1] > ValueObject[Index].DataValue[0])             
            {
                ValueObject[Index].DataValue[1] = ValueObject[Index].DataValue[0];
            }
            if (FloatFlag == 1)
            {
                if (ValueObject[Index].DataValue[1] > 999)
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[1].ToString().Insert(1, "."));
                }
                else
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[1].ToString().Insert(0, "0."));
                }
            }
            else 
            {
                DataUpdate(Index, TextBoxVerticalIndex, MatchedStr);
            }


            TextBoxVerticalIndex = 2;                                                           //Max
            if (ValueObject[Index].DataValue[2] < ValueObject[Index].DataValue[0])             
            {
                ValueObject[Index].DataValue[2] = ValueObject[Index].DataValue[0];
            }
            if (FloatFlag == 1)
            {
                if (ValueObject[Index].DataValue[2] > 999)
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[2].ToString().Insert(1, "."));
                }
                else
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[2].ToString().Insert(0, "0."));
                }
            }
            else
            {
                DataUpdate(Index, TextBoxVerticalIndex, MatchedStr);
            }


            ValueObject[Index].DataValue[4]++;                                                  //Total
            TextBoxVerticalIndex = 4;
            if (ValueObject[Index].DataValue[4] > 9999)
            {
                ValueObject[Index].DataValue[4] = 9999;
            }
            Console.WriteLine("cnt:{0}", ValueObject[Index].DataValue[4]);                      //控制台打印当前值和最小值
            DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[4].ToString());



            TextBoxVerticalIndex = 3;
            ValueObject[Index].DataValue[3] += DataValue;                                       //Average
            if (ValueObject[Index].DataValue[3] > 1)
            {
                ValueObject[Index].DataValue[3] = ValueObject[Index].DataValue[3] >> 1;
            }
            if (FloatFlag == 1)
            {
                if (ValueObject[Index].DataValue[3] > 999)
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[3].ToString().Insert(1, "."));
                }
                else
                {
                    DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[3].ToString().Insert(0, "0."));
                }
            }
            else
            {
                DataUpdate(Index, TextBoxVerticalIndex, ValueObject[Index].DataValue[3].ToString());
            }

            //DynamicDrawLineFunc(Index, DataValue);                                                                          //绘制dynamic line
            if (Index<4)
            {
                DisplayData[Index].Add((float)DataValue);
                PictureBox1PaintFunc();
            }

        }

        private static void DataUpdate(int HorizontalIndex, int VerticalIndex, string DisplayStr)
        {
            switch (HorizontalIndex)
            {
                case 0:
                    {
                        mainForm.MyCoTextBoxList[VerticalIndex].Text = DisplayStr == null ? "" : DisplayStr;
                    }
                    break;

                case 1:
                    {
                        mainForm.MyDarkTextBoxList[VerticalIndex].Text = DisplayStr == null ? "" : DisplayStr;
                    }
                    break;

                case 2:
                    {
                        mainForm.MyLightTextBoxList[VerticalIndex].Text = DisplayStr == null ? "" : DisplayStr;
                    }
                    break;

                case 3:
                    {
                        mainForm.MyL_DTextBoxList[VerticalIndex].Text = DisplayStr == null ? "" : DisplayStr;
                    }
                    break;

                case 4:
                    {
                        mainForm.MyTempTextBoxList[VerticalIndex].Text = DisplayStr == null ? "" : DisplayStr;
                    }
                    break;

                default:
                    break;
            }
        }   
        #endregion

        #region 画布绘制曲线方法
        private delegate void PictureBox1Paint();
        private static void PictureBox1PaintFunc()
        {
            int X_Size = 0, Y_Size = 0;
            if (mainForm.pictureBox1.InvokeRequired)
            {
                PictureBox1Paint d = new PictureBox1Paint(PictureBox1PaintFunc);
                mainForm.Invoke(d, new object[] {});
            }
            else
            {
                //mainForm.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                mainForm.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                CurvePaint cp = new CurvePaint();
                cp.XkeduCount = 20;
                cp.YkeduCount = 10;
                X_Size = mainForm.pictureBox1.Width;
                Y_Size = mainForm.pictureBox1.Height;

                if ((X_Size > 100) && (Y_Size > 100))
                {
                    mainForm.pictureBox1.Image = cp.drawCurve(LinesSelectValue, DisplayData, mainForm.pictureBox1.Width, mainForm.pictureBox1.Height);
                }
            }
        }
        #endregion

        #region  随机动态曲线绘制方法
        //Queue<int> Q1 = new Queue<int>();
        //Random r = new Random();

        //int sum = 0;
        //private delegate void ChartSeriesDraw();
        //public void Draw()
        //{
        //    Series series = chart1.Series[0];
        //    ChartArea chartArea = chart1.ChartAreas[0];
        //    int temp;

        //    chartArea.AxisX.ScaleView.Size = 50D;
        //    temp = r.Next(0, 5);
        //    Q1.Enqueue(temp);
        //    series.Points.AddXY(sum, temp);
        //    sum++;
        //    chartArea.AxisX.ScaleView.Position = 1;
        //    if (sum > 10)
        //    {
        //        double max = chartArea.AxisX.Maximum;
        //        max = (sum / 10 + 1) * 10;
        //        chartArea.AxisX.Interval = max / 10;
        //    }
        //    chartArea.AxisX.ScaleView.Size = sum * 1.1;
        //}
        #endregion

        #region 串口端口号实时获取
        private delegate void SerialPortGet();
        public void SerialPortGetFunc()
        {
            mainForm.serialPort1.PortName = mainForm.comboBox1.Text;   //得到当前COM选择口
            mainForm.comboBox1.Items.Clear();
            foreach (string portName in SerialPort.GetPortNames())
            {
                mainForm.comboBox1.Items.Add(portName);
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mainForm.serialPort1.IsOpen)
            {

            }
            else
            {
                if (mainForm.comboBox1.InvokeRequired)
                {
                    SerialPortGet d = new SerialPortGet(SerialPortGetFunc);
                    mainForm.Invoke(d, new object[] { });
                }
                else
                {
                    SerialPortGetFunc();
                }
            }
        }
        #endregion

        #region Timer事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (mainForm.chart1.InvokeRequired)
            //{
            //    ChartSeriesDraw d = new ChartSeriesDraw(Draw);
            //    mainForm.Invoke(d, new object[] { });
            //}
            //else
            //{
            //    Draw();
            //}
            //if (mainForm.chart1.InvokeRequired)
            //{
        }
        #endregion

        #region  选择动态图框事件
        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        #region 选择曲线 RadioButton 
        private void Dark_Series_Button_Click(object sender, EventArgs e)
        {
            if (SeriesDarkSelectFlag == true)
            {
                Dark_Series_Button.Checked = false;
                SeriesDarkSelectFlag = false;
                LinesSelectValue &= ~0x02;
            }
            else
            {
                Dark_Series_Button.Checked = true;
                SeriesDarkSelectFlag = true;
                LinesSelectValue |= 0x02;
            }
            PictureBox1PaintFunc();
        }

        private void Light_Series_Button_Click(object sender, EventArgs e)
        {
            if (SeriesLightSelectFlag == true)
            {
                Light_Series_Button.Checked = false;
                SeriesLightSelectFlag = false;
                LinesSelectValue &= ~0x04;
            }
            else
            {
                Light_Series_Button.Checked = true;
                SeriesLightSelectFlag = true;
                LinesSelectValue |= 0x04;
            }
            PictureBox1PaintFunc();
        }

        private void L_D_Series_Button_Click(object sender, EventArgs e)
        {
            if (SeriesL_DSelectFlag == true)
            {
                L_D_Series_Button.Checked = false;
                SeriesL_DSelectFlag = false;
                LinesSelectValue &= ~0x08;
            }
            else
            {
                L_D_Series_Button.Checked = true;
                SeriesL_DSelectFlag = true;
                LinesSelectValue |= 0x08;
            }
            PictureBox1PaintFunc();
        }

        private void Co_Series_Button_Click(object sender, EventArgs e)
        {
            if (SeriesCoSelectFlag == true)
            {
                Co_Series_Button.Checked = false;
                SeriesCoSelectFlag = false;
                LinesSelectValue &= ~0x01;
            }
            else
            {
                Co_Series_Button.Checked = true;
                SeriesCoSelectFlag = true;
                LinesSelectValue |= 0x01;
            }
            PictureBox1PaintFunc();
        }
        #endregion

        #region 窗体的关闭事件处理函数，在该事件中将之前创建的线程全部终止
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)                                                 //open状态
            {
                while (UartBusyFlag)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                serialPort1.Close();
            }

            DataMatchThread.Abort();

            if (MyThreadList.Count > 0)
            {
                //编列自定义队列,将所有线程终止
                foreach (Thread tWorkingThread in MyThreadList)
                {
                    tWorkingThread.Abort();
                }
            }
        }
        #endregion

        #region 画布鼠标滚动事
        private void chart1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)//鼠标向上
            {

            }
            else//鼠标向下滚动
            {

            }
        }

        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(chart1_MouseEnter);         //调用滚轮事件
        }
        #endregion

        #region 显示帮助信息 button 4
        private void button4_Click(object sender, EventArgs e)
        {
            //DialogResult MsgBoxResult;//设置对话框的返回值
            //MsgBoxResult = MessageBox.Show("请选择你要按下的按钮",//对话框的显示内容
            //"提示",//对话框的标题
            //MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮
            //MessageBoxIcon.Exclamation,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号
            //MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            //if (MsgBoxResult == DialogResult.Yes)//如果对话框的返回值是YES（按"Y"按钮）
            //{
            //    this.label1.ForeColor = System.Drawing.Color.Red;//字体颜色设定
            //    label1.Text = " 你选择了按下”Yes“的按钮！";
            //}
            //if (MsgBoxResult == DialogResult.No)//如果对话框的返回值是NO（按"N"按钮）
            //{
            //    this.label1.ForeColor = System.Drawing.Color.Blue;//字体颜色设定
            //    label1.Text = " 你选择了按下”No“的按钮！";
            //}
            DialogResult MsgBoxResult;//设置对话框的返回值
            MsgBoxResult = MessageBox.Show(this, "采样电压，最大5V，精度1mV\nCO:      [Co=xmV] 或 [Co=x.xV]\nDark:   [Dark=xmV] 或 [Dark=x.xV]\nLight:  [Light=xmV] 或 [Light=x.xV]\nL_D:     [L_D=xmV] 或   [L_D=x.xV]\nT:         [T=xx^C] \n电池和事件\nppm:    [CO:xxxppm]\nMCU_Bat:  [MCU_Bat:xmV] 或 [MCU_Bat:x.xV]\nCO_Bat:     [CO_Bat:xmV] 或 [CO_Bat:x.xV]\nEvent:     [Event:xxxx\\n]",//对话框的显示内容
            "帮助(输出格式)",//对话框的标题
            MessageBoxButtons.OK,//定义对话框的按钮，这里定义了YSE和NO两个按钮
            MessageBoxIcon.Information,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号
            MessageBoxDefaultButton.Button1);//定义对话框的按钮式样
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            PictureBox1PaintFunc();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CommonOperateFunc(true);
            Console.WriteLine("com is changed 3:{0}", comboBox1.Text);
        }
    }


    #region 曲线绘制class
    public class CurvePaint
    {

        public CurvePaint() { }
        //刻度线条数
        private int _X_KeduCount = 15;
        private int _Y_KeduCount = 5;

        //刻度值位置对应刻度线左移像素
        private float _X_KeduInCrementValue = 1f;
        private float _Y_KeduInCrementValue = 1f;

        //格式化刻度值
        private string _X_Format = "#0";
        private string _Y_Format = "#0.0";

        //X轴刻度值文字方向
        private bool _X_DirectionVertical = false;
        private bool _Y_DirectionVertical = false;
        public int XkeduCount
        {
            get { return _X_KeduCount; }
            set { _X_KeduCount = value; }
        }

        public float X_KeduIncrement                              //quanwu.xu 
        {
            get { return _X_KeduInCrementValue; }
            set { _X_KeduInCrementValue = value; }
        }

        public int YkeduCount
        {
            get { return _Y_KeduCount; }
            set { _Y_KeduCount = value; }
        }

        public float Y_KeduIncrement                              //quanwu.xu 
        {
            get { return _Y_KeduInCrementValue; }
            set { _Y_KeduInCrementValue = value; }
        }


        public bool XdirectionVertical
        {
            get { return _X_DirectionVertical; }
            set { _X_DirectionVertical = value; }
        }

        public bool YdirectionVertical
        {
            get { return _Y_DirectionVertical; }
            set { _Y_DirectionVertical = value; }
        }

        public string Xformat
        {
            get { return _X_Format; }
            set { _X_Format = value; }
        }

        public string Yformat
        {
            get { return _Y_Format; }
            set { _Y_Format = value; }
        }

        // Y轴数据规格化
        private float Standard(float Value, float k, float b)
        {
            //return C * (A * x + B) + D;
            return b - Value / k;
        }

        public Bitmap drawCurve(int LinesIndex, List<float>[] Y_array, int X_Size, int Y_Size)
        {

            //Console.WriteLine("size: {0}，{1}", X_Size, Y_Size );

            float ZoomScale_X_Value = X_Size / 580.0f;
            float ZoomScale_Y_Value = Y_Size / 540.0f;

            //画笔定义 pen1
            Pen pen1 = new Pen(Color.Black, 2);
            pen1.DashStyle = DashStyle.Custom;

            //画图初始化
            Bitmap bmap = new Bitmap(X_Size, Y_Size);                           //画布图片大小
            Graphics gph = Graphics.FromImage(bmap);
            gph.Clear(Color.White);

            //曲线坐标轴设定
            PointF cpt = new PointF(30, Y_Size - 30);                           //坐标原点，坐标轴起始点
            PointF X_EndPoint = new PointF(X_Size - 30, Y_Size - 30);           //X轴终点
            PointF Y_EndPoint = new PointF(30, 30);                             //Y轴终点

            //坐标轴三角形箭头
            PointF[] xpt = new PointF[3] { new PointF(X_EndPoint.X + 15, X_EndPoint.Y), new PointF(X_EndPoint.X, X_EndPoint.Y - 4), new PointF(X_EndPoint.X, X_EndPoint.Y + 4) };//x轴三角形
            PointF[] ypt = new PointF[3] { new PointF(Y_EndPoint.X, Y_EndPoint.Y - 15), new PointF(Y_EndPoint.X - 4, Y_EndPoint.Y), new PointF(Y_EndPoint.X + 4, Y_EndPoint.Y) };//y轴三角形           

            //画图表标题
            //gph.DrawString(chartTitle, new Font("宋体", 14), Brushes.Black, new PointF(Y_EndPoint.X + 60, Y_EndPoint.Y - 30));//图表标题

            //画x轴、三角箭头、标题
            gph.DrawLine(pen1, cpt.X, cpt.Y, X_EndPoint.X, X_EndPoint.Y);
            gph.DrawPolygon(pen1, xpt);
            gph.FillPolygon(new SolidBrush(Color.Black), xpt);
            //gph.DrawString(X_title, new Font("宋体", 12), Brushes.Black, new PointF(X_EndPoint.X + 10, X_EndPoint.Y + 10));


            //画y轴三角箭头、标题
            gph.DrawLine(pen1, cpt.X, cpt.Y, Y_EndPoint.X, Y_EndPoint.Y);
            gph.DrawPolygon(pen1, ypt);
            gph.FillPolygon(new SolidBrush(Color.Black), ypt);
            //gph.DrawString(Y_title, new Font("宋体", 12), Brushes.Black, new PointF(0, Y_EndPoint.Y - 30));

            //Y轴刻度显示的值
            float[] Y_KeduArr = new float[YkeduCount];   
            for (int i = 0; i < YkeduCount; i++)
            {
                Y_KeduArr[i] = (i + 1)*0.5f;
            }

            ////给刻度值数组赋值
            //setKeduStringArray(X_KeduArr, X_AvgIncrement);
            //setKeduStringArray(Y_KeduArr, Y_AvgIncrement);

            //PointF X_KeduStart = new PointF(0, 590);
            //PointF X_KeduEnd = new PointF(340 + 130, X_EndPoint.Y);             //(430,440) x轴最后一根刻度线

            //刻度线位置坐标增量
            int GreatestCnt = Y_array[0].Count;
            for (int i = 0; i < Y_array.Length; i++)
            {
                if (GreatestCnt < Y_array[i].Count)
                {
                    GreatestCnt = Y_array[i].Count;
                }
            }

            int Temp = GreatestCnt / 20;
            float _X_KeduInCrementDisplayValue = 25 * ZoomScale_X_Value; 
            if (Temp != 0)
            {
                _X_KeduInCrementValue = _X_KeduInCrementDisplayValue / (Temp + 1);
            }
            else
            {
                _X_KeduInCrementValue = _X_KeduInCrementDisplayValue;
            }
            _Y_KeduInCrementValue = 40 * ZoomScale_Y_Value;

            //Console.WriteLine("Greatest.Length: {0}, {1}", GreatestCnt, _X_KeduInCrementValue);

            //X,Y刻度线起始位置,  X_KeduEnd 和 Y_KeduEnd没有使用                        //quanwu.xu  20200415
            PointF X_KeduStart = new PointF(cpt.X + _X_KeduInCrementDisplayValue, cpt.Y); 
            PointF X_KeduEnd = new PointF(X_EndPoint.X - 30, X_EndPoint.Y);
            PointF Y_KeduStart = new PointF(cpt.X, cpt.Y - _Y_KeduInCrementValue);                 
            PointF Y_KeduEnd = new PointF(Y_EndPoint.X, Y_EndPoint.Y - 30 + 300);     

            //设置X轴刻度值显示方向
            StringFormat X_StringFormat = new StringFormat();
            if (XdirectionVertical)
            {
                X_StringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            }
            StringFormat Y_StringFormat = new StringFormat();
            if (YdirectionVertical)
            {
                Y_StringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            }

            //Console.WriteLine("X_Kedu: {0}，{1}， {2}， {3}", X_KeduStart.X, X_KeduStart.Y, X_KeduEnd.X, X_KeduEnd.Y);
            //Console.WriteLine("Y_Kedu: {0}，{1}， {2}， {3}", Y_KeduStart.X, Y_KeduStart.Y, Y_KeduEnd.X, Y_KeduEnd.Y);
            //Console.WriteLine("InCrementValue: {0},{1}", _X_KeduInCrementValue, _Y_KeduInCrementValue);

            //画笔定义 pen1
            Pen pen2 = new Pen(Color.LightGray, 1);
            pen2.DashStyle = DashStyle.Dash;

            //画x轴刻度线、刻度值
            for (int i = 1; i <= XkeduCount; i++)
            {
                gph.DrawString((i*(Temp + 1)).ToString(Xformat), new Font("Times New Roman", 8), Brushes.Black, new PointF(X_KeduStart.X - 5 + (i - 1) * _X_KeduInCrementDisplayValue, cpt.Y + 5), X_StringFormat);// new StringFormat(StringFormatFlags.DirectionVertical));//最后一个参数实现文字竖排，默认为横排
                gph.DrawLine(pen2, X_KeduStart.X + (i - 1) * _X_KeduInCrementDisplayValue, cpt.Y, X_KeduStart.X + (i - 1) * _X_KeduInCrementDisplayValue, Y_EndPoint.Y);
            }

            ////画y轴刻度线、刻度值
            for (int i = 1; i <= YkeduCount; i++)
            {
                gph.DrawString(Y_KeduArr[i - 1].ToString(Yformat), new Font("Times New Roman", 11), Brushes.Black, new PointF(Y_KeduStart.X - 30 , Y_KeduStart.Y - (i - 1) * _Y_KeduInCrementValue - 6), Y_StringFormat);
                gph.DrawLine(pen2, Y_KeduStart.X, Y_KeduStart.Y - (i - 1) * _Y_KeduInCrementValue, X_EndPoint.X, Y_KeduStart.Y - (i - 1) * _Y_KeduInCrementValue);
            }

            //画连接线
            if (LinesIndex != 0)
            {
                float Y_K = 12.5f / ZoomScale_Y_Value;
                float Y_B = Y_Size - 30;
                float Y_Value1;
                float Y_Value2;

                Console.WriteLine("Y_Cnt: {0}，{1}， {2}， {3}", Y_array[0].Count, Y_array[1].Count, Y_array[2].Count, Y_array[3].Count);

                //画笔定义 pen1
                Pen pen3 = new Pen(Color.Green, 1.5f);
                pen3.DashStyle = DashStyle.Solid;
                if (((LinesIndex & 0x01) == 0x01) && (Y_array[0].Count > 1))                              //Co
                {
                    for (int i = 2; i <= Y_array[0].Count; i++)
                    {
                        Y_Value1 = Standard(Y_array[0][i - 2], Y_K, Y_B);
                        Y_Value2 = Standard(Y_array[0][i - 1], Y_K, Y_B);

                        Console.WriteLine("Y_Point: {0}，{1}", Y_Value1, Y_Value2);
                        //画点
                        //gph.DrawEllipse(Pens.Black, X_KeduStart.X + (i - 1) * _X_KeduInCrementValue, Y_Value1, 3, 3);

                        //画折线
                        gph.DrawLine(pen3, cpt.X + (i - 2) * _X_KeduInCrementValue, Y_Value1, cpt.X + (i - 1) * _X_KeduInCrementValue, Y_Value2);

                    }
                }

                //画笔定义 pen1
                Pen pen4 = new Pen(Color.Black, 1.5f);
                pen3.DashStyle = DashStyle.Solid;
                if (((LinesIndex & 0x02) == 0x02) && (Y_array[1].Count > 1))                              //Dark
                {
                    for (int i = 2; i <= Y_array[1].Count; i++)
                    {
                        Y_Value1 = Standard(Y_array[1][i - 2], Y_K, Y_B);
                        Y_Value2 = Standard(Y_array[1][i - 1], Y_K, Y_B);

                        //画点
                        //gph.DrawEllipse(Pens.Black, X_KeduStart.X + (i - 1) * _X_KeduInCrementValue, Y_Value1, 3, 3);

                        //画折线
                        gph.DrawLine(pen4, cpt.X + (i - 2) * _X_KeduInCrementValue, Y_Value1, cpt.X + (i - 1) * _X_KeduInCrementValue, Y_Value2);

                    }
                }

                //画笔定义 pen1
                Pen pen5 = new Pen(Color.Red, 1.5f);
                pen3.DashStyle = DashStyle.Solid;
                if (((LinesIndex & 0x04) == 0x04) && (Y_array[2].Count > 1))                              //Light
                {
                    for (int i = 2; i <= Y_array[2].Count; i++)
                    {
                        Y_Value1 = Standard(Y_array[2][i - 2], Y_K, Y_B);
                        Y_Value2 = Standard(Y_array[2][i - 1], Y_K, Y_B);

                        //画点
                        //gph.DrawEllipse(Pens.Black, X_KeduStart.X + (i - 1) * _X_KeduInCrementValue, Y_Value1, 3, 3);

                        //画折线
                        gph.DrawLine(pen5, cpt.X + (i - 2) * _X_KeduInCrementValue, Y_Value1, cpt.X + (i - 1) * _X_KeduInCrementValue, Y_Value2);

                    }
                }


                //画笔定义 pen1
                Pen pen6 = new Pen(Color.Blue, 1.5f);
                pen3.DashStyle = DashStyle.Solid;
                if (((LinesIndex & 0x08) == 0x08) && (Y_array[3].Count > 1))                              //L_D
                {
                    for (int i = 2; i <= Y_array[3].Count; i++)
                    {
                        Y_Value1 = Standard(Y_array[3][i - 2], Y_K, Y_B);
                        Y_Value2 = Standard(Y_array[3][i - 1], Y_K, Y_B);

                        //画点
                        //gph.DrawEllipse(Pens.Black, X_KeduStart.X + (i - 1) * _X_KeduInCrementValue, Y_Value1, 3, 3);

                        //画折线
                        gph.DrawLine(pen6, cpt.X + (i - 2) * _X_KeduInCrementValue, Y_Value1, cpt.X + (i - 1) * _X_KeduInCrementValue, Y_Value2);

                    }
                }
            }

            return bmap;
            //保存输出图片
        }
    }

    #endregion
}


#region 数据对象
namespace Mytest1
{
    class myValueObject
    {
        private int MemCnt = 5;

        private string DataName;
        public int[] DataValue = new int[5];
        //public TextBox[] TextBoxList = new TextBox[5];

        //创建对象    
        public myValueObject(string Name, int[] Value)
        {
            this.DataName = Name;
            for (int i = 0; i < this.MemCnt; i++ )
            {
                this.DataValue[i] = Value[i];
            }
        }

        //名称
        public string GetName()
        {
            return this.DataName;
        }

        //取数据
        public int GetValue(int Index)
        {
            return this.DataValue[Index];
        }

        //写数据
        public int SetValue(int Index, int SetData)
        {
            return this.DataValue[Index] = SetData;
        }
    }
}
#endregion






