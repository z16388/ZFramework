using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        public void Show()
        {
            Global.UHelper.Show(gameObject);
        }

        public void Hide()
        {
            Global.UHelper.Hide(gameObject);
        }

        public void ResetAll()
        {
            Global.UHelper.ResetAll(gameObject);
        }

        public void SetLoaclPosX(float x)
        {
            Global.UHelper.SetLoaclPosX(gameObject, x);
        }

        public void SetLoaclPosY(float y)
        {
            Global.UHelper.SetLoaclPosY(gameObject, y);
        }

        public void SetLoaclPosZ(float z)
        {
            Global.UHelper.SetLoaclPosZ(gameObject, z);
        }

        public void SetLocalScaleX(float x)
        {
            Global.UHelper.SetLocalScaleX(gameObject, x);
        }

        public void SetLocalScaleY(float y)
        {
            Global.UHelper.SetLocalScaleY(gameObject, y);
        }

        public void SetLocalScaleZ(float z)
        {
            Global.UHelper.SetLocalScaleZ(gameObject, z);
        }
    }
}

