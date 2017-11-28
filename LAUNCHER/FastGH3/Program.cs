using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;
using System.Drawing;
//using Nini.Config;
//using Ini;
using IniParser;
using IniParser.Model;

namespace FastGH3
{
    class Program
    {
        private static string currentchart;
        private static string chart;
        private static string[] parameters;
        private static OpenFileDialog openchart = new OpenFileDialog() { AddExtension = true, CheckFileExists = true, CheckPathExists = true, Filter = "All chart types|*.mid;*.chart|Song.ini|Song.ini|Any type|*.*", RestoreDirectory = true, Title = "Select chart" };
        private static int maxarraysize;
        private static FileIniDataParser chartini;
        private static IniData data;

        static void disallowGameStartup()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("GH3"))
                {
                    proc.Kill();
                }
                foreach (Process proc2 in Process.GetProcessesByName("DxWnd"))
                {
                    proc2.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.Write("ERROR! :(\n" + ex.Message);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "FastGH3";
            Console.CursorVisible = false;
            Console.WindowWidth = 41;
            Console.WindowHeight = 19;
            Console.BufferWidth = 41;
            Console.BufferHeight = 19;
            parameters = Environment.GetCommandLineArgs();
            if (args.Length == 0)
            {
                if (File.Exists(@"C:\Windows\fastgh3\CONFIGS\startupmsg"))
                {
                    if (File.ReadAllText(@"C:\Windows\fastgh3\CONFIGS\startupmsg").ToString() == "on")
                    {
                        Console.CursorVisible = false;
                        Console.WriteLine(@" 
 FastGH3 is an advanced mod of
 Guitar Hero 3 designed to be played
 as fast as possible. With this mod, you
 can play customs without any technical
 setup and even associate chart or mid
 files with the game so you can access
 your charts quickly.

 To access settings,
 use -settings in parameters.

 If you want to disable this welcome
 message, you can do so by using
 these parameters:
 -startupmsg off

 Press any key to load a chart.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Windows\fastgh3\CONFIGS\");
                    File.WriteAllText(@"C:\Windows\fastgh3\CONFIGS\startupmsg", "on");
                }
                if (openchart.ShowDialog() == DialogResult.OK && args.Length == 0)
                {
                    Console.WriteLine("FASTGH3 by donnaken15");
                    Console.WriteLine("Checking file extension...");

                    if (openchart.SafeFileName.Contains(".chart") && !openchart.SafeFileName.Contains(".mid"))
                    {
                        Console.WriteLine("Detected chart file.");
                        currentchart = openchart.FileName;
                    }
                    else
                    {
                        Console.WriteLine("Detected midi file.");
                        Process.Start("mid2chart.exe", "-e " + openchart.FileName);
                        currentchart = openchart.FileName.Replace(openchart.SafeFileName, "") + openchart.SafeFileName.Replace(".chart", " (editable) .chart");
                    }
                    chart = File.ReadAllText(currentchart).Replace("}", "").Replace("{", "");
                    File.WriteAllText("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart", chart);
                    //IniFile chartini = new IniFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart");
                    var chartini = new FileIniDataParser();
                    IniData data = chartini.ReadFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart");
                    Console.WriteLine("Generating QB template.");
                    File.Delete("C:\\Windows\\fastgh3\\DATA\\SONGS\\song.qb");
                    File.Copy("C:\\Windows\\fastgh3\\DATA\\SONGS\\.qb", "C:\\Windows\\fastgh3\\DATA\\SONGS\\song.qb", true);
                    File.SetAttributes("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb", FileAttributes.Normal);
                    Console.WriteLine("Opening song pak.");
                    disallowGameStartup();
                    PakFormat pakformat = new PakFormat("C:\\Windows\\FastGH3\\DATA\\SONGS\\test_song.pak.xen", "", "", PakFormatType.PC);
                    PakEditor buildsong = new PakEditor(pakformat);
                    buildsong.RequiresPab.Equals(false);
                    Console.WriteLine("Compiling chart.");
                    QbFile songdata = new QbFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb", pakformat);
                    QbItemBase array_easy = new QbItemArray(songdata);
                    array_easy.Create(QbItemType.SectionArray);
                    QbItemInteger notes_easy = new QbItemInteger(songdata);
                    notes_easy.Create(QbItemType.ArrayInteger);
                    notes_easy.Values[0] = 1;
                    /*QbItemArray testinteger = new QbItemArray(songdata);
                    testinteger.Create(QbItemType.StructItemInteger);
                    testinteger.QbItemValue.Equals(1);
                    notes_easy.AddItem(testinteger);//*/
                    songdata.AddItem(array_easy);
                    array_easy.AddItem(notes_easy);
                    songdata.AlignPointers();
                    songdata.Write("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb");
                    Console.WriteLine("Compiling pak.");
                    buildsong.ReplaceFile("6BE19E2F", "C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb");
                    Console.WriteLine("Encoding song.");
                    disallowGameStartup();
                    Process mp3 = new Process();
                    mp3.StartInfo.FileName = "lame.exe";
                    mp3.StartInfo.Arguments = "-b128 -s 44100 \"" + openchart.FileName.Replace(openchart.SafeFileName, "") + data["Song"]["MusicStream"].Replace("\"", "") + "\" \"C:\\Windows\\FastGH3\\DATA\\MUSIC\\.mp3\"";
                    mp3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mp3.Start();
                    mp3.WaitForExit();
                    disallowGameStartup();
                    try
                    {
                        File.Move("C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen", "C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen.bak");
                    }
                    catch
                    {

                    }
                    Process fsb = new Process();
                    fsb.StartInfo.FileName = "fsbext.exe";
                    fsb.StartInfo.Arguments = "-s C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen -d audio C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.fsb.xen";
                    //fsb.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //fsb.Start();
                    //fsb.WaitForExit();
                    //File.Copy("C:\\Windows\\FastGH3\\DATA\\MUSIC\\.mp3", "C:\\Windows\\FastGH3\\DATA\\MUSIC\\audio\\.mp3");
                    disallowGameStartup();
                    Console.WriteLine("Speeding up.");
                    Console.ReadKey();
                    Process gh3 = new Process();
                    gh3.PriorityClass = ProcessPriorityClass.RealTime;
                    gh3.StartInfo.FileName = "C:\\Windows\\FastGH3\\gh3.exe";
                    gh3.StartInfo.WorkingDirectory = "C:\\Windows\\FastGH3\\";
                    /*gh3.Start();
                    //*/

                }
            }
            //try
            //{
                if (parameters.Length >= 0)
                {
                    if (parameters[1] == "-startupmsg" && args[2] == "off")
                    {
                        File.WriteAllText(@"C:\Windows\fastgh3\CONFIGS\startupmsg", "off");
                    }
                    if (parameters[1] == "-startupmsg" && args[2] == "on")
                    {
                        File.WriteAllText(@"C:\Windows\fastgh3\CONFIGS\startupmsg", "on");
                    }
                    if (parameters[1] == "-settings")
                    {
                        Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
                        //Application.Run(new settings());
                        settings options = new settings();
                        options.ShowDialog();
                    }
                    if (File.Exists(parameters[1]))
                    {
                    Console.WriteLine("FASTGH3 by donnaken15");
                    Console.WriteLine("Checking file extension...");
                    if (Path.GetFileName(parameters[1]).Contains(".chart") && !Path.GetFileName(parameters[1]).Contains(".mid"))
                    {
                        Console.WriteLine("Detected chart file.");
                        currentchart = parameters[1];
                    }
                    else
                    {
                        Console.WriteLine("Detected midi file.");
                        Process.Start("mid2chart.exe", "-e " + parameters[1]);
                        currentchart = parameters[1].Replace(Path.GetFileName(parameters[1]), "") + Path.GetFileName(parameters[1]).Replace(".chart", " (editable) .chart");
                    }
                    chart = File.ReadAllText(currentchart).Replace("}", "").Replace("{", "");
                    File.WriteAllText("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart", chart);
                    Process.Start("C:\\Windows\\FastGH3\\sed.exe", "sed - i '/ = S /d' C:\\Windows\\fastgh3\\DATA\\SONGS\\song.chart");
                    Process.Start("C:\\Windows\\FastGH3\\sed.exe", "sed - i '/ = TS /d' C:\\Windows\\fastgh3\\DATA\\SONGS\\song.chart");
                    //IConfigSource chartini = new IniConfigSource("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart");
                    //IConfig notes_easy_array_ini = chartini.Configs["EasySingle"];
                    //IniFile chartini = new IniFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart");
                    try
                    {
                        chartini = new FileIniDataParser();
                        data = chartini.ReadFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.chart");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    Console.WriteLine("Generating QB template.");
                    File.Delete("C:\\Windows\\fastgh3\\DATA\\SONGS\\song.qb");
                    File.Copy("C:\\Windows\\fastgh3\\DATA\\SONGS\\.qb", "C:\\Windows\\fastgh3\\DATA\\SONGS\\song.qb", true);
                    File.SetAttributes("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb", FileAttributes.Normal);
                    Console.WriteLine("Opening song pak.");
                    disallowGameStartup();
                    PakFormat pakformat = new PakFormat("C:\\Windows\\FastGH3\\DATA\\SONGS\\test_song.pak.xen", "", "", PakFormatType.PC);
                    PakEditor buildsong = new PakEditor(pakformat);
                    buildsong.RequiresPab.Equals(false);
                    Console.WriteLine("Compiling chart.");
                    QbFile songdata = new QbFile("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb", pakformat);
                    QbItemBase array_easy = new QbItemArray(songdata);
                    array_easy.Create(QbItemType.SectionArray);
                    QbItemInteger notes_easy = new QbItemInteger(songdata);
                    //chartini.Configs["EasySingle"].Remove(Array.FindAll(chartini.Configs["EasySingle"].GetValues(), "S");
                    //notes_easy_total = chartini.Configs["EasySingle"].GetKeys();
                    foreach(KeyData key in data["EasySingle"])
                    {
                        maxarraysize += 3;
                    }
                    Console.WriteLine(maxarraysize);
                    Console.ReadKey();
                    File.WriteAllText("C:\\Windows\\FastGH3\\DATA\\SONGS\\maxarraysize",maxarraysize.ToString());
                    Process.Start("","");
                    notes_easy.Create(QbItemType.ArrayInteger);
                    notes_easy.Values[0] = 1;
                    /*if (notes_easy_total < 6137446)
                    { File.WriteAllText("C:\\Windows\\FastGH3\\PLUGINS\\CODE\\notelimit\\notelimitfix.cpp", "#include \"noteLimitFix.h\"\n#include \"core\\Patcher.h\"\n#include <stdint.h>\n\nconst uint32_t MAX_NOTES " + notes_easy_total.ToString("X") + ";//5DA666\nconst uint32_t GH3_MAX_PLAYERS = 2;\nvoid* const SIZEOP_NOTE_ALLOCATION = (void*)0x0041AA78;\nvoid* const ADDROP_SUSTAINARRAY_1 = (void*)0x0041EE33;\nvoid * const ADDROP_SUSTAINARRAY_2 = (void*)0x00423CD4;\nvoid * const ADDROP_SUSTAINARRAY_3 = (void*)0x00423D02;\nvoid * const ADDROP_FCARRAY = (void*)0x00423D14;\nvoid * const ADDROP_NOTEOFFSETARRAY = (void*)0x00423D22;\n\n\nstatic float* fixedSustainArray = nullptr;\nstatic float* fixedFcArray = nullptr;\nstatic uint32_t* fixedOffsetArray = nullptr;\n\n\nstatic GH3P::Patcher g_patcher = GH3P::Patcher(__FILE__);\n\n\nvoid FixNoteLimit()\n{\nif(fixedSustainArray == nullptr)\nfixedSustainArray = new float[MAX_NOTES * GH3_MAX_PLAYERS];\n\n\nif(fixedFcArray == nullptr)\nfixedFcArray = new float[MAX_NOTES * GH3_MAX_PLAYERS];\n\nif(fixedOffsetArray == nullptr)\nfixedOffsetArray = new uint32_t[MAX_NOTES * GH3_MAX_PLAYERS];\n\n\ng_patcher.WriteInt32(SIZEOP_NOTE_ALLOCATION, MAX_NOTES);\n\ng_patcher.WriteInt32(ADDROP_SUSTAINARRAY_1, reinterpret_cast<uint32_t>(fixedSustainArray));\ng_patcher.WriteInt32(ADDROP_SUSTAINARRAY_2, reinterpret_cast<uint32_t>(fixedSustainArray));\ng_patcher.WriteInt32(ADDROP_SUSTAINARRAY_3, reinterpret_cast<uint32_t>(fixedSustainArray));\ng_patcher.WriteInt32(ADDROP_FCARRAY, reinterpret_cast<uint32_t>(fixedFcArray));\ng_patcher.WriteInt32(ADDROP_NOTEOFFSETARRAY, reinterpret_cast<uint32_t>(fixedOffsetArray));\n}\n\n"); }
                    else
                    {
                        Console.Clear();
                        Console.WindowWidth = 57;
                        Console.WindowHeight = 8;
                        Console.BufferWidth = 57;
                        Console.BufferHeight = 8;
                        Console.WriteLine(@"
 # # # YOU HAVE REACHED THE ACTUAL LIMIT OF NOTES # # # 

 6 MILLION IS THE REAL LIMIT (about)! IF THE NOTE LIMIT
 DLL IS REBUILT WITH ALLOWING OVER ABOUT 6 MILLION NOTES
 , THE GAME WILL NOT BE RESPONSIVE AND MORE THAN A
 GIGABYTE OF RAM WILL BE CONSUMED OF YOUR MEMORY!"); Console.ReadKey();
                    }

                    foreach (string key in chartini.Configs["EasySingle"].GetValues()) 
                    {
                        if (key.Contains("N"))
                        {
                            for (int notepos = 0; notepos < chartini.Configs["EasySingle"].GetKeys().Length; notepos += 3)
                            {
                                notes_easy.Values[notepos] = Convert.ToUInt32(chartini.Configs["EasySingle"].GetKeys()[notepos/3]);
                                notes_easy.Values[notepos + 1] = Convert.ToUInt32(chartini.Configs["EasySingle"].GetValues()[notepos / 3].Contains("N").ToString().Substring(2, 3).Replace("4","16").Replace("3","8").Replace("2","4").Replace("1","2").Replace("0","1"));
                                notes_easy.Values[notepos + 2] = Convert.ToUInt32(chartini.Configs["EasySingle"].GetValues()[notepos / 3].Contains("N").ToString().Substring(4));
                            }
                        }
                    }*/
                    songdata.AddItem(array_easy);
                    array_easy.AddItem(notes_easy);
                    songdata.AlignPointers();
                    songdata.Write("C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb");
                    Console.WriteLine("Compiling pak.");
                    buildsong.ReplaceFile("6BE19E2F", "C:\\Windows\\FastGH3\\DATA\\SONGS\\song.qb");
                    Console.WriteLine("Encoding song.");
                    disallowGameStartup();
                    Process mp3 = new Process();
                    mp3.StartInfo.FileName = "lame.exe";
                    mp3.StartInfo.Arguments = "-b128 -s 44100 \"" + parameters[1].Replace(Path.GetFileName(parameters[1]), "") + data["Song"]["MusicStream"].Replace("\"", "") + "\" \"C:\\Windows\\FastGH3\\DATA\\MUSIC\\.mp3\"";
                    mp3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mp3.Start();
                    mp3.WaitForExit();
                    disallowGameStartup();
                    try
                    {
                        File.Move("C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen", "C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen.bak");
                    }
                    catch
                    {

                    }
                    Process fsb = new Process();
                    fsb.StartInfo.FileName = "fsbext.exe";
                    fsb.StartInfo.Arguments = "-s C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.dat.xen -d audio C:\\Windows\\FastGH3\\DATA\\MUSIC\\song.fsb.xen";
                    //fsb.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //fsb.Start();
                    //fsb.WaitForExit();
                    //File.Copy("C:\\Windows\\FastGH3\\DATA\\MUSIC\\.mp3", "C:\\Windows\\FastGH3\\DATA\\MUSIC\\audio\\.mp3");
                    disallowGameStartup();
                    Console.WriteLine("Speeding up.");
                    Process dxwnd = new Process();
                    dxwnd.StartInfo.FileName = "C:\\Windows\\FastGH3\\WINDOWED\\dxwnd.exe";
                    dxwnd.StartInfo.WorkingDirectory = "C:\\Windows\\FastGH3\\WINDOWED\\";
                    dxwnd.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    /*dxwnd.Start();
                    Process.Start("C:\\Windows\\FastGH3\\gh3.exe");
                    //*/
                }
            }
            
            GC.Collect();
        }
    }
}