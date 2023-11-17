
using KaganWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KaganWebApi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly string key;
        public UserService(IConfiguration configuration)
        {
            var client =  new MongoClient(configuration.GetConnectionString("HyphenDb"));

            var database = client.GetDatabase("HyphenDb");

            users = database.GetCollection<User>("Users");

            this.key = configuration.GetSection("JwtKey").ToString();
        }
        public List<User> GetUsers() => users.Find(user => true).ToList(); 
        public User GetUser(string id)=> users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            users.InsertOne(user);
            return user;
        }
        public string Authenticate(string email, string password)
        {
            var user = this.users.Find(x=> x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return null;

            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
