using MCPServerClashOfClans.Model;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MCPServerClashOfClans.Service
{
	public class ClanService : IClanService
	{
		private readonly HttpClient _httpClient;
		private readonly ClashOfClansApiOptions _options;

		public ClanService(HttpClient httpClient, IOptions<ClashOfClansApiOptions> options)
		{
			_httpClient = httpClient;
			_options = options.Value;

			// Setando minha url base e meu token que estão configurados no appsettings
			_httpClient.BaseAddress = new Uri(_options.BaseUrl);
			_httpClient.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", _options.Token);
		}

		public async Task<List<Clan>> GetClanByNameAsync(string name)
		{
			var encodedName = Uri.EscapeDataString(name);
			var response = await _httpClient.GetAsync($"clans?name={encodedName}&limit=10");
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<ClanSearchResult>(json, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return result?.Items ?? new List<Clan>();
		}
	}
}
