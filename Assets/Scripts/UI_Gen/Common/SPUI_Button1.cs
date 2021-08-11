/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZUI.Common
{
    public partial class SPUI_Button1 : GButton
    {
        public GTextField text;
        public const string URL = "ui://kbqwxlg6wpn24";

        public static SPUI_Button1 CreateInstance()
        {
            return (SPUI_Button1)UIPackage.CreateObject("Common", "Button1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            text = (GTextField)GetChild("text");
        }
    }
}