// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Shield"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _WaveColor("Wave Color", Color) = (1,1,1,1)
        _Point("point", Vector) = (0, 1, 0, 0)
        _ImpactSize("size", Float) = 0.5
        _Interv("interval", Float) = 2.5
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _Point;
            float _ImpactSize;
            float _Interv;
            fixed4 _Color;
            fixed4 _WaveColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.worldPos = mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1)).xyz;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                float3 pointPos = mul(unity_ObjectToWorld, float4(_Point.xyz, 1));
                float3 objPos = i.worldPos;
                _Point.w *= _Time.y;
                _Point.w /= _Interv;
                float emessive = frac(1.0 - max(0, (_Point.w * _ImpactSize) - distance(pointPos.xyz, objPos.xyz)) / _ImpactSize);

                col = half4(col.rgb * float3(1, 1, 1), _Color.a);
                col += emessive * _WaveColor;

                return col;
            }
            ENDCG
        }
    }
}
