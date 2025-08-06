namespace MCPServerClashOfClans.Model
{
	public class ClashOfClansApiOptions
	{
		public string BaseUrl { get; set; } = Environment.GetEnvironmentVariable("CLASH_OF_CLANS_API_BASE_URL");
		public string Token { get; set; } = Environment.GetEnvironmentVariable("CLASH_OF_CLANS_API_TOKEN");
	}
}
