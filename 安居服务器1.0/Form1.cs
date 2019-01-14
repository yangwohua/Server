#region    
//  安居服务器1.0v
//  wubo           日期:2017/11/9
//                 今日状态:  良好
//
//  
//
//
//
//
#endregion


#region 引用命名空间
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 安居服务器1._0.Properties;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Serialization;
using System.Collections;
#endregion

namespace 安居服务器1._0
{
    public partial class Form1 : Form
    {
        private IPAddress local;

       // 显示接收消息回调
       private delegate void ShowReceiveMsgCallBack(string text);
       private ShowReceiveMsgCallBack showReceiveMsgCallBack;

       private void ShowReceiveMsg(string text)
       {
          // lstMsg.Items.Add(text);
            lstMsg.Items.Insert(0, text);
       }

        public Form1()
        {
            InitializeComponent();

            

            
        }

        // 显示接收消息回调方法
     

        #region   公共变量

        
        Dictionary<string, Socket> devicesocket = new Dictionary<string, Socket>();  //设备端+手机终端
        Dictionary<string, Socket> datasocket = new Dictionary<string, Socket>();    //设备数据端

        Dictionary<string, int> socektTime = new Dictionary<string, int>();//Socekt 对应的次数 作为心跳包
        Dictionary<string, Socket> IDdatasocekt = new Dictionary<string, Socket>();//ID名字与datasocekt连接
        Dictionary<string, Socket> IDAPPsocekt = new Dictionary<string, Socket>();//ID名字与APPsocekt连接
        //类对象的定义
        TcpSocket Tsk = new TcpSocket();
        Socket socketWatch;
        Thread th_socket;
        string title = "MIWL-1.0(OpenCV+Test)" ;

        #endregion

        #region 回调
        //// 添加客户端回调
        //private delegate void AddNewClientCallBack(string endPoint);
        //private AddNewClientCallBack addNewClientCallBack;

        //// 显示接收消息回调
        //private delegate void ShowReceiveMsgCallBack(string text);
        //private ShowReceiveMsgCallBack showReceiveMsgCallBack;

        //// 删除客户端回调
        //private delegate void DeleteClientCallBack(int index);
        //private DeleteClientCallBack deleteClientCallBack;



        #endregion


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        #region   string IP_string()返回本机IP地址 0异常
        private void IP_string()
        {

            string name = Dns.GetHostName();

            IPHostEntry me = Dns.GetHostEntry(name);

            foreach (IPAddress IPitem in me.AddressList)
            {
                if ("1" == IPitem.ToString().Substring(0,1))
                {
                    ip_tb.Items.Add(IPitem.ToString());
                    ip_tb.Text= IPitem.ToString();
                }
            }
          

        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {


            this.Text = title;
           
            IP_string();//IP地址

            Control.CheckForIllegalCrossThreadCalls = false;  //取消跨线程的检查

            //接收信息设置
           
            showReceiveMsgCallBack = new ShowReceiveMsgCallBack(ShowReceiveMsg);

        }

        private void button1_Click(object sender, EventArgs e)
        {

    

            try
            {
                 
                if (start_bt.Text == "启 动")
                {
                    

        
                    local = IPAddress.Parse(ip_tb.Text.ToString());
                    IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                    socketWatch = Tsk.socket();

                    //获取当前应用程序的IP地址和端口号
                  //  IPAddress ip = IPAddress.Parse(ip_tb.Text.Trim());

                    //获得当前应用程序的端口号
                    IPEndPoint point = new IPEndPoint(local, int.Parse(dk_tb.Text));
                     
                    //让我们负责监听的Socket 开始监听当前应用程序
                    socketWatch.Bind(point);

                    //设置监听队列
                    socketWatch.Listen(10);

                    //启动监听线程
                    th_socket = new Thread(Socket_Listen);
                    th_socket.IsBackground = true;
                    th_socket.Start(socketWatch);


                    lstMsg.Items.Insert(0,DateTime.Now.ToString("T") + ":" + "启动服务器成功");
                    lstMsg.Items.Insert(0, DateTime.Now.ToString("T") + ":" + "开始监听" + dk_tb.Text + "端口.....                                                                                                                                                                                                                                                                                                                                                                           end");

                    dk_tb.ReadOnly = !dk_tb.ReadOnly;

                    this.Text = title + "(MIWL-1.0 Just Working......)";

                    start_bt.Text = "关 闭";
                }
                else
                {
                    // socketWatch.Shutdown(SocketShutdown.Both);

                    for (int i = 0; i < lb_Client.Items.Count; i++)
                    {
                        //删除dictionary中的结点
                        devicesocket.Remove(lb_Client.Items[i].ToString());
                        //lb_Client.Invoke(deleteClientCallBack, i);
                      
                    }
                    lb_Client.Items.Clear();

                    socketWatch.Close();
                    th_socket.Abort();

                    dk_tb.ReadOnly = !dk_tb.ReadOnly;
                    this.Text = title;
                    lstMsg.Items.Insert(0, DateTime.Now.ToString("T") + ":" + "服务器关闭成功...");
                    devicesocket.Clear();
                    lb_Client.Items.Clear();

                    start_bt.Text = "启 动";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region  Accepet 监听请求函数  Socket_Listen()
        public void Socket_Listen(Object o)
        {
            Socket socketWatch = o as Socket;
            //等待连接    Accepet 监听请求  返回通信 Socket    主线程已经死了   线程参数 是Object
                while (true)
                {

                    Socket socketSend = socketWatch.Accept();

                //device-需要alive包   该线程 为 device（APP、设备） 与服务器的通信
                if (IsCommon(socketSend.RemoteEndPoint.ToString()) == 0)
                {
                    devicesocket.Add(socketSend.RemoteEndPoint.ToString(),socketSend);//添加到devicesocket
                    socektTime.Add(socketSend.RemoteEndPoint.ToString(), 0);//添加到socektTime
                    lb_Client.Items.Add(socketSend.RemoteEndPoint.ToString());
                    //不停的接受客户发送过来的数据
                    //开启新线程
                    Thread th2 = new Thread(SocketDeviceReceive);
                    th2.IsBackground = true;
                    th2.Start(socketSend);
                }
                //暗线包-硬件设备与手机APP的数据往来
                else
                {
                    datasocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);//添加到datasocket
                    lb_ClientData.Items.Add(socketSend.RemoteEndPoint.ToString());
                    //不停的接受客户发送过来的数据
                    //开启新线程
                    Thread th2 = new Thread(SocketDataReceive);
                    th2.IsBackground = true;
                    th2.Start(socketSend);
                }
                lstMsg.Items.Insert(0, DateTime.Now.ToString("T") + ":" + socketSend.RemoteEndPoint.ToString() + "已连接...");

                }
          

        }
        #endregion

        public void SleepTime(object endPoint)
        {
            string s= Convert.ToString(endPoint);
            Socket so = devicesocket[s];
            while (true)
            {
                Thread.Sleep(3600000);
                try
                {
                    if (socektTime[s] == 0)
                    {
                        so.Close();
                        DisconnectSocekt(s);
                        break;
                    }
                    socektTime[s] = 0;
                }
                catch
                {
                    break;
                }

            }
        }


        #region 接收处理设备端、手机终端数据函数
        public void  SocketDeviceReceive(object o)
        {
            Socket socketSend = o as Socket;
            int readlen = 0;

            //COMMOM:心跳包 and failure包
            byte[] alive = new byte[] { 0xAA, 0x96, 0xBA, 0x00, 0x00, 0x00, 0x69 };
            byte[] fresponse = new byte[] { 0xAA, 0x96, 0xBA, 0x01, 0x01, 0x00, 0x00, 0x69 };
            string strid = "";

            //硬件终端->服务器 私有变量
            int img0count = 0;
            int img1count = 0;
            int img2count = 0;

            Socket datas = null;
            //客户端
            string endPoint = socketSend.RemoteEndPoint.ToString();
            int socketlen = 0;
            //创建心跳包线程
            //开启新线程
            Thread thsocekttiom = new Thread(SleepTime);
            thsocekttiom.IsBackground = true;
            thsocekttiom.Start(endPoint);
            
            while (true)
            {
                try
                {
                    //5M
                    byte[] buffer = new byte[1024*1024];
                    readlen = socketSend.Receive(buffer);
                    //可能是心跳包
                    if (readlen > 6)
                    {
                        if (buffer[3] == 0)
                        {
                            socketlen = 7;
                        }
                        else
                        {
                            socketlen = buffer[5];
                            socketlen = socketlen * 256 + buffer[4] + 7;
                        }
                        while (readlen < socketlen)
                        {
                            readlen += socketSend.Receive(buffer, readlen, socketlen - readlen, SocketFlags.None);
                        }
                    }



                    //判断是否点击关闭按钮
                    if (lb_Client.Items.Count == 0) break;

                    #region  注释
                    //while (readlen != buffer.Length)
                    //{
                    //    readlen += socketSend.Receive(buffer, readlen, buffer.Length - readlen, SocketFlags.None);
                    //}
                    // 将字节数组转换为文本形式
                    //getMsg = Encoding.Default.GetString(buffer);
                    // getMsg= Encoding.UTF8.GetString(buffer);
                    //string getMsg=  System.Text.Encoding.BigEndianUnicode.GetString(buffer); 
                    //getMsg.Replace("\0", "");
                    #endregion

                    #region 是否掉线  and 心跳包回复
                    if (readlen == 0|| readlen == 7)
                    {

                        //收心跳包
                        if (buffer[1]+buffer[readlen-1]==0xff)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":alive");
                            }));
                            
                            socektTime[endPoint] = 1;

                            //回心跳包
                            if (buffer[2] == 0xab) { alive[2] = 0xba; }
                            else { alive[2] = 0xbc; }
                            socketSend.Send(alive);
                            continue;
                        }
                        else
                        {
                           
                            break;
                        }
                        
                    }
                    #endregion
                    
                    //处理包 得到STDID TKD
                    if(buffer[0]==0xAA&&buffer[1]+buffer[readlen-1]==0xFF)
                    {
                        switch(buffer[2])
                        {
                            case 0xAB:
                                #region 硬件终端->服务器
                                Int32 datalen = 0;
                                datalen = buffer[5];
                                datalen = datalen * 256 + buffer[4];
                                
                                //任务标识  1硬件ID  2图片数据
                                switch (buffer[3])
                                {
                                    case 1:
                                        byte[] idbytes = new byte[datalen];
                                        Array.Copy(buffer, 6, idbytes, 0, datalen);
                                        Socket s;
                                        if (((s = GetDataSocket(endPoint)) == null)||strid!="") {fresponse[6] = 0x00; }
                                        else {
                                            strid = "pgz001";//System.Text.Encoding.UTF8.GetString(idbytes);
                                            IDdatasocekt.Add(strid,s); fresponse[6] = 0x01; }
                                        fresponse[2] = 0xBA;
                                        fresponse[3] = 0x01;
                                        this.Invoke(new Action(() =>
                                        {  
                                          lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":获取PCRobotID->" + strid.ToString());
                                        }));
                                        socketSend.Send(fresponse);
                                        break;

                                    case 2:
                                        byte[] imgdata = new byte[datalen - 1];
                                        Array.Copy(buffer, 7, imgdata, 0, datalen - 1);
                                        int CID = buffer[6];
                                        fresponse[2] = 0xBA;
                                        fresponse[3] = 0x02;
                                        try
                                        {
                                            MemoryStream ms = new MemoryStream(imgdata);
                                            Image img = Image.FromStream(ms);
                                            //byte[] fresponse = new byte[] { 0xAA, 0x96, 0xBA, 0x01, 0x01, 0x00, 0x00, 0x69 };
                                            fresponse[6] = 0x01;
                                            this.Invoke(new Action(() =>
                                            {
                                                switch (CID)
                                                {
                                                    case 0:
                                                        pbimg0.Image = img;
                                                        lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":" + strid + "_" + CID + "_" +img0count++);
                                                        break;
                                                    case 1:
                                                        pbimg1.Image = img;
                                                        lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":" + strid + "_" + CID + "_" + img1count++);
                                                        break;
                                                    case 2:
                                                        pbimg2.Image = img;
                                                        lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":" + strid + "_" + CID + "_" + img2count++);
                                                        break;
                                                    default: break;
                                                }
                                                
                                            }));
                                        }
                                        catch
                                        {
                                            fresponse[6] = 0x00;
                                            lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":获取IMG" + CID+"failure");
                                        }
                                        socketSend.Send(fresponse);
                                        break;
                                    default:break;
                                }
                                #endregion
                                break;

                            //手机终端->硬件终端
                            case 0xCA:
                                if (datas == null)
                                {
                                    datas = IDdatasocekt[strid];
                                    IDAPPsocekt.Add(strid,socketSend);
                                }
                                datas.Send(buffer,0,readlen,0);
                                break;

                            //手机终端->服务器
                            case 0xCB:
                                #region 连接终端ID标识包
                                Int32 cbdatalen = 0;
                                cbdatalen = buffer[5];
                                cbdatalen = cbdatalen * 256 + buffer[4];
                                byte[] cbidbytes = new byte[cbdatalen];
                                Array.Copy(buffer, 6, cbidbytes, 0, cbdatalen);
                                strid = System.Text.Encoding.UTF8.GetString(cbidbytes);
                                //连接strid与机器人  返回Y/N
                                //byte[] fresponse = new byte[] { 0xAA, 0x96, 0xBA, 0x01, 0x01, 0x00, 0x00, 0x69 };
                                fresponse[2] = 0xBC;
                                fresponse[3] = 0x01;
                                fresponse[4] = 0x01;
                                fresponse[5] = 0x00;
                                fresponse[6] = 0x01;
                                socketSend.Send(fresponse);
                                this.Invoke(new Action(() =>
                                {
                                    lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":PCRobotName->"+ strid);
                                }));
                                break;
                            #endregion
                            default:break;
                        }



                    //   #region 处理正确数据
                    //this.Invoke(new Action(() =>
                    //{
                    //    try
                    //    { 
                    //       // System.IO.File.WriteAllBytes("G:\\111.avi", buffer);
                    //        lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":" + readlen.ToString());
                    //    }
                    //    catch
                    //    {
                    //        lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":img not get");
                    //    }
                    //}));
                    //#endregion 
                    }
                    //脏包 舍弃
                    else
                    {
                        if (buffer[2] == 0xab) { fresponse[2] = 0xba; }
                        else { fresponse[2] = 0xbc; }
                        fresponse[3] = buffer[3];
                        fresponse[6] = 0;
                        //发送失败包
                        socketSend.Send(fresponse);
                        this.Invoke(new Action(() =>
                        {
                            lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":error packet");
                        }));
                        

                    }
                   

                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    break;
                }

            }
            RemoveItem(endPoint, socketSend);
        }

        #endregion

        #region 接收处理设备端视频数据函数
        public void SocketDataReceive(object o)
        {
            Socket socketSend = o as Socket;
            Socket APPsocekt = null;
            int readlen = 0;
            //客户端
            string endPoint = socketSend.RemoteEndPoint.ToString();
            int socketlen = 0;
            while (true)
            {
                try
                {
                    //5M
                    byte[] buffer = new byte[1024*1024*5];
                    readlen = socketSend.Receive(buffer);
                    
                    socketlen = buffer[5];
                    socketlen = socketlen * 256 + buffer[4]+7;

                    while (readlen<socketlen)
                    {
                        readlen += socketSend.Receive(buffer, readlen, socketlen - readlen, SocketFlags.None);
                    }

                    //判断是否点击关闭按钮
                    if (lb_Client.Items.Count == 0) break;

                    #region  注释
                    //while (readlen != buffer.Length)
                    //{
                    //    readlen += socketSend.Receive(buffer, readlen, buffer.Length - readlen, SocketFlags.None);
                    //}
                    // 将字节数组转换为文本形式
                    //getMsg = Encoding.Default.GetString(buffer);
                    // getMsg= Encoding.UTF8.GetString(buffer);
                    //string getMsg=  System.Text.Encoding.BigEndianUnicode.GetString(buffer); 
                    //getMsg.Replace("\0", "");
                    #endregion

                    #region 是否掉线 
                    if (readlen == 0)
                    {
                        break;

                    }
                    #endregion

                    #region 处理正确数据

                    if (APPsocekt == null)
                    {
                        foreach (String value in IDdatasocekt.Keys)
                        {
                            if (IDdatasocekt[value] == socketSend)
                            {
                                APPsocekt = IDAPPsocekt[value];
                            }
                        }
                    }
                    APPsocekt.Send(buffer, 0, readlen, 0);
                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            //System.IO.File.WriteAllBytes("G:\\111.avi", buffer);
                            lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":" + readlen.ToString());
                        }
                        catch
                        {
                            lstMsg.Invoke(showReceiveMsgCallBack, DateTime.Now.ToString("T") + ":" + endPoint + ":img not get");
                        }
                    }));
                    #endregion 
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    break;
                }

            }
            RemoveItemData(endPoint, socketSend);
        }

        #endregion

        public int IsCommon(string socektstr)
        {
            // 遍历字典中的键
            foreach (var str in devicesocket.Keys)
            {
                string[] strs=str.Split(':');
                if(socektstr.Substring(0,strs[0].Length)==strs[0])
                {
                    return 1;
                }
            }
            return 0;
        }
        public Socket GetDataSocket(string socektstr)
        {
            // 遍历字典中的键
            foreach (var str in datasocket.Keys)
            {
                string[] strs = str.Split(':');
                if (socektstr.Substring(0, strs[0].Length) == strs[0])
                {
                    return datasocket[str];
                }
            }
            return null;
        }

        public void DisconnectSocekt(string socektstr)
        {
            // 遍历字典中的键
            foreach (var str in datasocket.Keys)
            {
                string[] strs = str.Split(':');
                if (socektstr.Substring(0, strs[0].Length) == strs[0])
                {
                    datasocket[str].Close();

                }
            }
        }




     




        private void clear_bt_Click(object sender, EventArgs e)
        {
            lstMsg.Items.Clear();
            lstMsg.Items.Add("                                                                                                                                                                                                                                                                                                                                 end");
        }


        #region 回调方法
        // 添加客户端回调方法
        private void AddNewClient(string endPoint)
        {
            lb_Client.Items.Add(endPoint);
        }

        // 显示接收消息回调方法
       // private void ShowReceiveMsg(string text)
       // {
         //   lstMsg.Items.Add(text);
      //  }

        // 删除客户端回调党法
        private void DeleteClient(int index)
        {
            lb_Client.Items.RemoveAt(index);
        }


        #endregion


        private void RemoveItem(string endPoint,Socket socketSend)
        {
            this.Invoke(new Action(() =>
            {
                lb_Client.Items.Remove(endPoint);
                lstMsg.Items.Insert(0, DateTime.Now.ToString("T") + ":" + endPoint + "已经断开连接...");
            }));
           
         

            //删除dictionary中的结点
            devicesocket.Remove(endPoint);
            socektTime.Remove(endPoint);
            socketSend.Close();
        }
        private void RemoveItemData(string endPoint, Socket socketSend)
        {
            this.Invoke(new Action(() =>
            {
                lb_ClientData.Items.Remove(endPoint);
    
                lstMsg.Items.Insert(0, DateTime.Now.ToString("T") + ":" + endPoint + "已经断开连接...");
            }));

            foreach (KeyValuePair<string, Socket> kvp in IDdatasocekt)
            {
                if (kvp.Value.Equals(socketSend))
                {
                    IDdatasocekt.Remove(kvp.Key);
                    break;
                }
            }
            //删除dictionary中的结点
            datasocket.Remove(endPoint);
            socketSend.Close();
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible==true)
            {
                this.Hide();
                // this.Visible = true;
             //   
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        protected override void OnResize(EventArgs e)
        {
            if(WindowState==FormWindowState.Minimized)
            {
                this.Hide();//Yes
             
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
           // this.ShowInTaskbar = true;  
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        


       

       
        /*
        public void Socket_Time(Object o)
        {
            Socket t = o as Socket;

            string endPoint = t.RemoteEndPoint.ToString();
            while (true)
            {
                Thread.Sleep(500);
                if (socektTime[t] == 1)
                {
                    socektTime[t] = 0;
                }
                else
                {
                    for (int i = 0; i < lb_Client.Items.Count; i++)
                    {
                        if (string.Equals(lb_Client.Items[i].ToString(), endPoint))
                        {
                            //lb_Client.Invoke(deleteClientCallBack, i);
                            lb_Client.Items.Remove(lb_Client.Items[i]);
                        }
                    }
                    //删除dictionary中的结点
                    socektTime.Remove(t);

                    dicSocket.Remove(endPoint);


                    //lstMsg.Invoke(showReceiveMsgCallBack, endPoint + "已经断开连接...");
                    lstMsg.Items.Add(DateTime.Now.ToString() + ":" + endPoint + "已经断开连接...");

                    t.Close();

                    break;

                }

                // if()
            }
        }
        */
        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            help_form s = new help_form();
            s.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label2.Text =DateTime.Now.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tooltitle_lb_Click(object sender, EventArgs e)
        {
            
        }

        private void tooltitle_lb_Click_1(object sender, EventArgs e)
        {
           
        }

        private void tooltitle_lb_MouseEnter(object sender, EventArgs e)
        {
            tool_time.Enabled = true;
        }

        private void tool_time_Tick(object sender, EventArgs e)
        {
           
        }


       

        private void 作者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("201512700139");
        }
      
    

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstMsg.Items.Clear();
        }

        private void ip_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//取消输入事件
        }

       

        private void Form1_Leave(object sender, EventArgs e)
        {

        }



    }
}
