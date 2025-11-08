Shader "Custom/2DColorOutlineTriangle"
{
    Properties
    {
        _Color("Triangle Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _OutlineWidthX("Outline Width X", Range(0.001, 0.05)) = 0.01
        _OutlineWidthY("Outline Width Y", Range(0.001, 0.05)) = 0.01
        _OutlineWidthZ("Outline Width Z", Range(0.001, 0.05)) = 0.01
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            ZWrite On
            ZTest LEqual
            Blend SrcAlpha OneMinusSrcAlpha
            Offset 10, 10

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            float _OutlineWidthX;
            float _OutlineWidthY;
            float _OutlineWidthZ;
            float4 _OutlineColor;

            v2f vert(appdata v)
            {
                v2f o;
                // Displace vertices along X, Y, and Z for the outline
                float4 offset = float4(_OutlineWidthX, _OutlineWidthY, _OutlineWidthZ, 0);
                o.pos = UnityObjectToClipPos(v.vertex + offset);
                o.color = _OutlineColor;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }

        Pass
        {
            Name "BASE"
            Tags { "LightMode" = "ForwardBase" }
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
        FallBack "Diffuse"
}