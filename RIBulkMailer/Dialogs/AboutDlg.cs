using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RIBulkMailer.Dialogs
{
  public partial class AboutDlg : Form
  {
    private int ShowSuzuCount = 0;

    public AboutDlg()
    {
      InitializeComponent();
    }

    private void riLogoPic_Click(object sender, EventArgs e)
    {
      ShowSuzuCount ++;

      if(ShowSuzuCount >= 9)
      {
        MessageBox.Show("Congratulations, you've found the easter egg :D.", "Winrar!!");

        SuzuDlg suzu = new SuzuDlg();
        suzu.ShowDialog();

        ShowSuzuCount = 0;
      }
    }
  }
}
