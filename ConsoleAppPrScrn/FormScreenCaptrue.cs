using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace screenCaptrue
{

    public partial class FormScreenCaptrue : Form
    {
        public FormScreenCaptrue()
        {
            InitializeComponent();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    Hotkey.ProcessHotKey(m);
        //}

        //protected override void DefWndProc(ref Message m)
        //{
        //    if (m.Msg == 0x104)
        //    {
        //        m.Result = (IntPtr)DLL.PrScrn();
        //        return;
        //    }
        //    else
        //    {
        //    }
        //    base.DefWndProc(ref m);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //int i = DLL.PrScrn();
        //    //if (i == 1)
        //    //{
        //    //    Image image = Clipboard.GetImage();
        //    //    image.Save(@"D:\hello.png");
        //    //    image.Dispose();
        //    //}
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //注册热键(窗体句柄,热键ID,辅助键,实键)   
        //    try
        //    {
        //        //Hotkey.Regist(this.Handle, HotkeyModifiers.MOD_ALT, Keys.F1, ScreenCapture);
        //        int i = DLL.PrScrn();
        //        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenCaptrue.txt");
        //        File.WriteAllText(path, i.ToString());
        //    }
        //    catch //(Exception ex)
        //    {
        //        //MessageBox.Show("Alt + A 热键被占用");
        //    }
        //    finally
        //    {
        //        //this.Close();
        //        Application.Exit();
        //    }
        //}

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                int i = DLL.PrScrn();
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenCaptrue.txt");
                File.WriteAllText(path, i.ToString());
            }
            catch { }
            finally
            {
                Application.Exit();
            }
        }

        //private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //注消热键(句柄,热键ID)   
        //    Hotkey.UnRegist(this.Handle, ScreenCapture);
        //}

        //private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
        //    {
        //        this.Show();
        //        this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        //    }
        //    else
        //    {
        //        this.Hide();
        //        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        //    }
        //}

        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        //this.Hide();
        //        this.notifyIcon1.Visible = true;
        //        //弹气泡/通知框提示
        //        this.notifyIcon1.ShowBalloonTip(20, "ScreenCaptrue", "ScreenCaptrue Alt+F1", ToolTipIcon.Info);
        //    }
        //}
    }

    public class DLL
    {
        [DllImport("PrScrn.dll", EntryPoint = "PrScrn")]

        public extern static int PrScrn();//与dll中一致   
    }

    //public static class Hotkey
    //{

    //    #region 系统api
    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers fsModifiers, Keys vk);

    //    [DllImport("user32.dll")]
    //    static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    //    #endregion

    //    /// <summary> 
    //    /// 注册快捷键 
    //    /// </summary> 
    //    /// <param name="hWnd">持有快捷键窗口的句柄</param> 
    //    /// <param name="fsModifiers">组合键</param> 
    //    /// <param name="vk">快捷键的虚拟键码</param> 
    //    /// <param name="callBack">回调函数</param> 
    //    public static void Regist(IntPtr hWnd, HotkeyModifiers fsModifiers, Keys vk, HotKeyCallBackHanlder callBack)
    //    {
    //        int id = keyid++;
    //        if (!RegisterHotKey(hWnd, id, fsModifiers, vk))
    //            throw new Exception("regist hotkey fail.");
    //        keymap[id] = callBack;
    //    }

    //    /// <summary> 
    //    /// 注销快捷键 
    //    /// </summary> 
    //    /// <param name="hWnd">持有快捷键窗口的句柄</param> 
    //    /// <param name="callBack">回调函数</param> 
    //    public static void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
    //    {
    //        foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
    //        {
    //            if (var.Value == callBack)
    //                UnregisterHotKey(hWnd, var.Key);
    //        }
    //    }

    //    /// <summary> 
    //    /// 快捷键消息处理 
    //    /// </summary> 
    //    public static void ProcessHotKey(System.Windows.Forms.Message m)
    //    {
    //        if (m.Msg == WM_HOTKEY)
    //        {
    //            int id = m.WParam.ToInt32();
    //            HotKeyCallBackHanlder callback;
    //            if (keymap.TryGetValue(id, out callback))
    //            {
    //                callback();
    //            }
    //        }
    //    }

    //    const int WM_HOTKEY = 0x312;
    //    static int keyid = 10;
    //    static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

    //    public delegate void HotKeyCallBackHanlder();
    //}

    //public enum HotkeyModifiers
    //{
    //    MOD_ALT = 0x1,
    //    MOD_CONTROL = 0x2,
    //    MOD_SHIFT = 0x4,
    //    MOD_WIN = 0x8
    //}
}
