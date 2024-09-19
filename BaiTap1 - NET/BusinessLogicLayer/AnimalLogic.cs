using NongTraiVuiVe.DataAccessLayer;
using NongTraiVuiVe.DataAccessLayer.DataClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NongTraiVuiVe.BusinessLogicLayer
{
    public class AnimalLogic
    {
        private AnimalDAL _animalDAL = new AnimalDAL();

        public List<Animal> GetAllAnimals()
        {
            return _animalDAL.GetAllAnimals();
        }

        public List<DTO> Statistical(int cowAmount, int sheepAmount, int goatAmount)
        {
            List<Animal> animals = _animalDAL.GetAllAnimals();
            List<DTO> data = new List<DTO>();

            foreach (Animal animal in animals)
            {
                DTO dt = new DTO();
                switch(animal.AnimalType.ToLower())
                {
                    case "cow":
                        dt.CurrentAmount = cowAmount;
                        dt.TotalMilk = ProduceMilk(animal, cowAmount);
                        dt.TotalGiveBirth = GiveBirth(animal, cowAmount);
                        break;
                    case "sheep":
                        dt.CurrentAmount = sheepAmount;
                        dt.TotalMilk = ProduceMilk(animal, sheepAmount);
                        dt.TotalGiveBirth = GiveBirth(animal, sheepAmount);
                        break;
                    case "goat":
                        dt.CurrentAmount = goatAmount;
                        dt.TotalMilk = ProduceMilk(animal, goatAmount);
                        dt.TotalGiveBirth = GiveBirth(animal, goatAmount);
                        break;
                }
                dt.AnimalType = animal.AnimalType;
                dt.TotalAmount = dt.CurrentAmount + dt.TotalGiveBirth;

                data.Add(dt);
            }

            return data;
        }

        public int ProduceMilk(Animal animal, int count)
        {
            int totalMilk = 0;
            for (int i = 0; i < count;i++)
            {
                
                totalMilk += animal.ProduceMilk();
            }
            return totalMilk;
        }

        public int GiveBirth(Animal animal, int count)
        {
            int totalGiveBirth = 0;
            for(int i = 0; i< count;i++)
            {
                totalGiveBirth += animal.GiveBirth();
            }
            return totalGiveBirth;
        }
    }
}
