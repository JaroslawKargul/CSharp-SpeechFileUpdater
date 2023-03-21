using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpeechFileUpdater.Utils
{
    public class Globals
    {
        private const string _initialChatGPTLine = "Short one-liner, the Wilson gentleman scientist's Don't Starve witty or funny string for <KEY>:";
        private static readonly Font _initialEditorFont = new Font("Segoe UI", 9.5F, GraphicsUnit.Point);
        private const float _initialChatGPTRandomness = 0.5F;

        public static string leftFilePath;
        public static string rightFilePath;
        public static string lastSearchedPath;
        public static string appParentDir;

        public static string chatGPTApiKeyLeft;
        public static string chatGPTPromptLeft = _initialChatGPTLine;
        public static float chatGPTResponseRandomnessLeft = _initialChatGPTRandomness;
        
        public static string chatGPTApiKeyRight;
        public static string chatGPTPromptRight = _initialChatGPTLine;
        public static float chatGPTResponseRandomnessRight = _initialChatGPTRandomness;

        public static bool editorChatGPTEnabled = true;
        public static Font editorTableFontLeft = _initialEditorFont;
        public static Font editorTableFontRight = _initialEditorFont;

        public static bool emptyLinesToTableBottom = true;
    }
}
