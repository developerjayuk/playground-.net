using GuestBook;

// REQUIREMENTS
//1.Welcome user to the app
//2. Have a menu 
//a. add to guestlist
//b. show guestlist
//3. Ask for their full name 
//    - confirm valid string
//4. Ask how many people are in their party
//    - confirm a valid number
//5. Keep track of how many people are at the party
//6. Print out the guestlist
//7. Print out the total number of guest

GuestList guestList = new();

Console.WriteLine("Hello and welcome to the hottest party of the Year \"The C# Pool Party\"");
guestList.DisplayMenu();
