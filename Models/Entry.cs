namespace needle_tracker.Models
{
	public class Entry
	{
		public int Id { get; set; }
		public string TimeStamp { get; set; }
		public int NeedlesIn { get; set; }
		public int NeedlesOut { get; set; }
		public bool IsVoid { get; set; }
		public string UserId { get; set; } // User that made entry
	}
}