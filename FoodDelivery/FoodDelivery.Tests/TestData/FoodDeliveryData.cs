using FoodDelivery.Domain.Models;

namespace FoodDelivery.Tests.TestData;

public class FoodDeliveryData
{
    public List<Category> Categories { get; } =
    [
        new Category { Id = 1, Name = "Пицца" },
        new Category { Id = 2, Name = "Бургеры" },
        new Category { Id = 3, Name = "Суши" },
        new Category { Id = 4, Name = "Салаты" },
        new Category { Id = 5, Name = "Супы" },
        new Category { Id = 6, Name = "Паста" },
        new Category { Id = 7, Name = "Десерты" },
        new Category { Id = 8, Name = "Напитки" },
        new Category { Id = 9, Name = "Завтраки" },
        new Category { Id = 10, Name = "Закуски" }
    ];

    public List<Dish> Dishes { get; }

    public List<Restaurant> Restaurants { get; } =
    [
        new Restaurant
        {
            Id = 1,
            Name = "Вкусно рядом",
            Address = "ул. Ленинградская, 10",
            Rating = 4.8m,
            OpeningTime = new TimeSpan(9, 0, 0),
            ClosingTime = new TimeSpan(23, 0, 0)
        },
        new Restaurant
        {
            Id = 2,
            Name = "Дом еды",
            Address = "ул. Молодогвардейская, 25",
            Rating = 4.6m,
            OpeningTime = new TimeSpan(10, 0, 0),
            ClosingTime = new TimeSpan(22, 0, 0)
        },
        new Restaurant
        {
            Id = 3,
            Name = "Городская кухня",
            Address = "ул. Победы, 15",
            Rating = 4.5m,
            OpeningTime = new TimeSpan(9, 0, 0),
            ClosingTime = new TimeSpan(23, 0, 0)
        },
        new Restaurant
        {
            Id = 4,
            Name = "Пицца Хаус",
            Address = "ул. Гагарина, 42",
            Rating = 4.4m,
            OpeningTime = new TimeSpan(10, 0, 0),
            ClosingTime = new TimeSpan(0, 0, 0)
        },
        new Restaurant
        {
            Id = 5,
            Name = "Суши Тайм",
            Address = "ул. Осипенко, 18",
            Rating = 4.7m,
            OpeningTime = new TimeSpan(11, 0, 0),
            ClosingTime = new TimeSpan(23, 0, 0)
        },
        new Restaurant
        {
            Id = 6,
            Name = "Бургер Бар",
            Address = "ул. Московское шоссе, 5",
            Rating = 4.3m,
            OpeningTime = new TimeSpan(10, 0, 0),
            ClosingTime = new TimeSpan(1, 0, 0)
        },
        new Restaurant
        {
            Id = 7,
            Name = "Семейный ресторан",
            Address = "ул. Советской Армии, 31",
            Rating = 4.2m,
            OpeningTime = new TimeSpan(9, 0, 0),
            ClosingTime = new TimeSpan(22, 0, 0)
        },
        new Restaurant
        {
            Id = 8,
            Name = "Кафе Центр",
            Address = "ул. Куйбышева, 12",
            Rating = 4.1m,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(22, 0, 0)
        },
        new Restaurant
        {
            Id = 9,
            Name = "Итальянский дворик",
            Address = "ул. Фрунзе, 7",
            Rating = 4.6m,
            OpeningTime = new TimeSpan(11, 0, 0),
            ClosingTime = new TimeSpan(23, 0, 0)
        },
        new Restaurant
        {
            Id = 10,
            Name = "Азия Фуд",
            Address = "ул. Авроры, 20",
            Rating = 4.5m,
            OpeningTime = new TimeSpan(10, 0, 0),
            ClosingTime = new TimeSpan(23, 0, 0)
        }
    ];

    public List<Customer> Customers { get; } =
    [
        new Customer
        {
            Id = 1,
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Петрович",
            Phone = "+79000000001",
            DeliveryAddress = "ул. Садовая, 1"
        },
        new Customer
        {
            Id = 2,
            LastName = "Петров",
            FirstName = "Алексей",
            Patronymic = "Иванович",
            Phone = "+79000000002",
            DeliveryAddress = "ул. Молодогвардейская, 12"
        },
        new Customer
        {
            Id = 3,
            LastName = "Сидорова",
            FirstName = "Мария",
            Patronymic = "Александровна",
            Phone = "+79000000003",
            DeliveryAddress = "ул. Гагарина, 20"
        },
        new Customer
        {
            Id = 4,
            LastName = "Кузнецов",
            FirstName = "Дмитрий",
            Patronymic = "Сергеевич",
            Phone = "+79000000004",
            DeliveryAddress = "ул. Ленинградская, 45"
        },
        new Customer
        {
            Id = 5,
            LastName = "Смирнова",
            FirstName = "Анна",
            Patronymic = "Викторовна",
            Phone = "+79000000005",
            DeliveryAddress = "ул. Победы, 8"
        },
        new Customer
        {
            Id = 6,
            LastName = "Попов",
            FirstName = "Максим",
            Patronymic = "Олегович",
            Phone = "+79000000006",
            DeliveryAddress = "ул. Осипенко, 15"
        },
        new Customer
        {
            Id = 7,
            LastName = "Волкова",
            FirstName = "Елена",
            Patronymic = "Игоревна",
            Phone = "+79000000007",
            DeliveryAddress = "ул. Фрунзе, 30"
        },
        new Customer
        {
            Id = 8,
            LastName = "Морозов",
            FirstName = "Андрей",
            Patronymic = "Николаевич",
            Phone = "+79000000008",
            DeliveryAddress = "ул. Куйбышева, 17"
        },
        new Customer
        {
            Id = 9,
            LastName = "Орлова",
            FirstName = "Ольга",
            Patronymic = "Павловна",
            Phone = "+79000000009",
            DeliveryAddress = "ул. Советской Армии, 9"
        },
        new Customer
        {
            Id = 10,
            LastName = "Никитин",
            FirstName = "Роман",
            Patronymic = "Андреевич",
            Phone = "+79000000010",
            DeliveryAddress = "ул. Авроры, 14"
        },
        new Customer
        {
            Id = 11,
            LastName = "Федорова",
            FirstName = "Дарья",
            Patronymic = "Ильинична",
            Phone = "+79000000011",
            DeliveryAddress = "ул. Самарская, 21"
        },
        new Customer
        {
            Id = 12,
            LastName = "Лебедев",
            FirstName = "Николай",
            Patronymic = "Васильевич",
            Phone = "+79000000012",
            DeliveryAddress = "ул. Полевая, 4"
        },
        new Customer
        {
            Id = 13,
            LastName = "Громова",
            FirstName = "София",
            Patronymic = "Романовна",
            Phone = "+79000000013",
            DeliveryAddress = "ул. Ново-Садовая, 36"
        },
        new Customer
        {
            Id = 14,
            LastName = "Зайцев",
            FirstName = "Евгений",
            Patronymic = "Михайлович",
            Phone = "+79000000014",
            DeliveryAddress = "ул. Полевой проезд, 11"
        },
        new Customer
        {
            Id = 15,
            LastName = "Белова",
            FirstName = "Ксения",
            Patronymic = "Олеговна",
            Phone = "+79000000015",
            DeliveryAddress = "ул. Мичурина, 19"
        }
    ];

    public List<Order> Orders { get; }

    public FoodDeliveryData()
    {
        Dishes =
        [
            new Dish
            {
                Id = 1,
                Name = "Маргарита",
                Weight = 500,
                Price = 650m,
                Category = Categories[0]
            },
            new Dish
            {
                Id = 2,
                Name = "Пепперони",
                Weight = 550,
                Price = 750m,
                Category = Categories[0]
            },
            new Dish
            {
                Id = 3,
                Name = "Четыре сыра",
                Weight = 520,
                Price = 800m,
                Category = Categories[0]
            },
            new Dish
            {
                Id = 4,
                Name = "Классический бургер",
                Weight = 350,
                Price = 500m,
                Category = Categories[1]
            },
            new Dish
            {
                Id = 5,
                Name = "Чизбургер",
                Weight = 370,
                Price = 550m,
                Category = Categories[1]
            },
            new Dish
            {
                Id = 6,
                Name = "Двойной бургер",
                Weight = 450,
                Price = 700m,
                Category = Categories[1]
            },
            new Dish
            {
                Id = 7,
                Name = "Филадельфия",
                Weight = 280,
                Price = 650m,
                Category = Categories[2]
            },
            new Dish
            {
                Id = 8,
                Name = "Калифорния",
                Weight = 300,
                Price = 600m,
                Category = Categories[2]
            },
            new Dish
            {
                Id = 9,
                Name = "Темпура",
                Weight = 320,
                Price = 700m,
                Category = Categories[2]
            },
            new Dish
            {
                Id = 10,
                Name = "Цезарь",
                Weight = 250,
                Price = 450m,
                Category = Categories[3]
            },
            new Dish
            {
                Id = 11,
                Name = "Греческий салат",
                Weight = 240,
                Price = 400m,
                Category = Categories[3]
            },
            new Dish
            {
                Id = 12,
                Name = "Овощной салат",
                Weight = 220,
                Price = 350m,
                Category = Categories[3]
            },
            new Dish
            {
                Id = 13,
                Name = "Куриный суп",
                Weight = 400,
                Price = 350m,
                Category = Categories[4]
            },
            new Dish
            {
                Id = 14,
                Name = "Солянка",
                Weight = 400,
                Price = 420m,
                Category = Categories[4]
            },
            new Dish
            {
                Id = 15,
                Name = "Том Ям",
                Weight = 450,
                Price = 650m,
                Category = Categories[4]
            },
            new Dish
            {
                Id = 16,
                Name = "Карбонара",
                Weight = 400,
                Price = 600m,
                Category = Categories[5]
            },
            new Dish
            {
                Id = 17,
                Name = "Болоньезе",
                Weight = 420,
                Price = 650m,
                Category = Categories[5]
            },
            new Dish
            {
                Id = 18,
                Name = "Альфредо",
                Weight = 400,
                Price = 620m,
                Category = Categories[5]
            },
            new Dish
            {
                Id = 19,
                Name = "Чизкейк",
                Weight = 180,
                Price = 350m,
                Category = Categories[6]
            },
            new Dish
            {
                Id = 20,
                Name = "Тирамису",
                Weight = 180,
                Price = 400m,
                Category = Categories[6]
            },
            new Dish
            {
                Id = 21,
                Name = "Шоколадный торт",
                Weight = 200,
                Price = 450m,
                Category = Categories[6]
            },
            new Dish
            {
                Id = 22,
                Name = "Кола",
                Weight = 500,
                Price = 150m,
                Category = Categories[7]
            },
            new Dish
            {
                Id = 23,
                Name = "Морс",
                Weight = 500,
                Price = 120m,
                Category = Categories[7]
            },
            new Dish
            {
                Id = 24,
                Name = "Лимонад",
                Weight = 500,
                Price = 180m,
                Category = Categories[7]
            },
            new Dish
            {
                Id = 25,
                Name = "Омлет",
                Weight = 300,
                Price = 350m,
                Category = Categories[8]
            },
            new Dish
            {
                Id = 26,
                Name = "Сырники",
                Weight = 250,
                Price = 400m,
                Category = Categories[8]
            },
            new Dish
            {
                Id = 27,
                Name = "Каша",
                Weight = 300,
                Price = 300m,
                Category = Categories[8]
            },
            new Dish
            {
                Id = 28,
                Name = "Наггетсы",
                Weight = 250,
                Price = 350m,
                Category = Categories[9]
            },
            new Dish
            {
                Id = 29,
                Name = "Картофель фри",
                Weight = 200,
                Price = 250m,
                Category = Categories[9]
            },
            new Dish
            {
                Id = 30,
                Name = "Луковые кольца",
                Weight = 200,
                Price = 300m,
                Category = Categories[9]
            }
        ];

        Orders =
        [
            CreateOrder(1, 1, 1, 1, 500m, 30),
            CreateOrder(2, 1, 2, 4, 650m, 25),
            CreateOrder(3, 1, 3, 7, 800m, 45),
            CreateOrder(4, 1, 4, 10, 900m, 20),
            CreateOrder(5, 1, 5, 16, 1100m, 35),
            CreateOrder(6, 1, 6, 19, 1250m, 40),

            CreateOrder(7, 2, 1, 2, 750m, 30),
            CreateOrder(8, 2, 2, 5, 700m, 25),
            CreateOrder(9, 2, 3, 8, 600m, 35),
            CreateOrder(10, 2, 4, 11, 850m, 45),
            CreateOrder(11, 2, 5, 17, 1300m, 30),

            CreateOrder(12, 3, 1, 3, 800m, 20),
            CreateOrder(13, 3, 2, 6, 900m, 40),
            CreateOrder(14, 3, 3, 9, 700m, 25),
            CreateOrder(15, 3, 4, 12, 650m, 30),
            CreateOrder(16, 3, 5, 18, 1200m, 35),

            CreateOrder(17, 4, 1, 1, 650m, 25),
            CreateOrder(18, 4, 2, 4, 500m, 30),
            CreateOrder(19, 4, 3, 10, 450m, 20),
            CreateOrder(20, 4, 6, 22, 1200m, 40),

            CreateOrder(21, 5, 1, 7, 650m, 35),
            CreateOrder(22, 5, 2, 8, 600m, 30),
            CreateOrder(23, 5, 3, 13, 350m, 25),
            CreateOrder(24, 5, 4, 16, 600m, 20),

            CreateOrder(25, 6, 1, 2, 750m, 30),
            CreateOrder(26, 6, 2, 5, 550m, 25),
            CreateOrder(27, 6, 3, 14, 420m, 35),

            CreateOrder(28, 7, 1, 19, 350m, 30),
            CreateOrder(29, 7, 2, 20, 400m, 25),

            CreateOrder(30, 8, 3, 22, 150m, 20),
            CreateOrder(31, 8, 4, 23, 120m, 30),

            CreateOrder(32, 9, 5, 17, 1300m, 40),
            CreateOrder(33, 9, 6, 18, 620m, 35),

            CreateOrder(34, 10, 1, 24, 180m, 25),
            CreateOrder(35, 10, 2, 25, 350m, 30),

            CreateOrder(36, 11, 1, 26, 400m, 20),
            CreateOrder(37, 12, 2, 27, 300m, 25),
            CreateOrder(38, 13, 3, 28, 350m, 35),
            CreateOrder(39, 14, 4, 29, 250m, 30),
            CreateOrder(40, 15, 5, 30, 300m, 45)
        ];
    }

    private Order CreateOrder(
        int id,
        int restaurantId,
        int customerId,
        int dishId,
        decimal totalAmount,
        int deliveryMinutes)
    {
        DateTime createdAt = new DateTime(2026, 9, 1)
            .AddDays(id - 1)
            .AddHours(12);

        return new Order
        {
            Id = id,
            Customer = Customers[customerId - 1],
            Restaurant = Restaurants[restaurantId - 1],
            CreatedAt = createdAt,
            DeliveredAt = createdAt.AddMinutes(deliveryMinutes),
            TotalAmount = totalAmount,
            Items =
            [
                new OrderItem
                {
                    Id = id,
                    Dish = Dishes[dishId - 1],
                    Quantity = 1,
                    UnitPrice = Dishes[dishId - 1].Price
                }
            ]
        };
    }
}