using Group5_API_Project.Models;

namespace Group5_API_Project.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }
            /***
             * 
             * Init data for table Account 
             * Account(AccountID, Email, Password, Fullname, PhoneNumber, Address, RoleID)
             * In Account the AccountID that is auto Identity
             * 
             ***/
            var accounts = new Account[]
            {
                new Account
                {   
                    AccountID = 1,
                    Email = "toannvce150811@fpt.edu.vn",
                    FullName = "Nguyen Van Toan",
                    Password = "123456",
                    Address = "Can Tho, Viet Nam",
                    PhoneNumber = "0762871115",
                    RoleID = 1
                },
                new Account
                {
                    AccountID = 2,
                    Email = "nguyentoan.01288@gmail.com",
                    FullName = "Nguyen Van Toan",
                    Password = "123456",
                    Address = "Can Tho, Viet Nam",
                    PhoneNumber = "0762871115",
                    RoleID = 2
                },
                new Account
                {
                    AccountID = 3,
                    Email = "mplkingofworld@gmail.com",
                    FullName = "Nguyen Van Toan",
                    Password = "123456",
                    Address = "Can Tho, Viet Nam",
                    PhoneNumber = "0762871115",
                    RoleID = 3
                },
                new Account
                {
                    AccountID = 4,
                    Email = "nguyenvtoan.01@gmail.com",
                    FullName = "Nguyen Van Toan",
                    Password = "123456",
                    Address = "Can Tho, Viet Nam",
                    PhoneNumber = "0762871115",
                    RoleID = 4
                }
            };
            foreach (Account account in accounts)
            {
                context.Accounts.Add(account);
            }

            /***
             * 
             * Init data for table Category 
             * Category(CategoryID, CategoryName, Description, CreatedDate)
             * In Category the CategoryID that is auto Identity
             * 
             ***/
            var categories = new Category[]
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Once Piece",
                    Description = "The toys of Once Piece (Luffy, Ace,...)",
                    CreatedDate = new DateTime(2021, 03, 03)
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Dragon Ball",
                    Description = "The toys of Dragon Ball (Son Goku, Vegeta, Bulma,...)",
                    CreatedDate = new DateTime(2020, 07, 15)
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Adventure",
                    Description = "The toys of Adventure (Iron Man, Superman, Wonder Woman,...)",
                    CreatedDate = new DateTime(2020, 09, 23)
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Pokemon",
                    Description = "The toys of Pokemon (Pikachu, Articuno, Zapdos,...)",
                    CreatedDate = new DateTime(2022, 10, 30)
                }
            };
            foreach (Category category in categories)
            {
                context.Categories.Add(category);
            }

            /***
             * 
             * Init data for table Order 
             * Order(OrderID, CustomerName, ShipperName, PhoneNumber, OrderDate, StartDeliveryDate, EndDeliveryDate, Address, ProductID, OrderStatus)
             * In Order the OrderID that is auto Identity
             * 
             ***/
            var orders = new Order[]
            {
                new Order
                {
                    OrderID = 1,
                    CustomerName = "Nguyen Toan",
                    ShipperName = "Nguyen Toan",
                    PhoneNumber = "0762871115",
                    OrderDate = new DateTime(2023, 01, 20),
                    StartDeliveryDate = new DateTime(2023, 01, 23),
                    EndDeliveryDate = new DateTime(2023, 01, 25),
                    Address = "Can Tho, VietNam",
                    ProductID = 1,
                    OrderCheckingID = 1
                },
                new Order
                {
                    OrderID = 2,
                    CustomerName = "Toan",
                    ShipperName = "Nguyen Toan",
                    PhoneNumber = "0762871115",
                    OrderDate = new DateTime(2023, 01, 20),
                    StartDeliveryDate = new DateTime(2023, 01, 23),
                    EndDeliveryDate = new DateTime(2023, 01, 25),
                    Address = "Can Tho, VietNam",
                    ProductID = 2,
                    OrderCheckingID = 2
                },
                new Order
                {
                    OrderID = 3,
                    CustomerName = "Nguyen Van Toan",
                    ShipperName = "Nguyen Toan",
                    PhoneNumber = "0762871115",
                    OrderDate = new DateTime(2023, 01, 20),
                    StartDeliveryDate = new DateTime(2023, 01, 23),
                    EndDeliveryDate = new DateTime(2023, 01, 25),
                    Address = "Can Tho, VietNam",
                    ProductID = 3,
                    OrderCheckingID =  3
                }
            };
            foreach (Order order in orders)
            {
                context.Orders.Add(order);
            }

            /***
             * 
             * Init data for table OrderDetail 
             * OrderDetail(OrderID, ProductID, Quantity, TotalPrice, Discount)
             * In OrderDetail the OrderID and ProductID that are Primary key of 2 tables (Order, Product)
             * 
             ***/
            var details = new OrderDetail[]
            {
                new OrderDetail
                {
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 2,
                    TotalPrice = 1000000,
                    Discount = 10                    
                },
                new OrderDetail
                {
                    OrderID = 2,
                    ProductID = 2,
                    Quantity = 5,
                    TotalPrice = 1900000,
                    Discount = 5
                },
                new OrderDetail
                {
                    OrderID = 3,
                    ProductID = 3,
                    Quantity = 4,
                    TotalPrice = 1700000,
                    Discount = 12
                }
            };
            foreach (OrderDetail detail in details)
            {
                context.OrderDetails.Add(detail);
            }

            /***
             * 
             * Init data for table Product 
             * Product(ProductID, ProductName, Quantity, UnitPrice, CreatedDate, SupplierID, CategoryID)
             * In Product the ProductID that is auto Identity
             * 
             ***/
            var products = new Product[]
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Luffy Gear 3",
                    Quantity = 150,
                    UnitPrice = 500000,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Bulma",
                    Quantity = 250,
                    UnitPrice = 650000,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Iron Man",
                    Quantity = 50,
                    UnitPrice = 550000,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Pikachu",
                    Quantity = 100,
                    UnitPrice = 350000,
                    CategoryID = 4
                }
            };
            foreach (Product product in products)
            {
                context.Products.Add(product);
            }

            /***
             * 
             * Init data for table RoleManager 
             * RoleManager(RoleID, RoleName)
             * In RoleManager the RoleID that is auto Identity
             * 
             ***/
            var roles = new RoleManager[]
            {
                new RoleManager
                {
                    RoleManagerID = 1,
                    RoleManagerName = "Administrator"
                },
                new RoleManager
                {
                    RoleManagerID = 2,
                    RoleManagerName = "Employee"
                },
                new RoleManager
                {
                    RoleManagerID = 3,
                    RoleManagerName = "Shipper"
                },new RoleManager
                {
                    RoleManagerID = 4,
                    RoleManagerName = "Customer"
                }
            };
            foreach (RoleManager role in roles)
            {
                context.RoleManagers.Add(role);
            }

            /***
             * 
             * Init data for table OrderChecking 
             * OrderChecking(OrderCheckingID, OrderCheckingName)
             * In OrderChecking the OrderCheckingID that is auto Identity
             * 
             ***/
            var orderCheck = new OrderChecking[]
            {
                new OrderChecking
                {
                    OrderCheckingID = 1,
                    OrderCheckingName = "Confirmed"
                },
                new OrderChecking
                {
                    OrderCheckingID = 2,
                    OrderCheckingName = "Delivering"
                },
                new OrderChecking
                {
                    OrderCheckingID = 3,
                    OrderCheckingName = "Received"
                },
                new OrderChecking
                {
                    OrderCheckingID = 4,
                    OrderCheckingName = "Cancel"
                }
            };
            foreach (OrderChecking check in orderCheck)
            {
                context.OrderCheckings.Add(check);
            }
        }
    }
}
