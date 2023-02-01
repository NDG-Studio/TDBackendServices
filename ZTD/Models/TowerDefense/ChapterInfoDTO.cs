namespace ZTD.Models;

public class ChapterInfoDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string SceneId { get; set; } = string.Empty;
    public int TotalStar  { get; set; } = 0;
    public List<LevelInfoDTO> Levels { get; set; }
}

public class ChapterInfoDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string SceneId { get; set; } = string.Empty;
    public int TotalStar  { get; set; } = 0;
    public int LevelCount  { get; set; } = 0;
    public List<LevelDTO> Levels { get; set; }
}