namespace MCPServerClashOfClans.Model
{
	public class Clan
	{
		public string Tag { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public Location Location { get; set; }
		public bool IsFamilyFriendly { get; set; }
		public BadgeUrls BadgeUrls { get; set; }
		public int ClanLevel { get; set; }
		public int ClanPoints { get; set; }
		public int ClanBuilderBasePoints { get; set; }
		public int ClanCapitalPoints { get; set; }
		public CapitalLeague CapitalLeague { get; set; }
		public int RequiredTrophies { get; set; }
		public string WarFrequency { get; set; }
		public int WarWinStreak { get; set; }
		public int WarWins { get; set; }
		public int WarTies { get; set; }
		public int WarLosses { get; set; }
		public bool IsWarLogPublic { get; set; }
		public WarLeague WarLeague { get; set; }
		public int Members { get; set; }
		public List<Label> Labels { get; set; }
		public int RequiredBuilderBaseTrophies { get; set; }
		public int RequiredTownhallLevel { get; set; }
		public ChatLanguage ChatLanguage { get; set; }
	}

	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsCountry { get; set; }
		public string CountryCode { get; set; }
	}

	public class BadgeUrls
	{
		public string Small { get; set; }
		public string Medium { get; set; }
		public string Large { get; set; }
	}

	public class CapitalLeague
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class WarLeague
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Label
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IconUrls IconUrls { get; set; }
	}

	public class IconUrls
	{
		public string Small { get; set; }
		public string Medium { get; set; }
	}

	public class ChatLanguage
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LanguageCode { get; set; }
	}

}
