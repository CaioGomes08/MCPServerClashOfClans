using MCPServerClashOfClans.Model;

namespace MCPServerClashOfClans.Service
{
	public interface IClanService
	{
		Task<List<Clan>> GetClanByNameAsync(string name);
	}
}
