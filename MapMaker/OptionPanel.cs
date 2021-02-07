using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	interface OptionPanel
	{
		bool variablesSet(int width = 0, int height = 0);
		void setVisibility(bool visible);
	}
}
