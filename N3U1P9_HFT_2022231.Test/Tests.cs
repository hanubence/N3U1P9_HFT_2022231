using Moq;
using N3U1P9_HFT_2022231.Logic;
using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace N3U1P9_HFT_2022231.Test
{
    [TestFixture]
    public class Tests
    {
        ShelterLogic sl;
        AnimalLogic al;
        ShelterWorkerLogic wl;
        Mock<IRepository<Shelter>> mockShelterRepo;
        Mock<IRepository<Animal>> mockAnimalRepo;
        Mock<IRepository<ShelterWorker>> mockWorkerRepo;

        [SetUp]
        public void Init()
        {
            var shelters = new List<Shelter>()
            {
                new Shelter { ShelterId = 1, Name = "Animal Haven", Address = "7001 W. Jennings St. Dalton, GA 30721", AnnualBudget = 12130921 },
                new Shelter { ShelterId = 2, Name = "Loved Pet Shelter", Address = "91 Smith Store Dr. Windsor Mill, MD 21244", AnnualBudget = 18902344 },
            }.AsQueryable();

            var animals1 = new List<Animal>()
            {
                new Animal { AnimalId = 1, Name = "Lacy", Species = "Parrot", Age = 5, ShelterId = 1, Shelter = shelters.First() },
                new Animal { AnimalId = 2, Name = "Lionel", Species = "Cat", Age = 14, ShelterId = 1, Shelter = shelters.First() },
                new Animal { AnimalId = 3, Name = "Lillith", Species = "Parrot", Age = 2, ShelterId = 1, Shelter = shelters.First() },
            }.AsQueryable();

            var animals2 = new List<Animal>()
            {
                new Animal { AnimalId = 4, Name = "Keefe", Species = "Hamster", Age = 12, ShelterId = 2, Shelter = shelters.Last() },
                new Animal { AnimalId = 5, Name = "Nomlanga", Species = "Cat", Age = 8, ShelterId = 2, Shelter = shelters.Last() },
                new Animal { AnimalId = 6, Name = "Jeremy", Species = "Hamster", Age = 11, ShelterId = 2, Shelter = shelters.Last() },
                new Animal { AnimalId = 7, Name = "Britanney", Species = "Parrot", Age = 9, ShelterId = 2, Shelter = shelters.Last() },
            }.AsQueryable();

            var workers1 = new List<ShelterWorker>()
            {
                new ShelterWorker { WorkerId = 1, Name = "Ramona Finley", Age = 53, Occupation = "Caretaker", Salary = 974485, ShelterId = 1, Shelter = shelters.First() },
                new ShelterWorker { WorkerId = 2, Name = "Fleur Lloyd", Age = 59, Occupation = "Caretaker", Salary = 838951, ShelterId = 1, Shelter = shelters.First() },
                new ShelterWorker { WorkerId = 3, Name = "Rae Owen", Age = 32, Occupation = "Caretaker", Salary = 717054, ShelterId = 1, Shelter = shelters.First() },
            }.AsQueryable();

            var workers2 = new List<ShelterWorker>()
            {
                new ShelterWorker { WorkerId = 4, Name = "Hiram Wright", Age = 35, Occupation = "Veterinarian",  Salary = 327110, ShelterId = 2, Shelter = shelters.Last() },
                new ShelterWorker { WorkerId = 5, Name = "Rhea Casey", Age = 21, Occupation = "Caretaker", Salary = 604499, ShelterId = 2, Shelter = shelters.Last() },
            }.AsQueryable();


            //Fill first shelter with data
            foreach (var item in animals1)
            {
                shelters.First().Animals.Add(item);
            }

            foreach (var item in workers1)
            {
                shelters.First().Workers.Add(item);
            }

            //Fill second shelter with data
            foreach (var item in animals2)
            {
                shelters.Last().Animals.Add(item);
            }

            foreach (var item in workers2)
            {
                shelters.Last().Workers.Add(item);
            }

            mockShelterRepo = new Mock<IRepository<Shelter>>();
            mockShelterRepo.Setup(t => t.ReadAll()).Returns(shelters);

            mockAnimalRepo = new Mock<IRepository<Animal>>();
            mockAnimalRepo.Setup(t => t.ReadAll()).Returns(animals1.Concat(animals2));

            mockWorkerRepo = new Mock<IRepository<ShelterWorker>>();
            mockWorkerRepo.Setup(t => t.ReadAll()).Returns(workers1.Concat(workers2));

            sl = new ShelterLogic(mockShelterRepo.Object, mockWorkerRepo.Object, mockAnimalRepo.Object);
            al = new AnimalLogic(mockAnimalRepo.Object);
            wl = new ShelterWorkerLogic(mockWorkerRepo.Object);
        }


        //CREATE TESTS -------------------------------------------------

        //SHELTER
        [Test]
        public void CreateShelterCorrectlyTest()
        {
            var s = new Shelter { Name = "Test Shelter" };

            sl.Create(s);

            mockShelterRepo.Verify(r => r.Create(s), Times.Once());
        }

        [Test]
        public void CreateShelterIncorrectlyTest()
        {
            var s = new Shelter { Name = "3" };
            try
            {
                sl.Create(s);
            }
            catch { }
            
            mockShelterRepo.Verify(r => r.Create(s), Times.Never());
        }

        //ANIMAL
        [Test]
        public void CreatAnimalCorrectlyTest()
        {
            var a = new Animal { Name = "Test Animal", Age = 5, ShelterId = 1, Species = "Dog" };

            try
            {
                al.Create(a);
            } catch { }

            mockAnimalRepo.Verify(r => r.Create(a), Times.Once());
        }

        [Test]
        public void CreatAnimalIncorrectlyTest()
        {
            var a = new Animal { Name = "Test Animal", Age = -10, ShelterId = 1, Species = "Dog" };

            try
            {
                al.Create(a);
            }
            catch { }

            mockAnimalRepo.Verify(r => r.Create(a), Times.Never());
        }

        //WORKER
        [Test]
        public void CreatWorkerCorrectlyTest()
        {
            var a = new ShelterWorker { Name = "Test Person", ShelterId = 3 };

            try
            {
                wl.Create(a);
            }
            catch { }

            mockWorkerRepo.Verify(r => r.Create(a), Times.Once());
        }

        [Test]
        public void CreatWorkerIncorrectlyTest()
        {
            var a = new ShelterWorker { Name = "Bad", ShelterId = 3 };

            try
            {
                wl.Create(a);
            }
            catch { }

            mockWorkerRepo.Verify(r => r.Create(a), Times.Never());
        }

        //NON CRUD TESTS -----------------------------------------------
        [Test]
        public void AverageAnnualBudgetTest()
        {
            double expected = 15516632.5d;

            Assert.AreEqual(expected, sl.GetAverageBudget());
        }

        [Test]
        public void AverageSalaryTest()
        {
            List<ShelterSalaryInfo> expected = new List<ShelterSalaryInfo>();

            expected.Add(new ShelterSalaryInfo { ShelterName = "Animal Haven", AverageSalary = 843496 });
            expected.Add(new ShelterSalaryInfo { ShelterName = "Loved Pet Shelter", AverageSalary = 465804 });

            var actual = sl.GetAverageSalaryByShelter().ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected[0].ShelterName, actual[0].ShelterName);
                Assert.AreEqual(expected[0].AverageSalary, actual[0].AverageSalary);

                Assert.AreEqual(expected[1].ShelterName, actual[1].ShelterName);
                Assert.AreEqual(expected[1].AverageSalary, actual[1].AverageSalary);
            });
        }

        [Test]
        public void WorkerOccupationCountTest()
        {
            List<WorkerOccupationInfo> expected = new List<WorkerOccupationInfo>();

            expected.Add(new WorkerOccupationInfo { ShelterName = "Animal Haven", Occupations = new List<OccupationCount> { new OccupationCount { Name = "Caretaker", Count = 3 } } });
            expected.Add(new WorkerOccupationInfo { ShelterName = "Loved Pet Shelter", Occupations = new List<OccupationCount> { new OccupationCount { Name = "Veterinarian", Count = 1 }, new OccupationCount { Name = "Caretaker", Count = 1 } } });

            var actual = sl.GetWorkerOccupationCountByShelter().ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected[0].ShelterName, actual[0].ShelterName);
                Assert.AreEqual(expected[0].Occupations, actual[0].Occupations);

                Assert.AreEqual(expected[1].ShelterName, actual[1].ShelterName);
                Assert.AreEqual(expected[1].Occupations, actual[1].Occupations);
            });
        }

        [Test]
        public void AnimalSpeciesCountTest()
        {
            List <AnimalSpecieInfo> expected = new List<AnimalSpecieInfo>();

            expected.Add(new AnimalSpecieInfo 
            { 
                ShelterName = "Animal Haven", 
                Species = new List<SpecieCount>
                {
                    new SpecieCount { Name = "Parrot", Count = 2},
                    new SpecieCount { Name = "Cat", Count = 1},
                }
            });

            expected.Add(new AnimalSpecieInfo
            {
                ShelterName = "Loved Pet Shelter",
                Species = new List<SpecieCount>
                {
                    new SpecieCount { Name = "Hamster", Count = 2},
                    new SpecieCount { Name = "Cat", Count = 1},
                    new SpecieCount { Name = "Parrot", Count = 1}
                }
            });

            var actual = sl.GetAnimalSpeciesCountByShelter().ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected[0].ShelterName, actual[0].ShelterName);
                Assert.AreEqual(expected[0].Species, actual[0].Species);

                Assert.AreEqual(expected[1].ShelterName, actual[1].ShelterName);
                Assert.AreEqual(expected[1].Species, actual[1].Species);
            });
        }

        [Test]
        public void AverageAnimalAgeTest()
        {
            List<AgeInfo> expected = new List<AgeInfo>();

            expected.Add(new AgeInfo { ShelterName = "Animal Haven", Average = 7.0d });
            expected.Add(new AgeInfo { ShelterName = "Loved Pet Shelter", Average = 10.0d });

            var actual = sl.GetAverageAnimalAgeByShelter().ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected[0].ShelterName, actual[0].ShelterName);
                Assert.AreEqual(expected[0].Average, actual[0].Average);

                Assert.AreEqual(expected[1].ShelterName, actual[1].ShelterName);
                Assert.AreEqual(expected[1].Average, actual[1].Average);
            });
        }

        [Test]
        public void AverageWorkerAgeTest()
        {
            List<AgeInfo> expected = new List<AgeInfo>();

            expected.Add(new AgeInfo { ShelterName = "Animal Haven", Average = 48.0d });
            expected.Add(new AgeInfo { ShelterName = "Loved Pet Shelter", Average = 28.0d });

            var actual = sl.GetAverageWorkerAgeByShelter().ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected[0].ShelterName, actual[0].ShelterName);
                Assert.AreEqual(expected[0].Average, actual[0].Average);

                Assert.AreEqual(expected[1].ShelterName, actual[1].ShelterName);
                Assert.AreEqual(expected[1].Average, actual[1].Average);
            });
        }
    }
}
