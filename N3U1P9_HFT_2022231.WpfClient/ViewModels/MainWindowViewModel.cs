using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.WpfClient;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using N3U1P9_HFT_2022231.Models;
using System.Windows.Input;
using System.ComponentModel;
using N3U1P9_HFT_2022231.WpfClient.Services;
using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;

namespace N3U1P9_HFT_2022231.WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private RestCollection<Shelter> shelters;
        public RestCollection<Shelter> Shelters
        {
            get { return shelters; }
            set
            {
                SetProperty(ref shelters, value);
                OnPropertyChanged("CurrentShelterWorkers");
                OnPropertyChanged("CurrentAnimals");
            }
        }

        private RestCollection<ShelterWorker> shelterWorkers;
        public RestCollection<ShelterWorker> ShelterWorkers
        {
            get { return shelterWorkers; }
            set
            {
                SetProperty(ref shelterWorkers, value);
                OnPropertyChanged("CurrentShelterWorkers");
            }
        }

        private RestCollection<Animal> animals;
        public RestCollection<Animal> Animals
        {
            get { return animals; }
            set
            {
                SetProperty(ref animals, value);
                OnPropertyChanged("CurrentAnimals");
            }
        }

        //------------------------

        private Shelter selectedShelter;
        public Shelter SelectedShelter
        {
            get { return selectedShelter; }
            set
            {
                SetProperty(ref selectedShelter, value);
                (UpdateShelterCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteShelterCommand as RelayCommand).NotifyCanExecuteChanged();
                (CreateShelterWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                (CreateAnimalCommand as RelayCommand).NotifyCanExecuteChanged();

                OnPropertyChanged("CurrentShelterWorkers");
                OnPropertyChanged("CurrentAnimals");
            }
        }

        public BindingList<ShelterWorker> CurrentShelterWorkers
        {
            get
            {
                if (SelectedShelter != null)
                {
                    return new BindingList<ShelterWorker>(ShelterWorkers.Where(x => x.ShelterId == selectedShelter.ShelterId).ToList());
                }
                else
                {
                    return null;
                }
            }
            set { }
        }

        private ShelterWorker selectedWorker;
        public ShelterWorker SelectedWorker
        {
            get { return selectedWorker; }
            set
            {
                SetProperty(ref selectedWorker, value);
                (UpdateAnimalCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteAnimalCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateShelterWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteShelterWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateShelterCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteShelterCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //private BindingList<Animal> currentAnimals;
        public BindingList<Animal> CurrentAnimals
        {
            get
            {
                if (SelectedShelter != null)
                {
                    return new BindingList<Animal>(Animals.Where(x => x.ShelterId == selectedShelter.ShelterId).ToList());
                }
                else
                {
                    return null;
                }
            }
            set { }
        }


        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                SetProperty(ref selectedAnimal, value);
                (UpdateAnimalCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteAnimalCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateShelterWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteShelterWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateShelterCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteShelterCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //Commands
        public ICommand CreateShelterCommand { get; set; }
        public ICommand UpdateShelterCommand { get; set; }
        public ICommand DeleteShelterCommand { get; set; }

        public ICommand CreateAnimalCommand { get; set; }
        public ICommand UpdateAnimalCommand { get; set; }
        public ICommand DeleteAnimalCommand { get; set; }

        public ICommand CreateShelterWorkerCommand { get; set; }
        public ICommand UpdateShelterWorkerCommand { get; set; }
        public ICommand DeleteShelterWorkerCommand { get; set; }

        public MainWindowViewModel()
        {
            Shelters = new RestCollection<Shelter>("http://localhost:50000/", "Shelter", "hub");
            ShelterWorkers = new RestCollection<ShelterWorker>("http://localhost:50000/", "ShelterWorker", "hub");
            Animals = new RestCollection<Animal>("http://localhost:50000/", "Animal", "hub");

            ShelterEditorService ShelterEditor = new ShelterEditorService();
            ShelterWorkerEditorService WorkerEditor = new ShelterWorkerEditorService();
            AnimalEditorService AnimalEditor = new AnimalEditorService();

            //Shelter Commands

            //CREATE
            CreateShelterCommand = new RelayCommand(() =>
            {
                Shelter NewShelter = new Shelter() { Name = "" };
                if (ShelterEditor.Edit(NewShelter)) Shelters.Add(NewShelter);
            }, () => true);

            //UPDATE
            UpdateShelterCommand = new RelayCommand(() =>
            {
                if (ShelterEditor.Edit(SelectedShelter)) Shelters.Update(SelectedShelter);
            }, () => SelectedShelter != null);

            //DELETE
            DeleteShelterCommand = new RelayCommand(() =>
            {
                Shelters.Delete(SelectedShelter.ShelterId);
                SelectedShelter = new Shelter();
            }, () => SelectedShelter != null);

            //ShelterWorker Commands

            //CREATE
            CreateShelterWorkerCommand = new RelayCommand(() =>
            {
                ShelterWorker NewWorker = new ShelterWorker() { ShelterId = SelectedShelter.ShelterId, Name = "" };
                if (WorkerEditor.Edit(NewWorker)) ShelterWorkers.Add(NewWorker);

                OnPropertyChanged("CurrentShelterWorkers");
            }, () => SelectedShelter != null);

            //UPDATE
            UpdateShelterWorkerCommand = new RelayCommand(() =>
            {
                if (WorkerEditor.Edit(SelectedWorker)) ShelterWorkers.Update(SelectedWorker);

                OnPropertyChanged("CurrentShelterWorkers");
            }, () => SelectedWorker != null);

            //DELETE
            DeleteShelterWorkerCommand = new RelayCommand(() =>
            {
                ShelterWorkers.Delete(SelectedWorker.WorkerId);
                OnPropertyChanged("CurrentShelterWorkers");
            }, () => SelectedWorker != null);

            //Animal Commands

            //CREATE
            CreateAnimalCommand = new RelayCommand(() =>
            {
                Animal NewAnimal = new Animal() { ShelterId = SelectedShelter.ShelterId, Name = "" };
                if (AnimalEditor.Edit(NewAnimal)) Animals.Add(NewAnimal);

                OnPropertyChanged("CurrentAnimals");
            }, () => SelectedShelter != null);

            //UPDATE
            UpdateAnimalCommand = new RelayCommand(() =>
            {
                if (AnimalEditor.Edit(SelectedAnimal)) Animals.Update(SelectedAnimal);

                OnPropertyChanged("CurrentAnimals");
            }, () => SelectedAnimal != null);

            //DELETE
            DeleteAnimalCommand = new RelayCommand(() =>
            {
                Animals.Delete(SelectedAnimal.AnimalId);
                OnPropertyChanged("CurrentAnimals");
            }, () => SelectedAnimal != null);
        }
    }
}
