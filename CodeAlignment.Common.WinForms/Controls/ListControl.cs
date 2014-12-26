using System;
using System.Linq;
using System.Collections;
using System.Windows.Forms;

namespace CMcG.CodeAlignment.Controls
{
    public partial class ListControl : BaseUserControl
    {
        Type  m_viewType;
        IList m_items;

        public ListControl()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        public Type ViewType
        {
            get { return m_viewType; }
            set
            {
                m_viewType = value;
                RefreshList();
            }
        }

        public IList Items
        {
            get { return m_items; }
            set
            {
                m_items = value;
                RefreshList();
            }
        }

        public void RefreshList()
        {
            foreach (Control ctl in Controls)
                ctl.Dispose();

            Controls.Clear();

            if (ViewType == null)
                return;

            if (Items == null)
                Controls.Add(CreateChild());
            else
                Controls.AddRange(Items.Cast<object>().Select(CreateChild).ToArray());
        }

        public void AddItem(object context)
        {
            Items.Add(context);
            Controls.Add(CreateChild(context));
        }

        Control CreateChild(object context = null)
        {
            var item  = (Control)Activator.CreateInstance(ViewType);
            item.Tag  = context;
            item.Dock = DockStyle.Fill;

            var panel     = new BaseUserControl { Dock = DockStyle.Top, Height = item.Height };
            var btnRemove = new Button { Text = "-", Dock = DockStyle.Right, Width = 30 };

            btnRemove.Click += (s, e) => RemoveItem(context);
            panel.Controls.Add(item);
            panel.Controls.Add(btnRemove);

            return panel;
        }

        void RemoveItem(object context)
        {
            Items.Remove(context);
            RefreshList();
        }
    }
}