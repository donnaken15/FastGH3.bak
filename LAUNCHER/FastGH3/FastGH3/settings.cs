using System.Windows.Forms;
using System.IO;
using System;
using Ini;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FastGH3
{
    public partial class settings : Form
    {
        public static IniFile dxwndini = new IniFile("C:\\Windows\\FastGH3\\WINDOWED\\dxwnd.ini");

        void changeRes(string width, string height)
        {
            try
            {
                var olddxwnd = Process.GetProcessesByName("dxwnd")[0];
                olddxwnd.Kill();
            }
            catch
            {

            }
            File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\resx",width);
            File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\resy", height);
            dxwndini.IniWriteValue("target","sizx0",width);
            dxwndini.IniWriteValue("target", "sizy0", height);
            File.WriteAllText(Path.Combine(Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName,"Local\\Aspyr\\FastGH3\\AspyrConfig.xml"), "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<r>\n    <s id = \"Video.Width\">"+width+"</s>\n    <s id = \"Video.Height\">"+height+"</s>\n    <s id = \"Options.GraphicsQuality\">0</s>\n    <s id = \"Options.Crowd\">0</s>\n    <s id = \"Options.Physics\">0</s>\n    <s id = \"Options.Flares\">0</s>\n    <s id = \"Options.FrontRowCamera\">1</s>\n    <s id = \"AudioLagReminderShown\">1</s>\n    <s id = \"AutoLogin\">OFF</s>\n    <s id = \"Username\"></s>\n    <s id = \"MatchUsername\"></s>\n    <s id = \"Password\"></s>\n    <s id = \"6f1d2b61d5a011cfbfc7444553540000\">201 202 203 204 205 402 999 219 235 400 401 999 310</s>\n    <s id = \"Sound.SongSkew\">0</s>\n</r>");
            Process newdxwnd = new Process();
            newdxwnd.StartInfo.FileName = "C:\\Windows\\FastGH3\\WINDOWED\\dxwnd.exe";
            newdxwnd.StartInfo.WorkingDirectory = "C:\\Windows\\FastGH3\\WINDOWED\\";
            newdxwnd.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            newdxwnd.Start();

        }

        public settings()
        {
            DialogResult = DialogResult.OK;
            InitializeComponent();
            res.Text = dxwndini.IniReadValue("target", "sizx0") + "x" + dxwndini.IniReadValue("target","sizy0");
            if (File.Exists("C:\\Windows\\FastGH3\\CONFIGS\\difficulty"))
            {
                diff.Text = File.ReadAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty");
            }
            else
            {
                File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty", "Expert");
            }
        }

        private void res_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (res.SelectedIndex==0)
            {
                changeRes("800","600");
            }
            if (res.SelectedIndex == 1)
            {
                changeRes("1024", "768");
            }
            if (res.SelectedIndex == 2)
            {
                changeRes("1152", "864");
            }
            if (res.SelectedIndex == 3)
            {
                changeRes("1280", "720");
            }
            if (res.SelectedIndex == 4)
            {
                changeRes("1280", "768");
            }
            if (res.SelectedIndex == 5)
            {
                changeRes("1280", "800");
            }
            if (res.SelectedIndex == 6)
            {
                changeRes("1280", "960");
            }
            if (res.SelectedIndex == 7)
            {
                changeRes("1280", "1024");
            }
            if (res.SelectedIndex == 8)
            {
                changeRes("1360", "768");
            }
            if (res.SelectedIndex == 9)
            {
                changeRes("1366", "768");
            }
            if (res.SelectedIndex == 10)
            {
                changeRes("1440", "900");
            }
            if (res.SelectedIndex == 11)
            {
                changeRes("1600", "900");
            }
            if (res.SelectedIndex == 12)
            {
                changeRes("1600", "1024");
            }
            if (res.SelectedIndex == 13)
            {
                changeRes("1680", "1050");
            }
            if (res.SelectedIndex == 14)
            {
                changeRes("1768", "992");
            }
            if (res.SelectedIndex == 15)
            {
                changeRes("1920","1080");
            }

        }

        private void diff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diff.SelectedIndex==0)
            {
                File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty","Easy");
            }
            if (diff.SelectedIndex==1)
            {
                File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty", "Medium");
            }
            if (diff.SelectedIndex==2)
            {
                File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty", "Hard");
            }
            if (diff.SelectedIndex==3)
            {
                File.WriteAllText("C:\\Windows\\FastGH3\\CONFIGS\\difficulty", "Expert");
            }
        }

        private void creditlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(@"Credits:

Developed by
donnaken15

Additional help by
ExileLord
Nanook
adituv

Images and sounds by
Activision
RedOctane
NeverSoft
Aspyr

Coding assistance by
Stackoverflow users");
        }
    }
}
