#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Enums;

namespace PlayerBaseApi.Entities;

public class Attack
{
    [Key]
    public long Id { get; set; }
    public long TargetUserId { get; set; }
    public int AttackerTroopCount { get; set; }
    public int AttackerHeroId { get; set; }
    public long AttackerUserId { get; set; }
    public byte? WinnerSide { get; set; } = (byte)AttackSideEnum.Defenser;
    public DateTimeOffset? ArriveDate { get; set; } = null;
    public DateTimeOffset? ComeBackDate { get; set; } = null;
    public string? ResultData { get; set; } = null;
    public bool IsActive { get; set; } = true;

}