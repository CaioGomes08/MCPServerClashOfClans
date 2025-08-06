using MCPServerClashOfClans.Model;
using MCPServerClashOfClans.Service;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole(consoleLogOptions =>
{
	// Configure all logs to go to stderr
	consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Criando meu server MCP, configurando meu server de transport padr�o
// e falando para nosso server buscar por Tools e APIs disponiveis no assembly
builder.Services
	.AddMcpServer()
	.WithStdioServerTransport()
	.WithToolsFromAssembly();

DotNetEnv.Env.Load();

// Bind options
builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<ClashOfClansApiOptions>(
	builder.Configuration.GetSection("ClashOfClansApi"));

builder.Services.AddHttpClient<IClanService, ClanService>();



await builder.Build().RunAsync();

[McpServerToolType]
public class ClanTool
{
	private readonly IClanService _clanService;
	public ClanTool(IClanService clanService)
	{
		_clanService = clanService;
	}

	[McpServerTool, Description("Busca um clan pelo nome")]
	public async Task<string> GetClanByName([Description("O nome do clan")] string name)
	{
		var list = await _clanService.GetClanByNameAsync(name);
		return JsonSerializer.Serialize(list);
	}

	[McpServerTool, Description("Buscar um clan pelo nome e traz o que tem mais vitoria")]
	public async Task<string> GetClanByNameWithMostWins([Description("O nome do clan")] string name)
	{
		var list = await _clanService.GetClanByNameAsync(name);
		var clan = list.OrderByDescending(c => c.WarWins).FirstOrDefault();
		return JsonSerializer.Serialize(clan);
	}

	[McpServerTool, Description("Buscar um clan pelo nome e traz o que tem mais derrota")]
	public async Task<string> GetClanByNameWithMostLosses([Description("O nome do clan")] string name)
	{
		var list = await _clanService.GetClanByNameAsync(name);
		var clan = list.OrderByDescending(c => c.WarLosses).FirstOrDefault();
		return JsonSerializer.Serialize(clan);
	}
}