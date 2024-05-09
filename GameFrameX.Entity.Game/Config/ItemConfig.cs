namespace GameFrameX.Entity.Game;

public partial class ItemConfig
{
    /// <summary>Id</summary>
    public int Id{ get; set; }
    /// <summary>名字</summary>
    public string Name { get; set; }
    /// <summary>伤害值</summary>
    public int DamageValue { get; set; }
    /// <summary>初始伤害范围</summary>
    public string DamageRange { get; set; }
    /// <summary>伤害类型</summary>
    public int DamageType { get; set; }
    /// <summary>详述</summary>
    public string DescLong { get; set; }
    /// <summary>类型</summary>
    public int Type { get; set; }
    /// <summary>形态</summary>
    public int TransformId { get; set; }
    /// <summary>预制体</summary>
    public string PrefabName { get; set; }
    /// <summary>图标</summary>
    public string Icon { get; set; }
    /// <summary>品质</summary>
    public int Quality { get; set; }
    /// <summary>基础价格</summary>
    public int BasePrice { get; set; }
    /// <summary>Mp消耗</summary>
    public int MpCost { get; set; }
    /// <summary>冷却时间</summary>
    public int Cooldown { get; set; }
    /// <summary>吟唱打断次数</summary>
    public int BreakChantTime { get; set; }
    /// <summary>使用次数</summary>
    public int Usetimes { get; set; }
    /// <summary>药剂使用方式</summary>
    public int PotionUseType { get; set; }
    /// <summary>能量恢复</summary>
    public int MpRecover { get; set; }
    /// <summary>关联属性</summary>
    public string RelationProperty { get; set; }
    /// <summary>作用脚本</summary>
    public string ActionScript { get; set; }
    /// <summary>装载脚本</summary>
    public int LoadScriptId { get; set; }
    /// <summary>装载参数</summary>
    public string LoadScriptParams { get; set; }
    /// <summary>是否合成</summary>
    public int IsComposite { get; set; }
    /// <summary>Warrior加成</summary>
    public int WarriorShopWeight { get; set; }
    /// <summary>SpikeGuard加成</summary>
    public int SpikeGuardShopWeight { get; set; }
    /// <summary>PoisonWizard加成</summary>
    public int PoisonWizardShopWeight { get; set; }
    /// <summary>Sorcerer加成</summary>
    public int SorcererShopWeight { get; set; }

}