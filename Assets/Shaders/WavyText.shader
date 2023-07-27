Shader "Custom/WavyText" {
    Properties {
        _MainTex ("Font Texture", 2D) = "white" {}
        _WaveAmplitude ("Wave Amplitude", Range(0,1)) = 0.1
        _WaveFrequency ("Wave Frequency", Range(0,10)) = 1
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WaveAmplitude;
            float _WaveFrequency;
            
            v2f vert (appdata v) {
                v2f o;
                v.uv.y += _WaveAmplitude * sin(_Time.y * _WaveFrequency + v.uv.x * 2.0 * 3.14159);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}