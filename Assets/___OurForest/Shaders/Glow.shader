// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Glow"
{
	Properties
	{
		_Color0("Color 0", Color) = (0,1,0.7863998,1)
		_disolve("disolve", Range( -1 , 1)) = 0
		_TextureSample2("Texture Sample 2", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
		};

		uniform sampler2D _TextureSample2;
		uniform float4 _TextureSample2_ST;
		uniform float4 _Color0;
		uniform float _disolve;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TextureSample2 = i.uv_texcoord * _TextureSample2_ST.xy + _TextureSample2_ST.zw;
			o.Albedo = tex2D( _TextureSample2, uv_TextureSample2 ).rgb;
			float3 ase_worldPos = i.worldPos;
			o.Emission = ( ( abs( _SinTime.w ) * _Color0 ) * ( ase_worldPos.y - _disolve ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
1366;0;1024;707;1440.674;-83.95032;1;False;False
Node;AmplifyShaderEditor.CommentaryNode;104;-28.99696,-1685.505;Inherit;False;710.4584;563.0641;Glow shader;8;273;12;10;8;272;270;271;332;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SinTimeNode;332;-24.09216,-1650.103;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.AbsOpNode;8;101.8376,-1649.569;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;10;99.25041,-1580.001;Inherit;False;Property;_Color0;Color 0;0;0;Create;True;0;0;False;0;False;0,1,0.7863998,1;0,0.6942835,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;271;-19.63305,-1246.536;Inherit;False;Property;_disolve;disolve;4;0;Create;True;0;0;False;0;False;0;0.46;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;270;-17.61625,-1387.446;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;272;243.6874,-1376.906;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;361.5817,-1629.215;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;293;-690.4609,744.0042;Inherit;False;943.9079;551.6401;death disolve;8;282;285;284;275;291;286;283;292;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;269;-1303.363,172.0544;Inherit;False;1346.635;355.3159;Rotator;11;105;127;126;244;130;243;246;248;247;242;245;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;126;-649.3962,215.3238;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PiNode;244;-651.2111,455.162;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;117;-203.4795,-1136.329;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;226;-676.2756,-1086.899;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;118;-477.0981,-1392.054;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;296;-1043.765,-500.7153;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;292;-169.487,794.458;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;127;-471.0774,212.3785;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;243;-1291.245,282.4539;Inherit;False;Constant;_Float0;Float 0;4;0;Create;True;0;0;False;0;False;2;8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;273;478.4158,-1412.389;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;105;-239.1475,214.5261;Inherit;True;Property;_Albedo;Albedo;1;0;Create;True;0;0;False;0;False;-1;None;eee0c039abe4c6344a1f7f2c0a539744;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;109;-409.185,-1020.865;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;291;-306.4136,785.3828;Inherit;False;Constant;_Float3;Float 3;7;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;284;-159.593,1029.417;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;242;-1136.297,216.8867;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;247;-852.6329,217.7089;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;9.596169,1035.81;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;248;-1020.079,429.4506;Inherit;False;Constant;_Float1;Float 1;4;0;Create;True;0;0;False;0;False;2;8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;285;-353.4666,1075.371;Inherit;False;Constant;_Vector3;Vector 3;7;0;Create;True;0;0;False;0;False;10000,10000;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;299;-2353.058,-768.8911;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FractNode;245;-1016.612,215.9233;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;283;31.70565,801.8303;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;295;-1513.093,-550.9874;Inherit;True;Property;_TextureSample1;Texture Sample 1;7;0;Create;True;0;0;False;0;False;-1;None;b80f8e2b5688dcd44a50dfc60f06a432;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;130;-648.5694,334.0821;Inherit;False;Property;_Vector1;Vector 1;3;0;Create;True;0;0;False;0;False;0.3,0.3;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;303;-1707.758,-384.0352;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;298;-2027.135,-740.4716;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;107;-425.9697,-1271.019;Inherit;False;Property;_Vector0;Vector 0;2;0;Create;True;0;0;False;0;False;0.3,0.3;0,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;246;-1291.767,215.7374;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;301;-2216.427,-455.0222;Inherit;False;Property;_Float5;Float 5;8;0;Create;True;0;0;False;0;False;0;2;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;308;-1432.805,-211.0437;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;282;-672.1063,783.9801;Inherit;True;Property;_Float2;Float 2;5;0;Create;True;0;0;False;0;False;0;0;0;100000;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;275;-392.3816,862.8733;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SamplerNode;338;159.8097,-988.2485;Inherit;True;Property;_TextureSample2;Texture Sample 2;10;0;Create;True;0;0;False;0;False;-1;None;3304c1a0c6d6ca54581ea20e4ad9987d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;294;-1372.628,-752.5896;Inherit;True;Property;_TextureSample0;Texture Sample 0;6;0;Create;True;0;0;False;0;False;-1;None;08ed0fb9c3d665e499b941fb9767c82f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleDivideOpNode;297;-1753.118,-653.24;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;300;-2466.966,-637.8573;Inherit;False;Property;_Float4;Float 4;9;0;Create;True;0;0;False;0;False;0;0.5694054;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;9;680.1136,-1013.567;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Glow;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;8;0;332;4
WireConnection;272;0;270;2
WireConnection;272;1;271;0
WireConnection;12;0;8;0
WireConnection;12;1;10;0
WireConnection;244;0;247;0
WireConnection;117;0;118;0
WireConnection;117;2;107;0
WireConnection;117;1;226;0
WireConnection;296;0;294;0
WireConnection;296;1;295;0
WireConnection;296;2;308;0
WireConnection;292;0;275;2
WireConnection;292;1;291;0
WireConnection;127;0;126;0
WireConnection;127;1;130;0
WireConnection;127;2;244;0
WireConnection;273;0;12;0
WireConnection;273;1;272;0
WireConnection;105;1;127;0
WireConnection;284;2;285;0
WireConnection;242;0;246;0
WireConnection;242;1;243;0
WireConnection;247;0;245;0
WireConnection;247;1;248;0
WireConnection;286;0;282;0
WireConnection;286;1;284;0
WireConnection;245;0;242;0
WireConnection;283;0;292;0
WireConnection;283;1;286;0
WireConnection;303;0;300;0
WireConnection;303;1;297;0
WireConnection;298;0;300;0
WireConnection;298;1;299;1
WireConnection;308;0;303;0
WireConnection;297;0;298;0
WireConnection;297;1;301;0
WireConnection;9;0;338;0
WireConnection;9;2;273;0
ASEEND*/
//CHKSM=BA9E84D40A95DCAF7FF9D83D91B8A0CA0363BCBB