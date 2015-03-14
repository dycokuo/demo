using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DX80_Monitor
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher m_Watcher;
        private Setting m_setting { get; set; }
        private string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Setting.xml");


        public Form1()
        {
            InitializeComponent();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyErrHandler);
            cbPrintName.DisplayMember = "DisplayText";
            cbPrintName.ValueMember = "Value";

          

            initForm();
            //Get Xml Setting
            XDocument xdoc = XDocument.Load(xmlPath);
            var _setting = xdoc.Descendants("Setting").FirstOrDefault();
            if (_setting != null)
            {
                Setting _newSetting = new Setting();
                _newSetting.WatchPath = _setting.Element("WatchPath").Value;
                _newSetting.BackupPath = _setting.Element("BackupPath").Value;
                //_newSetting.DX80IP = _setting.Element("DX80IP").Value;
                //_newSetting.DX80PORT = _setting.Element("DX80PORT").Value;
                _newSetting.PrintName = _setting.Element("PrintName").Value;
                txtWatchPath.Text = _newSetting.WatchPath;
                txtBackupPath.Text = _newSetting.BackupPath;
                //txtDX80IP.Text = _newSetting.DX80IP;
                //txtDX80PORT.Text = _newSetting.DX80PORT;

                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    var _newItem = new ComboItem(printer, printer);                 
                    cbPrintName.Items.Add(_newItem);
                    if (printer == _newSetting.PrintName)
                        cbPrintName.SelectedItem = _newItem;
                }                

                m_setting = _newSetting;
                if (!string.IsNullOrEmpty(txtWatchPath.Text) && !string.IsNullOrEmpty(txtBackupPath.Text)
                    && cbPrintName.SelectedItem!=null)
                        Run();
            }

            rtMessage.Focus();
           
        }

      

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.notifyIcon1.Visible = false;
            }
        }

        protected void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            //讓Form再度顯示，並寫狀態設為Normal
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void initForm()
        {
            var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            ChkAutoRun.Checked = key.GetValueNames().Any(x => x == "DX80") ? true : false;       
            txtDX80PORT.KeyPress += txtDX80PORT_KeyPress;
        }

        private void txtDX80PORT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            DialogResult resDialog = dlgOpenDir.ShowDialog();
            if (resDialog.ToString() == "OK")
            {
                switch (((Button)sender).Name)
                {
                    case "btnWatchBrowse":
                        txtWatchPath.Text = dlgOpenDir.SelectedPath; break;
                    case "btnBackupBrowse":
                        txtBackupPath.Text = dlgOpenDir.SelectedPath; break;
                }

            }
        }

        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                DialogResult result = MessageBox.Show(path + "Not Found!Will Create It?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Directory.CreateDirectory(path);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string WatchPath = txtWatchPath.Text.Trim();
            string BackupPath = txtBackupPath.Text.Trim();
            //string DX80IP = txtDX80IP.Text.Trim().Replace(" ", "");
            //string DX80PORT = txtDX80PORT.Text.Trim();

            var selected = cbPrintName.SelectedItem as ComboItem;
            string PrintName = "";
            if (selected != null)
                PrintName = selected.Value;

            if (WatchPath == "") { MessageBox.Show("WatchPath is Required"); txtWatchPath.Focus(); return; }
            if (BackupPath == "") { MessageBox.Show("BackupPath is Required"); txtBackupPath.Focus(); return; }
            //if (DX80IP == "") { MessageBox.Show("DX80IP is Required"); txtDX80IP.Focus(); return; }
            //if (DX80PORT == "") { MessageBox.Show("DX80PORT is Required"); txtDX80PORT.Focus(); return; }
            if (PrintName == "") { MessageBox.Show("PrintName is Required"); cbPrintName.Focus(); return; }
            //IPAddress ipAddress;
            //if (!IPAddress.TryParse(DX80IP, out ipAddress)) { { MessageBox.Show("IPAddress Is Wrong"); txtDX80IP.Focus(); return; } }

            //if Folder not Exists ,Create It
            if (WatchPath != "") { CreateIfMissing(WatchPath); }
            if (BackupPath != "") { CreateIfMissing(BackupPath); }

            if (m_Watcher != null) { LogTextEvent(rtMessage, Color.Red, "Stop Watch..."); m_Watcher.Dispose(); }

            XDocument xdoc = XDocument.Load(xmlPath);
            var _setting = xdoc.Descendants("Setting").FirstOrDefault();
            if (_setting != null)
            {
                _setting.Element("WatchPath").Value = WatchPath;
                _setting.Element("BackupPath").Value = BackupPath;
                //_setting.Element("DX80IP").Value = DX80IP;
                //_setting.Element("DX80PORT").Value = DX80PORT;
                _setting.Element("PrintName").Value = PrintName;
                m_setting.WatchPath = WatchPath;
                m_setting.BackupPath = BackupPath;
                m_setting.PrintName = PrintName;
                xdoc.Save(xmlPath);
            }
            Run();
        }


        private void Run()
        {

            LogTextEvent(rtMessage, Color.Blue, "Start Watch...");
            m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Filter = "*.*";
            m_Watcher.Path = m_setting.WatchPath + "\\";
            m_Watcher.IncludeSubdirectories = false;
            m_Watcher.Created += m_Watcher_Created;
            m_Watcher.EnableRaisingEvents = true;

        }

        void m_Watcher_Created(object sender, FileSystemEventArgs e)
        {
                // get the file's extension 
                string f = Path.GetExtension(e.FullPath);                
                // filter file types 
                if (Regex.IsMatch(f, @"(\.jpg|\.gif|\.bmp|\.png)", RegexOptions.IgnoreCase))
                {
                    LogTextEvent(rtMessage, Color.Green, e.FullPath + "  Created");
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        notifyIcon1.BalloonTipTitle = "Notify";
                        notifyIcon1.BalloonTipText = e.FullPath + "  Created";
                        notifyIcon1.ShowBalloonTip(500);
                    }

                    //print
                    doPrint(e.FullPath);
                    
                }           
        }

        private void doPrint(string FilePath)
        {          
            
            if (!string.IsNullOrEmpty(m_setting.PrintName))
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = m_setting.PrintName;


                pd.PrintPage += (sender, args) =>
                {

                    Image i = Image.FromStream(new MemoryStream(File.ReadAllBytes(FilePath)));
                    //args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    //args.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                    //args.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;                
                    args.Graphics.DrawImage(i, 1, 1, 345, 220);
                };
                if (pd.PrinterSettings.IsValid)
                {
                    //PrintDialog pdi = new PrintDialog();
                    //PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                    //printPrvDlg.Document = pd;
                    //printPrvDlg.ShowDialog();
                    //pdi.Document = pd;
                    //if (pdi.ShowDialog() == DialogResult.OK)
                    //{
                    pd.Print();
                    LogTextEvent(rtMessage, Color.RoyalBlue, "Printed...");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Print Cancelled");

                    //}
                }
                else
                    LogTextEvent(rtMessage, Color.Red, "Printer is Not Ready");
            }
            else
                LogTextEvent(rtMessage, Color.Red, "Printer is Required");

            WaitForFileToMove(FilePath);
        }

        private void WaitForFileToMove(string FilePath)
        {
            FileInfo f = null;
            bool FileReady = false;
            int CheckCount = 1;

            while (!FileReady && CheckCount<=60)
            {
                try
                {
                    f = new FileInfo(FilePath);                   
                    var _guid = Guid.NewGuid();
                    File.Move(f.FullName, m_setting.BackupPath + "\\" + _guid + f.Extension);
                    LogTextEvent(rtMessage, Color.Orange, "Move " + f.FullName + "=>" + m_setting.BackupPath + "\\" + _guid + f.Extension);
                    FileReady = true;
                }
                catch (Exception ex)
                {
                    //Debug.Write(ex.Message);
                    //File isn't ready yet, so we need to keep on waiting until it is.
                }
                //We'll want to wait a bit between polls, if the file isn't ready.
                CheckCount++;
                if (!FileReady) Thread.Sleep(1000);
            }
        }

        private void ChkAutoRun_Click(object sender, EventArgs e)
        {
            if (ChkAutoRun.Checked)
            {
                RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                add.SetValue("DX80", "\"" + Application.ExecutablePath.ToString() + "\"");
            }
            else
            {
                RegistryKey del = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);               
                del.DeleteValue("DX80", false);
            }
        }


        /// <summary>
        /// EventLog
        /// </summary>
        /// <param name="TextEventLog"></param>
        /// <param name="TextColor"></param>
        /// <param name="EventText"></param>
        public void LogTextEvent(RichTextBox TextEventLog, Color TextColor, string EventText)
        {
            if (TextEventLog.InvokeRequired)
            {
                TextEventLog.BeginInvoke(new Action(delegate
                {
                    LogTextEvent(TextEventLog, TextColor, EventText);
                }));
                return;
            }

            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

            // color text.
            TextEventLog.SelectionStart = TextEventLog.Text.Length;
            TextEventLog.SelectionColor = TextColor;

            // newline if first line, append if else.
            if (TextEventLog.Lines.Length == 0)
            {
                TextEventLog.AppendText(nDateTime + EventText);
                TextEventLog.ScrollToCaret();
                TextEventLog.AppendText(System.Environment.NewLine);
            }
            else
            {
                TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                TextEventLog.ScrollToCaret();
            }
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_Watcher != null)
                m_Watcher.Dispose();
        }

        /// <summary>
        /// ErrHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MyErrHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            EventLog eLog = new EventLog("Application");
            eLog.Source = "DX80";
            eLog.WriteEntry(e.Message, EventLogEntryType.Error);
            eLog.WriteEntry(xmlPath, EventLogEntryType.Error);
        }

        private void toolStrip_View_Click(object sender, EventArgs e)
        {
            //讓Form再度顯示，並寫狀態設為Normal
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStrip_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }



    public class Setting
    {
        public string WatchPath { get; set; }
        public string BackupPath { get; set; }
        public string DX80IP { get; set; }
        public string DX80PORT { get; set; }
        public string PrintName { get; set; }
    }

     public class ComboItem
  {

      private string _displayText;
      private string _value;
      public ComboItem(string text, string value)
      {

          this._displayText = text;
          this._value = value;
      }



      public string DisplayText
      {
          get { return _displayText; }
      }



      public string Value
      {
          get { return _value; }
      }

  }


}
