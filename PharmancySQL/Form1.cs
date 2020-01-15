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
    public partial class Form1 : Form
    {
        private AptekEntities _db;
        public Form1()
        {
            _db = new AptekEntities();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = _db.Drugs.Select(d => new
            {
                d.Id,
                d.Name,
                d.Price,
                d.DrugCount,
                Type = d.DrugsType.Name
            }).ToList();

            cmbType.Items.AddRange(_db.DrugsTypes.Select(dt => new CB_DrugsType
            {
                Id = dt.Id,
                Name = dt.Name
            }).ToArray());
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ((CB_DrugsType)cmbType.SelectedItem).Id;
            dgv.DataSource = _db.Drugs.Where(d => d.TypeId == id).Select(d => new
            {
                d.Id,
                d.Name,
                d.Price,
                d.DrugCount,
                Type = d.DrugsType.Name
            }).ToArray();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create type = new Create(cmbType);
            type.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.ShowDialog();
        }

      
    }
}
