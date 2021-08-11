/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZUI.Main
{
    public partial class SPUI_TestUI : GComponent
    {
        public GButton btn_test;
        public const string URL = "ui://ryan6zloew2e0";

        public static SPUI_TestUI CreateInstance()
        {
            return (SPUI_TestUI)UIPackage.CreateObject("Main", "TestUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_test = (GButton)GetChild("btn_test");
        }
    }
}