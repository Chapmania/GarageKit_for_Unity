﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * シェーダー内のテクスチャを更新する
 */ 
namespace GarageKit
{
    [Serializable]
    public class LayerTexture
    {
        public RenderScreenTexture renderScreenTexture;
        public string shaderTextureName = "_MainTex";
    }

    public class CompositLayer : MonoBehaviour
    {
        public bool isUpdateShader = true;
        public LayerTexture[] layerTextures;


        void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {
            //シェーダー内のテクスチャを更新
            if(isUpdateShader)
            {
                foreach(LayerTexture layerTex in layerTextures)
                {
                    this.gameObject.GetComponent<Renderer>().material.SetTexture(
                        layerTex.shaderTextureName,
                        layerTex.renderScreenTexture.GetRenderTexture());
                }
            }
        }
    }
}
