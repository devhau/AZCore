using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotYoutube.Database;

namespace BotYoutube.UI
{
    public partial class ManagerBase : UserControl
    {
        public ManagerBase()
        {
            InitializeComponent();
        }
        public virtual FormUpdate GetFormUpdate() {
            return null;
        }
        public virtual object GetData() {

            return null;
        }
        public virtual void UpdateData(IEntityModel model,bool isEdit=false) { 
        
        
        }

        public virtual void RemoveData(IEntityModel model)
        {


        }

        public virtual void BeforeLoad() { }
        public virtual void AfterLoad() { }
        public void LoadData() {
            BeforeLoad();
            dataView.DataSource = GetData();
            AfterLoad();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = GetFormUpdate();
            if(frm!=null){
                if (frm.ShowDialog() == DialogResult.OK) {
                    UpdateData(frm.Model); LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0) {
                var frm = GetFormUpdate();
                if (frm != null)
                {
                    frm.Model = dataView.SelectedRows[0].DataBoundItem as IEntityModel;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateData(frm.Model,true); LoadData();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                RemoveData(dataView.SelectedRows[0].DataBoundItem as IEntityModel); LoadData();
            }
        }
            private void ManagerBase_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void customInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}
