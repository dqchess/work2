﻿/*
 * Camera Following, modified frow smoothFollow.js by ljx
 */
using UnityEngine;

namespace engine {
    public class CameraFollowing : MonoBehaviour {
        public float rushDelay = 0f;//主角冲刺之后镜头缓动时间
        public Transform target;
        public float xOffset = 10.0f;
        public float zOffset = 10.0f;
        public float height = 5.0f;
        public float lookHeight = 1f;
        public float hightSmooth = 2.0f;
        public float xzSmooth = 1.0f;

        private Vector3 lastPos;

        private Vector3 temp;

        void LateUpdate() {
            if (target == null)
                return;
            doUpdate(Time.deltaTime);
        }

        public void makeFollow() {
            doUpdate(float.MaxValue);
        }

        private void doUpdate(float deltaTime) {
            Vector3 temp = target.position;
            float rate = (temp - lastPos).magnitude/0.05f;
            float offsetX = Mathf.Lerp(transform.position.x - temp.x, xOffset, rate * hightSmooth * deltaTime);
            float offsetY = Mathf.Lerp(transform.position.y - temp.y, height, rate * xzSmooth * deltaTime);
            float offsetZ = Mathf.Lerp(transform.position.z - temp.z, zOffset, rate * xzSmooth * deltaTime);
            lastPos = temp;
            temp.x = temp.x + offsetX;
            temp.y = temp.y + offsetY;
            temp.z = temp.z + offsetZ;
            transform.position = temp;
            transform.LookAt(target.position + Vector3.up * lookHeight);  
        }
    }
}
