using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PulsarUI.Forms;
using System.Diagnostics;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Net;


namespace UFConsole
{
    public partial class Form1 : PulsarUIModernFormV2
    {
        #region Var
        string github = "https://github.com/lulv3z";
        string githubProject = "https://github.com/lulv3z/UFConsole-Public";

        private static bool isSafeMode = Data.Settings.Default.isSafeMode;

        string currentDir = Directory.GetCurrentDirectory();
        bool sidebarExpand = false;
        Color currentForeColor;
        string currentPath = AppDomain.CurrentDomain.BaseDirectory;

        bool isLivePreview = false;

        private List<string> commandHistory = new List<string>();
        private int commandHistoryIndex = -1;
        #endregion Var

        Color ConsoleBackgroundColor = Data.Settings.Default.ConsoleBackgroundColor;
        Color ConsoleTextColor = Data.Settings.Default.ConsoleTextColor;
        Color InputTextColor = Data.Settings.Default.InputTextColor;
        Color InputBackgroundColor = Data.Settings.Default.InputBackgroundColor;
        Color SidebarBackgroundColor = Data.Settings.Default.SidebarBackgroundColor;
        Color SidebarTextColor = Data.Settings.Default.SidebarTextColor;
        Color TopBarBackgroundColor = Data.Settings.Default.TopBarBackgroundColor;
        Color TopBarTextColor = Data.Settings.Default.TopBarTextColor;

        #region Form
        public Form1()
        {
            InitializeComponent();
            this.isSizable = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentForeColor = Color.LightGray;
            if (sidebarExpand)
            {
                app_sidebar.Width = 300;
            }
            else
            {
                app_sidebar.Width = 0;
            }
            PrintStartupText();
            SetColorTheme();
            this.Shown += Form1_Shown; // Eventhandler für das Form.Shown Ereignis
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtUserInput.Focus();
            
        }
        #endregion form

        private void PrintStartupText()
        {
            AddTextToConsole("------------------------------------------------------------", Color.Magenta);
            AddTextToConsole(" ", Color.Magenta);
            AddTextToConsole("Developer: lulv3z -> " + github, Color.Magenta);
            AddTextToConsole("GitHub Project -> " + githubProject, Color.Magenta);
            AddTextToConsole("UFConsole - V.1.0.4", Color.Magenta);
            AddTextToConsole(" ", Color.Magenta);
            AddTextToConsole("------------------------------------------------------------", Color.Magenta);
        }

        #region Sidebar
        private void btnSettings_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                app_sidebar.Width -= 5;
                if (app_sidebar.Width <= 0)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                app_sidebar.Width += 5;
                if (app_sidebar.Width >= 300)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }
        #endregion Sidebar

        #region txtUserInput_keyDown
        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Wenn die Eingabetaste gedrückt wird, wird der Befehl ausgeführt und zur Befehlshistorie hinzugefügt.
                string userInput = txtUserInput.Text.Trim();
                ProcessCommand(userInput);
                commandHistory.Insert(0, userInput);
                commandHistoryIndex = -1; // Setze den Befehlshistorie-Index zurück.
                txtUserInput.Text = string.Empty; // Lösche den Text in der txtUserInput-Box.
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Wenn die Pfeiltaste nach oben gedrückt wird, wird der vorherige Befehl in txtUserInput eingefügt.
                if (commandHistory.Count > 0 && commandHistoryIndex < commandHistory.Count - 1)
                {
                    commandHistoryIndex++;
                    txtUserInput.Text = commandHistory[commandHistoryIndex];
                    txtUserInput.SelectionStart = txtUserInput.Text.Length; // Setze den Cursor ans Ende des Textes.
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // Wenn die Pfeiltaste nach unten gedrückt wird, wird der nächste Befehl in txtUserInput eingefügt.
                if (commandHistoryIndex >= 0)
                {
                    commandHistoryIndex--;
                    if (commandHistoryIndex >= 0)
                    {
                        txtUserInput.Text = commandHistory[commandHistoryIndex];
                    }
                    else
                    {
                        txtUserInput.Text = string.Empty;
                    }
                    txtUserInput.SelectionStart = txtUserInput.Text.Length; // Setze den Cursor ans Ende des Textes.
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        #endregion txtUserInput_keyDown
        private void UpdatePrompt()
        {
            string currentDir = Directory.GetCurrentDirectory();
            AddTextToConsole("cd " + Directory.GetCurrentDirectory() + " >> ", currentForeColor);
        }

        private void AddTextToConsole(string text, Color color)
        {
            txtConsole.SelectionColor = color;
            txtConsole.AppendText(text + Environment.NewLine);
            txtConsole.ScrollToCaret();
        }

        #region Commands
        private void ProcessCommand(string command)
        {
            string[] parts = command.Split(' ');
            AddTextToConsole(currentDir + " >> " + command, currentForeColor);

            #region color-commands
            if (parts.Length >= 2 && parts[0].ToLower() == "color")
            {
                string colorArgument = parts[1].ToLower();

                if (colorArgument == "a")
                {
                    txtConsole.ForeColor = Color.Green;
                    currentForeColor = Color.Green;
                }
                else if (colorArgument == "b")
                {
                    txtConsole.ForeColor = Color.Blue;
                    currentForeColor = Color.Blue;
                }
                else if (colorArgument == "r")
                {
                    txtConsole.ForeColor = Color.Red;
                    currentForeColor = Color.Red;
                }
                else if (colorArgument == "m")
                {
                    txtConsole.ForeColor = Color.Magenta;
                    currentForeColor = Color.Magenta;
                }
                else if (colorArgument == "y")
                {
                    txtConsole.ForeColor = Color.Yellow;
                    currentForeColor = Color.Yellow;
                }
                else if (colorArgument == "d")
                {
                    txtConsole.ForeColor = Data.Settings.Default.ConsoleTextColor;
                    currentForeColor = Data.Settings.Default.ConsoleTextColor;
                }
                // Weitere Farben oder spezifische Aktionen können hier ergänzt werden.
                else
                    AddTextToConsole("Ungültige Farbe. Unterstützte Farben: a, b, r, m, y, d", Color.Red);
            }
            #endregion color-commands

            #region exit-command
            else if (parts[0].ToLower() == "exit")
            {
                this.Close();
            }
            #endregion exit-command

            #region Net

            #region ping-command
            else if (parts[0].ToLower() == "ping")
            {
                if (parts.Length >= 2)
                {
                    string host = parts[1];

                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo("ping", host);
                        psi.RedirectStandardOutput = true;
                        psi.UseShellExecute = false;
                        Process process = Process.Start(psi);
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        AddTextToConsole(output, Color.White);
                    }
                    catch (Exception ex)
                    {
                        AddTextToConsole($"Fehler beim Ausführen von Ping: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Hostnamen oder die IP-Adresse an, die Sie ping möchten.", Color.Red);
                }
            }
            #endregion ping-command

            #region inconfig-command

            else if (parts[0].ToLower() == "ipconfig")
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo("ipconfig");
                    psi.RedirectStandardOutput = true;
                    psi.UseShellExecute = false;
                    Process process = Process.Start(psi);
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    AddTextToConsole(output, Color.White);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Ausführen von ipconfig: {ex.Message}", Color.Red);
                }
            }

            #endregion ipconfig-command

            #endregion Net

            #region File System

            #region attrib-command

            else if (parts[0].ToLower() == "attrib")
            {
                if (parts.Length >= 2)
                {
                    string filePath = parts[1];
                    if (File.Exists(filePath))
                    {
                        FileAttributes attributes = File.GetAttributes(filePath);
                        AddTextToConsole($"Attribute der Datei '{filePath}': {attributes}", Color.White);
                    }
                    else if (Directory.Exists(filePath))
                    {
                        FileAttributes attributes = File.GetAttributes(filePath);
                        AddTextToConsole($"Attribute des Verzeichnisses '{filePath}': {attributes}", Color.White);
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Die angegebene Datei oder das Verzeichnis existiert nicht.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Pfad der Datei oder des Verzeichnisses an.", Color.Red);
                }
            }

            #endregion attrib-command

            #region start-command

            else if (parts[0].ToLower() == "start")
            {
                if (parts.Length >= 2)
                {
                    string fileName = parts[1];

                    try
                    {
                        Process.Start(fileName);
                    }
                    catch (Exception ex)
                    {
                        AddTextToConsole($"Fehler beim Starten der Anwendung: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Namen der Anwendung oder Datei an, die gestartet werden soll.", Color.Red);
                }
            }

            #endregion start-command

            #region CD-Command
            else if (parts[0].ToLower() == "cd")
            {
                if (parts.Length >= 2)
                {
                    string newPath = string.Join(" ", parts.Skip(1)).Trim(); // Füge alle Teile nach "cd" zusammen und entferne führende/trailing Leerzeichen

                    try
                    {
                        Directory.SetCurrentDirectory(newPath);
                        AddTextToConsole("Aktuelles Verzeichnis geändert zu: " + newPath, Color.Green);
                    }
                    catch (Exception ex)
                    {
                        AddTextToConsole($"Fehler beim Ändern des Verzeichnisses: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Pfad des neuen Verzeichnisses an.", Color.Red);
                }
            }
            #endregion CD-Command

            #region ls-command
            else if (parts[0].ToLower() == "ls")
            {
                string currentDir = Directory.GetCurrentDirectory();
                string[] files = Directory.GetFiles(currentDir);
                string[] directories = Directory.GetDirectories(currentDir);

                AddTextToConsole("Verzeichnis von " + currentDir, Color.White);

                foreach (string dir in directories)
                {
                    AddTextToConsole(Path.GetFileName(dir) + "\t<DIR>", Color.Yellow);
                }

                foreach (string file in files)
                {
                    AddTextToConsole(Path.GetFileName(file), Color.White);
                }
            }
            #endregion ls-command

            #region copy-command
            else if (parts[0].ToLower() == "copy")
            {
                if (!isSafeMode)
                {
                    if (parts.Length >= 3)
                    {
                        string sourceFile = parts[1];
                        string destinationFile = parts[2];

                        try
                        {
                            File.Copy(sourceFile, destinationFile);
                            AddTextToConsole($"Datei {sourceFile} wurde nach {destinationFile} kopiert.", Color.Green);
                        }
                        catch (Exception ex)
                        {
                            AddTextToConsole($"Fehler beim Kopieren der Datei: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Geben Sie den Quell- und Ziel-Pfad der zu kopierenden Datei an.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
            }
            #endregion copy-command

            #region move-command
            else if (parts[0].ToLower() == "move")
            {
                if (!isSafeMode)
                {
                    if (parts.Length >= 3)
                    {
                        string sourceFile = parts[1];
                        string destinationFile = parts[2];

                        try
                        {
                            File.Move(sourceFile, destinationFile);
                            AddTextToConsole($"Datei {sourceFile} wurde nach {destinationFile} verschoben.", Color.Green);
                        }
                        catch (Exception ex)
                        {
                            AddTextToConsole($"Fehler beim Verschieben der Datei: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Geben Sie den Quell- und Ziel-Pfad der zu verschiebenden Datei an.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }
            #endregion move-command

            #region rename-command
            else if (parts[0].ToLower() == "rename")
            {
                if (!isSafeMode)
                {
                    if (parts.Length >= 3)
                    {
                        string oldName = parts[1];
                        string newName = parts[2];

                        try
                        {
                            File.Move(oldName, newName);
                            AddTextToConsole($"Datei/Verzeichnis {oldName} wurde in {newName} umbenannt.", Color.Green);
                        }
                        catch (Exception ex)
                        {
                            AddTextToConsole($"Fehler beim Umbenennen von Datei/Verzeichnis: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Geben Sie den alten und neuen Namen der Datei/des Verzeichnisses an.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }
            #endregion rename-command

            #region type-command
            else if (parts[0].ToLower() == "type")
            {
                if (parts.Length >= 2)
                {
                    string filePath = parts[1];
                    if (File.Exists(filePath))
                    {
                        string content = File.ReadAllText(filePath);
                        AddTextToConsole(content, Color.White);
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Die angegebene Datei existiert nicht.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Pfad der Datei an, die angezeigt werden soll.", Color.Red);
                }
            }
            #endregion type-command

            #region tree-command

            if (parts[0].ToLower() == "tree")
            {
                if (parts.Length >= 2)
                {
                    string path = parts[1];
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);

                    if (directoryInfo.Exists)
                    {
                        AddTextToConsole($"Verzeichnisstruktur von '{path}':", Color.White);
                        PrintDirectoryTree(directoryInfo, 0);
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Das angegebene Verzeichnis existiert nicht.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie den Pfad des Verzeichnisses an, dessen Struktur angezeigt werden soll.", Color.Red);
                }
            }

            #endregion tree-command

            #region deltemp-command
            else if (parts[0].ToLower() == "deltemp")
            {
                if (ConfirmDeleteTemp())
                {
                    DeleteTempFolderContents();
                }
                else
                {
                    AddTextToConsole("delTemp wurde abgebrochen.", Color.Red);
                }
            }
            #endregion deltemp-command

            #region DeleteFolderAndFile-Command
            else if (parts[0].ToLower() == "delfolder")
            {
                if (!isSafeMode)
                {
                    string folderPath = string.Join(" ", parts, 1, parts.Length - 1);
                    folderPath = GetFolderPath();
                    if (string.IsNullOrEmpty(folderPath))
                    {
                        AddTextToConsole("delFolder wurde abgebrochen.", Color.Red);
                        return;
                    }

                    if (ConfirmDeleteFolder(folderPath))
                    {
                        DeleteFolder(folderPath);
                    }
                    else
                    {
                        AddTextToConsole("delFolder wurde abgebrochen.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }
            else if (parts[0].ToLower() == "delfile")
            {
                if (!isSafeMode)
                {
                    string filePath = string.Join(" ", parts, 1, parts.Length - 1);
                    filePath = GetFilePath();
                    if (string.IsNullOrEmpty(filePath))
                    {
                        AddTextToConsole("delFile wurde abgebrochen.", Color.Red);
                        return;
                    }

                    if (ConfirmDeleteFile(filePath))
                    {
                        DeleteFile(filePath);
                    }
                    else
                    {
                        AddTextToConsole("delFile wurde abgebrochen.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }
            #endregion DeleteFolderAndFile-Command

            #region mkdir-command
            else if (parts[0].ToLower() == "mkdir")
            {
                if (!isSafeMode)
                {
                    if (parts.Length >= 2)
                    {
                        string newDir = parts[1];

                        try
                        {
                            Directory.CreateDirectory(newDir);
                            AddTextToConsole($"Das Verzeichnis {newDir} wurde erfolgreich erstellt.", Color.Green);
                        }
                        catch (Exception ex)
                        {
                            AddTextToConsole($"Fehler beim Erstellen des Verzeichnisses: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Geben Sie den Namen des neuen Verzeichnisses an.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }
            #endregion mkdir-command

            #endregion File System

            #region Basic Commands

            #region getMAC-command
            else if (parts[0].ToLower() == "getmac")
            {
                AddTextToConsole("MAC-Adresse der Netzwerkadapter:", Color.White);
                var networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
                foreach (var ni in networkInterfaces)
                {
                    AddTextToConsole($"{ni.Name}: {ni.GetPhysicalAddress()}", Color.White);
                }
            }
            #endregion getMAC-command

            #region hostname-command
            else if (parts[0].ToLower() == "hostname")
            {
                AddTextToConsole($"Computername: {Environment.MachineName}", Color.White);
            }
            #endregion hostname-command

            #region history-command
            else if (parts[0].ToLower() == "history")
            {
                AddTextToConsole("Befehlshistorie:", Color.White);
                int count = 1;
                foreach (string historyCommand in commandHistory)
                {
                    AddTextToConsole($"{count}. {historyCommand}", Color.White);
                    count++;
                }
            }
            #endregion history-command

            #region safeMode-command
            else if (parts[0].ToLower() == "safemode")
            {
                if (parts.Length >= 2)
                {
                    string newSafeMode = parts[1].ToLower();

                    if (newSafeMode == "true" || newSafeMode == "false")
                    {
                        if (ConfirmAction($"Soll der Safe Mode auf '{newSafeMode}' gesetzt werden? (ja/nein)"))
                        {
                            isSafeMode = newSafeMode == "true";
                            Data.Settings.Default.isSafeMode = isSafeMode;
                            Data.Settings.Default.Save();
                            AddTextToConsole($"Safe Mode wurde auf '{newSafeMode}' gesetzt.", Color.Green);
                        }
                        else
                        {
                            AddTextToConsole("Aktion abgebrochen. Safe Mode wurde nicht geändert.", Color.Yellow);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Gültige Werte für Safe Mode sind 'true' oder 'false'.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole("Fehler: Geben Sie 'true' oder 'false' nach dem Befehl ein.", Color.Red);
                }
            }
            #endregion safeMode-command

            #region shutdown-command

            else if (parts[0].ToLower() == "shutdown")
            {
                if (!isSafeMode)
                {
                    try
                    {
                        Process.Start("shutdown", "/s"); // /s zum Herunterfahren, /t 0 für sofortiges Herunterfahren
                    }
                    catch (Exception ex)
                    {
                        AddTextToConsole($"Fehler beim Herunterfahren des Computers: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
            }

            #endregion shutdown-command

            #region print-command
            else if (parts[0].ToLower() == "print")
            {
                string textToPrint = string.Join(" ", parts, 1, parts.Length - 1);
                AddTextToConsole(textToPrint, currentForeColor);
            }
            #endregion print-command

            #region Title-command
            else if (parts[0].ToLower() == "title")
            {
                string textToPrint = string.Join(" ", parts, 1, parts.Length - 1);
                app_title.Text = textToPrint;
                this.Text = textToPrint;
            }
            #endregion Title-command

            #region date&time-command
            else if (parts[0].ToLower() == "date")
            {
                try
                {
                    DateTime currentDate = DateTime.Now;
                    AddTextToConsole("Aktuelles Datum: " + currentDate.ToString("yyyy-MM-dd"), Color.White);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Abrufen des Datums: {ex.Message}", Color.Red);
                }
            }
            else if (parts[0].ToLower() == "time")
            {
                try
                {
                    DateTime currentTime = DateTime.Now;
                    AddTextToConsole("Aktuelle Uhrzeit: " + currentTime.ToString("HH:mm:ss"), Color.White);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Abrufen der Uhrzeit: {ex.Message}", Color.Red);
                }
            }
            #endregion date&time-command

            #region tasklist&taskkill-command
            // Tasklist
            else if (parts[0].ToLower() == "tasklist")
            {
                if (!isSafeMode)
                {
                    AddTextToConsole(" ", currentForeColor);
                    try
                    {
                        string searchKeyword = parts.Length >= 2 ? parts[1].ToLower() : null;

                        Process[] processes = Process.GetProcesses();
                        AddTextToConsole("Laufende Prozesse:", Color.White);
                        AddTextToConsole("--------------------", currentForeColor);

                        foreach (Process process in processes.Where(p => searchKeyword == null || p.ProcessName.ToLower().Contains(searchKeyword)))
                        {
                            AddTextToConsole($"[{process.Id}] {process.ProcessName}", Color.White);
                        }
                    }
                    catch (Exception ex)
                    {
                        AddTextToConsole($"Fehler beim Abrufen der Prozessliste: {ex.Message}", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
            }
            // Taskkill
            else if (parts[0].ToLower() == "taskkill")
            {
                if (!isSafeMode)
                {
                    if (parts.Length >= 2)
                    {
                        string target = parts[1].ToLower();

                        try
                        {
                            Process[] processes = Process.GetProcesses();
                            bool found = false;

                            foreach (Process process in processes)
                            {
                                if (process.Id.ToString() == target || process.ProcessName.ToLower() == target)
                                {
                                    process.Kill();
                                    AddTextToConsole($"Prozess [{process.Id}] ({process.ProcessName}) wurde beendet.", Color.Green);
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                AddTextToConsole($"Kein Prozess mit der PID oder dem Namen '{target}' gefunden.", Color.Red);
                            }
                        }
                        catch (Exception ex)
                        {
                            AddTextToConsole($"Fehler beim Beenden des Prozesses: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AddTextToConsole("Fehler: Geben Sie die PID oder den Namen des Prozesses an, den Sie beenden möchten.", Color.Red);
                    }
                }
                else
                {
                    AddTextToConsole($"Diese Aktion ist nicht Möglich da der SafeMode Aktiv ist!", Color.Red);
                }
                
            }

            #endregion tasklist&taskkill-command

            #region systeminfo-command
            else if (parts[0].ToLower() == "systeminfo")
            {
                AddTextToConsole(" ", currentForeColor);
                try
                {
                    string osVersion = Environment.OSVersion.ToString();
                    string machineName = Environment.MachineName;
                    string userName = Environment.UserName;
                    string systemDirectory = Environment.SystemDirectory;

                    AddTextToConsole("Systeminformationen:", Color.White);
                    AddTextToConsole($"Betriebssystemversion: {osVersion}", Color.White);
                    AddTextToConsole($"Computername: {machineName}", Color.White);
                    AddTextToConsole($"Benutzername: {userName}", Color.White);
                    AddTextToConsole($"Systemverzeichnis: {systemDirectory}", Color.White);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Abrufen der Systeminformationen: {ex.Message}", Color.Red);
                }
            }
            #endregion systeminfo-command

            #region help-command
            else if (parts[0].ToLower() == "help")
            {
                AddTextToConsole(" ", currentForeColor);
                AddTextToConsole("Basic:", currentForeColor);
                AddTextToConsole("--------------------------------------------", currentForeColor);

                AddTextToConsole("color [a/r/b/m/y/d] - Setzt die Schrift farbe | Beispiel: color a  = Schriftfarbe Grün", currentForeColor);
                AddTextToConsole("print [Text] - Schreibt etwas in die Console | Beispiel: print Hello World  = Hello World", currentForeColor);
                AddTextToConsole("title [Text] - Setzt den Consolen Title | Beispiel: title ConsoleTitle", currentForeColor);
                AddTextToConsole("clear - Leert die Console", currentForeColor);
                AddTextToConsole("exit - Beendet die Console", currentForeColor);
                AddTextToConsole("date - Zeigt das Datum an", currentForeColor);
                AddTextToConsole("time - Zeigt die Uhrzeit an", currentForeColor);
                AddTextToConsole("shutdown - Fährt den PC herunter", currentForeColor);
                AddTextToConsole("history - Der Befehl history wird normalerweise verwendet, um die Befehlshistorie anzuzeigen, also eine Liste der zuvor ausgeführten Befehle in der Konsolenumgebung", currentForeColor);
                AddTextToConsole("hostname - Der Befehl hostname wird verwendet, um den Namen des Computers oder Hostnamens auf einem Computer anzuzeigen", currentForeColor);
                AddTextToConsole("getmac - Der Befehl getmac wird verwendet, um die MAC-Adressen (Media Access Control) der Netzwerkadapter auf einem Computer anzuzeigen", currentForeColor);
                AddTextToConsole("systeminfo - Zeigt deine System Informationen an", currentForeColor);
                AddTextToConsole("safemode <true/false> - Schaltet den SafeMode An/Aus", currentForeColor);

                AddTextToConsole(" ", currentForeColor);
                AddTextToConsole("Net:", currentForeColor);
                AddTextToConsole("--------------------------------------------", currentForeColor); // 

                AddTextToConsole("ping <Hostname oder IP-Adresse> -  Erreichbarkeit eines Hosts oder einer IP-Adresse im Netzwerk zu testen", currentForeColor);
                AddTextToConsole("ipconfig - IP-Konfiguration und Netzwerkinformationen des aktuellen Computers anzuzeigen", currentForeColor);

                AddTextToConsole(" ", currentForeColor);
                AddTextToConsole("File System:", currentForeColor);
                AddTextToConsole("--------------------------------------------", currentForeColor);

                AddTextToConsole("ls -  listet alle dateien im aktuellen verzeichnis auf", currentForeColor);
                AddTextToConsole("cd <Path> -  ändert das verzeichnis", currentForeColor);
                AddTextToConsole("mkdir -  Erstellt ein Ordner", currentForeColor);
                AddTextToConsole("type <Dateipfad> -  Der Befehl type wird verwendet, um den Inhalt einer Textdatei in der Konsole anzuzeigen", currentForeColor);
                AddTextToConsole($@"attrib [+/-]<Attribut>[Datei/Verzeichnis] | Beispiel: attrib +R C:\MeineDatei.txt -  Der Befehl attrib wird verwendet, um die Attribute einer Datei oder eines Verzeichnisses auf dem Dateisystem anzuzeigen oder zu ändern", currentForeColor);
                AddTextToConsole("tasklist -  Zeigt eine liste aller Programme", currentForeColor);
                AddTextToConsole("taskkill [PID or ProcessName]-  Beendet ein programm", currentForeColor);
                AddTextToConsole("tree <PATH> -  Mit dem Befehl können Sie die Verzeichnisstruktur von einem angegebenen Pfad in Baumansicht anzeigen", currentForeColor);
                AddTextToConsole("deltemp -  bestätigen sie mit `ja` um den inhalt vom Temp Ordner zu löschen", currentForeColor);
                AddTextToConsole("delfolder -  öffnet ein fenster um ein ordner auszuwählen, bestätigen sie mit `Ja` um den ordner zu löschen", currentForeColor);
                AddTextToConsole("delfile -  öffnet ein fenster um eine Datei auszuwählen, bestätigen sie mit `Ja` um die Datei zu löschen", currentForeColor);
                AddTextToConsole("move <Quellpfad> <Zielpfad> -  Verschiebt eine Datei oder ein Verzeichnis", currentForeColor);
                AddTextToConsole("copy <Quellpfad> <Zielpfad> -  ermöglicht das Kopieren einer Datei von einem Quellpfad zu einem Ziel-Pfad auf dem Dateisystem, ohne das Original zu entfernen. ", currentForeColor);
                AddTextToConsole("rename <AlterName> <NeuerName> -  ermöglicht das Umbenennen von Dateien oder Verzeichnissen auf dem Dateisystem", currentForeColor);
                AddTextToConsole(" ", currentForeColor);
            }
            #endregion print-command

            #region clear-command
            else if (parts[0].ToLower() == "clear")
            {
                txtConsole.Text = "";
            }
            #endregion clear-command

            #endregion Basic Commands
            // Weitere Befehle können hier ergänzt werden.
            else
            {
                AddTextToConsole("Unbekannter Befehl. Geben Sie 'help' ein, um die unterstützten Befehle anzuzeigen.", Color.Red);
            }
        }

        #endregion Commands
        private void ProcessCommands(List<string> commands)
        {
            foreach (string command in commands)
            {
                ProcessCommand(command);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1 && Path.GetExtension(files[0]).ToLower() == ".ufconsole")
            {
                List<string> commands = ReadCommandsFromFile(files[0]);
                ProcessCommands(commands);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).ToLower() == ".ufconsole")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private List<string> ReadCommandsFromFile(string filePath)
        {
            List<string> commands = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                commands.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Lesen der Datei: " + ex.Message);
            }
            return commands;
        }

        private void DeleteFolder(string folderPath)
        {
            try
            {
                // Überprüfen, ob der Ordner existiert, um ungewollte Löschungen zu vermeiden
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                    AddTextToConsole($"Ordner: {folderPath} und seine Inhalte wurden gelöscht.", Color.Green);
                }
                else
                {
                    AddTextToConsole($"Der angegebene Ordner {folderPath} existiert nicht.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                AddTextToConsole($"Fehler beim Löschen des Ordners: {ex.Message}", Color.Red);
            }

            AddTextToConsole(" ", currentForeColor);
            AddTextToConsole("--------------------", currentForeColor);
            AddTextToConsole("Löschen abgeschlossen!", Color.Green);
        }
        private bool ConfirmDeleteFolder(string folderPath)
        {
            string message = $"Sind Sie sicher, dass Sie den Ordner {folderPath} und alle seine Inhalte löschen möchten?";
            string caption = "Bestätigung erforderlich";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private string GetFolderPath()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Wählen Sie einen Ordner aus, um ihn zu löschen.";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            return null;
        }
        private string GetFilePath()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Wählen Sie eine Datei zum Löschen aus.";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            return null;
        }

        private bool ConfirmDeleteFile(string filePath)
        {
            string message = $"Sind Sie sicher, dass Sie die Datei {filePath} löschen möchten?";
            string caption = "Bestätigung erforderlich";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void DeleteFile(string filePath)
        {
            try
            {
                // Überprüfen, ob die Datei existiert, um ungewollte Löschungen zu vermeiden
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    AddTextToConsole($"Datei: {filePath} wurde gelöscht.", Color.Green);
                }
                else
                {
                    AddTextToConsole($"Die angegebene Datei {filePath} existiert nicht.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                AddTextToConsole($"Fehler beim Löschen der Datei: {ex.Message}", Color.Red);
            }
            AddTextToConsole(" ", currentForeColor);
            AddTextToConsole("--------------------", currentForeColor);
            AddTextToConsole("Löschen abgeschlossen!", Color.Green);
        }

        private bool ConfirmDeleteTemp()
        {
            string message = "Sind Sie sicher, dass Sie den gesamten Inhalt des Temp-Ordners löschen möchten?";
            string caption = "Bestätigung erforderlich";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void DeleteTempFolderContents()
        {
            string tempFolderPath = Path.GetTempPath();
            string[] tempFiles = Directory.GetFiles(tempFolderPath);

            foreach (string file in tempFiles)
            {
                try
                {
                    File.Delete(file);
                    AddTextToConsole($"Datei {file} wurde gelöscht.", Color.Green);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Löschen der Datei {file}: {ex.Message}", Color.Red);
                }
            }

            string[] tempDirectories = Directory.GetDirectories(tempFolderPath);
            foreach (string directory in tempDirectories)
            {
                try
                {
                    Directory.Delete(directory, true);
                    AddTextToConsole($"Ordner {directory} und seine Inhalte wurden gelöscht.", Color.Green);
                }
                catch (Exception ex)
                {
                    AddTextToConsole($"Fehler beim Löschen des Ordners {directory}: {ex.Message}", Color.Red);
                }
            }

            // Meldung, dass das Löschen abgeschlossen ist
            AddTextToConsole(" ", currentForeColor);
            AddTextToConsole("--------------------", currentForeColor);
            AddTextToConsole("Löschen abgeschlossen!", Color.Green);
        }

        private bool ConfirmAction(string message)
        {
            DialogResult result = MessageBox.Show(message, "Bestätigung! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void PrintDirectoryTree(DirectoryInfo directory, int indentLevel)
        {
            foreach (var file in directory.GetFiles())
            {
                string indent = new string(' ', indentLevel * 4);
                AddTextToConsole($"{indent}- {file.Name}", Color.White);
            }

            foreach (var subdirectory in directory.GetDirectories())
            {
                string indent = new string(' ', indentLevel * 4);
                AddTextToConsole($"{indent}+ {subdirectory.Name}", Color.White);
                PrintDirectoryTree(subdirectory, indentLevel + 1);
            }
        }

        
        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start(githubProject);
        }


        #region Color-Theme-Settings

        void SaveColorThemeSettings()
        {
            Data.Settings.Default.ConsoleBackgroundColor = ConsoleBackgroundColor;
            Data.Settings.Default.ConsoleTextColor = ConsoleTextColor;
            Data.Settings.Default.InputTextColor = InputTextColor;
            Data.Settings.Default.InputBackgroundColor = InputBackgroundColor;
            Data.Settings.Default.SidebarBackgroundColor = SidebarBackgroundColor;
            Data.Settings.Default.SidebarTextColor = SidebarTextColor;
            Data.Settings.Default.TopBarBackgroundColor = TopBarBackgroundColor;
            Data.Settings.Default.TopBarTextColor = TopBarTextColor;
            Data.Settings.Default.Save();
        }

        void SetColorTheme()
        {
            // Console Theme
            txtConsole.BackColor = Data.Settings.Default.ConsoleBackgroundColor;
            txtConsole.ForeColor = Data.Settings.Default.ConsoleTextColor;

            // InputTheme
            txtUserInput.BackColor = Data.Settings.Default.InputBackgroundColor;
            txtUserInput.ForeColor = Data.Settings.Default.InputTextColor;

            // Sidebar Theme
            app_sidebar.BackColor = Data.Settings.Default.SidebarBackgroundColor;
            lblVersion.ForeColor = Data.Settings.Default.SidebarTextColor;
            cblivePreview.ForeColor = Data.Settings.Default.SidebarTextColor;

            // TopBar Theme
            this.app_title.ForeColor = Data.Settings.Default.TopBarTextColor;
            this.app_menubar.BackColor = Data.Settings.Default.TopBarBackgroundColor;

            this.Opacity = Data.Settings.Default.FormOpacity;
            this.AllowTransparency = true;
            this.TransparencyKey = Data.Settings.Default.FormColorKey;

        }

        private void LiveThemeUpdater_Tick(object sender, EventArgs e)
        {
            SetColorTheme();
        }

        private void cblivePreview_CheckedChanged(object sender, EventArgs e)
        {
            if (isLivePreview)
            {
                isLivePreview = false;
                LiveThemeUpdater.Stop();
            }
            else
            {
                isLivePreview = true;
                LiveThemeUpdater.Start();
            }
        }

        

        #endregion Color-Theme-Settings

        private void btnEditDesign_Click(object sender, EventArgs e)
        {
            Frm_ThemeEditor frm = new Frm_ThemeEditor();
            frm.ShowDialog();
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
