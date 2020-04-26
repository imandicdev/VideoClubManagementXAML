# VideoClubManagementXAML 
Video Club Management project in C#/WPF using MS SQL Server/Entity Framework as data stack.
The main logic is in the /Services/RentingService.cs
The goal was to write a management service to implement renting of movies if following conditions is met :
- User is not allowed to  rent more than 4 movies at once
- If there are titles to be returned, user is not allowed to rent.
- If user rented a title in the past, it's not allowed to rent the same title again.
- Check if title is in the stock, if not - user can't rent the title.

Implement the deadline for return :
-If there is one title rented, user has 2 days to return title.
-For each title add 2 days for return :
-If 3 and up, 6 days deadline
-If 2, 4 days

Implementation of WPF BooleanToVisibility Converter and InverseBooleanToVisibility is in the folder Useful


 NOTE: Didn't land the job due to non-programming non-technical reasons. Maybe still someone finds it useful.

