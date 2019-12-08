/** Class-1208: 練習 EF Core 的 Code First 開發流程 */
using System;
using System.ComponentModel.DataAnnotations;
public class Todo
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Item { get; set; }
    [Required]
    public bool IsDone { get; set; }
    [Required]
    public DateTime Update { get; set; }
}