using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models

{
	public class TextViewModel
	{
		[Required]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "Text to split must be between 2 and 30 characters long!")]
		public string Text { get; set; } = null!;
		public string? SplitText { get; set; }
	}
}
