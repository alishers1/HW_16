using SOLID.Entities;

/*Single responsiblity principle — у каждой сущности должна быть своя ответственность, 
должна быть только одна причина изменять или же добавлять.*/

// Плохо: Класс управления заказами отвечает и за обработку заказов, и за логирование.
class OrderManager
{
    public void ProcessOrder(Order order)
    {
        // Обработка заказа
    }

    public void LogOrder(Order order)
    {
        // Логирование заказа
    }
}

// Хорошо: Разделение ответственности между двумя классами.
class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Обработка заказа
    }
}

class OrderLogger
{
    public void LogOrder(Order order)
    {
        // Логирование заказа
    }
}


// Open closed principle — класс открыт для расширения, но закрыт для модификации.
// Плохо: Класс заказа имеет жесткую зависимость от типов продуктов.
class Order
{
    public Product Product { get; set; }
    public decimal CalculateTotal()
    {
        // Расчет стоимости заказа
    }
}

// Хорошо: Введение абстракции и использование интерфейса.
interface IProduct
{
    decimal GetPrice();
}

class Order
{
    public IProduct Product { get; set; }
    public decimal CalculateTotal()
    {
        // Расчет стоимости заказа
    }
}


/* Liskov substitution — производные классы должны уметь замещать свой родительский класс. 
Результат выполнение должен быть как у родительского класса. */ 
// Плохо: Нарушение LSP - производный класс не соответствует контракту базового.
class Bird
{
    public virtual void Fly()
    {
        // Реализация полета
    }
}

class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Страус не умеет летать");
    }
}

// Хорошо: Производный класс не нарушает контракт базового.
interface IFlyable
{
    void Fly();
}

class Bird : IFlyable
{
    public void Fly()
    {
        // Реализация полета
    }
}

class Ostrich : IFlyable
{
    public void Fly()
    {
        throw new NotImplementedException("Страус не умеет летать");
    }
}


/* Interface segregation — если ваш интерфейс имеет слишком много методов, 
то просто надо будет разделить на несколько маленьких интерфейсов. */
// Плохо: Один большой интерфейс, который клиенты не используют полностью.
interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

// Хорошо: Множество маленьких интерфейсов, каждый из которых специфичен.
interface IWorker
{
    void Work();
}

interface IEater
{
    void Eat();
}

interface ISleeper
{
    void Sleep();
}



// Dependency inversion — модули нижних уровней не должны зависеть от верхних, они зависят от абстракций. 

// Плохо: Высокоуровневый модуль зависит от низкоуровневого.
class OrderProcessor
{
    private DatabaseConnection dbConnection;

    public OrderProcessor()
    {
        dbConnection = new DatabaseConnection();
    }

    public void ProcessOrder(Order order)
    {
        // Использование dbConnection для работы с базой данных
    }
}

// Хорошо: Высокоуровневый модуль зависит от абстракции (интерфейса).
interface IDatabaseConnection
{
    void Connect();
    void Disconnect();
    void ExecuteQuery(string query);
}

class DatabaseConnection : IDatabaseConnection
{
    // Реализация методов интерфейса
}

class OrderProcessor
{
    private IDatabaseConnection dbConnection;

    public OrderProcessor(IDatabaseConnection connection)
    {
        dbConnection = connection;
    }

    public void ProcessOrder(Order order)
    {
        // Использование dbConnection для работы с базой данных
    }
}




