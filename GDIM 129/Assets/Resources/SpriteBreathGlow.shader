Shader "Custom/SpriteBreathGlow"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (1, 0, 1, 1) // 默认紫色
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1.5
        _BreathSpeed ("Breath Speed", Range(0.1, 5)) = 1
        _BreathAmount ("Breath Amount", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "IgnoreProjector" = "True"
            "CanUseSpriteAtlas" = "True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _GlowColor;
            float _GlowIntensity;
            float _BreathSpeed;
            float _BreathAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * i.color;
                
                // 计算呼吸效果：用sin函数生成0-1之间的波动值
                float breath = 0.5 + 0.5 * sin(_Time.y * _BreathSpeed * 3.14159);
                // 调整呼吸的幅度
                breath = 1 - _BreathAmount + breath * _BreathAmount;
                
                // 叠加发光颜色
                float3 glow = _GlowColor.rgb * _GlowIntensity * breath;
                col.rgb += glow * col.a;
                
                return col;
            }
            ENDCG
        }
    }
}