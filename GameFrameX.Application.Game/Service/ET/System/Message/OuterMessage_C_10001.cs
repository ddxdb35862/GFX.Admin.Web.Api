using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
//HTTP RouterManager返回Router和Reaml配置对象
	[Message(OuterMessage.HttpGetRouterResponse)]
	[MemoryPackable]
	public partial class HttpGetRouterResponse: MessageObject
	{
		public static HttpGetRouterResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse; 
		}

		[MemoryPackOrder(0)]
		public List<string> Realms { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<string> Routers { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Realms.Clear();
			this.Routers.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RouterSync)]
	[MemoryPackable]
	public partial class RouterSync: MessageObject
	{
		public static RouterSync Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync; 
		}

		[MemoryPackOrder(0)]
		public uint ConnectId { get; set; }

		[MemoryPackOrder(1)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConnectId = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterMessage.C2M_TestRequest)]
	[MemoryPackable]
	public partial class C2M_TestRequest: MessageObject, ILocationRequest
	{
		public static C2M_TestRequest Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string request { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.request = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestResponse)]
	[MemoryPackable]
	public partial class M2C_TestResponse: MessageObject, IResponse
	{
		public static M2C_TestResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string response { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.response = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterMessage.C2G_EnterMap)]
	[MemoryPackable]
	public partial class C2G_EnterMap: MessageObject, ISessionRequest
	{
		public static C2G_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_EnterMap)]
	[MemoryPackable]
	public partial class G2C_EnterMap: MessageObject, ISessionResponse
	{
		public static G2C_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

// 自己unitId
		[MemoryPackOrder(3)]
		public long MyId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MyId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartSceneChange)]
	[MemoryPackable]
	public partial class M2C_StartSceneChange: MessageObject, IMessage
	{
		public static M2C_StartSceneChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange; 
		}

		[MemoryPackOrder(0)]
		public long SceneInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public string SceneName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RemoveUnits)]
	[MemoryPackable]
	public partial class M2C_RemoveUnits: MessageObject, IMessage
	{
		public static M2C_RemoveUnits Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits; 
		}

		[MemoryPackOrder(0)]
		public List<long> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_Stop)]
	[MemoryPackable]
	public partial class C2M_Stop: MessageObject, ILocationMessage
	{
		public static C2M_Stop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterMessage.C2G_Ping)]
	[MemoryPackable]
	public partial class C2G_Ping: MessageObject, ISessionRequest
	{
		public static C2G_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Ping)]
	[MemoryPackable]
	public partial class G2C_Ping: MessageObject, ISessionResponse
	{
		public static G2C_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Test)]
	[MemoryPackable]
	public partial class G2C_Test: MessageObject, ISessionMessage
	{
		public static G2C_Test Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterMessage.C2M_Reload)]
	[MemoryPackable]
	public partial class C2M_Reload: MessageObject, ISessionRequest
	{
		public static C2M_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Reload)]
	[MemoryPackable]
	public partial class M2C_Reload: MessageObject, ISessionResponse
	{
		public static M2C_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterMessage.C2R_Login)]
	[MemoryPackable]
	public partial class C2R_Login: MessageObject, ISessionRequest
	{
		public static C2R_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_Login)]
	[MemoryPackable]
	public partial class R2C_Login: MessageObject, ISessionResponse
	{
		public static R2C_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string IP { get; set; }

		[MemoryPackOrder(4)]
		public int Port { get; set; }

		[MemoryPackOrder(5)]
		public long Key { get; set; }

		[MemoryPackOrder(6)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.IP = default;
			this.Port = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterMessage.C2G_LoginGate)]
	[MemoryPackable]
	public partial class C2G_LoginGate: MessageObject, ISessionRequest
	{
		public static C2G_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_LoginGate)]
	[MemoryPackable]
	public partial class G2C_LoginGate: MessageObject, ISessionResponse
	{
		public static G2C_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_ReLoginGate))]
	[Message(OuterMessage.C2G_ReLoginGate)]
	[MemoryPackable]
	public partial class C2G_ReLoginGate: MessageObject, ISessionRequest
	{
		public static C2G_ReLoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_ReLoginGate), isFromPool) as C2G_ReLoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_ReLoginGate)]
	[MemoryPackable]
	public partial class G2C_ReLoginGate: MessageObject, ISessionResponse
	{
		public static G2C_ReLoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_ReLoginGate), isFromPool) as G2C_ReLoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long NewKey { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.NewKey = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_TestHotfixMessage)]
	[MemoryPackable]
	public partial class G2C_TestHotfixMessage: MessageObject, ISessionMessage
	{
		public static G2C_TestHotfixMessage Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage; 
		}

		[MemoryPackOrder(0)]
		public string Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterMessage.C2M_TestRobotCase)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase: MessageObject, ILocationRequest
	{
		public static C2M_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase: MessageObject, ILocationResponse
	{
		public static M2C_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_TestRobotCase2)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static C2M_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase2)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static M2C_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterMessage.C2M_TransferMap)]
	[MemoryPackable]
	public partial class C2M_TransferMap: MessageObject, ILocationRequest
	{
		public static C2M_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TransferMap)]
	[MemoryPackable]
	public partial class M2C_TransferMap: MessageObject, ILocationResponse
	{
		public static M2C_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Benchmark))]
	[Message(OuterMessage.C2G_Benchmark)]
	[MemoryPackable]
	public partial class C2G_Benchmark: MessageObject, ISessionRequest
	{
		public static C2G_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Benchmark)]
	[MemoryPackable]
	public partial class G2C_Benchmark: MessageObject, ISessionResponse
	{
		public static G2C_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////////////////
//WX相关
	[ResponseType(nameof(R2C_WXLogin))]
	[Message(OuterMessage.C2R_WXLogin)]
	[MemoryPackable]
	public partial class C2R_WXLogin: MessageObject, ISessionRequest
	{
		public static C2R_WXLogin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_WXLogin), isFromPool) as C2R_WXLogin; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Code { get; set; }

		[MemoryPackOrder(2)]
		public string FromRoleId { get; set; }

		[MemoryPackOrder(3)]
		public string ActivityConfigId { get; set; }

		[MemoryPackOrder(4)]
		public bool IsMock { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Code = default;
			this.FromRoleId = default;
			this.ActivityConfigId = default;
			this.IsMock = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_WXLogin)]
	[MemoryPackable]
	public partial class R2C_WXLogin: MessageObject, ISessionResponse
	{
		public static R2C_WXLogin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_WXLogin), isFromPool) as R2C_WXLogin; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string IP { get; set; }

		[MemoryPackOrder(4)]
		public int Port { get; set; }

		[MemoryPackOrder(5)]
		public long Key { get; set; }

		[MemoryPackOrder(6)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.IP = default;
			this.Port = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////////////////
//DY相关
	[ResponseType(nameof(R2C_DYLogin))]
	[Message(OuterMessage.C2R_DYLogin)]
	[MemoryPackable]
	public partial class C2R_DYLogin: MessageObject, ISessionRequest
	{
		public static C2R_DYLogin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_DYLogin), isFromPool) as C2R_DYLogin; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Code { get; set; }

		[MemoryPackOrder(2)]
		public string FromRoleId { get; set; }

		[MemoryPackOrder(3)]
		public string ActivityConfigId { get; set; }

		[MemoryPackOrder(4)]
		public bool IsMock { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Code = default;
			this.FromRoleId = default;
			this.ActivityConfigId = default;
			this.IsMock = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_DYLogin)]
	[MemoryPackable]
	public partial class R2C_DYLogin: MessageObject, ISessionResponse
	{
		public static R2C_DYLogin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_DYLogin), isFromPool) as R2C_DYLogin; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string IP { get; set; }

		[MemoryPackOrder(4)]
		public int Port { get; set; }

		[MemoryPackOrder(5)]
		public long Key { get; set; }

		[MemoryPackOrder(6)]
		public long GateId { get; set; }

		[MemoryPackOrder(7)]
		public string AccountName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.IP = default;
			this.Port = default;
			this.Key = default;
			this.GateId = default;
			this.AccountName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////////////////
//主动断开
	[Message(OuterMessage.R2C_Disconnect)]
	[MemoryPackable]
	public partial class R2C_Disconnect: MessageObject, IMessage
	{
		public static R2C_Disconnect Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_Disconnect), isFromPool) as R2C_Disconnect; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////////////////
//数值变化同步
	[Message(OuterMessage.M2C_NoticeUnitNumeric)]
	[MemoryPackable]
	public partial class M2C_NoticeUnitNumeric: MessageObject, IMessage
	{
		public static M2C_NoticeUnitNumeric Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_NoticeUnitNumeric), isFromPool) as M2C_NoticeUnitNumeric; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int NumericType { get; set; }

		[MemoryPackOrder(3)]
		public long NewValue { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.NumericType = default;
			this.NewValue = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

/////////////////////////////////////////////////////
///Models
	[Message(OuterMessage.AdventureProto)]
	[MemoryPackable]
	public partial class AdventureProto: MessageObject
	{
		public static AdventureProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(AdventureProto), isFromPool) as AdventureProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int Round { get; set; }

		[MemoryPackOrder(3)]
		public int WonTimes { get; set; }

		[MemoryPackOrder(4)]
		public int LostTimes { get; set; }

		[MemoryPackOrder(5)]
		public int Retried { get; set; }

		[MemoryPackOrder(6)]
		public int RemainLife { get; set; }

		[MemoryPackOrder(7)]
		public int WinStreak { get; set; }

		[MemoryPackOrder(8)]
		public long AdventureStartTime { get; set; }

		[MemoryPackOrder(9)]
		public long AdventureEndTime { get; set; }

		[MemoryPackOrder(10)]
		public int State { get; set; }

		[MemoryPackOrder(11)]
		public int Gold { get; set; }

		[MemoryPackOrder(12)]
		public int CareerSkinConfigId { get; set; }

		[MemoryPackOrder(13)]
		public int GainDiamondOneRound { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.Round = default;
			this.WonTimes = default;
			this.LostTimes = default;
			this.Retried = default;
			this.RemainLife = default;
			this.WinStreak = default;
			this.AdventureStartTime = default;
			this.AdventureEndTime = default;
			this.State = default;
			this.Gold = default;
			this.CareerSkinConfigId = default;
			this.GainDiamondOneRound = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.BattleProto)]
	[MemoryPackable]
	public partial class BattleProto: MessageObject
	{
		public static BattleProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(BattleProto), isFromPool) as BattleProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int RoundId { get; set; }

		[MemoryPackOrder(2)]
		public int TimesInRound { get; set; }

		[MemoryPackOrder(3)]
		public int State { get; set; }

		[MemoryPackOrder(4)]
		public uint BattleSeed { get; set; }

		[MemoryPackOrder(5)]
		public long BattleStartTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.RoundId = default;
			this.TimesInRound = default;
			this.State = default;
			this.BattleSeed = default;
			this.BattleStartTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ItemCompositeProto)]
	[MemoryPackable]
	public partial class ItemCompositeProto: MessageObject
	{
		public static ItemCompositeProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ItemCompositeProto), isFromPool) as ItemCompositeProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public long CompositeMainId { get; set; }

		[MemoryPackOrder(2)]
		public int CompositeConfigId { get; set; }

		[MemoryPackOrder(3)]
		public int Completeness { get; set; }

		[MemoryPackOrder(4)]
		public List<long> CompositeItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.CompositeMainId = default;
			this.CompositeConfigId = default;
			this.Completeness = default;
			this.CompositeItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.BattleFormationProto)]
	[MemoryPackable]
	public partial class BattleFormationProto: MessageObject
	{
		public static BattleFormationProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(BattleFormationProto), isFromPool) as BattleFormationProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int RoundId { get; set; }

		[MemoryPackOrder(2)]
		public int PlayerRank { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerUnitId { get; set; }

		[MemoryPackOrder(4)]
		public int PlayerCareerSkinConfigId { get; set; }

		[MemoryPackOrder(5)]
		public List<ItemProto> CapacityLayerItemProtos { get; set; } = new();

		[MemoryPackOrder(6)]
		public List<ItemProto> ItemLayerItemProtos { get; set; } = new();

		[MemoryPackOrder(7)]
		public List<ItemCompositeProto> CompositeGroupIds { get; set; } = new();

		[MemoryPackOrder(8)]
		public bool CanComposite { get; set; }

		[MemoryPackOrder(9)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(10)]
		public string PlayerIcon { get; set; }

		[MemoryPackOrder(11)]
		public List<ItemProto> CareerItemProtos { get; set; } = new();

		[MemoryPackOrder(12)]
		public int DifficultyLevel { get; set; }

		[MemoryPackOrder(13)]
		public long CreateTime { get; set; }

		[MemoryPackOrder(14)]
		public long UpdateTime { get; set; }

		[MemoryPackOrder(15)]
		public long UpdateUserId { get; set; }

		[MemoryPackOrder(16)]
		public int IsDeleted { get; set; }

		[MemoryPackOrder(17)]
		public string Remark { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.RoundId = default;
			this.PlayerRank = default;
			this.PlayerUnitId = default;
			this.PlayerCareerSkinConfigId = default;
			this.CapacityLayerItemProtos.Clear();
			this.ItemLayerItemProtos.Clear();
			this.CompositeGroupIds.Clear();
			this.CanComposite = default;
			this.PlayerName = default;
			this.PlayerIcon = default;
			this.CareerItemProtos.Clear();
			this.DifficultyLevel = default;
			this.CreateTime = default;
			this.UpdateTime = default;
			this.UpdateUserId = default;
			this.IsDeleted = default;
			this.Remark = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RankChange)]
	[MemoryPackable]
	public partial class RankChange: MessageObject
	{
		public static RankChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankChange), isFromPool) as RankChange; 
		}

		[MemoryPackOrder(0)]
		public int OldRank { get; set; }

		[MemoryPackOrder(1)]
		public int NewRank { get; set; }

		[MemoryPackOrder(2)]
		public int OldRankExp { get; set; }

		[MemoryPackOrder(3)]
		public int NewRankExp { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.OldRank = default;
			this.NewRank = default;
			this.OldRankExp = default;
			this.NewRankExp = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PlayerTimedDataProto)]
	[MemoryPackable]
	public partial class PlayerTimedDataProto: MessageObject
	{
		public static PlayerTimedDataProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PlayerTimedDataProto), isFromPool) as PlayerTimedDataProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int Stamina { get; set; }

		[MemoryPackOrder(2)]
		public int MaxStamina { get; set; }

		[MemoryPackOrder(3)]
		public long LastUpdateStamina { get; set; }

		[MemoryPackOrder(4)]
		public long NextRefreshStaminaTime { get; set; }

		[MemoryPackOrder(5)]
		public int ShareTime1Day { get; set; }

		[MemoryPackOrder(6)]
		public int MaxShareTime1Day { get; set; }

		[MemoryPackOrder(7)]
		public int ShowAdForDiamond1Day { get; set; }

		[MemoryPackOrder(8)]
		public int MaxShowAdForDiamond1Day { get; set; }

		[MemoryPackOrder(9)]
		public int GainDiamondOnceAd { get; set; }

		[MemoryPackOrder(10)]
		public string WXAdUnitId { get; set; }

		[MemoryPackOrder(11)]
		public string DYAdUnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Stamina = default;
			this.MaxStamina = default;
			this.LastUpdateStamina = default;
			this.NextRefreshStaminaTime = default;
			this.ShareTime1Day = default;
			this.MaxShareTime1Day = default;
			this.ShowAdForDiamond1Day = default;
			this.MaxShowAdForDiamond1Day = default;
			this.GainDiamondOnceAd = default;
			this.WXAdUnitId = default;
			this.DYAdUnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.CareerProto)]
	[MemoryPackable]
	public partial class CareerProto: MessageObject
	{
		public static CareerProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(CareerProto), isFromPool) as CareerProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public long DefaultCareerSkinId { get; set; }

		[MemoryPackOrder(3)]
		public List<CareerSkinProto> CareerSkinProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.DefaultCareerSkinId = default;
			this.CareerSkinProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.CareerSkinProto)]
	[MemoryPackable]
	public partial class CareerSkinProto: MessageObject
	{
		public static CareerSkinProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(CareerSkinProto), isFromPool) as CareerSkinProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PhotoFrameProto)]
	[MemoryPackable]
	public partial class PhotoFrameProto: MessageObject
	{
		public static PhotoFrameProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PhotoFrameProto), isFromPool) as PhotoFrameProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.AttributeEntryProto)]
	[MemoryPackable]
	public partial class AttributeEntryProto: MessageObject
	{
		public static AttributeEntryProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(AttributeEntryProto), isFromPool) as AttributeEntryProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int Key { get; set; }

		[MemoryPackOrder(2)]
		public long Value { get; set; }

		[MemoryPackOrder(3)]
		public int EntryType { get; set; }

		[MemoryPackOrder(4)]
		public int Score { get; set; }

		[MemoryPackOrder(5)]
		public int EntryLevel { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Key = default;
			this.Value = default;
			this.EntryType = default;
			this.Score = default;
			this.EntryLevel = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ItemProto)]
	[MemoryPackable]
	public partial class ItemProto: MessageObject
	{
		public static ItemProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ItemProto), isFromPool) as ItemProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int CentrePosX { get; set; }

		[MemoryPackOrder(3)]
		public int CentrePosY { get; set; }

		[MemoryPackOrder(4)]
		public int Bag { get; set; }

		[MemoryPackOrder(5)]
		public int Price { get; set; }

		[MemoryPackOrder(6)]
		public int IndexId { get; set; }

		[MemoryPackOrder(7)]
		public bool Locked { get; set; }

		[MemoryPackOrder(8)]
		public bool Discount { get; set; }

		[MemoryPackOrder(9)]
		public bool Sold { get; set; }

		[MemoryPackOrder(10)]
		public long CurrentBelongItemCompositeId { get; set; }

		[MemoryPackOrder(11)]
		public List<long> BelongItemCompositeIds { get; set; } = new();

		[MemoryPackOrder(12)]
		public int Z_Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.CentrePosX = default;
			this.CentrePosY = default;
			this.Bag = default;
			this.Price = default;
			this.IndexId = default;
			this.Locked = default;
			this.Discount = default;
			this.Sold = default;
			this.CurrentBelongItemCompositeId = default;
			this.BelongItemCompositeIds.Clear();
			this.Z_Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ItemsProto)]
	[MemoryPackable]
	public partial class ItemsProto: MessageObject
	{
		public static ItemsProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ItemsProto), isFromPool) as ItemsProto; 
		}

		[MemoryPackOrder(0)]
		public List<ItemProto> ItemProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ItemProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MissionProto)]
	[MemoryPackable]
	public partial class MissionProto: MessageObject
	{
		public static MissionProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MissionProto), isFromPool) as MissionProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int MissionState { get; set; }

		[MemoryPackOrder(3)]
		public int CurrentProcess { get; set; }

		[MemoryPackOrder(4)]
		public int StartTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.MissionState = default;
			this.CurrentProcess = default;
			this.StartTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.ActivityProto)]
	[MemoryPackable]
	public partial class ActivityProto: MessageObject
	{
		public static ActivityProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(ActivityProto), isFromPool) as ActivityProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int ActivityState { get; set; }

		[MemoryPackOrder(3)]
		public int CurrentProcess { get; set; }

		[MemoryPackOrder(4)]
		public List<RoleRelationProto> NewRoleActivityRelations { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.ActivityState = default;
			this.CurrentProcess = default;
			this.NewRoleActivityRelations.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RoleRelationProto)]
	[MemoryPackable]
	public partial class RoleRelationProto: MessageObject
	{
		public static RoleRelationProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RoleRelationProto), isFromPool) as RoleRelationProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public string RoleName { get; set; }

		[MemoryPackOrder(2)]
		public string RoleAvatarUrl { get; set; }

		[MemoryPackOrder(3)]
		public long RoleCreateTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.RoleName = default;
			this.RoleAvatarUrl = default;
			this.RoleCreateTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RoleRelationProtos)]
	[MemoryPackable]
	public partial class RoleRelationProtos: MessageObject
	{
		public static RoleRelationProtos Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RoleRelationProtos), isFromPool) as RoleRelationProtos; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.AllRoleRelationProto)]
	[MemoryPackable]
	public partial class AllRoleRelationProto: MessageObject
	{
		public static AllRoleRelationProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(AllRoleRelationProto), isFromPool) as AllRoleRelationProto; 
		}

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[MemoryPackOrder(0)]
		public Dictionary<int, RoleRelationProtos> data { get; set; } = new();
		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.data.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

/////////////////////////////////////////////////////
///Setting页
	[ResponseType(nameof(M2C_SyncUserInfo))]
	[Message(OuterMessage.C2M_SyncUserInfo)]
	[MemoryPackable]
	public partial class C2M_SyncUserInfo: MessageObject, ILocationRequest
	{
		public static C2M_SyncUserInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SyncUserInfo), isFromPool) as C2M_SyncUserInfo; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string NickName { get; set; }

		[MemoryPackOrder(2)]
		public string AvatarUrl { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.NickName = default;
			this.AvatarUrl = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SyncUserInfo)]
	[MemoryPackable]
	public partial class M2C_SyncUserInfo: MessageObject, ILocationResponse
	{
		public static M2C_SyncUserInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SyncUserInfo), isFromPool) as M2C_SyncUserInfo; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

/////////////////////////////////////////////////////
///首页
	[ResponseType(nameof(M2C_EnterMain))]
	[Message(OuterMessage.C2M_EnterMain)]
	[MemoryPackable]
	public partial class C2M_EnterMain: MessageObject, ILocationRequest
	{
		public static C2M_EnterMain Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EnterMain), isFromPool) as C2M_EnterMain; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EnterMain)]
	[MemoryPackable]
	public partial class M2C_EnterMain: MessageObject, ILocationResponse
	{
		public static M2C_EnterMain Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EnterMain), isFromPool) as M2C_EnterMain; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<int> NewGuides { get; set; } = new();

		[MemoryPackOrder(10)]
		public PlayerTimedDataProto PlayerTimedDataProto { get; set; }

		[MemoryPackOrder(11)]
		public List<CareerProto> CareerProtoList { get; set; } = new();

		[MemoryPackOrder(12)]
		public long DefaultCareerId { get; set; }

		[MemoryPackOrder(13)]
		public List<PhotoFrameProto> PhotoFrameProtoList { get; set; } = new();

		[MemoryPackOrder(14)]
		public long DefaultPhotoFrameId { get; set; }

		[MemoryPackOrder(15)]
		public AdventureProto AdventureProto { get; set; }

		[MemoryPackOrder(16)]
		public int TotalRankAdventureTimes { get; set; }

		[MemoryPackOrder(17)]
		public int TotalNormalAdventureTimes { get; set; }

		[MemoryPackOrder(18)]
		public int LastAdventureMode { get; set; }

		[MemoryPackOrder(19)]
		public RankInfo2Proto RankInfo2Proto { get; set; }

		[MemoryPackOrder(20)]
		public int Top100Rank { get; set; }

		[MemoryPackOrder(21)]
		public int PermilleRank { get; set; }

		[MemoryPackOrder(22)]
		public List<MissionProto> MissionProtoList { get; set; } = new();

		[MemoryPackOrder(23)]
		public BattleProto BattleProto { get; set; }

		[MemoryPackOrder(24)]
		public List<ActivityProto> ActivityProtoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.NewGuides.Clear();
			this.PlayerTimedDataProto = default;
			this.CareerProtoList.Clear();
			this.DefaultCareerId = default;
			this.PhotoFrameProtoList.Clear();
			this.DefaultPhotoFrameId = default;
			this.AdventureProto = default;
			this.TotalRankAdventureTimes = default;
			this.TotalNormalAdventureTimes = default;
			this.LastAdventureMode = default;
			this.RankInfo2Proto = default;
			this.Top100Rank = default;
			this.PermilleRank = default;
			this.MissionProtoList.Clear();
			this.BattleProto = default;
			this.ActivityProtoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StaminaChange)]
	[MemoryPackable]
	public partial class M2C_StaminaChange: MessageObject, IMessage
	{
		public static M2C_StaminaChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StaminaChange), isFromPool) as M2C_StaminaChange; 
		}

		[MemoryPackOrder(0)]
		public PlayerTimedDataProto PlayerTimedDataProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerTimedDataProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ShareTimeChange)]
	[MemoryPackable]
	public partial class M2C_ShareTimeChange: MessageObject, IMessage
	{
		public static M2C_ShareTimeChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ShareTimeChange), isFromPool) as M2C_ShareTimeChange; 
		}

		[MemoryPackOrder(0)]
		public PlayerTimedDataProto PlayerTimedDataProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerTimedDataProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ShowAdForDiamondChange)]
	[MemoryPackable]
	public partial class M2C_ShowAdForDiamondChange: MessageObject, IMessage
	{
		public static M2C_ShowAdForDiamondChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ShowAdForDiamondChange), isFromPool) as M2C_ShowAdForDiamondChange; 
		}

		[MemoryPackOrder(0)]
		public PlayerTimedDataProto PlayerTimedDataProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerTimedDataProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_CloseAdventure))]
	[Message(OuterMessage.C2M_CloseAdventure)]
	[MemoryPackable]
	public partial class C2M_CloseAdventure: MessageObject, ILocationRequest
	{
		public static C2M_CloseAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_CloseAdventure), isFromPool) as C2M_CloseAdventure; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CloseAdventure)]
	[MemoryPackable]
	public partial class M2C_CloseAdventure: MessageObject, ILocationResponse
	{
		public static M2C_CloseAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CloseAdventure), isFromPool) as M2C_CloseAdventure; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int TotalRankAdventureTimes { get; set; }

		[MemoryPackOrder(1)]
		public int TotalNormalAdventureTimes { get; set; }

		[MemoryPackOrder(2)]
		public int LastAdventureMode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.TotalRankAdventureTimes = default;
			this.TotalNormalAdventureTimes = default;
			this.LastAdventureMode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_UpdateNewGuide))]
	[Message(OuterMessage.C2M_UpdateNewGuide)]
	[MemoryPackable]
	public partial class C2M_UpdateNewGuide: MessageObject, ILocationRequest
	{
		public static C2M_UpdateNewGuide Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UpdateNewGuide), isFromPool) as C2M_UpdateNewGuide; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int GroupId { get; set; }

		[MemoryPackOrder(2)]
		public int Step { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GroupId = default;
			this.Step = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UpdateNewGuide)]
	[MemoryPackable]
	public partial class M2C_UpdateNewGuide: MessageObject, ILocationResponse
	{
		public static M2C_UpdateNewGuide Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UpdateNewGuide), isFromPool) as M2C_UpdateNewGuide; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_FinishNewGuide)]
	[MemoryPackable]
	public partial class M2C_FinishNewGuide: MessageObject, IMessage
	{
		public static M2C_FinishNewGuide Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_FinishNewGuide), isFromPool) as M2C_FinishNewGuide; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int GroupId { get; set; }

		[MemoryPackOrder(2)]
		public int Step { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GroupId = default;
			this.Step = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GainRewardBySource))]
	[Message(OuterMessage.C2M_GainRewardBySource)]
	[MemoryPackable]
	public partial class C2M_GainRewardBySource: MessageObject, ILocationRequest
	{
		public static C2M_GainRewardBySource Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GainRewardBySource), isFromPool) as C2M_GainRewardBySource; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int GainRewardSource { get; set; }

		[MemoryPackOrder(2)]
		public int RewardType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.GainRewardSource = default;
			this.RewardType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GainRewardBySource)]
	[MemoryPackable]
	public partial class M2C_GainRewardBySource: MessageObject, ILocationResponse
	{
		public static M2C_GainRewardBySource Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GainRewardBySource), isFromPool) as M2C_GainRewardBySource; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

/////////////////////////////////////////////////////
///Adventure
	[ResponseType(nameof(M2C_NewAdventure))]
	[Message(OuterMessage.C2M_NewAdventure)]
	[MemoryPackable]
	public partial class C2M_NewAdventure: MessageObject, ILocationRequest
	{
		public static C2M_NewAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_NewAdventure), isFromPool) as C2M_NewAdventure; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int AdventureConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int CareerSkinConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdventureConfigId = default;
			this.CareerSkinConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_NewAdventure)]
	[MemoryPackable]
	public partial class M2C_NewAdventure: MessageObject, ILocationResponse
	{
		public static M2C_NewAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_NewAdventure), isFromPool) as M2C_NewAdventure; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public AdventureProto AdventureProto { get; set; }

		[MemoryPackOrder(1)]
		public BattleProto BattleProto { get; set; }

		[MemoryPackOrder(2)]
		public BattleFormationProto PlayerFormation { get; set; }

		[MemoryPackOrder(3)]
		public List<ItemProto> ShopItemProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.AdventureProto = default;
			this.BattleProto = default;
			this.PlayerFormation = default;
			this.ShopItemProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ManualRefreshShop))]
	[Message(OuterMessage.C2M_ManualRefreshShop)]
	[MemoryPackable]
	public partial class C2M_ManualRefreshShop: MessageObject, ILocationRequest
	{
		public static C2M_ManualRefreshShop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ManualRefreshShop), isFromPool) as C2M_ManualRefreshShop; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long BattleId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BattleId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ManualRefreshShop)]
	[MemoryPackable]
	public partial class M2C_ManualRefreshShop: MessageObject, ILocationResponse
	{
		public static M2C_ManualRefreshShop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ManualRefreshShop), isFromPool) as M2C_ManualRefreshShop; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<ItemProto> ShopItemProtos { get; set; } = new();

		[MemoryPackOrder(1)]
		public int Gold { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ShopItemProtos.Clear();
			this.Gold = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ToggleLock))]
	[Message(OuterMessage.C2M_ToggleLock)]
	[MemoryPackable]
	public partial class C2M_ToggleLock: MessageObject, ILocationRequest
	{
		public static C2M_ToggleLock Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ToggleLock), isFromPool) as C2M_ToggleLock; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int IndexId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.IndexId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ToggleLock)]
	[MemoryPackable]
	public partial class M2C_ToggleLock: MessageObject, ILocationResponse
	{
		public static M2C_ToggleLock Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ToggleLock), isFromPool) as M2C_ToggleLock; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BuyShopItem))]
	[Message(OuterMessage.C2M_BuyShopItem)]
	[MemoryPackable]
	public partial class C2M_BuyShopItem: MessageObject, ILocationRequest
	{
		public static C2M_BuyShopItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BuyShopItem), isFromPool) as C2M_BuyShopItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int IndexId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.IndexId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuyShopItem)]
	[MemoryPackable]
	public partial class M2C_BuyShopItem: MessageObject, ILocationResponse
	{
		public static M2C_BuyShopItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuyShopItem), isFromPool) as M2C_BuyShopItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ItemProto ItemProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ItemProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_SellItem))]
	[Message(OuterMessage.C2M_SellItem)]
	[MemoryPackable]
	public partial class C2M_SellItem: MessageObject, ILocationRequest
	{
		public static C2M_SellItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SellItem), isFromPool) as C2M_SellItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long ItemId { get; set; }

		[MemoryPackOrder(2)]
		public int Bag { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemId = default;
			this.Bag = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SellItem)]
	[MemoryPackable]
	public partial class M2C_SellItem: MessageObject, ILocationResponse
	{
		public static M2C_SellItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SellItem), isFromPool) as M2C_SellItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public int Gold { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Gold = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChangeItem))]
	[Message(OuterMessage.C2M_ChangeItem)]
	[MemoryPackable]
	public partial class C2M_ChangeItem: MessageObject, ILocationRequest
	{
		public static C2M_ChangeItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChangeItem), isFromPool) as C2M_ChangeItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long ItemId { get; set; }

		[MemoryPackOrder(2)]
		public int Bag { get; set; }

		[MemoryPackOrder(3)]
		public int CentrePosX { get; set; }

		[MemoryPackOrder(4)]
		public int CentrePosY { get; set; }

		[MemoryPackOrder(5)]
		public List<long> ItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemId = default;
			this.Bag = default;
			this.CentrePosX = default;
			this.CentrePosY = default;
			this.ItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChangeItem)]
	[MemoryPackable]
	public partial class M2C_ChangeItem: MessageObject, ILocationResponse
	{
		public static M2C_ChangeItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChangeItem), isFromPool) as M2C_ChangeItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_UnloadItem))]
	[Message(OuterMessage.C2M_UnloadItem)]
	[MemoryPackable]
	public partial class C2M_UnloadItem: MessageObject, ILocationRequest
	{
		public static C2M_UnloadItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_UnloadItem), isFromPool) as C2M_UnloadItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> ItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_UnloadItem)]
	[MemoryPackable]
	public partial class M2C_UnloadItem: MessageObject, ILocationResponse
	{
		public static M2C_UnloadItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UnloadItem), isFromPool) as M2C_UnloadItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_Composite))]
	[Message(OuterMessage.C2M_Composite)]
	[MemoryPackable]
	public partial class C2M_Composite: MessageObject, ILocationRequest
	{
		public static C2M_Composite Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Composite), isFromPool) as C2M_Composite; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Composite)]
	[MemoryPackable]
	public partial class M2C_Composite: MessageObject, ILocationResponse
	{
		public static M2C_Composite Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Composite), isFromPool) as M2C_Composite; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<ItemProto> NewItemProtos { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<ItemsProto> OldItemsProtos { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<long> OldItemCompositeIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.NewItemProtos.Clear();
			this.OldItemsProtos.Clear();
			this.OldItemCompositeIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_RotateItem))]
	[Message(OuterMessage.C2M_RotateItem)]
	[MemoryPackable]
	public partial class C2M_RotateItem: MessageObject, ILocationRequest
	{
		public static C2M_RotateItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RotateItem), isFromPool) as C2M_RotateItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long ItemId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RotateItem)]
	[MemoryPackable]
	public partial class M2C_RotateItem: MessageObject, ILocationResponse
	{
		public static M2C_RotateItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RotateItem), isFromPool) as M2C_RotateItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public ItemProto ItemProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ItemProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StartAdventure))]
	[Message(OuterMessage.C2M_StartAdventure)]
	[MemoryPackable]
	public partial class C2M_StartAdventure: MessageObject, ILocationRequest
	{
		public static C2M_StartAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StartAdventure), isFromPool) as C2M_StartAdventure; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long AdventureId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdventureId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartAdventure)]
	[MemoryPackable]
	public partial class M2C_StartAdventure: MessageObject, ILocationResponse
	{
		public static M2C_StartAdventure Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartAdventure), isFromPool) as M2C_StartAdventure; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public AdventureProto AdventureProto { get; set; }

		[MemoryPackOrder(1)]
		public BattleProto BattleProto { get; set; }

		[MemoryPackOrder(2)]
		public BattleFormationProto PlayerFormation { get; set; }

		[MemoryPackOrder(3)]
		public List<ItemProto> ShopItemProtos { get; set; } = new();

		[MemoryPackOrder(4)]
		public List<long> ShopBagSortedItemIds { get; set; } = new();

		[MemoryPackOrder(5)]
		public List<ItemProto> ShopBagItemProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.AdventureProto = default;
			this.BattleProto = default;
			this.PlayerFormation = default;
			this.ShopItemProtos.Clear();
			this.ShopBagSortedItemIds.Clear();
			this.ShopBagItemProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////
///Battle
	[Message(OuterMessage.M2C_EndGameSettle)]
	[MemoryPackable]
	public partial class M2C_EndGameSettle: MessageObject, IMessage
	{
		public static M2C_EndGameSettle Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EndGameSettle), isFromPool) as M2C_EndGameSettle; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long AdventureId { get; set; }

		[MemoryPackOrder(2)]
		public int TotalRoundsToWin { get; set; }

		[MemoryPackOrder(3)]
		public int RoundsWon { get; set; }

		[MemoryPackOrder(4)]
		public int TotalLife { get; set; }

		[MemoryPackOrder(5)]
		public int RemainLife { get; set; }

		[MemoryPackOrder(6)]
		public int BattleState { get; set; }

		[MemoryPackOrder(7)]
		public int AdventureState { get; set; }

		[MemoryPackOrder(8)]
		public bool IsAdventureEnd { get; set; }

		[MemoryPackOrder(9)]
		public int RoundGold { get; set; }

		[MemoryPackOrder(10)]
		public int WinStreakTimes { get; set; }

		[MemoryPackOrder(11)]
		public int WinStreakGold { get; set; }

		[MemoryPackOrder(12)]
		public int ItemCounts { get; set; }

		[MemoryPackOrder(13)]
		public int ItemGold { get; set; }

		[MemoryPackOrder(14)]
		public RankChange RankChange { get; set; }

		[MemoryPackOrder(15)]
		public long BattleId { get; set; }

		[MemoryPackOrder(16)]
		public bool CanContinue { get; set; }

		[MemoryPackOrder(17)]
		public bool ShowReport { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdventureId = default;
			this.TotalRoundsToWin = default;
			this.RoundsWon = default;
			this.TotalLife = default;
			this.RemainLife = default;
			this.BattleState = default;
			this.AdventureState = default;
			this.IsAdventureEnd = default;
			this.RoundGold = default;
			this.WinStreakTimes = default;
			this.WinStreakGold = default;
			this.ItemCounts = default;
			this.ItemGold = default;
			this.RankChange = default;
			this.BattleId = default;
			this.CanContinue = default;
			this.ShowReport = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_AdventureUpdate)]
	[MemoryPackable]
	public partial class M2C_AdventureUpdate: MessageObject, IMessage
	{
		public static M2C_AdventureUpdate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_AdventureUpdate), isFromPool) as M2C_AdventureUpdate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long AdventureId { get; set; }

		[MemoryPackOrder(2)]
		public int AdventureState { get; set; }

		[MemoryPackOrder(2)]
		public int RemainLife { get; set; }

		[MemoryPackOrder(3)]
		public int Retried { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdventureId = default;
			this.AdventureState = default;
			this.RemainLife = default;
			this.Retried = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_NewBattle)]
	[MemoryPackable]
	public partial class M2C_NewBattle: MessageObject, IMessage
	{
		public static M2C_NewBattle Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_NewBattle), isFromPool) as M2C_NewBattle; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long BattleId { get; set; }

		[MemoryPackOrder(2)]
		public int RoundConifgId { get; set; }

		[MemoryPackOrder(3)]
		public uint BattleSeed { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BattleId = default;
			this.RoundConifgId = default;
			this.BattleSeed = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_EndRound))]
	[Message(OuterMessage.C2M_EndRound)]
	[MemoryPackable]
	public partial class C2M_EndRound: MessageObject, ILocationRequest
	{
		public static C2M_EndRound Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_EndRound), isFromPool) as C2M_EndRound; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long BattleId { get; set; }

		[MemoryPackOrder(2)]
		public uint BattleSeed { get; set; }

		[MemoryPackOrder(3)]
		public int BattleState { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BattleId = default;
			this.BattleSeed = default;
			this.BattleState = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_EndRound)]
	[MemoryPackable]
	public partial class M2C_EndRound: MessageObject, ILocationResponse
	{
		public static M2C_EndRound Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_EndRound), isFromPool) as M2C_EndRound; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public bool IsAdventureEnd { get; set; }

		[MemoryPackOrder(1)]
		public bool CanContinue { get; set; }

		[MemoryPackOrder(2)]
		public AdventureProto AdventureProto { get; set; }

		[MemoryPackOrder(3)]
		public BattleProto BattleProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.IsAdventureEnd = default;
			this.CanContinue = default;
			this.AdventureProto = default;
			this.BattleProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_StartRound))]
	[Message(OuterMessage.C2M_StartRound)]
	[MemoryPackable]
	public partial class C2M_StartRound: MessageObject, ILocationRequest
	{
		public static C2M_StartRound Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_StartRound), isFromPool) as C2M_StartRound; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long BattleId { get; set; }

		[MemoryPackOrder(2)]
		public string AdId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.BattleId = default;
			this.AdId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartRound)]
	[MemoryPackable]
	public partial class M2C_StartRound: MessageObject, ILocationResponse
	{
		public static M2C_StartRound Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartRound), isFromPool) as M2C_StartRound; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public BattleProto BattleProto { get; set; }

		[MemoryPackOrder(1)]
		public BattleFormationProto PlayerFormation { get; set; }

		[MemoryPackOrder(2)]
		public BattleFormationProto OpponentFormation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.BattleProto = default;
			this.PlayerFormation = default;
			this.OpponentFormation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_WaitToLostConfirm))]
	[Message(OuterMessage.C2M_WaitToLostConfirm)]
	[MemoryPackable]
	public partial class C2M_WaitToLostConfirm: MessageObject, ILocationRequest
	{
		public static C2M_WaitToLostConfirm Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_WaitToLostConfirm), isFromPool) as C2M_WaitToLostConfirm; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long AdventureId { get; set; }

		[MemoryPackOrder(2)]
		public long BattleId { get; set; }

		[MemoryPackOrder(3)]
		public int GainRewardSource { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdventureId = default;
			this.BattleId = default;
			this.GainRewardSource = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_WaitToLostConfirm)]
	[MemoryPackable]
	public partial class M2C_WaitToLostConfirm: MessageObject, ILocationResponse
	{
		public static M2C_WaitToLostConfirm Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_WaitToLostConfirm), isFromPool) as M2C_WaitToLostConfirm; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////
///Rank
	[Message(OuterMessage.RankInfo2Proto)]
	[MemoryPackable]
	public partial class RankInfo2Proto: MessageObject
	{
		public static RankInfo2Proto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RankInfo2Proto), isFromPool) as RankInfo2Proto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int Score { get; set; }

		[MemoryPackOrder(2)]
		public int RankLevel { get; set; }

		[MemoryPackOrder(3)]
		public string Name { get; set; }

		[MemoryPackOrder(4)]
		public string Photo { get; set; }

		[MemoryPackOrder(5)]
		public int PhotoFrameConfigId { get; set; }

		[MemoryPackOrder(6)]
		public int ProvinceId { get; set; }

		[MemoryPackOrder(7)]
		public int CityId { get; set; }

		[MemoryPackOrder(8)]
		public int DistrictId { get; set; }

		[MemoryPackOrder(9)]
		public int CareerSkinConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Score = default;
			this.RankLevel = default;
			this.Name = default;
			this.Photo = default;
			this.PhotoFrameConfigId = default;
			this.ProvinceId = default;
			this.CityId = default;
			this.DistrictId = default;
			this.CareerSkinConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GetTopRanksInfo2))]
	[Message(OuterMessage.C2M_GetTopRanksInfo2)]
	[MemoryPackable]
	public partial class C2M_GetTopRanksInfo2: MessageObject, ILocationRequest
	{
		public static C2M_GetTopRanksInfo2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GetTopRanksInfo2), isFromPool) as C2M_GetTopRanksInfo2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int ProvinceId { get; set; }

		[MemoryPackOrder(2)]
		public int CityId { get; set; }

		[MemoryPackOrder(3)]
		public int DistrictId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ProvinceId = default;
			this.CityId = default;
			this.DistrictId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GetTopRanksInfo2)]
	[MemoryPackable]
	public partial class M2C_GetTopRanksInfo2: MessageObject, ILocationResponse
	{
		public static M2C_GetTopRanksInfo2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GetTopRanksInfo2), isFromPool) as M2C_GetTopRanksInfo2; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<RankInfo2Proto> RankInfo2ProtoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankInfo2ProtoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GetPlayerRanksInfo2))]
	[Message(OuterMessage.C2M_GetPlayerRanksInfo2)]
	[MemoryPackable]
	public partial class C2M_GetPlayerRanksInfo2: MessageObject, ILocationRequest
	{
		public static C2M_GetPlayerRanksInfo2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GetPlayerRanksInfo2), isFromPool) as C2M_GetPlayerRanksInfo2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GetPlayerRanksInfo2)]
	[MemoryPackable]
	public partial class M2C_GetPlayerRanksInfo2: MessageObject, ILocationResponse
	{
		public static M2C_GetPlayerRanksInfo2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GetPlayerRanksInfo2), isFromPool) as M2C_GetPlayerRanksInfo2; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public RankInfo2Proto RankInfo2Proto { get; set; }

		[MemoryPackOrder(1)]
		public int Top100Rank { get; set; }

		[MemoryPackOrder(2)]
		public int PermilleRank { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.RankInfo2Proto = default;
			this.Top100Rank = default;
			this.PermilleRank = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////
///Market
	[ResponseType(nameof(M2C_BuyCareer))]
	[Message(OuterMessage.C2M_BuyCareer)]
	[MemoryPackable]
	public partial class C2M_BuyCareer: MessageObject, ILocationRequest
	{
		public static C2M_BuyCareer Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BuyCareer), isFromPool) as C2M_BuyCareer; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CareerConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CareerConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuyCareer)]
	[MemoryPackable]
	public partial class M2C_BuyCareer: MessageObject, ILocationResponse
	{
		public static M2C_BuyCareer Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuyCareer), isFromPool) as M2C_BuyCareer; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BuyCareerSkin))]
	[Message(OuterMessage.C2M_BuyCareerSkin)]
	[MemoryPackable]
	public partial class C2M_BuyCareerSkin: MessageObject, ILocationRequest
	{
		public static C2M_BuyCareerSkin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BuyCareerSkin), isFromPool) as C2M_BuyCareerSkin; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int CareerSkinConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CareerSkinConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuyCareerSkin)]
	[MemoryPackable]
	public partial class M2C_BuyCareerSkin: MessageObject, ILocationResponse
	{
		public static M2C_BuyCareerSkin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuyCareerSkin), isFromPool) as M2C_BuyCareerSkin; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_BuyPhotoFrame))]
	[Message(OuterMessage.C2M_BuyPhotoFrame)]
	[MemoryPackable]
	public partial class C2M_BuyPhotoFrame: MessageObject, ILocationRequest
	{
		public static C2M_BuyPhotoFrame Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_BuyPhotoFrame), isFromPool) as C2M_BuyPhotoFrame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int PhotoFrameConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PhotoFrameConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuyPhotoFrame)]
	[MemoryPackable]
	public partial class M2C_BuyPhotoFrame: MessageObject, ILocationResponse
	{
		public static M2C_BuyPhotoFrame Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuyPhotoFrame), isFromPool) as M2C_BuyPhotoFrame; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ChangePhotoFrame))]
	[Message(OuterMessage.C2M_ChangePhotoFrame)]
	[MemoryPackable]
	public partial class C2M_ChangePhotoFrame: MessageObject, ILocationRequest
	{
		public static C2M_ChangePhotoFrame Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ChangePhotoFrame), isFromPool) as C2M_ChangePhotoFrame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int PhotoFrameConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PhotoFrameConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChangePhotoFrame)]
	[MemoryPackable]
	public partial class M2C_ChangePhotoFrame: MessageObject, ILocationResponse
	{
		public static M2C_ChangePhotoFrame Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChangePhotoFrame), isFromPool) as M2C_ChangePhotoFrame; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveCareer)]
	[MemoryPackable]
	public partial class M2C_ReceiveCareer: MessageObject, IMessage
	{
		public static M2C_ReceiveCareer Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveCareer), isFromPool) as M2C_ReceiveCareer; 
		}

		[MemoryPackOrder(0)]
		public CareerProto CareerProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.CareerProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveCareerSkin)]
	[MemoryPackable]
	public partial class M2C_ReceiveCareerSkin: MessageObject, IMessage
	{
		public static M2C_ReceiveCareerSkin Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveCareerSkin), isFromPool) as M2C_ReceiveCareerSkin; 
		}

		[MemoryPackOrder(0)]
		public int CareerConfigId { get; set; }

		[MemoryPackOrder(1)]
		public CareerSkinProto CareerSkinProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.CareerConfigId = default;
			this.CareerSkinProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceivePhotoFrame)]
	[MemoryPackable]
	public partial class M2C_ReceivePhotoFrame: MessageObject, IMessage
	{
		public static M2C_ReceivePhotoFrame Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceivePhotoFrame), isFromPool) as M2C_ReceivePhotoFrame; 
		}

		[MemoryPackOrder(0)]
		public PhotoFrameProto PhotoFrameProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PhotoFrameProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveCommonReward)]
	[MemoryPackable]
	public partial class M2C_ReceiveCommonReward: MessageObject, IMessage
	{
		public static M2C_ReceiveCommonReward Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveCommonReward), isFromPool) as M2C_ReceiveCommonReward; 
		}

		[MemoryPackOrder(0)]
		public int RewardType { get; set; }

		[MemoryPackOrder(1)]
		public int RewardCount { get; set; }

		[MemoryPackOrder(2)]
		public int LateShowPoint { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RewardType = default;
			this.RewardCount = default;
			this.LateShowPoint = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////////////
///Mission
	[Message(OuterMessage.M2C_UpdateMission)]
	[MemoryPackable]
	public partial class M2C_UpdateMission: MessageObject, IMessage
	{
		public static M2C_UpdateMission Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_UpdateMission), isFromPool) as M2C_UpdateMission; 
		}

		[MemoryPackOrder(0)]
		public MissionProto MissionProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MissionProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GetAllRunningMission))]
	[Message(OuterMessage.C2M_GetAllRunningMission)]
	[MemoryPackable]
	public partial class C2M_GetAllRunningMission: MessageObject, ILocationRequest
	{
		public static C2M_GetAllRunningMission Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GetAllRunningMission), isFromPool) as C2M_GetAllRunningMission; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GetAllRunningMission)]
	[MemoryPackable]
	public partial class M2C_GetAllRunningMission: MessageObject, ILocationResponse
	{
		public static M2C_GetAllRunningMission Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GetAllRunningMission), isFromPool) as M2C_GetAllRunningMission; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MissionProto> MissionProtoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MissionProtoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ReceiveMissionReward))]
	[Message(OuterMessage.C2M_ReceiveMissionReward)]
	[MemoryPackable]
	public partial class C2M_ReceiveMissionReward: MessageObject, ILocationRequest
	{
		public static C2M_ReceiveMissionReward Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ReceiveMissionReward), isFromPool) as C2M_ReceiveMissionReward; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long MissionId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MissionId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveMissionReward)]
	[MemoryPackable]
	public partial class M2C_ReceiveMissionReward: MessageObject, ILocationResponse
	{
		public static M2C_ReceiveMissionReward Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveMissionReward), isFromPool) as M2C_ReceiveMissionReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<MissionProto> MissionProtoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MissionProtoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////
//活动
	[Message(OuterMessage.M2C_ActivityNewRoleRelation)]
	[MemoryPackable]
	public partial class M2C_ActivityNewRoleRelation: MessageObject, IMessage
	{
		public static M2C_ActivityNewRoleRelation Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ActivityNewRoleRelation), isFromPool) as M2C_ActivityNewRoleRelation; 
		}

		[MemoryPackOrder(0)]
		public ActivityProto ActivityProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ActivityProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_GetAllRunningActivity))]
	[Message(OuterMessage.C2M_GetAllRunningActivity)]
	[MemoryPackable]
	public partial class C2M_GetAllRunningActivity: MessageObject, ILocationRequest
	{
		public static C2M_GetAllRunningActivity Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_GetAllRunningActivity), isFromPool) as C2M_GetAllRunningActivity; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_GetAllRunningActivity)]
	[MemoryPackable]
	public partial class M2C_GetAllRunningActivity: MessageObject, ILocationResponse
	{
		public static M2C_GetAllRunningActivity Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_GetAllRunningActivity), isFromPool) as M2C_GetAllRunningActivity; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		[MemoryPackOrder(0)]
		public List<ActivityProto> ActivityProtoList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ActivityProtoList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ReceiveActivityReward))]
	[Message(OuterMessage.C2M_ReceiveActivityReward)]
	[MemoryPackable]
	public partial class C2M_ReceiveActivityReward: MessageObject, ILocationRequest
	{
		public static C2M_ReceiveActivityReward Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ReceiveActivityReward), isFromPool) as C2M_ReceiveActivityReward; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long ActivityId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ActivityId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ReceiveActivityReward)]
	[MemoryPackable]
	public partial class M2C_ReceiveActivityReward: MessageObject, ILocationResponse
	{
		public static M2C_ReceiveActivityReward Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveActivityReward), isFromPool) as M2C_ReceiveActivityReward; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

/////////////////////////////////////////////////////
///广告页
	[ResponseType(nameof(M2C_RequestRewards))]
	[Message(OuterMessage.C2M_RequestRewards)]
	[MemoryPackable]
	public partial class C2M_RequestRewards: MessageObject, ILocationRequest
	{
		public static C2M_RequestRewards Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_RequestRewards), isFromPool) as C2M_RequestRewards; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int AdWeavingPoint { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.AdWeavingPoint = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RequestRewards)]
	[MemoryPackable]
	public partial class M2C_RequestRewards: MessageObject, ILocationResponse
	{
		public static M2C_RequestRewards Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RequestRewards), isFromPool) as M2C_RequestRewards; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////
//HTTP
//指定匹配的规则的阵容关系
	[Message(OuterMessage.AdventureMatchAOProto)]
	[MemoryPackable]
	public partial class AdventureMatchAOProto: MessageObject
	{
		public static AdventureMatchAOProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(AdventureMatchAOProto), isFromPool) as AdventureMatchAOProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int AdventureMode { get; set; }

		[MemoryPackOrder(2)]
		public int AdventureTime { get; set; }

		[MemoryPackOrder(3)]
		public int RoundId { get; set; }

		[MemoryPackOrder(4)]
		public long FormationId { get; set; }

		[MemoryPackOrder(5)]
		public string? FormationRemark { get; set; }

		[MemoryPackOrder(6)]
		public string? Remark { get; set; }

		[MemoryPackOrder(13)]
		public long CreateTime { get; set; }

		[MemoryPackOrder(14)]
		public long UpdateTime { get; set; }

		[MemoryPackOrder(15)]
		public long UpdateUserId { get; set; }

		[MemoryPackOrder(16)]
		public int IsDeleted { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.AdventureMode = default;
			this.AdventureTime = default;
			this.RoundId = default;
			this.FormationId = default;
			this.FormationRemark = default;
			this.Remark = default;
			this.CreateTime = default;
			this.UpdateTime = default;
			this.UpdateUserId = default;
			this.IsDeleted = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//通用返回
	[Message(OuterMessage.HttpCommonResponse)]
	[MemoryPackable]
	public partial class HttpCommonResponse: MessageObject
	{
		public static HttpCommonResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpCommonResponse), isFromPool) as HttpCommonResponse; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public string Body { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Message = default;
			this.Body = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//HTTP Manager返回查询需要的阵容对象s
	[Message(OuterMessage.HttpGetPoolFormationsResponse)]
	[MemoryPackable]
	public partial class HttpGetPoolFormationsResponse: MessageObject
	{
		public static HttpGetPoolFormationsResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetPoolFormationsResponse), isFromPool) as HttpGetPoolFormationsResponse; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public List<BattleFormationProto> BattleFormationProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Message = default;
			this.BattleFormationProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//HTTP Manager返回查询需要的阵容对象
	[Message(OuterMessage.HttpGetPoolFormationResponse)]
	[MemoryPackable]
	public partial class HttpGetPoolFormationResponse: MessageObject
	{
		public static HttpGetPoolFormationResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetPoolFormationResponse), isFromPool) as HttpGetPoolFormationResponse; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public BattleFormationProto BattleFormationProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Message = default;
			this.BattleFormationProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.HttpGetAdventureMatchAOsResponse)]
	[MemoryPackable]
	public partial class HttpGetAdventureMatchAOsResponse: MessageObject
	{
		public static HttpGetAdventureMatchAOsResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetAdventureMatchAOsResponse), isFromPool) as HttpGetAdventureMatchAOsResponse; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public List<AdventureMatchAOProto> AdventureMatchAOProtos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Message = default;
			this.AdventureMatchAOProtos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.HttpGetAdventureMatchAOResponse)]
	[MemoryPackable]
	public partial class HttpGetAdventureMatchAOResponse: MessageObject
	{
		public static HttpGetAdventureMatchAOResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetAdventureMatchAOResponse), isFromPool) as HttpGetAdventureMatchAOResponse; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public string Message { get; set; }

		[MemoryPackOrder(2)]
		public AdventureMatchAOProto AdventureMatchAOProto { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Message = default;
			this.AdventureMatchAOProto = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//////////////////////////////////
//其他
	public static class OuterMessage
	{
		 public const ushort HttpGetRouterResponse = 10002;
		 public const ushort RouterSync = 10003;
		 public const ushort C2M_TestRequest = 10004;
		 public const ushort M2C_TestResponse = 10005;
		 public const ushort C2G_EnterMap = 10006;
		 public const ushort G2C_EnterMap = 10007;
		 public const ushort MoveInfo = 10008;
		 public const ushort UnitInfo = 10009;
		 public const ushort M2C_CreateUnits = 10010;
		 public const ushort M2C_CreateMyUnit = 10011;
		 public const ushort M2C_StartSceneChange = 10012;
		 public const ushort M2C_RemoveUnits = 10013;
		 public const ushort C2M_PathfindingResult = 10014;
		 public const ushort C2M_Stop = 10015;
		 public const ushort M2C_PathfindingResult = 10016;
		 public const ushort M2C_Stop = 10017;
		 public const ushort C2G_Ping = 10018;
		 public const ushort G2C_Ping = 10019;
		 public const ushort G2C_Test = 10020;
		 public const ushort C2M_Reload = 10021;
		 public const ushort M2C_Reload = 10022;
		 public const ushort C2R_Login = 10023;
		 public const ushort R2C_Login = 10024;
		 public const ushort C2G_LoginGate = 10025;
		 public const ushort G2C_LoginGate = 10026;
		 public const ushort C2G_ReLoginGate = 10027;
		 public const ushort G2C_ReLoginGate = 10028;
		 public const ushort G2C_TestHotfixMessage = 10029;
		 public const ushort C2M_TestRobotCase = 10030;
		 public const ushort M2C_TestRobotCase = 10031;
		 public const ushort C2M_TestRobotCase2 = 10032;
		 public const ushort M2C_TestRobotCase2 = 10033;
		 public const ushort C2M_TransferMap = 10034;
		 public const ushort M2C_TransferMap = 10035;
		 public const ushort C2G_Benchmark = 10036;
		 public const ushort G2C_Benchmark = 10037;
		 public const ushort C2R_WXLogin = 10038;
		 public const ushort R2C_WXLogin = 10039;
		 public const ushort C2R_DYLogin = 10040;
		 public const ushort R2C_DYLogin = 10041;
		 public const ushort R2C_Disconnect = 10042;
		 public const ushort M2C_NoticeUnitNumeric = 10043;
		 public const ushort AdventureProto = 10044;
		 public const ushort BattleProto = 10045;
		 public const ushort ItemCompositeProto = 10046;
		 public const ushort BattleFormationProto = 10047;
		 public const ushort RankChange = 10048;
		 public const ushort PlayerTimedDataProto = 10049;
		 public const ushort CareerProto = 10050;
		 public const ushort CareerSkinProto = 10051;
		 public const ushort PhotoFrameProto = 10052;
		 public const ushort AttributeEntryProto = 10053;
		 public const ushort ItemProto = 10054;
		 public const ushort ItemsProto = 10055;
		 public const ushort MissionProto = 10056;
		 public const ushort ActivityProto = 10057;
		 public const ushort RoleRelationProto = 10058;
		 public const ushort RoleRelationProtos = 10059;
		 public const ushort AllRoleRelationProto = 10060;
		 public const ushort C2M_SyncUserInfo = 10061;
		 public const ushort M2C_SyncUserInfo = 10062;
		 public const ushort C2M_EnterMain = 10063;
		 public const ushort M2C_EnterMain = 10064;
		 public const ushort M2C_StaminaChange = 10065;
		 public const ushort M2C_ShareTimeChange = 10066;
		 public const ushort M2C_ShowAdForDiamondChange = 10067;
		 public const ushort C2M_CloseAdventure = 10068;
		 public const ushort M2C_CloseAdventure = 10069;
		 public const ushort C2M_UpdateNewGuide = 10070;
		 public const ushort M2C_UpdateNewGuide = 10071;
		 public const ushort M2C_FinishNewGuide = 10072;
		 public const ushort C2M_GainRewardBySource = 10073;
		 public const ushort M2C_GainRewardBySource = 10074;
		 public const ushort C2M_NewAdventure = 10075;
		 public const ushort M2C_NewAdventure = 10076;
		 public const ushort C2M_ManualRefreshShop = 10077;
		 public const ushort M2C_ManualRefreshShop = 10078;
		 public const ushort C2M_ToggleLock = 10079;
		 public const ushort M2C_ToggleLock = 10080;
		 public const ushort C2M_BuyShopItem = 10081;
		 public const ushort M2C_BuyShopItem = 10082;
		 public const ushort C2M_SellItem = 10083;
		 public const ushort M2C_SellItem = 10084;
		 public const ushort C2M_ChangeItem = 10085;
		 public const ushort M2C_ChangeItem = 10086;
		 public const ushort C2M_UnloadItem = 10087;
		 public const ushort M2C_UnloadItem = 10088;
		 public const ushort C2M_Composite = 10089;
		 public const ushort M2C_Composite = 10090;
		 public const ushort C2M_RotateItem = 10091;
		 public const ushort M2C_RotateItem = 10092;
		 public const ushort C2M_StartAdventure = 10093;
		 public const ushort M2C_StartAdventure = 10094;
		 public const ushort M2C_EndGameSettle = 10095;
		 public const ushort M2C_AdventureUpdate = 10096;
		 public const ushort M2C_NewBattle = 10097;
		 public const ushort C2M_EndRound = 10098;
		 public const ushort M2C_EndRound = 10099;
		 public const ushort C2M_StartRound = 10100;
		 public const ushort M2C_StartRound = 10101;
		 public const ushort C2M_WaitToLostConfirm = 10102;
		 public const ushort M2C_WaitToLostConfirm = 10103;
		 public const ushort RankInfo2Proto = 10104;
		 public const ushort C2M_GetTopRanksInfo2 = 10105;
		 public const ushort M2C_GetTopRanksInfo2 = 10106;
		 public const ushort C2M_GetPlayerRanksInfo2 = 10107;
		 public const ushort M2C_GetPlayerRanksInfo2 = 10108;
		 public const ushort C2M_BuyCareer = 10109;
		 public const ushort M2C_BuyCareer = 10110;
		 public const ushort C2M_BuyCareerSkin = 10111;
		 public const ushort M2C_BuyCareerSkin = 10112;
		 public const ushort C2M_BuyPhotoFrame = 10113;
		 public const ushort M2C_BuyPhotoFrame = 10114;
		 public const ushort C2M_ChangePhotoFrame = 10115;
		 public const ushort M2C_ChangePhotoFrame = 10116;
		 public const ushort M2C_ReceiveCareer = 10117;
		 public const ushort M2C_ReceiveCareerSkin = 10118;
		 public const ushort M2C_ReceivePhotoFrame = 10119;
		 public const ushort M2C_ReceiveCommonReward = 10120;
		 public const ushort M2C_UpdateMission = 10121;
		 public const ushort C2M_GetAllRunningMission = 10122;
		 public const ushort M2C_GetAllRunningMission = 10123;
		 public const ushort C2M_ReceiveMissionReward = 10124;
		 public const ushort M2C_ReceiveMissionReward = 10125;
		 public const ushort M2C_ActivityNewRoleRelation = 10126;
		 public const ushort C2M_GetAllRunningActivity = 10127;
		 public const ushort M2C_GetAllRunningActivity = 10128;
		 public const ushort C2M_ReceiveActivityReward = 10129;
		 public const ushort M2C_ReceiveActivityReward = 10130;
		 public const ushort C2M_RequestRewards = 10131;
		 public const ushort M2C_RequestRewards = 10132;
		 public const ushort AdventureMatchAOProto = 10133;
		 public const ushort HttpCommonResponse = 10134;
		 public const ushort HttpGetPoolFormationsResponse = 10135;
		 public const ushort HttpGetPoolFormationResponse = 10136;
		 public const ushort HttpGetAdventureMatchAOsResponse = 10137;
		 public const ushort HttpGetAdventureMatchAOResponse = 10138;
	}
}
