using LuaInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechFileUpdater.Forms;

namespace SpeechFileUpdater.Utils
{
    class MainFormUtils
    {
        public static string RemoveMultilines(object obj)
        {
            string valueString = (string)obj;
            if (valueString.Contains("\n") || valueString.Contains("\r"))
            {
                valueString = valueString.Replace("\n", @"\n");
                valueString = valueString.Replace("\r", @"\n");
                valueString = valueString.Replace(Environment.NewLine, @"\n");
                return valueString;
            }
            return valueString;
        }

        public static void Log(string logEntry)
        {
            using (StreamWriter w = File.AppendText(@"C:\users\jarekk\desktop\speechfileupdaterlog.txt"))
            {
                w.WriteLine(logEntry);
            }
        }

        public static void UpdateFileLabelText(Label label, string text)
        {
            if (text.Length > 72)
            {
                label.Text = $"Current file: (...){text.Substring(text.Length - 67).Trim()}";
            }
            else
            {
                label.Text = $"Current file: {text}";
            }
        }

        public static OpenFileDialog NewLuaOpenFileDialog(string initialDirectory = @"C:\")
        {
            if (String.IsNullOrEmpty(Globals.lastSearchedPath) &&
                !String.IsNullOrEmpty(Globals.appParentDir) && Directory.Exists(Globals.appParentDir))
            {
                initialDirectory = Globals.appParentDir;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.Title = "Browse Don't Starve Speech Files";
            openFileDialog.DefaultExt = "lua";
            openFileDialog.Filter = "LUA files (*.lua)|*.lua";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            return openFileDialog;
        }

        public static SaveFileDialog NewLuaSaveFileDialog(string initialDirectory = @"C:\speech_character.lua")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(initialDirectory);
            saveFileDialog.FileName = Path.GetFileName(initialDirectory);
            saveFileDialog.DefaultExt = "lua";
            saveFileDialog.Filter = "LUA files (*.lua)|*.lua";
            saveFileDialog.Title = "Save Don't Starve Speech File...";
            return saveFileDialog;
        }

        public static void ShowPopUp(Form parentForm, string title, string label, bool smallForm = false)
        {
            PopUpForm popUpForm = new PopUpForm(title, label, smallForm);
            popUpForm.ShowDialog(parentForm);
        }

        public static DialogResult ShowYesNoPopUp(Form parentForm, string title, string label)
        {
            PopUpYesNoForm popUpYesNoForm = new PopUpYesNoForm(title, label);
            return popUpYesNoForm.ShowDialog(parentForm);
        }

        public static bool VerifyIfFileDangerous(string filePath)
        {
            string[] fileContent = File.ReadAllLines(filePath);
            bool stringTableStarted = false;
            bool stringTableEnded = false;
            bool inMultilineComment = false;

            foreach (string line in fileContent)
            {
                if (line.Trim().StartsWith("--[["))
                {
                    inMultilineComment = true;
                    continue;
                }

                if (line.Trim().EndsWith("]]--"))
                {
                    inMultilineComment = false;
                    continue;
                }

                if (inMultilineComment)
                {
                    continue;
                }

                if (line.Trim().StartsWith("return") && line.Trim().EndsWith("{"))
                {
                    stringTableStarted = true;
                    continue;
                }

                if (stringTableStarted && line.Trim().EndsWith("}") && !line.Trim().EndsWith("},"))
                {
                    stringTableEnded = true;
                    continue;
                }

                if (!stringTableStarted && !line.Trim().StartsWith("--") && !String.IsNullOrEmpty(line.Trim()))
                {
                    return true;
                }

                if (stringTableStarted && !stringTableEnded && !line.Trim().StartsWith("{") && !line.Trim().StartsWith("},")
                    && !line.Trim().EndsWith("},") && !line.Trim().Contains("=")
                    && !String.IsNullOrEmpty(line.Trim()) && !line.Trim().StartsWith("--") &&
                    !line.Trim().StartsWith("\""))
                {
                    return true;
                }

                if (stringTableEnded && !String.IsNullOrEmpty(line.Trim()) && !line.Trim().StartsWith("--"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
