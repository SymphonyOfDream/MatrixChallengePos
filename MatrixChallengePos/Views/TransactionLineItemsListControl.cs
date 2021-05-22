using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Views
{
    public partial class TransactionLineItemsListControl : UserControl
    {
        private ObservableCollection<TransactionLineItem> _items = new ObservableCollection<TransactionLineItem>();

        public TransactionLineItemsListControl()
        {
            InitializeComponent();

            AutoScroll = true;
            _items.CollectionChanged += OnItemsCollectionChanged;
        }


        public Collection<TransactionLineItem> Items => _items;


        public void AddTransactionLineItem(TransactionLineItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
            else
            {
                // Item added that already exists, that means that the qty has changed.
                UpdateVisualization();
            }
        }

        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateVisualization();
        }

        private void UpdateVisualization()
        {
            SuspendLayout();
            Controls.Clear();

            foreach (var item in _items)
            {
                var control = new TransactionLineItemControl { TransactionLineItem = item, Dock = DockStyle.Top };
                Controls.Add(control);
                Controls.SetChildIndex(control, 0);
            }

            ResumeLayout();
        }

    }
}
