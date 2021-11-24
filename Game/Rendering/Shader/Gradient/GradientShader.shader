Shader "Hidden/GradientShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color) = (1,1,1,1) 
        _GradientTex("Gradient texture", 2D) = "white" {}
        _GradientCutoff("Gradient Cutoff", Range(0,1)) = 0
        _GradientModifier("Gradient Modifier", Int) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
            };

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

            sampler2D _MainTex;
            sampler2D _GradientTex;
            fixed4 _Color;
            fixed _GradientCutoff, _GradientModifier;

            fixed4 frag (v2f i) : SV_Target
            {
                float gradient = tex2D(_GradientTex, i.uv);
                clip(_GradientModifier * (_GradientCutoff - gradient));
                fixed4 col = tex2D(_MainTex, i.uv);
                col = col * _Color;
                return col;
            }
            ENDCG
        }
    }
}
