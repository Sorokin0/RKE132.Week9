string folderPath = @"C:\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShopingList = new List<string>();
if(File.Exists(filePath))
{
    myShopingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShopingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myShopingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShopingList);
}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}


static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} to you shoping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
