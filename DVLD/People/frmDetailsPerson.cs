using DVLD.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmDetailsPerson : Form
    {
        public frmDetailsPerson(int PersonID)
        {
            InitializeComponent();
            ctrlPersoneInformation.LoadPersonInformation(PersonID);
        }
    }
}
