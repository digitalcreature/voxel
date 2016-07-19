Shader "Skybox/Gradient"
{
	Properties
	{
		_BottomColor ("Bottom Color", Color) = (1, 1, 1, 1)
		_TopColor ("Top Color", Color) = (1, 1, 1, 1)
		_Bars ("Bar Count", Int) = 8
	}
	SubShader
	{
		Tags { "QUEUE"="Background" }
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
			};

			half4 _BottomColor;
			half4 _TopColor;
			int _Bars;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = (v.uv + 1) / 2; //make sure uv is from 0 to 1 not -1 to 1
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float v = i.uv.y;
				v *= _Bars;
				v = (int) v;
				v /= _Bars;
				return _BottomColor + (v * (_TopColor - _BottomColor));
			}
			ENDCG
		}
	}
}
