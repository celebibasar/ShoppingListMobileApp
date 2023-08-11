using System;
using System.Windows.Input;
using ShoppingListMobileApp.Models;


namespace ShoppingListMobileApp.ViewModels
{
    public class EditBasketPageViewModel : BindableObject
    {
        public EditBasketPageViewModel()
        {
            SaveEditedBasketCommand = new Command(OnSaveEditedBasket);
            CancelEditBasketCommand = new Command(OnCancelEditBasket);
        }

        private Basket _selectedBasket;
        public Basket SelectedBasket
        {
            get { return _selectedBasket; }
            set
            {
                _selectedBasket = value;
                EditedName = _selectedBasket?.Name;
                OnPropertyChanged();
            }
        }

        private string _editedName;
        public string EditedName
        {
            get { return _editedName; }
            set
            {
                _editedName = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveEditedBasketCommand { get; }
        public ICommand CancelEditBasketCommand { get; }

        // Event to signal that the editing is completed (Save or Cancel)
        public event EventHandler EditCompletedEvent;

        // Indicates whether the editing was completed
        public bool EditCompleted { get; private set; }

        // Method to wait for the editing to be completed
        public async Task WaitForEditCompletion()
        {
            // Use TaskCompletionSource to wait for the event
            var tcs = new TaskCompletionSource<bool>();

            // Handle the event
            EventHandler handler = null;
            handler = (s, e) =>
            {
                // Unsubscribe from the event
                EditCompletedEvent -= handler;
                // Set the result
                tcs.SetResult(true);
            };
            EditCompletedEvent += handler;

            // Wait for the event
            await tcs.Task;

            // Update the EditCompleted flag
            EditCompleted = true;
        }

        private void OnSaveEditedBasket()
        {
            if (SelectedBasket != null)
            {
                // Update the name of the selected basket
                SelectedBasket.Name = EditedName;
                SelectedBasket = null; // Clear the selected basket

                // Notify that the property within the collection has changed
                OnPropertyChanged(nameof(SelectedBasket));

                // Close the EditBasketPage (pop the navigation stack)
                Shell.Current.Navigation.PopAsync();
            }
        }




        private void OnCancelEditBasket()
        {
            // Just clear the selected basket, no changes are applied
            SelectedBasket = null;

            // Signal that editing is completed
            EditCompleted = false;
            OnEditCompleted();
        }

        // Method to invoke the EditCompletedEvent when editing is completed
        private void OnEditCompleted()
        {
            EditCompletedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}


