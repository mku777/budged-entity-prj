using tfmpj.Model;
using tfmpj.Model.Entities;
using System;

using (var db = new BudgetContext())
{


    var result = db.Transactions.Join(
       db.Users, // вторая таблица для объединения
        t => t.UserId, // ключ из первой таблицы (Transactions)
        u => u.Id, // ключ из второй таблицы (Users)
        (t, u) => new // результат объединения
        {
            // Выберите поля, которые вы хотите включить в результат
            TransactionId = t.TransactionId,
            Amount = t.Amount,
            Date = t.Date,
            Description = t.Description,
            UserName = u.UserName,
            CategoryId = t.CategoryId
        });

    foreach (var item in result)
    {
        Console.WriteLine($"TransactionId: {item.TransactionId}, Amount: {item.Amount}, Date: {item.Date}, Description: {item.Description}, UserName: {item.UserName}, CategoryId: {item.CategoryId}");
    }




    //db.Database.EnsureCreated();
    //var user = new User()
    //{
    //    UserName = "Jasya",
    //};
    //db.Users.Add(user);
    //db.SaveChanges();

    //var incomeCategory = new Category()
    //{
    //    Name = "Дохід",
    //};
    //db.Categories.Add(incomeCategory);

    //var expenseCategory = new Category()
    //{
    //    Name = "Витрати",
    //};
    //db.Categories.Add(expenseCategory);


    //db.SaveChanges();

    //var incomeTransaction = new Transaction()
    //{
    //    Amount = 1000,
    //    Date = DateTime.Now,
    //    Description = "Зарплата",
    //    UserId = user.Id, 
    //    CategoryId = incomeCategory.CategoryId
    //};
    //db.Transactions.Add(incomeTransaction);

    //var expenseTransaction = new Transaction()
    //{
    //    Amount = -100,
    //    Date = DateTime.Now,
    //    Description = "Іграшки",
    //    UserId = user.Id, 
    //    CategoryId = expenseCategory.CategoryId
    //};
    //db.Transactions.Add(expenseTransaction);


    //db.SaveChanges();
}