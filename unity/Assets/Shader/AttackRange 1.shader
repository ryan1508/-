// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/AttackRange"
{
    Properties
    {
        _MainTex("Base (RGB)",2D) = "white"{}
        _AreaColor("Area Color",Color) = (1,1,1,1)
        _Center ("Center",Vector) = (0,0,0,0)
        _Border("Border",Range(0,10)) =12
        _Radius ("Radius",Range(0,10)) = 75
        _Alpha ("RangeAlpha",Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "ForceNoShadowCasting" = "True"}
        
        //Alphatest Greater 0.0
        offset -1,-1
        Pass 
        {
            Blend SrcAlpha OneMinusSrcAlpha
            SetTexture[_MainTex]
            {
                constantColor[_AreaColor]
                Combine texture lerp(texture) previous, constant
            }
        }
        CGPROGRAM
        
        #pragma surface surf Lambert alpha:fade // alpha:fade 또는 alpha:blend
        #pragma target 3.0

        sampler2D _MainTex;
        fixed3 _AreaColor;
        float3 _Center;
        float _Radius;
        float _Border;
        float _Alpha;
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 wordlScale;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float3 localPos = IN.worldPos -  mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;
            float localScale = IN.uv_MainTex - mul(unity_ObjectToWorld,float4(0,0,0,1)).xyz;
            float dist = distance(_Center,localPos);
            
            half4 c = tex2D(_MainTex,localScale);
            if(dist > _Radius && dist < (_Radius + _Border))
            {
                o.Albedo = _AreaColor;
                o.Alpha = _Alpha;
            }
            else
            {
                o.Albedo = c.rgb;
                o.Alpha = 0;
            }
        }

        //Input vert (Input v)
        //{
        //        o.vertex = UnityObjectToClipPos(v.vertex);
 //
        //        // Gets the xy position of the vertex in worldspace.
        //        float2 worldXY = mul(unity_ObjectToWorld, v.vertex).xy;
        //        // Use the worldspace coords instead of the mesh's UVs.
        //        o.uv = TRANSFORM_TEX(worldXY, _MainTex);
 //
        //        return o;
        //}
        ENDCG
    }
    FallBack "Diffuse"
}
