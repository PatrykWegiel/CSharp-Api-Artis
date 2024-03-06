using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artis.IData.Item;
using Microsoft.EntityFrameworkCore;

namespace Artis.Data.Sql.Item
{
    public class ItemRepository : IItemRepository
    {
        private readonly ArtisDbContext _context;

        public ItemRepository(ArtisDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Item.Item> GetAuctionItem(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.ItemId == id);
            return new Domain.Item.Item(
                item.ItemId,
                item.CategoryId,
                item.UserId,
                item.StartingPrice,
                item.ItemName,
                item.ItemDescription,
                item.ItemImageHref,
                item.Condition,
                item.CreationDate,
                item.EndDate,
                item.Banned,
                item.Visible);
        }
        public async Task<List<Domain.Item.Item>> GetAuctionItemsByUser(int userId)
        {
            var items = await _context.Item.Where(x => x.UserId == userId).ToListAsync();
            return items.Select(item => new Domain.Item.Item(
                item.ItemId,
                item.CategoryId,
                item.UserId,
                item.StartingPrice,
                item.ItemName,
                item.ItemDescription,
                item.ItemImageHref,
                item.Condition,
                item.CreationDate,
                item.EndDate,
                item.Banned,
                item.Visible)).ToList();
        }
        public async Task<List<Domain.Item.Item>> GetAuctionItemsByCategory(int categoryId)
        {
            var items = await _context.Item.Where(x => x.CategoryId == categoryId).ToListAsync();
            return items.Select(item => new Domain.Item.Item(
                item.ItemId,
                item.CategoryId,
                item.UserId,
                item.StartingPrice,
                item.ItemName,
                item.ItemDescription,
                item.ItemImageHref,
                item.Condition,
                item.CreationDate,
                item.EndDate,
                item.Banned,
                item.Visible)).ToList();
        }
        public async Task<int> CreateAuctionItem(Domain.Item.Item createItem)
        {
            var item = new DAO.Item
            {
                CategoryId = createItem.CategoryId,
                UserId = createItem.UserId,
                StartingPrice = createItem.StartingPrice,
                ItemName = createItem.ItemName,
                ItemDescription = createItem.ItemDescription,
                ItemImageHref = createItem.ItemImageHref,
                Condition = createItem.Condition,
                CreationDate = DateTime.UtcNow,
                EndDate = createItem.EndDate,
                Banned = false,
                Visible = true
            };
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.ItemId;
        }
        public async Task EditAuctionItem(Domain.Item.Item editItem)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.ItemId == editItem.ItemId);
            item.CategoryId = editItem.CategoryId;
            item.Condition = editItem.Condition;
            item.StartingPrice = editItem.StartingPrice;
            item.ItemName = editItem.ItemName;
            item.ItemDescription = editItem.ItemDescription;
            item.ItemImageHref = editItem.ItemImageHref;
            item.EndDate = editItem.EndDate;
            await _context.SaveChangesAsync();
        }
    }
}
