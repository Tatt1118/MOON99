Shader "Unlit/marblenoise"
{
 Properties
    {
        _ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (0,0,0,1)
        _Scale ("Noise Scale", Float) = 5.0
        _ScrollSpeed ("Scroll Speed", Float) = 0.5
        _Distortion ("Distortion Strength", Float) = 2.0
        _Frequency ("Stripe Frequency", Float) = 10.0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // === Properties ===
            fixed4 _ColorA;
            fixed4 _ColorB;
            float _Scale;
            float _ScrollSpeed;
            float _Distortion;
            float _Frequency;

            //モデルから受け取るデータ　頂点
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            //頂点シェーダ⇒フラグメントシェーダに渡すデータ
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // === 簡易ノイズ関数 ===
            float hash(float2 p)
            {
                return frac(sin(dot(p, float2(127.1, 311.7))) * 43758.5453);
            }

            float noise(float2 p)
            {
                float2 i = floor(p);
                float2 f = frac(p);

                float a = hash(i);
                float b = hash(i + float2(1.0, 0.0));
                float c = hash(i + float2(0.0, 1.0));
                float d = hash(i + float2(1.0, 1.0));

                float2 u = f * f * (3.0 - 2.0 * f);

                return lerp(lerp(a, b, u.x), lerp(c, d, u.x), u.y);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * _Scale;

                // ノイズでUVを歪ませる
                float n = noise(uv + float2(_Time.y * _ScrollSpeed, 0));
                float distorted = uv.x + n * _Distortion;

                // サイン波を使ってマーブル模様を作る
                float stripe = sin(distorted * _Frequency + uv.y * 2.0);

                // 値を 0-1 に正規化
                stripe = stripe * 0.5 + 0.5;

                // 2色の補間
                fixed4 col = lerp(_ColorA, _ColorB, stripe);

                return col;
            }
            ENDCG
        }
    }
}
