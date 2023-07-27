Shader "Unlit/AnimatedRings"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [IntRange] _NumRings ("Number of Rings", Range(1,64)) = 4
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
 
        Pass
        {
            Blend One OneMinusSrcAlpha
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
 
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            float pixelRing(float2 pos, float2 center, float radius)
            {
                float dist = length(pos - center);
                float deriv = length(float2(ddx(dist), ddy(dist)));
                float ring = smoothstep(deriv, 0.0, abs(dist - radius));
                return ring;
            }
 
            half4 _Color;
            int _NumRings;
 
            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv - 0.5;
 
                half tau = UNITY_PI * 2.0;
 
                half totalAlpha = 0;
                for (int r=0; r<_NumRings; r++)
                {
                    float a = (float)r / (float)_NumRings;
 
                    half radians = tau * a;
                    half s, c;
                    sincos(radians, s, c);
 
                    float2 center = float2(s, c) * 0.166;
 
                    float t = frac(_Time.y * 0.25 + a);
 
                    float radius = sqrt(t) * 0.33;
 
                    half ring = pixelRing(uv, center, radius);
 
                    float alpha = pow(1.0 - t, 2.0);
 
                    totalAlpha = lerp(totalAlpha, 1.0, ring * alpha);
                }
 
                half4 col = _Color * totalAlpha;
                return col;
            }
            ENDCG
        }
    }
}