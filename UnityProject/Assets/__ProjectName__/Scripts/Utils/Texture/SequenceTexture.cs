﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 連番のテクスチャを切り替えてアニメーションをさせる
 */ 
namespace GarageKit
{
    public class SequenceTexture : MonoBehaviour
    {	
        public int fps = 30;
        public bool isLoop = false;
        public Texture2D[] textures;
        public string textureParamName = "";

        private int counter;


        void Start()
        {
            if(textures.Length == 0)
                return;

            // スタートフレームを設定
            if(textureParamName == "")
                textureParamName = "_MainTex";
            this.GetComponent<Renderer>().material.SetTexture(textureParamName, textures[0]);

            // 再生を開始する
            counter = 0;
            StartCoroutine("UpdateTexture");
        }

        IEnumerator UpdateTexture()
        {
            while(true)
            {
                // fpsで待機
                yield return new WaitForSeconds(1.0f / (float)fps);

                // テクスチャを更新
                counter = (counter + 1) % textures.Length;
                this.GetComponent<Renderer>().material.SetTexture(textureParamName, textures[counter]);

                // ループ設定
                if(((counter + 1) == textures.Length) && !isLoop)
                    break;
            }
        }

        void OnApplicationQuit()
        {
            StopCoroutine("UpdateTexture");
        }
    }
}
