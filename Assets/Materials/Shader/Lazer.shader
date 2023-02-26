Shader "Unlit/LazerBeam"
{
    Properties
    {
        [HDR] _Color("Color", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _Mask("Mask", 2D) = "white" {}
        _Speed("Speed", Float) = -0.5
        _NoiseScale("Noise scale", Float) = 25
        _NoiseSpeed("Noise speed", Float) = -0.7
        _NoisePower("Power", Float) = 2
        _NoiseAmount("Noise amount", Range(0, 1)) = 0.05
        _DisolveAmount("Disolve amount", Range(0, 1)) = 0.6

    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Blend SrcAlpha DstAlpha
        LOD 100

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
                float4 color: Color;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 vertexColor: Color;

            };

            sampler2D _MainTex;
            sampler2D _Mask;
            float4 _MainTex_ST;
            float _Speed;
            float4 _Color;
            float _NoisePower;
            float _NoiseScale;
            float _NoiseSpeed;
            float _NoiseAmount;
            float _DisolveAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.vertexColor = v.color;
                return o;
            }

            inline float unity_noise_randomValue(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
            }

            inline float unity_noise_interpolate(float a, float b, float t)
            {
                return (1.0 - t) * a + (t * b);
            }

            inline float unity_valueNoise(float2 uv)
            {
                float2 i = floor(uv);
                float2 f = frac(uv);
                f = f * f * (3.0 - 2.0 * f);

                uv = abs(frac(uv) - 0.5);
                float2 c0 = i + float2(0.0, 0.0);
                float2 c1 = i + float2(1.0, 0.0);
                float2 c2 = i + float2(0.0, 1.0);
                float2 c3 = i + float2(1.0, 1.0);
                float r0 = unity_noise_randomValue(c0);
                float r1 = unity_noise_randomValue(c1);
                float r2 = unity_noise_randomValue(c2);
                float r3 = unity_noise_randomValue(c3);

                float bottomOfGrid = unity_noise_interpolate(r0, r1, f.x);
                float topOfGrid = unity_noise_interpolate(r2, r3, f.x);
                float t = unity_noise_interpolate(bottomOfGrid, topOfGrid, f.y);
                return t;
            }

            void Unity_SimpleNoise_float(float2 UV, float Scale, out float Out)
            {
                float t = 0.0;

                float freq = pow(2.0, float(0));
                float amp = pow(0.5, float(3 - 0));
                t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

                freq = pow(2.0, float(1));
                amp = pow(0.5, float(3 - 1));
                t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

                freq = pow(2.0, float(2));
                amp = pow(0.5, float(3 - 2));
                t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

                Out = t;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //Scroll texture
                fixed2 mainUV = i.uv;
                fixed xScrollValue = _Speed * _Time.y;


                //Noise
                fixed noiseSpeed = _Time.y * _NoiseSpeed;
               
                float simpleNoise;
                Unity_SimpleNoise_float(float2(i.uv.x + noiseSpeed, i.uv.y), _NoiseScale, simpleNoise);
                
                fixed power = pow(simpleNoise, _NoisePower);
                fixed2 noiseLerp = lerp(i.uv, power, _NoiseAmount);


                //moving texture
                mainUV = fixed2(xScrollValue + noiseLerp.x, i.uv.y);


                // sample the texture
                fixed4 mask = tex2D(_Mask, i.uv);
                fixed4 lazer = tex2D(_MainTex, mainUV);
                
                //Distorsion
                fixed disolve = lazer.a * power;
                fixed4 disolveLerp = lerp(lazer, disolve, _DisolveAmount);


                //Calculate color
                fixed4 finalColor = mask * disolveLerp * _Color * i.vertexColor;
                finalColor.a = disolveLerp.a * mask.r;


                return finalColor;
            }
            ENDCG
        }
    }
}
