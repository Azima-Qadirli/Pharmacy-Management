class Program
{
    static void Main(string[] args)
    {
        var pharmacyManagement = new ManagementOfPharmacy();

        while (true)
        {
            Console.WriteLine("Welcome to Pharmacy Management System:");
            Console.WriteLine("1. Search shelves");
            Console.WriteLine("2. Search medicine");
            Console.WriteLine("3. Add medicine");
            Console.WriteLine("4. Sell medicine");
            Console.WriteLine("5. Update medicine or shelf");
            Console.WriteLine("6. Exit");
            Console.Write("Please, select your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pharmacyManagement.SearchShelves();
                    break;
                case "2":
                    pharmacyManagement.SearchMedicine();
                    break;
                case "3":
                    pharmacyManagement.AddMedicine();
                    break;
                case "4":
                    pharmacyManagement.SellMedicine();
                    break;
                case "5":
                    pharmacyManagement.UpdateMedicineOrShelf();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
