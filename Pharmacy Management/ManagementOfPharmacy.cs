using Pharmacy_Management;

public class ManagementOfPharmacy
{
    public List<Shelf> Shelves { get; set; } = new List<Shelf>();

    public void SearchShelves()
    {
        Console.WriteLine("Enter ID of the shelf to search:");
        var shelfId = Console.ReadLine();
        var shelf = Shelves.FirstOrDefault(s => s.ShelfId == shelfId);

        if (shelf != null)
        {
            Console.WriteLine($"Shelf ID: {shelf.ShelfId}");
            foreach (var medicine in shelf.Medicines)
            {
                Console.WriteLine(medicine);
            }
        }
        else
        {
            Console.WriteLine("Shelf not found.");
        }
    }

    public void SearchMedicine()
    {
        Console.WriteLine("Enter 1 to search by name, 2 to search by purpose:");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter medicine name to find:");
                var name = Console.ReadLine();
                Medicine foundByName = null;
                foreach (var shelf in Shelves)
                {
                    foundByName = shelf.GetMedicineByName(name);
                    if (foundByName != null)
                    {
                        break;
                    }
                }
                if (foundByName != null)
                {
                    Console.WriteLine(foundByName);
                }
                else
                {
                    Console.WriteLine("Medicine not found.");
                }
                break;
            case "2":
                Console.WriteLine("Enter purpose of medicine to find:");
                var purpose = Console.ReadLine();
                Medicine foundByPurpose = null;
                foreach (var shelf in Shelves)
                {
                    foundByPurpose = shelf.GetMedicineByPurpose(purpose);
                    if (foundByPurpose != null)
                    {
                        break;
                    }
                }
                if (foundByPurpose != null)
                {
                    Console.WriteLine(foundByPurpose);
                }
                else
                {
                    Console.WriteLine("Medicine not found.");
                }
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void AddMedicine()
    {
        Console.WriteLine("Enter shelf ID to add medicine:");
        var shelfId = Console.ReadLine();
        var shelf = Shelves.FirstOrDefault(s => s.ShelfId == shelfId);
        if (shelf == null)
        {
            shelf = new Shelf { ShelfId = shelfId };
            Shelves.Add(shelf);
        }

        Console.WriteLine("Enter medicine name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter medicine price:");
        var price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter medicine purpose:");
        var purpose = Console.ReadLine();

        var newMedicine = new Medicine(name, price, purpose, shelfId);
        shelf.AddMedicine(newMedicine);

        Console.WriteLine("Medicine added successfully.");
    }

    public void SellMedicine()
    {
        Console.WriteLine("Enter medicine name to sell:");
        var name = Console.ReadLine();
        Medicine medicineToSell = null;
        foreach (var shelf in Shelves)
        {
            medicineToSell = shelf.GetMedicineByName(name);
            if (medicineToSell != null)
            {
                break;
            }
        }

        if (medicineToSell != null)
        {
            Console.WriteLine($"Medicine sold: {medicineToSell.Name}, Price: {medicineToSell.Price}");
            foreach (var shelf in Shelves)
            {
                shelf.RemoveMedicine(medicineToSell);
            }
        }
        else
        {
            Console.WriteLine("Medicine not found.");
        }
    }

    public void UpdateMedicineOrShelf()
    {
        Console.WriteLine("Enter 1 to update medicine, 2 to update shelf:");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter medicine name to update:");
                var name = Console.ReadLine();
                Medicine medicineToUpdate = null;
                foreach (var shelf in Shelves)
                {
                    medicineToUpdate = shelf.GetMedicineByName(name);
                    if (medicineToUpdate != null)
                    {
                        break;
                    }
                }
                if (medicineToUpdate != null)
                {
                    Console.WriteLine("Enter new medicine name:");
                    var newName = Console.ReadLine();
                    Console.WriteLine("Enter new price:");
                    var newPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new purpose:");
                    var newPurpose = Console.ReadLine();

                    var updatedMedicine = new Medicine(newName, newPrice, newPurpose, medicineToUpdate.Shelf);
                    foreach (var shelf in Shelves)
                    {
                        if (shelf.ShelfId == updatedMedicine.Shelf)
                        {
                            shelf.UpdateMedicine(name, updatedMedicine);
                        }
                    }
                    Console.WriteLine("Medicine updated successfully.");
                }
                else
                {
                    Console.WriteLine("Medicine not found.");
                }
                break;
            case "2":
                Console.WriteLine("Enter shelf ID to update:");
                var shelfID = Console.ReadLine();
                var shelfToUpdate = Shelves.FirstOrDefault(s => s.ShelfId == shelfID);
                if (shelfToUpdate != null)
                {
                    Console.WriteLine("Enter new shelf ID:");
                    var newShelfID = Console.ReadLine();
                    shelfToUpdate.ShelfId = newShelfID;
                    Console.WriteLine("Shelf updated successfully.");
                }
                else
                {
                    Console.WriteLine("Shelf not found.");
                }
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
