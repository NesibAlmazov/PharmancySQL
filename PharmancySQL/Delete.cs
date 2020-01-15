using PharmancySQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmancySQL
{
    public partial class Delete : Form
    {
        private AptekEntities _db;
        public Delete()
        {
            _db = new AptekEntities();
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
        cmbdel.Items.AddRange(_db.DrugsTypes.Select(dt => new CB_DrugsType
        {
            Id = dt.Id,
            Name = dt.Name
        }).ToArray());
        
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int id = ((CB_DrugsType)cmbdel.SelectedItem).Id;
            DrugsType type = _db.DrugsTypes.First(t=>t.Id==id);
            type.Deleted = false;
            _db.DrugsTypes.Remove(type);
            await _db.SaveChangesAsync();
            cmbdel.Text = "";
            MessageBox.Show("Successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
