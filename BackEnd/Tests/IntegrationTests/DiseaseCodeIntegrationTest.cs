using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace IntegrationTests
{
    public class DiseaseCodeIntegrationTests : BaseIntegrationTest
    {
        private readonly ContabContext _context;

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task CreateDiseaseCode_ShouldAddNewEntry()
        {
            var diseaseCode = new DiseaseCode
            {
                DiseaseCode1 = "A01",
                DiseaseDescription = "Typhoid",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _context.DiseaseCodes.Add(diseaseCode);
            await _context.SaveChangesAsync();

            var createdDiseaseCode = await _context.DiseaseCodes.FirstOrDefaultAsync(dc => dc.DiseaseCode1 == "A01");

            Assert.NotNull(createdDiseaseCode);
            Assert.Equal("A01", createdDiseaseCode.DiseaseCode1);
        }

        [Fact]
        public async Task ReadDiseaseCode_ShouldReturnCorrectEntry()
        {
            var diseaseCode = new DiseaseCode
            {
                Id = 1,
                DiseaseCode1 = "A00",
                DiseaseDescription = "Cholera",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _context.DiseaseCodes.Add(diseaseCode);
            await _context.SaveChangesAsync();

            var readDiseaseCode = await _context.DiseaseCodes.FindAsync(1);

            Assert.NotNull(readDiseaseCode);
            Assert.Equal("A00", readDiseaseCode.DiseaseCode1);
        }

        [Fact]
        public async Task UpdateDiseaseCode_ShouldModifyExistingEntry()
        {
            var diseaseCode = new DiseaseCode
            {
                Id = 1,
                DiseaseCode1 = "A00",
                DiseaseDescription = "Cholera",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _context.DiseaseCodes.Add(diseaseCode);
            await _context.SaveChangesAsync();

            var existingDiseaseCode = await _context.DiseaseCodes.FindAsync(1);
            existingDiseaseCode.DiseaseCode1 = "A99";
            existingDiseaseCode.DiseaseDescription = "Updated Disease";

            _context.DiseaseCodes.Update(existingDiseaseCode);
            await _context.SaveChangesAsync();

            var updatedDiseaseCode = await _context.DiseaseCodes.FindAsync(1);

            Assert.NotNull(updatedDiseaseCode);
            Assert.Equal("A99", updatedDiseaseCode.DiseaseCode1);
            Assert.Equal("Updated Disease", updatedDiseaseCode.DiseaseDescription);
        }

        [Fact]
        public async Task DeleteDiseaseCode_ShouldRemoveEntry()
        {
            var diseaseCode = new DiseaseCode
            {
                Id = 1,
                DiseaseCode1 = "A00",
                DiseaseDescription = "Cholera",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _context.DiseaseCodes.Add(diseaseCode);
            await _context.SaveChangesAsync();

            var existingDiseaseCode = await _context.DiseaseCodes.FindAsync(1);
            _context.DiseaseCodes.Remove(existingDiseaseCode);
            await _context.SaveChangesAsync();

            var deletedDiseaseCode = await _context.DiseaseCodes.FindAsync(1);

            Assert.Null(deletedDiseaseCode);
        }
    }

}
