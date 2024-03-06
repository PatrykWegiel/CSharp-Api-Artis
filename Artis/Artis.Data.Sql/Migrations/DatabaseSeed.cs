using Artis.Common.Enum;
using Artis.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artis.Data.Sql.Migrations
{
    public class DatabaseSeed
    {
        private readonly ArtisDbContext _context;

        public DatabaseSeed(ArtisDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            var userList = BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();

            var opinionList = BuildOpinionList(userList);
            _context.Opinion.AddRange(opinionList);
            _context.SaveChanges();

            var categoryList = BuildCategoryList();
            _context.Category.AddRange(categoryList);
            _context.SaveChanges();

            var itemList = BuildItemList(categoryList, userList);
            _context.Item.AddRange(itemList);
            _context.SaveChanges();

            var bidList = BuildBidList(itemList, userList);
            _context.Bid.AddRange(bidList);
            _context.SaveChanges();

            var deliveryList = BuildDeliveryList(bidList);
            _context.Delivery.AddRange(deliveryList);
            _context.SaveChanges();

        }

        private IEnumerable<DAO.User> BuildUserList()
        {
            var userList = new List<DAO.User>();
            var rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                var user = new DAO.User
                {
                    UserName = "user" + i,
                    Name = "name" + 1,
                    Surname = "surname" + 1,
                    Email = $"user{i}@gmail.com",
                    PhoneNumber = "6473842" + (i < 10 ? i + 20 : i),
                    BirthDate = new DateTime(rand.Next(1960, 2002), rand.Next(1, 13), rand.Next(1, 29)),
                    RegistrationDate = DateTime.Now.AddYears(-2),
                    Banned = false,
                    Active = true
                };
                userList.Add(user);
            }
            return userList;
        }
        private IEnumerable<Opinion> BuildOpinionList(IEnumerable<DAO.User> userList)
        {
            var opinionList = new List<Opinion>();
            var rand = new Random();
            foreach (var user in userList)
            {
                foreach (var user2 in userList)
                {
                    if (user != user2)
                    {
                        opinionList.Add(new Opinion
                        {
                            AuthorId = user.UserId,
                            RatedUserId = user2.UserId,
                            Rate = rand.Next(1, 6),
                            Content = "super sprzedawca pozdrawiam cieplutko",
                            CreationDate = DateTime.Now.AddDays(-3),
                            Banned = false
                        });
                    }
                }
            }
            return opinionList;
        }
        private IEnumerable<Category> BuildCategoryList()
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    CategoryName = "Elektronika",
                    CategoryImage = "https://www.kolorowekable.net.pl/wp-content/uploads/2019/08/Sprz%C4%99t-AGD-Ceneo.pl_.jpg"
                },
                 new Category
                {
                    CategoryName = "Motoryzacja",
                    CategoryImage = "https://www.traveldudes.com/wp-content/uploads/2020/10/Motorbike.jpg"
                },
                  new Category
                {
                    CategoryName = "Moda",
                    CategoryImage = "https://thumbor.forbes.com/thumbor/fit-in/1200x0/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F992893220%2F0x0.jpg"
                },
                   new Category
                {
                    CategoryName = "Dom i ogród",
                    CategoryImage = "https://libreshot.com/wp-content/uploads/2016/05/family-house-and-garden.jpg"
                },
                    new Category
                {
                    CategoryName = "Sport i turystyka",
                    CategoryImage = "https://www.praca.pl/pressroom/poradniki/960x678/p960_300.jpeg"
                }
            };
            return categoryList;
        }
        private IEnumerable<DAO.Item> BuildItemList(IEnumerable<Category> categoryList, IEnumerable<DAO.User> userList)
        {

            var itemList = new List<DAO.Item>();
            var users = userList.ToList();
            var rand = new Random();
            var loremIpsum = new List<string>
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                "Curabitur sed dolor eu libero cursus pulvinar",
                "Maecenas dictum mi sodales, venenatis nisi nec, pretium dolor",
                "Morbi feugiat justo pulvinar nisi finibus, id aliquam est sollicitudin",
                "Morbi nec turpis id arcu rhoncus ullamcorper vitae sit amet felis",
                "Nullam vel orci consequat, auctor augue sit amet, pretium tellus",
                "Morbi vitae dui vel arcu varius iaculis",
                "Sed sed eros nec tellus aliquam luctus",
                "Proin placerat libero sed nisl euismod pellentesque",
                "Suspendisse vel tellus venenatis, dictum dolor ac, tincidunt nunc",
                "In ullamcorper nisi ut eros porta porta",
                "Nulla tincidunt velit quis commodo gravida",
                "Cras congue ipsum sed lorem molestie, vel venenatis lectus feugiat",
                "Proin sagittis ipsum cursus, viverra magna vel, imperdiet metus",
                "Integer lobortis libero nec sapien porta egestas",
                "Etiam egestas tellus nec ligula congue euismod",
                "Quisque fringilla diam ac justo bibendum posuere",
                "Aliquam dictum diam vel magna dapibus dictum sit amet eget magna",
                "Morbi sollicitudin dolor nec lectus facilisis rutrum",
                "Phasellus consectetur velit non condimentum imperdiet",
                "Fusce vehicula justo eget nunc volutpat ultrices",
                "Duis et tellus et enim laoreet fermentum nec sit amet ante",
                "Nam mattis purus sit amet ipsum aliquet fermentum",
                "Curabitur a sem sit amet nibh mollis euismod vitae quis magna",
                "Donec ut risus eu est pharetra egestas nec eu lectus"
            };

            var items = new Dictionary<string, List<(string, string)>>
            {
                ["Elektronika"] = new List<(string, string)>
                {
                    ("Telefon komórkowy AleFajny","https://media.istockphoto.com/photos/nokia-3310-mobile-phone-picture-id517335694?k=6&m=517335694&s=170667a&w=0&h=9ko1VEfUvH5ylCen3IKxzNgf-Ymu281sqiqXM-37GhY="),
                    ("Lodówka firmy SuperLodówki","https://cdn2.techmaniak.pl/wp-content/uploads/agdmaniak/2018/07/6.-Lodowka-Multi-door-medium.jpg"),
                    ("Mikrofalówka FikroMalówka","https://www.mall.cz/i/49650378/450/450"),
                    ("Mikser SerMik","https://www.ariete.pl/2404/mikser-planetarny-1588.jpg"),
                    ("Blender Blen-Er","https://www.electro.pl/media/cache/gallery/product/3/987/798/833/jv81bgoy/images/13/1350682/Blender-kielichowy-TEFAL-BL438831-front-mlynki.jpg")
                },
                ["Motoryzacja"] = new List<(string, string)>
                {
                    ("Sprzedam Opla!!","https://upload.wikimedia.org/wikipedia/commons/9/93/Opel_astra_F.jpg"),
                    ("Motocykl Jamacha","https://image.ceneostatic.pl/data/products/62290237/i-yamaha-mt-125-salon-polska.jpg"),
                    ("sprzedam kołpaki!!!","https://ireland.apollo.olxcdn.com/v1/files/pe3bavx51n4h2-PL/image;s=644x461"),
                },
                ["Moda"] = new List<(string, string)>
                {
                    ("Koszulki dziergane przez babcie","https://printing-season.com/wp-content/uploads/2020/04/koszulki-na-wieszaku.jpg"),
                    ("Sprzedam wygodne drewniane chodaki!","http://wiki.cantr.net/images/2/2e/Wooden_clogs.jpg"),
                },
                ["Dom i ogród"] = new List<(string, string)>
                {
                    ("Sprzedam taboret, wygodny","https://www.rossifurniture.eu/538-thickbox_default/taboret-tapicerowany-rossi-30-x-30-zielen.jpg"),
                    ("Wygodna szara kanapa","https://cdn3.jysk.com/getimage/wd2.large/110127"),
                },
                ["Sport i turystyka"] = new List<(string, string)>
                {
                    ("Piłka okrągła taka","https://hurtowniasportowa.net/public/storage/productimages/32/10/2d/ba/604515/image/xlarge.jpg"),
                    ("Wędka króla rybaków","https://www.sklep-mietus.pl/47997-large_default/wedka-shimano-stc-multi-spinning-240m270m-15-40g.jpg"),
                },
            };
            foreach (var category in categoryList)
            {
                for (int i = 0; i < items[category.CategoryName].Count; i++)
                {
                    itemList.Add(new DAO.Item
                    {
                        ItemName = items[category.CategoryName][i].Item1,
                        Condition = (i % 2 == 0 ? ItemCondition.New : (i % 3 == 0 ? ItemCondition.Used : ItemCondition.Damaged)),
                        ItemImageHref = items[category.CategoryName][i].Item2,
                        ItemDescription = loremIpsum[rand.Next(loremIpsum.Count)],
                        Banned = false,
                        Visible = true,
                        CreationDate = DateTime.Now.AddDays(-rand.Next(1, 5)),
                        EndDate = DateTime.Now,
                        StartingPrice = rand.Next(10000, 100000),
                        UserId = users[rand.Next(users.Count)].UserId,
                        CategoryId = category.CategoryId
                    });
                }
            }
            return itemList;
        }
        private IEnumerable<DAO.Bid> BuildBidList(IEnumerable<DAO.Item> itemList, IEnumerable<DAO.User> userList)
        {
            var bidList = new List<DAO.Bid>();
            var users = userList.ToList();
            var rand = new Random();
            int bidsCount;
            double amount;
            foreach (var item in itemList)
            {
                bidsCount = rand.Next(5);
                amount = item.StartingPrice / 100;
                for (int i = bidsCount; i >= 0; i--)
                {
                    bidList.Add(new DAO.Bid
                    {
                        ItemId = item.ItemId,
                        UserId = users[rand.Next(users.Count)].UserId,
                        CreationDate = item.EndDate.AddMinutes(-i),
                        Amount = Convert.ToInt32(amount * 100),
                    });
                    amount *= rand.NextDouble() * (1.15 - 1.1) + 1.1;
                }
            }
            return bidList;
        }
        private IEnumerable<Delivery> BuildDeliveryList(IEnumerable<DAO.Bid> bidList)
        {
            var deliveryList = new List<Delivery>();
            var rand = new Random();
            var cities = new List<string> { "Opole", "Warszawa", "Kraków", "Gdynia", "Gdańsk" };
            var streets = new List<string> { "Sezamkowa", "Ogórkowa", "Pomidorowa", "Pomarańczowa", "Bananowa", "Malinowa", "Truskakowka" };

            foreach (var bid in bidList.Where(bid => bid.CreationDate >= bid.Item.EndDate))
            {
                deliveryList.Add(new Delivery
                {
                    BidId = bid.BidId,
                    City = cities[rand.Next(cities.Count)],
                    PostalCode = $"{rand.Next(0, 9)}{rand.Next(0, 9)}-{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}",
                    Street = streets[rand.Next(streets.Count)],
                    BuldingNumber = rand.Next(1, 20).ToString(),
                    ApartmentNumber = null,
                    CreationDate = DateTime.Now
                });
            }
            return deliveryList;
        }
    }
}
