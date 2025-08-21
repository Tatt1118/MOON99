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

            //���f������󂯎��f�[�^�@���_
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            //���_�V�F�[�_�˃t���O�����g�V�F�[�_�ɓn���f�[�^
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

            // === �ȈՃm�C�Y�֐� ===
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

                // �m�C�Y��UV��c�܂���
                float n = noise(uv + float2(_Time.y * _ScrollSpeed, 0));
                float distorted = uv.x + n * _Distortion;

                // �T�C���g���g���ă}�[�u���͗l�����
                float stripe = sin(distorted * _Frequency + uv.y * 2.0);

                // �l�� 0-1 �ɐ��K��
                stripe = stripe * 0.5 + 0.5;

                // 2�F�̕��
                fixed4 col = lerp(_ColorA, _ColorB, stripe);

                return col;
            }
            ENDCG
        }
    }
}
