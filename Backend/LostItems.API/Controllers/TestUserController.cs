using LostItems.API.Interfaces.Repositories;
using LostItems.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostItems.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestUserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public TestUserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestUser()
        {
            var testUser = new User
            {
                Id = Guid.NewGuid(),
                PasswordHash = "passHash",
                Email = "testuser@example.com",
                NumOfFoundedItems = 0,
                NumOfLostItems = 0,
                Role = Enums.RoleEnum.User
            };

            await _userRepo.AddAsync(testUser);
            return CreatedAtAction(nameof(CreateTestUser), new { id = testUser.Id }, testUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();
            return Ok(users);
        }
    }
}
