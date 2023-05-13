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
                if (shelters != value) shelters = value;
            }
        }

        private RestCollection<ShelterWorker> shelterWorkers;
        public RestCollection<ShelterWorker> ShelterWorkers
        {
            get { return shelterWorkers; }
            set
            {
                if (shelterWorkers != value) shelterWorkers = value;
            }
        }

        private RestCollection<Animal> animals;
        public RestCollection<Animal> Animals
        {
            get { return animals; }
            set { if (animals != value) animals = value; }
        }

        //------------------------

        private Shelter selectedShelter;
        public Shelter SelectedShelter
        {
            get { return selectedShelter; }
            set { selectedShelter = value; }
        }

        private BindingList<ShelterWorker> currentShelterWorkers;
        public BindingList<ShelterWorker> CurrentShelterWorkers
        {
            get { return currentShelterWorkers; }
            set { currentShelterWorkers = new BindingList<ShelterWorker>(ShelterWorkers.Where(x => x.ShelterId == selectedShelter.ShelterId).ToList()); }
        }

        private ShelterWorker selectedWorker;
        public ShelterWorker SelectedWorker
        {
            get { return selectedWorker; }
            set { selectedWorker = value; }
        }

        private BindingList<Animal> currentAnimals;
        public BindingList<Animal> CurrentAnimals
        {
            get { return currentAnimals; }
            set { currentAnimals = new BindingList<Animal>(Animals.Where(x => x.ShelterId == selectedShelter.ShelterId).ToList()); }
        }


        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set { selectedAnimal = value; }
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
            Shelters = new RestCollection<Shelter>("http://localhost:5000", "Shelter", "hub");
            ShelterWorkers = new RestCollection<ShelterWorker>("http://localhost:5000", "ShelterWorker", "hub");
            Animals = new RestCollection<Animal>("http://localhost:5000", "Animal", "hub");

            ShelterEditorService ShelterEditor = new ShelterEditorService();
            ShelterWorkerEditorService WorkerEditor = new ShelterWorkerEditorService();
            AnimalEditorService AnimalEditor = new AnimalEditorService();

            //Shelter Commands

            CreateShelterCommand = new RelayCommand(() =>
            {
                Shelter NewShelter = new Shelter() { Name = "" };
                Shelters.Add(NewShelter);
                ShelterEditor.Edit(NewShelter);
            }, () => true);

            //ShelterWorker Commands

            CreateShelterCommand = new RelayCommand(() =>
            {
                ShelterWorker NewWorker = new ShelterWorker() { ShelterId = SelectedShelter.ShelterId, Name = "" };
                ShelterWorkers.Add(NewWorker);
                WorkerEditor.Edit(NewWorker);
            }, () => true);

            //Animal Commands

            CreateShelterCommand = new RelayCommand(() =>
            {
                ShelterWorker NewWorker = new ShelterWorker() { ShelterId = SelectedShelter.ShelterId, Name = "" };
                ShelterWorkers.Add(NewWorker);
                WorkerEditor.Edit(NewWorker);
            }, () => true);
        }

    }
}
