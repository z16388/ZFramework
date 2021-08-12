using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConfigData;

namespace ZFramework
{
    public class DialogInfo
    {

        private string _packName;
        private string _dialogName;

        public DialogInfo(string packName, string dialogName)
        {
            _packName = packName;
            _dialogName = dialogName;
        }

        public string GetPackName()
        {
            return _packName;
        }

        public string GetDialogName()
        {
            return _dialogName;
        }

    }

    public class UIHelper
    {
        private static Dictionary<string, BaseDialog> _uiDict;
        private static Dictionary<string, GComponent> _uiViews;
        private static int _uiMaxCount = 20;
        private static Dictionary<string, string> _uiPackDict;

        public UIHelper()
        {
            LoadBasePackage();
            GRoot.inst.SetContentScaleFactor(GameSettings.Instance.ScreenWeight, GameSettings.Instance.ScreenHeight, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
            UIConfig.defaultFont = "OPPOSans-M";

            _uiDict = new Dictionary<string, BaseDialog>();
            _uiViews = new Dictionary<string, GComponent>();
            _uiPackDict = new Dictionary<string, string>();
            SetUIMaxCount();
            InitPackData();
        }

        public static BaseDialog GetDialog<T>() where T : BaseDialog
        {
            return _uiDict[typeof(T).Name];
        }

        public static DialogInfo GetDialogInfo<T>() where T : BaseDialog
        {
            if (_uiDict.ContainsKey(typeof(T).Name))
            {
                return _uiDict[typeof(T).Name].GetDialogInfo();
            }
            else
            {
                return null;
            }
        }

        private static void TryAddToDict(string Key, BaseDialog dialog)
        {
            if (_uiDict.Count >= _uiMaxCount)
            {
                var dic_SortedById = from n in _uiDict orderby n.Value.instanceId ascending select n.Key;
                string firstWindowKey = "";
                foreach (var win in dic_SortedById)
                {
                    firstWindowKey = win;
                    break;
                }

                _uiDict.Remove(firstWindowKey);
            }
            _uiDict.Add(Key, dialog);
        }

        public static BaseDialog Open<T>(object arg = null) where T : BaseDialog, new()
        {
            T uiDialog;
            string uiName = typeof(T).Name;
            string uiKey = uiName.Replace("UI_", "");
            if (!_uiPackDict.ContainsKey(uiKey))
            {
                MDebug.LogDevErr("UI Package Name Error : " + uiName);
                return null;
            }
            string uiPackageName = _uiPackDict[uiKey];

            uiDialog = Global.UIRoot.AddComponent<T>();
            uiDialog.Data = arg;
            DialogInfo dialogInfo = new DialogInfo(uiPackageName, uiKey);
            uiDialog.SetDialogInfo(dialogInfo);

            if (UIHelper.IsContainUI<T>())
            {
                GObject targetUIObject = uiDialog.GetViewObject();
                targetUIObject.visible = true;
                uiDialog.SetDialogView(_uiViews[uiName]);
            }
            else
            {
                GComponent view = UIPackage.CreateObject(dialogInfo.GetPackName(), dialogInfo.GetDialogName()) as GComponent;
                view.SetSize(GRoot.inst.width, GRoot.inst.height);
                view.name = dialogInfo.GetDialogName();
                GRoot.inst.AddChild(view);
                uiDialog.SetDialogView(view);

                TryAddToDict(uiName, uiDialog);
                _uiViews.Add(uiName, view);
            }

            uiDialog.OnBeforeCreate();
            uiDialog.AddListener();
            uiDialog.OnCreate();
            uiDialog.OnRefresh();

            return uiDialog;
        }

        public static void Close<T>() where T : BaseDialog
        {
            if (UIHelper.IsContainUI<T>())
            {
                T uiDialog = (T)_uiDict[typeof(T).Name];
                uiDialog.RemoveListener();
                uiDialog.OnHide();
                uiDialog.OnDestroy();
                uiDialog.GetView().visible = false;
                uiDialog.Close();
            }
        }

        public static bool IsContainUI<T>() where T : BaseDialog
        {
           return _uiDict.ContainsKey(typeof(T).Name);
        }

        private void SetUIMaxCount()
        {
            if (SystemInfo.systemMemorySize < 2000)
            {
                _uiMaxCount = 4;
            }
            else if (SystemInfo.systemMemorySize < 4000)
            {
                _uiMaxCount = 10;
            }
        }

        private void InitPackData()
        {
            foreach (var line in DataCfg.UI_Data.UIPackagesItems)
            {
                _uiPackDict.Add(line.Name, line.PackageName);
            }
        }

        private void LoadBasePackage()
        {
            UIPackage.AddPackage("UI/Common").LoadAllAssets();
            UIPackage.AddPackage("UI/Main").LoadAllAssets();
            UIPackage.AddPackage("UI/Splash").LoadAllAssets();
        }
    }
}

