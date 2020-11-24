using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

public class CoffeeService
{
    private readonly IDynamoDBContext _context;
    public CoffeeService(IDynamoDBContext context) {
        _context = context;
    }

    public  async Task<List<Coffee>> GetAll() {
        var query = new QueryOperationConfig();
        var result = this._context.FromQueryAsync<Coffee>(query);
        return await result.GetRemainingAsync();
    }

    public  async Task<Coffee> GetById(string coffeeId) {
       return await this._context.LoadAsync<Coffee>(coffeeId);        
    }

    public async Task<Coffee> Create(Coffee coffee) {
        await _context.SaveAsync(coffee);
        return await _context.LoadAsync<Coffee>(coffee.CoffeeId, new DynamoDBContextConfig { ConsistentRead = true });
    }

    public  async Task<Coffee> Update(string coffeeId, Coffee coffee) {
       var retrievedCoffee = await this._context.LoadAsync<Coffee>(coffeeId);        
       retrievedCoffee.CoffeeName = coffee.CoffeeName;
       await _context.SaveAsync(retrievedCoffee);
       return await _context.LoadAsync<Coffee>(coffeeId, new DynamoDBContextConfig { ConsistentRead = true });
    }

    public  async Task Delete(string coffeeId) {
       await this._context.DeleteAsync<Coffee>(coffeeId);              
    }
}