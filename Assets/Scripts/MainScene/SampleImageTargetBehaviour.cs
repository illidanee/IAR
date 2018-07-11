//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using EasyAR;

namespace Sample
{
    public class SampleImageTargetBehaviour : ImageTargetBehaviour
    {
        GameObject _Obj;

        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
        }

        void OnTargetFound(TargetAbstractBehaviour behaviour)
        {
            Debug.Log("Found: " + Target.Id);

            _Obj = Instantiate(Resources.Load(Target.Name)) as GameObject;
            _Obj.transform.parent = this.gameObject.transform;
            
            //不使用 相对 Transform 设置。
            //obj.transform.localPosition = Vector3.up / 1;
            //obj.transform.localScale = new Vector3(this.Size.x / Mathf.Max(this.Size.x, this.Size.y) / 2, 1f / 5, this.Size.y / Mathf.Max(this.Size.x, this.Size.y) / 2);
        }

        void OnTargetLost(TargetAbstractBehaviour behaviour)
        {
            Debug.Log("Lost: " + Target.Id);

            Destroy(_Obj);

            //Destroy(this.gameObject);
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }
    }
}
