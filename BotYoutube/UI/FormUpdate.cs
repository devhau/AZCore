using BotYoutube.Database;
using BotYoutube.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI
{
    public partial class FormUpdate : FormBase

    {
        public IEntityModel Model { get; set; }
        public FormUpdate()
        {
            InitializeComponent();
        }
        List<IInput> controlInput;
        public List<IInput> ControlInput
        {
            get
            {
                if (controlInput == null)
                {
                    controlInput = panEditer.Controls.OfType<IInput>().Cast<IInput>().ToList();
                }
                return controlInput;
            }
        }

        public virtual IEntityModel GetDataNew()
        {
            return null;
        }
        public virtual bool BeforeLoad() { return true; }
        public virtual bool AfterLoad() { return true; }
        public virtual bool BeforeSave() { return true; }
        public virtual bool AfterSave() { return true; }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            if (designMode) return;
                BeforeLoad();
            if (Model != null)
            {
                Type typeModel = Model.GetType();
                foreach(var item in ControlInput)
                {
                    if (((Control)item).Tag != null && typeModel.GetProperty(((Control)item).Tag.ToString()) != null) {
                        item.SetValue(typeModel.GetProperty(((Control)item).Tag.ToString()).GetValue(Model));
                    }
                }
            }
            AfterLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforeSave()) { return; }
            if (Model == null) Model = GetDataNew();
            Type typeModel = Model.GetType();

            foreach (var item in ControlInput)
            {
                if (((Control)item).Tag!=null&&typeModel.GetProperty(((Control)item).Tag.ToString()) != null)
                {
                    typeModel.GetProperty(((Control)item).Tag.ToString()).SetValue(Model,item.GetValue());
                }
            }
            AfterSave();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
