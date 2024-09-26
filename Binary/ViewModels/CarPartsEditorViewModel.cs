using System.Collections.ObjectModel;
using System.Windows.Input;
using Nikki.Support.Shared.Class;
using Nikki.Support.Shared.Parts.CarParts;

using System.ComponentModel;

namespace Binary.UI
{
    public class CarPartsEditorViewModel : INotifyPropertyChanged
    {
        public DBModelPart Model { get; }

        public ICommand AddPartCommand { get; }
        public ICommand RemovePartCommand { get; }
        public ICommand CopyPartCommand { get; }
        public ICommand MoveUpPartCommand { get; }
        public ICommand MoveDownPartCommand { get; }
        public ICommand MoveFirstPartCommand { get; }
        public ICommand MoveLastPartCommand { get; }
        public ICommand ReversePartsCommand { get; }
        public ICommand SortPartsByNameCommand { get; }

        public CarPartsEditorViewModel(DBModelPart model)
        {
            Model = model;

            AddPartCommand = new RelayCommand(AddPart);
            RemovePartCommand = new RelayCommand(RemovePart);
            CopyPartCommand = new RelayCommand(CopyPart);
            MoveUpPartCommand = new RelayCommand(MoveUpPart);
            MoveDownPartCommand = new RelayCommand(MoveDownPart);
            MoveFirstPartCommand = new RelayCommand(MoveFirstPart);
            MoveLastPartCommand = new RelayCommand(MoveLastPart);
            ReversePartsCommand = new RelayCommand(ReverseParts);
            SortPartsByNameCommand = new RelayCommand(SortPartsByName);
        }

        private void AddPart()
        {
            Model.AddRealPart();
            OnPropertyChanged(nameof(Model.ModelCarParts));
        }

        private void RemovePart()
        {
            if (SelectedPart != null && Model.ModelCarParts.Contains(SelectedPart))
            {
                Model.ModelCarParts.Remove(SelectedPart);
                OnPropertyChanged(nameof(Model.ModelCarParts));
            }
        }

        private void CopyPart()
        {
            if (SelectedPart != null)
            {
                var copiedPart = SelectedPart.Clone(); // Assuming Clone method exists
                Model.ModelCarParts.Add(copiedPart);
                OnPropertyChanged(nameof(Model.ModelCarParts));
            }
        }

        private void MoveUpPart()
        {
            if (SelectedPart != null)
            {
                var index = Model.ModelCarParts.IndexOf(SelectedPart);
                if (index > 0)
                {
                    Model.ModelCarParts.Move(index, index - 1);
                    OnPropertyChanged(nameof(Model.ModelCarParts));
                }
            }
        }

        private void MoveDownPart()
        {
            if (SelectedPart != null)
            {
                var index = Model.ModelCarParts.IndexOf(SelectedPart);
                if (index < Model.ModelCarParts.Count - 1)
                {
                    Model.ModelCarParts.Move(index, index + 1);
                    OnPropertyChanged(nameof(Model.ModelCarParts));
                }
            }
        }

        private void MoveFirstPart()
        {
            if (SelectedPart != null)
            {
                Model.ModelCarParts.Remove(SelectedPart);
                Model.ModelCarParts.Insert(0, SelectedPart);
                OnPropertyChanged(nameof(Model.ModelCarParts));
            }
        }

        private void MoveLastPart()
        {
            if (SelectedPart != null)
            {
                Model.ModelCarParts.Remove(SelectedPart);
                Model.ModelCarParts.Add(SelectedPart);
                OnPropertyChanged(nameof(Model.ModelCarParts));
            }
        }

        private void ReverseParts()
        {
            Model.ReverseParts();
            OnPropertyChanged(nameof(Model.ModelCarParts));
        }

        private void SortPartsByName()
        {
            Model.SortByProperty(nameof(RealCarPart.PartName));
            OnPropertyChanged(nameof(Model.ModelCarParts));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
