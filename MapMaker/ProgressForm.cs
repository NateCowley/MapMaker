using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
	public partial class ProgressForm : Form
	{
		public int ProgressBarMax
		{
			get
			{
				return progressBar1.Maximum;
			}

			set
			{
				progressBar1.Maximum = value;
			}
		}

		public int ProgressBarValue
		{
			get
			{
				return progressBar1.Value;
			}

			set
			{
				if(value < 0)
				{
					progressBar1.Value = 0;
				}
				else
				{
					progressBar1.Value = value;
				}
			}
		}

		public ProgressForm()
		{
			InitializeComponent();
		}
	}
}
