using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	public enum BiomeMiscOptions
	{
		ATOLL = 1
	}

	public enum GeneratorMiscOptions
	{
		WORLEY = 3,
	}

	public enum Biome
	{
		CUSTOM,
		ARCHIPELAGO_SUBTRACTIVE,
		ARCHIPELAGO_GRADIENT,
		ARCHIPELAGO_LERP,
		CONTINENTS,
		PLAINS,
		MOUNTAINS,
		DESERT,
		ATOLL,
		NO_BIOME,
	}
}
