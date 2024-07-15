using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management
{

    public class Shelf
    {
        public string ShelfId { get; set; }
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();

        public void AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);
        }

        public void RemoveMedicine(Medicine medicine)
        {
            Medicines.Remove(medicine);
        }

        public Medicine GetMedicineByName(string name)
        {
            foreach (var medicine in Medicines)
            {
                if (medicine.Name == name)
                {
                    return medicine;
                }
            }
            return null;
        }

        public Medicine GetMedicineByPurpose(string purpose)
        {
            foreach (var medicine in Medicines)
            {
                if (medicine.Purpose == purpose)
                {
                    return medicine;
                }
            }
            return null;
        }

        public void UpdateMedicine(string name, Medicine updatedMedicine)
        {
            var medicine = GetMedicineByName(name);
            if (medicine != null)
            {
                medicine.Name = updatedMedicine.Name;
                medicine.Price = updatedMedicine.Price;
                medicine.Purpose = updatedMedicine.Purpose;
                medicine.Shelf = updatedMedicine.Shelf;
            }
        }
    }
}