using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Forms;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Views
{
    /// <summary>
    /// Holds a list of our TransactionLineItemControl controls.
    /// </summary>
    public partial class TransactionLineItemsListControl : UserControl
    {
        private ObservableCollection<TransactionLineItem> _items = new ObservableCollection<TransactionLineItem>();
        public event EventHandler TransactionLineItemListChanged;

        public TransactionLineItemsListControl()
        {
            InitializeComponent();

            AutoScroll = true;
            _items.CollectionChanged += OnItemsCollectionChanged;
        }

        public void Clear()
        {
            Items.Clear();
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
                control.TransactionLineItemDeleted += Control_TransactionLineItemDeleted;
                Controls.Add(control);
                Controls.SetChildIndex(control, 0);
            }

            ResumeLayout();

            OnTransactionLineItemListChanged(new EventArgs());
        }

        protected virtual void OnTransactionLineItemListChanged(EventArgs e)
        {
            if (TransactionLineItemListChanged != null)
                TransactionLineItemListChanged(this, e);
        }

        
        private void Control_TransactionLineItemDeleted(object sender, System.EventArgs e)
        {
            var doomedOne = (TransactionLineItemControl) sender;
            doomedOne.TransactionLineItemDeleted -= Control_TransactionLineItemDeleted;
            doomedOne.TransactionLineItem.Quantity = 0;
            Items.Remove(doomedOne.TransactionLineItem);
            Controls.Remove(doomedOne);
        }
    }
}
