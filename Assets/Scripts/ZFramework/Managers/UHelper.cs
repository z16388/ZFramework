using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class UHelper
    {
        public UHelper()
        {

        }

        // About Transform
        public void SetLoaclPosX(Transform transform, float x)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            transform.localPosition = localPosition;
        }

        public void SetLoaclPosY(Transform transform, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }

        public void SetLoaclPosZ(Transform transform, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.z = z;
            transform.localPosition = localPosition;
        }

        public void SetLocalScaleX(Transform transform, float x)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            transform.localScale = localScale;
        }

        public void SetLocalScaleY(Transform transform, float y)
        {
            var localScale = transform.localScale;
            localScale.y = y;
            transform.localScale = localScale;
        }

        public void SetLocalScaleZ(Transform transform, float z)
        {
            var localScale = transform.localScale;
            localScale.z = z;
            transform.localScale = localScale;
        }

        public void ResetAll(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }


        // About GameObject
        public void Hide(GameObject go)
        {
            go.SetActive(false);
        }

        public void Show(GameObject go)
        {
            go.SetActive(true);
        }

        public void SetLoaclPosX(GameObject go, float x)
        {
            SetLoaclPosX(go.transform, x);
        }

        public void SetLoaclPosY(GameObject go, float y)
        {
            SetLoaclPosY(go.transform, y);
        }

        public void SetLoaclPosZ(GameObject go, float z)
        {
            SetLoaclPosZ(go.transform, z);
        }

        public void SetLocalScaleX(GameObject go, float x)
        {
            SetLocalScaleX(go.transform, x);
        }

        public void SetLocalScaleY(GameObject go, float y)
        {
            SetLocalScaleY(go.transform, y);
        }

        public void SetLocalScaleZ(GameObject go, float z)
        {
            SetLocalScaleZ(go.transform, z);
        }

        public void ResetAll(GameObject go)
        {
            ResetAll(go.transform);
        }
    }

}
