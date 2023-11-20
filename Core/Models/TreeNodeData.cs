namespace Core.Models
{
    public class TreeNodeData
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<TreeNodeData>? Items { get; set; }
    }
}
